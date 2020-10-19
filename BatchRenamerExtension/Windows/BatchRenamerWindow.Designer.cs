namespace BatchRenamerExtension
{
    partial class BatchRenamerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchRenamerWindow));
            this.txbFiles = new FastColoredTextBoxNS.FastColoredTextBox();
            this.chkCheckPaths = new System.Windows.Forms.CheckBox();
            this.chkShowpathDest = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRegex = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txbFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // txbFiles
            // 
            this.txbFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFiles.AutoCompleteBracketsList = new char[] {
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
            this.txbFiles.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txbFiles.BackBrush = null;
            this.txbFiles.CharHeight = 14;
            this.txbFiles.CharWidth = 8;
            this.txbFiles.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFiles.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txbFiles.IsReplaceMode = false;
            this.txbFiles.Location = new System.Drawing.Point(-2, 0);
            this.txbFiles.Name = "txbFiles";
            this.txbFiles.Paddings = new System.Windows.Forms.Padding(0);
            this.txbFiles.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txbFiles.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txbFiles.ServiceColors")));
            this.txbFiles.Size = new System.Drawing.Size(595, 408);
            this.txbFiles.TabIndex = 0;
            this.txbFiles.Zoom = 100;
            // 
            // chkCheckPaths
            // 
            this.chkCheckPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCheckPaths.AutoSize = true;
            this.chkCheckPaths.Checked = true;
            this.chkCheckPaths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckPaths.Location = new System.Drawing.Point(604, 12);
            this.chkCheckPaths.Name = "chkCheckPaths";
            this.chkCheckPaths.Size = new System.Drawing.Size(116, 17);
            this.chkCheckPaths.TabIndex = 1;
            this.chkCheckPaths.Text = "Check path validity";
            this.chkCheckPaths.UseVisualStyleBackColor = true;
            this.chkCheckPaths.CheckedChanged += new System.EventHandler(this.chkCheckPaths_CheckedChanged);
            // 
            // chkShowpathDest
            // 
            this.chkShowpathDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowpathDest.AutoSize = true;
            this.chkShowpathDest.Location = new System.Drawing.Point(604, 35);
            this.chkShowpathDest.Name = "chkShowpathDest";
            this.chkShowpathDest.Size = new System.Drawing.Size(123, 17);
            this.chkShowpathDest.TabIndex = 2;
            this.chkShowpathDest.Text = "Show complete path";
            this.chkShowpathDest.UseVisualStyleBackColor = true;
            this.chkShowpathDest.CheckedChanged += new System.EventHandler(this.chkShowpathDest_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(604, 58);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRegex
            // 
            this.btnRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegex.Location = new System.Drawing.Point(604, 87);
            this.btnRegex.Name = "btnRegex";
            this.btnRegex.Size = new System.Drawing.Size(116, 23);
            this.btnRegex.TabIndex = 4;
            this.btnRegex.Text = "Regex...";
            this.btnRegex.UseVisualStyleBackColor = true;
            this.btnRegex.Click += new System.EventHandler(this.btnRegex_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(604, 348);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(604, 377);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(116, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // BatchRenamerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 407);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegex);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkShowpathDest);
            this.Controls.Add(this.chkCheckPaths);
            this.Controls.Add(this.txbFiles);
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "BatchRenamerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bath Renamer";
            ((System.ComponentModel.ISupportInitialize)(this.txbFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txbFiles;
        private System.Windows.Forms.CheckBox chkCheckPaths;
        private System.Windows.Forms.CheckBox chkShowpathDest;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRegex;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}