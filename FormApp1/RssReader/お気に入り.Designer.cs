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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            RSS内容一覧 = new ListBox();
            cbOutput = new ComboBox();
            サイト表示 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btnAddNewRss = new Button();
            txtNewUrl = new TextBox();
            txtNewName = new TextBox();
            btnRemoveRss = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            label2 = new Label();
            btnLoadImage = new Button();
            戻るボタン = new Button();
            進むボタン = new Button();
            ((System.ComponentModel.ISupportInitialize)サイト表示).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
            button1.Location = new Point(623, 5);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 48);
            button1.TabIndex = 1;
            button1.Text = "取得";
            button1.UseVisualStyleBackColor = true;
            // 
            // RSS内容一覧
            // 
            RSS内容一覧.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RSS内容一覧.FormattingEnabled = true;
            RSS内容一覧.ItemHeight = 18;
            RSS内容一覧.Location = new Point(12, 152);
            RSS内容一覧.Margin = new Padding(3, 4, 3, 4);
            RSS内容一覧.Name = "RSS内容一覧";
            RSS内容一覧.Size = new Size(776, 184);
            RSS内容一覧.TabIndex = 5;
            // 
            // cbOutput
            // 
            cbOutput.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbOutput.FormattingEnabled = true;
            cbOutput.Location = new Point(194, 13);
            cbOutput.Margin = new Padding(3, 4, 3, 4);
            cbOutput.Name = "cbOutput";
            cbOutput.Size = new Size(423, 40);
            cbOutput.TabIndex = 6;
            // 
            // サイト表示
            // 
            サイト表示.AllowExternalDrop = true;
            サイト表示.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            サイト表示.CreationProperties = null;
            サイト表示.DefaultBackgroundColor = Color.White;
            サイト表示.Location = new Point(12, 354);
            サイト表示.Margin = new Padding(3, 4, 3, 4);
            サイト表示.Name = "サイト表示";
            サイト表示.Size = new Size(776, 329);
            サイト表示.TabIndex = 9;
            サイト表示.ZoomFactor = 1D;
            // 
            // btnAddNewRss
            // 
            btnAddNewRss.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnAddNewRss.Location = new Point(413, 81);
            btnAddNewRss.Margin = new Padding(3, 4, 3, 4);
            btnAddNewRss.Name = "btnAddNewRss";
            btnAddNewRss.Size = new Size(104, 55);
            btnAddNewRss.TabIndex = 10;
            btnAddNewRss.Text = "新規登録";
            btnAddNewRss.UseVisualStyleBackColor = true;
            // 
            // txtNewUrl
            // 
            txtNewUrl.Location = new Point(179, 111);
            txtNewUrl.Margin = new Padding(3, 4, 3, 4);
            txtNewUrl.Name = "txtNewUrl";
            txtNewUrl.Size = new Size(228, 25);
            txtNewUrl.TabIndex = 11;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(179, 78);
            txtNewName.Margin = new Padding(3, 4, 3, 4);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(228, 25);
            txtNewName.TabIndex = 12;
            // 
            // btnRemoveRss
            // 
            btnRemoveRss.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnRemoveRss.Location = new Point(109, 11);
            btnRemoveRss.Margin = new Padding(3, 4, 3, 4);
            btnRemoveRss.Name = "btnRemoveRss";
            btnRemoveRss.Size = new Size(75, 48);
            btnRemoveRss.TabIndex = 13;
            btnRemoveRss.Text = "削除";
            btnRemoveRss.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 81);
            label1.Name = "label1";
            label1.Size = new Size(68, 18);
            label1.TabIndex = 15;
            label1.Text = "カテゴリ名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 118);
            label2.Name = "label2";
            label2.Size = new Size(32, 18);
            label2.TabIndex = 16;
            label2.Text = "URL";
            // 
            // btnLoadImage
            // 
            btnLoadImage.Font = new Font("UD デジタル 教科書体 NP", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnLoadImage.Location = new Point(741, 3);
            btnLoadImage.Margin = new Padding(3, 4, 3, 4);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(58, 34);
            btnLoadImage.TabIndex = 17;
            btnLoadImage.Text = "背景";
            btnLoadImage.UseVisualStyleBackColor = true;
            // 
            // 戻るボタン
            // 
            戻るボタン.Location = new Point(-1, 24);
            戻るボタン.Name = "戻るボタン";
            戻るボタン.Size = new Size(52, 23);
            戻るボタン.TabIndex = 18;
            戻るボタン.Text = "戻る";
            戻るボタン.UseVisualStyleBackColor = true;
            戻るボタン.Click += 戻るボタン_Click;
            // 
            // 進むボタン
            // 
            進むボタン.AllowDrop = true;
            進むボタン.Location = new Point(57, 24);
            進むボタン.Name = "進むボタン";
            進むボタン.Size = new Size(46, 23);
            進むボタン.TabIndex = 19;
            進むボタン.Text = "進む";
            進むボタン.UseVisualStyleBackColor = true;
            進むボタン.Click += 進むボタン_Click;
            // 
            // お気に入り
            // 
            AutoScaleDimensions = new SizeF(7F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 697);
            Controls.Add(進むボタン);
            Controls.Add(戻るボタン);
            Controls.Add(btnLoadImage);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRemoveRss);
            Controls.Add(txtNewName);
            Controls.Add(txtNewUrl);
            Controls.Add(btnAddNewRss);
            Controls.Add(サイト表示);
            Controls.Add(cbOutput);
            Controls.Add(RSS内容一覧);
            Controls.Add(button1);
            Font = new Font("メイリオ", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Margin = new Padding(3, 4, 3, 4);
            Name = "お気に入り";
            Text = "URL登録";
            ((System.ComponentModel.ISupportInitialize)サイト表示).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox RSS内容一覧;
        private ComboBox cbOutput;
        private Microsoft.Web.WebView2.WinForms.WebView2 サイト表示;
        private Button btnAddNewRss;
        private TextBox txtNewUrl;
        private TextBox txtNewName;
        private Button btnRemoveRss;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private Button btnLoadImage;
        private Button 戻るボタン;
        private Button 進むボタン;
    }
}