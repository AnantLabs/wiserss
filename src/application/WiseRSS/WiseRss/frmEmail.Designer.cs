namespace WiseRss
{
    partial class frmEmail
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
            this.btnPoslji = new System.Windows.Forms.Button();
            this.lblKomu = new System.Windows.Forms.Label();
            this.tbPrejemniki = new System.Windows.Forms.TextBox();
            this.tbNaslov = new System.Windows.Forms.TextBox();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.rtbVsebina = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPoslji
            // 
            this.btnPoslji.Location = new System.Drawing.Point(405, 251);
            this.btnPoslji.Name = "btnPoslji";
            this.btnPoslji.Size = new System.Drawing.Size(75, 23);
            this.btnPoslji.TabIndex = 0;
            this.btnPoslji.Text = "Pošlji";
            this.btnPoslji.UseVisualStyleBackColor = true;
            this.btnPoslji.Click += new System.EventHandler(this.btnPoslji_Click);
            // 
            // lblKomu
            // 
            this.lblKomu.AutoSize = true;
            this.lblKomu.Location = new System.Drawing.Point(12, 9);
            this.lblKomu.Name = "lblKomu";
            this.lblKomu.Size = new System.Drawing.Size(54, 13);
            this.lblKomu.TabIndex = 1;
            this.lblKomu.Text = "prejemniki";
            // 
            // tbPrejemniki
            // 
            this.tbPrejemniki.Location = new System.Drawing.Point(15, 25);
            this.tbPrejemniki.Name = "tbPrejemniki";
            this.tbPrejemniki.Size = new System.Drawing.Size(465, 20);
            this.tbPrejemniki.TabIndex = 2;
            // 
            // tbNaslov
            // 
            this.tbNaslov.Location = new System.Drawing.Point(15, 64);
            this.tbNaslov.Name = "tbNaslov";
            this.tbNaslov.Size = new System.Drawing.Size(465, 20);
            this.tbNaslov.TabIndex = 4;
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Location = new System.Drawing.Point(12, 48);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(38, 13);
            this.lblNaslov.TabIndex = 3;
            this.lblNaslov.Text = "naslov";
            // 
            // rtbVsebina
            // 
            this.rtbVsebina.Location = new System.Drawing.Point(15, 90);
            this.rtbVsebina.Name = "rtbVsebina";
            this.rtbVsebina.Size = new System.Drawing.Size(465, 155);
            this.rtbVsebina.TabIndex = 5;
            this.rtbVsebina.Text = "";
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 286);
            this.Controls.Add(this.rtbVsebina);
            this.Controls.Add(this.tbNaslov);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.tbPrejemniki);
            this.Controls.Add(this.lblKomu);
            this.Controls.Add(this.btnPoslji);
            this.Name = "frmEmail";
            this.Text = "frmEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPoslji;
        private System.Windows.Forms.Label lblKomu;
        private System.Windows.Forms.TextBox tbPrejemniki;
        private System.Windows.Forms.TextBox tbNaslov;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.RichTextBox rtbVsebina;
    }
}