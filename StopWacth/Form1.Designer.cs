namespace StopWacth {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lbTimeDisp = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btRiset = new System.Windows.Forms.Button();
            this.tmDispTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbTimeDisp
            // 
            this.lbTimeDisp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbTimeDisp.Font = new System.Drawing.Font("MS UI Gothic", 25F);
            this.lbTimeDisp.Location = new System.Drawing.Point(28, 9);
            this.lbTimeDisp.Name = "lbTimeDisp";
            this.lbTimeDisp.Size = new System.Drawing.Size(280, 99);
            this.lbTimeDisp.TabIndex = 0;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 129);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(115, 59);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "スタート";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(12, 226);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(115, 59);
            this.btStop.TabIndex = 1;
            this.btStop.Text = "ストップ";
            this.btStop.UseVisualStyleBackColor = true;
            // 
            // btRiset
            // 
            this.btRiset.Location = new System.Drawing.Point(193, 129);
            this.btRiset.Name = "btRiset";
            this.btRiset.Size = new System.Drawing.Size(115, 59);
            this.btRiset.TabIndex = 1;
            this.btRiset.Text = "リセット";
            this.btRiset.UseVisualStyleBackColor = true;
            // 
            // tmDispTimer
            // 
            this.tmDispTimer.Tick += new System.EventHandler(this.tmDispTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(353, 297);
            this.Controls.Add(this.btRiset);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lbTimeDisp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTimeDisp;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btRiset;
        private System.Windows.Forms.Timer tmDispTimer;
    }
}

