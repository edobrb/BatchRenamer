namespace BatchRenamerExtension
{
    partial class RegexWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkShowMatches = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbFrom = new System.Windows.Forms.TextBox();
            this.txbTo = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkShowMatches
            // 
            this.chkShowMatches.AutoSize = true;
            this.chkShowMatches.Checked = true;
            this.chkShowMatches.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMatches.Location = new System.Drawing.Point(15, 64);
            this.chkShowMatches.Name = "chkShowMatches";
            this.chkShowMatches.Size = new System.Drawing.Size(96, 17);
            this.chkShowMatches.TabIndex = 0;
            this.chkShowMatches.Text = "Show matches";
            this.chkShowMatches.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To:";
            // 
            // txbFrom
            // 
            this.txbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFrom.Location = new System.Drawing.Point(51, 6);
            this.txbFrom.Name = "txbFrom";
            this.txbFrom.Size = new System.Drawing.Size(388, 20);
            this.txbFrom.TabIndex = 3;
            // 
            // txbTo
            // 
            this.txbTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTo.Location = new System.Drawing.Point(51, 32);
            this.txbTo.Name = "txbTo";
            this.txbTo.Size = new System.Drawing.Size(388, 20);
            this.txbTo.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(364, 58);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // RegexWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 88);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txbTo);
            this.Controls.Add(this.txbFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkShowMatches);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 127);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 127);
            this.Name = "RegexWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apply regex to paths";
            this.Load += new System.EventHandler(this.RegexWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox chkShowMatches;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txbFrom;
        public System.Windows.Forms.TextBox txbTo;
        public System.Windows.Forms.Button btnApply;
    }
}