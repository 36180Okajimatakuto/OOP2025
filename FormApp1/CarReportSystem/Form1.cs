using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecord.DataSource = listCarReports;
        }

        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRecordAdd_Click(object sender, EventArgs e) {

            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            var carReport = new CarReport {

                Maker = getRadioButtonMaker(),
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Date = dtpDate.Value
            };
            listCarReports.Add(carReport);
            InputItemsAllClear();


        }



        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            //すでに登録済みか確認
            if (!cbAuthor.Items.Contains(author)) {

                cbAuthor.Items.Add(author);
            }
        }
        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);

            }
        }

        #region//入力項目をすべてクリア
        public void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }
        #endregion

        #region 車のメーカー
        private MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbImport.Checked)
                return MakerGroup.輸入車;

            return MakerGroup.その他;
        }
        #endregion

        #region　一覧を表示
        public void dgvRecord_Click(object sender, EventArgs e) {

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
        }
        #endregion

        #region 車の選択欄作成
        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;

            }

        }
        #endregion

        //新規追加のイベントハンドラ
        private void btNewRcord_Click(object sender, EventArgs e) {
            InputItemsAllClear();


        }

        #region 削除ボタンの行削除
        //削除ボタンのイベントハンドラ
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //カーレポート管理用リストから、
            //該当するデータを削除する
            //エラー止めるIF文
            if (dgvRecord.CurrentRow != null) {
                // 選択されている行のインデックスを取得
                int selectedIndex = dgvRecord.CurrentRow.Index;

                if (selectedIndex >= 0 && selectedIndex < listCarReports.Count) {
                    // リストから削除
                    listCarReports.RemoveAt(selectedIndex);

                    // DataGridView も再表示（再バインドなど）
                    dgvRecord.DataSource = null;
                    dgvRecord.DataSource = listCarReports;
                }
            }
        }
        #endregion

        #region 指定セルへの再度書き込み
        //修正ボタンのイベントハンドラ
        private void btRecordModify_Click(object sender, EventArgs e) {

            if (dgvRecord.Rows.Count == 0) return;

            //入力しやすくする用
            int selectedIndex = dgvRecord.CurrentRow.Index;

            listCarReports[selectedIndex].Author = cbAuthor.Text;
            listCarReports[selectedIndex].Date = dtpDate.Value;
            listCarReports[selectedIndex].Maker = getRadioButtonMaker();
            listCarReports[selectedIndex].CarName = cbCarName.Text;
            listCarReports[selectedIndex].Report = tbReport.Text;
            listCarReports[selectedIndex].Picture = pbPicture.Image;


        }
        #endregion

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();

            //交互に色を設定（データグリッドビュー）
            dgvRecord.DefaultCellStyle.BackColor = Color.LightBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //このアプリについてを選択したときのイベントハンドラ
        private void bsmi_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.Show();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
            }

        }

        //ファイルセーブ処理
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);

                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                }


            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }
    }
}
