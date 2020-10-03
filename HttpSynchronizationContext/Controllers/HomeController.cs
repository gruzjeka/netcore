using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HttpSynchronizationContext.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            int value = 13;

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Trace.WriteLine(HttpContext.GetHashCode());

            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Trace.WriteLine(HttpContext.GetHashCode());

            value *= 2;

            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Trace.WriteLine(HttpContext.GetHashCode());

            return View();
        }

        public async Task<ActionResult> About()
        {
            int value = 13;

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Trace.WriteLine(HttpContext.GetHashCode());

            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Trace.WriteLine(HttpContext.GetHashCode());

            value *= 2;

            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Trace.WriteLine(HttpContext.GetHashCode());

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}