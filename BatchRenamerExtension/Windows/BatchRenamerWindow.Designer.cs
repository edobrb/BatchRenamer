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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOtherFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOtherFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReset = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegex = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkShowpathDest = new System.Windows.Forms.ToolStripMenuItem();
            this.chkCheckPaths = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApplyRename = new System.Windows.Forms.ToolStripMenuItem();
            this.pathContainerPreview = new PathContainerView();
            this.pathContainerView = new PathContainerView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.btnHelp,
            this.viewToolStripMenuItem,
            this.btnApplyRename});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOtherFilesToolStripMenuItem,
            this.addOtherFoldersToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addOtherFilesToolStripMenuItem
            // 
            this.addOtherFilesToolStripMenuItem.Name = "addOtherFilesToolStripMenuItem";
            this.addOtherFilesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.addOtherFilesToolStripMenuItem.Text = "Add other files...";
            // 
            // addOtherFoldersToolStripMenuItem
            // 
            this.addOtherFoldersToolStripMenuItem.Name = "addOtherFoldersToolStripMenuItem";
            this.addOtherFoldersToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.addOtherFoldersToolStripMenuItem.Text = "Add other folders...";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReset,
            this.btnRegex});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(115, 22);
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRegex
            // 
            this.btnRegex.Name = "btnRegex";
            this.btnRegex.Size = new System.Drawing.Size(115, 22);
            this.btnRegex.Text = "Regex...";
            this.btnRegex.Click += new System.EventHandler(this.btnRegex_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(24, 20);
            this.btnHelp.Text = "?";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkShowpathDest,
            this.chkCheckPaths});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // chkShowpathDest
            // 
            this.chkShowpathDest.CheckOnClick = true;
            this.chkShowpathDest.Name = "chkShowpathDest";
            this.chkShowpathDest.Size = new System.Drawing.Size(175, 22);
            this.chkShowpathDest.Text = "Show full path";
            this.chkShowpathDest.CheckedChanged += new System.EventHandler(this.chkShowpathDest_CheckedChanged);
            // 
            // chkCheckPaths
            // 
            this.chkCheckPaths.CheckOnClick = true;
            this.chkCheckPaths.Name = "chkCheckPaths";
            this.chkCheckPaths.Size = new System.Drawing.Size(175, 22);
            this.chkCheckPaths.Text = "Check path validity";
            this.chkCheckPaths.CheckedChanged += new System.EventHandler(this.chkCheckPaths_CheckedChanged);
            // 
            // btnApplyRename
            // 
            this.btnApplyRename.Enabled = false;
            this.btnApplyRename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyRename.Name = "btnApplyRename";
            this.btnApplyRename.Size = new System.Drawing.Size(50, 20);
            this.btnApplyRename.Text = "Apply";
            this.btnApplyRename.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // pathContainerPreview
            // 
            this.pathContainerPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathContainerPreview.Location = new System.Drawing.Point(0, 24);
            this.pathContainerPreview.Name = "pathContainerPreview";
            this.pathContainerPreview.Size = new System.Drawing.Size(591, 274);
            this.pathContainerPreview.TabIndex = 8;
            this.pathContainerPreview.TabStop = false;
            this.pathContainerPreview.Visible = false;
            // 
            // pathContainerView
            // 
            this.pathContainerView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathContainerView.Location = new System.Drawing.Point(0, 24);
            this.pathContainerView.Name = "pathContainerView";
            this.pathContainerView.Size = new System.Drawing.Size(591, 274);
            this.pathContainerView.TabIndex = 8;
            // 
            // BatchRenamerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 300);
            this.Controls.Add(this.pathContainerPreview);
            this.Controls.Add(this.pathContainerView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 240);
            this.Name = "BatchRenamerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bath Renamer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PathContainerView pathContainerView;
        private PathContainerView pathContainerPreview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.ToolStripMenuItem btnReset;
        private System.Windows.Forms.ToolStripMenuItem btnRegex;
        private System.Windows.Forms.ToolStripMenuItem addOtherFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addOtherFoldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chkShowpathDest;
        private System.Windows.Forms.ToolStripMenuItem chkCheckPaths;
        private System.Windows.Forms.ToolStripMenuItem btnApplyRename;
    }
}