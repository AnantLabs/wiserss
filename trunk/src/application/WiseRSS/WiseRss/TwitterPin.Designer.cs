namespace WiseRss
{
    partial class TwitterPin
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
            this.btnPotrdi = new System.Windows.Forms.Button();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPotrdi
            // 
            this.btnPotrdi.Location = new System.Drawing.Point(205, 18);
            this.btnPotrdi.Name = "btnPotrdi";
            this.btnPotrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotrdi.TabIndex = 0;
            this.btnPotrdi.Text = "Potrdi";
            this.btnPotrdi.UseVisualStyleBackColor = true;
            this.btnPotrdi.Click += new System.EventHandler(this.btnPotrdi_Click);
            // 
            // tbPin
            // 
            this.tbPin.Location = new System.Drawing.Point(18, 13);
            this.tbPin.Name = "tbPin";
            this.tbPin.Size = new System.Drawing.Size(146, 20);
            this.tbPin.TabIndex = 1;
            // 
            // TwitterPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 53);
            this.Controls.Add(this.tbPin);
            this.Controls.Add(this.btnPotrdi);
            this.Name = "TwitterPin";
            this.Text = "TwitterPin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPotrdi;
        private System.Windows.Forms.TextBox tbPin;
    }
}