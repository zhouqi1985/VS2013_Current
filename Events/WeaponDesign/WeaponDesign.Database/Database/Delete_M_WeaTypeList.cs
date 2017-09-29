using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class M_WeaTypeList
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaTypeIDField = "WeaTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaTypeField = "WeaType";
    
        /// <summary>
        /// 
        /// </summary>
        public int WeaTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaType { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "WeaTypeID", WeaTypeID);
            output.AppendFormat(":{0}={1}", "WeaType", WeaType);
            return output.ToString();
        }
    }
}