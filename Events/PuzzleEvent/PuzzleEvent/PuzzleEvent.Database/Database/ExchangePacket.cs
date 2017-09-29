using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ExchangePacket
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketIdField = "PacketId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketNameField = "PacketName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketDescField = "PacketDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string NeedPointsField = "NeedPoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsNoticeField = "IsNotice";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsLimitField = "IsLimit";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LimitCountField = "LimitCount";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsDeleteField = "IsDelete";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTimeField = "CreateTime";
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
        public const string GameAreaField = "GameArea";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SexField = "Sex";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TotalCountField = "TotalCount";
    
        /// <summary>
        /// 
        /// </summary>
        public long PacketId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PacketName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PacketDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NeedPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNotice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int LimitCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsDelete { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
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
        public int GameArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "PacketName", PacketName);
            output.AppendFormat(":{0}={1}", "PacketDesc", PacketDesc);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleTypeID);
            output.AppendFormat(":{0}={1}", "NeedPoints", NeedPoints);
            output.AppendFormat(":{0}={1}", "IsNotice", IsNotice);
            output.AppendFormat(":{0}={1}", "IsLimit", IsLimit);
            output.AppendFormat(":{0}={1}", "LimitCount", LimitCount);
            output.AppendFormat(":{0}={1}", "IsDelete", IsDelete);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "GameArea", GameArea);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "TotalCount", TotalCount);
            return output.ToString();
        }
    }
}