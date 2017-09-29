using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ApproveLog
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IDField = "ID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponIDField = "WeaponID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusIDField = "StatusID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ReasonField = "Reason";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTSField = "CreateTS";
    
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WeaponID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StatusID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTS { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ID", ID);
            output.AppendFormat(":{0}={1}", "WeaponID", WeaponID);
            output.AppendFormat(":{0}={1}", "StatusID", StatusID);
            output.AppendFormat(":{0}={1}", "Reason", Reason);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            return output.ToString();
        }
    }
}