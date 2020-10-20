namespace BatchRenamerExtension
{
    partial class PathContainerView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathContainerView));
            this.txbFiles = new FastColoredTextBoxNS.FastColoredTextBox();
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
            this.txbFiles.Location = new System.Drawing.Point(0, 0);
            this.txbFiles.Name = "txbFiles";
            this.txbFiles.Paddings = new System.Windows.Forms.Padding(0);
            this.txbFiles.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txbFiles.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txbFiles.ServiceColors")));
            this.txbFiles.Size = new System.Drawing.Size(297, 276);
            this.txbFiles.TabIndex = 0;
            this.txbFiles.Zoom = 100;
            this.txbFiles.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txbFiles_TextChanged);
            // 
            // PathContainerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbFiles);
            this.Name = "PathContainerView";
            this.Size = new System.Drawing.Size(297, 276);
            ((System.ComponentModel.ISupportInitialize)(this.txbFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox txbFiles;
    }
}
