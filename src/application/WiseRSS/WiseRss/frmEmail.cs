using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace WiseRss
{
    public partial class frmEmail : Form
    {
        private string uporabnik = "";
        private string geslo = "";

        public frmEmail()
        {
            InitializeComponent();
        }

        public void setParams(string naslov, string vsebina)
        {
            tbNaslov.Text = naslov;
            rtbVsebina.Text = vsebina;
        }

        private void btnPoslji_Click(object sender, EventArgs e)
        {
            if (uporabnik == "")
            {
                frmEmailAuth frmAuth = new frmEmailAuth();
                if (frmAuth.ShowDialog() == DialogResult.OK)
                {
                    uporabnik = frmAuth.username;
                    geslo = frmAuth.geslo;
                }                
            }
            if (uporabnik != "")
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(uporabnik, geslo),
                    EnableSsl = true
                };
                client.Send(uporabnik, tbPrejemniki.Text, tbNaslov.Text, rtbVsebina.Text);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
