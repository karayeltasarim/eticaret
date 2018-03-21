using System.Web;
using System.Web.Mvc;

namespace KarayelTasarimEticaret2016
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
