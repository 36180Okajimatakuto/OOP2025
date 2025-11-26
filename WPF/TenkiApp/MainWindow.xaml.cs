using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow() {
            InitializeComponent();
            _ = LoadMajorCitiesWeatherAsync();
        }
        // Open-Meteo APIから天気データを取得するメソッド
        private async Task GetWeatherDataAsync(string city) {
            try {
                var coordinates = GetCoordinates(city);
                if (coordinates.Latitude == 0 && coordinates.Longitude == 0) {
                    MessageBox.Show("無効な都市名または県庁所在地です。");
                    return;
                }

                string latitude = coordinates.Latitude.ToString();
                string longitude = coordinates.Longitude.ToString();



                string url = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true&hourly=temperature_2m,weathercode,windspeed_10m,relativehumidity_2m\r\n&timezone=Asia%2FTokyo";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(responseBody);
                var weatherData = json["current_weather"];
                string temperature = weatherData["temperature"].ToString();
                string weatherCode = weatherData["weathercode"].ToString();
                string windSpeed = weatherData["windspeed"].ToString();
           //     string apparent_temperature = weatherData["apparent temperature"].ToString();  失敗
                string humidity = json["hourly"]["relativehumidity_2m"][0].ToString();

                // Current Weather Info
                Dispatcher.Invoke(() => {
                    Temperature.Text = $"{temperature} °C";
                    WeatherDescription.Text = GetWeatherDescription(weatherCode);
                    WindSpeed.Text = $"{windSpeed} m/s";
                    Humidity.Text = $"{humidity}%";
              //      apparent_temperature = $"{apparent_temperature}°C";　　　　失敗
                });

                // Hourly Forecast (Next 10 hours)
                var hourlyData = json["hourly"];
                Dispatcher.Invoke(() => {
                    HourlyForecast.Children.Clear();
                    for (int i = 0; i < 10; i++) {
                        var time = hourlyData["time"][i].ToString();
                        var temp = hourlyData["temperature_2m"][i].ToString();
                        var icon = hourlyData["weathercode"][i].ToString();

                        var weather = json["current_weather"];
                        string code = weather?["weathercode"]?.ToString() ?? "unknown"; // defaultコード
                        string icons = GetWeatherIcon(code);

                        // Create and add weather elements for each hour
                        var hourBlock = new StackPanel {
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(5) // 全体の余白を少しだけ確保
                        };

                        var hourText = new TextBlock {
                            Text = $"{DateTime.Parse(time).Hour}時",
                            FontSize = 12,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(0, 5, 0, 5)  // 上下5px
                        };

                        var tempText = new TextBlock {
                            Text = $"{temp} °C",
                            FontSize = 14,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            Margin = new Thickness(0, 5, 0, 5)  // 上下5px
                        };

                        var iconText = new TextBlock {
                            Text = icons,
                            FontSize = 36,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            TextAlignment = TextAlignment.Center,
                            FontFamily = new FontFamily("Segoe UI Emoji"),
                            Margin = new Thickness(0, 5, 0, 5)  // 上下5px
                        };

                        hourBlock.Children.Add(hourText);
                        hourBlock.Children.Add(tempText);
                        hourBlock.Children.Add(iconText);

                        HourlyForecast.Children.Add(hourBlock);
                    }
                });
            }
            catch (Exception ex) {
                MessageBox.Show($"天気データの取得中にエラーが発生しました: {ex.Message}");
            }
        }

        // 都市名に対応する緯度経度を返すメソッド
        private (double Latitude, double Longitude) GetCoordinates(string city) {
            // 都道府県庁所在地の座標データ（都市名とその緯度経度）
            if (city == "東京") { return (35.6895, 139.6917); } // 東京
            if (city == "大阪") { return (34.6937, 135.5023); } // 大阪
            if (city == "京都") { return (35.0116, 135.7681); } // 京都
            if (city == "札幌") { return (43.0618, 141.3545); } // 札幌
            if (city == "福岡") { return (33.5904, 130.4017); } // 福岡
            if (city == "名古屋") { return (35.1815, 136.9066); } // 名古屋
            if (city == "仙台") { return (38.2682, 140.8694); } // 仙台
            if (city == "千葉") { return (35.6074, 140.1069); } // 千葉
            if (city == "埼玉") { return (35.8617, 139.6489); } // 埼玉
            if (city == "広島") { return (34.3853, 132.4553); } // 広島
            if (city == "神戸") { return (34.6901, 135.1955); } // 神戸
            if (city == "長崎") { return (32.7503, 129.8777); } // 長崎
            if (city == "鹿児島") { return (31.5960, 130.5563); } // 鹿児島
            if (city == "沖縄") { return (26.2124, 127.6809); } // 沖縄
            if (city == "横浜") { return (35.4444, 139.6370); } // 横浜
            if (city == "新潟") { return (37.9025, 139.0233); } // 新潟
            if (city == "岡山") { return (34.6618, 133.9344); } // 岡山
            if (city == "高松") { return (34.3428, 134.0466); } // 高松
            if (city == "松山") { return (33.8392, 132.7652); } // 松山
            if (city == "那覇") { return (26.2124, 127.6809); } // 那覇
            if (city == "太田") { return (36.2030, 139.6009); } // 太田
            if (city == "伊勢崎") { return (35.8040, 139.3833); } // 伊勢崎
            if (city == "桐生") { return (36.3916, 139.3814); } // 桐生
            if (city == "青森") { return (40.8226, 140.7474); } // 青森
            if (city == "秋田") { return (39.7186, 140.1025); } // 秋田
            if (city == "富山") { return (36.6953, 137.2113); } // 富山
            if (city == "石川") { return (36.5940, 136.6255); } // 石川
            if (city == "福井") { return (36.0653, 136.2216); } // 福井
            if (city == "滋賀") { return (35.0044, 135.8686); } // 滋賀
            if (city == "奈良") { return (34.6851, 135.8048); } // 奈良
            if (city == "和歌山") { return (34.2260, 135.1675); } // 和歌山
            if (city == "三重") { return (34.7303, 136.5086); } // 三重
            if (city == "群馬") { return (36.3910, 139.0606); } // 群馬
            if (city == "長野") { return (36.6513, 138.1810); } // 長野
            if (city == "山梨") { return (35.6635, 138.5684); } // 山梨
            if (city == "愛知") { return (35.1801, 136.9066); } // 愛知
            if (city == "岐阜") { return (35.3912, 136.7223); } // 岐阜
            if (city == "静岡") { return (34.9756, 138.3828); } // 静岡
            if (city == "奈良") { return (34.6851, 135.8048); } // 奈良
            if (city == "佐賀") { return (33.2635, 130.2980); } // 佐賀
            if (city == "大分") { return (33.2382, 131.6126); } // 大分
            if (city == "宮崎") { return (31.9111, 131.4231); } // 宮崎
            if (city == "山口") { return (34.1859, 131.4714); } // 山口
            if (city == "広島") { return (34.3853, 132.4553); } // 広島
            if (city == "高知") { return (33.5597, 133.5311); } // 高知
            if (city == "熊本") { return (32.8031, 130.7079); } // 熊本
            if (city == "長野") { return (36.6513, 138.1810); } // 長野
            if (city == "福島") { return (37.7598, 140.4741); } // 福島
            if (city == "茨城") { return (36.3414, 140.4467); } // 茨城
            if (city == "栃木") { return (36.5657, 139.8836); } // 栃木
            if (city == "滋賀") { return (35.0044, 135.8686); } // 滋賀
            if (city == "宮城") { return (38.2682, 140.8694); } // 宮城
            if (city == "札幌") { return (43.0618, 141.3545); } // 札幌
            if (city == "函館") { return (41.7681, 140.7300); } // 函館
            if (city == "旭川") { return (43.7707, 142.3655); } // 旭川
            if (city == "帯広") { return (42.9333, 143.1917); } // 帯広
            if (city == "釧路") { return (42.9777, 144.3800); } // 釧路
            if (city == "北見") { return (43.8014, 143.8954); } // 北見
            if (city == "室蘭") { return (42.3184, 140.9765); } // 室蘭
            if (city == "苫小牧") { return (42.6323, 141.6040); } // 苫小牧
            if (city == "小樽") { return (43.2006, 141.0036); } // 小樽
            if (city == "北海道") { return (43.5, 142.0); }

              // 上記以外の都市（無効な都市）
            return (0, 0); // 無効な都市名
        }
      

        // weatherCodeを人間にわかりやすい天気に変換するメソッド
        private string GetWeatherDescription(string weatherCode) {
            switch (weatherCode) { 
        case "0": return "☀️ 快晴";
                case "1": return "🌤 ほぼ快晴";
                case "2": return "⛅ 一部曇り";
                case "3": return "☁️ 曇り";
                case "45": return "🌫 霧";
                case "48": return "🌫❄️ 樹氷を伴う霧";
                case "51": return "🌦 弱い霧雨";
                case "53": return "🌦💧 やや強い霧雨";
                case "55": return "🌧 強い霧雨";
                case "61": return "🌧 弱い雨";
                case "63": return "🌧🌧 やや強い雨";
                case "65": return "🌧💦 強い雨";
                case "71": return "🌨 弱い雪";
                case "73": return "🌨❄️ やや強い雪";
                case "75": return "❄️❄️ 強い雪";
                case "77": return "🌨🧊 霰（あられ）";
                case "80": return "🌦 弱いにわか雨";
                case "81": return "🌦💧 やや強いにわか雨";
                case "82": return "🌧💦 強いにわか雨";
                case "85": return "🌨 弱いにわか雪";
                case "86": return "🌨❄️ 強いにわか雪";
                case "95": return "⛈ 雷雨";
                case "96": return "⛈🧊 雹を伴う雷雨";
                case "99": return "⛈⚡ 激しい雷雨";
                default: return "❓ 不明な天気";
                
            }
        }

        // 検索ボタンのクリックイベント(消去しました）
        //private async void SearchWeather(object sender, RoutedEventArgs e) {
        //    string city = CityInput.Text.Trim();  // 入力された都市名を取得
        //    if (!string.IsNullOrEmpty(city)) {
        //        await GetWeatherDataAsync(city);
        //    } else {
        //        MessageBox.Show("都市名を入力してください。");
        //    }
        //}

        // ComboBoxの選択変更時に天気情報を検索
        private async void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // ComboBoxから選ばれた都市名を取得
            string city = (CityInput.SelectedItem as ComboBoxItem)?.Content.ToString().Trim();

            if (!string.IsNullOrEmpty(city)) {
                // 非同期で天気データを取得
                await GetWeatherDataAsync(city);
            } else {
                MessageBox.Show("都市名が選ばれていません。");
            }
        }

        private readonly List<(string Name, double Lat, double Lon)> MajorCities = new()
{
    ("東京", 35.6895, 139.6917),
    ("大阪", 34.6937, 135.5023),
    ("名古屋", 35.1815, 136.9066),
    ("札幌", 43.0618, 141.3545),
    ("福岡", 33.5904, 130.4017),
    ("仙台", 38.2682, 140.8694)
};

        private async Task LoadMajorCitiesWeatherAsync() {
            MajorCitiesWeatherPanel.Children.Clear();

            foreach (var city in MajorCities) {
                try {
                    string url =
                        $"https://api.open-meteo.com/v1/forecast?latitude={city.Lat}&longitude={city.Lon}" +
                        $"&current_weather=true&timezone=Asia%2FTokyo";

                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = JObject.Parse(await response.Content.ReadAsStringAsync());
                    var weather = json["current_weather"];

                    string temp = weather["temperature"].ToString();
                    string code = weather["weathercode"].ToString();

                    string iconUrl = $"https://open-meteo.com/images/weather-icons/{code}.png";

                    string icon = GetWeatherIcon(code);


                    // ---- UI 要素を生成 ----
                    var panel = new StackPanel {
                        Width = 120,
                        Margin = new Thickness(10),
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };

                    var cityName = new TextBlock {
                        Text = city.Name,
                        FontSize = 16,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    var iconText = new TextBlock {
                        Text = icon,
                        FontSize = 36,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(0, 5, 0, 5)
                    };


                    var tempText = new TextBlock {
                        Text = $"{temp}°C",
                        FontSize = 18,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    panel.Children.Add(cityName);
                    panel.Children.Add(iconText);
                    panel.Children.Add(tempText);

                    MajorCitiesWeatherPanel.Children.Add(panel);
                }
                catch {
                    // 失敗してもアプリが落ちないように
                    var error = new TextBlock {
                        Text = $"{city.Name}: 読込失敗",
                        Foreground = Brushes.Red
                    };
                    MajorCitiesWeatherPanel.Children.Add(error);
                }
            }
        }
        public static string GetWeatherIcon(string weatherCode2) {
            switch (weatherCode2) {
                case "0": return "☀️";
                case "1": return "🌤";
                case "2": return "⛅";
                case "3": return "☁️";
                case "45": return "🌫";
                case "48": return "🌫❄️";
                case "51": return "🌦";
                case "53": return "🌦💧";
                case "55": return "🌧";
                case "61": return "🌧";
                case "63": return "🌧🌧";
                case "65": return "🌧💦";
                case "71": return "🌨";
                case "73": return "🌨❄️";
                case "75": return "❄️❄️";
                case "77": return "🌨🧊";
                case "80": return "🌦";
                case "81": return "🌦💧";
                case "82": return "🌧💦";
                case "85": return "🌨";
                case "86": return "🌨❄️";
                case "95": return "⛈";
                case "96": return "⛈🧊";
                case "99": return "⛈⚡";
                default: return "❓";
            }
        }
    }
}