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
        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X�𐶐�
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

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbAuthor(string author) {
            //���łɓo�^�ς݂��m�F
            if (!cbAuthor.Items.Contains(author)) {

                cbAuthor.Items.Add(author);
            }
        }
        //�Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);

            }
        }


        private void btRecordAdd_Click(object sender, EventArgs e) {

            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
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
            setCbAuthor(cbAuthor.Text); //�R���{�{�b�N�X�֓o�^
            setCbCarName(cbCarName.Text);
            InputItemsAllClear();


        }


        #region//���͍��ڂ����ׂăN���A
        public void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }
        #endregion

        #region �Ԃ̃��[�J�[
        private MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.�g���^;
            if (rbNissan.Checked)
                return MakerGroup.���Y;
            if (rbSubaru.Checked)
                return MakerGroup.�X�o��;
            if (rbHonda.Checked)
                return MakerGroup.�z���_;
            if (rbImport.Checked)
                return MakerGroup.�A����;

            return MakerGroup.���̑�;
        }
        #endregion

        #region�@�ꗗ��\��
        public void dgvRecord_Click(object sender, EventArgs e) {

            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
        }
        #endregion

        #region �Ԃ̑I�𗓍쐬
        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;

            }

        }
        #endregion

        //�V�K�ǉ��̃C�x���g�n���h��
        private void btNewRcord_Click(object sender, EventArgs e) {
            InputItemsAllClear();


        }

        #region �폜�{�^���̍s�폜
        //�폜�{�^���̃C�x���g�n���h��
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //�J�[���|�[�g�Ǘ��p���X�g����A
            //�Y������f�[�^���폜����
            //�G���[�~�߂�IF��
            if (dgvRecord.CurrentRow != null) {
                // �I������Ă���s�̃C���f�b�N�X���擾
                int selectedIndex = dgvRecord.CurrentRow.Index;

                if (selectedIndex >= 0 && selectedIndex < listCarReports.Count) {
                    // ���X�g����폜
                    listCarReports.RemoveAt(selectedIndex);

                    // DataGridView ���ĕ\���i�ăo�C���h�Ȃǁj
                    dgvRecord.DataSource = null;
                    dgvRecord.DataSource = listCarReports;
                }
            }
        }
        #endregion

        #region �w��Z���ւ̍ēx��������
        //�C���{�^���̃C�x���g�n���h��
        private void btRecordModify_Click(object sender, EventArgs e) {

            if (dgvRecord.Rows.Count == 0) return;

            //���͂��₷������p
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

            //���݂ɐF��ݒ�i�f�[�^�O���b�h�r���[�j
            dgvRecord.DefaultCellStyle.BackColor = Color.LightBlue;
            dgvRecord.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            //�ݒ�t�@�C����ǂݍ��ݔw�i�F�������ă`�X���i�t�V���A�����j
            //P286�ӌ����Q�l�ɂ���i�t�@�C�����Fsetting.xml�j
            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var set = serializer.Deserialize(reader) as Settings;//�Q�ƌ^�̏ꍇ�͌���as
                        BackColor = Color.FromArgb(set?.MainFormBackColor ?? 0);//�H�͂Ȃ��Ă������C�ɂȂ�Ȃ�
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�ݒ�t�@�C���ǂݍ��݃G���[";
                    MessageBox.Show(ex.Message);
                }
            } else {
                tsslbMessage.Text = "�ݒ�t�@�C��������܂���";
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        //���̃A�v���ɂ��Ă�I�������Ƃ��̃C�x���g�n���h��
        private void bsmi_Click(object sender, EventArgs e) {
            fmVersion fmv = new fmVersion();
            fmv.Show();
        }

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cdColor.Color.ToArgb();//�w�i�F��ݒ�C���X�^���X�֐ݒ�
            }

        }

        #region �t�@�C�����J�����߂̏���
        //�t�@�C���I�[�v������
        private void reportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011

                    using (FileStream fs = File.Open(
                        ofdPicFileOpen.FileName, FileMode.Open, FileAccess.Read)) {

                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecord.DataSource = listCarReports;

                        //�R���{�{�b�N�X�ɓo�^
                        foreach (var report in listCarReports) {//���Ƃ��ƒǉ��{�^���������ƌĂяo������̂�
                            setCbAuthor(report.Author);         //���X�g����Ăяo���悤�ɂ���
                            setCbCarName(report.CarName);
                        }
                    }
                }
                catch (Exception) {
                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }

            }
        }
        #endregion

        #region �t�@�C����ۑ����邽�߂̏���
        //�t�@�C���Z�[�u����
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A��
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning disable SYSLIB0011
                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);

                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message);
                }


            }

        }
        #endregion

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //�t�H�[����������Ă΂��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //�ݒ�t�@�C���֐F����ۑ����鏈���i�V���A�����j
            try {
                using (var writer = XmlWriter.Create("setting.xml")) {//�����𔲂���Ɖ�������悤�ɂ��邽��
                    var serializer = new XmlSerializer(settings.GetType());
                    serializer.Serialize(writer, settings);
                }
            }
            catch (Exception ex) {
                tsslbMessage.Text = "�t�@�C�������o���G���[";
                MessageBox.Show(ex.Message);

            }


        }

    }
}