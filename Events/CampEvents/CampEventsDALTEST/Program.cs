using CampEvents.Database.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogBLLV2;
using CampEvents.Database.Context;
using CommonLibs.Common;


namespace CampEventsDALTEST
{
    class Program
    {
        //public static List<Wallet> WalletList(ref DataPage dp, Wallet wallet)
        //{
        //    CampEventsAdminService.CampEventsAdminServiceClient _admin;
        //    _admin = new CampEventsAdminService.CampEventsAdminServiceClient();
        //    List<Wallet> lists = new List<Wallet>();
        //    try
        //    {
        //        lists = _admin.GetWalletList(ref dp, wallet);
        //        _admin.Close();
        //        return lists;
        //    }
        //    catch (Exception ex)
        //    {
        //        _admin.CloseCatch(ex, "GetWalletList failed");
        //        return lists;
        //    }
        //}
        
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet();


            DataPage dp=new DataPage(){PageIndex=1,PageSize=20};
            CampEvents.DAL.Admin.ICampEventsAdmin _dal = new CampEvents.DAL.Admin.CampEventsAdmin();
            //List<Wallet> lists = WalletList(ref dp, wallet)
                 List<Wallet> lists =_dal.GetWalletList(ref dp,wallet);

 

            //int rs = _dal.UserChooseCamp(userinfo);


            //CampEventsService.CampEventsServiceClient _client;
            //_client = new CampEventsService.CampEventsServiceClient();
            //int rs = 0;
            //try
            //{
            //    rs = _client.UserChooseCamp(userinfo);
            //    _client.Close();

            //}
            //catch (Exception ex)
            //{
            //    _client.CloseCatch(ex, "UserChooseCamp Failed");

            //}



            foreach (Wallet p in lists)
            {
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", p.CampId, p.UserId, p.AreaId, p.AvatarId, p.WId, p.FromId, p.UserCampLog.LogId,p.CampConfig.CampName);

            }

            //CampEvents.DAL.WCF.Client.ICampEventsServiceClient CampEventsBll = new CampEvents.DAL.WCF.Client.CampEventsServiceClient();
            //int resultinfo = CampEventsBll.UserChooseCamp(userinfo);
            Console.WriteLine("OK");
            Console.ReadLine();

        }
    }
}
