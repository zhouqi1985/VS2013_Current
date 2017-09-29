using CommonLibs.Common;
using CommonLibs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using WeaponDesign.Database.Database;

namespace WeaponDesign.DAL.Admin
{
    public class WeaponDesignAdmin : CommonLibs.EnterpriseLibrary.DatabaseAccessBase, IWeaponDesignAdmin
    {
        public WeaponDesignAdmin()
            : base("DesignUploadDB")
        { }

        public Int32 DelComment(Int32 iD)
        {
            DbCommand cmd = DB.GetStoredProcCommand("CommentsList_Del");
            DB.AddInParameter(cmd, CommentsList.IDField, DbType.Int32, iD);

            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //注意：
            //增加方法 如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1
            //更新方法 如果更新成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1
            //删除方法 如果删除成功，返回ID，如果失败，返回0
            int rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

        /// <summary>
        /// 根据ID获取 WeaponList
        /// </summary>
        /// Create By zhouqi
        /// 2015/11/26 18:03:57
        /// <param name="weaponList">WeaponList 实体</param>
        /// <returns></returns>
        public WeaponList GetWeaponList(WeaponList searchWeaponList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_GetByWeaponID");
            DB.AddInParameter(cmd, WeaponList.WeaponIDField, DbType.Int32, searchWeaponList.WeaponID);

            WeaponList weaponList = new WeaponList();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coWeaponID = dr.GetOrdinal(WeaponList.WeaponIDField);
                    int coWeaponName = dr.GetOrdinal(WeaponList.WeaponNameField);
                    int coContactMethod = dr.GetOrdinal(WeaponList.ContactMethodField);
                    int coWeaponDesc = dr.GetOrdinal(WeaponList.WeaponDescField);
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
        public List<WeaponUserList> GetWeaponAllUserList(ref DataPage dp, WeaponUserList weaponuserlist)
        {

            DbCommand cmd = DB.GetStoredProcCommand("WeaponList_GetAllUsers");
            string websitepath = AppSetting.GetString("WebsitePath");
            List<WeaponUserList> weaponListList = new List<WeaponUserList>();
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);
            DB.AddInParameter(cmd, WeaponUserList.AreaIDField, DbType.Int32, weaponuserlist.AreaID);
            DB.AddInParameter(cmd, WeaponUserList.StatusIDField, DbType.Int32, weaponuserlist.StatusID);
            DB.AddInParameter(cmd, WeaponUserList.UserIDField, DbType.Int64, weaponuserlist.UserID);
            DB.AddInParameter(cmd, WeaponUserList.WeaponNameField, DbType.String, weaponuserlist.WeaponName);
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
                    int coStatusID = dr.GetOrdinal(WeaponUserList.StatusIDField);
                    int coAvatarName = dr.GetOrdinal(WeaponUserList.AvatarNameField);
                    int coAreaName = dr.GetOrdinal(WeaponUserList.AreaNameField);
                    int coStatusType = dr.GetOrdinal(WeaponUserList.StatusTypeField);
                    int coUserID = dr.GetOrdinal(WeaponUserList.UserIDField);
                    int coReason = dr.GetOrdinal(WeaponUserList.ReasonField);
                    int coWeaType = dr.GetOrdinal(WeaponUserList.WeaTypeField);
                    int coAreaID = dr.GetOrdinal(WeaponUserList.AreaIDField);
                    int coLoginName = dr.GetOrdinal(WeaponUserList.LoginNameField);
                    int coFistName = dr.GetOrdinal(WeaponUserList.FirstNameField);
                    int coGender = dr.GetOrdinal(WeaponUserList.GenderField);
                    while (dr.Read())
                    {
                        WeaponUserList weaponuserList = new WeaponUserList();
                        weaponuserList.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        weaponuserList.WeaponName = dr.IsDBNull(coWeaponName) ? string.Empty : dr.GetString(coWeaponName);
                        weaponuserList.ContactMethod = dr.IsDBNull(coContactMethod) ? string.Empty : dr.GetString(coContactMethod);
                        weaponuserList.WeaponDesc = dr.IsDBNull(coWeaponDesc) ? string.Empty : dr.GetString(coWeaponDesc);
                        weaponuserList.ShowPraise = dr.IsDBNull(coShowPraise) ? (int)0 : dr.GetInt32(coShowPraise);
                        weaponuserList.PicAddress = dr.IsDBNull(coPicAddress) ? string.Empty : (websitepath + dr.GetString(coPicAddress));
                        weaponuserList.SpicAddress = dr.IsDBNull(coSpicAddress) ? string.Empty : (websitepath + dr.GetString(coSpicAddress));
                        weaponuserList.Length = dr.IsDBNull(coLength) ? (int)0 : dr.GetInt32(coLength);
                        weaponuserList.Width = dr.IsDBNull(coWidth) ? (int)0 : dr.GetInt32(coWidth);
                        weaponuserList.SLength = dr.IsDBNull(coSLength) ? (int)0 : dr.GetInt32(coSLength);
                        weaponuserList.SWidth = dr.IsDBNull(coSWidth) ? (int)0 : dr.GetInt32(coSWidth);
                        weaponuserList.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        weaponuserList.UpdateTS = dr.IsDBNull(coUpdateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coUpdateTS);
                        weaponuserList.StatusID = dr.IsDBNull(coStatusID) ? (int)0 : dr.GetInt32(coStatusID);
                        weaponuserList.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        weaponuserList.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        weaponuserList.StatusType = dr.IsDBNull(coStatusType) ? string.Empty : dr.GetString(coStatusType);
                        weaponuserList.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        weaponuserList.Reason = dr.IsDBNull(coReason) ? string.Empty : dr.GetString(coReason);
                        weaponuserList.WeaType = dr.IsDBNull(coWeaType) ? string.Empty : dr.GetString(coWeaType);
                        weaponuserList.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        weaponuserList.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        weaponuserList.FirstName = dr.IsDBNull(coFistName) ? string.Empty : dr.GetString(coFistName);
                        weaponuserList.Gender = dr.IsDBNull(coGender) ? string.Empty : dr.GetString(coGender);
                        weaponListList.Add(weaponuserList);
                    }
                }
            }
            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));
            return weaponListList;
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
            DB.AddInParameter(cmd, WeaponList.ReasonField, DbType.String, weaponList.Reason);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

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
        /// 获取 PraiseLog 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2015/12/7 17:29:03
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPraiseLog">PraiseLog 查询实体</param>
        /// <returns></returns>
        public List<PraiseLog> GetPraiseLogList(ref DataPage dp, PraiseLog searchPraiseLog)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseLog_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PraiseLog.WeaponIDField, DbType.Int32, searchPraiseLog.WeaponID);
            DB.AddInParameter(cmd, PraiseLog.PraiseIPField, DbType.String, searchPraiseLog.PraiseIP);

            List<PraiseLog> praiseLogList = new List<PraiseLog>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPraiseID = dr.GetOrdinal(PraiseLog.PraiseIDField);
                    int coWeaponID = dr.GetOrdinal(PraiseLog.WeaponIDField);
                    int coPraiseIP = dr.GetOrdinal(PraiseLog.PraiseIPField);
                    int coCreateTS = dr.GetOrdinal(PraiseLog.CreateTSField);
                    int coPraiseNumber = dr.GetOrdinal(PraiseLog.PraiseNumberField);
                    int coSource = dr.GetOrdinal(PraiseLog.SourceField);
                    int coAvatarID = dr.GetOrdinal(PraiseLog.AvatarIDField);
                    int coAreaID = dr.GetOrdinal(PraiseLog.AreaIDField);
                    int coUserID = dr.GetOrdinal(PraiseLog.UserIDField);
                    int coAreaName = dr.GetOrdinal(PraiseLog.AreaNameField);
                    while (dr.Read())
                    {
                        PraiseLog praiseLog = new PraiseLog();

                        praiseLog.PraiseID = dr.IsDBNull(coPraiseID) ? (int)0 : dr.GetInt32(coPraiseID);
                        praiseLog.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        praiseLog.PraiseIP = dr.IsDBNull(coPraiseIP) ? string.Empty : dr.GetString(coPraiseIP);
                        praiseLog.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        praiseLog.PraiseNumber = dr.IsDBNull(coPraiseNumber) ? (int)0 : dr.GetInt32(coPraiseNumber);
                        praiseLog.Source = dr.IsDBNull(coSource) ? (int)0 : dr.GetInt32(coSource);
                        praiseLog.AvatarID = dr.IsDBNull(coAvatarID) ? (long)0 : dr.GetInt64(coAvatarID);
                        praiseLog.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        praiseLog.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        praiseLog.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        praiseLogList.Add(praiseLog);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return praiseLogList;
        }

        /// <summary>
        /// 获取 CommentsList 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2015/12/11 13:56:36
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchCommentsList">CommentsList 查询实体</param>
        /// <returns></returns>
        public List<CommentsList> GetCommentsListList(ref DataPage dp, CommentsList searchCommentsList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("CommentsList_GetAll");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, CommentsList.WeaponIDField, DbType.Int32, searchCommentsList.WeaponID);
            DB.AddInParameter(cmd, CommentsList.UserIDField, DbType.Int64, searchCommentsList.UserID);
            DB.AddInParameter(cmd, CommentsList.AreaIDField, DbType.Int32, searchCommentsList.AreaID);

            List<CommentsList> commentsListList = new List<CommentsList>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coID = dr.GetOrdinal(CommentsList.IDField);
                    int coWeaponID = dr.GetOrdinal(CommentsList.WeaponIDField);
                    int coComments = dr.GetOrdinal(CommentsList.CommentsField);
                    int coCreateTS = dr.GetOrdinal(CommentsList.CreateTSField);
                    int coUserID = dr.GetOrdinal(CommentsList.UserIDField);
                    int coLoginName = dr.GetOrdinal(CommentsList.LoginNameField);
                    int coAreaName = dr.GetOrdinal(CommentsList.AreaNameField);
                    int coAvatarName = dr.GetOrdinal(CommentsList.AvatarNameField);
   

                    while (dr.Read())
                    {
                        CommentsList commentsList = new CommentsList();

                        commentsList.ID = dr.IsDBNull(coID) ? (int)0 : dr.GetInt32(coID);
                        commentsList.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        commentsList.Comments = dr.IsDBNull(coComments) ? string.Empty : dr.GetString(coComments);
                        commentsList.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        commentsList.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        commentsList.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        commentsList.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        commentsList.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        
                        commentsListList.Add(commentsList);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return commentsListList;
        }


        /// <summary>
        /// 更新 PraiseNumber
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 11:50:19
        /// <param name="praiseNumber">PraiseNumber 实体</param>
        /// <returns></returns>
        public Int32 UpdatePraiseNumber(PraiseNumber praiseNumber)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ChangePraiseNumber");
            DB.AddInParameter(cmd, PraiseNumber.NumField, DbType.Int32, praiseNumber.Num);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 获取 PraiseNumber 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 11:50:19
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPraiseNumber">PraiseNumber 查询实体</param>
        /// <returns></returns>
        public List<PraiseNumber> GetPraiseNumberList(ref DataPage dp)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseNumber_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<PraiseNumber> praiseNumberList = new List<PraiseNumber>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coID = dr.GetOrdinal(PraiseNumber.IDField);
                    int coNum = dr.GetOrdinal(PraiseNumber.NumField);

                    while (dr.Read())
                    {
                        PraiseNumber praiseNumber = new PraiseNumber();

                        praiseNumber.ID = dr.IsDBNull(coID) ? (int)0 : dr.GetInt32(coID);
                        praiseNumber.Num = dr.IsDBNull(coNum) ? (int)0 : dr.GetInt32(coNum);

                        praiseNumberList.Add(praiseNumber);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return praiseNumberList;
        }

        #region 自动刷票配置
        /// <summary>
        /// 增加 PraiseSchedule
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 12:32:20
        /// <param name="praiseSchedule">PraiseSchedule 实体</param>
        /// <returns></returns>
        public Int32 PraiseScheduleAdd(PraiseSchedule praiseSchedule)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseSchedule_Add");
            DB.AddParameter(cmd, PraiseSchedule.IDField, DbType.Int32, ParameterDirection.InputOutput, PraiseSchedule.IDField, DataRowVersion.Current, praiseSchedule.ID);
            DB.AddInParameter(cmd, PraiseSchedule.StartTSField, DbType.DateTime, praiseSchedule.StartTS);
            DB.AddInParameter(cmd, PraiseSchedule.EndTSField, DbType.DateTime, praiseSchedule.EndTS);
            DB.AddInParameter(cmd, PraiseSchedule.StatusField, DbType.Int32, praiseSchedule.Status);
            DB.AddInParameter(cmd, PraiseSchedule.MinField, DbType.Int32, praiseSchedule.Min);
            DB.AddInParameter(cmd, PraiseSchedule.MaxField, DbType.Int32, praiseSchedule.Max);
            DB.AddInParameter(cmd, PraiseSchedule.WeaponIDField, DbType.Int32, praiseSchedule.WeaponID);
            DB.AddInParameter(cmd, PraiseSchedule.RandNumField, DbType.Int32, praiseSchedule.RandNum);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            praiseSchedule.ID = Convert.ToInt32(DB.GetParameterValue(cmd, "ID"));

            return praiseSchedule.ID;
        }

        /// <summary>
        /// 更新 PraiseSchedule
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 12:32:20
        /// <param name="praiseSchedule">PraiseSchedule 实体</param>
        /// <returns></returns>
        public Int32 PraiseScheduleUpdate(PraiseSchedule praiseSchedule)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseSchedule_Update");
            DB.AddParameter(cmd, PraiseSchedule.IDField, DbType.Int32, ParameterDirection.InputOutput, PraiseSchedule.IDField, DataRowVersion.Current, praiseSchedule.ID);
            DB.AddInParameter(cmd, PraiseSchedule.StartTSField, DbType.DateTime, praiseSchedule.StartTS);
            DB.AddInParameter(cmd, PraiseSchedule.EndTSField, DbType.DateTime, praiseSchedule.EndTS);
            DB.AddInParameter(cmd, PraiseSchedule.StatusField, DbType.Int32, praiseSchedule.Status);
            DB.AddInParameter(cmd, PraiseSchedule.MinField, DbType.Int32, praiseSchedule.Min);
            DB.AddInParameter(cmd, PraiseSchedule.MaxField, DbType.Int32, praiseSchedule.Max);
            DB.AddInParameter(cmd, PraiseSchedule.WeaponIDField, DbType.Int32, praiseSchedule.WeaponID);
            DB.AddInParameter(cmd, PraiseSchedule.RandNumField, DbType.Int32, praiseSchedule.RandNum);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 PraiseSchedule
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 12:32:20
        /// <param name="praiseSchedule">PraiseSchedule 实体</param>
        /// <returns></returns>
        public bool PraiseScheduleDel(PraiseSchedule praiseSchedule)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseSchedule_Del");
            DB.AddInParameter(cmd, PraiseSchedule.IDField, DbType.Int32, praiseSchedule.ID);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 PraiseSchedule
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 12:32:20
        /// <param name="praiseSchedule">PraiseSchedule 实体</param>
        /// <returns></returns>
        public PraiseSchedule PraiseScheduleGetByID(PraiseSchedule searchPraiseSchedule)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseSchedule_GetByID");
            DB.AddInParameter(cmd, PraiseSchedule.IDField, DbType.Int32, searchPraiseSchedule.ID);

            PraiseSchedule praiseSchedule = new PraiseSchedule();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coID = dr.GetOrdinal(PraiseSchedule.IDField);
                    int coStartTS = dr.GetOrdinal(PraiseSchedule.StartTSField);
                    int coEndTS = dr.GetOrdinal(PraiseSchedule.EndTSField);
                    int coStatus = dr.GetOrdinal(PraiseSchedule.StatusField);
                    int coMin = dr.GetOrdinal(PraiseSchedule.MinField);
                    int coMax = dr.GetOrdinal(PraiseSchedule.MaxField);
                    int coWeaponID = dr.GetOrdinal(PraiseSchedule.WeaponIDField);
                    int coRandNum = dr.GetOrdinal(PraiseSchedule.RandNumField);

                    if (dr.Read())
                    {
                        praiseSchedule.ID = dr.GetInt32(coID);
                        praiseSchedule.StartTS = dr.GetDateTime(coStartTS);
                        praiseSchedule.EndTS = dr.GetDateTime(coEndTS);
                        praiseSchedule.Status = dr.GetInt32(coStatus);
                        praiseSchedule.Min = dr.GetInt32(coMin);
                        praiseSchedule.Max = dr.GetInt32(coMax);
                        praiseSchedule.WeaponID = dr.GetInt32(coWeaponID);
                        praiseSchedule.RandNum = dr.GetInt32(coRandNum);
                    }
                }
            }

            return praiseSchedule;
        }

        /// <summary>
        /// 获取 PraiseSchedule 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/28 12:32:20
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPraiseSchedule">PraiseSchedule 查询实体</param>
        /// <returns></returns>
        public List<PraiseSchedule> PraiseScheduleGetList(ref DataPage dp)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PraiseSchedule_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<PraiseSchedule> praiseScheduleList = new List<PraiseSchedule>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coID = dr.GetOrdinal(PraiseSchedule.IDField);
                    int coStartTS = dr.GetOrdinal(PraiseSchedule.StartTSField);
                    int coEndTS = dr.GetOrdinal(PraiseSchedule.EndTSField);
                    int coStatus = dr.GetOrdinal(PraiseSchedule.StatusField);
                    int coMin = dr.GetOrdinal(PraiseSchedule.MinField);
                    int coMax = dr.GetOrdinal(PraiseSchedule.MaxField);
                    int coWeaponID = dr.GetOrdinal(PraiseSchedule.WeaponIDField);
                    int coRandNum = dr.GetOrdinal(PraiseSchedule.RandNumField);

                    while (dr.Read())
                    {
                        PraiseSchedule praiseSchedule = new PraiseSchedule();

                        praiseSchedule.ID = dr.IsDBNull(coID) ? (int)0 : dr.GetInt32(coID);
                        praiseSchedule.StartTS = dr.IsDBNull(coStartTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coStartTS);
                        praiseSchedule.EndTS = dr.IsDBNull(coEndTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coEndTS);
                        praiseSchedule.Status = dr.IsDBNull(coStatus) ? (int)0 : dr.GetInt32(coStatus);
                        praiseSchedule.Min = dr.IsDBNull(coMin) ? (int)0 : dr.GetInt32(coMin);
                        praiseSchedule.Max = dr.IsDBNull(coMax) ? (int)0 : dr.GetInt32(coMax);
                        praiseSchedule.WeaponID = dr.IsDBNull(coWeaponID) ? (int)0 : dr.GetInt32(coWeaponID);
                        praiseSchedule.RandNum = dr.IsDBNull(coRandNum) ? (int)0 : dr.GetInt32(coRandNum);

                        praiseScheduleList.Add(praiseSchedule);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return praiseScheduleList;
        }    


        #endregion


    }
}


