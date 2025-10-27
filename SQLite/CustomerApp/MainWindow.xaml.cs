using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CustomerApp {
    public partial class MainWindow : Window {
        private SQLiteAsyncConnection _database;
        private Customer _selectedCustomer;
        private string _dbPath = Path.Combine(Environment.CurrentDirectory, "customers.db3");
        private byte[] _selectedImageBytes;
        private readonly HttpClient _httpClient = new HttpClient();

        private CancellationTokenSource _ctsZip;

        public MainWindow() {
            InitializeComponent();
            _database = new SQLiteAsyncConnection(_dbPath);
            InitDatabase();

            // 郵便番号自動取得用イベント
            AddressTextBox.TextChanged += AddressTextBox_TextChanged;
        }

        private async void InitDatabase() {
            await _database.CreateTableAsync<Customer>();
            await LoadCustomers();
        }

        private async Task LoadCustomers() {
            var customers = await _database.Table<Customer>().ToListAsync();
            CustomerListView.ItemsSource = customers;
        }

        // ==================== CRUD ====================
        private async void Add_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = _selectedImageBytes,
                Postcode = PostcodeTextBox.Text
            };

            await _database.InsertAsync(customer);
            ClearForm();
            await LoadCustomers();
        }

        private async void Update_Click(object sender, RoutedEventArgs e) {
            if (_selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください。");
                return;
            }

            _selectedCustomer.Name = NameTextBox.Text;
            _selectedCustomer.Phone = PhoneTextBox.Text;
            _selectedCustomer.Address = AddressTextBox.Text;
            _selectedCustomer.Picture = _selectedImageBytes;
            _selectedCustomer.Postcode = PostcodeTextBox.Text;

            await _database.UpdateAsync(_selectedCustomer);
            ClearForm();
            await LoadCustomers();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e) {
            if (_selectedCustomer == null) {
                MessageBox.Show("削除する顧客を選択してください。");
                return;
            }

            await _database.DeleteAsync(_selectedCustomer);
            ClearForm();
            await LoadCustomers();
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CustomerListView.SelectedItem is Customer selected) {
                _selectedCustomer = selected;
                NameTextBox.Text = selected.Name;
                PhoneTextBox.Text = selected.Phone;
                AddressTextBox.Text = selected.Address;
                PostcodeTextBox.Text = selected.Postcode;
                _selectedImageBytes = selected.Picture;

                CustomerImage.Source = _selectedImageBytes != null ? ByteArrayToImage(_selectedImageBytes) : null;
            }
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e) {
            var dialog = new OpenFileDialog {
                Title = "画像を選択",
                Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dialog.ShowDialog() == true) {
                _selectedImageBytes = File.ReadAllBytes(dialog.FileName);
                CustomerImage.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }

        private void ClearForm() {
            NameTextBox.Text = "";
            PhoneTextBox.Text = "";
            AddressTextBox.Text = "";
            PostcodeTextBox.Text = "";
            CustomerImage.Source = null;
            _selectedCustomer = null;
            _selectedImageBytes = null;
            CustomerListView.SelectedItem = null;
        }

        private BitmapImage ByteArrayToImage(byte[] imageData) {
            using var ms = new MemoryStream(imageData);
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = ms;
            image.EndInit();
            image.Freeze();
            return image;
        }

        // ==================== 検索 ====================
        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            string keyword = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(keyword)) {
                await LoadCustomers();
                return;
            }

            var filtered = await _database.Table<Customer>()
                .Where(c => c.Name.Contains(keyword) || c.Phone.Contains(keyword) || c.Address.Contains(keyword))
                .ToListAsync();

            CustomerListView.ItemsSource = filtered;
        }

        private async void ClearSearchButton_Click(object sender, RoutedEventArgs e) {
            SearchTextBox.Text = "";
            await LoadCustomers();
        }

        // ==================== 郵便番号自動取得 ====================
        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            _ctsZip?.Cancel();

            string address = AddressTextBox.Text.Trim();
            if (string.IsNullOrEmpty(address)) {
                PostcodeTextBox.Text = "";
                return;
            }

            _ctsZip = new CancellationTokenSource();
            var token = _ctsZip.Token;

            _ = Task.Run(async () => {
                try {
                    await Task.Delay(500, token); // デバウンス
                    if (token.IsCancellationRequested) return;

                    string postal = "検索中...";
                    await Dispatcher.InvokeAsync(() => PostcodeTextBox.Text = postal);

                    string url = $"https://zipcloud.ibsnet.co.jp/api/search?address={Uri.EscapeDataString(address)}";
                    string json = await _httpClient.GetStringAsync(url);

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<ZipCloudResponse>(json, options);

                    if (result != null && result.Status == 200 && result.Results?.Count > 0) {
                        postal = result.Results[0].Zipcode;
                        if (postal.Length == 7) postal = postal.Insert(3, "-");
                    } else {
                        postal = "該当なし";
                    }

                    await Dispatcher.InvokeAsync(() => PostcodeTextBox.Text = postal);
                }
                catch (TaskCanceledException) { /* 無視 */ }
                catch {
                    await Dispatcher.InvokeAsync(() => PostcodeTextBox.Text = "通信エラー");
                }
            });
        }

        // ==================== JSON解析用クラス ====================
        private class ZipCloudResponse {
            [JsonPropertyName("message")]
            public string Message { get; set; }

            [JsonPropertyName("status")]
            public int Status { get; set; }

            [JsonPropertyName("results")]
            public List<ZipCloudResult> Results { get; set; }
        }

        private class ZipCloudResult {
            [JsonPropertyName("zipcode")]
            public string Zipcode { get; set; }

            [JsonPropertyName("address1")]
            public string Address1 { get; set; }

            [JsonPropertyName("address2")]
            public string Address2 { get; set; }

            [JsonPropertyName("address3")]
            public string Address3 { get; set; }
        }
    }
}
