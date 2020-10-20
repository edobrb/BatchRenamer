namespace BatchRenamerExtension
{
    partial class HelpWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpWindow));
            this.txbEg = new FastColoredTextBoxNS.FastColoredTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txbEg)).BeginInit();
            this.SuspendLayout();
            // 
            // txbEg
            // 
            this.txbEg.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txbEg.AutoScrollMinSize = new System.Drawing.Size(298, 56);
            this.txbEg.BackBrush = null;
            this.txbEg.CharHeight = 14;
            this.txbEg.CharWidth = 8;
            this.txbEg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbEg.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txbEg.IsReplaceMode = false;
            this.txbEg.Location = new System.Drawing.Point(12, 12);
            this.txbEg.Name = "txbEg";
            this.txbEg.Paddings = new System.Windows.Forms.Padding(0);
            this.txbEg.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txbEg.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txbEg.ServiceColors")));
            this.txbEg.ShowLineNumbers = false;
            this.txbEg.Size = new System.Drawing.Size(513, 63);
            this.txbEg.TabIndex = 0;
            this.txbEg.Text = "This path is invalid\r\nThis file or directory already exists\r\nThis file is used by" +
    " another program\r\nThis file or directory can be renamed";
            this.txbEg.Zoom = 100;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 108);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(513, 343);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // HelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 454);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txbEg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpWindow";
            this.Text = "Hep & License";
            ((System.ComponentModel.ISupportInitialize)(this.txbEg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txbEg;
        private System.Windows.Forms.TextBox textBox1;
    }
}