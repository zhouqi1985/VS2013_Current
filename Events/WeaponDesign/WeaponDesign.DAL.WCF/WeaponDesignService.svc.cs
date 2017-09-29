using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeaponDesign.Database.Database;

namespace WeaponDesign.DAL.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class WeaponDesignService : IWeaponDesignService
    {
        private readonly WeaponDesign.DAL.WeaponDesignDAL _dal = new WeaponDesignDAL();



        public Int32 AddUserList(UserList userList)
        {
            return _dal.AddUserList(userList);
        }

        public Int32 AddWeaponList(WeaponList weaponList)
        {
            return _dal.AddWeaponList(weaponList);
        }

        public Int32 UpdateWeaponList(WeaponList weaponList)
        {
            return _dal.UpdateWeaponList(weaponList);
        }

        public Int32 UpdateWeaponStatus(WeaponList weaponList)
        {
            return _dal.UpdateWeaponStatus(weaponList);
        }

        public List<WeaponUserList> GetWeaponUserList(WeaponUserList weaponuserlist)
        {
            return _dal.GetWeaponUserList(weaponuserlist);
        }

        public Int32 AddCommentsList(CommentsList commentsList)
        {
            return _dal.AddCommentsList(commentsList);
        }

        public List<WeaponComments> GetWeaponCommentsList(ref DataPage dp, WeaponComments searchWeaponComments)
        {
            return _dal.GetWeaponCommentsList(ref dp, searchWeaponComments);
        }

        public Int32 AddPraiseLog(PraiseLog praiseLog)
        {
            return _dal.AddPraiseLog(praiseLog);
        }

        public WeaponList GetWeaponList(WeaponList searchWeaponList)
        {
            return _dal.GetWeaponList(searchWeaponList);
        }

        public DesignEventType GetDesignEventType(DesignEventType searchDesignEventType)
        {
            return _dal.GetDesignEventType(searchDesignEventType);
        }
    }
}