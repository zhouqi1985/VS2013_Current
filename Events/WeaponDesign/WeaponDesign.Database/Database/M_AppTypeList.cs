using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class M_AppTypeList
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusIDField = "StatusID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusTypeField = "StatusType";
    
        /// <summary>
        /// 
        /// </summary>
        public int StatusID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusType { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "StatusID", StatusID);
            output.AppendFormat(":{0}={1}", "StatusType", StatusType);
            return output.ToString();
        }
    }
}