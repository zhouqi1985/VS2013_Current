using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BasicConfig
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string ConfigIdField = "ConfigId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ConfigNameField = "ConfigName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ConfigValueField = "ConfigValue";
    
        /// <summary>
        /// 
        /// </summary>
        public int ConfigId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ConfigName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ConfigValue { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ConfigId", ConfigId);
            output.AppendFormat(":{0}={1}", "ConfigName", ConfigName);
            output.AppendFormat(":{0}={1}", "ConfigValue", ConfigValue);
            return output.ToString();
        }
    }
}