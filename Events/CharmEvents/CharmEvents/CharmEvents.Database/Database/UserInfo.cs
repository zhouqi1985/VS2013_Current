using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharmEvents.Database.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UserInfo
    {
        /// <summary>
        /// 字段
        /// </summary>
        public const string UserIdField = "UserId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarIdField = "AvatarId";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AvatarNameField = "AvatarName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string GameAreaField = "GameArea";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaIDField = "AreaID";
        /// <summary>
        /// 字段
        /// </summary>
        public const string AreaNameField = "AreaName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string LoginNameField = "LoginName";
        /// <summary>
        /// 字段
        /// </summary>
        public const string SexField = "Sex";
        /// <summary>
        /// 字段
        /// </summary>
        public const string ExchangeIDField = "ExchangeID";
    

        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long AvatarId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AvatarName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int GameArea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AreaID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExchangeID { get; set; }


        
        //重写ToString方法 输出对象属性列表
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            
            output.AppendFormat(":{0}={1}", "UserId", UserId);
            output.AppendFormat(":{0}={1}", "AvatarId", AvatarId);
            output.AppendFormat(":{0}={1}", "AvatarName", AvatarName);
            output.AppendFormat(":{0}={1}", "GameArea", GameArea);
            output.AppendFormat(":{0}={1}", "AreaID", AreaID);
            output.AppendFormat(":{0}={1}", "AreaName", AreaName);
            output.AppendFormat(":{0}={1}", "LoginName", LoginName);
            output.AppendFormat(":{0}={1}", "Sex", Sex);
            output.AppendFormat(":{0}={1}", "ExchangeID", ExchangeID);
            return output.ToString();
        }
    }
}