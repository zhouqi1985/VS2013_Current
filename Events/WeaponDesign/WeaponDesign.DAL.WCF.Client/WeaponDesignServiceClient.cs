using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeaponDesign.DAL.WCF;
using WeaponDesign.Database.Database;
using LogBLLV2;

namespace WeaponDesign.DAL.WCF.Client
{
    public class WeaponDesignServiceClient : IWeaponDesignServiceClient
    {
        private WeaponDesignService.WeaponDesignServiceClient _client;

        public int AddUserList(UserList userList)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            try
            {

                int rs = _client.AddUserList(userList);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "AddUserList 添加用户失败");
                return 0;
            }
        }

        public int AddWeaponList(WeaponList weaponList)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            try
            {

                int rs = _client.AddWeaponList(weaponList);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "AddWeaponList 添加武器失败");
                return 0;
            }
        }

        public WeaponList GetWeaponList(WeaponList searchWeaponList)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            WeaponList list = new WeaponList();
            try
            {
                list = _client.GetWeaponList(searchWeaponList);
                _client.Close();
                return list;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "GetWeaponList 获取武器信息失败");
                return list;
            }
        }



        public int UpdateWeaponList(WeaponList weaponList)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            try
            {
                int rs = _client.UpdateWeaponList(weaponList);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "UpdateWeaponList 更新武器失败");
                return 0;
            }
        }

        public int UpdateWeaponStatus(WeaponList weaponList)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            try
            {

                int rs = _client.UpdateWeaponStatus(weaponList);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "UpdateWeaponStatus 删除武器失败");
                return 0;
            }
        }

        public List<WeaponUserList> GetWeaponUserList(WeaponUserList weaponuserlist)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            List<WeaponUserList> lists = new List<WeaponUserList>();
            try
            {
                lists = _client.GetWeaponUserList(weaponuserlist);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "GetWeaponUserList 获取指定用户的武器失败");
                return lists;
            }
        }

        public int AddCommentsList(CommentsList commentsList)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            try
            {

                int rs = _client.AddCommentsList(commentsList);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "AddCommentsList 添加评论失败");
                return 0;
            }
        }

        public List<WeaponComments> GetWeaponCommentsList(ref CommonLibs.Common.DataPage dp, WeaponComments searchWeaponComments)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            List<WeaponComments> lists = new List<WeaponComments>();
            try
            {
                lists = _client.GetWeaponCommentsList(ref dp, searchWeaponComments);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "GetWeaponCommentsList 获取评论失败");
                return lists;
            }
        }

        public int AddPraiseLog(PraiseLog praiseLog)
        {
            _client = new WeaponDesignService.WeaponDesignServiceClient();
            try
            {

                int rs = _client.AddPraiseLog(praiseLog);
                _client.Close();
                return rs;
            }
            catch (Exception ex)
            {

                _client.CloseCatch(ex, "AddPraiseLog 点赞失败");
                return 0;
            }
        }

        public DesignEventType GetDesignEventType(DesignEventType searchDesignEventType)
        {

            _client = new WeaponDesignService.WeaponDesignServiceClient();
            DesignEventType lists = new DesignEventType();
            try
            {
                lists = _client.GetDesignEventType(searchDesignEventType);
                _client.Close();
                return lists;
            }
            catch (Exception ex)
            {
                _client.CloseCatch(ex, "GetDesignEventType Failed");
                return lists;

            }
        }
    }
}
