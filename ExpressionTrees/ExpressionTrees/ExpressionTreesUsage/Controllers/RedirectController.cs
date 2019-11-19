using Microsoft.AspNetCore.Mvc;

namespace ExpressionTreesUsage.Controllers
{
    public class RedirectController : Controller
    {
        public IActionResult MyAction(int id, string query) => this.View();
    }
}
