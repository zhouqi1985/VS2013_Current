using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PraiseSchedule
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IDField = "ID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StartTSField = "StartTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EndTSField = "EndTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusField = "Status";
        /// <summary>
        /// 字段
        /// </summary>
        public const string MinField = "Min";
        /// <summary>
        /// 字段
        /// </summary>
        public const string MaxField = "Max";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponIDField = "WeaponID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RandNumField = "RandNum";
    
        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Min { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Max { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WeaponID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RandNum { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ID", ID);
            output.AppendFormat(":{0}={1}", "StartTS", StartTS);
            output.AppendFormat(":{0}={1}", "EndTS", EndTS);
            output.AppendFormat(":{0}={1}", "Status", Status);
            output.AppendFormat(":{0}={1}", "Min", Min);
            output.AppendFormat(":{0}={1}", "Max", Max);
            output.AppendFormat(":{0}={1}", "WeaponID", WeaponID);
            output.AppendFormat(":{0}={1}", "RandNum", RandNum);
            return output.ToString();
        }
    }
}