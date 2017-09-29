using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ExchangeAndDrawLog
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string ConsumeIdField = "ConsumeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIdField = "UserId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LoginNameField = "LoginName";
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
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SexField = "Sex";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeIdField = "ExchangeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PointsField = "Points";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RandNumField = "RandNum";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTimeField = "CreateTime";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SourceField = "Source";
    
        /// <summary>
        /// 
        /// </summary>
        public long ConsumeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
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
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RandNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ConsumeId", ConsumeId);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "AreaId", AreaId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "ExchangeId", ExchangeId);
            output.AppendFormat(":{0}={1}", "Points", Points);
            output.AppendFormat(":{0}={1}", "RandNum", RandNum);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "Source", Source);
            return output.ToString();
        }
    }
}