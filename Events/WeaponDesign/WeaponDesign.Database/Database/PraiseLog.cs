using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PraiseLog
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string PraiseIDField = "PraiseID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponIDField = "WeaponID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PraiseIPField = "PraiseIP";
        /// <summary>
        /// 字段
        /// </summary>
        public const string CreateTSField = "CreateTS";
        /// <summary>
        /// 字段
        /// </summary>
        public const string PraiseNumberField = "PraiseNumber";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SourceField = "Source";
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
        public const string UserIDField = "UserID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string WeaponIDoldField = "WeaponIDold";
        /// <summary>
        /// 
        /// </summary>
        public int PraiseID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WeaponID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PraiseIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PraiseNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Source { get; set; }
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
        public long UserID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WeaponIDold { get; set; }

        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "PraiseID", PraiseID);
            output.AppendFormat(":{0}={1}", "WeaponID", WeaponID);
            output.AppendFormat(":{0}={1}", "PraiseIP", PraiseIP);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "PraiseNumber", PraiseNumber);
            output.AppendFormat(":{0}={1}", "Source", Source);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "WeaponIDold", WeaponIDold);
            return output.ToString();
        }
    }
}