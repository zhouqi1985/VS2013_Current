using CampEvents.Database.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampEvents.Database.Database
{
    public class ResultInfo
    {
        public ErrorCode Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PacketName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long CampPoints { get; set; }
        public int CampId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UserPoints { get; set; }
        public bool IsNotice { get; set; }
        public DateTime CutOffTime { get; set; }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "Result", Result);
            output.AppendFormat(":{0}={1}", "PacketName", PacketName);
            output.AppendFormat(":{0}={1}", "CampPoints", CampPoints);
            output.AppendFormat(":{0}={1}", "CampId", CampId);
            output.AppendFormat(":{0}={1}", "UserPoints", UserPoints);
            output.AppendFormat(":{0}={1}", "IsNotice", IsNotice);
            output.AppendFormat(":{0}={1}", "CutOffTime", CutOffTime);
            return output.ToString();
        }
    }
}
