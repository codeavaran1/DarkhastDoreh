using Microsoft.AspNetCore.Mvc;
using Request_Course.Serivces.Interface;

namespace Request_Course.Controllers
{
    public class MokhatabController : Controller
    {
        private IRepository _services;
        public MokhatabController(IRepository repository)
        {
            _services = repository; 
        }

        public async Task<IActionResult> MokhatibProfile(string phone)
        {
            var model = await _services.GetMokhatebin(phone);
            return View();
        }

        public async Task<IActionResult> DorehMokhatbfaal(string phone)
        {
            var user = _services.GetMokhatebin(phone).Result.ID_Mokhatebin;
            var model=_services.GetDorehMokhatabFaal(user);
            return View(model);
        }

        public async Task<IActionResult> DorehMokhatbGhabli(string phone)
        {
            var user = _services.GetMokhatebin(phone).Result.ID_Mokhatebin;
            var model = _services.GetDorehMokhatabGhabl(user);
            return View(model);
        }
        public async Task<IActionResult> DorehMokhatbPygiry(string phone)
        {
            var user = _services.GetMokhatebin(phone).Result.ID_Mokhatebin;
            var model = _services.GetDorehMokhatabPygiry(user);
            return View(model);
        }

        public async Task<IActionResult> RequestCertificate()
        {
            return View();
        }



    }
}
