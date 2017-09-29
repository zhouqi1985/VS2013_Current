using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Wallets
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string WIdField = "WId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIdField = "UserId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIdField = "AreaId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarIdField = "AvatarId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RecordDateField = "RecordDate";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GetPointsField = "GetPoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string BalancePointsField = "BalancePoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTimeField = "CreateTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SourceField = "Source";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GetLastTimeField = "GetLastTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string FromIdField = "FromId";
    
        /// <summary>
        /// 
        /// </summary>
        public long WId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AvatarId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GetPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BalancePoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime GetLastTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long FromId { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "WId", WId);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "RecordDate", RecordDate);
            output.AppendFormat(":{0}={1}", "GetPoints", GetPoints);
            output.AppendFormat(":{0}={1}", "BalancePoints", BalancePoints);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "Source", Source);
            output.AppendFormat(":{0}={1}", "GetLastTime", GetLastTime);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "FromId", FromId);
            return output.ToString();
        }
    }
}