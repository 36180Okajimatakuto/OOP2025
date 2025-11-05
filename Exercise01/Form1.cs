using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "テキストファイル|*.txt;*.log;*.csv|すべてのファイル|*.*";
                ofd.Title = "ファイルを選択してください";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    var Text = await TextReaderSample.ReadTextAsync(ofd.FileName);
                }
            }
        }

        static class TextReaderSample {
            public static async Task<string> ReadTextAsync(string filePath) {
                var sb = new StringBuilder();

                using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
                    while (!sr.EndOfStream) {
                        var line = await sr.ReadLineAsync();
                        sb.AppendLine(line);

                        await Task.Delay(10); // わざと遅延（非同期動作を見やすくするため）
                    }
                }

                return sb.ToString();
            }
        }
    }
}