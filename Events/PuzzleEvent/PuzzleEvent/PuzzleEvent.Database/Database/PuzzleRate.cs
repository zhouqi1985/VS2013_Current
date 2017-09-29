using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PuzzleRate
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIdField = "PuzzleTypeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePiecesCountField = "PuzzlePiecesCount";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleRateTypeIDField = "PuzzleRateTypeID";
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
        /// 
        /// </summary>
        public int PuzzleTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePiecesCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleRateTypeID { get; set; }
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
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "PuzzleTypeId", PuzzleTypeId);
            output.AppendFormat(":{0}={1}", "PuzzlePiecesCount", PuzzlePiecesCount);
            output.AppendFormat(":{0}={1}", "PuzzleRateTypeID", PuzzleRateTypeID);
            output.AppendFormat(":{0}={1}", "Rate", Rate);
            output.AppendFormat(":{0}={1}", "RateBegin", RateBegin);
            output.AppendFormat(":{0}={1}", "RateEnd", RateEnd);
            return output.ToString();
        }
    }
}