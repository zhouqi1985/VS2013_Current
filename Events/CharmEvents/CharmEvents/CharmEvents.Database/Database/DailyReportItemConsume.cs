using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DailyReportItemConsume
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IdField = "Id";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ReportDateField = "ReportDate";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ItemIdField = "ItemId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ItemNameField = "ItemName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TotalConsumeField = "TotalConsume";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTsField = "CreateTs";
    
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReportDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalConsume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTs { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "ReportDate", ReportDate);
            output.AppendFormat(":{0}={1}", "ItemId", ItemId);
            output.AppendFormat(":{0}={1}", "ItemName", ItemName);
            output.AppendFormat(":{0}={1}", "TotalConsume", TotalConsume);
            output.AppendFormat(":{0}={1}", "CreateTs", CreateTs);
            return output.ToString();
        }
    }
}