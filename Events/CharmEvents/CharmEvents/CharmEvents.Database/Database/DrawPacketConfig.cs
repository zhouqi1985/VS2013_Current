using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DrawPacketConfig
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IdField = "Id";
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
        public const string RateValueField = "RateValue";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RateBeginField = "RateBegin";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RateEndField = "RateEnd";
    
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
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
        public decimal RateValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RateBegin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RateEnd { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "PacketId", PacketId);
            output.AppendFormat(":{0}={1}", "PacketName", PacketName);
            output.AppendFormat(":{0}={1}", "PacketDesc", PacketDesc);
            output.AppendFormat(":{0}={1}", "RateValue", RateValue);
            output.AppendFormat(":{0}={1}", "RateBegin", RateBegin);
            output.AppendFormat(":{0}={1}", "RateEnd", RateEnd);
            return output.ToString();
        }
    }
}