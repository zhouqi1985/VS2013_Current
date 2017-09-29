using CommonLibs.Common;
using CommonLibs.Common.Enums;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace PuzzleEvent.DAL
{
    public class PuzzleEventDAL : CommonLibs.EnterpriseLibrary.DatabaseAccessBase, IPuzzleEventDAL
    {
        public PuzzleEventDAL()
            : base("PuzzleEventDB")
        { }



        /// <summary>
        /// 获取 UserPiecesTotal 全部数据
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/5 18:44:26
        /// <returns></returns>
        public List<UserPiecesTotal> GetUserPiecesTotalAll(UserPiecesTotal userpiecestotal)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UserPiecesTotal_GetAll");
            DB.AddInParameter(cmd, UserPiecesTotal.AreaIDField, DbType.Int32, userpiecestotal.AreaID);
            DB.AddInParameter(cmd, UserPiecesTotal.UserIdField, DbType.Int64, userpiecestotal.UserId);
            List<UserPiecesTotal> userPiecesTotalList = new List<UserPiecesTotal>();
            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coRecordID = dr.GetOrdinal(UserPiecesTotal.RecordIDField);
                    int coUserId = dr.GetOrdinal(UserPiecesTotal.UserIdField);
                    int coAreaID = dr.GetOrdinal(UserPiecesTotal.AreaIDField);
                    int coPiecesTotal = dr.GetOrdinal(UserPiecesTotal.PiecesTotalField);
                    int coPiecesConsume = dr.GetOrdinal(UserPiecesTotal.PiecesConsumeField);
                    int coPiecesBalance = dr.GetOrdinal(UserPiecesTotal.PiecesBalanceField);
                    int coPiecesOccupied = dr.GetOrdinal(UserPiecesTotal.PiecesOccupiedField);
                    int coPuzzleTypeID = dr.GetOrdinal(UserPiecesTotal.PuzzleTypeIDField);
                    int coRemainPoints = dr.GetOrdinal(UserPiecesTotal.RemainPointsField);
                    int coIsFirst = dr.GetOrdinal(UserPiecesTotal.IsFirstField);
                    while (dr.Read())
                    {
                        UserPiecesTotal userPiecesTotal = new UserPiecesTotal();

                        userPiecesTotal.RecordID = dr.IsDBNull(coRecordID) ? (long)0 : dr.GetInt64(coRecordID);
                        userPiecesTotal.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        userPiecesTotal.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        userPiecesTotal.PiecesTotal = dr.IsDBNull(coPiecesTotal) ? (long)0 : dr.GetInt64(coPiecesTotal);
                        userPiecesTotal.PiecesConsume = dr.IsDBNull(coPiecesConsume) ? (int)0 : dr.GetInt32(coPiecesConsume);
                        userPiecesTotal.PiecesBalance = dr.IsDBNull(coPiecesBalance) ? (int)0 : dr.GetInt32(coPiecesBalance);
                        userPiecesTotal.PiecesOccupied = dr.IsDBNull(coPiecesOccupied) ? (int)0 : dr.GetInt32(coPiecesOccupied);
                        userPiecesTotal.PuzzleTypeID = dr.IsDBNull(coPuzzleTypeID) ? (int)0 : dr.GetInt32(coPuzzleTypeID);
                        userPiecesTotal.RemainPoints = dr.IsDBNull(coRemainPoints) ? (int)0 : dr.GetInt32(coRemainPoints);
                        userPiecesTotal.IsFirst = dr.IsDBNull(coIsFirst) ? (int)0 : dr.GetInt32(coIsFirst);
                        userPiecesTotalList.Add(userPiecesTotal);
                    }
                }
            }

            //UserPiecesTotal UserPoints = new UserPiecesTotal();
            //UserPoints.RemainPoints = Convert.ToInt64(DB.GetParameterValue(cmd, UserPiecesTotal.RemainPointsField));
            //userPiecesTotalList.Add(UserPoints);
            return userPiecesTotalList;
        }

        public Int32 AddOrdinaryPacketReceive(UserSearch ordinaryPacketReceive)
        {
            DbCommand cmd = DB.GetStoredProcCommand("OrdinaryPacketReceive_Add");
            DB.AddInParameter(cmd, ExchangePacket.UserIdField, DbType.Int64, ordinaryPacketReceive.UserId);
            DB.AddInParameter(cmd, ExchangePacket.AvatarIdField, DbType.Int64, ordinaryPacketReceive.AvatarID);
            DB.AddInParameter(cmd, ExchangePacket.SexField, DbType.Int32, ordinaryPacketReceive.Sex);
            DB.AddInParameter(cmd, ExchangePacket.GameAreaField, DbType.Int32, ordinaryPacketReceive.AreaID);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            return rs;
        }

        /// <summary>
        /// 增加 ExchangePacketReceive
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/6 16:13:42
        /// <param name="exchangePacketReceive">ExchangePacketReceive 实体</param>
        /// <returns></returns>
        public Int32 AddExchangePacketReceive(UserSearch exchangePacketReceive, ref bool IsNotice, ref string PacketName)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketReceive_Add");
            DB.AddParameter(cmd, ExchangePacket.IsNoticeField, DbType.Boolean, ParameterDirection.Output, ExchangePacket.IsNoticeField, DataRowVersion.Current, IsNotice);
            //DB.AddParameter(cmd, ExchangePacket.PacketNameField, DbType.String, ParameterDirection.Output, ExchangePacket.PacketNameField, DataRowVersion.Current, PacketName);
            DB.AddInParameter(cmd, ExchangePacket.UserIdField, DbType.Int64, exchangePacketReceive.UserId);
            DB.AddInParameter(cmd, ExchangePacket.AvatarIdField, DbType.Int64, exchangePacketReceive.AvatarID);
            DB.AddInParameter(cmd, ExchangePacket.SexField, DbType.Int32, exchangePacketReceive.Sex);
            DB.AddInParameter(cmd, ExchangePacket.GameAreaField, DbType.Int32, exchangePacketReceive.AreaID);
            DB.AddInParameter(cmd, ExchangePacket.PacketIdField, DbType.Int64, exchangePacketReceive.PacketID);
            DB.AddInParameter(cmd, ExchangePacket.PuzzleTypeIDField, DbType.Int32, exchangePacketReceive.PuzzleTypeID);

            DB.AddOutParameter(cmd, ExchangePacket.PacketNameField, DbType.String, 255);


            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            IsNotice = Convert.ToBoolean(DB.GetParameterValue(cmd, "IsNotice").ToString());
            PacketName = Convert.ToString(DB.GetParameterValue(cmd, "PacketName").ToString());
            return rs;
        }


        /// <summary>
        /// 根据ID获取 PiecesReceive
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/6 16:43:36
        /// <param name="piecesReceive">PiecesReceive 实体</param>
        /// <returns></returns>
        public List<PuzzlePieces> GetPiecesReceive(UserSearch searchPiecesReceive)
        {
            List<PuzzlePieces> PuzzlePiecesLists = new List<PuzzlePieces>();
            DbCommand cmd = DB.GetStoredProcCommand("PiecesReceive_GetByUser");
            DB.AddInParameter(cmd, UserSearch.UserIdField, DbType.Int64, searchPiecesReceive.UserId);
            DB.AddInParameter(cmd, UserSearch.AreaIDField, DbType.Int32, searchPiecesReceive.AreaID);

            PuzzlePieces piecesReceive = new PuzzlePieces();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {

                    int coPuzzleName = dr.GetOrdinal(PuzzlePieces.PuzzleNameField);
                    int coPuzzlePieceName = dr.GetOrdinal(PuzzlePieces.PuzzlePieceNameField);
                    int coPieceOrder = dr.GetOrdinal(PuzzlePieces.PieceOrderField);
                    int coPuzzleID = dr.GetOrdinal(PuzzlePieces.PuzzleIDField);
                    while (dr.Read())
                    {
                        PuzzlePieces puzzlepieces = new PuzzlePieces();
                        puzzlepieces.PuzzleName = dr.IsDBNull(coPuzzleName) ? string.Empty : dr.GetString(coPuzzleName);
                        puzzlepieces.PuzzlePieceName = dr.IsDBNull(coPuzzlePieceName) ? string.Empty : dr.GetString(coPuzzlePieceName);
                        puzzlepieces.PieceOrder = dr.IsDBNull(coPieceOrder) ? (int)0 : dr.GetInt32(coPieceOrder);
                        puzzlepieces.PuzzleID = dr.IsDBNull(coPuzzleID) ? (int)0 : dr.GetInt32(coPuzzleID);
                        PuzzlePiecesLists.Add(puzzlepieces);
                    }
                }
            }

            return PuzzlePiecesLists;
        }

        /// <summary>
        /// 增加 PuzzleDrawDetails
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/6 17:42:46
        /// <param name="puzzleDrawDetails">PuzzleDrawDetails 实体</param>
        /// <returns></returns>
        public Int32 AddPuzzleDrawDetails(PuzzleDrawDetails puzzleDrawDetails)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleDrawDetails_Add");
            DB.AddParameter(cmd, PuzzleDrawDetails.PuzzleDrawIDField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.PuzzleDrawIDField, DataRowVersion.Current, puzzleDrawDetails.PuzzleDrawID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.UserIDField, DbType.Int64, puzzleDrawDetails.UserID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.LoginNameField, DbType.String, puzzleDrawDetails.LoginName);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AreaIDField, DbType.Int32, puzzleDrawDetails.AreaID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AvatarIDField, DbType.Int64, puzzleDrawDetails.AvatarID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AvatarNameField, DbType.String, puzzleDrawDetails.AvatarName);
            DB.AddInParameter(cmd, PuzzleDrawDetails.DrawCountField, DbType.Int32, puzzleDrawDetails.DrawCount);
            DB.AddInParameter(cmd, PuzzleDrawDetails.ActualCountField, DbType.Int32, puzzleDrawDetails.ActualCount);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PuzzleTypeIdField, DbType.Int32, puzzleDrawDetails.PuzzleTypeId);
            DB.AddInParameter(cmd, PuzzleDrawDetails.SexField, DbType.Int32, puzzleDrawDetails.Sex);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            puzzleDrawDetails.PuzzleDrawID = Convert.ToInt32(DB.GetParameterValue(cmd, "PuzzleDrawID"));

            return puzzleDrawDetails.PuzzleDrawID;
        }

        /// <summary>
        /// 增加 PiecesPacketDetails
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/6 17:49:35
        /// <param name="piecesPacketDetails">PiecesPacketDetails 实体</param>
        /// <returns></returns>
        public PuzzleDrawDetails AddPiecesPacketDetails(PuzzleDrawDetails piecesPacketDetails)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PiecesPacketDetails_Add");
            //DB.AddParameter(cmd, PuzzleDrawDetails.AwardNameField, DbType.String, ParameterDirection.InputOutput, PuzzleDrawDetails.AwardNameField, DataRowVersion.Current, piecesPacketDetails.AwardName);
            DB.AddParameter(cmd, PuzzleDrawDetails.IsNoticeField, DbType.Boolean, ParameterDirection.InputOutput, PuzzleDrawDetails.IsNoticeField, DataRowVersion.Current, piecesPacketDetails.IsNotice);
            DB.AddParameter(cmd, PuzzleDrawDetails.IsPuzzleField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.IsPuzzleField, DataRowVersion.Current, piecesPacketDetails.PuzzleDrawID);
            DB.AddParameter(cmd, PuzzleDrawDetails.IsCompleteField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.IsCompleteField, DataRowVersion.Current, piecesPacketDetails.IsComplete);
            //DB.AddParameter(cmd, PuzzleDrawDetails.AwardPuzzlePacketField, DbType.String, ParameterDirection.InputOutput, PuzzleDrawDetails.AwardPuzzlePacketField, DataRowVersion.Current, piecesPacketDetails.AwardPuzzlePacket);
            DB.AddParameter(cmd, PuzzleDrawDetails.PuzzleNoticeField, DbType.Boolean, ParameterDirection.InputOutput, PuzzleDrawDetails.PuzzleNoticeField, DataRowVersion.Current, piecesPacketDetails.PuzzleNotice);
            DB.AddParameter(cmd, PuzzleDrawDetails.PuzzleIDField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.PuzzleIDField, DataRowVersion.Current, piecesPacketDetails.PuzzleID);
            DB.AddParameter(cmd, PuzzleDrawDetails.PiecesOrderField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.PiecesOrderField, DataRowVersion.Current, piecesPacketDetails.PiecesOrder);
            DB.AddParameter(cmd, PuzzleDrawDetails.PuzzleRandomField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.PuzzleRandomField, DataRowVersion.Current, piecesPacketDetails.PuzzleRandom);
            DB.AddOutParameter(cmd, PuzzleDrawDetails.AwardNameField, DbType.String, 255);
            DB.AddOutParameter(cmd, PuzzleDrawDetails.AwardPuzzlePacketField, DbType.String, 255);

            DB.AddInParameter(cmd, PuzzleDrawDetails.UserIDField, DbType.Int64, piecesPacketDetails.UserID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AreaIDField, DbType.Int32, piecesPacketDetails.AreaID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AvatarIDField, DbType.Int64, piecesPacketDetails.AvatarID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.SexField, DbType.Int32, piecesPacketDetails.Sex);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PointsField, DbType.Int32, piecesPacketDetails.Points);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PuzzleTypeIdField, DbType.Int32, piecesPacketDetails.PuzzleTypeId);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PuzzleDrawIDField, DbType.Int32, piecesPacketDetails.PuzzleDrawID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.RateField, DbType.Int32, piecesPacketDetails.Rate);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PacketRateField, DbType.Int32, piecesPacketDetails.PacketRate);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AllPiecesRateField, DbType.Int32, piecesPacketDetails.AllPiecesRate);

            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);
            PuzzleDrawDetails piecesPacket = new PuzzleDrawDetails();
            piecesPacket.AwardName = Convert.ToString(DB.GetParameterValue(cmd, "AwardName"));
            piecesPacket.IsNotice = Convert.ToBoolean(DB.GetParameterValue(cmd, "IsNotice"));
            piecesPacket.IsComplete = Convert.ToInt32(DB.GetParameterValue(cmd, "IsComplete"));
            piecesPacket.IsPuzzle = Convert.ToInt32(DB.GetParameterValue(cmd, "IsPuzzle"));
            piecesPacket.AwardPuzzlePacket = Convert.ToString(DB.GetParameterValue(cmd, "AwardPuzzlePacket"));
            piecesPacket.PuzzleNotice = Convert.ToBoolean(DB.GetParameterValue(cmd, "PuzzleNotice"));
            piecesPacket.DrawRS = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            piecesPacket.PuzzleID = Convert.ToInt32(DB.GetParameterValue(cmd, "PuzzleID"));
            piecesPacket.PiecesOrder = Convert.ToInt32(DB.GetParameterValue(cmd, "PiecesOrder"));
            piecesPacket.PuzzleRandom = Convert.ToInt32(DB.GetParameterValue(cmd, "PuzzleRandom"));
            return piecesPacket;
        }


        /// <summary>
        /// 获取 RankList 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/7 10:42:58
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchRankList">RankList 查询实体</param>
        /// <returns></returns>
        public List<RankList> GetRankListList(ref DataPage dp, RankList searchRankList)
        {
            DbCommand cmd = DB.GetStoredProcCommand("RankList_GetList");
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
                    int coGameArea = dr.GetOrdinal(RankList.GameAreaField);
                    int coAreaName = dr.GetOrdinal(RankList.AreaNameField);
                    int coUsedPoints = dr.GetOrdinal(RankList.UsedPointsField);
                    int coCreateTime = dr.GetOrdinal(RankList.CreateTimeField);
                    int coRankOrder = dr.GetOrdinal(RankList.RankOrderField);

                    while (dr.Read())
                    {
                        RankList rankList = new RankList();

                        rankList.Id = dr.IsDBNull(coId) ? (int)0 : dr.GetInt32(coId);
                        rankList.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        rankList.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        rankList.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        rankList.GameArea = dr.IsDBNull(coGameArea) ? (int)0 : dr.GetInt32(coGameArea);
                        rankList.AreaName = dr.IsDBNull(coAreaName) ? string.Empty : dr.GetString(coAreaName);
                        rankList.UsedPoints = dr.IsDBNull(coUsedPoints) ? (int)0 : dr.GetInt32(coUsedPoints);
                        rankList.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        rankList.RankOrder = dr.IsDBNull(coRankOrder) ? (int)0 : dr.GetInt32(coRankOrder);

                        rankListList.Add(rankList);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return rankListList;
        }



        public List<PuzzleDrawDetails> PuzzleDraw(PuzzleDrawDetails piecesPacketDetails)
        {
            int randend = 3;
            DbConnection conn = DB.CreateConnection();
            conn.Open();
            DbTransaction tran = conn.BeginTransaction();
            try
            {

                piecesPacketDetails.PuzzleDrawID = AddPuzzleDrawDetails(piecesPacketDetails);
                if (piecesPacketDetails.PuzzleDrawID < 1)
                    tran.Rollback();

                List<PuzzleDrawDetails> list = new List<PuzzleDrawDetails>();
                if (piecesPacketDetails.PuzzleTypeId == 3)
                {
                    randend = 25;
                }
                for (int i = 0; i < piecesPacketDetails.DrawCount; i++)
                {


                    piecesPacketDetails.Rate = GetRandomNum(1, 10000);
                    piecesPacketDetails.PacketRate = GetRandomNum(1, 10000);
                    piecesPacketDetails.AllPiecesRate = GetRandomNum(1, 10000);
                    piecesPacketDetails.Points = 1;
                    piecesPacketDetails.PuzzleRandom = GetRandomNum(1, randend);
                    PuzzleDrawDetails onedraw = new PuzzleDrawDetails();
                    onedraw = AddPiecesPacketDetails(piecesPacketDetails);
                    //System.Threading.Thread.Sleep(500);
                    if (onedraw.DrawRS == 1)
                    { list.Add(onedraw); }
                   
                }
                if (piecesPacketDetails.ExtraCount > 0)
                    for (int i = 0; i < piecesPacketDetails.ExtraCount; i++)
                    {
                        piecesPacketDetails.Rate = GetRandomNum(1, 10000);
                        piecesPacketDetails.PacketRate = GetRandomNum(1, 10000);
                        piecesPacketDetails.AllPiecesRate = GetRandomNum(1, 10000);
                        piecesPacketDetails.Points = 0;
                        piecesPacketDetails.PuzzleRandom = GetRandomNum(1, randend);
                        PuzzleDrawDetails onedraw = new PuzzleDrawDetails();
                        onedraw = AddPiecesPacketDetails(piecesPacketDetails);
                        if (onedraw.DrawRS == 1)
                        { list.Add(onedraw); }
                       
                    }
                tran.Commit();
                return list;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        public int GetRedPacket(long userid, int areaId)
        {
            DbCommand cmd = DB.GetStoredProcCommand("GetRedPacket");

            DB.AddInParameter(cmd, "UserID", DbType.Int64, userid);
            DB.AddInParameter(cmd, "GameAreaId", DbType.Int32, areaId);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            return rs;

        }


        public PuzzleDrawDetails PuzzleReceive(PuzzleDrawDetails PuzzleDrawDetails)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleReceiveDetails_Add");
            DB.AddInParameter(cmd, PuzzleDrawDetails.UserIDField, DbType.Int64, PuzzleDrawDetails.UserID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AreaIDField, DbType.Int32, PuzzleDrawDetails.AreaID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AvatarIDField, DbType.Int64, PuzzleDrawDetails.AvatarID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.CreateTSField, DbType.DateTime, PuzzleDrawDetails.CreateTS);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PuzzleIDField, DbType.Int32, PuzzleDrawDetails.PuzzleID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PuzzleTypeIdField, DbType.Int32, PuzzleDrawDetails.PuzzleTypeId);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AllPiecesRateField, DbType.Int32, PuzzleDrawDetails.AllPiecesRate);
            DB.AddOutParameter(cmd, PuzzleDrawDetails.AwardPuzzlePacketField, DbType.String, 255);
            DB.AddParameter(cmd, PuzzleDrawDetails.IsCompleteField, DbType.Int32, ParameterDirection.InputOutput, PuzzleDrawDetails.IsCompleteField, DataRowVersion.Current, PuzzleDrawDetails.IsComplete);
            //   DB.AddParameter(cmd, PuzzleDrawDetails.AwardPuzzlePacketField, DbType.String, ParameterDirection.InputOutput, PuzzleDrawDetails.AwardPuzzlePacketField, DataRowVersion.Current, PuzzleDrawDetails.AwardPuzzlePacket);
            DB.AddParameter(cmd, PuzzleDrawDetails.PuzzleNoticeField, DbType.Boolean, ParameterDirection.InputOutput, PuzzleDrawDetails.PuzzleNoticeField, DataRowVersion.Current, PuzzleDrawDetails.PuzzleNotice);
            DB.AddInParameter(cmd, PuzzleDrawDetails.SexField, DbType.Int32, PuzzleDrawDetails.Sex);

            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);
            PuzzleDrawDetails Packet = new PuzzleDrawDetails();
            PuzzleDrawDetails.IsComplete = Convert.ToInt32(DB.GetParameterValue(cmd, "IsComplete"));
            PuzzleDrawDetails.AwardPuzzlePacket = Convert.ToString(DB.GetParameterValue(cmd, "AwardPuzzlePacket"));
            PuzzleDrawDetails.PuzzleNotice = Convert.ToBoolean(DB.GetParameterValue(cmd, "PuzzleNotice"));
            //注意：
            //增加方法 如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1
            //更新方法 如果更新成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1
            //删除方法 如果删除成功，返回ID，如果失败，返回0
            // int rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));
            Packet = PuzzleDrawDetails;
            return Packet;
        }




        private int GetRandomNum(int start, int end)
        {
            end = end + 1;
            Guid guid = Guid.NewGuid();
            int num = guid.GetHashCode();
            Random a = new Random(num);
            int randNum = a.Next(start, end);
            return randNum;
        }

    }
}
