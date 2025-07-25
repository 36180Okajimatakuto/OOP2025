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
            ((System.ComponentModel.ISupportInitialize)サイト表示).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
            button1.Location = new Point(562, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 40);
            button1.TabIndex = 1;
            button1.Text = "取得";
            button1.UseVisualStyleBackColor = true;
            // 
            // RSS内容一覧
            // 
            RSS内容一覧.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            RSS内容一覧.FormattingEnabled = true;
            RSS内容一覧.ItemHeight = 15;
            RSS内容一覧.Location = new Point(12, 127);
            RSS内容一覧.Name = "RSS内容一覧";
            RSS内容一覧.Size = new Size(776, 154);
            RSS内容一覧.TabIndex = 5;
            // 
            // cbOutput
            // 
            cbOutput.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbOutput.FormattingEnabled = true;
            cbOutput.Location = new Point(111, 12);
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
            サイト表示.Location = new Point(12, 295);
            サイト表示.Name = "サイト表示";
            サイト表示.Size = new Size(776, 274);
            サイト表示.TabIndex = 9;
            サイト表示.ZoomFactor = 1D;
            // 
            // btnAddNewRss
            // 
            btnAddNewRss.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            btnAddNewRss.Location = new Point(388, 81);
            btnAddNewRss.Name = "btnAddNewRss";
            btnAddNewRss.Size = new Size(104, 35);
            btnAddNewRss.TabIndex = 10;
            btnAddNewRss.Text = "新規登録";
            btnAddNewRss.UseVisualStyleBackColor = true;
            // 
            // txtNewUrl
            // 
            txtNewUrl.Location = new Point(111, 98);
            txtNewUrl.Name = "txtNewUrl";
            txtNewUrl.Size = new Size(243, 23);
            txtNewUrl.TabIndex = 11;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(111, 63);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(243, 23);
            txtNewName.TabIndex = 12;
            // 
            // btnRemoveRss
            // 
            btnRemoveRss.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnRemoveRss.Location = new Point(12, 12);
            btnRemoveRss.Name = "btnRemoveRss";
            btnRemoveRss.Size = new Size(75, 40);
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
            label1.Location = new Point(22, 71);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 15;
            label1.Text = "カテゴリ名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 101);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 16;
            label2.Text = "URL";
            // 
            // お気に入り
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 581);
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
    }
}