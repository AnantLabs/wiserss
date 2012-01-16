using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Business;
using System.Timers;

namespace WiseService
{
    public partial class WiseService : ServiceBase
    {
        private Timer timer1 = new Timer();
        private RssObject wRssObject = new RssObject();

        public WiseService()
        {
            InitializeComponent();
            timer1.Elapsed += new ElapsedEventHandler(timer1_Elapsed);
            timer1.Interval = 60000;
        }

        protected override void OnStart(string[] args)
        {
            timer1.Start();
        }



        protected override void OnStop()
        {
            timer1.Stop();
        }

        private void timer1_Elapsed(object sender, EventArgs e)
        {
            wRssObject.InsertNewItems();
        }
    }
}
