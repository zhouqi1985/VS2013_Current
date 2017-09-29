using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DesignEventType
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IDField = "ID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EventTypeIDField = "EventTypeID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EventNameField = "EventName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EventDescField = "EventDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EventStartField = "EventStart";
        /// <summary>
        /// 字段
        /// </summary>
        public const string EventEndField = "EventEnd";

        /// <summary>
        /// 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EventTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EventDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EventStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EventEnd { get; set; }

        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "ID", ID);
            output.AppendFormat(":{0}={1}", "EventTypeID", EventTypeID);
            output.AppendFormat(":{0}={1}", "EventName", EventName);
            output.AppendFormat(":{0}={1}", "EventDesc", EventDesc);
            output.AppendFormat(":{0}={1}", "EventStart", EventStart);
            output.AppendFormat(":{0}={1}", "EventEnd", EventEnd);
            return output.ToString();
        }
    }
}