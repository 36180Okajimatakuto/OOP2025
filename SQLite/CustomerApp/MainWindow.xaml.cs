using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CustomerApp {



    public partial class MainWindow : Window {
        private SQLiteAsyncConnection _database;
        private Customer _selectedCustomer;
        private string _dbPath = Path.Combine(Environment.CurrentDirectory, "customers.db3");
        private byte[] _selectedImageBytes;

        public MainWindow() {
            InitializeComponent();
            _database = new SQLiteAsyncConnection(_dbPath);
            InitDatabase();
        }

        private async void InitDatabase() {
            await _database.CreateTableAsync<Customer>();
            await LoadCustomers();
        }

        private async Task LoadCustomers() {
            var customers = await _database.Table<Customer>().ToListAsync();
            CustomerListView.ItemsSource = customers;
        }

        private async void Add_Click(object sender, RoutedEventArgs e) {
            var customer = new Customer {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = _selectedImageBytes
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
                _selectedImageBytes = selected.Picture;

                if (_selectedImageBytes != null && _selectedImageBytes.Length > 0) {
                    CustomerImage.Source = ByteArrayToImage(_selectedImageBytes);
                } else {
                    CustomerImage.Source = null;
                }
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
            return image;
        }

        // =================== ここから検索機能 ===================

        private async void SearchButton_Click(object sender, RoutedEventArgs e) {
            await SearchCustomers();
        }
        //自動検索機能（文字を入力したらすぐに検索する機能
        private async void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            string keyword = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(keyword)) {
                // キーワードが空なら全件表示
                await LoadCustomers();
                return;
            }

            // 名前・電話・住所のいずれかにキーワードが含まれるものを検索
            var filtered = await _database.Table<Customer>()
                .Where(c => c.Name.Contains(keyword) || c.Phone.Contains(keyword) || c.Address.Contains(keyword))
                .ToListAsync();

            CustomerListView.ItemsSource = filtered;
        }

        private async void ClearSearchButton_Click(object sender, RoutedEventArgs e) {
            SearchTextBox.Text = "";
            await LoadCustomers();
        }

        private async Task SearchCustomers() {
            string keyword = SearchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(keyword)) {
                await LoadCustomers();
                return;
            }
            //修正中
            //    var query = _database.Table<Customer>().Where(c =>
            //        c.Name.Contains(keyword) ||
            //        c.Phone.Contains(keyword) ||
            //        c.Address.Contains(keyword));

            //    var results = await query.ToListAsync();

            //    CustomerListView.ItemsSource = results;
        }



        ///お試しGoogleMAP
        private const string GoogleMapsApiKey = "YOUR_API_KEY_HERE";

        private async void MapSearchButton_Click(object sender, RoutedEventArgs e) {
            string address = MapSearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(address)) {
                MessageBox.Show("住所を入力してください。");
                return;
            }

            string url = BuildStaticMapUrl(address);
            await LoadMapImageAsync(url);
        }

        private string BuildStaticMapUrl(string address) {
            // 住所はURLエンコード必須
            string encodedAddress = Uri.EscapeDataString(address);

            // 地図サイズやズームレベルは適宜調整してください
            return $"https://maps.googleapis.com/maps/api/staticmap?center={encodedAddress}&zoom=15&size=480x360&markers=color:red|{encodedAddress}&key={GoogleMapsApiKey}";
        }

        private async Task LoadMapImageAsync(string url) {
            try {
                using HttpClient client = new HttpClient();
                var stream = await client.GetStreamAsync(url);

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();

                MapImage.Source = bitmap;
            }
            catch (Exception ex) {
                MessageBox.Show("地図画像の取得に失敗しました。\n" + ex.Message);
            }
        }

    }
}
