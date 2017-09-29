using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PuzzleDrawDetails
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleDrawIDField = "PuzzleDrawID";
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
        public const string DrawCountField = "DrawCount";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ActualCountField = "ActualCount";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIdField = "PuzzleTypeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PointsField = "Points";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LoginNameField = "LoginName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AwardNameField = "AwardName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsCompleteField = "IsComplete";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsNoticeField = "IsNotice";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsPuzzleField = "IsPuzzle";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SexField = "Sex";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RateField = "Rate";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketRateField = "PacketRate";
                /// <summary>
        /// 字段
        /// </summary>
        public const string AllPiecesRateField = "AllPiecesRate";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExtraCountField = "ExtraCount";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AwardPuzzlePacketField = "AwardPuzzlePacket";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleNoticeField = "PuzzleNotice";
        /// <summary>
        /// 字段
        /// </summary>
        public const string DrawRSField = "DrawRS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleIDField = "PuzzleID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PiecesOrderField = "PiecesOrder";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleRandomField = "PuzzleRandom";
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleDrawID { get; set; }
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
        public int DrawCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ActualCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExtraCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsComplete { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AwardName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNotice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsPuzzle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AllPiecesRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AwardPuzzlePacket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool PuzzleNotice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DrawRS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PiecesOrder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleRandom { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "PuzzleDrawID", PuzzleDrawID);
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "DrawCount", DrawCount);
            output.AppendFormat(":{0}={1}", "ActualCount", ActualCount);
            output.AppendFormat(":{0}={1}", "PuzzleTypeId", PuzzleTypeId);
            output.AppendFormat(":{0}={1}", "Points", Points);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "IsComplete", IsComplete);
            output.AppendFormat(":{0}={1}", "AwardName", AwardName);
            output.AppendFormat(":{0}={1}", "IsNotice", IsNotice);
            output.AppendFormat(":{0}={1}", "IsPuzzle", IsPuzzle);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "Rate", Rate);
            output.AppendFormat(":{0}={1}", "PacketRate", PacketRate);
            output.AppendFormat(":{0}={1}", "ExtraCount", ExtraCount);
            output.AppendFormat(":{0}={1}", "AllPiecesRate", AllPiecesRate);
            output.AppendFormat(":{0}={1}", "AwardPuzzlePacket", AwardPuzzlePacket);
            output.AppendFormat(":{0}={1}", "PuzzleNotice", PuzzleNotice);
            output.AppendFormat(":{0}={1}", "DrawRS", DrawRS);
            output.AppendFormat(":{0}={1}", "PiecesOrder", PiecesOrder);
            output.AppendFormat(":{0}={1}", "PuzzleID", PuzzleID);
            output.AppendFormat(":{0}={1}", "PuzzleRandom", PuzzleRandom);
            return output.ToString();
        }
    }
}