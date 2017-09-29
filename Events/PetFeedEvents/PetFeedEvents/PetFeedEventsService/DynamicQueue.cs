using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PetFeedEventsService
{
    public class DynamicQueue
    {
        private PetFeedEvents.DAL.IPetFeedEventsDAL _dal = new PetFeedEvents.DAL.PetFeedEventsDAL();

        public void SendDynamicPacketMultiple(object datetimeconfig)
        {
            ServiceLog.InfoLog("SendDynamicPacketMultiple Start");
            DateTimeConfig config = datetimeconfig as DateTimeConfig;
            ServiceLog.InfoLog("Service Run Mehtod." + config.RunMethod);
            List<RunDateConfig> RunDateList = new List<RunDateConfig>();
            if (config.RunMethod != "Auto")
            {
                SendDynamicPacketOnce(config);
                return;
            }
            ServiceLog.InfoLog("Service Run Mehtod." + config.RunMethod);
            for (DateTime startdt = config.StartDate; startdt <= config.EndDate; startdt=startdt.AddDays(1))
            {
                DateTime currentdt = Convert.ToDateTime(startdt.ToShortDateString() + " " + config.RunTime);
                if (currentdt > DateTime.Now)
                {
                    ServiceLog.InfoLog("Service Run Mehtod Add Run Date List." + currentdt);
                    RunDateConfig runconfig = new RunDateConfig() { Rundate=currentdt,IsRun=false};
                    RunDateList.Add(runconfig);          
                }
            }
            while (true)
            {
                foreach (RunDateConfig rundate in RunDateList)
                {
                    if (DateTime.Now >= rundate.Rundate&&rundate.IsRun==false)
                    {
                        ServiceLog.InfoLog("Service Auto Method Run." + rundate.Rundate);
                        DateTime RecordDate = Convert.ToDateTime(rundate.Rundate.ToShortDateString()).AddDays(-1);
                        SendDynamicPacket(RecordDate);
                        int dateindex = RunDateList.IndexOf(rundate);
                        RunDateList[dateindex].IsRun = true;
                    }
                    Thread.Sleep(1000);
                }
                Thread.Sleep(1000);
            }

        }

        public void SendDynamicPacketOnce(DateTimeConfig config)
        {
            ServiceLog.InfoLog("SendDynamicPacketOnce Start");
            DateTime RunDate = new DateTime();
            if (config.RunMethod == "Mannual")
            {
                RunDate = config.RecordDate;
            }
            else if (config.RunMethod == "Default")
            {
                RunDate = DateTime.Parse(System.DateTime.Now.ToShortDateString()).AddDays(-1);
            }
            SendDynamicPacket(RunDate);

        }
        public void SendDynamicPacket(DateTime reportdate)
        {
            ServiceLog.InfoLog("SendDynamicPacket Start");
            ServiceLog.InfoLog("RecordDate." + reportdate);
            try
            {
                List<int> rs = _dal.GameLogTransfer(reportdate);
                int rs2 = _dal.SendDynamicCouponQueue();
                if (rs[0] < 1 || rs2 < 1)
                {
                    ServiceLog.InfoLog("No Data." + rs[0] + "," + rs[1]  + "," + rs2);
                    return;
                }
                ServiceLog.InfoLog("Success." + rs[0] + "," + rs[1]  +","+ rs2);
            }
            catch (Exception ex)
            {
                ServiceLog.ErrorLog(ex);
            }
        }
    }
}
