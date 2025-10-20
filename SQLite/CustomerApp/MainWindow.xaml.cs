using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
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

                if (_selectedImageBytes != null) {
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
    }
}
