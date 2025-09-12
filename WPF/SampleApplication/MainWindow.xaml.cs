using System;
using System.Windows;
using System.Windows.Controls;

namespace SampleApplication {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        // 季節コンボボックスの選択が変わった時
        private void seasonComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (seasonComboBox.SelectedItem is ComboBoxItem selectedItem) {
                seasonTextBlock.Text = (string)selectedItem.Content;
            }
        }

        // チェックボックスがチェックされた時
        private void checkBox_Checked(object sender, RoutedEventArgs e) {
            checkBoxTextBlock.Text = "チェック済み";
        }

        // チェックボックスのチェックが外れた時
        private void checkBox_Unchecked(object sender, RoutedEventArgs e) {
            checkBoxTextBlock.Text = "未チェック";
        }

        // 赤ラジオボタンが選択された時
        private void redRadioButton_Checked(object sender, RoutedEventArgs e) {
            colorTextBox.Text = "赤";
        }

        // 黄ラジオボタンが選択された時
        private void yellowRadioButton_Checked(object sender, RoutedEventArgs e) {
            colorTextBox.Text = "黄";
        }

        // 青ラジオボタンが選択された時
        private void blueRadioButton_Checked(object sender, RoutedEventArgs e) {
            colorTextBox.Text = "青";
        }
    }
}