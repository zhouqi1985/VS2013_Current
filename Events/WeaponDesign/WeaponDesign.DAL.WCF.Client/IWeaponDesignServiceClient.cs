using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeaponDesign.Database.Database;

namespace WeaponDesign.DAL.WCF.Client
{
    public interface IWeaponDesignServiceClient
    {

        Int32 AddUserList(UserList userList);

        Int32 AddWeaponList(WeaponList weaponList);

        Int32 UpdateWeaponList(WeaponList weaponList);

        Int32 UpdateWeaponStatus(WeaponList weaponList);

        List<WeaponUserList> GetWeaponUserList(WeaponUserList weaponuserlist);

        Int32 AddCommentsList(CommentsList commentsList);

        List<WeaponComments> GetWeaponCommentsList(ref DataPage dp, WeaponComments searchWeaponComments);

        Int32 AddPraiseLog(PraiseLog praiseLog);

        WeaponList GetWeaponList(WeaponList searchWeaponList);
        DesignEventType GetDesignEventType(DesignEventType searchDesignEventType);

    }
}
