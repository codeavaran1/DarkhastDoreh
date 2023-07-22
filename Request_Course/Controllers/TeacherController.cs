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

        public async Task<IActionResult> FollowUpTeacher()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TeacherInfo(string phone="",int id=0)
        {
            T_Modaresan Teacher = new T_Modaresan();
            if (phone!="")
            {
                Teacher =await _services.GetModaresan(phone);
            }
            else
            {
                Teacher = await _services.GetModaresan(id);
            }
            var teacher_name = _services.GetActivation(Teacher.Phone).Result.NameFamily;
            var teacher_MaghtaeTahsili =await _services.GetMaghtaeTahsili(Teacher.ID_Modaresan);
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

        #region Teacher From

        public async Task<IActionResult> TeacherForm(string phone = "")
        {
            List<Modaresan_Fild_AsliVM> modaresan_Fild_AsliVMs = new List<Modaresan_Fild_AsliVM>();
            List<SelectListItem> Reshte = _services.GetReshtehTahsilis().Result
                .Select(x => new SelectListItem { Value = x.ID_ReshtehTahsili.ToString(), Text = x.Titles_ReshtehTahsili }).ToList();
            List<SelectListItem> MaghtaeTahsili_Drop = _services.GetMaghtaeTahsili().Result
                .Select(x => new SelectListItem { Value = x.ID_MaghtaeTahsili.ToString(), Text = x.Titles_MaghtaeTahsili }).ToList();
            List<SelectListItem> DaragehElmi = _services.GetDaragehElmis().Result
                .Select(x => new SelectListItem { Value = x.ID_DaragehElmi.ToString(), Text = x.Titles_DaragehElmi }).ToList();
            List<SelectListItem> FildAsli = _services.GetFildAslis().Result
                .Select(x => new SelectListItem { Value = x.ID_FildAsli.ToString(), Text = x.Titles_FildAsli }).ToList();
            List<SelectListItem> OnvanDoreh = _services.GetOnvanDorehs().Result
                .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(),Text=x.Titles_OnvanDoreh}).ToList();
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
        public async Task<IActionResult> TeacherForm(ModaresanVM model, IFormFile img, List<string> FildAsli, List<string> OnvanDoreh, string MaghtaeTahsili=""
            ,string Reshte="",string DaragehElmi="")
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            T_Modaresan t_Modaresan = new T_Modaresan()
            {
                Email = model.Email,
                DateCreate = DateTime.Now,
                Daneshgah_Sherkat = model.Daneshgah_Reshteh,
                Mobile = model.Phone,
                Phone = model.Phone,
                Onvan_Shoghli=model.OnvanShoghli,
                Description = model.Description,
                T_L_MaghtaeTahsili_ID= Convert.ToInt32(MaghtaeTahsili),
                T_L_ReshtehTahsili_ID=Convert.ToInt32(Reshte),
                T_L_DaragehElmi_ID=Convert.ToInt32(DaragehElmi),
            };
            t_Modaresan.MadrakTahsili = await _services.GetMadraktahsilibyId(Convert.ToInt32(MaghtaeTahsili));
            var Modearseid=await _services.AddModares(t_Modaresan, img);
            List<T_Modaresan_Fild_Amozeshi> t_Modaresan_Fild_Amozeshi = new List<T_Modaresan_Fild_Amozeshi>();
            for (int i = 0; i < FildAsli.Count; i++)
            {
                T_Modaresan_Fild_Amozeshi t_Modaresan_Fild_Amozeshi_one =new  T_Modaresan_Fild_Amozeshi();
                t_Modaresan_Fild_Amozeshi_one.T_L_FildAsli_ID = Convert.ToInt16(FildAsli[i]);
                t_Modaresan_Fild_Amozeshi_one.T_L_OnvanDoreh_ID= Convert.ToInt16(OnvanDoreh[i]);
                t_Modaresan_Fild_Amozeshi_one.T_Modaresan_ID = Modearseid;
                t_Modaresan_Fild_Amozeshi.Add(t_Modaresan_Fild_Amozeshi_one);   
            }
            await _services.AddModaresanFildAsli(t_Modaresan_Fild_Amozeshi);
            return RedirectToAction("TeacherInfo", new { id = Modearseid });
        }

        #endregion
       
    }
}
