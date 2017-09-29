using CampEvents.Database.Context;
using CampEvents.Database.Database;
using LogBLLV2;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using CampEvents.Database.Enums;

namespace CampEvents.DAL
{
    public class CampEventsDAL : ICampEventsDAL
    {
        protected CampEventsContext ctx = new CampEventsContext();

        public ResultInfo UserChooseCamp(UserInfo userinfo)
        {
            string source = "ChooseCamp";
            ResultInfo resultinfo = new ResultInfo() { Result = ErrorCode.JoinCampFailed };
            bool IsExists = ctx.UserCampLogs.Any(p => p.AreaId == userinfo.AreaId && p.AvatarId == userinfo.AvatarId && p.UserId == userinfo.UserId);
            bool CampIsExists = ctx.CampConfigs.Any(p => p.CampId == userinfo.CampId);
            int LoginPoints = ctx.DailyTaskConfigs.Where(p => p.TaskConfigId == 1).Select(p => p.GetPoints).SingleOrDefault();
            if (IsExists)
            {
                resultinfo.Result = ErrorCode.RepeatJoinFailed;
                return resultinfo;
            }
            if (LoginPoints < 1 || !CampIsExists)
            {
                resultinfo.Result = ErrorCode.CampErrorFailed;
                return resultinfo;
            }
            int FirstCampPeople = ctx.CampConfigs.Where(p => p.CampId == userinfo.CampId).Select(p => p.CurrentPeople).SingleOrDefault();
            long FirstCampPoints = ctx.CampConfigs.Where(p => p.CampId == userinfo.CampId).Select(p => p.CurrentPoints).SingleOrDefault();
            int SecondCampPeople = ctx.CampConfigs.Where(p => p.CampId != userinfo.CampId).Select(p => p.CurrentPeople).SingleOrDefault();
            //阵营相差人数上限(对比人数差)
            int PeopleNumLimit = ctx.BasicConfigs.Where(p => p.BasicId == 1).Select(p => p.ConfigValue).SingleOrDefault();
            //阵营人数调整起始值(对比总人数)
            int PeopleAdjustNum = ctx.BasicConfigs.Where(p => p.BasicId == 2).Select(p => p.ConfigValue).SingleOrDefault();
            //总人数
            int TotalPeople = FirstCampPeople + SecondCampPeople;
            //人数差
            int PeopleDiff = System.Math.Abs(FirstCampPeople - SecondCampPeople);
            if (PeopleDiff > PeopleNumLimit && TotalPeople > PeopleAdjustNum && FirstCampPeople > SecondCampPeople)
            {
                resultinfo.Result = ErrorCode.CampLimitFailed;
                return resultinfo;
            }
            UserCampLog usercamplog = new UserCampLog() { UserId = userinfo.UserId, AreaId = userinfo.AreaId, AvatarId = userinfo.AvatarId, CampId = userinfo.CampId, LoginName = userinfo.LoginName, Sex = userinfo.Sex, AvatarName = userinfo.AvatarName };
            ctx.UserCampLogs.Add(usercamplog);
            Wallet wallet = new Wallet() { UserId = userinfo.UserId, AreaId = userinfo.AreaId, AvatarId = userinfo.AvatarId, AvatarName = userinfo.AvatarName, CampId = userinfo.CampId, RecordDate = System.DateTime.Now, Source = source, BalancePoints = LoginPoints, DailyGetPoints = LoginPoints, FromId = usercamplog.LogId, FinishedTaskNum = 1 };
            ctx.Wallets.Add(wallet);
            using (DbContextTransaction ts = ctx.Database.BeginTransaction())
            {
                int joinrs = ctx.SaveChanges();
                if (joinrs == 2)
                {
                    int updaters = ctx.CampConfigs.Where(p => p.CampId == usercamplog.CampId && p.CurrentPeople == FirstCampPeople && p.CurrentPoints == FirstCampPoints).Update(p => new CampConfig { CurrentPeople = FirstCampPeople + 1, CurrentPoints = FirstCampPoints + LoginPoints });
                    if (updaters == 1)
                    {
                        ts.Commit();
                        resultinfo.Result = ErrorCode.Succuess;
                        return resultinfo;
                    }
                    else
                    {
                        ts.Rollback();
                        resultinfo.Result = ErrorCode.JoinCampFailed;
                        return resultinfo;
                    }
                }
            }

            return resultinfo;

        }

        public List<RankListTop20> GetRankListTop20(UserInfo userinfo)
        {
            List<RankListTop20> RankList = new List<RankListTop20>();
            int CampId = ctx.UserCampLogs.Where(p => p.AreaId == userinfo.AreaId && p.UserId == userinfo.UserId && p.AvatarId == userinfo.AvatarId).Select(p => p.CampId).SingleOrDefault();
            if (CampId == default(int))
                return RankList;
            RankList = ctx.RankListTop20s.Where(p => p.CampId == CampId).ToList<RankListTop20>();
            return RankList;
        }

        public ResultInfo ExchangePointPacket(UserInfo userinfo)
        {
            string source = "CampEvents_ExchangePointPacket";
            ResultInfo resultinfo = new ResultInfo() { Result = ErrorCode.PacketFailed, IsNotice = false, PacketName = "" };
            int CampId = ctx.UserCampLogs.Where(p => p.AreaId == userinfo.AreaId && p.UserId == userinfo.UserId && p.AvatarId == userinfo.AvatarId).Select(p => p.CampId).SingleOrDefault();
            if (CampId == default(int))
            {
                resultinfo.Result = ErrorCode.NoCampFailed;
                return resultinfo;
            }
            int TotalPoints = ctx.Wallets.Where(p => p.AreaId == userinfo.AreaId && p.UserId == userinfo.UserId && p.AvatarId == userinfo.AvatarId).Sum(p => (int?)p.DailyGetPoints).GetValueOrDefault();
            //阵营不同个人积分奖励不同
            //PointPacketConfig packetlist = ctx.PointPacketConfigs.Where(p => p.CampId == CampId && p.NeedPoints <= TotalPoints && p.ShowId == userinfo.ExchangeID).SingleOrDefault();
            //阵营不同个人积分奖励相同
            PointPacketConfig packetlist = ctx.PointPacketConfigs.Where(p => p.NeedPoints <= TotalPoints && p.ShowId == userinfo.ExchangeID).SingleOrDefault();

            if (packetlist == null)
            {
                resultinfo.Result = ErrorCode.NoPoints;
                return resultinfo;
            }
            bool IsExistRecord = ctx.PointPacketExchangeLogs.Any(p => p.AreaId == userinfo.AreaId && p.UserId == userinfo.UserId && p.AvatarId == userinfo.AvatarId && p.PointPacketConfigId == packetlist.ConfigId);
            if (IsExistRecord)
            {
                resultinfo.Result = ErrorCode.RepeatedFailed;
                return resultinfo;
            }
            PointPacketExchangeLog exchangelog = new PointPacketExchangeLog() { UserId = userinfo.UserId, AreaId = userinfo.AreaId, AvatarId = userinfo.AvatarId, AvatarName = userinfo.AvatarName, Sex = userinfo.Sex, LoginName = userinfo.LoginName, CurrentPoints = TotalPoints, PointPacketConfigId = packetlist.ConfigId };
            ctx.PointPacketExchangeLogs.Add(exchangelog);
            PacketQueue packetqueue = new PacketQueue() { UserId = userinfo.UserId, AreaId = userinfo.AreaId, AvatarId = userinfo.AvatarId, Sex = userinfo.Sex, PacketId = packetlist.PacketId, Source = source, FromId = exchangelog.Id };
            ctx.PacketQueues.Add(packetqueue);
            int rs = ctx.SaveChanges();
            if (rs == 2)
            {
                resultinfo.Result = ErrorCode.Succuess;
                resultinfo.IsNotice = packetlist.IsNotice;
                resultinfo.PacketName = packetlist.PacketName;
            }
            return resultinfo;
        }

        public ResultInfo GetUserInfo(UserInfo userinfo)
        {
            ResultInfo resultinfo = new ResultInfo() { Result = ErrorCode.UnSuccessful };
            int CampId = ctx.UserCampLogs.Where(p => p.AreaId == userinfo.AreaId && p.UserId == userinfo.UserId && p.AvatarId == userinfo.AvatarId).Select(p => p.CampId).SingleOrDefault();
            if (CampId == default(int))
            {
                resultinfo.Result = ErrorCode.NoCampFailed;
                return resultinfo;
            }
            DateTime cutofftime=new DateTime();
            resultinfo.Result = ErrorCode.Succuess;
            resultinfo.CampId = CampId;
            resultinfo.CampPoints = ctx.CampConfigs.Where(p => p.CampId == CampId).Select(p => p.CurrentPoints).SingleOrDefault();
            resultinfo.UserPoints = ctx.Wallets.Where(p => p.AreaId == userinfo.AreaId && p.UserId == userinfo.UserId && p.AvatarId == userinfo.AvatarId).Sum(p => (int?)p.DailyGetPoints).GetValueOrDefault();
            cutofftime = ctx.Wallets.Where(p => p.Source == "Event_Src_DailyLog").Max(p => (DateTime?)p.RecordDate).GetValueOrDefault();
            resultinfo.CutOffTime = cutofftime.AddDays(1).AddSeconds(-1);
            return resultinfo;
        }
        public List<CampConfig> GetCampInfo()
        {
            List<CampConfig> camp = ctx.CampConfigs.ToList<CampConfig>();
            return camp;
        }


        //private int SaveCommit(string Note)
        //{
        //    try
        //    {
        //        ctx.SaveChanges();
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorLog.Instance.AddErrLog(ex, Note);
        //        return 0;
        //    }
        //}

    }
}
