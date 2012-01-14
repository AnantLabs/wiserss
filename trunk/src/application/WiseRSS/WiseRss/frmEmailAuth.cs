using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WiseRss
{
    public partial class frmEmailAuth : Form
    {
        public frmEmailAuth()
        {
            InitializeComponent();
        }
        public string username = "";
        public string geslo = "";

        private void btnShrani_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text != "" && tbGeslo.Text != "")
            {
                username = tbUsername.Text;
                geslo = tbGeslo.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
