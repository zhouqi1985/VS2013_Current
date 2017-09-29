using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PuzzlePacket
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePacketIdField = "PuzzlePacketId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePacketNameField = "PuzzlePacketName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePacketDescField = "PuzzlePacketDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePacketTypeIDField = "PuzzlePacketTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RateField = "Rate";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RateBeginField = "RateBegin";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RateEndField = "RateEnd";
        /// <summary>
        /// 字段
        /// </summary>
        public const string IsNoticeField = "IsNotice";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleIDField = "PuzzleID";
    
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePacketId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzlePacketName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzlePacketDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePacketTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RateBegin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RateEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNotice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleID { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "PuzzlePacketId", PuzzlePacketId);
            output.AppendFormat(":{0}={1}", "PuzzlePacketName", PuzzlePacketName);
            output.AppendFormat(":{0}={1}", "PuzzlePacketDesc", PuzzlePacketDesc);
            output.AppendFormat(":{0}={1}", "PuzzlePacketTypeID", PuzzlePacketTypeID);
            output.AppendFormat(":{0}={1}", "Rate", Rate);
            output.AppendFormat(":{0}={1}", "RateBegin", RateBegin);
            output.AppendFormat(":{0}={1}", "RateEnd", RateEnd);
            output.AppendFormat(":{0}={1}", "IsNotice", IsNotice);
            output.AppendFormat(":{0}={1}", "PuzzleID", PuzzleID);
            return output.ToString();
        }
    }
}