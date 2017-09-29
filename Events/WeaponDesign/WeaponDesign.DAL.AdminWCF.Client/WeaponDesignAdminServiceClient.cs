using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeaponDesign.Database.Database;
using LogBLLV2;
using CommonLibs.Common;

namespace WeaponDesign.DAL.AdminWCF.Client
{
    public class WeaponDesignAdminServiceClient : IWeaponDesignAdminServiceClient
    {
        private WeaponDesignAdminService.WeaponDesignAdminServiceClient _admin;

        public Int32 DelComment(int iD)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            try
            {
                int rs = _admin.DelComment(iD);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "DelComment 删除评论失败");
                return 0;
            }
        }

        public WeaponList GetWeaponList(WeaponList searchWeaponList)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            WeaponList list = new WeaponList();
            try
            {
                list = _admin.GetWeaponList(searchWeaponList);
                _admin.Close();
                return list;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetWeaponList 获取武器信息失败");
                return list;
            }
        }
        public List<WeaponUserList> GetWeaponAllUserList(ref DataPage dp, WeaponUserList weaponuserlist)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            List<WeaponUserList> lists = new List<WeaponUserList>();
            try
            {
                lists = _admin.GetWeaponAllUserList(ref dp, weaponuserlist);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetWeaponUserList 获取武器信息失败");
                return lists;
            }
        }


        public Int32 UpdateWeaponStatus(WeaponList weaponList)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            try
            {

                int rs = _admin.UpdateWeaponStatus(weaponList);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "UpdateWeaponStatus 更新武器状态失败");
                return 0;
            }
        }

        public int AddPraiseLog(PraiseLog praiseLog)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            try
            {

                int rs = _admin.AddPraiseLog(praiseLog);
                _admin.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "AddPraiseLog 增加赞数失败");
                return 0;
            }
        }

        public List<PraiseLog> GetPraiseLogList(ref DataPage dp, PraiseLog searchPraiseLog)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            List<PraiseLog> lists = new List<PraiseLog>();
            try
            {
                lists = _admin.GetPraiseLogList(ref dp, searchPraiseLog);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetPraiseLogList 获取点赞失败");
                return lists;
            }
        }

        public List<CommentsList> GetCommentsListList(ref DataPage dp, CommentsList searchCommentsList)
        {
            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            List<CommentsList> lists = new List<CommentsList>();
            try
            {
                lists = _admin.GetCommentsListList(ref dp, searchCommentsList);
                _admin.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _admin.CloseCatch(ex, "GetCommentsListList 获取评论失败");
                return lists;
            }

        }

        public Int32 UpdatePraiseNumber(PraiseNumber searchPraiseNumber)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.UpdatePraiseNumber(searchPraiseNumber);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "UpdatePraiseNumber failed");
                return result;
            }
        }
        public List<PraiseNumber> GetPraiseNumberList(ref DataPage dp)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            List<PraiseNumber> result = new List<PraiseNumber>();

            try
            {
                result = _admin.GetPraiseNumberList(ref dp);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "GetPraiseNumberList failed");
                return result;
            }
        }

        public Int32 PraiseScheduleAdd(PraiseSchedule searchPraiseSchedule)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.PraiseScheduleAdd(searchPraiseSchedule);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "PraiseScheduleAdd failed");
                return result;
            }
        }
        public bool PraiseScheduleDel(PraiseSchedule searchPraiseSchedule)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            bool result = false;

            try
            {
                result = _admin.PraiseScheduleDel(searchPraiseSchedule);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "PraiseScheduleDel failed");
                return result;
            }
        }
        public PraiseSchedule PraiseScheduleGetByID(PraiseSchedule searchPraiseSchedule)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            PraiseSchedule result = new PraiseSchedule();

            try
            {
                result = _admin.PraiseScheduleGetByID(searchPraiseSchedule);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "PraiseScheduleGetByID failed");
                return result;
            }
        }
        public List<PraiseSchedule> PraiseScheduleGetList(ref DataPage dp)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            List<PraiseSchedule> result = new List<PraiseSchedule>();

            try
            {
                result = _admin.PraiseScheduleGetList(ref dp);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "PraiseScheduleGetList failed");
                return result;
            }
        }
        public Int32 PraiseScheduleUpdate(PraiseSchedule searchPraiseSchedule)
        {

            _admin = new WeaponDesignAdminService.WeaponDesignAdminServiceClient();
            Int32 result = 0;

            try
            {
                result = _admin.PraiseScheduleUpdate(searchPraiseSchedule);
                _admin.Close();
                return result;
            }
            catch (Exception ex)
            {
                _admin.CloseCatch(ex, "PraiseScheduleUpdate failed");
                return result;
            }
        }
    }
}
