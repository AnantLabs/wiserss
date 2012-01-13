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
    public partial class TwitterPin : Form
    {
        public string pin = "";
        public TwitterPin()
        {
            InitializeComponent();
        }

        private void btnPotrdi_Click(object sender, EventArgs e)
        {
            pin = tbPin.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
