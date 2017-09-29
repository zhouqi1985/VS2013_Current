using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserSearch
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIdField = "UserId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIDField = "AreaID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarIdField = "AvatarID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";

        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketIdField = "PacketID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SexField = "Sex";
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AvatarID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PacketID { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleTypeID);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "PacketID", PacketID);
            return output.ToString();
        }
    }
}