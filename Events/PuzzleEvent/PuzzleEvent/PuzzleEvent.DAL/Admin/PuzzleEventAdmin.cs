using CommonLibs.Common;
using CommonLibs.Common.Enums;
using PuzzleEvent.Database.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace PuzzleEvent.DAL.Admin
{
    public class PuzzleEventAdmin : CommonLibs.EnterpriseLibrary.DatabaseAccessBase, IPuzzleEventAdmin
    {
        public PuzzleEventAdmin()
            : base("PuzzleEventDB")
        { }
        #region 添加积分
        public Int64 AddWallet(Wallet wallet)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Wallet_Add");
            DB.AddParameter(cmd, Wallet.WIdField, DbType.Int64, ParameterDirection.InputOutput, Wallet.WIdField, DataRowVersion.Current, wallet.WId);
            DB.AddInParameter(cmd, Wallet.PaymentIdField, DbType.Int64, wallet.PaymentId);
            DB.AddInParameter(cmd, Wallet.UserIdField, DbType.Int64, wallet.UserId);
            DB.AddInParameter(cmd, Wallet.LoginNameField, DbType.String, wallet.LoginName);
            DB.AddInParameter(cmd, Wallet.GameAreaIdField, DbType.Int32, wallet.GameAreaId);
            DB.AddInParameter(cmd, Wallet.TotalPointsField, DbType.Int32, wallet.TotalPoints);
            DB.AddInParameter(cmd, Wallet.BalancePointsField, DbType.Int32, wallet.BalancePoints);
            DB.AddInParameter(cmd, Wallet.NoteField, DbType.String, wallet.Note);
            DB.AddInParameter(cmd, Wallet.CreateTimeField, DbType.DateTime, wallet.CreateTime);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            wallet.WId = Convert.ToInt64(DB.GetParameterValue(cmd, "WId"));

            return wallet.WId;
        }

        public List<Wallet> GetWalletList(ref DataPage dp, Wallet searchWallet)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Wallet_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, Wallet.UserIdField, DbType.Int64, searchWallet.UserId);

            List<Wallet> walletList = new List<Wallet>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coWId = dr.GetOrdinal(Wallet.WIdField);
                    int coPaymentId = dr.GetOrdinal(Wallet.PaymentIdField);
                    int coUserId = dr.GetOrdinal(Wallet.UserIdField);
                    int coLoginName = dr.GetOrdinal(Wallet.LoginNameField);
                    int coGameAreaId = dr.GetOrdinal(Wallet.GameAreaIdField);
                    int coTotalPoints = dr.GetOrdinal(Wallet.TotalPointsField);
                    int coBalancePoints = dr.GetOrdinal(Wallet.BalancePointsField);
                    int coNote = dr.GetOrdinal(Wallet.NoteField);
                    int coCreateTime = dr.GetOrdinal(Wallet.CreateTimeField);

                    while (dr.Read())
                    {
                        Wallet wallet = new Wallet();

                        wallet.WId = dr.IsDBNull(coWId) ? (long)0 : dr.GetInt64(coWId);
                        wallet.PaymentId = dr.IsDBNull(coPaymentId) ? (long)0 : dr.GetInt64(coPaymentId);
                        wallet.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        wallet.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);
                        wallet.GameAreaId = dr.IsDBNull(coGameAreaId) ? (int)0 : dr.GetInt32(coGameAreaId);
                        wallet.TotalPoints = dr.IsDBNull(coTotalPoints) ? (int)0 : dr.GetInt32(coTotalPoints);
                        wallet.BalancePoints = dr.IsDBNull(coBalancePoints) ? (int)0 : dr.GetInt32(coBalancePoints);
                        wallet.Note = dr.IsDBNull(coNote) ? string.Empty : dr.GetString(coNote);
                        wallet.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);

                        walletList.Add(wallet);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return walletList;
        }
        #endregion

        #region 后台配置
        /// <summary>
        /// 更新 ExchangePacket
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 19:58:52
        /// <param name="exchangePacket">ExchangePacket 实体</param>
        /// <returns></returns>
        public Int64 UpdateExchangePacket(ExchangePacket exchangePacket)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacket_Update");
            DB.AddParameter(cmd, ExchangePacket.PacketIdField, DbType.Int64, ParameterDirection.InputOutput, ExchangePacket.PacketIdField, DataRowVersion.Current, exchangePacket.PacketId);
            DB.AddParameter(cmd, ExchangePacket.PuzzleTypeIDField, DbType.Int32, ParameterDirection.InputOutput, ExchangePacket.PuzzleTypeIDField, DataRowVersion.Current, exchangePacket.PuzzleTypeID);
            DB.AddInParameter(cmd, ExchangePacket.PacketNameField, DbType.String, exchangePacket.PacketName);
            DB.AddInParameter(cmd, ExchangePacket.PacketDescField, DbType.String, exchangePacket.PacketDesc);
            DB.AddInParameter(cmd, ExchangePacket.NeedPointsField, DbType.Int32, exchangePacket.NeedPoints);
            DB.AddInParameter(cmd, ExchangePacket.IsNoticeField, DbType.Boolean, exchangePacket.IsNotice);
            DB.AddInParameter(cmd, ExchangePacket.IsLimitField, DbType.Boolean, exchangePacket.IsLimit);
            DB.AddInParameter(cmd, ExchangePacket.LimitCountField, DbType.Int32, exchangePacket.LimitCount);
            DB.AddInParameter(cmd, ExchangePacket.IsDeleteField, DbType.Int32, exchangePacket.IsDelete);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int64 rs = Convert.ToInt64(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 根据ID获取 ExchangePacket
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 19:58:52
        /// <param name="exchangePacket">ExchangePacket 实体</param>
        /// <returns></returns>
        public ExchangePacket GetExchangePacket(ExchangePacket searchExchangePacket)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacket_GetByPacketId");
            DB.AddInParameter(cmd, ExchangePacket.PacketIdField, DbType.Int64, searchExchangePacket.PacketId);
            DB.AddInParameter(cmd, ExchangePacket.PuzzleTypeIDField, DbType.Int32, searchExchangePacket.PuzzleTypeID);
            ExchangePacket exchangePacket = new ExchangePacket();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPacketId = dr.GetOrdinal(ExchangePacket.PacketIdField);
                    int coPacketName = dr.GetOrdinal(ExchangePacket.PacketNameField);
                    int coPacketDesc = dr.GetOrdinal(ExchangePacket.PacketDescField);
                    int coPuzzleTypeID = dr.GetOrdinal(ExchangePacket.PuzzleTypeIDField);
                    int coNeedPoints = dr.GetOrdinal(ExchangePacket.NeedPointsField);
                    int coIsNotice = dr.GetOrdinal(ExchangePacket.IsNoticeField);
                    int coIsLimit = dr.GetOrdinal(ExchangePacket.IsLimitField);
                    int coLimitCount = dr.GetOrdinal(ExchangePacket.LimitCountField);
                    int coIsDelete = dr.GetOrdinal(ExchangePacket.IsDeleteField);
                    int coCreateTime = dr.GetOrdinal(ExchangePacket.CreateTimeField);

                    if (dr.Read())
                    {
                        exchangePacket.PacketId = dr.GetInt64(coPacketId);
                        exchangePacket.PacketName = dr.GetString(coPacketName);
                        exchangePacket.PacketDesc = dr.GetString(coPacketDesc);
                        exchangePacket.PuzzleTypeID = dr.GetInt32(coPuzzleTypeID);
                        exchangePacket.NeedPoints = dr.GetInt32(coNeedPoints);
                        exchangePacket.IsNotice = dr.GetBoolean(coIsNotice);
                        exchangePacket.IsLimit = dr.GetBoolean(coIsLimit);
                        exchangePacket.LimitCount = dr.GetInt32(coLimitCount);
                        exchangePacket.IsDelete = dr.GetInt32(coIsDelete);
                        exchangePacket.CreateTime = dr.GetDateTime(coCreateTime);
                    }
                }
            }

            return exchangePacket;
        }


        /// <summary>
        /// 更新 Puzzle
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:01:19
        /// <param name="puzzle">Puzzle 实体</param>
        /// <returns></returns>
        public Int32 UpdatePuzzle(Puzzle puzzle)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Puzzle_Update");
            DB.AddParameter(cmd, Puzzle.PuzzleIdField, DbType.Int32, ParameterDirection.InputOutput, Puzzle.PuzzleIdField, DataRowVersion.Current, puzzle.PuzzleId);
            DB.AddInParameter(cmd, Puzzle.PuzzleNameField, DbType.String, puzzle.PuzzleName);
            DB.AddInParameter(cmd, Puzzle.PuzzleDescField, DbType.String, puzzle.PuzzleDesc);
            DB.AddInParameter(cmd, Puzzle.PuzzleNodeField, DbType.Int32, puzzle.PuzzleNode);
            DB.AddInParameter(cmd, Puzzle.PuzzleTypeIDField, DbType.Int32, puzzle.PuzzleTypeID);
            DB.AddInParameter(cmd, Puzzle.PuzzlePacketTypeIDField, DbType.Int32, puzzle.PuzzlePacketTypeID);
            DB.AddInParameter(cmd, Puzzle.RateBeginField, DbType.Int32, puzzle.RateBegin);
            DB.AddInParameter(cmd, Puzzle.RateEndField, DbType.Int32, puzzle.RateEnd);
            DB.AddInParameter(cmd, Puzzle.PacketIDField, DbType.Int32, puzzle.PacketID);
            DB.AddInParameter(cmd, Puzzle.NodeTypeField, DbType.Int32, puzzle.NodeType);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

        /// <summary>
        /// 根据ID获取 Puzzle
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:01:19
        /// <param name="puzzle">Puzzle 实体</param>
        /// <returns></returns>
        public Puzzle GetPuzzle(Puzzle searchPuzzle)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Puzzle_GetByPuzzleId");
            DB.AddInParameter(cmd, Puzzle.PuzzleIdField, DbType.Int32, searchPuzzle.PuzzleId);

            Puzzle puzzle = new Puzzle();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzleId = dr.GetOrdinal(Puzzle.PuzzleIdField);
                    int coPuzzleName = dr.GetOrdinal(Puzzle.PuzzleNameField);
                    int coPuzzleDesc = dr.GetOrdinal(Puzzle.PuzzleDescField);
                    int coPuzzleNode = dr.GetOrdinal(Puzzle.PuzzleNodeField);
                    int coPuzzleTypeID = dr.GetOrdinal(Puzzle.PuzzleTypeIDField);
                    int coPuzzlePacketTypeID = dr.GetOrdinal(Puzzle.PuzzlePacketTypeIDField);
                    int coRateBegin = dr.GetOrdinal(Puzzle.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(Puzzle.RateEndField);
                    int coPacketID = dr.GetOrdinal(Puzzle.PacketIDField);
                    int coNodeType = dr.GetOrdinal(Puzzle.NodeTypeField);

                    if (dr.Read())
                    {
                        puzzle.PuzzleId = dr.GetInt32(coPuzzleId);
                        puzzle.PuzzleName = dr.GetString(coPuzzleName);
                        puzzle.PuzzleDesc = dr.IsDBNull(coPuzzleDesc) ? string.Empty : dr.GetString(coPuzzleDesc);
                        puzzle.PuzzleNode = dr.GetInt32(coPuzzleNode);
                        puzzle.PuzzleTypeID = dr.GetInt32(coPuzzleTypeID);
                        puzzle.PuzzlePacketTypeID = dr.GetInt32(coPuzzlePacketTypeID);
                        puzzle.RateBegin = dr.GetInt32(coRateBegin);
                        puzzle.RateEnd = dr.GetInt32(coRateEnd);
                        puzzle.PacketID = dr.IsDBNull(coPacketID) ? (int)0 : dr.GetInt32(coPacketID);
                        puzzle.NodeType = dr.IsDBNull(coNodeType) ? (int)0 : dr.GetInt32(coNodeType);
                    }
                }
            }

            return puzzle;
        }


        /// <summary>
        /// 更新 PuzzlePieces
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:01:51
        /// <param name="puzzlePieces">PuzzlePieces 实体</param>
        /// <returns></returns>
        public Int32 UpdatePuzzlePieces(PuzzlePieces puzzlePieces)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePieces_Update");
            DB.AddParameter(cmd, PuzzlePieces.PuzzlePieceIdField, DbType.Int32, ParameterDirection.InputOutput, PuzzlePieces.PuzzlePieceIdField, DataRowVersion.Current, puzzlePieces.PuzzlePieceId);
            DB.AddInParameter(cmd, PuzzlePieces.PuzzlePieceNameField, DbType.String, puzzlePieces.PuzzlePieceName);
            DB.AddInParameter(cmd, PuzzlePieces.PuzzlePieceDescField, DbType.String, puzzlePieces.PuzzlePieceDesc);
            DB.AddInParameter(cmd, PuzzlePieces.PuzzleIDField, DbType.Int32, puzzlePieces.PuzzleID);
            DB.AddInParameter(cmd, PuzzlePieces.PieceOrderField, DbType.Int32, puzzlePieces.PieceOrder);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 根据ID获取 PuzzlePieces
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:01:51
        /// <param name="puzzlePieces">PuzzlePieces 实体</param>
        /// <returns></returns>
        public PuzzlePieces GetPuzzlePieces(PuzzlePieces searchPuzzlePieces)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePieces_GetByPuzzlePieceId");
            DB.AddInParameter(cmd, PuzzlePieces.PuzzlePieceIdField, DbType.Int32, searchPuzzlePieces.PuzzlePieceId);

            PuzzlePieces puzzlePieces = new PuzzlePieces();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzlePieceId = dr.GetOrdinal(PuzzlePieces.PuzzlePieceIdField);
                    int coPuzzlePieceName = dr.GetOrdinal(PuzzlePieces.PuzzlePieceNameField);
                    int coPuzzlePieceDesc = dr.GetOrdinal(PuzzlePieces.PuzzlePieceDescField);
                    int coPuzzleID = dr.GetOrdinal(PuzzlePieces.PuzzleIDField);
                    int coPieceOrder = dr.GetOrdinal(PuzzlePieces.PieceOrderField);

                    if (dr.Read())
                    {
                        puzzlePieces.PuzzlePieceId = dr.GetInt32(coPuzzlePieceId);
                        puzzlePieces.PuzzlePieceName = dr.GetString(coPuzzlePieceName);
                        puzzlePieces.PuzzlePieceDesc = dr.IsDBNull(coPuzzlePieceDesc) ? string.Empty : dr.GetString(coPuzzlePieceDesc);
                        puzzlePieces.PuzzleID = dr.GetInt32(coPuzzleID);
                        puzzlePieces.PieceOrder = dr.GetInt32(coPieceOrder);
                    }
                }
            }

            return puzzlePieces;
        }


        /// <summary>
        /// 更新 PuzzlePacket
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:02:28
        /// <param name="puzzlePacket">PuzzlePacket 实体</param>
        /// <returns></returns>
        public Int32 UpdatePuzzlePacket(PuzzlePacket puzzlePacket)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePacket_Update");
            DB.AddParameter(cmd, PuzzlePacket.PuzzlePacketIdField, DbType.Int32, ParameterDirection.InputOutput, PuzzlePacket.PuzzlePacketIdField, DataRowVersion.Current, puzzlePacket.PuzzlePacketId);
            DB.AddInParameter(cmd, PuzzlePacket.PuzzlePacketNameField, DbType.String, puzzlePacket.PuzzlePacketName);
            DB.AddInParameter(cmd, PuzzlePacket.PuzzlePacketDescField, DbType.String, puzzlePacket.PuzzlePacketDesc);
            DB.AddInParameter(cmd, PuzzlePacket.PuzzlePacketTypeIDField, DbType.Int32, puzzlePacket.PuzzlePacketTypeID);
            DB.AddInParameter(cmd, PuzzlePacket.RateField, DbType.Decimal, puzzlePacket.Rate);
            DB.AddInParameter(cmd, PuzzlePacket.RateBeginField, DbType.Int32, puzzlePacket.RateBegin);
            DB.AddInParameter(cmd, PuzzlePacket.RateEndField, DbType.Int32, puzzlePacket.RateEnd);
            DB.AddInParameter(cmd, PuzzlePacket.IsNoticeField, DbType.Boolean, puzzlePacket.IsNotice);
            DB.AddInParameter(cmd, PuzzlePacket.PuzzleIDField, DbType.Int32, puzzlePacket.PuzzleID);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 根据ID获取 PuzzlePacket
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:02:28
        /// <param name="puzzlePacket">PuzzlePacket 实体</param>
        /// <returns></returns>
        public PuzzlePacket GetPuzzlePacket(PuzzlePacket searchPuzzlePacket)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePacket_GetByPuzzlePacketId");
            DB.AddInParameter(cmd, PuzzlePacket.PuzzlePacketIdField, DbType.Int32, searchPuzzlePacket.PuzzlePacketId);

            PuzzlePacket puzzlePacket = new PuzzlePacket();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzlePacketId = dr.GetOrdinal(PuzzlePacket.PuzzlePacketIdField);
                    int coPuzzlePacketName = dr.GetOrdinal(PuzzlePacket.PuzzlePacketNameField);
                    int coPuzzlePacketDesc = dr.GetOrdinal(PuzzlePacket.PuzzlePacketDescField);
                    int coPuzzlePacketTypeID = dr.GetOrdinal(PuzzlePacket.PuzzlePacketTypeIDField);
                    int coRate = dr.GetOrdinal(PuzzlePacket.RateField);
                    int coRateBegin = dr.GetOrdinal(PuzzlePacket.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(PuzzlePacket.RateEndField);
                    int coIsNotice = dr.GetOrdinal(PuzzlePacket.IsNoticeField);
                    int coPuzzleID = dr.GetOrdinal(PuzzlePacket.PuzzleIDField);

                    if (dr.Read())
                    {
                        puzzlePacket.PuzzlePacketId = dr.GetInt32(coPuzzlePacketId);
                        puzzlePacket.PuzzlePacketName = dr.GetString(coPuzzlePacketName);
                        puzzlePacket.PuzzlePacketDesc = dr.IsDBNull(coPuzzlePacketDesc) ? string.Empty : dr.GetString(coPuzzlePacketDesc);
                        puzzlePacket.PuzzlePacketTypeID = dr.GetInt32(coPuzzlePacketTypeID);
                        puzzlePacket.Rate = dr.GetDecimal(coRate);
                        puzzlePacket.RateBegin = dr.IsDBNull(coRateBegin) ? (int)0 : dr.GetInt32(coRateBegin);
                        puzzlePacket.RateEnd = dr.IsDBNull(coRateEnd) ? (int)0 : dr.GetInt32(coRateEnd);
                        puzzlePacket.IsNotice = dr.GetBoolean(coIsNotice);
                        puzzlePacket.PuzzleID = dr.IsDBNull(coPuzzleID) ? (int)0 : dr.GetInt32(coPuzzleID);
                    }
                }
            }

            return puzzlePacket;
        }


        /// <summary>
        /// 更新 PuzzleRate
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:04:11
        /// <param name="puzzleRate">PuzzleRate 实体</param>
        /// <returns></returns>
        public Int32 UpdatePuzzleRate(PuzzleRate puzzleRate)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleRate_Update");
            DB.AddParameter(cmd, PuzzleRate.PuzzleTypeIdField, DbType.Int32, ParameterDirection.InputOutput, PuzzleRate.PuzzleTypeIdField, DataRowVersion.Current, puzzleRate.PuzzleTypeId);
            DB.AddParameter(cmd, PuzzleRate.PuzzlePiecesCountField, DbType.Int32, ParameterDirection.InputOutput, PuzzleRate.PuzzlePiecesCountField, DataRowVersion.Current, puzzleRate.PuzzlePiecesCount);
            DB.AddParameter(cmd, PuzzleRate.PuzzleRateTypeIDField, DbType.Int32, ParameterDirection.InputOutput, PuzzleRate.PuzzleRateTypeIDField, DataRowVersion.Current, puzzleRate.PuzzleRateTypeID);
            DB.AddInParameter(cmd, PuzzleRate.RateField, DbType.Decimal, puzzleRate.Rate);
            DB.AddInParameter(cmd, PuzzleRate.RateBeginField, DbType.Int32, puzzleRate.RateBegin);
            DB.AddInParameter(cmd, PuzzleRate.RateEndField, DbType.Int32, puzzleRate.RateEnd);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }


        /// <summary>
        /// 根据ID获取 PuzzleRate
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 20:04:11
        /// <param name="puzzleRate">PuzzleRate 实体</param>
        /// <returns></returns>
        public PuzzleRate GetPuzzleRate(PuzzleRate searchPuzzleRate)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleRate_GetByPuzzleTypeId");
            DB.AddInParameter(cmd, PuzzleRate.PuzzleTypeIdField, DbType.Int32, searchPuzzleRate.PuzzleTypeId);
            DB.AddInParameter(cmd, PuzzleRate.PuzzlePiecesCountField, DbType.Int32, searchPuzzleRate.PuzzlePiecesCount);
            DB.AddInParameter(cmd, PuzzleRate.PuzzleRateTypeIDField, DbType.Int32, searchPuzzleRate.PuzzleRateTypeID);
            PuzzleRate puzzleRate = new PuzzleRate();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzleTypeId = dr.GetOrdinal(PuzzleRate.PuzzleTypeIdField);
                    int coPuzzlePiecesCount = dr.GetOrdinal(PuzzleRate.PuzzlePiecesCountField);
                    int coPuzzleRateTypeID = dr.GetOrdinal(PuzzleRate.PuzzleRateTypeIDField);
                    int coRate = dr.GetOrdinal(PuzzleRate.RateField);
                    int coRateBegin = dr.GetOrdinal(PuzzleRate.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(PuzzleRate.RateEndField);

                    if (dr.Read())
                    {
                        puzzleRate.PuzzleTypeId = dr.GetInt32(coPuzzleTypeId);
                        puzzleRate.PuzzlePiecesCount = dr.GetInt32(coPuzzlePiecesCount);
                        puzzleRate.PuzzleRateTypeID = dr.GetInt32(coPuzzleRateTypeID);
                        puzzleRate.Rate = dr.GetDecimal(coRate);
                        puzzleRate.RateBegin = dr.IsDBNull(coRateBegin) ? (int)0 : dr.GetInt32(coRateBegin);
                        puzzleRate.RateEnd = dr.IsDBNull(coRateEnd) ? (int)0 : dr.GetInt32(coRateEnd);
                    }
                }
            }

            return puzzleRate;
        }


        /// <summary>
        /// 获取 ExchangePacket 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:23:11
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchExchangePacket">ExchangePacket 查询实体</param>
        /// <returns></returns>
        public List<ExchangePacket> GetExchangePacketList(ref DataPage dp, ExchangePacket searchExchangePacket)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacket_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<ExchangePacket> exchangePacketList = new List<ExchangePacket>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPacketId = dr.GetOrdinal(ExchangePacket.PacketIdField);
                    int coPacketName = dr.GetOrdinal(ExchangePacket.PacketNameField);
                    int coPacketDesc = dr.GetOrdinal(ExchangePacket.PacketDescField);
                    int coPuzzleTypeID = dr.GetOrdinal(ExchangePacket.PuzzleTypeIDField);
                    int coNeedPoints = dr.GetOrdinal(ExchangePacket.NeedPointsField);
                    int coIsNotice = dr.GetOrdinal(ExchangePacket.IsNoticeField);
                    int coIsLimit = dr.GetOrdinal(ExchangePacket.IsLimitField);
                    int coLimitCount = dr.GetOrdinal(ExchangePacket.LimitCountField);
                    int coIsDelete = dr.GetOrdinal(ExchangePacket.IsDeleteField);
                    int coCreateTime = dr.GetOrdinal(ExchangePacket.CreateTimeField);
                    int coTotalCount = dr.GetOrdinal(ExchangePacket.TotalCountField);

                    while (dr.Read())
                    {
                        ExchangePacket exchangePacket = new ExchangePacket();

                        exchangePacket.PacketId = dr.IsDBNull(coPacketId) ? (long)0 : dr.GetInt64(coPacketId);
                        exchangePacket.PacketName = dr.IsDBNull(coPacketName) ? string.Empty : dr.GetString(coPacketName);
                        exchangePacket.PacketDesc = dr.IsDBNull(coPacketDesc) ? string.Empty : dr.GetString(coPacketDesc);
                        exchangePacket.PuzzleTypeID = dr.IsDBNull(coPuzzleTypeID) ? (int)0 : dr.GetInt32(coPuzzleTypeID);
                        exchangePacket.NeedPoints = dr.IsDBNull(coNeedPoints) ? (int)0 : dr.GetInt32(coNeedPoints);
                        exchangePacket.IsNotice = dr.IsDBNull(coIsNotice) ? false : dr.GetBoolean(coIsNotice);
                        exchangePacket.IsLimit = dr.IsDBNull(coIsLimit) ? false : dr.GetBoolean(coIsLimit);
                        exchangePacket.LimitCount = dr.IsDBNull(coLimitCount) ? (int)0 : dr.GetInt32(coLimitCount);
                        exchangePacket.IsDelete = dr.IsDBNull(coIsDelete) ? (int)0 : dr.GetInt32(coIsDelete);
                        exchangePacket.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        exchangePacket.TotalCount = dr.IsDBNull(coTotalCount) ? (int)0 : dr.GetInt32(coTotalCount);
                        exchangePacketList.Add(exchangePacket);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return exchangePacketList;
        }

        /// <summary>
        /// 获取 PuzzlePieces 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:26:00
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPuzzlePieces">PuzzlePieces 查询实体</param>
        /// <returns></returns>
        public List<PuzzlePieces> GetPuzzlePiecesList(ref DataPage dp, PuzzlePieces searchPuzzlePieces)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePieces_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PuzzlePieces.PuzzleIDField, DbType.Int32, searchPuzzlePieces.PuzzleID);

            List<PuzzlePieces> puzzlePiecesList = new List<PuzzlePieces>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzlePieceId = dr.GetOrdinal(PuzzlePieces.PuzzlePieceIdField);
                    int coPuzzlePieceName = dr.GetOrdinal(PuzzlePieces.PuzzlePieceNameField);
                    int coPuzzlePieceDesc = dr.GetOrdinal(PuzzlePieces.PuzzlePieceDescField);
                    int coPuzzleID = dr.GetOrdinal(PuzzlePieces.PuzzleIDField);
                    int coPieceOrder = dr.GetOrdinal(PuzzlePieces.PieceOrderField);

                    while (dr.Read())
                    {
                        PuzzlePieces puzzlePieces = new PuzzlePieces();

                        puzzlePieces.PuzzlePieceId = dr.IsDBNull(coPuzzlePieceId) ? (int)0 : dr.GetInt32(coPuzzlePieceId);
                        puzzlePieces.PuzzlePieceName = dr.IsDBNull(coPuzzlePieceName) ? string.Empty : dr.GetString(coPuzzlePieceName);
                        puzzlePieces.PuzzlePieceDesc = dr.IsDBNull(coPuzzlePieceDesc) ? string.Empty : dr.GetString(coPuzzlePieceDesc);
                        puzzlePieces.PuzzleID = dr.IsDBNull(coPuzzleID) ? (int)0 : dr.GetInt32(coPuzzleID);
                        puzzlePieces.PieceOrder = dr.IsDBNull(coPieceOrder) ? (int)0 : dr.GetInt32(coPieceOrder);

                        puzzlePiecesList.Add(puzzlePieces);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return puzzlePiecesList;
        }

        /// <summary>
        /// 获取 PuzzlePacket 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:28:11
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPuzzlePacket">PuzzlePacket 查询实体</param>
        /// <returns></returns>
        public List<PuzzlePacket> GetPuzzlePacketList(ref DataPage dp, PuzzlePacket searchPuzzlePacket)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePacket_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PuzzlePacket.PuzzlePacketTypeIDField, DbType.Int32, searchPuzzlePacket.PuzzlePacketTypeID);

            List<PuzzlePacket> puzzlePacketList = new List<PuzzlePacket>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzlePacketId = dr.GetOrdinal(PuzzlePacket.PuzzlePacketIdField);
                    int coPuzzlePacketName = dr.GetOrdinal(PuzzlePacket.PuzzlePacketNameField);
                    int coPuzzlePacketDesc = dr.GetOrdinal(PuzzlePacket.PuzzlePacketDescField);
                    int coPuzzlePacketTypeID = dr.GetOrdinal(PuzzlePacket.PuzzlePacketTypeIDField);
                    int coRate = dr.GetOrdinal(PuzzlePacket.RateField);
                    int coRateBegin = dr.GetOrdinal(PuzzlePacket.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(PuzzlePacket.RateEndField);
                    int coIsNotice = dr.GetOrdinal(PuzzlePacket.IsNoticeField);

                    while (dr.Read())
                    {
                        PuzzlePacket puzzlePacket = new PuzzlePacket();

                        puzzlePacket.PuzzlePacketId = dr.IsDBNull(coPuzzlePacketId) ? (int)0 : dr.GetInt32(coPuzzlePacketId);
                        puzzlePacket.PuzzlePacketName = dr.IsDBNull(coPuzzlePacketName) ? string.Empty : dr.GetString(coPuzzlePacketName);
                        puzzlePacket.PuzzlePacketDesc = dr.IsDBNull(coPuzzlePacketDesc) ? string.Empty : dr.GetString(coPuzzlePacketDesc);
                        puzzlePacket.PuzzlePacketTypeID = dr.IsDBNull(coPuzzlePacketTypeID) ? (int)0 : dr.GetInt32(coPuzzlePacketTypeID);
                        puzzlePacket.Rate = dr.IsDBNull(coRate) ? 0.0m : dr.GetDecimal(coRate);
                        puzzlePacket.RateBegin = dr.IsDBNull(coRateBegin) ? (int)0 : dr.GetInt32(coRateBegin);
                        puzzlePacket.RateEnd = dr.IsDBNull(coRateEnd) ? (int)0 : dr.GetInt32(coRateEnd);
                        puzzlePacket.IsNotice = dr.IsDBNull(coIsNotice) ? false : dr.GetBoolean(coIsNotice);

                        puzzlePacketList.Add(puzzlePacket);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return puzzlePacketList;
        }

        /// <summary>
        /// 获取 PuzzleRate 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:30:10
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPuzzleRate">PuzzleRate 查询实体</param>
        /// <returns></returns>
        public List<PuzzleRate> GetPuzzleRateList(ref DataPage dp, PuzzleRate searchPuzzleRate)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleRate_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PuzzleRate.PuzzleTypeIdField, DbType.Int32, searchPuzzleRate.PuzzleTypeId);

            List<PuzzleRate> puzzleRateList = new List<PuzzleRate>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzleTypeId = dr.GetOrdinal(PuzzleRate.PuzzleTypeIdField);
                    int coPuzzlePiecesCount = dr.GetOrdinal(PuzzleRate.PuzzlePiecesCountField);
                    int coPuzzleRateTypeID = dr.GetOrdinal(PuzzleRate.PuzzleRateTypeIDField);
                    int coRate = dr.GetOrdinal(PuzzleRate.RateField);
                    int coRateBegin = dr.GetOrdinal(PuzzleRate.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(PuzzleRate.RateEndField);

                    while (dr.Read())
                    {
                        PuzzleRate puzzleRate = new PuzzleRate();

                        puzzleRate.PuzzleTypeId = dr.IsDBNull(coPuzzleTypeId) ? (int)0 : dr.GetInt32(coPuzzleTypeId);
                        puzzleRate.PuzzlePiecesCount = dr.IsDBNull(coPuzzlePiecesCount) ? (int)0 : dr.GetInt32(coPuzzlePiecesCount);
                        puzzleRate.PuzzleRateTypeID = dr.IsDBNull(coPuzzleRateTypeID) ? (int)0 : dr.GetInt32(coPuzzleRateTypeID);
                        puzzleRate.Rate = dr.IsDBNull(coRate) ? 0.0m : dr.GetDecimal(coRate);
                        puzzleRate.RateBegin = dr.IsDBNull(coRateBegin) ? (int)0 : dr.GetInt32(coRateBegin);
                        puzzleRate.RateEnd = dr.IsDBNull(coRateEnd) ? (int)0 : dr.GetInt32(coRateEnd);

                        puzzleRateList.Add(puzzleRate);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return puzzleRateList;
        }

        /// <summary>
        /// 获取 Puzzle 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:31:28
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPuzzle">Puzzle 查询实体</param>
        /// <returns></returns>
        public List<Puzzle> GetPuzzleList(ref DataPage dp, Puzzle searchPuzzle)
        {
            DbCommand cmd = DB.GetStoredProcCommand("Puzzle_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);


            List<Puzzle> puzzleList = new List<Puzzle>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzleId = dr.GetOrdinal(Puzzle.PuzzleIdField);
                    int coPuzzleName = dr.GetOrdinal(Puzzle.PuzzleNameField);
                    int coPuzzleDesc = dr.GetOrdinal(Puzzle.PuzzleDescField);
                    int coPuzzleNode = dr.GetOrdinal(Puzzle.PuzzleNodeField);
                    int coPuzzleTypeID = dr.GetOrdinal(Puzzle.PuzzleTypeIDField);
                    int coPuzzlePacketTypeID = dr.GetOrdinal(Puzzle.PuzzlePacketTypeIDField);
                    int coRateBegin = dr.GetOrdinal(Puzzle.RateBeginField);
                    int coRateEnd = dr.GetOrdinal(Puzzle.RateEndField);
                    int coPacketID = dr.GetOrdinal(Puzzle.PacketIDField);
                    int coNodeType = dr.GetOrdinal(Puzzle.NodeTypeField);

                    while (dr.Read())
                    {
                        Puzzle puzzle = new Puzzle();

                        puzzle.PuzzleId = dr.IsDBNull(coPuzzleId) ? (int)0 : dr.GetInt32(coPuzzleId);
                        puzzle.PuzzleName = dr.IsDBNull(coPuzzleName) ? string.Empty : dr.GetString(coPuzzleName);
                        puzzle.PuzzleDesc = dr.IsDBNull(coPuzzleDesc) ? string.Empty : dr.GetString(coPuzzleDesc);
                        puzzle.PuzzleNode = dr.IsDBNull(coPuzzleNode) ? (int)0 : dr.GetInt32(coPuzzleNode);
                        puzzle.PuzzleTypeID = dr.IsDBNull(coPuzzleTypeID) ? (int)0 : dr.GetInt32(coPuzzleTypeID);
                        puzzle.PuzzlePacketTypeID = dr.IsDBNull(coPuzzlePacketTypeID) ? (int)0 : dr.GetInt32(coPuzzlePacketTypeID);
                        puzzle.RateBegin = dr.IsDBNull(coRateBegin) ? (int)0 : dr.GetInt32(coRateBegin);
                        puzzle.RateEnd = dr.IsDBNull(coRateEnd) ? (int)0 : dr.GetInt32(coRateEnd);
                        puzzle.PacketID = dr.IsDBNull(coPacketID) ? (int)0 : dr.GetInt32(coPacketID);
                        puzzle.NodeType = dr.IsDBNull(coNodeType) ? (int)0 : dr.GetInt32(coNodeType);

                        puzzleList.Add(puzzle);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return puzzleList;
        }
        #endregion

        #region 明细列表
        /// <summary>
        /// 获取 PuzzleReceiveDetails 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/12 11:34:00
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPuzzleReceiveDetails">PuzzleReceiveDetails 查询实体</param>
        /// <returns></returns>
        public List<PuzzleReceiveDetails> GetPuzzleReceiveDetailsList(ref DataPage dp, PuzzleReceiveDetails searchPuzzleReceiveDetails)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleReceiveDetails_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PuzzleReceiveDetails.UserIDField, DbType.Int64, searchPuzzleReceiveDetails.UserID);
            DB.AddInParameter(cmd, PuzzleReceiveDetails.AreaIDField, DbType.Int32, searchPuzzleReceiveDetails.AreaID);
            DB.AddInParameter(cmd, PuzzleReceiveDetails.PuzzleIDField, DbType.Int32, searchPuzzleReceiveDetails.PuzzleID);
            DB.AddInParameter(cmd, PuzzleReceiveDetails.PuzzleTypeIdField, DbType.Int32, searchPuzzleReceiveDetails.PuzzleTypeId);

            List<PuzzleReceiveDetails> puzzleReceiveDetailsList = new List<PuzzleReceiveDetails>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coReceivePuzzleID = dr.GetOrdinal(PuzzleReceiveDetails.ReceivePuzzleIDField);
                    int coUserID = dr.GetOrdinal(PuzzleReceiveDetails.UserIDField);
                    int coAreaID = dr.GetOrdinal(PuzzleReceiveDetails.AreaIDField);
                    int coAvatarID = dr.GetOrdinal(PuzzleReceiveDetails.AvatarIDField);
                    int coCreateTS = dr.GetOrdinal(PuzzleReceiveDetails.CreateTSField);
                    int coPuzzleID = dr.GetOrdinal(PuzzleReceiveDetails.PuzzleIDField);
                    int coPuzzleTypeId = dr.GetOrdinal(PuzzleReceiveDetails.PuzzleTypeIdField);

                    while (dr.Read())
                    {
                        PuzzleReceiveDetails puzzleReceiveDetails = new PuzzleReceiveDetails();

                        puzzleReceiveDetails.ReceivePuzzleID = dr.IsDBNull(coReceivePuzzleID) ? (int)0 : dr.GetInt32(coReceivePuzzleID);
                        puzzleReceiveDetails.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        puzzleReceiveDetails.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        puzzleReceiveDetails.AvatarID = dr.IsDBNull(coAvatarID) ? (long)0 : dr.GetInt64(coAvatarID);
                        puzzleReceiveDetails.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        puzzleReceiveDetails.PuzzleID = dr.IsDBNull(coPuzzleID) ? (int)0 : dr.GetInt32(coPuzzleID);
                        puzzleReceiveDetails.PuzzleTypeId = dr.IsDBNull(coPuzzleTypeId) ? (int)0 : dr.GetInt32(coPuzzleTypeId);

                        puzzleReceiveDetailsList.Add(puzzleReceiveDetails);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return puzzleReceiveDetailsList;
        }

        /// <summary>
        /// 获取 UserPiecesTotal 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/12 11:38:27
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchUserPiecesTotal">UserPiecesTotal 查询实体</param>
        /// <returns></returns>
        public List<UserPiecesTotal> GetUserPiecesTotalList(ref DataPage dp, UserPiecesTotal searchUserPiecesTotal)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UserPiecesTotal_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, UserPiecesTotal.UserIdField, DbType.Int64, searchUserPiecesTotal.UserId);
            DB.AddInParameter(cmd, UserPiecesTotal.AreaIDField, DbType.Int32, searchUserPiecesTotal.AreaID);
            DB.AddInParameter(cmd, UserPiecesTotal.PuzzleTypeIDField, DbType.Int32, searchUserPiecesTotal.PuzzleTypeID);

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

                        userPiecesTotalList.Add(userPiecesTotal);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return userPiecesTotalList;
        }

        /// <summary>
        /// 获取 PuzzleDrawDetails 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/12 11:39:51
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPuzzleDrawDetails">PuzzleDrawDetails 查询实体</param>
        /// <returns></returns>
        public List<PuzzleDrawDetails> GetPuzzleDrawDetailsList(ref DataPage dp, PuzzleDrawDetails searchPuzzleDrawDetails)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleDrawDetails_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PuzzleDrawDetails.UserIDField, DbType.Int64, searchPuzzleDrawDetails.UserID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.AreaIDField, DbType.Int32, searchPuzzleDrawDetails.AreaID);
            DB.AddInParameter(cmd, PuzzleDrawDetails.DrawCountField, DbType.Int32, searchPuzzleDrawDetails.DrawCount);
            DB.AddInParameter(cmd, PuzzleDrawDetails.PuzzleTypeIdField, DbType.Int32, searchPuzzleDrawDetails.PuzzleTypeId);

            List<PuzzleDrawDetails> puzzleDrawDetailsList = new List<PuzzleDrawDetails>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coPuzzleDrawID = dr.GetOrdinal(PuzzleDrawDetails.PuzzleDrawIDField);
                    int coUserID = dr.GetOrdinal(PuzzleDrawDetails.UserIDField);
                    int coAreaID = dr.GetOrdinal(PuzzleDrawDetails.AreaIDField);
                    int coAvatarID = dr.GetOrdinal(PuzzleDrawDetails.AvatarIDField);
                    int coCreateTS = dr.GetOrdinal(PuzzleDrawDetails.CreateTSField);
                    int coDrawCount = dr.GetOrdinal(PuzzleDrawDetails.DrawCountField);
                    int coActualCount = dr.GetOrdinal(PuzzleDrawDetails.ActualCountField);
                    int coPuzzleTypeId = dr.GetOrdinal(PuzzleDrawDetails.PuzzleTypeIdField);
                    int coPoints = dr.GetOrdinal(PuzzleDrawDetails.PointsField);
                    int coAvatarName = dr.GetOrdinal(PuzzleDrawDetails.AvatarNameField);
                    int coLoginName = dr.GetOrdinal(PuzzleDrawDetails.LoginNameField);

                    while (dr.Read())
                    {
                        PuzzleDrawDetails puzzleDrawDetails = new PuzzleDrawDetails();

                        puzzleDrawDetails.PuzzleDrawID = dr.IsDBNull(coPuzzleDrawID) ? (int)0 : dr.GetInt32(coPuzzleDrawID);
                        puzzleDrawDetails.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        puzzleDrawDetails.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        puzzleDrawDetails.AvatarID = dr.IsDBNull(coAvatarID) ? (long)0 : dr.GetInt64(coAvatarID);
                        puzzleDrawDetails.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        puzzleDrawDetails.DrawCount = dr.IsDBNull(coDrawCount) ? (int)0 : dr.GetInt32(coDrawCount);
                        puzzleDrawDetails.ActualCount = dr.IsDBNull(coActualCount) ? (int)0 : dr.GetInt32(coActualCount);
                        puzzleDrawDetails.PuzzleTypeId = dr.IsDBNull(coPuzzleTypeId) ? (int)0 : dr.GetInt32(coPuzzleTypeId);
                        puzzleDrawDetails.Points = dr.IsDBNull(coPoints) ? (int)0 : dr.GetInt32(coPoints);
                        puzzleDrawDetails.AvatarName = dr.IsDBNull(coAvatarName) ? string.Empty : dr.GetString(coAvatarName);
                        puzzleDrawDetails.LoginName = dr.IsDBNull(coLoginName) ? string.Empty : dr.GetString(coLoginName);

                        puzzleDrawDetailsList.Add(puzzleDrawDetails);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return puzzleDrawDetailsList;
        }

        /// <summary>
        /// 获取 PacketQueueLog 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/12 11:45:40
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
            DB.AddInParameter(cmd, PacketQueueLog.GameAreaField, DbType.Int32, searchPacketQueueLog.GameArea);
            DB.AddInParameter(cmd, PacketQueueLog.PacketIdField, DbType.Int64, searchPacketQueueLog.PacketId);
            DB.AddInParameter(cmd, PacketQueueLog.SourceField, DbType.String, searchPacketQueueLog.Source);

            List<PacketQueueLog> packetQueueLogList = new List<PacketQueueLog>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coLogId = dr.GetOrdinal(PacketQueueLog.LogIdField);
                    int coId = dr.GetOrdinal(PacketQueueLog.IdField);
                    int coUserId = dr.GetOrdinal(PacketQueueLog.UserIdField);
                    int coAvatarId = dr.GetOrdinal(PacketQueueLog.AvatarIdField);
                    int coSex = dr.GetOrdinal(PacketQueueLog.SexField);
                    int coGameArea = dr.GetOrdinal(PacketQueueLog.GameAreaField);
                    int coPacketId = dr.GetOrdinal(PacketQueueLog.PacketIdField);
                    int coCreateTime = dr.GetOrdinal(PacketQueueLog.CreateTimeField);
                    int coSource = dr.GetOrdinal(PacketQueueLog.SourceField);

                    while (dr.Read())
                    {
                        PacketQueueLog packetQueueLog = new PacketQueueLog();

                        packetQueueLog.LogId = dr.IsDBNull(coLogId) ? (long)0 : dr.GetInt64(coLogId);
                        packetQueueLog.Id = dr.IsDBNull(coId) ? (long)0 : dr.GetInt64(coId);
                        packetQueueLog.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        packetQueueLog.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        packetQueueLog.Sex = dr.IsDBNull(coSex) ? (int)0 : dr.GetInt32(coSex);
                        packetQueueLog.GameArea = dr.IsDBNull(coGameArea) ? (int)0 : dr.GetInt32(coGameArea);
                        packetQueueLog.PacketId = dr.IsDBNull(coPacketId) ? (long)0 : dr.GetInt64(coPacketId);
                        packetQueueLog.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        packetQueueLog.Source = dr.IsDBNull(coSource) ? string.Empty : dr.GetString(coSource);

                        packetQueueLogList.Add(packetQueueLog);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return packetQueueLogList;
        }

        /// <summary>
        /// 获取 PiecesPacketDetails 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/12 11:46:56
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchPiecesPacketDetails">PiecesPacketDetails 查询实体</param>
        /// <returns></returns>
        public List<PiecesPacketDetails> GetPiecesPacketDetailsList(ref DataPage dp, PiecesPacketDetails searchPiecesPacketDetails)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PiecesPacketDetails_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, PiecesPacketDetails.UserIDField, DbType.Int64, searchPiecesPacketDetails.UserID);
            DB.AddInParameter(cmd, PiecesPacketDetails.AreaIDField, DbType.Int32, searchPiecesPacketDetails.AreaID);
            DB.AddInParameter(cmd, PiecesPacketDetails.IsPuzzleField, DbType.Int32, searchPiecesPacketDetails.IsPuzzle);
            DB.AddInParameter(cmd, PiecesPacketDetails.PuzzlePacketIDField, DbType.Int32, searchPiecesPacketDetails.PuzzlePacketID);
            DB.AddInParameter(cmd, PiecesPacketDetails.PuzzlePieceIdField, DbType.Int32, searchPiecesPacketDetails.PuzzlePieceId);
            DB.AddInParameter(cmd, PiecesPacketDetails.PuzzleDrawIDField, DbType.Int32, searchPiecesPacketDetails.PuzzleDrawID);

            List<PiecesPacketDetails> piecesPacketDetailsList = new List<PiecesPacketDetails>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coReceiveID = dr.GetOrdinal(PiecesPacketDetails.ReceiveIDField);
                    int coUserID = dr.GetOrdinal(PiecesPacketDetails.UserIDField);
                    int coAreaID = dr.GetOrdinal(PiecesPacketDetails.AreaIDField);
                    int coAvatarID = dr.GetOrdinal(PiecesPacketDetails.AvatarIDField);
                    int coCreateTS = dr.GetOrdinal(PiecesPacketDetails.CreateTSField);
                    int coPoints = dr.GetOrdinal(PiecesPacketDetails.PointsField);
                    int coIsPuzzle = dr.GetOrdinal(PiecesPacketDetails.IsPuzzleField);
                    int coPuzzlePacketID = dr.GetOrdinal(PiecesPacketDetails.PuzzlePacketIDField);
                    int coPuzzlePieceId = dr.GetOrdinal(PiecesPacketDetails.PuzzlePieceIdField);
                    int coPuzzleDrawID = dr.GetOrdinal(PiecesPacketDetails.PuzzleDrawIDField);

                    while (dr.Read())
                    {
                        PiecesPacketDetails piecesPacketDetails = new PiecesPacketDetails();

                        piecesPacketDetails.ReceiveID = dr.IsDBNull(coReceiveID) ? (long)0 : dr.GetInt64(coReceiveID);
                        piecesPacketDetails.UserID = dr.IsDBNull(coUserID) ? (long)0 : dr.GetInt64(coUserID);
                        piecesPacketDetails.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        piecesPacketDetails.AvatarID = dr.IsDBNull(coAvatarID) ? (long)0 : dr.GetInt64(coAvatarID);
                        piecesPacketDetails.CreateTS = dr.IsDBNull(coCreateTS) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTS);
                        piecesPacketDetails.Points = dr.IsDBNull(coPoints) ? (int)0 : dr.GetInt32(coPoints);
                        piecesPacketDetails.IsPuzzle = dr.IsDBNull(coIsPuzzle) ? (int)0 : dr.GetInt32(coIsPuzzle);
                        piecesPacketDetails.PuzzlePacketID = dr.IsDBNull(coPuzzlePacketID) ? (int)0 : dr.GetInt32(coPuzzlePacketID);
                        piecesPacketDetails.PuzzlePieceId = dr.IsDBNull(coPuzzlePieceId) ? (int)0 : dr.GetInt32(coPuzzlePieceId);
                        piecesPacketDetails.PuzzleDrawID = dr.IsDBNull(coPuzzleDrawID) ? (int)0 : dr.GetInt32(coPuzzleDrawID);

                        piecesPacketDetailsList.Add(piecesPacketDetails);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return piecesPacketDetailsList;
        }

        /// <summary>
        /// 获取 ExchangePacketReceive 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/13 10:07:49
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchExchangePacketReceive">ExchangePacketReceive 查询实体</param>
        /// <returns></returns>
        public List<ExchangePacketReceive> GetExchangePacketReceiveList(ref DataPage dp, ExchangePacketReceive searchExchangePacketReceive)
        {
            DbCommand cmd = DB.GetStoredProcCommand("ExchangePacketReceive_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, ExchangePacketReceive.UserIdField, DbType.Int64, searchExchangePacketReceive.UserId);
            DB.AddInParameter(cmd, ExchangePacketReceive.GameAreaField, DbType.Int32, searchExchangePacketReceive.GameArea);
            DB.AddInParameter(cmd, ExchangePacketReceive.PacketIdField, DbType.Int64, searchExchangePacketReceive.PacketId);
            DB.AddInParameter(cmd, ExchangePacketReceive.PuzzleTypeIDField, DbType.Int32, searchExchangePacketReceive.PuzzleTypeID);

            List<ExchangePacketReceive> exchangePacketReceiveList = new List<ExchangePacketReceive>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coExchangeId = dr.GetOrdinal(ExchangePacketReceive.ExchangeIdField);
                    int coUserId = dr.GetOrdinal(ExchangePacketReceive.UserIdField);
                    int coAvatarId = dr.GetOrdinal(ExchangePacketReceive.AvatarIdField);
                    int coSex = dr.GetOrdinal(ExchangePacketReceive.SexField);
                    int coGameArea = dr.GetOrdinal(ExchangePacketReceive.GameAreaField);
                    int coPacketId = dr.GetOrdinal(ExchangePacketReceive.PacketIdField);
                    int coCreateTime = dr.GetOrdinal(ExchangePacketReceive.CreateTimeField);
                    int coPiecesCount = dr.GetOrdinal(ExchangePacketReceive.PiecesCountField);
                    int coPuzzleTypeID = dr.GetOrdinal(ExchangePacketReceive.PuzzleTypeIDField);

                    while (dr.Read())
                    {
                        ExchangePacketReceive exchangePacketReceive = new ExchangePacketReceive();

                        exchangePacketReceive.ExchangeId = dr.IsDBNull(coExchangeId) ? (long)0 : dr.GetInt64(coExchangeId);
                        exchangePacketReceive.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        exchangePacketReceive.AvatarId = dr.IsDBNull(coAvatarId) ? (long)0 : dr.GetInt64(coAvatarId);
                        exchangePacketReceive.Sex = dr.IsDBNull(coSex) ? (int)0 : dr.GetInt32(coSex);
                        exchangePacketReceive.GameArea = dr.IsDBNull(coGameArea) ? (int)0 : dr.GetInt32(coGameArea);
                        exchangePacketReceive.PacketId = dr.IsDBNull(coPacketId) ? (long)0 : dr.GetInt64(coPacketId);
                        exchangePacketReceive.CreateTime = dr.IsDBNull(coCreateTime) ? (DateTime)SqlDateTime.Null : dr.GetDateTime(coCreateTime);
                        exchangePacketReceive.PiecesCount = dr.IsDBNull(coPiecesCount) ? (int)0 : dr.GetInt32(coPiecesCount);
                        exchangePacketReceive.PuzzleTypeID = dr.IsDBNull(coPuzzleTypeID) ? (int)0 : dr.GetInt32(coPuzzleTypeID);

                        exchangePacketReceiveList.Add(exchangePacketReceive);
                    }
                }
            }

            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return exchangePacketReceiveList;
        }
        #endregion

        #region 个人结点
        /// <summary>
        /// 获取 UserPuzzleNode 翻页列表
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:51:21
        /// <param name="dp">翻页类 如果PageSize = 0 则不翻页</param>
        /// <param name="searchUserPuzzleNode">UserPuzzleNode 查询实体</param>
        /// <returns></returns>
        public List<UserPuzzleNode> GetUserPuzzleNodeList(ref DataPage dp, UserPuzzleNode searchUserPuzzleNode)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UserPuzzleNode_GetList");
            //翻页参数
            DB.AddInParameter(cmd, DataPage.PageSizeField, DbType.Int32, dp.PageSize);
            DB.AddInParameter(cmd, DataPage.PageIndexField, DbType.Int32, dp.PageIndex);
            DB.AddParameter(cmd, DataPage.RowCountField, DbType.Int64, ParameterDirection.InputOutput, String.Empty, DataRowVersion.Default, dp.RowCount);

            DB.AddInParameter(cmd, UserPuzzleNode.UserIdField, DbType.Int64, searchUserPuzzleNode.UserId);

            List<UserPuzzleNode> userPuzzleNodeList = new List<UserPuzzleNode>();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coNodeID = dr.GetOrdinal(UserPuzzleNode.NodeIDField);
                    int coUserId = dr.GetOrdinal(UserPuzzleNode.UserIdField);
                    int coAreaID = dr.GetOrdinal(UserPuzzleNode.AreaIDField);
                    int coNodeCurrent = dr.GetOrdinal(UserPuzzleNode.NodeCurrentField);
                    int coNodeTotal = dr.GetOrdinal(UserPuzzleNode.NodeTotalField);
                    int coPuzzleTypeID = dr.GetOrdinal(UserPuzzleNode.PuzzleTypeIDField);
                    int coPuzzleID = dr.GetOrdinal(UserPuzzleNode.PuzzleIDField);

                    while (dr.Read())
                    {
                        UserPuzzleNode userPuzzleNode = new UserPuzzleNode();

                        userPuzzleNode.NodeID = dr.IsDBNull(coNodeID) ? (long)0 : dr.GetInt64(coNodeID);
                        userPuzzleNode.UserId = dr.IsDBNull(coUserId) ? (long)0 : dr.GetInt64(coUserId);
                        userPuzzleNode.AreaID = dr.IsDBNull(coAreaID) ? (int)0 : dr.GetInt32(coAreaID);
                        userPuzzleNode.NodeCurrent = dr.IsDBNull(coNodeCurrent) ? (int)0 : dr.GetInt32(coNodeCurrent);
                        userPuzzleNode.NodeTotal = dr.IsDBNull(coNodeTotal) ? (long)0 : dr.GetInt64(coNodeTotal);
                        userPuzzleNode.PuzzleTypeID = dr.IsDBNull(coPuzzleTypeID) ? (int)0 : dr.GetInt32(coPuzzleTypeID);
                        userPuzzleNode.PuzzleID = dr.IsDBNull(coPuzzleID) ? (int)0 : dr.GetInt32(coPuzzleID);

                        userPuzzleNodeList.Add(userPuzzleNode);
                    }
                }
            }



            //获取翻页
            dp.RowCount = Convert.ToInt64(DB.GetParameterValue(cmd, DataPage.RowCountField));

            return userPuzzleNodeList;
        }
        /// <summary>
        /// 根据ID获取 UserPuzzleNode
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 11:22:19
        /// <param name="userPuzzleNode">UserPuzzleNode 实体</param>
        /// <returns></returns>
        public UserPuzzleNode GetUserPuzzleNode(UserPuzzleNode searchUserPuzzleNode)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UserPuzzleNode_GetByNodeID");
            DB.AddInParameter(cmd, UserPuzzleNode.NodeIDField, DbType.Int64, searchUserPuzzleNode.NodeID);

            UserPuzzleNode userPuzzleNode = new UserPuzzleNode();

            using (IDataReader dr = DB.ExecuteReader(cmd))
            {
                if (dr.FieldCount > 0)
                {
                    int coNodeID = dr.GetOrdinal(UserPuzzleNode.NodeIDField);
                    int coUserId = dr.GetOrdinal(UserPuzzleNode.UserIdField);
                    int coAreaID = dr.GetOrdinal(UserPuzzleNode.AreaIDField);
                    int coNodeCurrent = dr.GetOrdinal(UserPuzzleNode.NodeCurrentField);
                    int coNodeTotal = dr.GetOrdinal(UserPuzzleNode.NodeTotalField);
                    int coPuzzleTypeID = dr.GetOrdinal(UserPuzzleNode.PuzzleTypeIDField);
                    int coPuzzleID = dr.GetOrdinal(UserPuzzleNode.PuzzleIDField);

                    if (dr.Read())
                    {
                        userPuzzleNode.NodeID = dr.GetInt64(coNodeID);
                        userPuzzleNode.UserId = dr.GetInt64(coUserId);
                        userPuzzleNode.AreaID = dr.GetInt32(coAreaID);
                        userPuzzleNode.NodeCurrent = dr.GetInt32(coNodeCurrent);
                        userPuzzleNode.NodeTotal = dr.GetInt64(coNodeTotal);
                        userPuzzleNode.PuzzleTypeID = dr.GetInt32(coPuzzleTypeID);
                        userPuzzleNode.PuzzleID = dr.GetInt32(coPuzzleID);
                    }
                }
            }

            return userPuzzleNode;
        }

        /// <summary>
        /// 更新 UserPuzzleNode
        /// </summary>
        /// Create By zhouqi
        /// 2016/4/8 10:52:42
        /// <param name="userPuzzleNode">UserPuzzleNode 实体</param>
        /// <returns></returns>
        public Int64 UpdateUserPuzzleNode(UserPuzzleNode userPuzzleNode)
        {
            DbCommand cmd = DB.GetStoredProcCommand("UserPuzzleNode_Update");
            DB.AddParameter(cmd, UserPuzzleNode.NodeIDField, DbType.Int64, ParameterDirection.InputOutput, UserPuzzleNode.NodeIDField, DataRowVersion.Current, userPuzzleNode.NodeID);
            DB.AddInParameter(cmd, UserPuzzleNode.UserIdField, DbType.Int64, userPuzzleNode.UserId);
            DB.AddInParameter(cmd, UserPuzzleNode.AreaIDField, DbType.Int32, userPuzzleNode.AreaID);
            DB.AddInParameter(cmd, UserPuzzleNode.NodeCurrentField, DbType.Int32, userPuzzleNode.NodeCurrent);
            DB.AddInParameter(cmd, UserPuzzleNode.NodeTotalField, DbType.Int64, userPuzzleNode.NodeTotal);
            DB.AddInParameter(cmd, UserPuzzleNode.PuzzleTypeIDField, DbType.Int32, userPuzzleNode.PuzzleTypeID);
            DB.AddInParameter(cmd, UserPuzzleNode.PuzzleIDField, DbType.Int32, userPuzzleNode.PuzzleID);
            //增加返回参数
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue,
                string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);

            DB.ExecuteNonQuery(cmd);

            //如果增加成功，返回ID，如果失败，返回0，如果检测到重复值，返回-1	
            Int64 rs = Convert.ToInt64(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }
        #endregion

        #region 提交概率
        public Int32 SubmitPuzzleRate(int PuzzleTypeId)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzleRate_SubmitByPuzzleTypeID");
            DB.AddInParameter(cmd, PuzzleRate.PuzzleTypeIdField, DbType.Int32, PuzzleTypeId);
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }

        public Int32 SubmitPuzzlePacketRate(int PuzzlePacketTypeID)
        {
            DbCommand cmd = DB.GetStoredProcCommand("PuzzlePacket_SubmitByPuzzlePacketTypeID");
            DB.AddInParameter(cmd, PuzzlePacket.PuzzlePacketTypeIDField, DbType.Int32, PuzzlePacketTypeID);
            DB.AddParameter(cmd, ConstUtil.ReturnValue, DbType.Int32, ParameterDirection.ReturnValue, string.Empty, DataRowVersion.Default, (int)ReturnState.UnSuccessful);
            DB.ExecuteNonQuery(cmd);

            //无异常就返回true
            Int32 rs = Convert.ToInt32(DB.GetParameterValue(cmd, ConstUtil.ReturnValue));

            return rs;
        }
        #endregion


        #region
        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public DataTableCollection AllAnalyze(DateTime Date)
        {
            DbCommand cmd = DB.GetStoredProcCommand("AllAnalyze");
            DB.AddInParameter(cmd, "@Date", DbType.DateTime, Date);
            return DB.ExecuteDataSet(cmd).Tables;
        }

        #endregion


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
    }
}
