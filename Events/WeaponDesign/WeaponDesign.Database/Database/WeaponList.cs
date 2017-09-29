using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WeaponList
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponIDField = "WeaponID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponNameField = "WeaponName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ContactMethodField = "ContactMethod";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponDescField = "WeaponDesc";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TruePraiseField = "TruePraise";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ShowPraiseField = "ShowPraise";
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
        public const string LengthField = "Length";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WidthField = "Width";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SLengthField = "SLength";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SWidthField = "SWidth";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTSField = "CreateTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string UpdateTSField = "UpdateTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string StatusIDField = "StatusID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIDField = "UserID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarIDField = "AvatarID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIDField = "AreaID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ReasonField = "Reason";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaTypeField = "WeaType";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string TotalComField = "TotalCom";
        /// <summary>
        /// 字段
        /// </summary>
        public const string FirstNameField = "FirstName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GenderField = "Gender";
        /// <summary>
        /// 
        /// </summary>
        public int WeaponID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaponName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaponDesc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TruePraise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ShowPraise { get; set; }
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
        public int Length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public int StatusID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AvatarID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WeaType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long TotalCom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Gender { get; set; }

        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "WeaponID", WeaponID);
            output.AppendFormat(":{0}={1}", "WeaponName", WeaponName);
            output.AppendFormat(":{0}={1}", "WeaponDesc", WeaponDesc);
            output.AppendFormat(":{0}={1}", "ContactMethod", ContactMethod);
            output.AppendFormat(":{0}={1}", "TruePraise", TruePraise);
            output.AppendFormat(":{0}={1}", "ShowPraise", ShowPraise);
            output.AppendFormat(":{0}={1}", "PicAddress", PicAddress);
            output.AppendFormat(":{0}={1}", "SpicAddress", SpicAddress);
            output.AppendFormat(":{0}={1}", "Length", Length);
            output.AppendFormat(":{0}={1}", "Width", Width);
            output.AppendFormat(":{0}={1}", "SLength", SLength);
            output.AppendFormat(":{0}={1}", "SWidth", SWidth);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "UpdateTS", UpdateTS);
            output.AppendFormat(":{0}={1}", "StatusID", StatusID);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "Reason", Reason);
            output.AppendFormat(":{0}={1}", "WeaType", WeaType);
            output.AppendFormat(":{0}={1}", "AreaName", AvatarName);
            output.AppendFormat(":{0}={1}", "TotalCom", TotalCom);
            output.AppendFormat(":{0}={1}", "FirstName", FirstName);
            output.AppendFormat(":{0}={1}", "Gender", Gender);
            return output.ToString();
        }
    }
}