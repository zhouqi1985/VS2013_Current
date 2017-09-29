using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ExchangePacketTypeConfig
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IdField = "Id";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeTypeIdField = "ExchangeTypeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeTypeNameField = "ExchangeTypeName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeTypeDescField = "ExchangeTypeDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AccumulatePointsField = "AccumulatePoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TypeLimitField = "TypeLimit";
    
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeTypeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeTypeDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AccumulatePoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TypeLimit { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "ExchangeTypeId", ExchangeTypeId);
            output.AppendFormat(":{0}={1}", "ExchangeTypeName", ExchangeTypeName);
            output.AppendFormat(":{0}={1}", "ExchangeTypeDesc", ExchangeTypeDesc);
            output.AppendFormat(":{0}={1}", "AccumulatePoints", AccumulatePoints);
            output.AppendFormat(":{0}={1}", "TypeLimit", TypeLimit);
            return output.ToString();
        }
    }
}