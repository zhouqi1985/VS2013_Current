using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeaponDesign.Database.Database;

namespace WeaponDesign.DAL.AdminWCF.Client
{
    public interface IWeaponDesignAdminServiceClient
    {

        WeaponList GetWeaponList(WeaponList searchWeaponList);
        List<WeaponUserList> GetWeaponAllUserList(ref DataPage dp, WeaponUserList weaponuserlist);

        Int32 UpdateWeaponStatus(WeaponList weaponList);

        Int32 AddPraiseLog(PraiseLog praiseLog);

        List<PraiseLog> GetPraiseLogList(ref DataPage dp, PraiseLog searchPraiseLog);

        Int32 DelComment(Int32 iD);
        Int32 UpdatePraiseNumber(PraiseNumber praiseNumber);
        List<PraiseNumber> GetPraiseNumberList(ref DataPage dp);
        Int32 PraiseScheduleAdd(PraiseSchedule searchPraiseSchedule);


        bool PraiseScheduleDel(PraiseSchedule searchPraiseSchedule);


        PraiseSchedule PraiseScheduleGetByID(PraiseSchedule searchPraiseSchedule);


        List<PraiseSchedule> PraiseScheduleGetList(ref DataPage dp);


        Int32 PraiseScheduleUpdate(PraiseSchedule searchPraiseSchedule);

    }
}
