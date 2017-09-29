using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DailyReportTotalPeople
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
        public const string DrawPacketPeopleField = "DrawPacketPeople";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AllPacketPeopleField = "AllPacketPeople";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTsField = "CreateTs";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RefreshCurrentField = "RefreshCurrent";
    
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
        public int DrawPacketPeople { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AllPacketPeople { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RefreshCurrent { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "ReportDate", ReportDate);
            output.AppendFormat(":{0}={1}", "DrawPacketPeople", DrawPacketPeople);
            output.AppendFormat(":{0}={1}", "AllPacketPeople", AllPacketPeople);
            output.AppendFormat(":{0}={1}", "CreateTs", CreateTs);
            output.AppendFormat(":{0}={1}", "RefreshCurrent", RefreshCurrent);
            return output.ToString();
        }
    }
}