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
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            進むボタン = new Button();
            戻るボタン = new Button();
            お気に入り登録ボタン = new Button();
            cbUrl = new ComboBox();
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
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(12, 75);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(610, 109);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(12, 190);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(610, 465);
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
            // cbUrl
            // 
            cbUrl.FormattingEnabled = true;
            cbUrl.Location = new Point(99, 30);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(417, 23);
            cbUrl.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 667);
            Controls.Add(cbUrl);
            Controls.Add(お気に入り登録ボタン);
            Controls.Add(戻るボタン);
            Controls.Add(進むボタン);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "RSSリーダー";
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button 進むボタン;
        private Button 戻るボタン;
        private Button お気に入り登録ボタン;
        private ComboBox cbUrl;
    }
}
