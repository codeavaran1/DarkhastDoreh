using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Models;
using Request_Course.Serivces;
using Request_Course.Serivces.Interface;
using Request_Course.VM;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        public async Task<IActionResult> Modaresan(int pageId = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name)==null)
            //{
            //    return BadRequest();
            //}
            var reslut = await _services.GetModaresan(pageId, "ali");
            var model = reslut.Item1;
            ViewBag.pagecount = reslut.Item2;
            ViewBag.pageid = pageId;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateModares()
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            List<Modaresan_Fild_AsliVM> modaresan_Fild_AsliVMs = new List<Modaresan_Fild_AsliVM>();
            List<SelectListItem> Reshte = _services.GetReshtehTahsilis().Result
                .Select(x => new SelectListItem { Value = x.ID_ReshtehTahsili.ToString(), Text = x.Titles_ReshtehTahsili }).ToList();
            Reshte.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            List<SelectListItem> MaghtaeTahsili_Drop = _services.GetMaghtaeTahsili().Result
                .Select(x => new SelectListItem { Value = x.ID_MaghtaeTahsili.ToString(), Text = x.Titles_MaghtaeTahsili }).ToList();
            MaghtaeTahsili_Drop.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            List<SelectListItem> DaragehElmi = _services.GetDaragehElmis().Result
                .Select(x => new SelectListItem { Value = x.ID_DaragehElmi.ToString(), Text = x.Titles_DaragehElmi }).ToList();
            DaragehElmi.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            List<SelectListItem> FildAsli = _services.GetFildAslis().Result
                .Select(x => new SelectListItem { Value = x.ID_FildAsli.ToString(), Text = x.Titles_FildAsli }).ToList();
            FildAsli.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            List<SelectListItem> OnvanDoreh = _services.GetOnvanDorehs().Result
                .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(), Text = x.Titles_OnvanDoreh }).ToList();
            OnvanDoreh.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            ViewBag.MaghtaeTahsili_Drop = MaghtaeTahsili_Drop;
            ViewBag.Reshte = Reshte;
            ViewBag.FildAsli = FildAsli;
            ViewBag.DaragehElmi = DaragehElmi;
            ViewBag.OnvanDoreh = OnvanDoreh;
            ViewBag.Fild_Asli = modaresan_Fild_AsliVMs;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateModares(ModaresanVM model, IFormFile img, List<string> FildAsli, List<string> OnvanDoreh, string MaghtaeTahsili = ""
            , string Reshte = "", string DaragehElmi = "",string NameFamilyr="")
        {
            ModelState.Remove("img");
            if (!ModelState.IsValid || Reshte == "0" || MaghtaeTahsili == "0" || DaragehElmi == "0")
            {
                List<Modaresan_Fild_AsliVM> modaresan_Fild_AsliVMs1 = new List<Modaresan_Fild_AsliVM>();
                List<SelectListItem> Reshte1 = _services.GetReshtehTahsilis().Result
                    .Select(x => new SelectListItem { Value = x.ID_ReshtehTahsili.ToString(), Text = x.Titles_ReshtehTahsili }).ToList();
                Reshte1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
                List<SelectListItem> MaghtaeTahsili_Drop1 = _services.GetMaghtaeTahsili().Result
                    .Select(x => new SelectListItem { Value = x.ID_MaghtaeTahsili.ToString(), Text = x.Titles_MaghtaeTahsili }).ToList();
                MaghtaeTahsili_Drop1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
                List<SelectListItem> DaragehElmi1 = _services.GetDaragehElmis().Result
                    .Select(x => new SelectListItem { Value = x.ID_DaragehElmi.ToString(), Text = x.Titles_DaragehElmi }).ToList();
                DaragehElmi1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
                List<SelectListItem> FildAsli1 = _services.GetFildAslis().Result
                    .Select(x => new SelectListItem { Value = x.ID_FildAsli.ToString(), Text = x.Titles_FildAsli }).ToList();
                FildAsli1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
                List<SelectListItem> OnvanDoreh1 = _services.GetOnvanDorehs().Result
                    .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(), Text = x.Titles_OnvanDoreh }).ToList();
                OnvanDoreh1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });

                ViewBag.MaghtaeTahsili_Drop = MaghtaeTahsili_Drop1;
                ViewBag.Reshte = Reshte1;
                ViewBag.FildAsli = FildAsli1;
                ViewBag.DaragehElmi = DaragehElmi1;
                ViewBag.OnvanDoreh = OnvanDoreh1;
                ViewBag.Fild_Asli = modaresan_Fild_AsliVMs1;

                return View(model);
            }

            T_Modaresan t_Modaresan = new T_Modaresan()
            {
                Email = model.Email,
                DateCreate = DateTime.Now,
                Daneshgah_Sherkat = model.Daneshgah_Reshteh,
                Mobile = model.Phone,
                Phone = model.Phone,
                Onvan_Shoghli = model.OnvanShoghli,
                Description = model.Description,
                T_L_MaghtaeTahsili_ID = null,
                T_L_ReshtehTahsili_ID = null,
                T_L_DaragehElmi_ID = null,
                NameFamily= NameFamilyr,
            };
            if (MaghtaeTahsili != "0")
            {
                t_Modaresan.T_L_MaghtaeTahsili_ID = Convert.ToInt32(MaghtaeTahsili);
                t_Modaresan.MadrakTahsili = await _services.GetMadraktahsilibyId(Convert.ToInt32(MaghtaeTahsili));
            }
            if (Reshte != "0")
            {
                t_Modaresan.T_L_ReshtehTahsili_ID = Convert.ToInt32(Reshte);
            }
            if (DaragehElmi != "0")
            {
                t_Modaresan.T_L_DaragehElmi_ID = Convert.ToInt32(DaragehElmi);
            }
            var Modearseid = await _services.AddModares(t_Modaresan, img);
            List<T_Modaresan_Fild_Amozeshi> t_Modaresan_Fild_Amozeshi = new List<T_Modaresan_Fild_Amozeshi>();
            for (int i = 0; i < FildAsli.Count; i++)
            {
                T_Modaresan_Fild_Amozeshi t_Modaresan_Fild_Amozeshi_one = new T_Modaresan_Fild_Amozeshi();
                t_Modaresan_Fild_Amozeshi_one.T_L_FildAsli_ID = Convert.ToInt16(FildAsli[i]);
                t_Modaresan_Fild_Amozeshi_one.T_L_OnvanDoreh_ID = Convert.ToInt16(OnvanDoreh[i]);
                t_Modaresan_Fild_Amozeshi_one.T_Modaresan_ID = Modearseid;
                t_Modaresan_Fild_Amozeshi.Add(t_Modaresan_Fild_Amozeshi_one);
            }
            await _services.AddModaresanFildAsli(t_Modaresan_Fild_Amozeshi);
            T_Activation t_Activation = new T_Activation()
            {
                Phone = model.Phone,
                code = "12345",
                DateGenerateCode = DateTime.Now,
                NameFamily = NameFamilyr,
                Teacher=true,
                Student=false, 
            };
            await _services.AddActivation(t_Activation);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateModares(int modaresId)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
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

        public async Task<IActionResult> BindModaresToDoreh(int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetDorehWithoutModares(pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            List<int> DorehId = new List<int>();
            foreach (var item in result.Item1)
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);
                DorehId.Add(item.ID_Doreh_Darkhasti);
                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            var Model = result.Item1.Count();
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            ViewBag.Dorehid = DorehId;
            return View(Model);
        }

        public async Task<IActionResult> ModarsanPishnadiDoreh(int dorehId)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            string Teacher1 = null;
            string Teacher2 = null;
            string Teacher3 = null;
            T_Doreh_Darkhasti Doreh = await _services.GetDoreh_Darkhasti(dorehId);
            var pishnahad_MOdares = await _services.GetPishnahad_Modares_Doreh(dorehId);
            ModaresanPishnahadi model = new ModaresanPishnahadi();
            if (pishnahad_MOdares!=null)
            {
                model.TeacherPshanmdiName1 = pishnahad_MOdares.Pishnahad_Modares_Name1;
                model.TeacherPshanmdiName2 = pishnahad_MOdares.Pishnahad_Modares_Name2;
                model.TeacherPshanmdiName3 = pishnahad_MOdares.Pishnahad_Modares_Name3;
            }
           
            T_Pishnahad_Modares_Doreh Teachers = await _services.GetPishnahad_Modares_Doreh(dorehId);
            if (Teachers != null)
            {
                if (Teachers.T_Modaresan_ID1 != null)
                {
                    Teacher1 = await _services.GetTeacherName(Teachers.T_Modaresan_ID1.Value);
                    model.ID_Teahcername1 =Teachers.T_Modaresan_ID1.Value;
                    model.Teahcername1 = Teacher1;
                }
                if (Teachers.T_Modaresan_ID2 != null)
                {
                    Teacher2 = await _services.GetTeacherName(Teachers.T_Modaresan_ID2.Value);
                    model.ID_Teahcername2 = Teachers.T_Modaresan_ID2.Value;
                    model.Teahcername2 = Teacher2;
                }
                if (Teachers.T_Modaresan_ID3 != null)
                {
                    Teacher3 = await _services.GetTeacherName(Teachers.T_Modaresan_ID3.Value);
                    model.Teahcername3 = Teacher3;
                    model.ID_Teahcername3 = Teachers.T_Modaresan_ID3.Value;
                }
            }
            ViewBag.DorehId=dorehId;
            return View(model);
        }

        public async Task<IActionResult> BindModaresToDorehFindModare(int dorehId, int pageId = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            var reslut = await _services.GetModaresan(pageId, "ali");
            var model = reslut.Item1;
            ViewBag.pagecount = reslut.Item2;
            ViewBag.pageid = pageId;
            ViewBag.dorehid = dorehId;
            return View(model);

        }

        public async Task<IActionResult> FinalBindModares(int dorehid, int modaresid)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            await _services.BindModresToDoreh(dorehid, modaresid);
            return RedirectToAction("BindModaresToDoreh");
        }

        #endregion

        #region Doreh
        public async Task<IActionResult> Doreh(int pageid = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }

            var result = await _services.GetDoreh(pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            foreach (var item in result.Item1)
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            var Model = result.Item1.Count();
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(Model);
        }

        public async Task<IActionResult> DefineOnvanAsliAndOnvanDoreh()
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
               .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            ViewBag.Sheklejra = Sheklejra;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DefineOnvanAsliAndOnvanDoreh(string OnvanAsli, string OnvanDoreh, List<string> Mohtav, List<string> Modate_Ejra,
            List<string> shekldoreh)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            await _services.AddOnvanAsliAndOnvanDoreh(OnvanAsli, OnvanDoreh);
            int onvanAsli = await _services.GetOnvanAsliByName(OnvanAsli);
            int onvanDoreh= await _services.GetOnvanDorehByName(OnvanDoreh);
            List<T_Fasl_Doreh> List_Fasl = new List<T_Fasl_Doreh>();
            for (int i = 0; i < Mohtav.Count; i++)
            {
                T_Fasl_Doreh t_Fasl_Doreh = new T_Fasl_Doreh()
                {
                    Modate_Ejra = Modate_Ejra[i],
                    Mohtav = Mohtav[i],
                    Shekle_Ejra = shekldoreh[i],
                    T_L_OnvanAsli_ID=onvanAsli,
                    T_L_OnvanDoreh_ID=onvanDoreh
                };
                List_Fasl.Add(t_Fasl_Doreh);

            }
            await _services.AddSarFasl(List_Fasl);
            return RedirectToAction("DefineOnvanAsliAndOnvanDoreh");
        }

        public async Task<IActionResult> DorehFaal(int pageid = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            var result = await _services.GetDorehMokhatabFaalAdmin(pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            foreach (var item in result.Item1)
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            var Model = result.Item1.Count();
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(Model);
        }

        public async Task<IActionResult> DorehPygiry(int pageid = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            var result = await _services.GetDorehMokhatabPygiryAdmin(pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            foreach (var item in result.Item1)
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            var Model = result.Item1.Count();
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(Model);
        }

        public async Task<IActionResult> DorehGhabl(int pageid = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            var result = await _services.GetDorehMokhatabGhablAdmin(pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            foreach (var item in result.Item1)
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            var Model = result.Item1.Count();
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(Model);
        }
        #endregion

        #region Requster
        public async Task<IActionResult> Sherkatha(int pageid = 1)
        {
            var reslut = await _services.GetSherkatha(pageid);
            var model = reslut.Item1;
            ViewBag.pagecount = reslut.Item2;
            ViewBag.pageid = pageid;
            return View(model);
        }
        #endregion

        #region Adimn & User
        public async Task<IActionResult> Admins(int pageid = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            var result = await _services.GetAdminsList(pageid);
            var model = result.Item1;
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            return View(model);
        }
        public async Task<IActionResult> AddAdmin()
        {
            var admin = await _services.GetAdmin(User.Identity.Name);
            if ( admin== null || admin.Admin==false)
            {
                return BadRequest();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AdminCreateVM model, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Admin = await _services.GetAdmin(model.Username);
            if (Admin != null)
            {
                return View();
            }
            T_Admin t_Admin = new T_Admin()
            {
                Admin = model.IsAdmin,
                Code = "",
                Name = model.Name,
                Password = Encreption.MD5Hash(model.Password),
                Phone = model.Phone,
                User = model.IsUser,
                UserName = model.Username,
            };
            await _services.AddAdmin(t_Admin, img);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateAdmin(string username)
        {
            var result = await _services.GetAdmin(username);
            AdminUpdateVM model = new AdminUpdateVM()
            {
                IsAdmin = result.Admin,
                IsUser = result.User,
                Name = result.Name,
                UsreName = result.UserName,
                Password = "",
                Phone = result.Phone
            };
            ViewBag.username = username;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAdmin(AdminUpdateVM model, IFormFile img, string username)
        {
            ModelState.Remove("img");
            if (!ModelState.IsValid )
            {
                return View(model);
            }
            var Admin = await _services.GetAdmin(username);
            if (Admin != null)
            {
                Admin.Phone = model.Phone;
                Admin.Admin = model.IsAdmin;
                Admin.User = model.IsUser;
                Admin.Name = model.Name;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    Admin.Password = Encreption.MD5Hash(model.Password);
                }
                await _services.EditAdmin(Admin, img);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RmoveAdmin(string username)
        {
            await _services.RemoveAdmin(username);
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> AddUser()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddUser(AdminCreateVM model,IFormFile img)
        //{
        //    // use AdminCreateVM beacuse user and Admin the same
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var User = await _services.GetAdmin(model.Username);
        //    if (User!= null)
        //    {
        //        return View();
        //    }
        //    T_Admin t_Admin = new T_Admin()
        //    {
        //        Admin = model.IsAdmin,
        //        Code = "",
        //        Name = model.Name,
        //        Password = Encreption.MD5Hash(model.Password),
        //        Phone = model.Phone,
        //        User = model.IsUser,
        //        UserName = model.Username,
        //    };
        //    return View();
        //}

        //public async Task<IActionResult> UpdateUser(string username)
        //{
        //    var Model = _services.GetAdmin(username);
        //    return View(Model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateUser(UserUpdateVM model, IFormFile img)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var User = await _services.GetAdmin(model.Usename);
        //    if (User != null)
        //    {
        //        User.Name = model.Name;
        //        User.Password = Encreption.MD5Hash(model.Password);
        //        User.Phone = model.Phone;
        //        await _services.EditAdmin(User, img);
        //    }
        //    return RedirectToAction("Users");
        //}
        public async Task<IActionResult> Users(int pageid = 1)
        {
            if (await _services.GetAdmin(User.Identity.Name) == null)
            {
                return BadRequest();
            }
            var result = await _services.GetUsersList(pageid);
            var model = result.Item1;
            ViewBag.pagecount = result.Item2;
            ViewBag.pageid = pageid;
            return View(model);

        }
        #endregion

        #region Login logout
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            string password = Encreption.MD5Hash(loginVM.Password);
            var user = await _services.GetAdmin(loginVM.UserName, password);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "ورود غیر مجاز شما ثبت شد");
                return View(loginVM);
            }
            var clm = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.ID_Admin.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),

            };
            var identity = new ClaimsIdentity(clm, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = loginVM.RememberMe
            };
            await HttpContext.SignInAsync(principle, properties);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login", "Home");
        }
        #endregion

        #region Cerdential

        public async Task<IActionResult> Certificates()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetCertificate(CertificateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            return RedirectToAction("Certificates");
        }

        #endregion

    }
}