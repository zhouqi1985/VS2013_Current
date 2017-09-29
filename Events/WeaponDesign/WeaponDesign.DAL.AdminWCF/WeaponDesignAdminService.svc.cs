using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeaponDesign.Database.Database;

namespace WeaponDesign.DAL.AdminWCF
{

    public class WeaponDesignAdminService : IWeaponDesignAdminService
    {

        private readonly WeaponDesign.DAL.Admin.IWeaponDesignAdmin _dal = new WeaponDesign.DAL.Admin.WeaponDesignAdmin();

        public WeaponList GetWeaponList(WeaponList searchWeaponList)
        {
            return _dal.GetWeaponList(searchWeaponList);
        
        }

        public List<WeaponUserList> GetWeaponAllUserList(ref DataPage dp, WeaponUserList weaponuserlist)
        {
            return _dal.GetWeaponAllUserList(ref dp, weaponuserlist);
        }
        public Int32 UpdateWeaponStatus(WeaponList weaponList)
        {
            return _dal.UpdateWeaponStatus(weaponList);
        }

        public Int32 AddPraiseLog(PraiseLog praiseLog)
        {
            return _dal.AddPraiseLog(praiseLog);
        }

        public List<PraiseLog> GetPraiseLogList(ref DataPage dp, PraiseLog searchPraiseLog)
        {

            return _dal.GetPraiseLogList(ref dp, searchPraiseLog);

        }

        public List<CommentsList> GetCommentsListList(ref DataPage dp, CommentsList searchCommentsList)
        {
            return _dal.GetCommentsListList(ref dp, searchCommentsList);
        }

        public int DelComment(int iD)
        {
            return _dal.DelComment(iD);
        }

        public Int32 UpdatePraiseNumber(PraiseNumber PraiseNumber)
        {
            return _dal.UpdatePraiseNumber(PraiseNumber);
        }


        public List<PraiseNumber> GetPraiseNumberList(ref DataPage dp)
        {
            return _dal.GetPraiseNumberList(ref dp);
        }
        public Int32 PraiseScheduleAdd(PraiseSchedule searchPraiseSchedule)
        {
            return _dal.PraiseScheduleAdd(searchPraiseSchedule);
        }

        public bool PraiseScheduleDel(PraiseSchedule searchPraiseSchedule)
        {
            return _dal.PraiseScheduleDel(searchPraiseSchedule);
        }

        public PraiseSchedule PraiseScheduleGetByID(PraiseSchedule searchPraiseSchedule)
        {
            return _dal.PraiseScheduleGetByID(searchPraiseSchedule);
        }

        public List<PraiseSchedule> PraiseScheduleGetList(ref DataPage dp)
        {
            return _dal.PraiseScheduleGetList(ref dp);
        }

        public Int32 PraiseScheduleUpdate(PraiseSchedule searchPraiseSchedule)
        {
            return _dal.PraiseScheduleUpdate(searchPraiseSchedule);
        }
    }

}
