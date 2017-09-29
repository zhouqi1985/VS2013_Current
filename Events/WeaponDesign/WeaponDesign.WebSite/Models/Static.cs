using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeaponDesign.Database.Database;

namespace WeaponDesign.WebSite.Models
{
    public class Static
    {
        static WeaponDesign.DAL.WCF.Client.IWeaponDesignServiceClient client = new WeaponDesign.DAL.WCF.Client.WeaponDesignServiceClient();

        static object locker = new object();

        public static int AddWeaponList(WeaponList weaponlist)
        {
            lock (locker)
            {
                return client.AddWeaponList(weaponlist);
            }
        }

        public static int AddPraiseLog(PraiseLog pralog)
        {
            lock (locker)
            {
                return client.AddPraiseLog(pralog);
            }
        }
    }
}