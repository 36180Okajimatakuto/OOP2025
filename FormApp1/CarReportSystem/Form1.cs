using System.ComponentModel;
using System.Security.Cryptography;
using static CarReportSystem.CarReport;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {
        //�J�[���|�[�g�Ǘ��p���X�g
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

            var carReport = new CarReport {
                
                Maker = GetRadioButtonMaker(),
                Author = cbAuthor.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Date = dtpDate.Value
            };
            listCarReports.Add(carReport);
            InputItemsAllClear();


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

        //���͍��ڂ����ׂăN���A
        public void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;
        }
        private MakerGroup GetRadioButtonMaker() {
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

        public void dgvRecord_Click(object sender, EventArgs e) {


            dtpDate.Value = (DateTime)dgvRecord.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecord.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((MakerGroup)dgvRecord.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecord.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecord.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecord.CurrentRow.Cells["Picture"].Value;
        }
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


        //�V�K�ǉ��̃C�x���g�n���h��
        private void btNewRcord_Click(object sender, EventArgs e) {
            InputItemsAllClear();


        }
        //�폜�{�^���̃C�x���g�n���h��
        private void btRecordDelete_Click(object sender, EventArgs e) {
            //�J�[���|�[�g�Ǘ��p���X�g����A
            //�Y������f�[�^���폜����
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
        //�C���{�^���̃C�x���g�n���h��
        private void btRecordModify_Click(object sender, EventArgs e) {
            int selectedIndex = dgvRecord.CurrentRow.Index;
            
            listCarReports[selectedIndex].Author  = cbAuthor.Text;
            listCarReports[selectedIndex].Date    = dtpDate.Value;
            listCarReports[selectedIndex].Maker   = GetRadioButtonMaker();
            listCarReports[selectedIndex].CarName = cbCarName.Text;
            listCarReports[selectedIndex].Report  = tbReport.Text;
            listCarReports[selectedIndex].Picture = pbPicture.Image;


        }

        private void Form1_Load(object sender, EventArgs e) {
            InputItemsAllClear();
        }
    }
}
