using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(cbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                //リストボックスへタイトルを表示
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title ?? "データなし"));

            }

        }
        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri("https://yahoo.co.jp/");

        }

        private void 進むボタン_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) {
                wvRssLink.GoForward();
            }
        }

        private void 戻るボタン_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoBack) {
                wvRssLink.GoBack();
            }
        }

        private void お気に入り登録ボタン_Click(object sender, EventArgs e) {
            お気に入り form2 = new お気に入り();
            form2.Show();  // モードレスで表示
                           // form2.ShowDialog();  // モーダルで表示（Form2が閉じるまでForm1操作不可）
        }
    }
}
