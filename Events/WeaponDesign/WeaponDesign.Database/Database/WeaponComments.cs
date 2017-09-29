using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WeaponComments
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
        public const string CommentsField = "Comments";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTSField = "CreateTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponNameField = "WeaponName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaTypeField = "WeaType";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponDescField = "WeaponDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PicAddressField = "PicAddress";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SpicAddressField = "SpicAddress";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ShowPraiseField = "ShowPraise";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LoginNameField = "LoginName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string RowIDField = "RowID";
    
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
        public string Comments { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaponName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaponDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PicAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SpicAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ShowPraise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long RowID { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ID", ID);
            output.AppendFormat(":{0}={1}", "WeaponID", WeaponID);
            output.AppendFormat(":{0}={1}", "Comments", Comments);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "WeaponName", WeaponName);
            output.AppendFormat(":{0}={1}", "WeaType", WeaType);
            output.AppendFormat(":{0}={1}", "WeaponDesc", WeaponDesc);
            output.AppendFormat(":{0}={1}", "PicAddress", PicAddress);
            output.AppendFormat(":{0}={1}", "SpicAddress", SpicAddress);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "ShowPraise", ShowPraise);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "RowID", RowID);
            return output.ToString();
        }
    }
}