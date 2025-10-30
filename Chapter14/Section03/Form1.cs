using System.Diagnostics;
using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
                //↓awaitがあると必要（非同期）
        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoLongTimeWorkAdync(4000);
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }

        private async Task<long> DoLongTimeWorkAdync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                System.Threading.Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
