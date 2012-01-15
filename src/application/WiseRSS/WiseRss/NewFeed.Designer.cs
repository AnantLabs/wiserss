namespace WiseRss
{
  partial class frmAddNewFeeds
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
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lstbUrls = new System.Windows.Forms.ListBox();
      this.txtUrl = new System.Windows.Forms.TextBox();
      this.lblUrl = new System.Windows.Forms.Label();
      this.btnAdd = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnOK
      // 
      this.btnOK.Location = new System.Drawing.Point(512, 238);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(599, 238);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // lstbUrls
      // 
      this.lstbUrls.FormattingEnabled = true;
      this.lstbUrls.Location = new System.Drawing.Point(12, 33);
      this.lstbUrls.Name = "lstbUrls";
      this.lstbUrls.Size = new System.Drawing.Size(662, 199);
      this.lstbUrls.TabIndex = 3;
      // 
      // txtUrl
      // 
      this.txtUrl.Location = new System.Drawing.Point(47, 6);
      this.txtUrl.Name = "txtUrl";
      this.txtUrl.Size = new System.Drawing.Size(527, 20);
      this.txtUrl.TabIndex = 1;
      // 
      // lblUrl
      // 
      this.lblUrl.AutoSize = true;
      this.lblUrl.ForeColor = System.Drawing.Color.Blue;
      this.lblUrl.Location = new System.Drawing.Point(9, 9);
      this.lblUrl.Name = "lblUrl";
      this.lblUrl.Size = new System.Drawing.Size(32, 13);
      this.lblUrl.TabIndex = 0;
      this.lblUrl.Text = "URL:";
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(589, 4);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(88, 23);
      this.btnAdd.TabIndex = 2;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
      // 
      // frmAddNewFeeds
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(686, 272);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.lblUrl);
      this.Controls.Add(this.txtUrl);
      this.Controls.Add(this.lstbUrls);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAddNewFeeds";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Add New Feeds";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.ListBox lstbUrls;
    private System.Windows.Forms.TextBox txtUrl;
    private System.Windows.Forms.Label lblUrl;
    private System.Windows.Forms.Button btnAdd;
  }
}