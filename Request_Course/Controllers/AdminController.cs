using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

namespace Request_Course.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _services;
        public AdminController(IRepository repository)
        {
            _services = repository;
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
            var Modares = await _services.GetModaresan(modaresId);
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
        public async Task<IActionResult> UpdateModares(ModaresanUpdateVM model, int modaresId, IFormFile image)
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
            await _services.UpdateModaresan(Modares, image);
            return View();
        }

        public async Task<IActionResult> BindModaresToDoreh()
        {
            var Doreh = await _services.GetDorehforBinding();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BindModaresToDoreh(int dorehId)
        {
            var Modares = await _services.GetModaresan();
            return View(Modares);
        }
        [HttpPost]
        public async Task<IActionResult> FinalBindModares(int dorehid, int modaresid)
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

        public async Task<IActionResult> DefineOnvanAsliAndOnvanDoreh(string OnvanAsli, string OnvanDoreh)
        {
            await _services.AddOnvanAsliAndOnvanDoreh(OnvanAsli, OnvanDoreh);
            return RedirectToAction("DefineOnvanAsliAndOnvanDoreh");
        }

        public async Task<IActionResult> DorehFaal()
        {
            var model = await _services.GetDorehMokhatabFaal();
            return View(model);
        }

        public async Task<IActionResult> DorehPygiry()
        {
            var model = await _services.GetDorehMokhatabPygiry();
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

        #region Adimn & User
        public async Task<IActionResult> AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AdminCreateVM model, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            T_Admin t_Admin = new T_Admin()
            {
                Admin = model.IsAdmin,
                Code = "",
                Name = model.Name,
                Password = model.Password,
                Phone = model.Phone,
                User = model.IsUser,
                UserName = model.Username,
            };
            await _services.AddAdmin(t_Admin, img);
            return RedirectToAction("Admins");
        }
        public async Task<IActionResult> UpdateAdmin(int id)
        {
            var Model = _services.GetAdmin(id);
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(AdminUpdateVM model, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Admin = await _services.GetAdmin(model.id);
            if (Admin!=null)
            {
                Admin.Phone = model.Phone;
                Admin.Admin = model.IsAdmin;
                Admin.User = model.IsUser;
                Admin.Name = model.Name;
                Admin.Password = model.Password;
                await _services.EditAdmin(Admin, img);
            }
            return RedirectToAction("Admins");
        }
        public async Task<IActionResult> RmoveAdmin(int adminId)
        {
            await _services.RemoveAdmin(adminId);
            return RedirectToAction("Admins");
        }
        public async Task<IActionResult> Admins()
        {
            var Model = await _services.GetAdminsList();
            return View(Model);
        }
        public async Task<IActionResult> UpdateUser(int id)
        {
            var Model = _services.GetAdmin(id);
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateVM model, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var User = await _services.GetAdmin(model.id);
            if (User != null)
            {
                User.Name = model.Name;
                User.Password = model.Password;
                User.Phone = model.Phone;
                await _services.EditAdmin(User, img);
            }
            return RedirectToAction("Users");
        }
        public async Task<IActionResult> Users()
        {
            var model = await _services.GetUsersList();
            return View();
        }

        #endregion

    }
}
