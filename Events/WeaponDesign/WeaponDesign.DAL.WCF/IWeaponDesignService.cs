
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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IWeaponDesignService
    {
        [OperationContract]
        Int32 AddUserList(UserList userList);

        [OperationContract]
        Int32 AddWeaponList(WeaponList weaponList);


        [OperationContract]
        Int32 UpdateWeaponList(WeaponList weaponList);

        [OperationContract]
        Int32 UpdateWeaponStatus(WeaponList weaponList);

        [OperationContract]
        List<WeaponUserList> GetWeaponUserList(WeaponUserList weaponuserlist);

        [OperationContract]
        Int32 AddCommentsList(CommentsList commentsList);

        [OperationContract]
        List<WeaponComments> GetWeaponCommentsList(ref DataPage dp, WeaponComments searchWeaponComments);

        [OperationContract]
        Int32 AddPraiseLog(PraiseLog praiseLog);

        [OperationContract]
        WeaponList GetWeaponList(WeaponList searchWeaponList);
        [OperationContract]
        DesignEventType GetDesignEventType(DesignEventType searchDesignEventType);



    }
}