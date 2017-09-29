using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Wallet
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string WIdField = "WId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PaymentIdField = "PaymentId";
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
        public const string GameAreaIdField = "GameAreaId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TotalPointsField = "TotalPoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string BalancePointsField = "BalancePoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string NoteField = "Note";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTimeField = "CreateTime";
    
        /// <summary>
        /// 
        /// </summary>
        public long WId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PaymentId { get; set; }
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
        public int GameAreaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BalancePoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "WId", WId);
            output.AppendFormat(":{0}={1}", "PaymentId", PaymentId);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "GameAreaId", GameAreaId);
            output.AppendFormat(":{0}={1}", "TotalPoints", TotalPoints);
            output.AppendFormat(":{0}={1}", "BalancePoints", BalancePoints);
            output.AppendFormat(":{0}={1}", "Note", Note);
            output.AppendFormat(":{0}={1}", "CreateTime", CreateTime);
            return output.ToString();
        }
    }
}