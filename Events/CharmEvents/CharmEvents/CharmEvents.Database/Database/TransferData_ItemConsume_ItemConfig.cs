using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TransferData_ItemConsume_ItemConfig
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string IdField = "Id";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ItemIdField = "ItemId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ItemNameField = "ItemName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ShowNameField = "ShowName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusField = "Status";
    
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShowName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "Id", Id);
            output.AppendFormat(":{0}={1}", "ItemId", ItemId);
            output.AppendFormat(":{0}={1}", "ItemName", ItemName);
            output.AppendFormat(":{0}={1}", "ShowName", ShowName);
            output.AppendFormat(":{0}={1}", "Status", Status);
            return output.ToString();
        }
    }
}