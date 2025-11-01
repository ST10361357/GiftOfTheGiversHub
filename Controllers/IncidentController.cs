using Microsoft.AspNetCore.Mvc;

namespace GiftOfTheGiversHub.Controllers
{
    public class IncidentController : Controller
    {
        [HttpGet]
        public IActionResult ReportIncident()
        {
            return View();
        }
    }
}
