namespace RssReader {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btRssGet = new Button();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            進むボタン = new Button();
            戻るボタン = new Button();
            お気に入り登録ボタン = new Button();
            tbUrl = new TextBox();
            cbList = new ComboBox();
            btnLoadImage = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(522, 21);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(94, 33);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 106);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(610, 549);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            // 
            // 進むボタン
            // 
            進むボタン.Location = new Point(54, 25);
            進むボタン.Name = "進むボタン";
            進むボタン.Size = new Size(39, 31);
            進むボタン.TabIndex = 4;
            進むボタン.Text = "進む";
            進むボタン.UseVisualStyleBackColor = true;
            進むボタン.Click += 進むボタン_Click;
            // 
            // 戻るボタン
            // 
            戻るボタン.Location = new Point(12, 25);
            戻るボタン.Name = "戻るボタン";
            戻るボタン.Size = new Size(42, 31);
            戻るボタン.TabIndex = 5;
            戻るボタン.Text = "戻る";
            戻るボタン.UseVisualStyleBackColor = true;
            戻るボタン.Click += 戻るボタン_Click;
            // 
            // お気に入り登録ボタン
            // 
            お気に入り登録ボタン.Location = new Point(-1, 2);
            お気に入り登録ボタン.Name = "お気に入り登録ボタン";
            お気に入り登録ボタン.Size = new Size(94, 23);
            お気に入り登録ボタン.TabIndex = 6;
            お気に入り登録ボタン.Text = "お気に入り登録";
            お気に入り登録ボタン.UseVisualStyleBackColor = true;
            お気に入り登録ボタン.Click += お気に入り登録ボタン_Click;
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(99, 25);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(417, 23);
            tbUrl.TabIndex = 7;
            // 
            // cbList
            // 
            cbList.FormattingEnabled = true;
            cbList.Location = new Point(12, 62);
            cbList.Name = "cbList";
            cbList.Size = new Size(610, 23);
            cbList.TabIndex = 8;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(99, 2);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(75, 23);
            btnLoadImage.TabIndex = 9;
            btnLoadImage.Text = "背景";
            btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 667);
            Controls.Add(btnLoadImage);
            Controls.Add(cbList);
            Controls.Add(tbUrl);
            Controls.Add(お気に入り登録ボタン);
            Controls.Add(戻るボタン);
            Controls.Add(進むボタン);
            Controls.Add(wvRssLink);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "RSSリーダー";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btRssGet;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button 進むボタン;
        private Button 戻るボタン;
        private Button お気に入り登録ボタン;
        private TextBox tbUrl;
        private ComboBox cbList;
        private Button btnLoadImage;
    }
}
