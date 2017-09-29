using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PuzzleReceiveDetails
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string ReceivePuzzleIDField = "ReceivePuzzleID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIDField = "UserID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIDField = "AreaID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarIDField = "AvatarID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTSField = "CreateTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleIDField = "PuzzleID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIdField = "PuzzleTypeId";
    
        /// <summary>
        /// 
        /// </summary>
        public int ReceivePuzzleID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserID { get; set; }
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
        public DateTime CreateTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeId { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ReceivePuzzleID", ReceivePuzzleID);
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "PuzzleID", PuzzleID);
            output.AppendFormat(":{0}={1}", "PuzzleTypeId", PuzzleTypeId);
            return output.ToString();
        }
    }
}