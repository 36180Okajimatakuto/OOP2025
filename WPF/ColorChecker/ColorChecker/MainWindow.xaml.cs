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

        #region スライダー変更時
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
        #endregion

        #region 色プレビュー更新
        private void UpdateColorPreview() {
            Color c = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(c);
        }
        #endregion

        #region 登録ボタンと重複チェック
        //登録ボタンクリック
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            string name = colorNameTextBox.Text.Trim();

            // 名前が空ならコンボボックスから名前を取得（MyColorに変更されてる）
            if (string.IsNullOrEmpty(name)) {
                if (colorSelectComboBox.SelectedItem is MyColor selectedColorFromCombo) {
                    name = selectedColorFromCombo.Name;
                }

                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("色の名前を入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            Color newColorValue = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);

            // 既存のチェック
            var existing = stockColors.Find(c => c.Name == name);

            if (existing.Color != default) {
                if (existing.Color != newColorValue) {
                    MessageBox.Show($"名前「{name}」は既に別の色(R:{existing.Color.R} G:{existing.Color.G} B:{existing.Color.B})で登録されています。", "登録エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                } else {
                    stockList.SelectedItem = existing;
                    return;
                }
            }


            // 名前未入力でComboBoxから選択し、RGBが変更された場合の警告
            if (string.IsNullOrEmpty(colorNameTextBox.Text) && colorSelectComboBox.SelectedItem is MyColor selectedComboColor) {
                if (selectedComboColor.Color != newColorValue) {
                    MessageBox.Show("コンボボックスで選択された色のRGB値が変更されています。名前を入力してください。", "登録エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            #endregion

            #region 新規登録
            // 新規登録
            MyColor newColor = new MyColor {
                Name = name,
                Color = newColorValue
            };
            #endregion

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

        // ComboBoxの内容変更
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorSelectComboBox.SelectedItem is MyColor item) {
                Color c = item.Color;
                rSlider.Value = c.R;
                gSlider.Value = c.G;
                bSlider.Value = c.B;
            }
        }

        // コンボボックスに色を入れる
        private void InitComboBoxColors() {
            var colorProps = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var colorList = new List<MyColor>();
            
            foreach (var prop in colorProps) {
                var color = (Color)prop.GetValue(null, null);
                colorList.Add(new MyColor {
                    Name = prop.Name,
                    Color = color
                });
            }

            colorSelectComboBox.ItemsSource = colorList;
        }

        // TextBoxのテキスト変更時
        private void colorNameTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            UpdatePlaceholderVisibility();
        }

        // なんかXAMLに対応させたやつ
        private void UpdatePlaceholderVisibility() {
            if (string.IsNullOrEmpty(colorNameTextBox.Text)) {
                placeholderText.Visibility = Visibility.Visible;
            } else {
                placeholderText.Visibility = Visibility.Collapsed;
            }
        }
        //削除ボタン
        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            if (stockList.SelectedItem is MyColor selected) {
                MessageBoxResult result = MessageBox.Show(
                    $"色「{selected.Name}」を削除しますか？",
                    "削除の確認",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) {
                    stockColors.Remove(selected);
                    stockList.Items.Remove(selected);
                    stockList.SelectedItem = null;
                    UpdatePlaceholderVisibility();
                }
            } else {
                MessageBox.Show("削除する色を選択してください。", "情報", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}