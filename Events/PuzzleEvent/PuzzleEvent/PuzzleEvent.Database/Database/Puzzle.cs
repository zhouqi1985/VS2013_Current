using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Puzzle
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleIdField = "PuzzleId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleNameField = "PuzzleName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleDescField = "PuzzleDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleNodeField = "PuzzleNode";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePacketTypeIDField = "PuzzlePacketTypeID";
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
        public const string PacketIDField = "PacketID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string NodeTypeField = "NodeType";
    
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzleDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleNode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePacketTypeID { get; set; }
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
        public int PacketID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NodeType { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "PuzzleId", PuzzleId);
            output.AppendFormat(":{0}={1}", "PuzzleName", PuzzleName);
            output.AppendFormat(":{0}={1}", "PuzzleDesc", PuzzleDesc);
            output.AppendFormat(":{0}={1}", "PuzzleNode", PuzzleNode);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleTypeID);
            output.AppendFormat(":{0}={1}", "PuzzlePacketTypeID", PuzzlePacketTypeID);
            output.AppendFormat(":{0}={1}", "RateBegin", RateBegin);
            output.AppendFormat(":{0}={1}", "RateEnd", RateEnd);
            output.AppendFormat(":{0}={1}", "PacketID", PacketID);
            output.AppendFormat(":{0}={1}", "NodeType", NodeType);
            return output.ToString();
        }
    }
}