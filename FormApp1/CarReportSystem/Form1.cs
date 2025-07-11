using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //設定クラスのインスタンスを生成
        Settings settings = Settings.getInstance();

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
            setCbAuthor(cbAuthor.Text); //コンボボックスへ登録
            setCbCarName(cbCarName.Text);
            InputItemsAllClear();


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

            //設定ファイルを読み込み背景色をせってチスル（逆シリアル化）
            //P286意向を参考にする（ファイル名：setting.xml）
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var set = serializer.Deserialize(reader) as Settings;//参照型の場合は後ろにas
                        BackColor = Color.FromArgb(set?.MainFormBackColor ?? 0);//？はなくてもいい気になるなら
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "設定ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);
                }
            } else {
                tsslbMessage.Text = "設定ファイルがありません";
            }
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
                //設定ファイルへ保存
                settings.MainFormBackColor = cdColor.Color.ToArgb();//背景色を設定インスタンスへ設定
            }

        }

        #region ファイルを開くための処理
        //ファイルオープン処理
        private void reportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011

                    using (FileStream fs = File.Open(
                        ofdPicFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        //コンボボックスに登録
                        foreach (var report in listCarReports) {//もともと追加ボタンを押すと呼び出せるものを
                            setCbAuthor(report.Author);         //リストから呼び出すようにする
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "ファイル形式が違います";
                }

            }
        }
        #endregion

        #region ファイルを保存するための処理
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
                catch (Exception ex) {
                    tsslbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);
                }


            }

        }
        #endregion

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //フォームが閉じたら呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理（シリアル化）
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {//ここを抜けると解放されるようにするため
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "ファイル書き出しエラー";
                MessageBox.Show(ex.Message);

            }


        }

    }
}