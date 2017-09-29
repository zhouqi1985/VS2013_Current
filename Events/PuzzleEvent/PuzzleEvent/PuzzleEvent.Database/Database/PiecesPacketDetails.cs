using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PiecesPacketDetails
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string ReceiveIDField = "ReceiveID";
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
        public const string PointsField = "Points";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsPuzzleField = "IsPuzzle";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePacketIDField = "PuzzlePacketID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePieceIdField = "PuzzlePieceId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleDrawIDField = "PuzzleDrawID";
    
        /// <summary>
        /// 
        /// </summary>
        public long ReceiveID { get; set; }
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
        public int Points { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsPuzzle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePacketID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePieceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleDrawID { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ReceiveID", ReceiveID);
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "Points", Points);
            output.AppendFormat(":{0}={1}", "IsPuzzle", IsPuzzle);
            output.AppendFormat(":{0}={1}", "PuzzlePacketID", PuzzlePacketID);
            output.AppendFormat(":{0}={1}", "PuzzlePieceId", PuzzlePieceId);
            output.AppendFormat(":{0}={1}", "PuzzleDrawID", PuzzleDrawID);
            return output.ToString();
        }
    }
}