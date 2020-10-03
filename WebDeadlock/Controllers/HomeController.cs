using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebDeadlock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Http Synchronization Context blocked here
            DoSomethingAsync().Wait();

            ViewBag.Title = "Home Page";

            return View();
        }

        private async Task DoSomethingAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            // Http Synchronization Context is trying to continue method on the UI thread here but it has already blocked
        }
    }
}
