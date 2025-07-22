namespace RssReader {
    partial class お気に入り {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            button1 = new Button();
            button2 = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            cbOutput = new ComboBox();
            cbSave = new ComboBox();
            rechtextbox = new ListBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(540, 13);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "取得";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(315, 73);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "登録";
            button2.UseVisualStyleBackColor = true;
            button2.Click += 登録ボタン_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(396, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(371, 79);
            listBox1.TabIndex = 4;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(12, 127);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(776, 154);
            listBox2.TabIndex = 5;
            // 
            // cbOutput
            // 
            cbOutput.FormattingEnabled = true;
            cbOutput.Location = new Point(111, 12);
            cbOutput.Name = "cbOutput";
            cbOutput.Size = new Size(423, 23);
            cbOutput.TabIndex = 6;
            // 
            // cbSave
            // 
            cbSave.FormattingEnabled = true;
            cbSave.Location = new Point(111, 73);
            cbSave.Name = "cbSave";
            cbSave.Size = new Size(198, 23);
            cbSave.TabIndex = 7;
            // 
            // rechtextbox
            // 
            rechtextbox.FormattingEnabled = true;
            rechtextbox.ItemHeight = 15;
            rechtextbox.Location = new Point(12, 287);
            rechtextbox.MultiColumn = true;
            rechtextbox.Name = "rechtextbox";
            rechtextbox.Size = new Size(776, 274);
            rechtextbox.Sorted = true;
            rechtextbox.TabIndex = 8;
            rechtextbox.Visible = false;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(12, 287);
            webView21.Name = "webView21";
            webView21.Size = new Size(776, 274);
            webView21.TabIndex = 9;
            webView21.ZoomFactor = 1D;
            // 
            // お気に入り
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 581);
            Controls.Add(webView21);
            Controls.Add(rechtextbox);
            Controls.Add(cbSave);
            Controls.Add(cbOutput);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "お気に入り";
            Text = "URL登録";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ListBox listBox1;
        private ListBox listBox2;
        private ComboBox cbOutput;
        private ComboBox cbSave;
        private ListBox rechtextbox;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}