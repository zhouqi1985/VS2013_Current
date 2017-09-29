using CommonLibs.Common;
using CommonLibs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponDesign.Database.Database;



namespace WeaponDesign.DAL
{
    public class WeaponDesignDAL : CommonLibs.EnterpriseLibrary.DatabaseAccessBase
    {
        public WeaponDesignDAL()
            : base("DesignUploadDB")
        {

        }

 

        /// <summary>
        /// 增加 UserList
        /// </summary>
        /// Create By zhouqi
        /// 2015/11/26 17:27:46
        /// <param name="userList">UserList 实体</param>
        /// <returns></returns>
        public Int32 AddUserList(UserList userList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UserList_Add");
            DB.AddInParameter(cmd, UserList.UserIDField, DbType.Int64, userList.UserID);
            DB.AddInParameter(cmd, UserList.AvatarIDField, DbType.Int64, userList.AvatarID);
            DB.AddInParameter(cmd, UserList.AreaIDField, DbType.Int32, userList.AreaID);
            DB.AddInParameter(cmd, UserList.SexField, DbType.String, userList.Sex);
            DB.AddInParameter(cmd, UserList.LoginNameField, DbType.String, userList.LoginName);
            DB.AddInParameter(cmd, UserList.AvatarNameField, DbType.String, userList.AvatarName);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 增加 WeaponList
        /// </summary>
        /// Create By zhouqi
        /// 2015/11/26 18:03:53
        /// <param name="weaponList">WeaponList 实体</param>
        /// <returns></returns>
        public Int32 AddWeaponList(WeaponList weaponList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_Add");
            DB.AddParameter(cmd, WeaponList.WeaponIDField, DbType.Int32, ParameterDirection.InputOutput, WeaponList.WeaponIDField, DataRowVersion.Current, weaponList.WeaponID);
            DB.AddInParameter(cmd, WeaponList.WeaponNameField, DbType.String, weaponList.WeaponName);
            DB.AddInParameter(cmd, WeaponList.ContactMethodField, DbType.String, weaponList.ContactMethod);
            DB.AddInParameter(cmd, WeaponList.WeaTypeField, DbType.String, weaponList.WeaType);
            DB.AddInParameter(cmd, WeaponList.WeaponDescField, DbType.String, weaponList.WeaponDesc);
            DB.AddInParameter(cmd, WeaponList.TruePraiseField, DbType.Int32, weaponList.TruePraise);
            DB.AddInParameter(cmd, WeaponList.ShowPraiseField, DbType.Int32, weaponList.ShowPraise);
            DB.AddInParameter(cmd, WeaponList.PicAddressField, DbType.String, weaponList.PicAddress);
            DB.AddInParameter(cmd, WeaponList.SpicAddressField, DbType.String, weaponList.SpicAddress);
            DB.AddInParameter(cmd, WeaponList.LengthField, DbType.Int32, weaponList.Length);
            DB.AddInParameter(cmd, WeaponList.WidthField, DbType.Int32, weaponList.Width);
            DB.AddInParameter(cmd, WeaponList.SLengthField, DbType.Int32, weaponList.SLength);
            DB.AddInParameter(cmd, WeaponList.SWidthField, DbType.Int32, weaponList.SWidth);
            DB.AddInParameter(cmd, WeaponList.CreateTSField, DbType.DateTime, weaponList.CreateTS);
            DB.AddInParameter(cmd, WeaponList.UpdateTSField, DbType.DateTime, weaponList.UpdateTS);
            DB.AddInParameter(cmd, WeaponList.StatusIDField, DbType.Int32, weaponList.StatusID);
            DB.AddInParameter(cmd, WeaponList.AvatarIDField, DbType.Int64, weaponList.AvatarID);
            DB.AddInParameter(cmd, WeaponList.AreaIDField, DbType.Int32, weaponList.AreaID);
            DB.AddInParameter(cmd, WeaponList.UserIDField, DbType.Int64, weaponList.UserID);
            DB.AddInParameter(cmd, WeaponList.FirstNameField, DbType.String, weaponList.FirstName);
            DB.AddInParameter(cmd, WeaponList.GenderField, DbType.String, weaponList.Gender);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            weaponList.WeaponID = Convert.ToInt32(DB.GetParameterValue(cmd, "WeaponID"));

            return weaponList.WeaponID;
        }

        /// <summary>
        /// 更新 WeaponList
        /// </summary>
        /// Create By zhouqi
        /// 2015/11/26 18:03:57
        /// <param name="weaponList">WeaponList 实体</param>
        /// <returns></returns>
        public Int32 UpdateWeaponList(WeaponList weaponList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_Update");
            DB.AddParameter(cmd, WeaponList.WeaponIDField, DbType.Int32, ParameterDirection.InputOutput, WeaponList.WeaponIDField, DataRowVersion.Current, weaponList.WeaponID);
            DB.AddInParameter(cmd, WeaponList.WeaponNameField, DbType.String, weaponList.WeaponName);
            DB.AddInParameter(cmd, WeaponList.ContactMethodField, DbType.String, weaponList.ContactMethod);
            DB.AddInParameter(cmd, WeaponList.WeaTypeField, DbType.String, weaponList.WeaType);
            DB.AddInParameter(cmd, WeaponList.WeaponDescField, DbType.String, weaponList.WeaponDesc);
            DB.AddInParameter(cmd, WeaponList.UpdateTSField, DbType.DateTime, weaponList.UpdateTS);
            DB.AddInParameter(cmd, WeaponList.FirstNameField, DbType.String, weaponList.FirstName);
            DB.AddInParameter(cmd, WeaponList.GenderField, DbType.String, weaponList.Gender);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 更新状态 WeaponList
        /// </summary>
        /// Create By zhouqi
        /// 2015/11/26 18:03:57
        /// <param name="weaponList">WeaponList 实体</param>
        /// <returns></returns>
        public Int32 UpdateWeaponStatus(WeaponList weaponList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_UpdateStatus");
            DB.AddParameter(cmd, WeaponList.WeaponIDField, DbType.Int32, ParameterDirection.InputOutput, WeaponList.WeaponIDField, DataRowVersion.Current, weaponList.WeaponID);
            DB.AddInParameter(cmd, WeaponList.UpdateTSField, DbType.DateTime, weaponList.UpdateTS);
            DB.AddInParameter(cmd, WeaponList.StatusIDField, DbType.Int32, weaponList.StatusID);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 根据ID获取 WeaponList
        /// </summary>
        /// Create By zhouqi
        /// 2015/12/16 10:37:03
        /// <param name="weaponList">WeaponList 实体</param>
        /// <returns></returns>
        public WeaponList GetWeaponList(WeaponList searchWeaponList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_GetByWID");
            DB.AddInParameter(cmd, WeaponList.WeaponIDField, DbType.Int32, searchWeaponList.WeaponID);
            DB.AddInParameter(cmd, WeaponList.StatusIDField, DbType.Int32, searchWeaponList.StatusID);
            WeaponList weaponList = new WeaponList();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coWeaponID = dr.GetOrdinal(WeaponList.WeaponIDField);
                    int coWeaponName = dr.GetOrdinal(WeaponList.WeaponNameField);
                    int coWeaponDesc = dr.GetOrdinal(WeaponList.WeaponDescField);
                    int coContactMethod = dr.GetOrdinal(WeaponList.ContactMethodField);
                    int coTruePraise = dr.GetOrdinal(WeaponList.TruePraiseField);
                    int coShowPraise = dr.GetOrdinal(WeaponList.ShowPraiseField);
                    int coPicAddress = dr.GetOrdinal(WeaponList.PicAddressField);
                    int coSpicAddress = dr.GetOrdinal(WeaponList.SpicAddressField);
                    int coLength = dr.GetOrdinal(WeaponList.LengthField);
                    int coWidth = dr.GetOrdinal(WeaponList.WidthField);
                    int coSLength = dr.GetOrdinal(WeaponList.SLengthField);
                    int coSWidth = dr.GetOrdinal(WeaponList.SWidthField);
                    int coCreateTS = dr.GetOrdinal(WeaponList.CreateTSField);
                    int coUpdateTS = dr.GetOrdinal(WeaponList.UpdateTSField);
                    int coStatusID = dr.GetOrdinal(WeaponList.StatusIDField);
                    int coReason = dr.GetOrdinal(WeaponList.ReasonField);
                    int coWeaType = dr.GetOrdinal(WeaponList.WeaTypeField);
                    int coAvatarName = dr.GetOrdinal(WeaponList.AvatarNameField);
                    int coAreaName = dr.GetOrdinal(WeaponList.AreaNameField);
                    int coUserID = dr.GetOrdinal(WeaponList.UserIDField);
                    int coFirstName = dr.GetOrdinal(WeaponList.FirstNameField);
                    int coGender = dr.GetOrdinal(WeaponList.GenderField);

                    if (dr.Read())
                    {
                        weaponList.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        weaponList.WeaponName = dr.IsDBNull(coWeaponName) ? string.Empty : dr.GetString(coWeaponName);
                        weaponList.ContactMethod = dr.IsDBNull(coContactMethod) ? string.Empty : dr.GetString(coContactMethod);
                        weaponList.WeaponDesc = dr.IsDBNull(coWeaponDesc) ? string.Empty : dr.GetString(coWeaponDesc);
                        weaponList.TruePraise = dr.IsDBNull(coTruePraise) ? (int)0 : dr.GetInt32(coTruePraise);
                        weaponList.ShowPraise = dr.IsDBNull(coShowPraise) ? (int)0 : dr.GetInt32(coShowPraise);
                        weaponList.PicAddress = dr.IsDBNull(coPicAddress) ? string.Empty : dr.GetString(coPicAddress);
                        weaponList.SpicAddress = dr.IsDBNull(coSpicAddress) ? string.Empty : dr.GetString(coSpicAddress);
                        weaponList.Length = dr.IsDBNull(coLength) ? (int)0 : dr.GetInt32(coLength);
                        weaponList.Width = dr.IsDBNull(coWidth) ? (int)0 : dr.GetInt32(coWidth);
                        weaponList.SLength = dr.IsDBNull(coSLength) ? (int)0 : dr.GetInt32(coSLength);
                        weaponList.SWidth = dr.IsDBNull(coSWidth) ? (int)0 : dr.GetInt32(coSWidth);
                        weaponList.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        weaponList.UpdateTS = dr.IsDBNull(coUpdateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coUpdateTS);
                        weaponList.StatusID = dr.IsDBNull(coStatusID) ? (int)0 : dr.GetInt32(coStatusID);
                        weaponList.Reason = dr.IsDBNull(coReason) ? string.Empty : dr.GetString(coReason);
                        weaponList.WeaType = dr.IsDBNull(coWeaType) ? string.Empty : dr.GetString(coWeaType);
                        weaponList.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        weaponList.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        weaponList.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        weaponList.FirstName = dr.IsDBNull(coFirstName) ? string.Empty : dr.GetString(coFirstName);
                        weaponList.Gender = dr.IsDBNull(coGender) ? string.Empty : dr.GetString(coGender);
                    }
                }
            }

            return weaponList;
        }

        
        /// <summary>
        /// 获取 WeaponList 全部数据
        /// </summary>
        /// Create By zhouqi
        /// 2015/11/26 18:03:57
        /// <returns></returns>
        public List<WeaponUserList> GetWeaponUserList(WeaponUserList weaponuserlist)
        {
            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_GetAll");
            List<WeaponUserList> weaponListList = new List<WeaponUserList>();
            DB.AddInParameter(cmd, WeaponUserList.UserIDField, DbType.Int64, weaponuserlist.UserID);
            DB.AddInParameter(cmd, WeaponUserList.StatusIDField, DbType.Int32, weaponuserlist.StatusID);
            DB.AddInParameter(cmd, WeaponUserList.SortField, DbType.Int32, weaponuserlist.Sort);

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coWeaponID = dr.GetOrdinal(WeaponUserList.WeaponIDField);
                    int coWeaponName = dr.GetOrdinal(WeaponUserList.WeaponNameField);
                    int coContactMethod = dr.GetOrdinal(WeaponUserList.ContactMethodField);
                    int coWeaponDesc = dr.GetOrdinal(WeaponUserList.WeaponDescField);
                    int coShowPraise = dr.GetOrdinal(WeaponUserList.ShowPraiseField);
                    int coPicAddress = dr.GetOrdinal(WeaponUserList.PicAddressField);
                    int coSpicAddress = dr.GetOrdinal(WeaponUserList.SpicAddressField);
                    int coLength = dr.GetOrdinal(WeaponUserList.LengthField);
                    int coWidth = dr.GetOrdinal(WeaponUserList.WidthField);
                    int coSLength = dr.GetOrdinal(WeaponUserList.SLengthField);
                    int coSWidth = dr.GetOrdinal(WeaponUserList.SWidthField);
                    int coCreateTS = dr.GetOrdinal(WeaponUserList.CreateTSField);
                    int coUpdateTS = dr.GetOrdinal(WeaponUserList.UpdateTSField);
                    int coAvatarName = dr.GetOrdinal(WeaponUserList.AvatarNameField);
                    int coAreaName = dr.GetOrdinal(WeaponUserList.AreaNameField);
                    int coStatusType = dr.GetOrdinal(WeaponUserList.StatusTypeField);
                    int coUserID = dr.GetOrdinal(WeaponUserList.UserIDField);
                    int coReason = dr.GetOrdinal(WeaponUserList.ReasonField);
                    int coWeaType = dr.GetOrdinal(WeaponUserList.WeaTypeField);
                    int coLoginName = dr.GetOrdinal(WeaponUserList.LoginNameField);
                    int coTotalCom = dr.GetOrdinal(WeaponUserList.TotalComField);
                    int coFirstName = dr.GetOrdinal(WeaponUserList.FirstNameField);
                    int coGender = dr.GetOrdinal(WeaponUserList.GenderField);
                    while (dr.Read())
                    {
                        WeaponUserList weaponuserList = new WeaponUserList();
                        weaponuserList.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        weaponuserList.WeaponName = dr.IsDBNull(coWeaponName) ? string.Empty : dr.GetString(coWeaponName);
                        weaponuserList.ContactMethod = dr.IsDBNull(coContactMethod) ? string.Empty : dr.GetString(coContactMethod);
                        weaponuserList.WeaponDesc = dr.IsDBNull(coWeaponDesc) ? string.Empty : dr.GetString(coWeaponDesc);
                        weaponuserList.ShowPraise = dr.IsDBNull(coShowPraise) ? (int)0 : dr.GetInt32(coShowPraise);
                        weaponuserList.PicAddress = dr.IsDBNull(coPicAddress) ? string.Empty : dr.GetString(coPicAddress);
                        weaponuserList.SpicAddress = dr.IsDBNull(coSpicAddress) ? string.Empty :  dr.GetString(coSpicAddress);
                        weaponuserList.Length = dr.IsDBNull(coLength) ? (int)0 : dr.GetInt32(coLength);
                        weaponuserList.Width = dr.IsDBNull(coWidth) ? (int)0 : dr.GetInt32(coWidth);
                        weaponuserList.SLength = dr.IsDBNull(coSLength) ? (int)0 : dr.GetInt32(coSLength);
                        weaponuserList.SWidth = dr.IsDBNull(coSWidth) ? (int)0 : dr.GetInt32(coSWidth);
                        weaponuserList.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        weaponuserList.UpdateTS = dr.IsDBNull(coUpdateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coUpdateTS);
                        weaponuserList.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        weaponuserList.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        weaponuserList.StatusType = dr.IsDBNull(coStatusType) ? string.Empty : dr.GetString(coStatusType);
                        weaponuserList.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        weaponuserList.Reason = dr.IsDBNull(coReason) ? string.Empty : dr.GetString(coReason);
                        weaponuserList.WeaType = dr.IsDBNull(coWeaType) ? string.Empty : dr.GetString(coWeaType);
                        weaponuserList.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        weaponuserList.TotalCom = dr.IsDBNull(coTotalCom) ? (int)0 : dr.GetInt32(coTotalCom);
                        weaponuserList.FirstName = dr.IsDBNull(coFirstName) ? string.Empty : dr.GetString(coFirstName);
                        weaponuserList.Gender = dr.IsDBNull(coGender) ? string.Empty : dr.GetString(coGender);
                        weaponListList.Add(weaponuserList);
                    }
                }
            }

            return weaponListList;
        }
  

        /// <summary>
        /// 增加 CommentsList
        /// </summary>
        /// Create By zhouqi
        /// 2015/12/2 11:03:06
        /// <param name="commentsList">CommentsList 实体</param>
        /// <returns></returns>
        public Int32 AddCommentsList(CommentsList commentsList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("CommentsList_Add");
            DB.AddParameter(cmd, CommentsList.IDField, DbType.Int32, ParameterDirection.InputOutput, CommentsList.IDField, DataRowVersion.Current, commentsList.ID);
            DB.AddInParameter(cmd, CommentsList.WeaponIDField, DbType.Int32, commentsList.WeaponID);
            DB.AddInParameter(cmd, CommentsList.CommentsField, DbType.String, commentsList.Comments);
            DB.AddInParameter(cmd, CommentsList.CreateTSField, DbType.DateTime, commentsList.CreateTS);
            //DB.AddInParameter(cmd, CommentsList.UserIDField, DbType.Int32, commentsList.UserID);
            DB.AddInParameter(cmd, CommentsList.AvatarIDField, DbType.Int64, commentsList.AvatarID);
            DB.AddInParameter(cmd, CommentsList.AreaIDField, DbType.Int32, commentsList.AreaID);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

        /// <summary>
        /// 获取 CommentsList 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2015/12/2 11:03:07
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchCommentsList">CommentsList 查询实体</param>
        /// <returns></returns>
        public List<WeaponComments> GetWeaponCommentsList(ref DataPage dp, WeaponComments searchWeaponComments)
        {
            //string websitepath = AppSetting.GetString("WebsitePath");
            DbCommand cmd = DB.GetStoredProcCommand("WeaponComments_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);
            DB.AddInParameter(cmd, WeaponList.WeaponIDField, DbType.Int32, searchWeaponComments.WeaponID);

            List<WeaponComments> WeaponCommentsList = new List<WeaponComments>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coID = dr.GetOrdinal(WeaponComments.IDField);
                    int coWeaponID = dr.GetOrdinal(WeaponComments.WeaponIDField);
                    int coComments = dr.GetOrdinal(WeaponComments.CommentsField);
                    int coCreateTS = dr.GetOrdinal(WeaponComments.CreateTSField);
                    int coWeaponName = dr.GetOrdinal(WeaponComments.WeaponNameField);
                    int coWeaponDesc = dr.GetOrdinal(WeaponComments.WeaponDescField);
                    int coShowPraise = dr.GetOrdinal(WeaponComments.ShowPraiseField);
                    int coPicAddress = dr.GetOrdinal(WeaponComments.PicAddressField);
                    int coSpicAddress = dr.GetOrdinal(WeaponComments.SpicAddressField);
                    int coAvatarName = dr.GetOrdinal(WeaponComments.AvatarNameField);
                    int coLoginName = dr.GetOrdinal(WeaponComments.LoginNameField);
                    int coAreaName = dr.GetOrdinal(WeaponComments.AreaNameField);
                    int coWeaType = dr.GetOrdinal(WeaponComments.WeaTypeField);
                    int coRowID = dr.GetOrdinal(WeaponComments.RowIDField);
                    while (dr.Read())
                    {
                        WeaponComments weaponComments = new WeaponComments();

                        weaponComments.ID = dr.IsDBNull(coID) ? (int)0 : dr.GetInt32(coID);
                        weaponComments.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        weaponComments.Comments = dr.IsDBNull(coComments) ? string.Empty : dr.GetString(coComments);
                        weaponComments.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        weaponComments.WeaponName = dr.IsDBNull(coWeaponName) ? string.Empty : dr.GetString(coWeaponName);
                        weaponComments.WeaponDesc = dr.IsDBNull(coWeaponDesc) ? string.Empty : dr.GetString(coWeaponDesc);
                        weaponComments.ShowPraise = dr.IsDBNull(coShowPraise) ? (int)0 : dr.GetInt32(coShowPraise);
                        weaponComments.PicAddress = dr.IsDBNull(coPicAddress) ? string.Empty : dr.GetString(coPicAddress);
                        weaponComments.SpicAddress = dr.IsDBNull(coSpicAddress) ? string.Empty :  dr.GetString(coSpicAddress);
                        weaponComments.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        weaponComments.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        weaponComments.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        weaponComments.WeaType = dr.IsDBNull(coWeaType) ? string.Empty : dr.GetString(coWeaType);
                        weaponComments.RowID = dr.IsDBNull(coRowID) ? (long)0 : dr.GetInt64(coRowID);
                        WeaponCommentsList.Add(weaponComments);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return WeaponCommentsList;
        }


        ///// <summary>
        ///// 每人每活动一票，可换作品
        ///// </summary>
        ///// Create By zhouqi
        ///// 2015/12/3 17:17:27
        ///// <param name="praiseLog">PraiseLog 实体</param>
        ///// <returns></returns>
        //public Int32 ChangePraiseLog(PraiseLog praiseLog)
        //{
        //    DbCommand cmd = DB.GetStoredProcCommand("PraiseLog_Change");
        //    DB.AddParameter(cmd, PraiseLog.WeaponIDoldField, DbType.Int32, ParameterDirection.InputOutput, PraiseLog.WeaponIDoldField, DataRowVersion.Current, praiseLog.WeaponIDold);
        //    DB.AddInParameter(cmd, PraiseLog.WeaponIDField, DbType.Int32, praiseLog.WeaponID);
        //    DB.AddInParameter(cmd, PraiseLog.PraiseIPField, DbType.String, praiseLog.PraiseIP);
        //    DB.AddInParameter(cmd, PraiseLog.PraiseNumberField, DbType.Int32, praiseLog.PraiseNumber);
        //    DB.AddInParameter(cmd, PraiseLog.SourceField, DbType.Int32, praiseLog.Source);
        //    DB.AddInParameter(cmd, PraiseLog.AvatarIDField, DbType.Int64, praiseLog.AvatarID);
        //    DB.AddInParameter(cmd, PraiseLog.AreaIDField, DbType.Int32, praiseLog.AreaID);
        //    DB.AddInParameter(cmd, PraiseLog.UserIDField, DbType.Int64, praiseLog.UserID);
        //    //增加返回参数
        //    DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
        //        string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

        //    DB.ExecuteNonQuery(cmd);

        //    Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, "WeaponIDold"));

        //    return rs;
        //}

        /// <summary>
        /// 每人每天一票，只增不减
        /// </summary>
        /// Create By zhouqi
        /// 2015/12/3 17:17:27
        /// <param name="praiseLog">PraiseLog 实体</param>
        /// <returns></returns>
        public Int32 AddPraiseLog(PraiseLog praiseLog)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseLog_Add");
            DB.AddParameter(cmd, PraiseLog.PraiseIDField, DbType.Int32, ParameterDirection.InputOutput, PraiseLog.PraiseIDField, DataRowVersion.Current, praiseLog.PraiseID);
            DB.AddInParameter(cmd, PraiseLog.WeaponIDField, DbType.Int32, praiseLog.WeaponID);
            DB.AddInParameter(cmd, PraiseLog.PraiseIPField, DbType.String, praiseLog.PraiseIP);
            DB.AddInParameter(cmd, PraiseLog.CreateTSField, DbType.DateTime, praiseLog.CreateTS);
            DB.AddInParameter(cmd, PraiseLog.PraiseNumberField, DbType.Int32, praiseLog.PraiseNumber);
            DB.AddInParameter(cmd, PraiseLog.SourceField, DbType.Int32, praiseLog.Source);
            DB.AddInParameter(cmd, PraiseLog.AvatarIDField, DbType.Int64, praiseLog.AvatarID);
            DB.AddInParameter(cmd, PraiseLog.AreaIDField, DbType.Int32, praiseLog.AreaID);
            DB.AddInParameter(cmd, PraiseLog.UserIDField, DbType.Int64, praiseLog.UserID);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 根据ID获取 DesignEventType
        /// </summary>
        /// Create By zhouqi
        /// 2017/5/2 18:15:41
        /// <param name="designEventType">DesignEventType 实体</param>
        /// <returns></returns>
        public DesignEventType GetDesignEventType(DesignEventType searchDesignEventType)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DesignEventType_GetByTypeID");
            DB.AddInParameter(cmd, DesignEventType.EventTypeIDField, DbType.Int32, searchDesignEventType.EventTypeID);

            DesignEventType designEventType = new DesignEventType();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coID = dr.GetOrdinal(DesignEventType.IDField);
                    int coEventTypeID = dr.GetOrdinal(DesignEventType.EventTypeIDField);
                    int coEventName = dr.GetOrdinal(DesignEventType.EventNameField);
                    int coEventDesc = dr.GetOrdinal(DesignEventType.EventDescField);
                    int coEventStart = dr.GetOrdinal(DesignEventType.EventStartField);
                    int coEventEnd = dr.GetOrdinal(DesignEventType.EventEndField);

                    if (dr.Read())
                    {
                        designEventType.ID = dr.GetInt32(coID);
                        designEventType.EventTypeID = dr.GetInt32(coEventTypeID);
                        designEventType.EventName = dr.GetString(coEventName);
                        designEventType.EventDesc = dr.IsDBNull(coEventDesc) ? string.Empty : dr.GetString(coEventDesc);
                        designEventType.EventStart = dr.GetDateTime(coEventStart);
                        designEventType.EventEnd = dr.GetDateTime(coEventEnd);
                    }
                }
            }

            return designEventType;
        }

   



    }
}
