using CampEvents.Database.Context;
using CampEvents.Database.Database;
using CommonLibs.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using DataTableOperator;
using System.Collections;

namespace CampEvents.DAL.Admin
{
    public class CampEventsAdmin : ICampEventsAdmin
    {
        protected CampEventsContext ctx = new CampEventsContext();
        #region BasicConfigs
        public Int32 UpdateBasicConfig(BasicConfig basicConfig)
        {
            int rs = 0;
            DbEntityEntry<BasicConfig> basicentry = ctx.Entry(basicConfig);
            basicentry.State = EntityState.Modified;
            basicentry.Property(p => p.ConfigName).IsModified = false;
            rs = ctx.SaveChanges();
            return rs;
        }

        public List<BasicConfig> GetBasicConfigList()
        {
            List<BasicConfig> basicconfiglist = ctx.BasicConfigs.ToList<BasicConfig>();
            return basicconfiglist;
        }
        #endregion

        #region CampConfigs
        public List<CampConfig> GetCampConfigList()
        {
            List<CampConfig> campconfiglist = ctx.CampConfigs.ToList<CampConfig>();
            return campconfiglist;
        }

        #endregion

        #region DailyTaskConfigs
        public int InsertDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            int rs = 0;
            ctx.DailyTaskConfigs.Add(dailytaskconfig);
            rs = ctx.SaveChanges();
            return rs;
        }

        public int UpdateDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            int rs = 0;
            DbEntityEntry<DailyTaskConfig> taskentry = ctx.Entry(dailytaskconfig);
            taskentry.State = EntityState.Modified;
            rs = ctx.SaveChanges();
            return rs;
        }

        public int DeleteDailyTaskConfig(DailyTaskConfig dailytaskconfig)
        {
            int rs = 0;
            DailyTaskConfig taskconfig = ctx.DailyTaskConfigs.Find(dailytaskconfig.TaskConfigId);
            if (taskconfig == null)
                return rs;
            ctx.DailyTaskConfigs.Remove(taskconfig);
            rs = ctx.SaveChanges();
            return rs;
        }

        public List<DailyTaskConfig> GetDailyTaskConfigList()
        {
            List<DailyTaskConfig> taskconfiglist = ctx.DailyTaskConfigs.ToList<DailyTaskConfig>();
            return taskconfiglist;
        }

        #endregion

        #region GameDailyLogHistories
        public List<GameDailyLogHistory> GetGameDailyLogHistoryList(ref DataPage dp, GameDailyLogHistory searchGameDailyLogHistory)
        {
            Expression<Func<GameDailyLogHistory, bool>> exp = CreateDydaminWhereAndExpression<GameDailyLogHistory>(searchGameDailyLogHistory);
            List<GameDailyLogHistory> resultlist = GetEntityQueryList(ref dp, exp, p => p.HistoryId);
            return resultlist;
        }
        #endregion

        #region GameDailyLogs

        public List<GameDailyLog> GetGameDailyLogList(ref DataPage dp, GameDailyLog searchGameDailyLog)
        {
            Expression<Func<GameDailyLog, bool>> exp = CreateDydaminWhereAndExpression<GameDailyLog>(searchGameDailyLog);
            List<GameDailyLog> resultlist = GetEntityQueryList(ref dp, exp, p => p.RecordId);
            return resultlist;
        }

        #endregion

        #region PacketQueueLogs

        public List<PacketQueueLog> GetPacketQueueLogList(ref DataPage dp, PacketQueueLog searchpacketqueuelog)
        {
            Expression<Func<PacketQueueLog, bool>> exp = CreateDydaminWhereAndExpression<PacketQueueLog>(searchpacketqueuelog);
            List<PacketQueueLog> resultlist = GetEntityQueryList(ref dp, exp, p => p.LogId);
            return resultlist;
        }

        #endregion

        #region PacketQueues

        public int InsertPacketQueue(PacketQueue packetqueue)
        {
            int rs = 0;
            ctx.PacketQueues.Add(packetqueue);
            rs = ctx.SaveChanges();
            return rs;
        }

        public int DeletePacketQueue(PacketQueue packetqueue)
        {
            int rs = 0;
            PacketQueue packetqueueentry = ctx.PacketQueues.Find(packetqueue.Id);
            if (packetqueueentry == null)
                return rs;
            ctx.PacketQueues.Remove(packetqueueentry);
            rs = ctx.SaveChanges();
            return rs;
        }

        public List<PacketQueue> GetPacketQueueList(ref DataPage dp, PacketQueue searchPacketQueue)
        {
            Expression<Func<PacketQueue, bool>> exp = CreateDydaminWhereAndExpression<PacketQueue>(searchPacketQueue);
            List<PacketQueue> list = GetEntityQueryList(ref dp, exp, p => p.Id);
            List<PacketQueue> resultlist = list.Select(p => new PacketQueue { Id = p.Id, UserId = p.UserId, AreaId = p.AreaId, AvatarId = p.AvatarId, CreateTime = p.CreateTime, FromId = p.FromId, PacketId = p.PacketId, Sex = p.Sex, Source = p.Source }).ToList<PacketQueue>();

            return resultlist;
        }

        public int CalculateFinalPackets()
        {
            int rs = 0;
            string source = "CampEvents_FinalPacket";
            List<CampConfig> campinfo = ctx.CampConfigs.ToList();
            long VictoryPoints = campinfo.Max(p => p.CurrentPoints);
            int VictoryCamp = campinfo.Where(p => p.CurrentPoints == VictoryPoints).Select(p => p.CampId).Single();
            int VictoryPacket = ctx.BasicConfigs.Where(p => p.BasicId == 3).Select(p => p.ConfigValue).Single();
            int FailPacket = ctx.BasicConfigs.Where(p => p.BasicId == 4).Select(p => p.ConfigValue).Single();
            var temp = ctx.Wallets.Join(ctx.UserCampLogs, p => new { p.AreaId, p.AvatarId, p.UserId }, t => new { t.AreaId, t.AvatarId, t.UserId }, (p,t) => new {p.AreaId,p.AvatarId,p.UserId,p.CampId,t.Sex,p.FinishedTaskNum }).GroupBy(p => new { p.AreaId, p.AvatarId, p.UserId, p.CampId,p.Sex }).Select(t => new { AreaId = t.Key.AreaId, UserId = t.Key.UserId, AvatarId = t.Key.AvatarId, CampId = t.Key.CampId, Sex=t.Key.Sex,FinishedTaskNum = t.Sum(p => p.FinishedTaskNum) }).ToList();
            List<PacketQueue> VictoryQueue = temp.Where(p => p.FinishedTaskNum >= 5&&p.CampId==VictoryCamp).Select(t => new PacketQueue { AreaId = t.AreaId, AvatarId = t.AvatarId, Source = source, PacketId = VictoryPacket, Sex = t.Sex, UserId = t.UserId }).ToList<PacketQueue>();
            List<PacketQueue> FailQueue = temp.Where(p => p.FinishedTaskNum >= 5 && p.CampId != VictoryCamp).Select(t => new PacketQueue { AreaId = t.AreaId, AvatarId = t.AvatarId, Source = source, PacketId = FailPacket, Sex = t.Sex, UserId = t.UserId }).ToList<PacketQueue>();
            ctx.PacketQueues.AddRange(VictoryQueue);
            ctx.PacketQueues.AddRange(FailQueue);
            rs = ctx.SaveChanges();
            return rs;
        }


        #endregion

        #region PointPacketConfigs
        public int InsertPointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            int rs = 0;
            ctx.PointPacketConfigs.Add(pointpacketconfig);
            rs = ctx.SaveChanges();
            return rs;
        }

        public int UpdatePointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            int rs = 0;
            DbEntityEntry<PointPacketConfig> packetentry = ctx.Entry(pointpacketconfig);
            packetentry.State = EntityState.Modified;
            rs = ctx.SaveChanges();
            return rs;
        }

        public int DeletePointPacketConfig(PointPacketConfig pointpacketconfig)
        {
            int rs = 0;
            PointPacketConfig packetentry = ctx.PointPacketConfigs.Find(pointpacketconfig.ConfigId);
            if (packetentry == null)
                return rs;
            ctx.PointPacketConfigs.Remove(packetentry);
            rs = ctx.SaveChanges();
            return rs;
        }

        public List<PointPacketConfig> GetPointPacketConfigsList(ref DataPage dp)
        {
            Expression<Func<PointPacketConfig, bool>> exp = PredicateExtensionses.True<PointPacketConfig>();
            List<PointPacketConfig> packetentrylist = GetEntityQueryList(ref dp, exp, p => p.ConfigId);
            return packetentrylist;
        }


        #endregion

        #region PointPacketExchangeLogs
        public List<PointPacketExchangeLog> GetPointPacketExchangeLogList(ref DataPage dp, PointPacketExchangeLog searchPointPacketExchangeLog)
        {
            Expression<Func<PointPacketExchangeLog, bool>> exp = CreateDydaminWhereAndExpression<PointPacketExchangeLog>(searchPointPacketExchangeLog);
            List<PointPacketExchangeLog> list = GetEntityQueryList(ref dp, exp, p => p.Id);
            List<PointPacketExchangeLog> resultlist = list.Select(p => new PointPacketExchangeLog {PointPacketConfigId=p.PointPacketConfigId ,UserId = p.UserId, AreaId = p.AreaId, AvatarId = p.AvatarId, AvatarName = p.AvatarName, CreateTime = p.CreateTime, LoginName=p.LoginName,Sex=p.Sex,Id=p.Id,CurrentPoints=p.CurrentPoints}).ToList<PointPacketExchangeLog>();

            return resultlist;
        }
        #endregion

        #region RankListTop20

        public int InsertRankListTop20(RankListTop20 ranklisttop20)
        {
            int rs = 0;
            ctx.RankListTop20s.Add(ranklisttop20);
            rs = ctx.SaveChanges();
            return rs;
        }

        public int DeleteRankListTop20(RankListTop20 ranklisttop20)
        {
            int rs = 0;
            RankListTop20 ranktentry = ctx.RankListTop20s.Find(ranklisttop20.Id);
            if (ranktentry == null)
                return rs;
            ctx.RankListTop20s.Remove(ranktentry);
            rs = ctx.SaveChanges();
            return rs;
        }

        public List<RankListTop20> GetRankListTop20List(ref DataPage dp, RankListTop20 searchRankListTop20)
        {
            Expression<Func<RankListTop20, bool>> exp = CreateDydaminWhereAndExpression<RankListTop20>(searchRankListTop20);
            List<RankListTop20> resultlist = GetEntityQueryList(ref dp, exp, p => p.Id);
            return resultlist;
        }

        public int CalculateRankPacket(RankListTop20 rankinfo, int packetid)
        {
            int rs = 0;
            string source = "CampEvents_RankPacket";
            rankinfo = ctx.RankListTop20s.Where(p => p.Id == rankinfo.Id).Single();
            int sex = ctx.UserCampLogs.Where(p => p.AreaId == rankinfo.AreaId && p.AvatarId == rankinfo.AvatarId && p.UserId == rankinfo.UserId).Select(p => p.Sex).Single();
            PacketQueue packetqueue = new PacketQueue() { UserId = rankinfo.UserId, AreaId = rankinfo.AreaId, AvatarId = rankinfo.AvatarId, Source = source, Sex = sex, PacketId = packetid };
            ctx.PacketQueues.Add(packetqueue);
            rs = ctx.SaveChanges();
            return rs;
        }


        #endregion

        #region UserCampLogs
        public List<UserCampLog> GetUserCampLogList(ref DataPage dp, UserCampLog searchUserCampLog)
        {
            Expression<Func<UserCampLog, bool>> exp = CreateDydaminWhereAndExpression<UserCampLog>(searchUserCampLog);
            List<UserCampLog> list = GetEntityQueryList(ref dp, exp, p => p.LogId);
            List<UserCampLog> resultlist = list.Select(p => new UserCampLog { UserId = p.UserId, AreaId = p.AreaId, AvatarId = p.AvatarId, Sex = p.Sex, CampId = p.CampId, AvatarName = p.AvatarName, LogId = p.LogId, CreateTime = p.CreateTime, LoginName = p.LoginName }).ToList<UserCampLog>();
            return resultlist;
        }
        #endregion

        #region Wallets
        public int InsertWallet(Wallet wallet)
        {
            int rs = 0;
            long camppoints = ctx.Wallets.Where(p => p.CampId == wallet.CampId).Sum(p => (long?)p.DailyGetPoints).GetValueOrDefault() + wallet.DailyGetPoints;
            CampConfig campinfo = ctx.CampConfigs.Where(p => p.CampId == wallet.CampId).Single();
            campinfo.CurrentPoints = camppoints;
            DbEntityEntry<CampConfig> campentry = ctx.Entry(campinfo);
            campentry.State = EntityState.Modified;
            ctx.Wallets.Add(wallet);
            rs = ctx.SaveChanges();
            return rs;
        }

        public int DeleteWallet(Wallet wallet)
        {
            int rs = 0;
            Wallet walletentry = ctx.Wallets.Find(wallet.WId);
            if (walletentry == null)
                return rs;
            long camppoints = ctx.Wallets.Where(p => p.CampId == wallet.CampId).Sum(p => (long?)p.DailyGetPoints).GetValueOrDefault() - wallet.DailyGetPoints;
            CampConfig campinfo = ctx.CampConfigs.Where(p => p.CampId == wallet.CampId).Single();
            campinfo.CurrentPoints = camppoints;
            DbEntityEntry<CampConfig> campentry = ctx.Entry(campinfo);
            campentry.State = EntityState.Modified;
            ctx.Wallets.Remove(walletentry);
            rs = ctx.SaveChanges();
            return rs;
        }

        public List<Wallet> GetWalletList(ref DataPage dp, Wallet searchwallet)
        {
            Expression<Func<Wallet, bool>> exp = CreateDydaminWhereAndExpression<Wallet>(searchwallet);
            List<Wallet> list = GetEntityQueryList(ref dp, exp, p => p.WId);
            List<Wallet> resultlist = list.Select(p => new Wallet { UserId = p.UserId, WId = p.WId, AreaId = p.AreaId, AvatarId = p.AvatarId, AvatarName = p.AvatarName, CreateTime = p.CreateTime, BalancePoints = p.BalancePoints, DailyGetPoints = p.DailyGetPoints, Source = p.Source, RecordDate = p.RecordDate, FinishedTaskNum = p.FinishedTaskNum, CampId = p.CampId, FromId = p.FromId }).ToList<Wallet>();
            return resultlist;
        }

        #endregion

        #region Public

        public Expression<Func<T, bool>> CreateDydaminWhereAndExpression<T>(T querymodel) where T : class
        {
            Expression<Func<T, bool>> finalexpression = PredicateExtensionses.True<T>();
            if (querymodel == null)
            {
                return finalexpression;
            }
            Type t = querymodel.GetType();
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo item in properties)
            {
                object value = item.GetValue(querymodel, null);
                if (value != null)
                {
                    Type valuetype = value.GetType();
                    if (valuetype != typeof(Int32) && valuetype != typeof(Int64))
                    {
                        if (valuetype == typeof(DateTime) && (DateTime)value != DateTime.Parse("1900/1/1 0:00:00") && (DateTime)value != default(DateTime))
                        {
                            DateTime startdate = DateTime.Parse(Convert.ToDateTime(value).ToShortDateString());
                            DateTime enddate = startdate.AddDays(1);
                            Expression<Func<T, bool>> startexpression = ExpressionOperator.CreateCompareExpression<T>(item.Name, startdate, "greaterthanorequal");
                            Expression<Func<T, bool>> endexpression = ExpressionOperator.CreateCompareExpression<T>(item.Name, enddate, "lessthan");
                            finalexpression = finalexpression.And<T>(startexpression).And<T>(endexpression);

                        }
                        if (valuetype != typeof(DateTime) && valuetype != typeof(Boolean))
                        {
                            Expression<Func<T, bool>> currentexpression = ExpressionOperator.CreateCompareExpression<T>(item.Name, value);
                            finalexpression = finalexpression.And<T>(currentexpression);
                        }
                    }
                    else
                    {
                        long convervalue = Convert.ToInt64(value);
                        if (convervalue != 0)
                        {
                            Expression<Func<T, bool>> currentexpression = ExpressionOperator.CreateCompareExpression<T>(item.Name, value);
                            finalexpression = finalexpression.And<T>(currentexpression);
                        }
                    }

                }

            }
            return finalexpression;
        }

        private List<T> GetEntityQueryList<T, U>(ref DataPage dp, Expression<Func<T, bool>> exp, Expression<Func<T, U>> orderexp) where T : class
        {

            List<T> querylist = new List<T>();
            DbSet<T> _dbset = ctx.Set<T>();
            dp.RowCount = _dbset.Where(exp).Count();
            if (dp.PageSize == 0)
            {
                querylist = _dbset.Where(exp).OrderByDescending(orderexp).ToList<T>();
            }
            else
            {
                querylist = _dbset.Where(exp).OrderByDescending(orderexp).Skip(dp.PageSize * (dp.PageIndex - 1)).Take(dp.PageSize).ToList<T>();
            }
            return querylist;

        }

        #endregion

    }
}
