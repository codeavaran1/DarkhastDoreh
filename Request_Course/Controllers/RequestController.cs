using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

namespace Request_Course.Controllers
{
    public class RequestController : Controller
    {
        private IRepository _serivecs;
        public RequestController(IRepository repository)
        {
            _serivecs = repository;
        }

        #region Mokhatabin jadid
        [HttpGet]
        public async Task<IActionResult> RequestForm(string phone = "", string Family = "")
        {
            List<SelectListItem> Ostan = _serivecs.GetOstans().Result
                .Select(x => new SelectListItem { Value = x.ID_Ostan.ToString(), Text = x.Titles_Ostan }).ToList();
            List<SelectListItem> Semat = _serivecs.GetSemats().Result
                .Select(x => new SelectListItem { Value = x.ID_Semat.ToString(), Text = x.Titles_Semat }).ToList();
            ViewBag.Ostan = Ostan;
            ViewBag.Semat = Semat;
            ViewBag.phone = phone;
            ViewBag.family = Family;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RequestForm(RequesterVM model, string Ostan = "", string Semat = "")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            T_Mokhatebin t_Mokhatebin = new T_Mokhatebin()
            {
                Email = model.Email,
                Phone = model.Phone,
                Name_Sherkat = model.Name_Sherkat,
                NamFamily_Rabet = model.Family,
                T_L_Ostan_ID = Convert.ToInt16(Ostan),
                T_L_Semat_ID = Convert.ToInt16(Semat)
            };
            await _serivecs.AddMokhatab(t_Mokhatebin);

            return RedirectToAction("Request_DorehAmozeshi", new { Family = model.Family, Name_Sherkat = model.Name_Sherkat, Phone = model.Phone });

        }


        #endregion

        #region Mokhatin Old

        public async Task<IActionResult> FollowUpRequest()
        {
            return View();
        }

        #endregion

        #region DarkhastDoreh

        [HttpGet]
        public async Task<IActionResult> Request_DorehAmozeshi(string Family = "", string Name_Sherkat = "", string Phone = "")
        {
            List<SelectListItem> OnvanAsli = _serivecs.GetOnvanAslis().Result
              .Select(x => new SelectListItem { Value = x.ID_L_OnvanAsli.ToString(), Text = x.Titles_OnvanAsli }).ToList();
            List<SelectListItem> OnvanDoreh = _serivecs.GetOnvanDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(), Text = x.Titles_OnvanDoreh }).ToList();
            List<SelectListItem> MediaAmozeshis = _serivecs.GetMediaAmozeshis().Result
              .Select(x => new SelectListItem { Value = x.ID_MediaAmozeshi.ToString(), Text = x.Titles_MediaAmozeshi }).ToList();
            List<SelectListItem> RaveshAmozeshis = _serivecs.GetRaveshAmozeshis().Result
              .Select(x => new SelectListItem { Value = x.ID_L_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            List<SelectListItem> ModateDorehs = _serivecs.GetModateDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_ModateDoreh.ToString(), Text = x.Titles_ModateDoreh }).ToList();
            List<SelectListItem> MokhatabanDorehs = _serivecs.GetMokhatabanDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_MokhatabanDoreh.ToString(), Text = x.Titles_MokhatabanDoreh }).ToList();
            List<SelectListItem> SatheKeyfi_Modares = _serivecs.GetSatheKeyfi_Modares().Result
              .Select(x => new SelectListItem { Value = x.ID_L_SatheKeyfi_Modares.ToString(), Text = x.Titles_SatheKeyfi_Modares }).ToList();
            ViewBag.OnvanAsli = OnvanAsli;
            ViewBag.OnvanDoreh = OnvanDoreh;
            ViewBag.MediaAmozeshis = MediaAmozeshis;
            ViewBag.RaveshAmozeshis = RaveshAmozeshis;
            ViewBag.ModateDorehs = ModateDorehs;
            ViewBag.MokhatabanDorehs = MokhatabanDorehs;
            ViewBag.SatheKeyfi_Modares = SatheKeyfi_Modares;
            ViewBag.user = Family;
            ViewBag.Name_Sherkat = Name_Sherkat;
            ViewBag.Phone = Phone;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Request_DorehAmozeshi(DarkhastDorehAmozeshiVM model, string OnvanAsli = "", string OnvanDoreh = ""
            , string MediaAmozeshis = "", string RaveshAmozeshis = "", string ModateDorehs = "", string MokhatabanDorehs = "", string SatheKeyfi_Modares = "")
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            T_Doreh_Darkhasti t_Doreh_Darkhasti = new T_Doreh_Darkhasti()
            {
                Date_Az_Pishnahad = model.DateStart,
                Date_Ta_Pishnahad = model.DateEnd,
                T_L_OnvanAsli_ID = Convert.ToInt16(OnvanAsli),
                T_L_OnvanDoreh_ID = Convert.ToInt16(OnvanDoreh),
                T_L_MediaAmozeshi_ID = Convert.ToInt16(MediaAmozeshis),
                T_L_RaveshAmozeshi_ID = Convert.ToInt16(RaveshAmozeshis),
                T_L_ModateDoreh_ID = Convert.ToInt16(ModateDorehs),
                T_L_MokhatabanDoreh_ID = Convert.ToInt16(MokhatabanDorehs),
                T_L_SatheKeyfi_Modares_ID = Convert.ToInt16(SatheKeyfi_Modares),
            };
            await _serivecs.AddDorehJadid(t_Doreh_Darkhasti);
            return RedirectToAction("TeacherOfDoreh", new { onvanAsli = Convert.ToInt16(OnvanAsli), OnvanDoreh = Convert.ToInt16(OnvanDoreh), DorehDarkhasti_ID = t_Doreh_Darkhasti.ID_Doreh_Darkhasti });
        }

        #endregion

        #region DarkhastDoreh jadid

        [HttpGet]
        public async Task<IActionResult> Request_New_DorehAmozeshi(string phone)
        {
            List<SelectListItem> OnvanAsli = _serivecs.GetOnvanAslis().Result
            .Select(x => new SelectListItem { Value = x.ID_L_OnvanAsli.ToString(), Text = x.Titles_OnvanAsli }).ToList();
            List<SelectListItem> RaveshAmozeshis = _serivecs.GetRaveshAmozeshis().Result
            .Select(x => new SelectListItem { Value = x.ID_L_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            List<SelectListItem> MediaAmozeshis = _serivecs.GetMediaAmozeshis().Result
            .Select(x => new SelectListItem { Value = x.ID_MediaAmozeshi.ToString(), Text = x.Titles_MediaAmozeshi }).ToList();
            List<SelectListItem> ModateDorehs = _serivecs.GetModateDorehs().Result
            .Select(x => new SelectListItem { Value = x.ID_ModateDoreh.ToString(), Text = x.Titles_ModateDoreh }).ToList();
            List<SelectListItem> MokhatabanDorehs = _serivecs.GetMokhatabanDorehs().Result
            .Select(x => new SelectListItem { Value = x.ID_MokhatabanDoreh.ToString(), Text = x.Titles_MokhatabanDoreh }).ToList();
            ViewBag.phone = phone;
            ViewBag.OnvanAsli = OnvanAsli;
            ViewBag.MediaAmozeshis = MediaAmozeshis;
            ViewBag.RaveshAmozeshis = RaveshAmozeshis;
            ViewBag.ModateDorehs = ModateDorehs;
            ViewBag.MokhatabanDorehs = MokhatabanDorehs;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Request_New_DorehAmozeshi(DarkhasDorheNewVM model, string OnvanAsli = "", string OnvanDoreh = ""
            , string MediaAmozeshis = "", string RaveshAmozeshis = "", string ModateDorehs = "", string MokhatabanDorehs = "")
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            T_Doreh_Darkhasti t_Doreh_Darkhasti = new T_Doreh_Darkhasti()
            {
                OnvanDoreh_Jadid = model.OnvanDoreh,
                Date_Az_Pishnahad = model.DateStart,
                Date_Ta_Pishnahad = model.DateEnd,
                T_L_OnvanAsli_ID = Convert.ToInt16(OnvanAsli),
                T_L_MediaAmozeshi_ID = Convert.ToInt16(MediaAmozeshis),
                T_L_ModateDoreh_ID = Convert.ToInt16(ModateDorehs),
                T_L_MokhatabanDoreh_ID = Convert.ToInt16(MokhatabanDorehs),
                T_L_RaveshAmozeshi_ID = Convert.ToInt16(RaveshAmozeshis),
            };
            int Userid = _serivecs.GetMokhatebin(model.Phone).Result.ID_Mokhatebin;
            t_Doreh_Darkhasti.T_Mokhatebin_ID = Userid;
            await _serivecs.AddDorehJadid(t_Doreh_Darkhasti);
            return RedirectToAction("TeacherOfDoreh", new { onvanAsli = Convert.ToInt16(OnvanAsli), OnvanDoreh = Convert.ToInt16(OnvanDoreh), DorehDarkhasti_ID = t_Doreh_Darkhasti.ID_Doreh_Darkhasti });

        }


        #endregion

        #region Modaresan doreh
        public async Task<IActionResult> TeacherOfDoreh(int onvanAsli, int OnvanDoreh, int DorehDarkhasti_ID = 0)
        {
            var Teachers = await _serivecs.GetModaresan(onvanAsli, OnvanDoreh);
            List<string> FamilyName = new List<string>();
            List<string> Stars = new List<string>();
            foreach (var item in Teachers)
            {
                FamilyName.Add(_serivecs.GetActivation(item.Phone).Result.NameFamily);
                if (item.Sathe_Keyfi == null)
                {
                    Stars.Add("don't have");
                }
                else
                {
                    var star = await _serivecs.GetSatheKeyfi(Convert.ToInt32(item.Sathe_Keyfi));
                    if (star != null)
                    {
                        Stars.Add(star);
                    }
                    else
                    {
                        Stars.Add("don't have");
                    }
                }
            }
            List<SelectListItem> Teacher = _serivecs.GetModaresan().Result
               .Select(x => new SelectListItem { Value = x.ID_Modaresan.ToString(), Text = x.NameFamily }).ToList();
            ViewBag.stars = Stars;
            ViewBag.Teacher = Teacher;
            ViewBag.Family = FamilyName;
            ViewBag.onvanAsli = onvanAsli;
            ViewBag.OnvanDoreh = OnvanDoreh;
            ViewBag.DorehDarkhasti_ID = DorehDarkhasti_ID;
            return View(Teachers);
        }
        [HttpPost]
        public async Task<IActionResult> TeacherOfDoreh(string Teacher = "", string Teacher2 = "",
            string Teacher3 = "", string NewTeacher_Name = "", string NewTeacher_Name2 = ""
            , string NewTeacher_Name3 = "", string NewTeacher_Phone = "", string NewTeacher_Phone2 = ""
            , string NewTeacher_Phone3 = "", int DorehDarkhasti_ID = 0)
        {
            T_Pishnahad_Modares_Doreh t_Pishnahad_Modares_Doreh = new T_Pishnahad_Modares_Doreh()
            {
                T_Modaresan_ID1 = Convert.ToInt32(Teacher),
                T_Modaresan_ID2 = Convert.ToInt32(Teacher2),
                T_Modaresan_ID3 = Convert.ToInt32(Teacher3),
                Pishnahad_Modares_Name1 = NewTeacher_Name,
                Pishnahad_Modares_Name2 = NewTeacher_Name2,
                Pishnahad_Modares_Name3 = NewTeacher_Name3,
                Pishnahad_Modares_phone1 = NewTeacher_Phone,
                Pishnahad_Modares_phone2 = NewTeacher_Phone2,
                Pishnahad_Modares_phone3 = NewTeacher_Phone3,
                T_Doreh_Darkhasti_ID = DorehDarkhasti_ID,
            };
            await _serivecs.Add_Pishnahad_Modares_Doreh(t_Pishnahad_Modares_Doreh);
            return RedirectToAction("OK");
        }


        public async Task<IActionResult> OK()
        {
            return View();
        }


        #endregion

    }
}
