using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ResultInfo
    {


        /// <summary>
        /// 字段
        /// </summary>
        public const string ResultField = "Result";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PacketNameField = "PacketName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TotalPointsField = "TotalPoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string BalancePointsField = "BalancePoints";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeIdField = "ExchangeId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeTotalField = "ExchangeTotal";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CutOffDateField = "CutOffDate";
        /// <summary>
        /// 
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PacketName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalPoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BalancePoints { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CutOffDate { get; set; }


        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Result", Result);
            output.AppendFormat(":{0}={1}", "PacketName", PacketName);
            output.AppendFormat(":{0}={1}", "TotalPoints", TotalPoints);
            output.AppendFormat(":{0}={1}", "BalancePoints", BalancePoints);
            output.AppendFormat(":{0}={1}", "ExchangeId", ExchangeId);
            output.AppendFormat(":{0}={1}", "ExchangeTotal", ExchangeTotal);
            output.AppendFormat(":{0}={1}", "CutOffDate", CutOffDate);
            return output.ToString();
        }
    }
}