using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

namespace Request_Course.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _services;
        public AdminController(IRepository repository)
        {
            _services=repository;   
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Modaresan
        public async Task<IActionResult> Modaresan()
        {
            var model = await _services.GetModaresan();
            return View();
        }

        public async Task<IActionResult> CreateModares()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateModares(int model)
        {
            return View(model);
        }

        public async Task<IActionResult> UpdateModares(int modaresId)
        {
            var Modares =await _services.GetModaresan(modaresId);
            ModaresanUpdateVM model = new ModaresanUpdateVM()
            {
                Active = Modares.Active,
                Daneshgah_Sherkat = Modares.Daneshgah_Sherkat,
                Description = Modares.Description,
                Email = Modares.Email,
                MadrakTahsili = Modares.MadrakTahsili,
                NameFamily = Modares.NameFamily,
                Onvan_Shoghli = Modares.Onvan_Shoghli,
                Phone = Modares.Phone
            };
            ViewBag.img = Modares.img;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateModares(ModaresanUpdateVM model,int modaresId,IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Modares = await _services.GetModaresan(modaresId);
            Modares.Active = model.Active;
            Modares.Daneshgah_Sherkat = model.Daneshgah_Sherkat;
            Modares.Description = model.Description;
            Modares.Email = model.Email;
            Modares.MadrakTahsili = model.MadrakTahsili;
            Modares.NameFamily = model.NameFamily;
            Modares.Onvan_Shoghli = model.Onvan_Shoghli;
            Modares.Phone = model.Phone;
            await _services.UpdateModaresan(Modares ,image); 
            return View();
        }

        public async Task<IActionResult> BindModaresToDoreh()
        {
            var Doreh=await _services.GetDorehforBinding();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BindModaresToDoreh(int dorehId)
        {
            var Modares = await _services.GetModaresan();
            return View(Modares);
        }
        [HttpPost]
        public async Task<IActionResult> FinalBindModares(int dorehid,int modaresid)
        {
            await _services.BindModresToDoreh(dorehid, modaresid);
            return RedirectToAction("BindModaresToDoreh");
        }

        #endregion

        #region Doreh
        public async Task<IActionResult> Doreh()
        {
            var Model = await _services.GetDorehforBinding();
            return View(Model);
        }

        public async Task<IActionResult> DefineOnvanAsliAndOnvanDoreh()
        {
            return View();
        }

        public async Task<IActionResult> DefineOnvanAsliAndOnvanDoreh(string OnvanAsli,string OnvanDoreh)
        {
            await _services.AddOnvanAsliAndOnvanDoreh(OnvanAsli, OnvanDoreh);
            return RedirectToAction("DefineOnvanAsliAndOnvanDoreh");
        }

        public async Task<IActionResult> DorehFaal()
        {
            var model=await _services.GetDorehMokhatabFaal();
            return View(model);
        }

        public async Task<IActionResult> DorehPygiry()
        {
            var model=await _services.GetDorehMokhatabPygiry();
            return View();
        }

        public async Task<IActionResult> DorehGhabl()
        {
            var model = await _services.GetDorehMokhatabGhabl();
            return View(model);
        }
        #endregion

        #region Requster
        public async Task<IActionResult> Sherkatha()
        {
            var model = await _services.GetSherkatha();
            return View(model);
        }
        #endregion



    }
}
