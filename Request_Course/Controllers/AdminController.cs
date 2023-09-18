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
        public async Task<IActionResult> Index()
        {
            return View();
        }

        #region chart
        [HttpPost]
        public async Task<List<object>> charting()
        {
            List<object> data = new List<object>();
            List<string> labels = new List<string>();
            var Result = await _services.GetDorehByMonthForChart();
            foreach (var item in Result.Item1)
            {
                labels.Add(item.ToString());
            }
            List<int> total = new List<int>();
            foreach (var item in Result.Item2)
            {
                total.Add(item);
            }
            data.Add(labels);
            data.Add(total);
            return data;
        }


        #endregion

        #region Modaresan

        public async Task<IActionResult> ModaresanTest(string sortOrder, string search, int pageid = 1)
        {
            ViewBag.searchQuery = string.IsNullOrEmpty(search) ? "" : search;
            var result = await _services.GetMOdaresanTest(search, sortOrder, pageid);
            return View(result);
        }

        public async Task<IActionResult> Modaresan(string sortOrder, string search, int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name)==null)
            //{
            //    return BadRequest();
            //}

            //Create Modares
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

            // List Teacher
            ViewBag.searchQuery = string.IsNullOrEmpty(search) ? "" : search;
            var result = await _services.GetModaresan(search, sortOrder, pageid);

            return View(result);
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
            , string Reshte = "", string DaragehElmi = "", string NameFamilyr = "")
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
                NameFamily = NameFamilyr,
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
                Teacher = true,
                Student = false,
            };
            await _services.AddActivation(t_Activation);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateModaresAdmin(string Phone, string Email, string Daneshgah_Reshteh
            , string Description, string OnvanShoghli
            , IFormFile img, List<string> FildAsli, List<string> OnvanDoreh, string MaghtaeTahsili = ""
           , string Reshte = "", string DaragehElmi = "", string NameFamilyr = "")
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

                return View();
            }

            T_Modaresan t_Modaresan = new T_Modaresan()
            {
                Email = Email,
                DateCreate = DateTime.Now,
                Daneshgah_Sherkat = Daneshgah_Reshteh,
                Mobile = Phone,
                Phone = Phone,
                Onvan_Shoghli = OnvanShoghli,
                Description = Description,
                T_L_MaghtaeTahsili_ID = null,
                T_L_ReshtehTahsili_ID = null,
                T_L_DaragehElmi_ID = null,
                NameFamily = NameFamilyr,
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
                Phone = Phone,
                code = "12345",
                DateGenerateCode = DateTime.Now,
                NameFamily = NameFamilyr,
                Teacher = true,
                Student = false,
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

            string DaregEml = await _services.GetDategeElmibyid(Modares.T_L_DaragehElmi_ID.Value);
            string MaghtaeTahsili = await _services.GetMadraktahsilibyId(Modares.T_L_MaghtaeTahsili_ID.Value);
            string Reshteh = await _services.GetReshtehTahsilibyid(Modares.T_L_ReshtehTahsili_ID.Value);
            List<SelectListItem> DaragehElmi1 = _services.GetDaragehElmis().Result
                  .Select(x => new SelectListItem { Value = x.ID_DaragehElmi.ToString(), Text = x.Titles_DaragehElmi }).ToList();
            DaragehElmi1.Insert(0, new SelectListItem { Value = Modares.T_L_DaragehElmi_ID.ToString(), Text = DaregEml });
            List<SelectListItem> MaghtaeTahsili_Drop1 = _services.GetMaghtaeTahsili().Result
                   .Select(x => new SelectListItem { Value = x.ID_MaghtaeTahsili.ToString(), Text = x.Titles_MaghtaeTahsili }).ToList();
            MaghtaeTahsili_Drop1.Insert(0, new SelectListItem { Value = Modares.T_L_MaghtaeTahsili_ID.ToString(), Text = MaghtaeTahsili });
            List<SelectListItem> Reshte1 = _services.GetReshtehTahsilis().Result
                   .Select(x => new SelectListItem { Value = x.ID_ReshtehTahsili.ToString(), Text = x.Titles_ReshtehTahsili }).ToList();
            Reshte1.Insert(0, new SelectListItem { Value = Modares.T_L_ReshtehTahsili_ID.ToString(), Text = Reshteh });

            ViewBag.Maghta = MaghtaeTahsili_Drop1;
            ViewBag.Reshte_Drop = Reshte1;
            ViewBag.DaregElm_Drop = DaragehElmi1;
            ViewBag.ID = modaresId;
            ModaresanUpdateVM model = new ModaresanUpdateVM()
            {
                Daneshgah_Sherkat = Modares.Daneshgah_Sherkat,
                Description = Modares.Description,
                Email = Modares.Email,
                NameFamily = Modares.NameFamily,
                Onvan_Shoghli = Modares.Onvan_Shoghli,
                Phone = Modares.Phone
            };
            ViewBag.img = Modares.img;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateModares(ModaresanUpdateVM model, int modaresId, IFormFile img, string maghtaehtasili = "", string Reshte = "", string DaregElmi = "")
        {
            bool username_Uniq = true;
            var Modares = await _services.GetModaresan(modaresId);
            if (model.Phone!=Modares.Phone)
            {
                username_Uniq=await _services.UniqPhoneModares(model.Phone);
            }
            ModelState.Remove("img");
            if (!ModelState.IsValid || username_Uniq==false)
            {
                string DaregEml = await _services.GetDategeElmibyid(Modares.T_L_DaragehElmi_ID.Value);
                string MaghtaeTahsili = await _services.GetMadraktahsilibyId(Modares.T_L_MaghtaeTahsili_ID.Value);
                string Reshteh = await _services.GetReshtehTahsilibyid(Modares.T_L_ReshtehTahsili_ID.Value);
                List<SelectListItem> DaragehElmi1 = _services.GetDaragehElmis().Result
                      .Select(x => new SelectListItem { Value = x.ID_DaragehElmi.ToString(), Text = x.Titles_DaragehElmi }).ToList();
                DaragehElmi1.Insert(0, new SelectListItem { Value = Modares.T_L_DaragehElmi_ID.ToString(), Text = DaregEml });
                List<SelectListItem> MaghtaeTahsili_Drop1 = _services.GetMaghtaeTahsili().Result
                       .Select(x => new SelectListItem { Value = x.ID_MaghtaeTahsili.ToString(), Text = x.Titles_MaghtaeTahsili }).ToList();
                MaghtaeTahsili_Drop1.Insert(0, new SelectListItem { Value = Modares.T_L_MaghtaeTahsili_ID.ToString(), Text = MaghtaeTahsili });
                List<SelectListItem> Reshte1 = _services.GetReshtehTahsilis().Result
                       .Select(x => new SelectListItem { Value = x.ID_ReshtehTahsili.ToString(), Text = x.Titles_ReshtehTahsili }).ToList();
                Reshte1.Insert(0, new SelectListItem { Value = Modares.T_L_ReshtehTahsili_ID.ToString(), Text = Reshteh });
                ViewBag.Maghta = MaghtaeTahsili_Drop1;
                ViewBag.Reshte_Drop = Reshte1;
                ViewBag.DaregElm_Drop = DaragehElmi1;
                return View(model);
            }
            
            Modares.Daneshgah_Sherkat = model.Daneshgah_Sherkat;
            Modares.Description = model.Description;
            Modares.T_L_DaragehElmi_ID = Convert.ToInt32(DaregElmi);
            Modares.T_L_MaghtaeTahsili_ID = Convert.ToInt32(maghtaehtasili);
            Modares.T_L_ReshtehTahsili_ID = Convert.ToInt32(Reshte);
            Modares.Email = model.Email;
            Modares.MadrakTahsili = await _services.GetMadraktahsilibyId(Modares.T_L_MaghtaeTahsili_ID.Value);
            Modares.NameFamily = model.NameFamily;
            Modares.Onvan_Shoghli = model.Onvan_Shoghli;
            Modares.Phone = model.Phone;
            await _services.UpdateModaresan(Modares, img);
            return View();
        }

        public async Task<IActionResult> DeleteModares(int modaresId)
        {
            await _services.RemoveTeacher(modaresId);
            return RedirectToAction("Modaresan");

        }



        public async Task<IActionResult> BindModaresToDoreh(string search = "", string sortOrder = "", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetDorehWithoutModares(search, sortOrder, pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            List<int> DorehId = new List<int>();
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);
                DorehId.Add(item.ID_Doreh_Darkhasti);
                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            ViewBag.Dorehid = DorehId;
            return View(result);
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
            T_Pishnahad_Modares_Doreh Teachers = await _services.GetPishnahad_Modares_Doreh(dorehId);
            ModaresanPishnahadi model = new ModaresanPishnahadi();
            if (Teachers != null)
            {
                model.TeacherPshanmdiName1 = Teachers.Pishnahad_Modares_Name1;
                model.TeacherPshanmdiName2 = Teachers.Pishnahad_Modares_Name2;
                model.TeacherPshanmdiName3 = Teachers.Pishnahad_Modares_Name3;
                model.TeacherPshanmdiNumber1 = Teachers.Pishnahad_Modares_phone1;
                model.TeacherPshanmdiNumber2 = Teachers.Pishnahad_Modares_phone2;
                model.TeacherPshanmdiNumber3 = Teachers.Pishnahad_Modares_phone3;

                if (Teachers.T_Modaresan_ID1 != null)
                {
                    Teacher1 = await _services.GetTeacherName(Teachers.T_Modaresan_ID1.Value);
                    model.ID_Teahcername1 = Teachers.T_Modaresan_ID1.Value;
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
            ViewBag.DorehId = dorehId;
            return View(model);
        }

        public async Task<IActionResult> BindModaresToDorehFindModare(int dorehId, int pageId = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var reslut = await _services.GetModaresan(pageId);
            ViewBag.pageid = pageId;
            ViewBag.dorehid = dorehId;
            return View(reslut);

        }

        public async Task<IActionResult> BindModaresPishnahadi(int Dorehid = 0, string Phone = "")
        {
            bool result = await _services.GetModaresPishnahadiForBind(Dorehid, Phone);
            if (result == true)
            {
                return RedirectToAction("BindModaresToDoreh");
            }
            return View(result);
        }

        public async Task<IActionResult> FinalBindModares(int dorehid, int modaresid)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            await _services.BindModresToDoreh(dorehid, modaresid);
            return View();
        }

        #endregion

        #region Doreh
        public async Task<IActionResult> Doreh(string search = "", string sortOrder = "", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetDoreh(search, sortOrder, pageid);
            List<string> OnvanDoreh = new List<string>();
            List<int> IdDoreh = new List<int>();
            List<string> Mokhatab = new List<string>();
            List<string> VaziatDoreh = new List<string>();
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);
                IdDoreh.Add(item.ID_Doreh_Darkhasti);
                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
                VaziatDoreh.Add(await _services.GetVaziatDorehbyid(item.T_L_Vaziyat_Doreh_ID.Value));
            }
            ViewBag.mokhatab = Mokhatab;
            ViewBag.Dorehid = IdDoreh;
            ViewBag.onvandoreh = OnvanDoreh;
            ViewBag.VaziatDoreh = VaziatDoreh;
            return View(result);
        }

        public async Task<IActionResult> DeleteDoreh(int id)
        {
            var doreh = await _services.GetDoreh_Darkhasti(id);
            if (doreh == null)
            {
                return NotFound();
            }
            doreh.IsFinaly = false;
            doreh.T_L_Vaziyat_Doreh_ID = 4;
            await _services.UpdateDoreh(doreh);
            return RedirectToAction("Doreh");
        }

        public async Task<IActionResult> DorehFaal(string search = "", string sortOrder = "", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetDorehMokhatabFaalAdmin(search, sortOrder, pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            List<int> IdDoreh = new List<int>();
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
                IdDoreh.Add(item.ID_Doreh_Darkhasti);
            }
            ViewBag.mokhatab = Mokhatab;
            ViewBag.Dorehid = IdDoreh;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(result);
        }

        public async Task<IActionResult> DorehPygiry(string search = "", string sortOrder = "", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetDorehMokhatabPygiryAdmin(search, sortOrder, pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
            List<int> IdDoreh = new List<int>();
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
                IdDoreh.Add(item.ID_Doreh_Darkhasti);
            }
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            ViewBag.Dorehid = IdDoreh;
            return View(result);
        }

        public async Task<IActionResult> DorehGhabl(string search = "", string sortOrder = "", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetDorehMokhatabGhablAdmin(search, sortOrder, pageid);
            List<string> OnvanDoreh = new List<string>();
            List<string> Mokhatab = new List<string>();
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
                string mokhatab = await _services.GetMokhatabinDoreh(item.T_Mokhatebin_ID.Value);

                OnvanDoreh.Add(onvandoreh);
                Mokhatab.Add(mokhatab);
            }
            ViewBag.mokhatab = Mokhatab;
            ViewBag.onvandoreh = OnvanDoreh;
            return View(result);
        }

        public async Task<IActionResult> DefineOnvanAsliAndOnvanDoreh(int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
               .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            ViewBag.Sheklejra = Sheklejra;

            var model = await _services.GetT_Fasle_Dorehs(pageid);
            List<string> onvanasli = new List<string>();
            List<string> onvanDoreh = new List<string>();
            foreach (var item in model)
            {
                onvanasli.Add(await _services.GetOnvanAsli(item.T_L_OnvanAsli_ID.Value));
                onvanDoreh.Add(await _services.GetOnvanDoreh(item.T_L_OnvanDoreh_ID.Value));
            }
            ViewBag.onvanAsli = onvanasli;
            ViewBag.onvanDoreh = onvanDoreh;
            return View(model);
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
            int onvanDoreh = await _services.GetOnvanDorehByName(OnvanDoreh);
            List<T_Fasl_Doreh> List_Fasl = new List<T_Fasl_Doreh>();
            for (int i = 0; i < Mohtav.Count; i++)
            {
                T_Fasl_Doreh t_Fasl_Doreh = new T_Fasl_Doreh()
                {
                    Modate_Ejra = Modate_Ejra[i],
                    Mohtav = Mohtav[i],
                    Shekle_Ejra = shekldoreh[i],
                    T_L_OnvanAsli_ID = onvanAsli,
                    T_L_OnvanDoreh_ID = onvanDoreh
                };
                List_Fasl.Add(t_Fasl_Doreh);

            }
            await _services.AddSarFasl(List_Fasl);
            return RedirectToAction("DefineOnvanAsliAndOnvanDoreh");
        }

        public async Task<IActionResult> UpdateOnvanAsliAndOnvanDoreh(int Id)
        {
            var Onvanss = await _services.GetT_Fasl_DorehById(Id);
            if (Onvanss == null)
            {
                return NotFound();
            }

            string onvanasli = await _services.GetOnvanAslisbyid(Onvanss.T_L_OnvanAsli_ID.Value);
            string onvandoreh = await _services.GetOnvanDorehbyid(Onvanss.T_L_OnvanDoreh_ID.Value);
            int shekejra_id = await _services.Get_RaveshAmozeshiByName(Onvanss.Shekle_Ejra);

            List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
             .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            Sheklejra.Insert(0, new SelectListItem { Value = Onvanss.Shekle_Ejra, Text = Onvanss.Shekle_Ejra });
            ViewBag.Sheklejra = Sheklejra;
            ViewBag.onvansasli = onvanasli;
            ViewBag.onvandoreh = onvandoreh;
            ViewBag.mohtava = Onvanss.Mohtav;
            ViewBag.modateejra = Onvanss.Modate_Ejra;
            ViewBag.id = Id;

            return View(Onvanss);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOnvanAsliAndOnvanDoreh(int T_Fasel_Doreh_Id, string Mohtav, string Modate_Ejra, string shekldoreh)
        {
            var update = await _services.GetT_Fasl_DorehById(T_Fasel_Doreh_Id);
            update.Mohtav = Mohtav;
            update.Modate_Ejra = Modate_Ejra;
            update.Shekle_Ejra = shekldoreh;
            await _services.Update_T_Fasle_Doreh(update);
            return RedirectToAction("DefineOnvanAsliAndOnvanDoreh");
        }

        #endregion

        #region Requster
        public async Task<IActionResult> Sherkatha(string sortOrder = "", string search = "", int pageid = 1)
        {
            var reslut = await _services.GetSherkatha(search, sortOrder, pageid);
            return View(reslut);
        }

        public async Task<IActionResult> GetDorehOfSherkat(int MokhatabId, int pageid = 1)
        {
            var reslut = await _services.GetDoreh_DarkhastisForMokhatab(MokhatabId, pageid);
            List<string> onvanAsli = new List<string>();
            List<string> onvanDoreh = new List<string>();
            List<string> Vaziat = new List<string>();
            List<int> Id = new List<int>();
            foreach (var item in reslut)
            {
                onvanAsli.Add(await _services.GetOnvanAslisbyid(item.T_L_OnvanAsli_ID.Value));
                onvanDoreh.Add(await _services.GetOnvanDorehbyid(item.T_L_OnvanDoreh_ID.Value));
                Vaziat.Add(await _services.GetVaziatDorehbyid(item.T_L_Vaziyat_Doreh_ID.Value));
                Id.Add(item.ID_Doreh_Darkhasti);
            }
            ViewBag.OnvanAsli = onvanAsli;
            ViewBag.OnvanDoreh = onvanDoreh;
            ViewBag.Vaziat = Vaziat;
            ViewBag.ID = Id;
            ViewBag.MokhatabId = MokhatabId;
            return View(reslut);
        }

        public async Task<IActionResult> DeleteSherkat(int MokhatabId)
        {
            return null;
        }
        public async Task<IActionResult> AddDorehForSherkat(int mokhatabId)
        {
            var mokhatab = await _services.GetMokhatebinById(mokhatabId);
            if (mokhatab == null)
            {
                return NotFound();
            }
            string Family = mokhatab.NamFamily_Rabet;
            string Name_Sherkat = mokhatab.Name_Sherkat;
            string Phone = mokhatab.Phone;

            return RedirectToAction("Request_DorehAmozeshi", "Request", new
            {
                Family = Family,
                Name_Sherkat = Name_Sherkat,
                Phone = Phone,
            });

        }

        public async Task<IActionResult> DeleteDorehOfSherkat(int DorehId)
        {
            await _services.RemoveDoreh(DorehId);
            return RedirectToAction("Sherkatha");
        }

        public async Task<IActionResult> SetSatehSherkat(int sherkatId)
        {
            var sherkat =await _services.GetMokhatebinById(sherkatId);
            if (sherkat.T_L_Sathe_Sherkat_ID!=null)
            {
                ViewBag.image=sherkat.T_L_Sathe_Sherkat_ID;
            }
            List<SelectListItem> sateh = _services.GetSathe_Sherkat().Result
                    .Select(x => new SelectListItem { Value = x.ID_Sathe_Sherkat.ToString(), Text = x.Titles_Sathe_Sherkat}).ToList();
            sateh.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            ViewBag.SatehSherkat = sateh;
            ViewBag.SherkatId = sherkatId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SetSatehSherkat(string sateh,int sherkatId)
        {
            await _services.SetSatehSherkat(int.Parse(sateh), sherkatId);
            return RedirectToAction("Sherkatha");
        }


        #endregion

        #region Adimn & User
        public async Task<IActionResult> Admins(string sortOrder="", string search="", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetAdminsList(search,sortOrder,pageid);
            return View(result);
        }

        public async Task<IActionResult> AddAdmin()
        {
            var admin = await _services.GetAdmin(User.Identity.Name);
            //if (admin == null || admin.Admin == false)
            //{
            //    return BadRequest();
            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AdminCreateVM model, IFormFile img)
        {
            ModelState.Remove("img");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Admin = await _services.GetAdmin(model.Username);
            //if (Admin != null)
            //{
            //    return View();
            //}
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
            if (!ModelState.IsValid)
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
        public async Task<IActionResult> AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AdminCreateVM model, IFormFile img)
        {
            // use admincreatevm beacuse user and admin the same
            ModelState.Remove("img");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _services.GetAdmin(model.Username);
            if (user != null)
            {
                return View();
            }
            T_Admin t_admin = new T_Admin()
            {
                Admin = model.IsAdmin,
                Code = "",
                Name = model.Name,
                Password = Encreption.MD5Hash(model.Password),
                Phone = model.Phone,
                User = model.IsUser,
                UserName = model.Username,
            };
            await _services.AddAdmin(t_admin, img);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateUser(string username)
        {
            var Model = _services.GetAdmin(username);
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateVM model, IFormFile img)
        {
            ModelState.Remove("img");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var User = await _services.GetAdmin(model.Usename);
            if (User != null)
            {
                User.Name = model.Name;
                User.Password = Encreption.MD5Hash(model.Password);
                User.Phone = model.Phone;
                await _services.EditAdmin(User, img);
            }
            return RedirectToAction("Users");
        }
        public async Task<IActionResult> Users(string sortOrder="", string search="", int pageid = 1)
        {
            //if (await _services.GetAdmin(User.Identity.Name) == null)
            //{
            //    return BadRequest();
            //}
            var result = await _services.GetUsersList(search,sortOrder,pageid);
            return View(result);

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