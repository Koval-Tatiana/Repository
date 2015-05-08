using lab9_ASP_MVC_Views.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace lab9_ASP_MVC_Views.Controllers
{
    [LogActionFilter()]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ChildList()
        {
            MyData data = new MyData();
            return PartialView(data);
        }

  
        public ActionResult PrintTable(string table)
        {
            MyData data = new MyData();
            var val = data.getData(table).ToList();
            return View(val);
        }

    }

    public class LogActionFilter : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var path = filterContext.HttpContext.Server.MapPath("~/App_Data/Log.csv");
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("{0};{1}", DateTime.Now.ToLocalTime(), filterContext.HttpContext.Request.Url);
                }
            }
            catch { }
            base.OnActionExecuted(filterContext);


        }
    }
}