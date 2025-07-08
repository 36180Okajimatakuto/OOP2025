namespace CarReportSystem {
    partial class fmVersion {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            かー = new Label();
            btOK = new Button();
            lbVersion = new Label();
            SuspendLayout();
            // 
            // かー
            // 
            かー.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            かー.Location = new Point(30, 59);
            かー.Name = "かー";
            かー.Size = new Size(403, 57);
            かー.TabIndex = 0;
            かー.Text = "試乗レポート管理システム";
            かー.TextAlign = ContentAlignment.TopCenter;
            // 
            // btOK
            // 
            btOK.Location = new Point(435, 264);
            btOK.Name = "btOK";
            btOK.Size = new Size(75, 23);
            btOK.TabIndex = 1;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbVersion.Location = new Point(391, 138);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new Size(119, 40);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Ver0.0.1";
            // 
            // fmVersion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 330);
            Controls.Add(lbVersion);
            Controls.Add(btOK);
            Controls.Add(かー);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fmVersion";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "fmVersion";
            Load += fmVersion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label かー;
        private Button btOK;
        private Label lbVersion;
    }
}