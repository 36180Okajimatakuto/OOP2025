using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {
        private List<ItemData> items;

        public Form1() {
            InitializeComponent();

            cbList.SelectedIndexChanged += cbList_SelectedIndexChanged;
            btnLoadImage.Click += btnLoadImage_Click;
            this.Load += Form1_Load;
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {
                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string)x.Element("title"),
                            Link = (string)x.Element("link"),
                        }).ToList();

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
            form2.Show();
        }

        #region �I��
        // --- ��������w�i�摜�I���E�ݒ菈�� ---

        private void btnLoadImage_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "�w�i�ɐݒ肷��摜�t�@�C����I�����Ă�������";
                ofd.Filter = "�摜�t�@�C��|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    string sourcePath = ofd.FileName;

                    string imagesFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                    if (!System.IO.Directory.Exists(imagesFolder)) {
                        System.IO.Directory.CreateDirectory(imagesFolder);
                    }

                    string destPath = System.IO.Path.Combine(imagesFolder, System.IO.Path.GetFileName(sourcePath));

                    try {
                        System.IO.File.Copy(sourcePath, destPath, true);

                        if (this.BackgroundImage != null) {
                            this.BackgroundImage.Dispose();
                        }

                        this.BackgroundImage = Image.FromFile(destPath);
                        this.BackgroundImageLayout = ImageLayout.Stretch;

                        // �摜�t�@�C�������e�L�X�g�t�@�C���ɕۑ�
                        string configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
                        System.IO.File.WriteAllText(configPath, System.IO.Path.GetFileName(destPath));

                        MessageBox.Show("�w�i�摜��ݒ肵�܂����B\n�t�@�C��: " + destPath);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("�摜�̃R�s�[�܂��͓ǂݍ��݂Ɏ��s���܂���:\n" + ex.Message);
                    }
                }
            }
            #endregion
        }
        #region �w�i�摜�̏o��
        private void Form1_Load(object sender, EventArgs e) {
            string configPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            if (System.IO.File.Exists(configPath)) {
                string fileName = System.IO.File.ReadAllText(configPath).Trim();
                if (!string.IsNullOrEmpty(fileName)) {
                    string imagesFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                    string imagePath = System.IO.Path.Combine(imagesFolder, fileName);
                    if (System.IO.File.Exists(imagePath)) {
                        try {
                            if (this.BackgroundImage != null) {
                                this.BackgroundImage.Dispose();
                            }
                            this.BackgroundImage = Image.FromFile(imagePath);
                            this.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        catch (Exception ex) {
                            MessageBox.Show("�w�i�摜�̓ǂݍ��݂Ɏ��s���܂���:\n" + ex.Message);
                        }
                    }
                    #endregion
                }
            }
        }
    }
}