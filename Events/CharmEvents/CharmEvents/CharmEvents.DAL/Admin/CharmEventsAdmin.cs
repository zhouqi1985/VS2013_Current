using CharmEvents.Database.Database;
using CommonLibs.Common;
using CommonLibs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace CharmEvents.DAL.Admin
{
    public class CharmEventsAdmin : CommonLibs.EnterpriseLibrary.DatabaseAccessBase, ICharmEventsAdmin
    {
        public CharmEventsAdmin() : base("CharmEventsDB") { }

        #region OtherLists

        /// <summary>
        /// 获取 ExchangeAndDrawLog 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:10:02
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchExchangeAndDrawLog">ExchangeAndDrawLog 查询实体</param>
        /// <returns></returns>
        public List<ExchangeAndDrawLog> GetExchangeAndDrawLogList(ref DataPage dp, ExchangeAndDrawLog searchExchangeAndDrawLog)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangeAndDrawLog_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, ExchangeAndDrawLog.UserIdField, DbType.Int64, searchExchangeAndDrawLog.UserId);
            DB.AddInParameter(cmd, ExchangeAndDrawLog.LoginNameField, DbType.AnsiString, searchExchangeAndDrawLog.LoginName);
            DB.AddInParameter(cmd, ExchangeAndDrawLog.AreaIdField, DbType.Int32, searchExchangeAndDrawLog.AreaId);
            DB.AddInParameter(cmd, ExchangeAndDrawLog.ExchangeIdField, DbType.Int32, searchExchangeAndDrawLog.ExchangeId);

            List<ExchangeAndDrawLog> exchangeAndDrawLogList = new List<ExchangeAndDrawLog>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coConsumeId = dr.GetOrdinal(ExchangeAndDrawLog.ConsumeIdField);
                    int coUserId = dr.GetOrdinal(ExchangeAndDrawLog.UserIdField);
                    int coLoginName = dr.GetOrdinal(ExchangeAndDrawLog.LoginNameField);
                    int coAreaId = dr.GetOrdinal(ExchangeAndDrawLog.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(ExchangeAndDrawLog.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(ExchangeAndDrawLog.AvatarNameField);
                    int coSex = dr.GetOrdinal(ExchangeAndDrawLog.SexField);
                    int coExchangeId = dr.GetOrdinal(ExchangeAndDrawLog.ExchangeIdField);
                    int coPoints = dr.GetOrdinal(ExchangeAndDrawLog.PointsField);
                    int coRandNum = dr.GetOrdinal(ExchangeAndDrawLog.RandNumField);
                    int coCreateTime = dr.GetOrdinal(ExchangeAndDrawLog.CreateTimeField);
                    int coSource = dr.GetOrdinal(ExchangeAndDrawLog.SourceField);

                    while (dr.Read())
                    {
                        ExchangeAndDrawLog exchangeAndDrawLog = new ExchangeAndDrawLog();

                        exchangeAndDrawLog.ConsumeId = dr.IsDBNull(coConsumeId) ? (long)0 : dr.GetInt64(coConsumeId);
                        exchangeAndDrawLog.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        exchangeAndDrawLog.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        exchangeAndDrawLog.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        exchangeAndDrawLog.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        exchangeAndDrawLog.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        exchangeAndDrawLog.Sex = dr.IsDBNull(coSex) ? (int)0 : dr.GetInt32(coSex);
                        exchangeAndDrawLog.ExchangeId = dr.IsDBNull(coExchangeId) ? (int)0 : dr.GetInt32(coExchangeId);
                        exchangeAndDrawLog.Points = dr.IsDBNull(coPoints) ? (int)0 : dr.GetInt32(coPoints);
                        exchangeAndDrawLog.RandNum = dr.IsDBNull(coRandNum) ? (int)0 : dr.GetInt32(coRandNum);
                        exchangeAndDrawLog.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        exchangeAndDrawLog.Source = dr.IsDBNull(coSource) ? string.Empty : dr.GetString(coSource);

                        exchangeAndDrawLogList.Add(exchangeAndDrawLog);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return exchangeAndDrawLogList;
        }

        /// <summary>
        /// 获取 LoginPacketLog 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:14:30
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchLoginPacketLog">LoginPacketLog 查询实体</param>
        /// <returns></returns>
        public List<LoginPacketLog> GetLoginPacketLogList(ref DataPage dp, LoginPacketLog searchLoginPacketLog)
        {
            DbCommand cmd = DB.GetStoredProcCommand("LoginPacketLog_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, LoginPacketLog.UserIdField, DbType.Int64, searchLoginPacketLog.UserId);
            DB.AddInParameter(cmd, LoginPacketLog.LoginNameField, DbType.AnsiString, searchLoginPacketLog.LoginName);
            DB.AddInParameter(cmd, LoginPacketLog.AreaIdField, DbType.Int32, searchLoginPacketLog.AreaId);

            List<LoginPacketLog> loginPacketLogList = new List<LoginPacketLog>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(LoginPacketLog.IdField);
                    int coUserId = dr.GetOrdinal(LoginPacketLog.UserIdField);
                    int coLoginName = dr.GetOrdinal(LoginPacketLog.LoginNameField);
                    int coAreaId = dr.GetOrdinal(LoginPacketLog.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(LoginPacketLog.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(LoginPacketLog.AvatarNameField);
                    int coSex = dr.GetOrdinal(LoginPacketLog.SexField);
                    int coPacketId = dr.GetOrdinal(LoginPacketLog.PacketIdField);
                    int coCreateTime = dr.GetOrdinal(LoginPacketLog.CreateTimeField);
                    int coSource = dr.GetOrdinal(LoginPacketLog.SourceField);

                    while (dr.Read())
                    {
                        LoginPacketLog loginPacketLog = new LoginPacketLog();

                        loginPacketLog.Id = dr.IsDBNull(coId) ? (long)0 : dr.GetInt64(coId);
                        loginPacketLog.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        loginPacketLog.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        loginPacketLog.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        loginPacketLog.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        loginPacketLog.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        loginPacketLog.Sex = dr.IsDBNull(coSex) ? (int)0 : dr.GetInt32(coSex);
                        loginPacketLog.PacketId = dr.IsDBNull(coPacketId) ? (int)0 : dr.GetInt32(coPacketId);
                        loginPacketLog.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        loginPacketLog.Source = dr.IsDBNull(coSource) ? string.Empty : dr.GetString(coSource);

                        loginPacketLogList.Add(loginPacketLog);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return loginPacketLogList;
        }

        /// <summary>
        /// 获取 PacketQueueLog 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:16:08
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPacketQueueLog">PacketQueueLog 查询实体</param>
        /// <returns></returns>
        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchPacketQueueLog)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PacketQueueLog_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PacketQueueLog.UserIdField, DbType.Int64, searchPacketQueueLog.UserId);
            DB.AddInParameter(cmd, PacketQueueLog.LoginNameField, DbType.AnsiString, searchPacketQueueLog.LoginName);
            DB.AddInParameter(cmd, PacketQueueLog.AreaIdField, DbType.Int32, searchPacketQueueLog.AreaId);
            DB.AddInParameter(cmd, PacketQueueLog.PacketIdField, DbType.Int64, searchPacketQueueLog.PacketId);

            List<PacketQueueLog> packetQueueLogList = new List<PacketQueueLog>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(PacketQueueLog.IdField);
                    int coUserId = dr.GetOrdinal(PacketQueueLog.UserIdField);
                    int coLoginName = dr.GetOrdinal(PacketQueueLog.LoginNameField);
                    int coAreaId = dr.GetOrdinal(PacketQueueLog.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(PacketQueueLog.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(PacketQueueLog.AvatarNameField);
                    int coSex = dr.GetOrdinal(PacketQueueLog.SexField);
                    int coPacketId = dr.GetOrdinal(PacketQueueLog.PacketIdField);
                    int coCreateTime = dr.GetOrdinal(PacketQueueLog.CreateTimeField);
                    int coSource = dr.GetOrdinal(PacketQueueLog.SourceField);
                    int coFromId = dr.GetOrdinal(PacketQueueLog.FromIdField);

                    while (dr.Read())
                    {
                        PacketQueueLog packetQueueLog = new PacketQueueLog();

                        packetQueueLog.Id = dr.IsDBNull(coId) ? (long)0 : dr.GetInt64(coId);
                        packetQueueLog.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        packetQueueLog.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        packetQueueLog.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        packetQueueLog.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        packetQueueLog.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        packetQueueLog.Sex = dr.IsDBNull(coSex) ? (int)0 : dr.GetInt32(coSex);
                        packetQueueLog.PacketId = dr.IsDBNull(coPacketId) ? (long)0 : dr.GetInt64(coPacketId);
                        packetQueueLog.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        packetQueueLog.Source = dr.IsDBNull(coSource) ? string.Empty : dr.GetString(coSource);
                        packetQueueLog.FromId = dr.IsDBNull(coFromId) ? (long)0 : dr.GetInt64(coFromId);

                        packetQueueLogList.Add(packetQueueLog);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return packetQueueLogList;
        }
        #endregion

        #region Wallets
        /// <summary>
        /// 获取 Wallets 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:18:46
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchWallets">Wallets 查询实体</param>
        /// <returns></returns>
        public List<Wallets> GetWalletsList(ref DataPage dp, Wallets searchWallets)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Wallets_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, Wallets.UserIdField, DbType.Int64, searchWallets.UserId);
            DB.AddInParameter(cmd, Wallets.AreaIdField, DbType.Int32, searchWallets.AreaId);

            List<Wallets> walletsList = new List<Wallets>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coWId = dr.GetOrdinal(Wallets.WIdField);
                    int coUserId = dr.GetOrdinal(Wallets.UserIdField);
                    int coAreaId = dr.GetOrdinal(Wallets.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(Wallets.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(Wallets.AvatarNameField);
                    int coRecordDate = dr.GetOrdinal(Wallets.RecordDateField);
                    int coGetPoints = dr.GetOrdinal(Wallets.GetPointsField);
                    int coBalancePoints = dr.GetOrdinal(Wallets.BalancePointsField);
                    int coCreateTime = dr.GetOrdinal(Wallets.CreateTimeField);
                    int coSource = dr.GetOrdinal(Wallets.SourceField);
                    int coGetLastTime = dr.GetOrdinal(Wallets.GetLastTimeField);
                    int coFromId = dr.GetOrdinal(Wallets.FromIdField);

                    while (dr.Read())
                    {
                        Wallets wallets = new Wallets();

                        wallets.WId = dr.IsDBNull(coWId) ? (long)0 : dr.GetInt64(coWId);
                        wallets.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        wallets.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        wallets.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        wallets.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        wallets.RecordDate = dr.IsDBNull(coRecordDate) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coRecordDate);
                        wallets.GetPoints = dr.IsDBNull(coGetPoints) ? (int)0 : dr.GetInt32(coGetPoints);
                        wallets.BalancePoints = dr.IsDBNull(coBalancePoints) ? (int)0 : dr.GetInt32(coBalancePoints);
                        wallets.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        wallets.Source = dr.IsDBNull(coSource) ? string.Empty : dr.GetString(coSource);
                        wallets.GetLastTime = dr.IsDBNull(coGetLastTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coGetLastTime);
                        wallets.FromId = dr.IsDBNull(coFromId) ? (long)0 : dr.GetInt64(coFromId);

                        walletsList.Add(wallets);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return walletsList;
        }

        /// <summary>
        /// 增加 Wallets
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:59:06
        /// <param name="wallets">Wallets 实体</param>
        /// <returns></returns>
        public Int64 AddWallets(Wallets wallets)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Wallets_Add");
            DB.AddParameter(cmd, Wallets.WIdField, DbType.Int64, ParameterDirection.InputOutput, Wallets.WIdField, DataRowVersion.Current, wallets.WId);
            DB.AddInParameter(cmd, Wallets.UserIdField, DbType.Int64, wallets.UserId);
            DB.AddInParameter(cmd, Wallets.AreaIdField, DbType.Int32, wallets.AreaId);
            DB.AddInParameter(cmd, Wallets.AvatarIdField, DbType.Int64, wallets.AvatarId);
            DB.AddInParameter(cmd, Wallets.AvatarNameField, DbType.AnsiString, wallets.AvatarName);
            DB.AddInParameter(cmd, Wallets.RecordDateField, DbType.Date, wallets.RecordDate);
            DB.AddInParameter(cmd, Wallets.GetPointsField, DbType.Int32, wallets.GetPoints);
            DB.AddInParameter(cmd, Wallets.BalancePointsField, DbType.Int32, wallets.BalancePoints);
            DB.AddInParameter(cmd, Wallets.CreateTimeField, DbType.DateTime, wallets.CreateTime);
            DB.AddInParameter(cmd, Wallets.SourceField, DbType.String, wallets.Source);
            DB.AddInParameter(cmd, Wallets.GetLastTimeField, DbType.DateTime, wallets.GetLastTime);
            DB.AddInParameter(cmd, Wallets.FromIdField, DbType.Int64, wallets.FromId);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            wallets.WId = Convert.ToInt64(DB.GetParameterValue(cmd, "WId"));

            return wallets.WId;
        }
        #endregion

        #region DrawPacketConfig

        /// <summary>
        /// 增加 DrawPacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:48:12
        /// <param name="drawPacketConfig">DrawPacketConfig 实体</param>
        /// <returns></returns>
        public int AddDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DrawPacketConfig_Add");
            DB.AddParameter(cmd, DrawPacketConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, DrawPacketConfig.IdField, DataRowVersion.Current, drawPacketConfig.Id);
            DB.AddInParameter(cmd, DrawPacketConfig.PacketIdField, DbType.Int64, drawPacketConfig.PacketId);
            DB.AddInParameter(cmd, DrawPacketConfig.PacketNameField, DbType.String, drawPacketConfig.PacketName);
            DB.AddInParameter(cmd, DrawPacketConfig.PacketDescField, DbType.String, drawPacketConfig.PacketDesc);
            DB.AddInParameter(cmd, DrawPacketConfig.RateValueField, DbType.Decimal, drawPacketConfig.RateValue);
            DB.AddInParameter(cmd, DrawPacketConfig.RateBeginField, DbType.Int32, drawPacketConfig.RateBegin);
            DB.AddInParameter(cmd, DrawPacketConfig.RateEndField, DbType.Int32, drawPacketConfig.RateEnd);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            drawPacketConfig.Id = Convert.ToInt32(DB.GetParameterValue(cmd, "Id"));

            return drawPacketConfig.Id;
        }

        /// <summary>
        /// 更新 DrawPacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:48:12
        /// <param name="drawPacketConfig">DrawPacketConfig 实体</param>
        /// <returns></returns>
        public int UpdateDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DrawPacketConfig_Update");
            DB.AddParameter(cmd, DrawPacketConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, DrawPacketConfig.IdField, DataRowVersion.Current, drawPacketConfig.Id);
            DB.AddInParameter(cmd, DrawPacketConfig.PacketIdField, DbType.Int64, drawPacketConfig.PacketId);
            DB.AddInParameter(cmd, DrawPacketConfig.PacketNameField, DbType.String, drawPacketConfig.PacketName);
            DB.AddInParameter(cmd, DrawPacketConfig.PacketDescField, DbType.String, drawPacketConfig.PacketDesc);
            DB.AddInParameter(cmd, DrawPacketConfig.RateValueField, DbType.Decimal, drawPacketConfig.RateValue);
            DB.AddInParameter(cmd, DrawPacketConfig.RateBeginField, DbType.Int32, drawPacketConfig.RateBegin);
            DB.AddInParameter(cmd, DrawPacketConfig.RateEndField, DbType.Int32, drawPacketConfig.RateEnd);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            int rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 DrawPacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:48:12
        /// <param name="drawPacketConfig">DrawPacketConfig 实体</param>
        /// <returns></returns>
        public bool DelDrawPacketConfig(DrawPacketConfig drawPacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DrawPacketConfig_Del");
            DB.AddInParameter(cmd, DrawPacketConfig.PacketIdField, DbType.Int64, drawPacketConfig.PacketId);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 DrawPacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:48:12
        /// <param name="drawPacketConfig">DrawPacketConfig 实体</param>
        /// <returns></returns>
        public DrawPacketConfig GetDrawPacketConfig(DrawPacketConfig searchDrawPacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DrawPacketConfig_GetById");
            DB.AddInParameter(cmd, DrawPacketConfig.IdField, DbType.Int32, searchDrawPacketConfig.Id);

            DrawPacketConfig drawPacketConfig = new DrawPacketConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(DrawPacketConfig.IdField);
                    int coPacketId = dr.GetOrdinal(DrawPacketConfig.PacketIdField);
                    int coPacketName = dr.GetOrdinal(DrawPacketConfig.PacketNameField);
                    int coPacketDesc = dr.GetOrdinal(DrawPacketConfig.PacketDescField);
                    int coRateValue = dr.GetOrdinal(DrawPacketConfig.RateValueField);
                    int coRateBegin = dr.GetOrdinal(DrawPacketConfig.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(DrawPacketConfig.RateEndField);

                    if (dr.Read())
                    {
                        drawPacketConfig.Id = dr.GetInt32(coId);
                        drawPacketConfig.PacketId = dr.GetInt64(coPacketId);
                        drawPacketConfig.PacketName = dr.GetString(coPacketName);
                        drawPacketConfig.PacketDesc = dr.IsDBNull(coPacketDesc) ? string.Empty : dr.GetString(coPacketDesc);
                        drawPacketConfig.RateValue = dr.GetDecimal(coRateValue);
                        drawPacketConfig.RateBegin = dr.GetInt32(coRateBegin);
                        drawPacketConfig.RateEnd = dr.GetInt32(coRateEnd);
                    }
                }
            }

            return drawPacketConfig;
        }

        /// <summary>
        /// 获取 DrawPacketConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 10:48:12
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchDrawPacketConfig">DrawPacketConfig 查询实体</param>
        /// <returns></returns>
        public List<DrawPacketConfig> GetDrawPacketConfigList(ref DataPage dp)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DrawPacketConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<DrawPacketConfig> drawPacketConfigList = new List<DrawPacketConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(DrawPacketConfig.IdField);
                    int coPacketId = dr.GetOrdinal(DrawPacketConfig.PacketIdField);
                    int coPacketName = dr.GetOrdinal(DrawPacketConfig.PacketNameField);
                    int coPacketDesc = dr.GetOrdinal(DrawPacketConfig.PacketDescField);
                    int coRateValue = dr.GetOrdinal(DrawPacketConfig.RateValueField);
                    int coRateBegin = dr.GetOrdinal(DrawPacketConfig.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(DrawPacketConfig.RateEndField);

                    while (dr.Read())
                    {
                        DrawPacketConfig drawPacketConfig = new DrawPacketConfig();

                        drawPacketConfig.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        drawPacketConfig.PacketId = dr.IsDBNull(coPacketId) ? (long)0 : dr.GetInt64(coPacketId);
                        drawPacketConfig.PacketName = dr.IsDBNull(coPacketName) ? string.Empty : dr.GetString(coPacketName);
                        drawPacketConfig.PacketDesc = dr.IsDBNull(coPacketDesc) ? string.Empty : dr.GetString(coPacketDesc);
                        drawPacketConfig.RateValue = dr.IsDBNull(coRateValue) ? 0.0m : dr.GetDecimal(coRateValue);
                        drawPacketConfig.RateBegin = dr.IsDBNull(coRateBegin) ? (int)0 : dr.GetInt32(coRateBegin);
                        drawPacketConfig.RateEnd = dr.IsDBNull(coRateEnd) ? (int)0 : dr.GetInt32(coRateEnd);

                        drawPacketConfigList.Add(drawPacketConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return drawPacketConfigList;
        }

        public int SubmitDrawPacketConfigRate()
        {
            DbCommand cmd = DB.GetStoredProcCommand("DrawPacketConfig_SubmitRate");
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            //无异常就返回true
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }
        #endregion

        #region ExchangePacketTypeConfig
        /// <summary>
        /// 增加 ExchangePacketTypeConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:00:22
        /// <param name="exchangePacketTypeConfig">ExchangePacketTypeConfig 实体</param>
        /// <returns></returns>
        public Int32 AddExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketTypeConfig_Add");
            DB.AddParameter(cmd, ExchangePacketTypeConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, ExchangePacketTypeConfig.IdField, DataRowVersion.Current, exchangePacketTypeConfig.Id);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeIdField, DbType.Int32, exchangePacketTypeConfig.ExchangeTypeId);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeNameField, DbType.String, exchangePacketTypeConfig.ExchangeTypeName);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeDescField, DbType.String, exchangePacketTypeConfig.ExchangeTypeDesc);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.AccumulatePointsField, DbType.Int32, exchangePacketTypeConfig.AccumulatePoints);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.TypeLimitField, DbType.Int32, exchangePacketTypeConfig.TypeLimit);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            exchangePacketTypeConfig.Id = Convert.ToInt32(DB.GetParameterValue(cmd, ExchangePacketTypeConfig.IdField));

            return exchangePacketTypeConfig.Id;
        }

        /// <summary>
        /// 更新 ExchangePacketTypeConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:00:22
        /// <param name="exchangePacketTypeConfig">ExchangePacketTypeConfig 实体</param>
        /// <returns></returns>
        public Int32 UpdateExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketTypeConfig_Update");
            DB.AddParameter(cmd, ExchangePacketTypeConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, ExchangePacketTypeConfig.IdField, DataRowVersion.Current, exchangePacketTypeConfig.Id);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeIdField, DbType.Int32, exchangePacketTypeConfig.ExchangeTypeId);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeNameField, DbType.String, exchangePacketTypeConfig.ExchangeTypeName);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeDescField, DbType.String, exchangePacketTypeConfig.ExchangeTypeDesc);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.AccumulatePointsField, DbType.Int32, exchangePacketTypeConfig.AccumulatePoints);
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.TypeLimitField, DbType.Int32, exchangePacketTypeConfig.TypeLimit);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 ExchangePacketTypeConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:00:22
        /// <param name="exchangePacketTypeConfig">ExchangePacketTypeConfig 实体</param>
        /// <returns></returns>
        public bool DelExchangePacketTypeConfig(ExchangePacketTypeConfig exchangePacketTypeConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketTypeConfig_Del");
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.ExchangeTypeIdField, DbType.Int32, exchangePacketTypeConfig.ExchangeTypeId);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 ExchangePacketTypeConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:00:22
        /// <param name="exchangePacketTypeConfig">ExchangePacketTypeConfig 实体</param>
        /// <returns></returns>
        public ExchangePacketTypeConfig GetExchangePacketTypeConfig(ExchangePacketTypeConfig searchExchangePacketTypeConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketTypeConfig_GetById");
            DB.AddInParameter(cmd, ExchangePacketTypeConfig.IdField, DbType.Int32, searchExchangePacketTypeConfig.Id);

            ExchangePacketTypeConfig exchangePacketTypeConfig = new ExchangePacketTypeConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(ExchangePacketTypeConfig.IdField);
                    int coExchangeTypeId = dr.GetOrdinal(ExchangePacketTypeConfig.ExchangeTypeIdField);
                    int coExchangeTypeName = dr.GetOrdinal(ExchangePacketTypeConfig.ExchangeTypeNameField);
                    int coExchangeTypeDesc = dr.GetOrdinal(ExchangePacketTypeConfig.ExchangeTypeDescField);
                    int coAccumulatePoints = dr.GetOrdinal(ExchangePacketTypeConfig.AccumulatePointsField);
                    int coTypeLimit = dr.GetOrdinal(ExchangePacketTypeConfig.TypeLimitField);

                    if (dr.Read())
                    {
                        exchangePacketTypeConfig.Id = dr.GetInt32(coId);
                        exchangePacketTypeConfig.ExchangeTypeId = dr.GetInt32(coExchangeTypeId);
                        exchangePacketTypeConfig.ExchangeTypeName = dr.GetString(coExchangeTypeName);
                        exchangePacketTypeConfig.ExchangeTypeDesc = dr.IsDBNull(coExchangeTypeDesc) ? string.Empty : dr.GetString(coExchangeTypeDesc);
                        exchangePacketTypeConfig.AccumulatePoints = dr.GetInt32(coAccumulatePoints);
                        exchangePacketTypeConfig.TypeLimit = dr.GetInt32(coTypeLimit);
                    }
                }
            }

            return exchangePacketTypeConfig;
        }

        /// <summary>
        /// 获取 ExchangePacketTypeConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:00:22
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchExchangePacketTypeConfig">ExchangePacketTypeConfig 查询实体</param>
        /// <returns></returns>
        public List<ExchangePacketTypeConfig> GetExchangePacketTypeConfigList(ref DataPage dp)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketTypeConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<ExchangePacketTypeConfig> exchangePacketTypeConfigList = new List<ExchangePacketTypeConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(ExchangePacketTypeConfig.IdField);
                    int coExchangeTypeId = dr.GetOrdinal(ExchangePacketTypeConfig.ExchangeTypeIdField);
                    int coExchangeTypeName = dr.GetOrdinal(ExchangePacketTypeConfig.ExchangeTypeNameField);
                    int coExchangeTypeDesc = dr.GetOrdinal(ExchangePacketTypeConfig.ExchangeTypeDescField);
                    int coAccumulatePoints = dr.GetOrdinal(ExchangePacketTypeConfig.AccumulatePointsField);
                    int coTypeLimit = dr.GetOrdinal(ExchangePacketTypeConfig.TypeLimitField);

                    while (dr.Read())
                    {
                        ExchangePacketTypeConfig exchangePacketTypeConfig = new ExchangePacketTypeConfig();

                        exchangePacketTypeConfig.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        exchangePacketTypeConfig.ExchangeTypeId = dr.IsDBNull(coExchangeTypeId) ? (int)0 : dr.GetInt32(coExchangeTypeId);
                        exchangePacketTypeConfig.ExchangeTypeName = dr.IsDBNull(coExchangeTypeName) ? string.Empty : dr.GetString(coExchangeTypeName);
                        exchangePacketTypeConfig.ExchangeTypeDesc = dr.IsDBNull(coExchangeTypeDesc) ? string.Empty : dr.GetString(coExchangeTypeDesc);
                        exchangePacketTypeConfig.AccumulatePoints = dr.IsDBNull(coAccumulatePoints) ? (int)0 : dr.GetInt32(coAccumulatePoints);
                        exchangePacketTypeConfig.TypeLimit = dr.IsDBNull(coTypeLimit) ? (int)0 : dr.GetInt32(coTypeLimit);

                        exchangePacketTypeConfigList.Add(exchangePacketTypeConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return exchangePacketTypeConfigList;
        }
        #endregion

        #region ExchangePacketConfig
        /// <summary>
        /// 增加 ExchangePacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:18:23
        /// <param name="exchangePacketConfig">ExchangePacketConfig 实体</param>
        /// <returns></returns>
        public Int32 AddExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketConfig_Add");
            DB.AddParameter(cmd, ExchangePacketConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, ExchangePacketConfig.IdField, DataRowVersion.Current, exchangePacketConfig.Id);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeIdField, DbType.Int32, exchangePacketConfig.ExchangeId);
            DB.AddInParameter(cmd, ExchangePacketConfig.PacketIdField, DbType.Int64, exchangePacketConfig.PacketId);
            DB.AddInParameter(cmd, ExchangePacketConfig.PacketNameField, DbType.String, exchangePacketConfig.PacketName);
            DB.AddInParameter(cmd, ExchangePacketConfig.PacketDescField, DbType.String, exchangePacketConfig.PacketDesc);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeLimitField, DbType.Int32, exchangePacketConfig.ExchangeLimit);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangePointsField, DbType.Int32, exchangePacketConfig.ExchangePoints);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeTypeIdField, DbType.Int32, exchangePacketConfig.ExchangeTypeId);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            exchangePacketConfig.Id = Convert.ToInt32(DB.GetParameterValue(cmd, ExchangePacketConfig.IdField));

            return exchangePacketConfig.Id;
        }

        /// <summary>
        /// 更新 ExchangePacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:18:23
        /// <param name="exchangePacketConfig">ExchangePacketConfig 实体</param>
        /// <returns></returns>
        public Int32 UpdateExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketConfig_Update");
            DB.AddParameter(cmd, ExchangePacketConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, ExchangePacketConfig.IdField, DataRowVersion.Current, exchangePacketConfig.Id);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeIdField, DbType.Int32, exchangePacketConfig.ExchangeId);
            DB.AddInParameter(cmd, ExchangePacketConfig.PacketIdField, DbType.Int64, exchangePacketConfig.PacketId);
            DB.AddInParameter(cmd, ExchangePacketConfig.PacketNameField, DbType.String, exchangePacketConfig.PacketName);
            DB.AddInParameter(cmd, ExchangePacketConfig.PacketDescField, DbType.String, exchangePacketConfig.PacketDesc);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeLimitField, DbType.Int32, exchangePacketConfig.ExchangeLimit);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangePointsField, DbType.Int32, exchangePacketConfig.ExchangePoints);
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeTypeIdField, DbType.Int32, exchangePacketConfig.ExchangeTypeId);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 ExchangePacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:18:23
        /// <param name="exchangePacketConfig">ExchangePacketConfig 实体</param>
        /// <returns></returns>
        public bool DelExchangePacketConfig(ExchangePacketConfig exchangePacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketConfig_Del");
            DB.AddInParameter(cmd, ExchangePacketConfig.ExchangeIdField, DbType.Int32, exchangePacketConfig.ExchangeId);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 ExchangePacketConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:18:23
        /// <param name="exchangePacketConfig">ExchangePacketConfig 实体</param>
        /// <returns></returns>
        public ExchangePacketConfig GetExchangePacketConfig(ExchangePacketConfig searchExchangePacketConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketConfig_GetById");
            DB.AddInParameter(cmd, ExchangePacketConfig.IdField, DbType.Int32, searchExchangePacketConfig.Id);

            ExchangePacketConfig exchangePacketConfig = new ExchangePacketConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(ExchangePacketConfig.IdField);
                    int coExchangeId = dr.GetOrdinal(ExchangePacketConfig.ExchangeIdField);
                    int coPacketId = dr.GetOrdinal(ExchangePacketConfig.PacketIdField);
                    int coPacketName = dr.GetOrdinal(ExchangePacketConfig.PacketNameField);
                    int coPacketDesc = dr.GetOrdinal(ExchangePacketConfig.PacketDescField);
                    int coExchangeLimit = dr.GetOrdinal(ExchangePacketConfig.ExchangeLimitField);
                    int coExchangePoints = dr.GetOrdinal(ExchangePacketConfig.ExchangePointsField);
                    int coExchangeTypeId = dr.GetOrdinal(ExchangePacketConfig.ExchangeTypeIdField);

                    if (dr.Read())
                    {
                        exchangePacketConfig.Id = dr.GetInt32(coId);
                        exchangePacketConfig.ExchangeId = dr.GetInt32(coExchangeId);
                        exchangePacketConfig.PacketId = dr.GetInt64(coPacketId);
                        exchangePacketConfig.PacketName = dr.GetString(coPacketName);
                        exchangePacketConfig.PacketDesc = dr.IsDBNull(coPacketDesc) ? string.Empty : dr.GetString(coPacketDesc);
                        exchangePacketConfig.ExchangeLimit = dr.GetInt32(coExchangeLimit);
                        exchangePacketConfig.ExchangePoints = dr.GetInt32(coExchangePoints);
                        exchangePacketConfig.ExchangeTypeId = dr.GetInt32(coExchangeTypeId);
                    }
                }
            }

            return exchangePacketConfig;
        }

        /// <summary>
        /// 获取 ExchangePacketConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 11:18:23
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchExchangePacketConfig">ExchangePacketConfig 查询实体</param>
        /// <returns></returns>
        public List<ExchangePacketConfig> GetExchangePacketConfigList(ref DataPage dp)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<ExchangePacketConfig> exchangePacketConfigList = new List<ExchangePacketConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(ExchangePacketConfig.IdField);
                    int coExchangeId = dr.GetOrdinal(ExchangePacketConfig.ExchangeIdField);
                    int coPacketId = dr.GetOrdinal(ExchangePacketConfig.PacketIdField);
                    int coPacketName = dr.GetOrdinal(ExchangePacketConfig.PacketNameField);
                    int coPacketDesc = dr.GetOrdinal(ExchangePacketConfig.PacketDescField);
                    int coExchangeLimit = dr.GetOrdinal(ExchangePacketConfig.ExchangeLimitField);
                    int coExchangePoints = dr.GetOrdinal(ExchangePacketConfig.ExchangePointsField);
                    int coExchangeTypeId = dr.GetOrdinal(ExchangePacketConfig.ExchangeTypeIdField);
                    int coPacketCount = dr.GetOrdinal(ExchangePacketConfig.PacketCountField);
                    while (dr.Read())
                    {
                        ExchangePacketConfig exchangePacketConfig = new ExchangePacketConfig();

                        exchangePacketConfig.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        exchangePacketConfig.ExchangeId = dr.IsDBNull(coExchangeId) ? (int)0 : dr.GetInt32(coExchangeId);
                        exchangePacketConfig.PacketId = dr.IsDBNull(coPacketId) ? (long)0 : dr.GetInt64(coPacketId);
                        exchangePacketConfig.PacketName = dr.IsDBNull(coPacketName) ? string.Empty : dr.GetString(coPacketName);
                        exchangePacketConfig.PacketDesc = dr.IsDBNull(coPacketDesc) ? string.Empty : dr.GetString(coPacketDesc);
                        exchangePacketConfig.ExchangeLimit = dr.IsDBNull(coExchangeLimit) ? (int)0 : dr.GetInt32(coExchangeLimit);
                        exchangePacketConfig.ExchangePoints = dr.IsDBNull(coExchangePoints) ? (int)0 : dr.GetInt32(coExchangePoints);
                        exchangePacketConfig.ExchangeTypeId = dr.IsDBNull(coExchangeTypeId) ? (int)0 : dr.GetInt32(coExchangeTypeId);
                        exchangePacketConfig.PacketCount = dr.IsDBNull(coPacketCount) ? (int)0 : dr.GetInt32(coPacketCount);
                        exchangePacketConfigList.Add(exchangePacketConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return exchangePacketConfigList;
        }


        #endregion

        #region BasicConfig

        /// <summary>
        /// 更新 BasicConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 12:12:48
        /// <param name="basicConfig">BasicConfig 实体</param>
        /// <returns></returns>
        public Int32 UpdateBasicConfig(BasicConfig basicConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("BasicConfig_Update");
            DB.AddInParameter(cmd, BasicConfig.ConfigIdField, DbType.Int32, basicConfig.ConfigId);
            DB.AddInParameter(cmd, BasicConfig.ConfigValueField, DbType.Int64, basicConfig.ConfigValue);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }





        /// <summary>
        /// 获取 BasicConfig 全部数据
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 12:12:48
        /// <returns></returns>
        public List<BasicConfig> GetBasicConfigAll()
        {
            DbCommand cmd = DB.GetStoredProcCommand("BasicConfig_GetAll");

            List<BasicConfig> basicConfigList = new List<BasicConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coConfigId = dr.GetOrdinal(BasicConfig.ConfigIdField);
                    int coConfigName = dr.GetOrdinal(BasicConfig.ConfigNameField);
                    int coConfigValue = dr.GetOrdinal(BasicConfig.ConfigValueField);

                    while (dr.Read())
                    {
                        BasicConfig basicConfig = new BasicConfig();

                        basicConfig.ConfigId = dr.IsDBNull(coConfigId) ? (int)0 : dr.GetInt32(coConfigId);
                        basicConfig.ConfigName = dr.IsDBNull(coConfigName) ? string.Empty : dr.GetString(coConfigName);
                        basicConfig.ConfigValue = dr.IsDBNull(coConfigValue) ? (long)0 : dr.GetInt64(coConfigValue);

                        basicConfigList.Add(basicConfig);
                    }
                }
            }

            return basicConfigList;
        }






        /// <summary>
        /// 根据ID获取 BasicConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/14 12:20:05
        /// <param name="basicConfig">BasicConfig 实体</param>
        /// <returns></returns>
        public BasicConfig GetBasicConfig(BasicConfig searchBasicConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("BasicConfig_GetByConfigId");
            DB.AddInParameter(cmd, BasicConfig.ConfigIdField, DbType.Int32, searchBasicConfig.ConfigId);

            BasicConfig basicConfig = new BasicConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coConfigId = dr.GetOrdinal(BasicConfig.ConfigIdField);
                    int coConfigName = dr.GetOrdinal(BasicConfig.ConfigNameField);
                    int coConfigValue = dr.GetOrdinal(BasicConfig.ConfigValueField);

                    if (dr.Read())
                    {
                        basicConfig.ConfigId = dr.GetInt32(coConfigId);
                        basicConfig.ConfigName = dr.GetString(coConfigName);
                        basicConfig.ConfigValue = dr.GetInt64(coConfigValue);
                    }
                }
            }

            return basicConfig;
        }


        #endregion

        #region TransferData_All_ReportDateConfig
        /// <summary>
        /// 增加 TransferData_All_ReportDateConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:28:08
        /// <param name="transferDataAllReportDateConfig">TransferData_All_ReportDateConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataAllReportDateConfigAdd(TransferData_All_ReportDateConfig transferDataAllReportDateConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_All_ReportDateConfig_Add");
            DB.AddParameter(cmd, TransferData_All_ReportDateConfig.ConfigIdField, DbType.Int32, ParameterDirection.InputOutput, TransferData_All_ReportDateConfig.ConfigIdField, DataRowVersion.Current, transferDataAllReportDateConfig.ConfigId);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.ConfigNameField, DbType.String, transferDataAllReportDateConfig.ConfigName);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.StatusField, DbType.Int32, transferDataAllReportDateConfig.Status);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.ReportIdField, DbType.Int32, transferDataAllReportDateConfig.ReportId);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.StartTimeField, DbType.DateTime, transferDataAllReportDateConfig.StartTime);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.EndTimeField, DbType.DateTime, transferDataAllReportDateConfig.EndTime);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.CreateTimeField, DbType.DateTime, transferDataAllReportDateConfig.CreateTime);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            transferDataAllReportDateConfig.ConfigId = Convert.ToInt32(DB.GetParameterValue(cmd, "ConfigId"));

            return transferDataAllReportDateConfig.ConfigId;
        }

        /// <summary>
        /// 更新 TransferData_All_ReportDateConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:28:08
        /// <param name="transferDataAllReportDateConfig">TransferData_All_ReportDateConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataAllReportDateConfigUpdate(TransferData_All_ReportDateConfig transferDataAllReportDateConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_All_ReportDateConfig_Update");
            DB.AddParameter(cmd, TransferData_All_ReportDateConfig.ConfigIdField, DbType.Int32, ParameterDirection.InputOutput, TransferData_All_ReportDateConfig.ConfigIdField, DataRowVersion.Current, transferDataAllReportDateConfig.ConfigId);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.ConfigNameField, DbType.String, transferDataAllReportDateConfig.ConfigName);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.StatusField, DbType.Int32, transferDataAllReportDateConfig.Status);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.ReportIdField, DbType.Int32, transferDataAllReportDateConfig.ReportId);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.StartTimeField, DbType.DateTime, transferDataAllReportDateConfig.StartTime);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.EndTimeField, DbType.DateTime, transferDataAllReportDateConfig.EndTime);
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.CreateTimeField, DbType.DateTime, transferDataAllReportDateConfig.CreateTime);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 TransferData_All_ReportDateConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:28:08
        /// <param name="transferDataAllReportDateConfig">TransferData_All_ReportDateConfig 实体</param>
        /// <returns></returns>
        public bool TransferDataAllReportDateConfigDel(TransferData_All_ReportDateConfig transferDataAllReportDateConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_All_ReportDateConfig_Del");
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.ConfigIdField, DbType.Int32, transferDataAllReportDateConfig.ConfigId);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 TransferData_All_ReportDateConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:28:08
        /// <param name="transferDataAllReportDateConfig">TransferData_All_ReportDateConfig 实体</param>
        /// <returns></returns>
        public TransferData_All_ReportDateConfig TransferDataAllReportDateConfigGetByConfigId(TransferData_All_ReportDateConfig searchTransferDataAllReportDateConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_All_ReportDateConfig_GetByConfigId");
            DB.AddInParameter(cmd, TransferData_All_ReportDateConfig.ConfigIdField, DbType.Int32, searchTransferDataAllReportDateConfig.ConfigId);

            TransferData_All_ReportDateConfig transferDataAllReportDateConfig = new TransferData_All_ReportDateConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coConfigId = dr.GetOrdinal(TransferData_All_ReportDateConfig.ConfigIdField);
                    int coConfigName = dr.GetOrdinal(TransferData_All_ReportDateConfig.ConfigNameField);
                    int coStatus = dr.GetOrdinal(TransferData_All_ReportDateConfig.StatusField);
                    int coReportId = dr.GetOrdinal(TransferData_All_ReportDateConfig.ReportIdField);
                    int coStartTime = dr.GetOrdinal(TransferData_All_ReportDateConfig.StartTimeField);
                    int coEndTime = dr.GetOrdinal(TransferData_All_ReportDateConfig.EndTimeField);
                    int coCreateTime = dr.GetOrdinal(TransferData_All_ReportDateConfig.CreateTimeField);

                    if (dr.Read())
                    {
                        transferDataAllReportDateConfig.ConfigId = dr.GetInt32(coConfigId);
                        transferDataAllReportDateConfig.ConfigName = dr.GetString(coConfigName);
                        transferDataAllReportDateConfig.Status = dr.GetInt32(coStatus);
                        transferDataAllReportDateConfig.ReportId = dr.GetInt32(coReportId);
                        transferDataAllReportDateConfig.StartTime = dr.GetDateTime(coStartTime);
                        transferDataAllReportDateConfig.EndTime = dr.GetDateTime(coEndTime);
                        transferDataAllReportDateConfig.CreateTime = dr.GetDateTime(coCreateTime);
                    }
                }
            }

            return transferDataAllReportDateConfig;
        }

        /// <summary>
        /// 获取 TransferData_All_ReportDateConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:28:08
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchTransferDataAllReportDateConfig">TransferData_All_ReportDateConfig 查询实体</param>
        /// <returns></returns>
        public List<TransferData_All_ReportDateConfig> TransferDataAllReportDateConfigGetList(ref DataPage dp, TransferData_All_ReportDateConfig searchTransferDataAllReportDateConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_All_ReportDateConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<TransferData_All_ReportDateConfig> transferDataAllReportDateConfigList = new List<TransferData_All_ReportDateConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coConfigId = dr.GetOrdinal(TransferData_All_ReportDateConfig.ConfigIdField);
                    int coConfigName = dr.GetOrdinal(TransferData_All_ReportDateConfig.ConfigNameField);
                    int coStatus = dr.GetOrdinal(TransferData_All_ReportDateConfig.StatusField);
                    int coReportId = dr.GetOrdinal(TransferData_All_ReportDateConfig.ReportIdField);
                    int coStartTime = dr.GetOrdinal(TransferData_All_ReportDateConfig.StartTimeField);
                    int coEndTime = dr.GetOrdinal(TransferData_All_ReportDateConfig.EndTimeField);
                    int coCreateTime = dr.GetOrdinal(TransferData_All_ReportDateConfig.CreateTimeField);

                    while (dr.Read())
                    {
                        TransferData_All_ReportDateConfig transferDataAllReportDateConfig = new TransferData_All_ReportDateConfig();

                        transferDataAllReportDateConfig.ConfigId = dr.IsDBNull(coConfigId) ? (int)0 : dr.GetInt32(coConfigId);
                        transferDataAllReportDateConfig.ConfigName = dr.IsDBNull(coConfigName) ? string.Empty : dr.GetString(coConfigName);
                        transferDataAllReportDateConfig.Status = dr.IsDBNull(coStatus) ? (int)0 : dr.GetInt32(coStatus);
                        transferDataAllReportDateConfig.ReportId = dr.IsDBNull(coReportId) ? (int)0 : dr.GetInt32(coReportId);
                        transferDataAllReportDateConfig.StartTime = dr.IsDBNull(coStartTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coStartTime);
                        transferDataAllReportDateConfig.EndTime = dr.IsDBNull(coEndTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coEndTime);
                        transferDataAllReportDateConfig.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);

                        transferDataAllReportDateConfigList.Add(transferDataAllReportDateConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return transferDataAllReportDateConfigList;
        }    



        #endregion

        #region TransferData_GameDetails_ItemConfig
        /// <summary>
        /// 增加 TransferData_GameDetails_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:31:53
        /// <param name="transferDataGameDetailsItemConfig">TransferData_GameDetails_ItemConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataGameDetailsItemConfigAdd(TransferData_GameDetails_ItemConfig transferDataGameDetailsItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_ItemConfig_Add");
            DB.AddParameter(cmd, TransferData_GameDetails_ItemConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, TransferData_GameDetails_ItemConfig.IdField, DataRowVersion.Current, transferDataGameDetailsItemConfig.Id);
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ItemIdField, DbType.Int32, transferDataGameDetailsItemConfig.ItemId);

            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ItemNameField, DbType.String, transferDataGameDetailsItemConfig.ItemName);
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ShowNameField, DbType.String, transferDataGameDetailsItemConfig.ShowName);
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.StatusField, DbType.Int32, transferDataGameDetailsItemConfig.Status);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            transferDataGameDetailsItemConfig.Id = Convert.ToInt32(DB.GetParameterValue(cmd, "Id"));

            return transferDataGameDetailsItemConfig.Id;
        }

        /// <summary>
        /// 更新 TransferData_GameDetails_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:31:53
        /// <param name="transferDataGameDetailsItemConfig">TransferData_GameDetails_ItemConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataGameDetailsItemConfigUpdate(TransferData_GameDetails_ItemConfig transferDataGameDetailsItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_ItemConfig_Update");
            DB.AddParameter(cmd, TransferData_GameDetails_ItemConfig.ItemIdField, DbType.Int32, ParameterDirection.InputOutput, TransferData_GameDetails_ItemConfig.ItemIdField, DataRowVersion.Current, transferDataGameDetailsItemConfig.ItemId);
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ItemNameField, DbType.String, transferDataGameDetailsItemConfig.ItemName);
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ShowNameField, DbType.String, transferDataGameDetailsItemConfig.ShowName);
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.StatusField, DbType.Int32, transferDataGameDetailsItemConfig.Status);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 TransferData_GameDetails_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:31:53
        /// <param name="transferDataGameDetailsItemConfig">TransferData_GameDetails_ItemConfig 实体</param>
        /// <returns></returns>
        public bool TransferDataGameDetailsItemConfigDel(TransferData_GameDetails_ItemConfig transferDataGameDetailsItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_ItemConfig_Del");
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ItemIdField, DbType.Int32, transferDataGameDetailsItemConfig.ItemId);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 TransferData_GameDetails_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:31:53
        /// <param name="transferDataGameDetailsItemConfig">TransferData_GameDetails_ItemConfig 实体</param>
        /// <returns></returns>
        public TransferData_GameDetails_ItemConfig TransferDataGameDetailsItemConfigGetByItemId(TransferData_GameDetails_ItemConfig searchTransferDataGameDetailsItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_ItemConfig_GetByItemId");
            DB.AddInParameter(cmd, TransferData_GameDetails_ItemConfig.ItemIdField, DbType.Int32, searchTransferDataGameDetailsItemConfig.ItemId);

            TransferData_GameDetails_ItemConfig transferDataGameDetailsItemConfig = new TransferData_GameDetails_ItemConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.IdField);
                    int coItemId = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.ItemIdField);
                    int coItemName = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.ItemNameField);
                    int coShowName = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.ShowNameField);
                    int coStatus = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.StatusField);

                    if (dr.Read())
                    {
                        transferDataGameDetailsItemConfig.Id = dr.GetInt32(coId);
                        transferDataGameDetailsItemConfig.ItemId = dr.GetInt32(coItemId);
                        transferDataGameDetailsItemConfig.ItemName = dr.GetString(coItemName);
                        transferDataGameDetailsItemConfig.ShowName = dr.GetString(coShowName);
                        transferDataGameDetailsItemConfig.Status = dr.GetInt32(coStatus);
                    }
                }
            }

            return transferDataGameDetailsItemConfig;
        }

        /// <summary>
        /// 获取 TransferData_GameDetails_ItemConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:31:53
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchTransferDataGameDetailsItemConfig">TransferData_GameDetails_ItemConfig 查询实体</param>
        /// <returns></returns>
        public List<TransferData_GameDetails_ItemConfig> TransferDataGameDetailsItemConfigGetList(ref DataPage dp, TransferData_GameDetails_ItemConfig searchTransferDataGameDetailsItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_ItemConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<TransferData_GameDetails_ItemConfig> transferDataGameDetailsItemConfigList = new List<TransferData_GameDetails_ItemConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.IdField);
                    int coItemId = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.ItemIdField);
                    int coItemName = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.ItemNameField);
                    int coShowName = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.ShowNameField);
                    int coStatus = dr.GetOrdinal(TransferData_GameDetails_ItemConfig.StatusField);

                    while (dr.Read())
                    {
                        TransferData_GameDetails_ItemConfig transferDataGameDetailsItemConfig = new TransferData_GameDetails_ItemConfig();

                        transferDataGameDetailsItemConfig.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        transferDataGameDetailsItemConfig.ItemId = dr.IsDBNull(coItemId) ? (int)0 : dr.GetInt32(coItemId);
                        transferDataGameDetailsItemConfig.ItemName = dr.IsDBNull(coItemName) ? string.Empty : dr.GetString(coItemName);
                        transferDataGameDetailsItemConfig.ShowName = dr.IsDBNull(coShowName) ? string.Empty : dr.GetString(coShowName);
                        transferDataGameDetailsItemConfig.Status = dr.IsDBNull(coStatus) ? (int)0 : dr.GetInt32(coStatus);

                        transferDataGameDetailsItemConfigList.Add(transferDataGameDetailsItemConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return transferDataGameDetailsItemConfigList;
        }    



        #endregion

        #region TransferData_GameDetails_UsersConfig
        /// <summary>
        /// 增加 TransferData_GameDetails_UsersConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:13
        /// <param name="transferDataGameDetailsUsersConfig">TransferData_GameDetails_UsersConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataGameDetailsUsersConfigAdd(TransferData_GameDetails_UsersConfig transferDataGameDetailsUsersConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_UsersConfig_Add");
            DB.AddParameter(cmd, TransferData_GameDetails_UsersConfig.IdField, DbType.Int64, ParameterDirection.InputOutput, TransferData_GameDetails_UsersConfig.IdField, DataRowVersion.Current, transferDataGameDetailsUsersConfig.Id);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.RankOrderField, DbType.Int32, transferDataGameDetailsUsersConfig.RankOrder);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.UserIdField, DbType.Int64, transferDataGameDetailsUsersConfig.UserId);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.AreaIdField, DbType.Int32, transferDataGameDetailsUsersConfig.AreaId);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.AvatarIdField, DbType.Int64, transferDataGameDetailsUsersConfig.AvatarId);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.AvatarNameField, DbType.String, transferDataGameDetailsUsersConfig.AvatarName);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.CreateTimeField, DbType.DateTime, transferDataGameDetailsUsersConfig.CreateTime);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.FromIdField, DbType.Int64, transferDataGameDetailsUsersConfig.FromId);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            int rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

        public Int32 TransferDataGameDetailsUsersConfigBatchAdd(List<TransferData_GameDetails_UsersConfig> listuserconfig)
        {
            int result = 0;
            foreach (TransferData_GameDetails_UsersConfig userconfig in listuserconfig)
            {
                int rs = TransferDataGameDetailsUsersConfigAdd(userconfig);
                result = rs + result;
            }
            return result;
        }

        /// <summary>
        /// 更新 TransferData_GameDetails_UsersConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:13
        /// <param name="transferDataGameDetailsUsersConfig">TransferData_GameDetails_UsersConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataGameDetailsUsersConfigUpdate(TransferData_GameDetails_UsersConfig transferDataGameDetailsUsersConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_UsersConfig_Update");
            DB.AddParameter(cmd, TransferData_GameDetails_UsersConfig.IdField, DbType.Int64, ParameterDirection.InputOutput, TransferData_GameDetails_UsersConfig.IdField, DataRowVersion.Current, transferDataGameDetailsUsersConfig.Id);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.RankOrderField, DbType.Int32, transferDataGameDetailsUsersConfig.RankOrder);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.UserIdField, DbType.Int64, transferDataGameDetailsUsersConfig.UserId);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.AreaIdField, DbType.Int32, transferDataGameDetailsUsersConfig.AreaId);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.AvatarIdField, DbType.Int64, transferDataGameDetailsUsersConfig.AvatarId);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.AvatarNameField, DbType.String, transferDataGameDetailsUsersConfig.AvatarName);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.CreateTimeField, DbType.DateTime, transferDataGameDetailsUsersConfig.CreateTime);
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.FromIdField, DbType.Int64, transferDataGameDetailsUsersConfig.FromId);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 TransferData_GameDetails_UsersConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:13
        /// <param name="transferDataGameDetailsUsersConfig">TransferData_GameDetails_UsersConfig 实体</param>
        /// <returns></returns>
        public bool TransferDataGameDetailsUsersConfigDel(TransferData_GameDetails_UsersConfig transferDataGameDetailsUsersConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_UsersConfig_Del");
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.IdField, DbType.Int64, transferDataGameDetailsUsersConfig.Id);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 TransferData_GameDetails_UsersConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:13
        /// <param name="transferDataGameDetailsUsersConfig">TransferData_GameDetails_UsersConfig 实体</param>
        /// <returns></returns>
        public TransferData_GameDetails_UsersConfig TransferDataGameDetailsUsersConfigGetById(TransferData_GameDetails_UsersConfig searchTransferDataGameDetailsUsersConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_UsersConfig_GetById");
            DB.AddInParameter(cmd, TransferData_GameDetails_UsersConfig.IdField, DbType.Int64, searchTransferDataGameDetailsUsersConfig.Id);

            TransferData_GameDetails_UsersConfig transferDataGameDetailsUsersConfig = new TransferData_GameDetails_UsersConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.IdField);
                    int coRankOrder = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.RankOrderField);
                    int coUserId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.UserIdField);
                    int coAreaId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.AvatarNameField);
                    int coCreateTime = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.CreateTimeField);
                    int coFromId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.FromIdField);

                    if (dr.Read())
                    {
                        transferDataGameDetailsUsersConfig.Id = dr.GetInt64(coId);
                        transferDataGameDetailsUsersConfig.RankOrder = dr.GetInt32(coRankOrder);
                        transferDataGameDetailsUsersConfig.UserId = dr.GetInt64(coUserId);
                        transferDataGameDetailsUsersConfig.AreaId = dr.GetInt32(coAreaId);
                        transferDataGameDetailsUsersConfig.AvatarId = dr.GetInt64(coAvatarId);
                        transferDataGameDetailsUsersConfig.AvatarName = dr.GetString(coAvatarName);
                        transferDataGameDetailsUsersConfig.CreateTime = dr.GetDateTime(coCreateTime);
                        transferDataGameDetailsUsersConfig.FromId = dr.GetInt64(coFromId);
                    }
                }
            }

            return transferDataGameDetailsUsersConfig;
        }

        /// <summary>
        /// 获取 TransferData_GameDetails_UsersConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:13
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchTransferDataGameDetailsUsersConfig">TransferData_GameDetails_UsersConfig 查询实体</param>
        /// <returns></returns>
        public List<TransferData_GameDetails_UsersConfig> TransferDataGameDetailsUsersConfigGetList(ref DataPage dp, TransferData_GameDetails_UsersConfig searchTransferDataGameDetailsUsersConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_GameDetails_UsersConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<TransferData_GameDetails_UsersConfig> transferDataGameDetailsUsersConfigList = new List<TransferData_GameDetails_UsersConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.IdField);
                    int coRankOrder = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.RankOrderField);
                    int coUserId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.UserIdField);
                    int coAreaId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.AvatarNameField);
                    int coCreateTime = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.CreateTimeField);
                    int coFromId = dr.GetOrdinal(TransferData_GameDetails_UsersConfig.FromIdField);
                    while (dr.Read())
                    {
                        TransferData_GameDetails_UsersConfig transferDataGameDetailsUsersConfig = new TransferData_GameDetails_UsersConfig();

                        transferDataGameDetailsUsersConfig.Id = dr.IsDBNull(coId) ? (long)0 : dr.GetInt64(coId);
                        transferDataGameDetailsUsersConfig.RankOrder = dr.IsDBNull(coRankOrder) ? (int)0 : dr.GetInt32(coRankOrder);
                        transferDataGameDetailsUsersConfig.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        transferDataGameDetailsUsersConfig.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        transferDataGameDetailsUsersConfig.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        transferDataGameDetailsUsersConfig.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        transferDataGameDetailsUsersConfig.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        transferDataGameDetailsUsersConfig.FromId = dr.IsDBNull(coFromId) ? (long)0 : dr.GetInt64(coFromId);
                        transferDataGameDetailsUsersConfigList.Add(transferDataGameDetailsUsersConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return transferDataGameDetailsUsersConfigList;
        }    



        #endregion

        #region TransferData_ItemConsume_ItemConfig
        /// <summary>
        /// 增加 TransferData_ItemConsume_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:39
        /// <param name="transferDataItemConsumeItemConfig">TransferData_ItemConsume_ItemConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataItemConsumeItemConfigAdd(TransferData_ItemConsume_ItemConfig transferDataItemConsumeItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_ItemConsume_ItemConfig_Add");
            DB.AddParameter(cmd, TransferData_ItemConsume_ItemConfig.IdField, DbType.Int32, ParameterDirection.InputOutput, TransferData_ItemConsume_ItemConfig.IdField, DataRowVersion.Current, transferDataItemConsumeItemConfig.Id);
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ItemIdField, DbType.Int32, transferDataItemConsumeItemConfig.ItemId);

            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ItemNameField, DbType.String, transferDataItemConsumeItemConfig.ItemName);
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ShowNameField, DbType.String, transferDataItemConsumeItemConfig.ShowName);
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.StatusField, DbType.Int32, transferDataItemConsumeItemConfig.Status);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            transferDataItemConsumeItemConfig.Id = Convert.ToInt32(DB.GetParameterValue(cmd, "Id"));

            return transferDataItemConsumeItemConfig.Id;
        }

        /// <summary>
        /// 更新 TransferData_ItemConsume_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:39
        /// <param name="transferDataItemConsumeItemConfig">TransferData_ItemConsume_ItemConfig 实体</param>
        /// <returns></returns>
        public Int32 TransferDataItemConsumeItemConfigUpdate(TransferData_ItemConsume_ItemConfig transferDataItemConsumeItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_ItemConsume_ItemConfig_Update");
            DB.AddParameter(cmd, TransferData_ItemConsume_ItemConfig.ItemIdField, DbType.Int32, ParameterDirection.InputOutput, TransferData_ItemConsume_ItemConfig.ItemIdField, DataRowVersion.Current, transferDataItemConsumeItemConfig.ItemId);
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ItemNameField, DbType.String, transferDataItemConsumeItemConfig.ItemName);
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ShowNameField, DbType.String, transferDataItemConsumeItemConfig.ShowName);
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.StatusField, DbType.Int32, transferDataItemConsumeItemConfig.Status);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }



        /// <summary>
        /// 删除 TransferData_ItemConsume_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:39
        /// <param name="transferDataItemConsumeItemConfig">TransferData_ItemConsume_ItemConfig 实体</param>
        /// <returns></returns>
        public bool TransferDataItemConsumeItemConfigDel(TransferData_ItemConsume_ItemConfig transferDataItemConsumeItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_ItemConsume_ItemConfig_Del");
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ItemIdField, DbType.Int32, transferDataItemConsumeItemConfig.ItemId);

            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            return true;
        }

        /// <summary>
        /// 根据ID获取 TransferData_ItemConsume_ItemConfig
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:39
        /// <param name="transferDataItemConsumeItemConfig">TransferData_ItemConsume_ItemConfig 实体</param>
        /// <returns></returns>
        public TransferData_ItemConsume_ItemConfig TransferDataItemConsumeItemConfigGetByItemId(TransferData_ItemConsume_ItemConfig searchTransferDataItemConsumeItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_ItemConsume_ItemConfig_GetByItemId");
            DB.AddInParameter(cmd, TransferData_ItemConsume_ItemConfig.ItemIdField, DbType.Int32, searchTransferDataItemConsumeItemConfig.ItemId);

            TransferData_ItemConsume_ItemConfig transferDataItemConsumeItemConfig = new TransferData_ItemConsume_ItemConfig();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.IdField);
                    int coItemId = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.ItemIdField);
                    int coItemName = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.ItemNameField);
                    int coShowName = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.ShowNameField);
                    int coStatus = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.StatusField);

                    if (dr.Read())
                    {
                        transferDataItemConsumeItemConfig.Id = dr.GetInt32(coId);
                        transferDataItemConsumeItemConfig.ItemId = dr.GetInt32(coItemId);
                        transferDataItemConsumeItemConfig.ItemName = dr.GetString(coItemName);
                        transferDataItemConsumeItemConfig.ShowName = dr.GetString(coShowName);
                        transferDataItemConsumeItemConfig.Status = dr.GetInt32(coStatus);
                    }
                }
            }

            return transferDataItemConsumeItemConfig;
        }

        /// <summary>
        /// 获取 TransferData_ItemConsume_ItemConfig 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 10:32:39
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchTransferDataItemConsumeItemConfig">TransferData_ItemConsume_ItemConfig 查询实体</param>
        /// <returns></returns>
        public List<TransferData_ItemConsume_ItemConfig> TransferDataItemConsumeItemConfigGetList(ref DataPage dp, TransferData_ItemConsume_ItemConfig searchTransferDataItemConsumeItemConfig)
        {
            DbCommand cmd = DB.GetStoredProcCommand("TransferData_ItemConsume_ItemConfig_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<TransferData_ItemConsume_ItemConfig> transferDataItemConsumeItemConfigList = new List<TransferData_ItemConsume_ItemConfig>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.IdField);
                    int coItemId = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.ItemIdField);
                    int coItemName = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.ItemNameField);
                    int coShowName = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.ShowNameField);
                    int coStatus = dr.GetOrdinal(TransferData_ItemConsume_ItemConfig.StatusField);

                    while (dr.Read())
                    {
                        TransferData_ItemConsume_ItemConfig transferDataItemConsumeItemConfig = new TransferData_ItemConsume_ItemConfig();

                        transferDataItemConsumeItemConfig.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        transferDataItemConsumeItemConfig.ItemId = dr.IsDBNull(coItemId) ? (int)0 : dr.GetInt32(coItemId);
                        transferDataItemConsumeItemConfig.ItemName = dr.IsDBNull(coItemName) ? string.Empty : dr.GetString(coItemName);
                        transferDataItemConsumeItemConfig.ShowName = dr.IsDBNull(coShowName) ? string.Empty : dr.GetString(coShowName);
                        transferDataItemConsumeItemConfig.Status = dr.IsDBNull(coStatus) ? (int)0 : dr.GetInt32(coStatus);

                        transferDataItemConsumeItemConfigList.Add(transferDataItemConsumeItemConfig);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return transferDataItemConsumeItemConfigList;
        }    



        #endregion

        #region ImportCSV
        public Int32 importCSVtoDB(DataSet ds, string TableName)
        {
            try
            {
                string connectionStrings = DB.ConnectionString;
                SqlBulkCopy bcp = new SqlBulkCopy(connectionStrings);
                bcp.BatchSize = 50;//每次传输的行数  
                bcp.NotifyAfter = 50;//进度提示的行数 

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    bcp.ColumnMappings.Add(ds.Tables[0].Columns[i].ColumnName, ds.Tables[0].Columns[i].ColumnName);
                }
                bcp.DestinationTableName = TableName;//目标表  
                SqlConnection con = new SqlConnection(connectionStrings);
                string sqlcomm = "delete from " + TableName;
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlcomm, con);
                cmd.ExecuteNonQuery();
                con.Close();
                bcp.WriteToServer(ds.Tables[0]);
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region Report

        /// <summary>
        /// 增加 DailyReportTotalPeople
        /// </summary>
        /// Create By zhouqi
        /// 2017/5/31 15:50:51
        /// <param name="dailyReportTotalPeople">DailyReportTotalPeople 实体</param>
        /// <returns></returns>
        public Int32 AddDailyReportTotalPeople(DailyReportTotalPeople dailyReportTotalPeople)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DailyReport_TotalPeople_Refresh");

            DB.AddInParameter(cmd, DailyReportTotalPeople.RefreshCurrentField, DbType.Int32, dailyReportTotalPeople.RefreshCurrent);


            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            int rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 获取 DailyReportTotalPeople 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/5/31 15:50:51
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchDailyReportTotalPeople">DailyReportTotalPeople 查询实体</param>
        /// <returns></returns>
        public List<DailyReportTotalPeople> GetDailyReportTotalPeopleList(ref DataPage dp, DailyReportTotalPeople searchDailyReportTotalPeople)
        {
            DbCommand cmd = DB.GetStoredProcCommand("DailyReport_TotalPeople_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<DailyReportTotalPeople> dailyReportTotalPeopleList = new List<DailyReportTotalPeople>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(DailyReportTotalPeople.IdField);
                    int coReportDate = dr.GetOrdinal(DailyReportTotalPeople.ReportDateField);
                    int coDrawPacketPeople = dr.GetOrdinal(DailyReportTotalPeople.DrawPacketPeopleField);
                    int coAllPacketPeople = dr.GetOrdinal(DailyReportTotalPeople.AllPacketPeopleField);
                    int coCreateTs = dr.GetOrdinal(DailyReportTotalPeople.CreateTsField);

                    while (dr.Read())
                    {
                        DailyReportTotalPeople dailyReportTotalPeople = new DailyReportTotalPeople();

                        dailyReportTotalPeople.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        dailyReportTotalPeople.ReportDate = dr.IsDBNull(coReportDate) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coReportDate);
                        dailyReportTotalPeople.DrawPacketPeople = dr.IsDBNull(coDrawPacketPeople) ? (int)0 : dr.GetInt32(coDrawPacketPeople);
                        dailyReportTotalPeople.AllPacketPeople = dr.IsDBNull(coAllPacketPeople) ? (int)0 : dr.GetInt32(coAllPacketPeople);
                        dailyReportTotalPeople.CreateTs = dr.IsDBNull(coCreateTs) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTs);

                        dailyReportTotalPeopleList.Add(dailyReportTotalPeople);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return dailyReportTotalPeopleList;
        }


        /// <summary>
        /// 获取 DailyReportItemConsume 全部数据
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/1 15:51:18
        /// <returns></returns>
        public List<DailyReportItemConsume> GetDailyReportItemConsumeAll()
        {
            DbCommand cmd = DB.GetStoredProcCommand("DailyReport_ItemConsume_GetAll");

            List<DailyReportItemConsume> dailyReportItemConsumeList = new List<DailyReportItemConsume>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(DailyReportItemConsume.IdField);
                    int coReportDate = dr.GetOrdinal(DailyReportItemConsume.ReportDateField);
                    int coItemId = dr.GetOrdinal(DailyReportItemConsume.ItemIdField);
                    int coItemName = dr.GetOrdinal(DailyReportItemConsume.ItemNameField);
                    int coTotalConsume = dr.GetOrdinal(DailyReportItemConsume.TotalConsumeField);
                    int coCreateTs = dr.GetOrdinal(DailyReportItemConsume.CreateTsField);

                    while (dr.Read())
                    {
                        DailyReportItemConsume dailyReportItemConsume = new DailyReportItemConsume();

                        dailyReportItemConsume.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        dailyReportItemConsume.ReportDate = dr.IsDBNull(coReportDate) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coReportDate);
                        dailyReportItemConsume.ItemId = dr.IsDBNull(coItemId) ? (int)0 : dr.GetInt32(coItemId);
                        dailyReportItemConsume.ItemName = dr.IsDBNull(coItemName) ? string.Empty : dr.GetString(coItemName);
                        dailyReportItemConsume.TotalConsume = dr.IsDBNull(coTotalConsume) ? (int)0 : dr.GetInt32(coTotalConsume);
                        dailyReportItemConsume.CreateTs = dr.IsDBNull(coCreateTs) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTs);

                        dailyReportItemConsumeList.Add(dailyReportItemConsume);
                    }
                }
            }

            return dailyReportItemConsumeList;
        }


        /// <summary>
        /// 获取 DailyReportGameDetailsPerUser 全部数据
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/7 12:00:11
        /// <returns></returns>
        public List<DailyReportGameDetailsPerUser> GetDailyReportGameDetailsPerUserAll()
        {
            DbCommand cmd = DB.GetStoredProcCommand("DailyReport_GameDetailsPerUser_GetAll");

            List<DailyReportGameDetailsPerUser> dailyReportGameDetailsPerUserList = new List<DailyReportGameDetailsPerUser>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(DailyReportGameDetailsPerUser.IdField);
                    int coRankOrder = dr.GetOrdinal(DailyReportGameDetailsPerUser.RankOrderField);
                    int coUserId = dr.GetOrdinal(DailyReportGameDetailsPerUser.UserIdField);
                    int coAreaId = dr.GetOrdinal(DailyReportGameDetailsPerUser.AreaIdField);
                    int coAvatarId = dr.GetOrdinal(DailyReportGameDetailsPerUser.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(DailyReportGameDetailsPerUser.AvatarNameField);
                    int coStatisticalItem = dr.GetOrdinal(DailyReportGameDetailsPerUser.StatisticalItemField);
                    int coStatisticalResult = dr.GetOrdinal(DailyReportGameDetailsPerUser.StatisticalResultField);
                    int coCreateTime = dr.GetOrdinal(DailyReportGameDetailsPerUser.CreateTimeField);
                    int coFromId = dr.GetOrdinal(DailyReportGameDetailsPerUser.FromIdField);

                    while (dr.Read())
                    {
                        DailyReportGameDetailsPerUser dailyReportGameDetailsPerUser = new DailyReportGameDetailsPerUser();

                        dailyReportGameDetailsPerUser.Id = dr.IsDBNull(coId) ? (long)0 : dr.GetInt64(coId);
                        dailyReportGameDetailsPerUser.RankOrder = dr.IsDBNull(coRankOrder) ? (int)0 : dr.GetInt32(coRankOrder);
                        dailyReportGameDetailsPerUser.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        dailyReportGameDetailsPerUser.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        dailyReportGameDetailsPerUser.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        dailyReportGameDetailsPerUser.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        dailyReportGameDetailsPerUser.StatisticalItem = dr.IsDBNull(coStatisticalItem) ? string.Empty : dr.GetString(coStatisticalItem);
                        dailyReportGameDetailsPerUser.StatisticalResult = dr.IsDBNull(coStatisticalResult) ? (long)0 : dr.GetInt64(coStatisticalResult);
                        dailyReportGameDetailsPerUser.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        dailyReportGameDetailsPerUser.FromId = dr.IsDBNull(coFromId) ? (long)0 : dr.GetInt64(coFromId);
                        dailyReportGameDetailsPerUserList.Add(dailyReportGameDetailsPerUser);
                    }
                }
            }

            return dailyReportGameDetailsPerUserList;
        }

        /// <summary>
        /// 获取 RankList_TopN 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/6/12 11:50:52
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchRankListTopN">RankList_TopN 查询实体</param>
        /// <returns></returns>
        public List<RankList_TopN> GetRankListTopNList(ref DataPage dp, RankList_TopN searchRankListTopN)
        {
            DbCommand cmd = DB.GetStoredProcCommand("RankList_TopN_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, RankList_TopN.IdField, DbType.Int64, searchRankListTopN.Id);
            DB.AddInParameter(cmd, RankList_TopN.UserIdField, DbType.Int64, searchRankListTopN.UserId);
            DB.AddInParameter(cmd, RankList_TopN.RankOrderField, DbType.Int32, searchRankListTopN.RankOrder);
            DB.AddInParameter(cmd, RankList_TopN.CutOffDateField, DbType.DateTime, searchRankListTopN.CutOffDate);

            List<RankList_TopN> rankListTopNList = new List<RankList_TopN>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(RankList_TopN.IdField);
                    int coUserId = dr.GetOrdinal(RankList_TopN.UserIdField);
                    int coAvatarId = dr.GetOrdinal(RankList_TopN.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(RankList_TopN.AvatarNameField);
                    int coAreaId = dr.GetOrdinal(RankList_TopN.AreaIdField);
                    int coAreaName = dr.GetOrdinal(RankList_TopN.AreaNameField);
                    int coGetPoints = dr.GetOrdinal(RankList_TopN.GetPointsField);
                    int coCreateTime = dr.GetOrdinal(RankList_TopN.CreateTimeField);
                    int coRankOrder = dr.GetOrdinal(RankList_TopN.RankOrderField);
                    int coGetLastTime = dr.GetOrdinal(RankList_TopN.GetLastTimeField);
                    int coCutOffDate = dr.GetOrdinal(RankList_TopN.CutOffDateField);

                    while (dr.Read())
                    {
                        RankList_TopN rankListTopN = new RankList_TopN();

                        rankListTopN.Id = dr.IsDBNull(coId) ? (long)0 : dr.GetInt64(coId);
                        rankListTopN.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        rankListTopN.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        rankListTopN.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        rankListTopN.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        rankListTopN.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        rankListTopN.GetPoints = dr.IsDBNull(coGetPoints) ? (int)0 : dr.GetInt32(coGetPoints);
                        rankListTopN.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        rankListTopN.RankOrder = dr.IsDBNull(coRankOrder) ? (int)0 : dr.GetInt32(coRankOrder);
                        rankListTopN.GetLastTime = dr.IsDBNull(coGetLastTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coGetLastTime);
                        rankListTopN.CutOffDate = dr.IsDBNull(coCutOffDate) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCutOffDate);

                        rankListTopNList.Add(rankListTopN);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return rankListTopNList;
        }

        public int RefreshTopNList()
        {
            DbCommand cmd = DB.GetStoredProcCommand("TopRank_TopN");
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            //无异常就返回true
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

        #endregion

    }
}
