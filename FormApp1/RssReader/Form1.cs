using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        

        cbList.SelectedIndexChanged += cbList_SelectedIndexChanged;
        }


        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string)x.Element("title"),
                            Link = (string)x.Element("link"),
                        }).ToList();


                //リストボックスへタイトルを表示
                cbList.Items.Clear();
                items.ForEach(item => cbList.Items.Add(item.Title));

            }
        }

        private void cbList_SelectedIndexChanged(object sender, EventArgs e) {
            int index = cbList.SelectedIndex;
            if (index >= 0 && index < items.Count) {
                string url = items[index].Link;
                if (!string.IsNullOrEmpty(url)) {
                    wvRssLink.Source = new Uri(url);
                }
            }
        }



        //private void lbTitles_Click(object sender, EventArgs e) {
        //    wvRssLink.Source = new Uri("https://yahoo.co.jp/");

        //}

        #region ChatGPT考案リンク表示
        private void lbTitles_Click(object sender, EventArgs e) {
            int index = cbList.SelectedIndex;
            if (index >= 0 && index < items.Count) {
                string url = items[index].Link;
                if (!string.IsNullOrEmpty(url)) {
                    wvRssLink.Source = new Uri(url);
                }
            }
        }

        #endregion

        private void UpdateNavigationButtons() {
            進むボタン.Enabled = wvRssLink.CanGoForward;
            戻るボタン.Enabled = wvRssLink.CanGoBack;
        }

        private void 進むボタン_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) {
                wvRssLink.GoForward();
            }
            UpdateNavigationButtons();
        }

        private void 戻るボタン_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoBack) {
                wvRssLink.GoBack();
            }
            UpdateNavigationButtons();
        }

        private void お気に入り登録ボタン_Click(object sender, EventArgs e) {
            お気に入り form2 = new お気に入り();
            form2.Show();  // モードレスで表示
                           // form2.ShowDialog();  // モーダルで表示（Form2が閉じるまでForm1操作不可）
        }


    }
}
