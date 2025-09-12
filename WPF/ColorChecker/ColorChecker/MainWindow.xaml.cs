using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorChecker {
    public partial class MainWindow : Window {

        private List<MyColor> stockColors = new List<MyColor>();

        public MainWindow() {
            InitializeComponent();
            InitComboBoxColors();
            UpdateColorPreview();
            UpdatePlaceholderVisibility();
        }

        // スライダー変更時
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            if (rValue == null || gValue == null || bValue == null) return;

            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            rValue.Text = r.ToString();
            gValue.Text = g.ToString();
            bValue.Text = b.ToString();

            UpdateColorPreview();
        }

        // 色プレビュー更新
        private void UpdateColorPreview() {
            Color c = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(c);
        }

        //登録ボタンクリック
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            string name = colorNameTextBox.Text.Trim();

            // 名前が空ならコンボボックスの選択色の名前を使う
            if (string.IsNullOrEmpty(name)) {
                if (colorSelectComboBox.SelectedItem is PropertyInfo prop) {
                    name = prop.Name;
                }

                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("色の名前を入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            Color newColorValue = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);

            // 名前が既に登録されている色があるかチェック
            // 名前が既に登録されている色を探す
            var existing = stockColors.Find(c => c.Name == name);

            if (existing.Color != default) {
                // RGBが異なればエラー
                if (existing.Color != newColorValue) {
                    MessageBox.Show($"名前「{name}」は既に別の色(R:{existing.Color.R} G:{existing.Color.G} B:{existing.Color.B})で登録されています。", "登録エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                } else {
                    // RGBも同じなら選択状態にして終了
                    stockList.SelectedItem = existing;
                    return;
                }
            }
            // さらに、名前はコンボボックス由来で、RGBが変更されている場合の判定を追加
            if (string.IsNullOrEmpty(colorNameTextBox.Text) && colorSelectComboBox.SelectedItem is PropertyInfo selectedProp) {
                Color comboColor = (Color)selectedProp.GetValue(null, null);
                if (comboColor != newColorValue) {
                    MessageBox.Show("コンボボックスに登録されている色の名前で登録しようとしていますが、RGBが変更されています。名前を入力してください。", "登録エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }



            // 新規登録
            MyColor newColor = new MyColor {
                Name = name,
                Color = newColorValue
            };

            stockColors.Add(newColor);
            stockList.Items.Add(newColor);
            colorNameTextBox.Clear();
            UpdatePlaceholderVisibility();
            stockList.SelectedItem = newColor;
        }

        // 登録リスト選択変更時
        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selected) {
                Color c = selected.Color;
                rSlider.Value = c.R;
                gSlider.Value = c.G;
                bSlider.Value = c.B;
            }
        }

        // ComboBox選択変更時
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedItem is PropertyInfo prop) {
                Color c = (Color)prop.GetValue(null, null);
                rSlider.Value = c.R;
                gSlider.Value = c.G;
                bSlider.Value = c.B;
            }
        }

        // コンボボックスにColorsをセット
        private void InitComboBoxColors() {
            var colorProps = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static);
            colorSelectComboBox.ItemsSource = colorProps;
        }

        // TextBoxのテキスト変更時
        private void colorNameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            UpdatePlaceholderVisibility();
        }

        // プレースホルダー表示制御
        private void UpdatePlaceholderVisibility() {
            if (string.IsNullOrEmpty(colorNameTextBox.Text)) {
                placeholderText.Visibility = Visibility.Visible;
            } else {
                placeholderText.Visibility = Visibility.Collapsed;
            }
        }
    }
}