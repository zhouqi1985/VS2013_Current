using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeaponDesign.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CommentsList
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
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LoginNameField = "LoginName";
    
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
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "ID", ID);
            output.AppendFormat(":{0}={1}", "WeaponID", WeaponID);
            output.AppendFormat(":{0}={1}", "Comments", Comments);
            output.AppendFormat(":{0}={1}", "CreateTS", CreateTS);
            output.AppendFormat(":{0}={1}", "UserID", UserID);
            output.AppendFormat(":{0}={1}", "AvatarID", AvatarID);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            return output.ToString();
        }
    }
}