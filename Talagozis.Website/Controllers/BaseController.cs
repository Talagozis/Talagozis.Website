using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Talagozis.Website.Controllers
{
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.startTime = DateTime.Now;
            ViewBag.AssemblyVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

            base.OnActionExecuting(context);
        }
    }
}