namespace WiseRss
{
  partial class frmMain
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
      System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Subscriptions", 0, 0);
      System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Tags", 1, 1);
      System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Bookmarks", 2, 2);
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.newFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copytToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.treeVewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rchTxtContent = new System.Windows.Forms.RichTextBox();
      this.btnTag = new System.Windows.Forms.Button();
      this.btnBookmark = new System.Windows.Forms.Button();
      this.btnFacebook = new System.Windows.Forms.Button();
      this.btnTwitt = new System.Windows.Forms.Button();
      this.btnMail = new System.Windows.Forms.Button();
      this.btnTranslate = new System.Windows.Forms.Button();
      this.translateContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.googleTranslatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.microsoftTranslatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cbxTranslate = new System.Windows.Forms.ComboBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.menuStrip1.SuspendLayout();
      this.translateContextMenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(830, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem1});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // addToolStripMenuItem1
      // 
      this.addToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFeedToolStripMenuItem});
      this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
      this.addToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
      this.addToolStripMenuItem1.Text = "&Add";
      // 
      // newFeedToolStripMenuItem
      // 
      this.newFeedToolStripMenuItem.Name = "newFeedToolStripMenuItem";
      this.newFeedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newFeedToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.newFeedToolStripMenuItem.Text = "&New Feed";
      this.newFeedToolStripMenuItem.Click += new System.EventHandler(this.newFeedToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
      this.saveAsToolStripMenuItem.Text = "&Save As";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem1
      // 
      this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
      this.exitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
      this.exitToolStripMenuItem1.Text = "&Exit";
      this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copytToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.selectAllToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // cutToolStripMenuItem
      // 
      this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
      this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.cutToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.cutToolStripMenuItem.Text = "Cut";
      this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
      // 
      // copytToolStripMenuItem
      // 
      this.copytToolStripMenuItem.Name = "copytToolStripMenuItem";
      this.copytToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copytToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.copytToolStripMenuItem.Text = "Copy";
      this.copytToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.pasteToolStripMenuItem.Text = "Paste";
      this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
      this.selectAllToolStripMenuItem.Text = "Select All";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.treeVewToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // treeVewToolStripMenuItem
      // 
      this.treeVewToolStripMenuItem.Checked = true;
      this.treeVewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.treeVewToolStripMenuItem.Name = "treeVewToolStripMenuItem";
      this.treeVewToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
      this.treeVewToolStripMenuItem.Text = "&TreeVew";
      this.treeVewToolStripMenuItem.Click += new System.EventHandler(this.treeVewToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // treeView1
      // 
      this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.treeView1.Indent = 15;
      this.treeView1.ItemHeight = 16;
      this.treeView1.Location = new System.Drawing.Point(3, 3);
      this.treeView1.Name = "treeView1";
      treeNode1.ImageIndex = 0;
      treeNode1.Name = "NodeSubscriptions";
      treeNode1.SelectedImageIndex = 0;
      treeNode1.Text = "Subscriptions";
      treeNode2.ImageIndex = 1;
      treeNode2.Name = "NodeTags";
      treeNode2.SelectedImageIndex = 1;
      treeNode2.Text = "Tags";
      treeNode3.ImageIndex = 2;
      treeNode3.Name = "NodeBookmarks";
      treeNode3.SelectedImageIndex = 2;
      treeNode3.Text = "Bookmarks";
      this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
      this.treeView1.ShowNodeToolTips = true;
      this.treeView1.Size = new System.Drawing.Size(270, 409);
      this.treeView1.TabIndex = 2;
      this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
      this.saveToolStripMenuItem.Text = "&Save As";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
      this.exitToolStripMenuItem.Text = "&Exit";
      // 
      // rchTxtContent
      // 
      this.rchTxtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rchTxtContent.BackColor = System.Drawing.SystemColors.Window;
      this.rchTxtContent.Location = new System.Drawing.Point(3, 3);
      this.rchTxtContent.Name = "rchTxtContent";
      this.rchTxtContent.Size = new System.Drawing.Size(547, 409);
      this.rchTxtContent.TabIndex = 3;
      this.rchTxtContent.Text = "";
      // 
      // btnTag
      // 
      this.btnTag.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btnTag.Image = global::WiseRss.Properties.Resources.tag_icon;
      this.btnTag.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnTag.Location = new System.Drawing.Point(533, 1);
      this.btnTag.Name = "btnTag";
      this.btnTag.Size = new System.Drawing.Size(50, 23);
      this.btnTag.TabIndex = 11;
      this.btnTag.Text = "Tag";
      this.btnTag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnTag.UseVisualStyleBackColor = true;
      this.btnTag.Click += new System.EventHandler(this.btnTag_Click);
      // 
      // btnBookmark
      // 
      this.btnBookmark.Image = global::WiseRss.Properties.Resources.disable_bookmarks_icon;
      this.btnBookmark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnBookmark.Location = new System.Drawing.Point(448, 1);
      this.btnBookmark.Name = "btnBookmark";
      this.btnBookmark.Size = new System.Drawing.Size(79, 23);
      this.btnBookmark.TabIndex = 10;
      this.btnBookmark.Text = "Bookmark";
      this.btnBookmark.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnBookmark.UseVisualStyleBackColor = true;
      this.btnBookmark.Click += new System.EventHandler(this.btnBookmark_Click);
      // 
      // btnFacebook
      // 
      this.btnFacebook.Image = global::WiseRss.Properties.Resources.facebook_icon;
      this.btnFacebook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnFacebook.Location = new System.Drawing.Point(364, 1);
      this.btnFacebook.Name = "btnFacebook";
      this.btnFacebook.Size = new System.Drawing.Size(78, 23);
      this.btnFacebook.TabIndex = 9;
      this.btnFacebook.Text = "Facebook";
      this.btnFacebook.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnFacebook.UseVisualStyleBackColor = true;
      this.btnFacebook.Click += new System.EventHandler(this.btnFacebook_Click);
      // 
      // btnTwitt
      // 
      this.btnTwitt.Image = global::WiseRss.Properties.Resources.twitter_icon;
      this.btnTwitt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnTwitt.Location = new System.Drawing.Point(298, 1);
      this.btnTwitt.Name = "btnTwitt";
      this.btnTwitt.Size = new System.Drawing.Size(60, 23);
      this.btnTwitt.TabIndex = 8;
      this.btnTwitt.Text = "Twitter";
      this.btnTwitt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnTwitt.UseVisualStyleBackColor = true;
      this.btnTwitt.Click += new System.EventHandler(this.btnTwitt_Click);
      // 
      // btnMail
      // 
      this.btnMail.Image = global::WiseRss.Properties.Resources.mail_icon;
      this.btnMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnMail.Location = new System.Drawing.Point(233, 1);
      this.btnMail.Name = "btnMail";
      this.btnMail.Size = new System.Drawing.Size(59, 23);
      this.btnMail.TabIndex = 7;
      this.btnMail.Text = "E-mail";
      this.btnMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnMail.UseVisualStyleBackColor = true;
      this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
      // 
      // btnTranslate
      // 
      this.btnTranslate.ContextMenuStrip = this.translateContextMenuStrip;
      this.btnTranslate.Location = new System.Drawing.Point(743, 1);
      this.btnTranslate.Name = "btnTranslate";
      this.btnTranslate.Size = new System.Drawing.Size(75, 23);
      this.btnTranslate.TabIndex = 12;
      this.btnTranslate.Text = "Translate";
      this.btnTranslate.UseVisualStyleBackColor = true;
      this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
      // 
      // translateContextMenuStrip
      // 
      this.translateContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleTranslatorToolStripMenuItem,
            this.microsoftTranslatorToolStripMenuItem});
      this.translateContextMenuStrip.Name = "translateContextMenuStrip";
      this.translateContextMenuStrip.Size = new System.Drawing.Size(182, 48);
      // 
      // googleTranslatorToolStripMenuItem
      // 
      this.googleTranslatorToolStripMenuItem.Checked = true;
      this.googleTranslatorToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.googleTranslatorToolStripMenuItem.Name = "googleTranslatorToolStripMenuItem";
      this.googleTranslatorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.googleTranslatorToolStripMenuItem.Text = "Google Translator";
      this.googleTranslatorToolStripMenuItem.Click += new System.EventHandler(this.googleTranslatorToolStripMenuItem_Click);
      // 
      // microsoftTranslatorToolStripMenuItem
      // 
      this.microsoftTranslatorToolStripMenuItem.Name = "microsoftTranslatorToolStripMenuItem";
      this.microsoftTranslatorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
      this.microsoftTranslatorToolStripMenuItem.Text = "Microsoft Translator";
      this.microsoftTranslatorToolStripMenuItem.Click += new System.EventHandler(this.microsoftTranslatorToolStripMenuItem_Click);
      // 
      // cbxTranslate
      // 
      this.cbxTranslate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxTranslate.FormattingEnabled = true;
      this.cbxTranslate.Location = new System.Drawing.Point(589, 3);
      this.cbxTranslate.Name = "cbxTranslate";
      this.cbxTranslate.Size = new System.Drawing.Size(148, 21);
      this.cbxTranslate.Sorted = true;
      this.cbxTranslate.TabIndex = 13;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(0, 27);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.treeView1);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.rchTxtContent);
      this.splitContainer1.Size = new System.Drawing.Size(830, 421);
      this.splitContainer1.SplitterDistance = 276;
      this.splitContainer1.SplitterWidth = 1;
      this.splitContainer1.TabIndex = 14;
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.Filter = "\"Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf\"; ";
      this.saveFileDialog1.InitialDirectory = "C:\\";
      this.saveFileDialog1.RestoreDirectory = true;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(830, 448);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.cbxTranslate);
      this.Controls.Add(this.btnTranslate);
      this.Controls.Add(this.btnBookmark);
      this.Controls.Add(this.btnTag);
      this.Controls.Add(this.btnFacebook);
      this.Controls.Add(this.btnTwitt);
      this.Controls.Add(this.btnMail);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Wise RSS";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.translateContextMenuStrip.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem newFeedToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    private System.Windows.Forms.RichTextBox rchTxtContent;
    private System.Windows.Forms.Button btnFacebook;
    private System.Windows.Forms.Button btnTwitt;
    private System.Windows.Forms.Button btnMail;
    private System.Windows.Forms.Button btnTag;
    private System.Windows.Forms.Button btnBookmark;
    private System.Windows.Forms.Button btnTranslate;
    private System.Windows.Forms.ComboBox cbxTranslate;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.ToolStripMenuItem treeVewToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip translateContextMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem googleTranslatorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem microsoftTranslatorToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copytToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    
  }
}

