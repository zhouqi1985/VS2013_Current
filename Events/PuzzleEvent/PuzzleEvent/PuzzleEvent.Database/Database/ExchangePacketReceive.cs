using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ExchangePacketReceive
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeIdField = "ExchangeId";
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
        public const string PiecesCountField = "PiecesCount";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";
    
        /// <summary>
        /// 
        /// </summary>
        public long ExchangeId { get; set; }
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
        public int PiecesCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ExchangeId", ExchangeId);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "GameArea", GameArea);
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "PiecesCount", PiecesCount);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleTypeID);
            return output.ToString();
        }
    }
}