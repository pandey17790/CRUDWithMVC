using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using CRUDOperationMVC.Models;

namespace CRUDOperationMVC.Filters
{
    public class ExceptionLog: FilterAttribute, IExceptionFilter
    {
        Connections con = new Connections();
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now
                };

                con.AddExceptionData(logger);
                filterContext.ExceptionHandled = true;
            }
        }
    }
}