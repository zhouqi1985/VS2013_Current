using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class M_AreaList
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIDField = "AreaID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
    
        /// <summary>
        /// 
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            return output.ToString();
        }
    }
}