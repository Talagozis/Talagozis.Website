using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Talagozis.Website.Controllers
{
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.ViewBag.startTime = DateTime.Now;
            this.ViewBag.AssemblyVersion = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version.ToString() ?? string.Empty;

            base.OnActionExecuting(context);
        }
    }
}