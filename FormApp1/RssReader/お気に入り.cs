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
                cbOutput.Items.Add(item);
            }
            #region Designer内容
            cbOutput.Items.Insert(0, new ListItem("すべて", "ALL"));
            btnAddNewRss.Click += btnAddNewRss_Click;
            RSS内容一覧.SelectedIndexChanged += RSS内容一覧_SelectedIndexChanged;
            button1.Click += btRssGet_Click;
            btnRemoveRss.Click += btnRemoveRss_Click;

            // WebView2 初期化
            サイト表示.CoreWebView2InitializationCompleted += WebView_Initialized;
            _ = サイト表示.EnsureCoreWebView2Async();
            //恐竜ゲーム
            サイト表示.Source = new Uri("https://dinorunner.com/jp/");
            //パックマン
            //サイト表示.Source = new Uri("https://www.google.com/logos/2010/pacman10-i.html");
        }
        #endregion

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
                // デフォルトリンクを表示
                if (サイト表示.CoreWebView2 != null)
                    //恐竜ゲーム
                    サイト表示.CoreWebView2.Navigate("https://dinorunner.com/jp/");
                //パックマン
                //サイト表示.CoreWebView2.Navigate("https://www.google.com/logos/2010/pacman10-i.html");
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
        #region 登録ボタン　全選択付き
        //private void 登録ボタン_Click(object sender, EventArgs e) {
        //    if (cbSave.SelectedItem is not ListItem sel) {
        //        MessageBox.Show("登録するカテゴリを選択してください。");
        //        return;
        //    }

        //    if (sel.Url == "ALL") {
        //        // 「すべて」が選択された場合
        //        int addedCount = 0;
        //        foreach (var pair in rssSources) {
        //            string url = pair.Value;
        //            string name = pair.Key;
        //            var item = new ListItem(name, url);

        //            if (!favorites.Contains(url)) {
        //                favorites.Add(url);
        //                cbOutput.Items.Add(item);
        //                SaveSearchResult("全URL保存", url);
        //                addedCount++;
        //            }
        //        }

        //        if (addedCount > 0) {
        //            MessageBox.Show($"{addedCount} 件のRSSを登録しました。");
        //        } else {
        //            MessageBox.Show("すべてのRSSはすでに登録済みです。");
        //        }
        //    } else {
        //        // 通常の1カテゴリ登録
        //        if (!favorites.Contains(sel.Url)) {
        //            favorites.Add(sel.Url);
        //            cbOutput.Items.Add(sel);
        //            SaveSearchResult("URL保存", sel.Url);
        //            MessageBox.Show("登録されました");
        //        } else {
        //            MessageBox.Show("既に登録済みです");
        //        }
        //    }
        //}
        #endregion

        #region RSSURL追加
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
        #endregion

        private void btnRemoveRss_Click(object sender, EventArgs e) {
            if (cbOutput.SelectedItem is not ListItem selected) {
                MessageBox.Show("削除するRSSを選択してください。");
                return;
            }
            DialogResult result = MessageBox.Show($"「{selected.Name}」を削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                favorites.Remove(selected.Url);
                favorites.Remove((string)selected.Name);
                cbOutput.Items.Remove(selected);
                SaveSearchResult("RSS削除", selected.Url);
                MessageBox.Show("RSSが削除されました。");

                    };
        }
        

        public void SaveSearchResult(string keyword, string result) {
            File.AppendAllText(historyFilePath, $"{DateTime.Now:u}\t{keyword}\n{result}\n");
        }
    }


}
