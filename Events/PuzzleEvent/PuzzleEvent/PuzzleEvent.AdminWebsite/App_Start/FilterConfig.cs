using System.Web;
using System.Web.Mvc;

namespace PuzzleEvent.AdminWebsite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}