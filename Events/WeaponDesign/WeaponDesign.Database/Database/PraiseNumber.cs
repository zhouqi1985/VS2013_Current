using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PraiseNumber
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IDField = "ID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string NumField = "Num";
    
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Num { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ID", ID);
            output.AppendFormat(":{0}={1}", "Num", Num);
            return output.ToString();
        }
    }
}