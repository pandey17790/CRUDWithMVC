using System.Web;
using System.Web.Mvc;
using CRUDOperationMVC.Filters;

namespace CRUDOperationMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionLog());
        }
    }
}
