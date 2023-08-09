using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

namespace Request_Course.Controllers
{
    public class TeacherController : Controller
    {
        private IRepository _services;
        public TeacherController(IRepository repository)
        {
            _services = repository;
        }

        #region Teacher Schema

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> FollowUpTeacher()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TeacherInfo(string phone = "", int id = 0)
        {
            T_Modaresan Teacher = new T_Modaresan();
            if (phone != "")
            {
                Teacher = await _services.GetModaresan(phone);
            }
            else
            {
                Teacher = await _services.GetModaresan(id);
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
                Description = Teacher.Description,
                // We don't have data
                NomrehTadris = "",
                RotbebeinModaresan = "",
                SatheKeyfi = "",
                TedadDoreh = ""
            };
            return View(model);
        }
        #endregion

        #region Teacher Dore
        public async Task<IActionResult> DorehTadrisShodeh(int TeacherId)
        {
            var model = await _services.GetDoreh_Teacher(TeacherId);
            return View(model);
        }

        public async Task<IActionResult> DorehFaal(int teacherid)
        {
            var model = await _services.GetDoreh_Faal_Teacher(teacherid);
            return View(model);
        }

        public async Task<IActionResult> DorehGhabil(int teacherid)
        {
            var model = await _services.GetDoreh_ghabil(teacherid);
            return View(model);
        }

        #endregion

        #region Teacher From

        public async Task<IActionResult> TeacherForm(string phone = "")
        {
            var teacher = await _services.GetModaresan(phone);
            if (teacher!=null)
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
        public async Task<IActionResult> TeacherForm(ModaresanVM model, IFormFile img, List<string> FildAsli, List<string> OnvanDoreh, string MaghtaeTahsili = ""
            , string Reshte = "", string DaragehElmi = "")
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
            return RedirectToAction("TeacherInfo", new { id = Modearseid });
        }

        #endregion

    }
}
