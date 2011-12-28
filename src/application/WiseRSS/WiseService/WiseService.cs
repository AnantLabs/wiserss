using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
//using System.Timers;

namespace WiseService
{
    public partial class WiseService : ServiceBase
    {
        //Timer tmr = new Timer();

        public WiseService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DebugMode();
            tmr.Enabled = true;
        }

        

        protected override void OnStop()
        {
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            
        }

        [Conditional("DEBUG_SERVICE")]
        private static void DebugMode()
        {
            Debugger.Break();
        }

    }
}
