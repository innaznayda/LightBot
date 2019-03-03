using System.Web.Mvc;

namespace LightBot.Controllers {
    public class HomeController : Controller {
        public string Index() {
            return "It's my telegram bot";
        }
    }
}