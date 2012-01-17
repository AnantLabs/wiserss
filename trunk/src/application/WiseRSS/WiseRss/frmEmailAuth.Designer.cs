namespace WiseRss
{
    partial class frmEmailAuth
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
      this.label1 = new System.Windows.Forms.Label();
      this.tbUsername = new System.Windows.Forms.TextBox();
      this.tbGeslo = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.btnShrani = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "gmail";
      // 
      // tbUsername
      // 
      this.tbUsername.Location = new System.Drawing.Point(15, 25);
      this.tbUsername.Name = "tbUsername";
      this.tbUsername.Size = new System.Drawing.Size(271, 20);
      this.tbUsername.TabIndex = 1;
      // 
      // tbGeslo
      // 
      this.tbGeslo.Location = new System.Drawing.Point(15, 66);
      this.tbGeslo.Name = "tbGeslo";
      this.tbGeslo.PasswordChar = '*';
      this.tbGeslo.Size = new System.Drawing.Size(271, 20);
      this.tbGeslo.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 50);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(32, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "geslo";
      // 
      // btnShrani
      // 
      this.btnShrani.Location = new System.Drawing.Point(211, 92);
      this.btnShrani.Name = "btnShrani";
      this.btnShrani.Size = new System.Drawing.Size(75, 23);
      this.btnShrani.TabIndex = 4;
      this.btnShrani.Text = "Shrani";
      this.btnShrani.UseVisualStyleBackColor = true;
      this.btnShrani.Click += new System.EventHandler(this.btnShrani_Click);
      // 
      // frmEmailAuth
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(299, 124);
      this.Controls.Add(this.btnShrani);
      this.Controls.Add(this.tbGeslo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbUsername);
      this.Controls.Add(this.label1);
      this.Name = "frmEmailAuth";
      this.Text = "frmEmailAuth";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbGeslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShrani;
    }
}