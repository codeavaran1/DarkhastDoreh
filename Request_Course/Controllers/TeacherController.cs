using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;
using System.Security.Claims;

namespace Request_Course.Controllers
{
    public class TeacherController : Controller
    {
        private IRepository _services;
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".PNG" };
        public TeacherController(IRepository repository)
        {
            _services = repository;
        }

        #region Teacher Schema

        public async Task<IActionResult> Index(int teacherId = 0)
        {
            ViewBag.teacherid = teacherId;
            return View();
        }


        #endregion

        #region Teacher Panel
        public async Task<IActionResult> DorehTadrisShodeh(int TeacherId, string search = "", string sortOrder = "", int paegid = 1)
        {
            ViewBag.teacherid = TeacherId;
            var result = await _services.GetDoreh_Teacher(TeacherId, search, sortOrder, paegid);
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

        public async Task<IActionResult> DorehFaal(int teacherid, string search = "", string sortOrder = "", int paegid = 1)
        {
            ViewBag.teacherid = teacherid;
            var result = await _services.GetDoreh_Faal_Teacher(teacherid, search, sortOrder, paegid);
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

        public async Task<IActionResult> DorehGhabil(int teacherid, string search = "", string sortOrder = "", int paegid = 1)
        {
            ViewBag.teacherid = teacherid;
            var result = await _services.GetDoreh_ghabil(teacherid, search, sortOrder, paegid);

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

        [HttpGet]
        public async Task<IActionResult> TeacherInfo(int teacherid = 0)
        {
            ViewBag.teacherid = teacherid;
            T_Modaresan Teacher = new T_Modaresan();
            if (teacherid != 0)
            {
                Teacher = await _services.GetModaresan(teacherid);
            }
            else
            {
                return NotFound();
            }
            var teacher_name = _services.GetActivation(Teacher.Phone).Result.NameFamily;
            var teacher_MaghtaeTahsili = Teacher.MadrakTahsili;
            TeacherInfoVM model = new TeacherInfoVM()
            {
                Name = teacher_name,
                MadrakTahsili = Teacher.MadrakTahsili,
                OnvanShoghly = Teacher.Onvan_Shoghli,
                MaghtaeTahsili = teacher_MaghtaeTahsili,
                img = Teacher.img,
                Phone = Teacher.Phone,
                Description = Teacher.Description,
                NomrehTadris = Teacher.Avg_Nomreh_Tadris_float.ToString(),
                RotbebeinModaresan = Teacher.Rotbe_Modares.ToString(),
            };
            return View(model);
        }

        public async Task<IActionResult> UpdateModares(int teacherid = 0)
        {
            ViewBag.teacherid = teacherid;
            var Modares = await _services.GetModaresan(teacherid);

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
            ViewBag.ID = teacherid;
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
        public async Task<IActionResult> UpdateModares(ModaresanUpdateVM model, int modaresId, IFormFile img, string Sll, string maghtaehtasili = "", string Reshte = "", string DaregElmi = "")
        {
            bool username_Uniq = true;
            var Modares = await _services.GetModaresan(modaresId);
            if (model.Phone != Modares.Phone)
            {
                username_Uniq = await _services.UniqPhoneModares(model.Phone);
            }
            bool ImageValid = true;
            if (img != null)
            {
                if (!ImageExtensions.Contains(Path.GetExtension(img.FileName).ToUpperInvariant()))
                {
                    ImageValid = false;
                }
            }
            model.Description = Sll;
            ModelState.Remove("img");
            if (!ModelState.IsValid || username_Uniq == false || ImageValid == false)
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

        public async Task<IActionResult> TeachersRank(int teacherId, string search, int pageid = 1)
        {
            ViewBag.teacherid = teacherId;
            var Modares = await _services.TeacherRank(search, pageid);
            return View(Modares);
        }

        public async Task<IActionResult> WorkedFild(int teacherid)
        {
            ViewBag.teacherid = teacherid;
            T_Modaresan Teacher = new T_Modaresan();
            if (teacherid != 0)
            {
                Teacher = await _services.GetModaresan(teacherid);
            }

            List<SelectListItem> FildAsli = _services.GetFildAslis().Result
              .Select(x => new SelectListItem { Value = x.ID_FildAsli.ToString(), Text = x.Titles_FildAsli }).ToList();
            FildAsli.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            List<SelectListItem> OnvanDoreh = _services.GetOnvanDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(), Text = x.Titles_OnvanDoreh }).ToList();
            OnvanDoreh.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتخاب کنید" });
            ViewBag.FildAsli = FildAsli;
            ViewBag.OnvanDoreh = OnvanDoreh;

            var result= await _services.GetModaresanFildAsli(teacherid);
            List<string> FildAsli_show = new List<string>();
            List<string> OnvanDoreh_show = new List<string>();
            foreach (var item in result)
            {
                FildAsli_show .Add(await _services.GetFildAslibyid(item.T_L_FildAsli_ID.Value));
                OnvanDoreh_show.Add( await _services.GetOnvanDorehbyid(item.T_L_OnvanDoreh_ID.Value));
            }
            FildAslAndOnvanDreohShow model = new FildAslAndOnvanDreohShow()
            {
                FilAsli = FildAsli_show,
                OnvanDoreh = OnvanDoreh_show
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> WorkedFild(int teacherid, List<string> FildAsli, List<string> OnvanDoreh)
        {
            ViewBag.teacherid = teacherid;
            T_Modaresan Teacher = new T_Modaresan();
            if (teacherid != 0)
            {
                Teacher = await _services.GetModaresan(teacherid);
            }
            List<T_Modaresan_Fild_Amozeshi> t_Modaresan_Fild_Amozeshi = new List<T_Modaresan_Fild_Amozeshi>();
            for (int i = 0; i < FildAsli.Count; i++)
            {
                T_Modaresan_Fild_Amozeshi t_Modaresan_Fild_Amozeshi_one = new T_Modaresan_Fild_Amozeshi();
                t_Modaresan_Fild_Amozeshi_one.T_L_FildAsli_ID = Convert.ToInt16(FildAsli[i]);
                t_Modaresan_Fild_Amozeshi_one.T_L_OnvanDoreh_ID = Convert.ToInt16(OnvanDoreh[i]);
                t_Modaresan_Fild_Amozeshi_one.T_Modaresan_ID = teacherid;
                t_Modaresan_Fild_Amozeshi.Add(t_Modaresan_Fild_Amozeshi_one);
            }
            await _services.AddModaresanFildAsli(t_Modaresan_Fild_Amozeshi);
            return RedirectToAction("WorkedFild", new { teacherid = teacherid });
        }


        #endregion

        #region Teacher From

        public async Task<IActionResult> TeacherForm(string phone = "")
        {
            var teacher = await _services.GetModaresan(phone);
            if (teacher != null)
            {
                return RedirectToAction("Index");
            }
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
            ViewBag.Phone = phone;
            ViewBag.Fild_Asli = modaresan_Fild_AsliVMs;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> TeacherForm(ModaresanVM model, IFormFile img, string Sll, List<string> FildAsli, List<string> OnvanDoreh, string MaghtaeTahsili = ""
            , string Reshte = "", string DaragehElmi = "")
        {
            bool ImageValid = true;
            if (img != null)
            {
                if (!ImageExtensions.Contains(Path.GetExtension(img.FileName).ToUpperInvariant()))
                {
                    ImageValid = false;
                }
            }
            model.Description = Sll;
            ModelState.Remove("img");
            if (!ModelState.IsValid || Reshte == "0" || MaghtaeTahsili == "0" || DaragehElmi == "0" || ImageValid == false)
            {
                if (img != null)
                {
                    if (!ImageExtensions.Contains(Path.GetExtension(img.FileName).ToUpperInvariant()))
                    {
                        return View(model);
                    }
                }
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
                DateCreate = await _services.ConvertDateToShamsi(DateTime.Now),
                Daneshgah_Sherkat = model.Daneshgah_Reshteh,
                Mobile = model.Phone,
                Phone = model.Phone,
                Onvan_Shoghli = model.OnvanShoghli,
                Description = model.Description,
                T_L_MaghtaeTahsili_ID = null,
                T_L_ReshtehTahsili_ID = null,
                T_L_DaragehElmi_ID = null,
            };
            if (img != null)
            {
                if (!ImageExtensions.Contains(Path.GetExtension(img.FileName).ToUpperInvariant()))
                {
                    return View(model);
                }
            }
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
            t_Modaresan.NameFamily = _services.GetActivation(t_Modaresan.Phone).Result.NameFamily;
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
            // var x = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            // x.Add(new Claim(ClaimTypes.Version, "sk"));
            return RedirectToAction("TeacherInfo", new { teacherid = Modearseid });
        }

        #endregion

    }
}
