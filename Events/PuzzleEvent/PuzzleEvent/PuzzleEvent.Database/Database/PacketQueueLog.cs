using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PacketQueueLog
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string LogIdField = "LogId";
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
        public const string SexField = "Sex";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GameAreaField = "GameArea";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketIdField = "PacketId";
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
        public long LogId { get; set; }
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
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GameArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PacketId { get; set; }
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
            output.AppendFormat(":{0}={1}", "LogId", LogId);
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "GameArea", GameArea);
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "Source", Source);
            return output.ToString();
        }
    }
}