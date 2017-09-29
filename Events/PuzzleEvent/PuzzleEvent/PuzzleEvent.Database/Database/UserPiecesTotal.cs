using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserPiecesTotal
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string RecordIDField = "RecordID";
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
        public const string PiecesTotalField = "PiecesTotal";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PiecesConsumeField = "PiecesConsume";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PiecesBalanceField = "PiecesBalance";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PiecesOccupiedField = "PiecesOccupied";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RemainPointsField = "RemainPoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsFirstField = "IsFirst";
    
        /// <summary>
        /// 
        /// </summary>
        public long RecordID { get; set; }
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
        public long PiecesTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PiecesConsume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PiecesBalance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PiecesOccupied { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long RemainPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IsFirst { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "RecordID", RecordID);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "PiecesTotal", PiecesTotal);
            output.AppendFormat(":{0}={1}", "PiecesConsume", PiecesConsume);
            output.AppendFormat(":{0}={1}", "PiecesBalance", PiecesBalance);
            output.AppendFormat(":{0}={1}", "PiecesOccupied", PiecesOccupied);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleTypeID);
            output.AppendFormat(":{0}={1}", "RemainPoints", RemainPoints);
            output.AppendFormat(":{0}={1}", "IsFirst", IsFirst);
            return output.ToString();
        }
    }
}