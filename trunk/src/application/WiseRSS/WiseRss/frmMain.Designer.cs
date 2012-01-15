﻿namespace WiseRss
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
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
      this.cbxTranslate = new System.Windows.Forms.ComboBox();
      this.menuStrip1.SuspendLayout();
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
      // 
      // exitToolStripMenuItem1
      // 
      this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
      this.exitToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
      this.exitToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
      this.exitToolStripMenuItem1.Text = "&Exit";
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
      this.viewToolStripMenuItem.Text = "&View";
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
      this.treeView1.Location = new System.Drawing.Point(0, 27);
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
      this.treeView1.Size = new System.Drawing.Size(227, 409);
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
      this.rchTxtContent.BackColor = System.Drawing.SystemColors.Window;
      this.rchTxtContent.Location = new System.Drawing.Point(233, 27);
      this.rchTxtContent.Name = "rchTxtContent";
      this.rchTxtContent.Size = new System.Drawing.Size(597, 409);
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
      this.btnTranslate.Location = new System.Drawing.Point(743, 1);
      this.btnTranslate.Name = "btnTranslate";
      this.btnTranslate.Size = new System.Drawing.Size(75, 23);
      this.btnTranslate.TabIndex = 12;
      this.btnTranslate.Text = "Translate";
      this.btnTranslate.UseVisualStyleBackColor = true;
      this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
      // 
      // cbxTranslate
      // 
      this.cbxTranslate.FormattingEnabled = true;
      this.cbxTranslate.Location = new System.Drawing.Point(589, 3);
      this.cbxTranslate.Name = "cbxTranslate";
      this.cbxTranslate.Size = new System.Drawing.Size(148, 21);
      this.cbxTranslate.TabIndex = 13;
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(830, 448);
      this.Controls.Add(this.cbxTranslate);
      this.Controls.Add(this.btnTranslate);
      this.Controls.Add(this.btnBookmark);
      this.Controls.Add(this.btnTag);
      this.Controls.Add(this.btnFacebook);
      this.Controls.Add(this.btnTwitt);
      this.Controls.Add(this.rchTxtContent);
      this.Controls.Add(this.btnMail);
      this.Controls.Add(this.treeView1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Wise RSS";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
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

  }
}

