using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TransferData_All_ReportDateConfig
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string ConfigIdField = "ConfigId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ConfigNameField = "ConfigName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusField = "Status";
        /// <summary>
        /// (1)GameDetailsPerUser(2)ItemConsume(3)TotalPeople字段
        /// </summary>
        public const string ReportIdField = "ReportId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StartTimeField = "StartTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EndTimeField = "EndTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTimeField = "CreateTime";
    
        /// <summary>
        /// 
        /// </summary>
        public int ConfigId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ConfigName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// (1)GameDetailsPerUser(2)ItemConsume(3)TotalPeople
        /// </summary>
        public int ReportId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ConfigId", ConfigId);
            output.AppendFormat(":{0}={1}", "ConfigName", ConfigName);
            output.AppendFormat(":{0}={1}", "Status", Status);
            output.AppendFormat(":{0}={1}", "ReportId", ReportId);
            output.AppendFormat(":{0}={1}", "StartTime", StartTime);
            output.AppendFormat(":{0}={1}", "EndTime", EndTime);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            return output.ToString();
        }
    }
}