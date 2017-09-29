using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleEvent.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PuzzlePieces
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePieceIdField = "PuzzlePieceId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePieceNameField = "PuzzlePieceName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzlePieceDescField = "PuzzlePieceDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleIDField = "PuzzleID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleNameField = "PuzzleName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PieceOrderField = "PieceOrder";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeIDField = "PuzzleTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PuzzleTypeNameField = "PuzzleTypeName";
    
        /// <summary>
        /// 
        /// </summary>
        public int PuzzlePieceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzlePieceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzlePieceDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PuzzleTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PuzzleTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PieceOrder { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "PuzzlePieceId", PuzzlePieceId);
            output.AppendFormat(":{0}={1}", "PuzzlePieceName", PuzzlePieceName);
            output.AppendFormat(":{0}={1}", "PuzzlePieceDesc", PuzzlePieceDesc);
            output.AppendFormat(":{0}={1}", "PuzzleID", PuzzleID);
            output.AppendFormat(":{0}={1}", "PuzzleName", PuzzleName);
            output.AppendFormat(":{0}={1}", "PuzzleTypeID", PuzzleID);
            output.AppendFormat(":{0}={1}", "PuzzleTypeName", PuzzleName);
            output.AppendFormat(":{0}={1}", "PieceOrder", PieceOrder);
            return output.ToString();
        }
    }
}