using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;
using Microsoft.Web.WebView2.Core;
using static RssReader.ItemData; // WebView2 名前空間

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

        public EventHandler listBox1_SelectedIndexChanged { get; }

        public お気に入り() {
            InitializeComponent();

            foreach (var pair in rssSources) {
                var item = new ListItem(pair.Key, pair.Value);
                listBox1.Items.Add(item);
                cbSave.Items.Add(item);
            }

            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            button1.Click += btRssGet_Click;

            // WebView2 初期化
            webView21.CoreWebView2InitializationCompleted += WebView_Initialized;
            _ = webView21.EnsureCoreWebView2Async();
        }

        private void WebView_Initialized(object sender, CoreWebView2InitializationCompletedEventArgs e) {
            if (e.IsSuccess) {
                webView21.CoreWebView2.Settings.IsScriptEnabled = true;
            } else {
                MessageBox.Show("WebView2 の初期化に失敗しました: " + e.InitializationException.Message);
            }
        }

        private async void listBox2_SelectedIndexChanged(object sender, EventArgs e) {
            int index = listBox2.SelectedIndex;
            if (index < 0 || items == null || index >= items.Count) return;

            string link = items[index].Link;

            try {
                webView21.CoreWebView2.Navigate(link);
            }
            catch (Exception ex) {
                MessageBox.Show("ページ表示に失敗しました: " + ex.Message);
            }
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            if (cbSave.SelectedItem is not ListItem sel) {
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

                listBox2.Items.Clear();
                items.ForEach(i => listBox2.Items.Add(i.Title));
            }
            catch (Exception ex) {
                MessageBox.Show("RSS取得に失敗しました: " + ex.Message);
            }
        }

        private void 登録ボタン_Click(object sender, EventArgs e) {
            if (cbSave.SelectedItem is not ListItem sel) {
                MessageBox.Show("登録するカテゴリを選択してください。");
                return;
            }
            if (!favorites.Contains(sel.Url)) {
                favorites.Add(sel.Url);
                cbOutput.Items.Add(sel);
                SaveSearchResult("URL保存", sel.Url);
                MessageBox.Show("登録されました");
            } else {
                MessageBox.Show("既に登録済みです");
            }
        }

        public void SaveSearchResult(string keyword, string result) {
            File.AppendAllText(historyFilePath, $"{DateTime.Now:u}\t{keyword}\n{result}\n");
        }
    }


}
