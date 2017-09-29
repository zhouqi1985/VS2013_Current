using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserPuzzleNode
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string NodeIDField = "NodeID";
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
        public const string NodeCurrentField = "NodeCurrent";
        /// <summary>
        /// 字段
        /// </summary>
        public const string NodeTotalField = "NodeTotal";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleIDField = "PuzzleID";
    
        /// <summary>
        /// 
        /// </summary>
        public long NodeID { get; set; }
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
        public int NodeCurrent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long NodeTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleID { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "NodeID", NodeID);
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "NodeCurrent", NodeCurrent);
            output.AppendFormat(":{0}={1}", "NodeTotal", NodeTotal);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleTypeID);
            output.AppendFormat(":{0}={1}", "PuzzleID", PuzzleID);
            return output.ToString();
        }
    }
}