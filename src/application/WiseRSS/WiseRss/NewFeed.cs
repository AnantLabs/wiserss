using System;
using System.Windows.Forms;

namespace WiseRss
{
  public partial class frmAddNewFeeds : Form
  {
    frmMain frmParent = null;

    public frmAddNewFeeds()
    {
      InitializeComponent();
    }

    public frmAddNewFeeds(frmMain frm)
      : this()
    {
      frmParent = frm;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (frmParent != null)
      {
        // add each url into list of new feeds
        foreach (object url in lstbUrls.Items)
        {
          if (url is string)
          {
            frmParent.ListNewFeeds.Add((string)url);
          }
        }
      }
      this.Close();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (txtUrl != null && txtUrl.Text != null)
      {
        string uri = txtUrl.Text.Trim();

        if (!string.IsNullOrWhiteSpace(uri) &&
            !lstbUrls.Items.Contains(uri))
        {
          lstbUrls.Items.Add(uri);
          txtUrl.Clear();
        }
      }
    }
  }
}