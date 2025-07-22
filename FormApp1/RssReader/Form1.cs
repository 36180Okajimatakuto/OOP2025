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

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string)x.Element("title"),
                            Link = (string)x.Element("link"),
                        }).ToList();


                //���X�g�{�b�N�X�փ^�C�g����\��
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

        #region ChatGPT�l�ă����N�\��
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
            �i�ރ{�^��.Enabled = wvRssLink.CanGoForward;
            �߂�{�^��.Enabled = wvRssLink.CanGoBack;
        }

        private void �i�ރ{�^��_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) {
                wvRssLink.GoForward();
            }
            UpdateNavigationButtons();
        }

        private void �߂�{�^��_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoBack) {
                wvRssLink.GoBack();
            }
            UpdateNavigationButtons();
        }

        private void ���C�ɓ���o�^�{�^��_Click(object sender, EventArgs e) {
            ���C�ɓ��� form2 = new ���C�ɓ���();
            form2.Show();  // ���[�h���X�ŕ\��
                           // form2.ShowDialog();  // ���[�_���ŕ\���iForm2������܂�Form1����s�j
        }


    }
}
