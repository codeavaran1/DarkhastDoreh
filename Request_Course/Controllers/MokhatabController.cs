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
        public async Task<IActionResult> index(string phone="")
        {
            ViewBag.Phone = phone;
            return View();  
        }

        public async Task<IActionResult> MokhatibProfile(string phone)
        {
            ViewBag.Phone = phone;
            var model = await _services.GetMokhatebin(phone);
            return View();
        }

        public async Task<IActionResult> DorehMokhatbfaal(string phone,string search="",string sortOrder="",int pageid=1)
        {
            ViewBag.Phone = phone;
            var user =_services.GetMokhatebin(phone).Result.ID_Mokhatebin;
            var result=await _services.GetDorehMokhatabFaal(user,search,sortOrder, pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Modares = new List<string>();
            foreach (var item in result)
            {
                string onvandoreh = "";
                if (item.T_L_OnvanDoreh_ID != null)
                {
                    onvandoreh = await _services.GetOnvanDoreh(item.T_L_OnvanDoreh_ID.Value);
                }
                else
                {
                    onvandoreh = item.OnvanDoreh_Jadid;
                }
                string Mmodares =_services.GetModaresan(item.T_Modaresan_ID.Value).Result.NameFamily;

                OnvanDoreh.Add(onvandoreh);
                Modares.Add(Mmodares);
            }
            ViewBag.Modares = Modares;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(result);
        }

        public async Task<IActionResult> DorehMokhatbGhabli(string phone, string search="", string sortOrder="", int pageid = 1)
        {
            ViewBag.Phone = phone;
            var user = _services.GetMokhatebin(phone).Result.ID_Mokhatebin;
            var result = await _services.GetDorehMokhatabGhabl(user,search,sortOrder,pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Modares = new List<string>();
            List<int> DoreId = new List<int>();
            foreach (var item in result)
            {
                string onvandoreh = "";
                if (item.T_L_OnvanDoreh_ID != null)
                {
                    onvandoreh = await _services.GetOnvanDoreh(item.T_L_OnvanDoreh_ID.Value);
                }
                else
                {
                    onvandoreh = item.OnvanDoreh_Jadid;
                }
                string Mmodares = _services.GetModaresan(item.T_Modaresan_ID.Value).Result.NameFamily;

                OnvanDoreh.Add(onvandoreh);
                Modares.Add(Mmodares);
                DoreId.Add(item.ID_Doreh_Darkhasti);
            }
            ViewBag.Modares = Modares;
            ViewBag.DoreId = DoreId;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(result);
        }
        public async Task<IActionResult> DorehMokhatbPygiry(string phone, string search="", string sortOrder="", int pageid = 1)
        {
            ViewBag.Phone = phone;
            var user = _services.GetMokhatebin(phone).Result.ID_Mokhatebin;
            var result = await _services.GetDorehMokhatabPygiry(user,search,sortOrder,pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Modares = new List<string>();
            foreach (var item in result)
            {
                string onvandoreh = "";
                if (item.T_L_OnvanDoreh_ID != null)
                {
                    onvandoreh = await _services.GetOnvanDoreh(item.T_L_OnvanDoreh_ID.Value);
                }
                else
                {
                    onvandoreh = item.OnvanDoreh_Jadid;
                }
                string Mmodares = _services.GetModaresan(item.T_Modaresan_ID.Value).Result.NameFamily;

                OnvanDoreh.Add(onvandoreh);
                Modares.Add(Mmodares);
            }
            ViewBag.Modares = Modares;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(result);
        }       

        public async Task<IActionResult> RequestCertificate(string phone)
        {
            return RedirectToAction("DorehMokhatbGhabli", new { phone = phone });
        }

        public async Task<IActionResult> Certificate(string phone)
        {
            ViewBag.Phone = phone;
            return View();
        }



    }
}
