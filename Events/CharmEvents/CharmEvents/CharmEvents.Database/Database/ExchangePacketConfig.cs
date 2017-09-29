using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ExchangePacketConfig
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IdField = "Id";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeIdField = "ExchangeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketIdField = "PacketId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketNameField = "PacketName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketDescField = "PacketDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeLimitField = "ExchangeLimit";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangePointsField = "ExchangePoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeTypeIdField = "ExchangeTypeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketCountField = "PacketCount";
    
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long PacketId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PacketName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PacketDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangePoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PacketCount { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "ExchangeId", ExchangeId);
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "PacketName", PacketName);
            output.AppendFormat(":{0}={1}", "PacketDesc", PacketDesc);
            output.AppendFormat(":{0}={1}", "ExchangeLimit", ExchangeLimit);
            output.AppendFormat(":{0}={1}", "ExchangePoints", ExchangePoints);
            output.AppendFormat(":{0}={1}", "ExchangeTypeId", ExchangeTypeId);
            output.AppendFormat(":{0}={1}", "PacketCount", PacketCount);
            return output.ToString();
        }
    }
}