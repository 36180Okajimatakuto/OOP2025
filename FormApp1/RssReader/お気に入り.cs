using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;
using Microsoft.Web.WebView2.Core;
using System.Drawing;

namespace RssReader {
    public partial class お気に入り : Form {
        private List<string> favorites = new List<string>();
        private string historyFilePath = "search_history.txt";
        private List<ItemData> items;

        private Dictionary<string, string> rssSources = new Dictionary<string, string> {
            { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "科学", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "地域", "https://news.yahoo.co.jp/rss/topics/local.xml" }
        };

        // 画像背景関連
        private string imageSaveFolder;
        private string configPath;

        public EventHandler listBox1_SelectedIndexChanged { get; }

        public お気に入り() {
            InitializeComponent();

            imageSaveFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

            foreach (var pair in rssSources) {
                var item = new ListItem(pair.Key, pair.Value);
                cbOutput.Items.Add(item);
            }
            cbOutput.Items.Insert(0, new ListItem("すべて", "ALL"));
            btnAddNewRss.Click += btnAddNewRss_Click;
            RSS内容一覧.SelectedIndexChanged += RSS内容一覧_SelectedIndexChanged;
            button1.Click += btRssGet_Click;
            btnRemoveRss.Click += btnRemoveRss_Click;

            // WebView2 初期化
            サイト表示.CoreWebView2InitializationCompleted += WebView_Initialized;
            _ = サイト表示.EnsureCoreWebView2Async();
            サイト表示.Source = new Uri("https://dinorunner.com/jp/");

            // 背景画像復元
            LoadBackgroundImage();

            // 背景画像設定ボタンのイベント登録（例：btnLoadImage）
            btnLoadImage.Click += btnLoadImage_Click;
        }

        private void WebView_Initialized(object sender, CoreWebView2InitializationCompletedEventArgs e) {
            if (e.IsSuccess) {
                サイト表示.CoreWebView2.Settings.IsScriptEnabled = true;
            } else {
                MessageBox.Show("WebView2 の初期化に失敗しました: " + e.InitializationException.Message);
            }
        }

        private async void RSS内容一覧_SelectedIndexChanged(object sender, EventArgs e) {
            int index = RSS内容一覧.SelectedIndex;
            if (index < 0 || items == null || index >= items.Count) {
                if (サイト表示.CoreWebView2 != null)
                    サイト表示.CoreWebView2.Navigate("https://dinorunner.com/jp/");
                return;
            }

            string link = items[index].Link;

            try {
                サイト表示.CoreWebView2.Navigate(link);
            }
            catch (Exception ex) {
                MessageBox.Show("ページ表示に失敗しました: " + ex.Message);
            }
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            if (cbOutput.SelectedItem is not ListItem sel) {
                MessageBox.Show("カテゴリを選択してください。");
                return;
            }

            try {
                using var hc = new HttpClient();
                hc.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                string xml = await hc.GetStringAsync(sel.Url);
                var xdoc = XDocument.Parse(xml);
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string)x.Element("title"),
                        Link = (string)x.Element("link")
                    }).ToList();

                RSS内容一覧.Items.Clear();
                items.ForEach(i => RSS内容一覧.Items.Add(i.Title));
            }
            catch (Exception ex) {
                MessageBox.Show("RSS取得に失敗しました: " + ex.Message);
            }
        }

        private void btnAddNewRss_Click(object sender, EventArgs e) {
            string name = txtNewName.Text.Trim();
            string url = txtNewUrl.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(url)) {
                MessageBox.Show("カテゴリ名とURLの両方を入力してください。");
                return;
            }

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) {
                MessageBox.Show("有効なURLを入力してください。");
                return;
            }

            if (favorites.Contains(url)) {
                MessageBox.Show("このURLは既に登録済みです。");
                return;
            }

            var item = new ListItem(name, url);
            favorites.Add(url);
            cbOutput.Items.Add(item);
            SaveSearchResult("ユーザー追加RSS", url);
            MessageBox.Show("新しいRSSリンクが登録されました！");
        }

        private void btnRemoveRss_Click(object sender, EventArgs e) {
            if (cbOutput.SelectedItem is not ListItem selected) {
                MessageBox.Show("削除するRSSを選択してください。");
                return;
            }
            DialogResult result = MessageBox.Show($"「{selected.Name}」を削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                favorites.Remove(selected.Url);
                cbOutput.Items.Remove(selected);
                SaveSearchResult("RSS削除", selected.Url);
                MessageBox.Show("RSSが削除されました。");
            }
        }

        public void SaveSearchResult(string keyword, string result) {
            File.AppendAllText(historyFilePath, $"{DateTime.Now:u}\t{keyword}\n{result}\n");
        }

        // =======================
        // 背景画像関連
        // =======================

        private void btnLoadImage_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "背景に設定する画像ファイルを選択してください";
                ofd.Filter = "画像ファイル|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    string sourcePath = ofd.FileName;

                    if (!Directory.Exists(imageSaveFolder)) {
                        Directory.CreateDirectory(imageSaveFolder);
                    }

                    string destPath = Path.Combine(imageSaveFolder, Path.GetFileName(sourcePath));

                    try {
                        File.Copy(sourcePath, destPath, true);

                        if (this.BackgroundImage != null) {
                            this.BackgroundImage.Dispose();
                        }

                        this.BackgroundImage = Image.FromFile(destPath);
                        this.BackgroundImageLayout = ImageLayout.Stretch;

                        File.WriteAllText(configPath, Path.GetFileName(destPath));

                        MessageBox.Show("背景画像を設定しました。\nファイル: " + destPath);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("画像のコピーまたは読み込みに失敗しました:\n" + ex.Message);
                    }
                }
            }
        }

        private void LoadBackgroundImage() {
            if (!File.Exists(configPath)) return;

            string fileName = File.ReadAllText(configPath).Trim();
            if (string.IsNullOrEmpty(fileName)) return;

            string imagePath = Path.Combine(imageSaveFolder, fileName);
            if (!File.Exists(imagePath)) return;

            try {
                if (this.BackgroundImage != null) {
                    this.BackgroundImage.Dispose();
                }

                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex) {
                MessageBox.Show("背景画像の読み込みに失敗しました:\n" + ex.Message);
            }
        }

    }

    // ListItemクラスの例（必要ならご利用ください）
    public class ListItem {
        public string Name { get; }
        public string Url { get; }
        public ListItem(string name, string url) {
            Name = name;
            Url = url;
        }
        public override string ToString() => Name;
    }
}
