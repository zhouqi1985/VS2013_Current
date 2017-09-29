using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace PetFeedEventsService
{
    public partial class PetFeedServcie : ServiceBase
    {
        private PetFeedEvents.DAL.IPetFeedEventsDAL _dal = new PetFeedEvents.DAL.PetFeedEventsDAL();
        DateTime RecordDate = Convert.ToDateTime(System.Configuration.ConfigurationManager.AppSettings["RecordDate"]);
        string RunMethod = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["RunMethod"]);
        List<Thread> threadlist = new List<Thread>();
        public PetFeedServcie()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ServiceLog.InfoLog("Windows Service Start");
            DateTimeConfig dtconfig = new DateTimeConfig();
            DynamicQueue dq = new DynamicQueue();
            ParameterizedThreadStart pts = new ParameterizedThreadStart(dq.SendDynamicPacketMultiple);
            Thread th = new Thread(pts);
            th.Start(dtconfig);
            threadlist.Add(th);
        }

        protected override void OnStop()
        {
            foreach (Thread thread in threadlist)
            {
                thread.Abort();
            }
            threadlist.Clear();
            threadlist = null;
            ServiceLog.InfoLog("Windows Service Stop");
        }


        
    }
}
