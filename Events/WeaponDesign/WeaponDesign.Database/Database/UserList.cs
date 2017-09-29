using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserList
    {

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
        public const string SexField = "Sex";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LoginNameField = "LoginName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
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
        public string Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            return output.ToString();
        }
    }
}