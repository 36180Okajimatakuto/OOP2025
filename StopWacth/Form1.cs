using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StopWacth {
    public partial class Form1 : Form {
        Stopwatch sw = new Stopwatch();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            lbTimeDisp.Text = "00.00.00";
            tmDispTimer.Interval = 1000;//10msごとにタイマーイベントを発生させる

        }
        //スタートボタンのイベントハンドラ
        private void btStart_Click(object sender, EventArgs e) {
            sw.Start();
            tmDispTimer.Start();    //画面更新用のタイマーをスタート
        }

        private void tmDispTimer_Tick(object sender, EventArgs e) {
            lbTimeDisp.Text = sw.Elapsed.ToString(@"hh\:mm\ss\.ff");
        }
    }
}
