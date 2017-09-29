using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class RankList_TopN
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IdField = "Id";
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIdField = "UserId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarIdField = "AvatarId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIdField = "AreaId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GetPointsField = "GetPoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTimeField = "CreateTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RankOrderField = "RankOrder";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GetLastTimeField = "GetLastTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CutOffDateField = "CutOffDate";
    
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AvatarId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GetPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RankOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime GetLastTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CutOffDate { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "GetPoints", GetPoints);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "RankOrder", RankOrder);
            output.AppendFormat(":{0}={1}", "GetLastTime", GetLastTime);
            output.AppendFormat(":{0}={1}", "CutOffDate", CutOffDate);
            return output.ToString();
        }
    }
}