using CharmEvents.Database.Database;
using CommonLibs.Common;
using CommonLibs.Common.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace CharmEvents.DAL
{
    public class CharmEventsDAL : CommonLibs.EnterpriseLibrary.DatabaseAccessBase, ICharmEventsDAL
    {
        public CharmEventsDAL() : base("CharmEventsDB") { }

        public List<ResultInfo> GetUserInfo(UserInfo userinfo)
        {
            DbCommand cmd = DB.GetStoredProcCommand("GetUserInfo");
            DB.AddInParameter(cmd, UserInfo.UserIdField, DbType.Int64, userinfo.UserId);
            DB.AddInParameter(cmd, UserInfo.AvatarIdField, DbType.Int64, userinfo.AvatarId);
            DB.AddInParameter(cmd, UserInfo.AreaIDField, DbType.Int32, userinfo.AreaID);
            List<ResultInfo> resultinfos = new List<ResultInfo>();
            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coTotalPoints = dr.GetOrdinal(ResultInfo.TotalPointsField);
                    int coBalancePoints = dr.GetOrdinal(ResultInfo.BalancePointsField);
                    int coExchangeId = dr.GetOrdinal(ResultInfo.ExchangeIdField);
                    int coExchangeTotal = dr.GetOrdinal(ResultInfo.ExchangeTotalField);
                    int coCutOffDate = dr.GetOrdinal(ResultInfo.CutOffDateField);

                    while (dr.Read())
                    {
                        ResultInfo resultinfo = new ResultInfo();
                        resultinfo.TotalPoints = dr.IsDBNull(coTotalPoints) ? (int)0 : dr.GetInt32(coTotalPoints);
                        resultinfo.BalancePoints = dr.IsDBNull(coBalancePoints) ? (int)0 : dr.GetInt32(coBalancePoints);
                        resultinfo.ExchangeId = dr.IsDBNull(coExchangeId) ? (int)0 : dr.GetInt32(coExchangeId);
                        resultinfo.ExchangeTotal = dr.IsDBNull(coExchangeTotal) ? (int)0 : dr.GetInt32(coExchangeTotal);
                        resultinfo.CutOffDate = dr.IsDBNull(coCutOffDate) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCutOffDate);
                        resultinfos.Add(resultinfo);
                    }
                }
            }

            return resultinfos;
        }

        public ResultInfo UsersExchangePackets(UserInfo userinfo)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UsersExchangePackets");
            DB.AddInParameter(cmd, UserInfo.UserIdField, DbType.Int64, userinfo.UserId);
            DB.AddInParameter(cmd, UserInfo.AvatarIdField, DbType.Int64, userinfo.AvatarId);
            DB.AddInParameter(cmd, UserInfo.AreaIDField, DbType.Int32, userinfo.AreaID);
            DB.AddInParameter(cmd, UserInfo.SexField, DbType.Int32, userinfo.Sex);
            DB.AddInParameter(cmd, UserInfo.LoginNameField, DbType.String, userinfo.LoginName);
            DB.AddInParameter(cmd, UserInfo.AvatarNameField, DbType.String, userinfo.AvatarName);
            DB.AddInParameter(cmd, UserInfo.ExchangeIDField, DbType.Int32, userinfo.ExchangeID);
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            ResultInfo resultinfo = new ResultInfo();
            resultinfo.Result = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            return resultinfo;
        }

        public ResultInfo UsersDrawPackets(UserInfo userinfo)
        {
            ResultInfo resultinfo = new ResultInfo();
            DbCommand cmd = DB.GetStoredProcCommand("UsersDrawPackets");
            DB.AddInParameter(cmd, UserInfo.UserIdField, DbType.Int64, userinfo.UserId);
            DB.AddInParameter(cmd, UserInfo.AvatarIdField, DbType.Int64, userinfo.AvatarId);
            DB.AddInParameter(cmd, UserInfo.AreaIDField, DbType.Int32, userinfo.AreaID);
            DB.AddInParameter(cmd, UserInfo.SexField, DbType.Int32, userinfo.Sex);
            DB.AddInParameter(cmd, UserInfo.LoginNameField, DbType.String, userinfo.LoginName);
            DB.AddInParameter(cmd, UserInfo.AvatarNameField, DbType.String, userinfo.AvatarName);
            DB.AddParameter(cmd, ResultInfo.PacketNameField, DbType.String, 200, ParameterDirection.Output, true, 0, 0, ResultInfo.PacketNameField, DataRowVersion.Default, resultinfo.PacketName);
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            resultinfo.Result = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            resultinfo.PacketName = Convert.ToString(DB.GetParameterValue(cmd, ResultInfo.PacketNameField));
            return resultinfo;
        }

        public ResultInfo UsersLoginPacket(UserInfo userinfo)
        {
            ResultInfo resultinfo = new ResultInfo();
            DbCommand cmd = DB.GetStoredProcCommand("UsersLoginPacket");
            DB.AddInParameter(cmd, UserInfo.UserIdField, DbType.Int64, userinfo.UserId);
            DB.AddInParameter(cmd, UserInfo.AvatarIdField, DbType.Int64, userinfo.AvatarId);
            DB.AddInParameter(cmd, UserInfo.AreaIDField, DbType.Int32, userinfo.AreaID);
            DB.AddInParameter(cmd, UserInfo.SexField, DbType.Int32, userinfo.Sex);
            DB.AddInParameter(cmd, UserInfo.LoginNameField, DbType.String, userinfo.LoginName);
            DB.AddInParameter(cmd, UserInfo.AvatarNameField, DbType.String, userinfo.AvatarName);
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            resultinfo.Result = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            return resultinfo;
        }


        /// <summary>
        /// 获取 RankList 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2017/4/12 18:23:38
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchRankList">RankList 查询实体</param>
        /// <returns></returns>
        public List<RankList> GetRankListList(ref DataPage dp)
        {
            DbCommand cmd = DB.GetStoredProcCommand("GetRankList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<RankList> rankListList = new List<RankList>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coId = dr.GetOrdinal(RankList.IdField);
                    int coUserId = dr.GetOrdinal(RankList.UserIdField);
                    int coAvatarId = dr.GetOrdinal(RankList.AvatarIdField);
                    int coAvatarName = dr.GetOrdinal(RankList.AvatarNameField);
                    int coAreaId = dr.GetOrdinal(RankList.AreaIdField);
                    int coAreaName = dr.GetOrdinal(RankList.AreaNameField);
                    int coGetPoints = dr.GetOrdinal(RankList.GetPointsField);
                    int coCreateTime = dr.GetOrdinal(RankList.CreateTimeField);
                    int coRankOrder = dr.GetOrdinal(RankList.RankOrderField);
                    int coGetLastTime = dr.GetOrdinal(RankList.GetLastTimeField);
                    int coCutOffDate = dr.GetOrdinal(RankList.CutOffDateField);

                    while (dr.Read())
                    {
                        RankList rankList = new RankList();

                        rankList.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        rankList.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        rankList.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        rankList.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        rankList.AreaId = dr.IsDBNull(coAreaId) ? (int)0 : dr.GetInt32(coAreaId);
                        rankList.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        rankList.GetPoints = dr.IsDBNull(coGetPoints) ? (int)0 : dr.GetInt32(coGetPoints);
                        rankList.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        rankList.RankOrder = dr.IsDBNull(coRankOrder) ? (int)0 : dr.GetInt32(coRankOrder);
                        rankList.GetLastTime = dr.IsDBNull(coGetLastTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coGetLastTime);
                        rankList.CutOffDate = dr.IsDBNull(coCutOffDate) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCutOffDate);
                        rankListList.Add(rankList);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return rankListList;
        }


    }
}
