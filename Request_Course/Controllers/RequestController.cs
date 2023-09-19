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

        public async Task<IActionResult> Index()
        {
            return View();
        }

        #region Mokhatabin jadid
        [HttpGet]
        public async Task<IActionResult> RequestForm(string phone = "")
        {
            var Mokhatab = await _serivecs.GetMokhatebin(phone);
            if (Mokhatab!=null)
            {
                return RedirectToAction("Index");
            }
            List<SelectListItem> Ostan = _serivecs.GetOstans().Result
                .Select(x => new SelectListItem { Value = x.ID_Ostan.ToString(), Text = x.Titles_Ostan }).ToList();
            Ostan.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتحاب کنید" });
            List<SelectListItem> Semat = _serivecs.GetSemats().Result
                .Select(x => new SelectListItem { Value = x.ID_Semat.ToString(), Text = x.Titles_Semat }).ToList();
            Semat.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتحاب کنید" });
            ViewBag.ostany = Ostan;
            ViewBag.Semat = Semat;
            ViewBag.phone = phone;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RequestForm(RequesterVM model, string Ostan = "", string Semat = "")
        {
            if (ModelState.IsValid==false || Ostan=="0"||Semat=="0")
            {
                List<SelectListItem> Ostan1 = _serivecs.GetOstans().Result
               .Select(x => new SelectListItem { Value = x.ID_Ostan.ToString(), Text = x.Titles_Ostan }).ToList();
                Ostan1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتحاب کنید" });
                List<SelectListItem> Semat1 = _serivecs.GetSemats().Result
                    .Select(x => new SelectListItem { Value = x.ID_Semat.ToString(), Text = x.Titles_Semat }).ToList();
                Semat1.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "انتحاب کنید" });
                ViewBag.phone = model.Phone;
                ViewBag.ostany = Ostan1;
                ViewBag.Semat = Semat1;
                return View(model);
            }

            T_Mokhatebin t_Mokhatebin = new T_Mokhatebin()
            {
                Email = model.Email,
                Phone = model.Phone,
                Name_Sherkat = model.Name_Sherkat,
                NamFamily_Rabet = model.Family,
                T_L_Ostan_ID = null,
                T_L_Semat_ID = null
            };
            if (Ostan != "0")
            {
                t_Mokhatebin.T_L_Ostan_ID = Convert.ToInt16(Ostan);
            }
            if (Semat != "0")
            {
                t_Mokhatebin.T_L_Semat_ID = Convert.ToInt16(Semat);
            }
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
            var mokhatab = await _serivecs.GetMokhatebin(phone:Phone);
            if (mokhatab!=null)
            {
                Family = mokhatab.NamFamily_Rabet;
                Name_Sherkat = mokhatab.Name_Sherkat;
            }
            List<SelectListItem> OnvanAsli = _serivecs.GetOnvanAslis().Result
              .Select(x => new SelectListItem { Value = x.ID_L_OnvanAsli.ToString(), Text = x.Titles_OnvanAsli }).ToList();
            OnvanAsli.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> OnvanDoreh = _serivecs.GetOnvanDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(), Text = x.Titles_OnvanDoreh }).ToList();
            OnvanDoreh.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> MediaAmozeshis = _serivecs.GetMediaAmozeshis().Result
              .Select(x => new SelectListItem { Value = x.ID_MediaAmozeshi.ToString(), Text = x.Titles_MediaAmozeshi }).ToList();
            MediaAmozeshis.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> RaveshAmozeshis = _serivecs.GetRaveshAmozeshis().Result
              .Select(x => new SelectListItem { Value = x.ID_L_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            RaveshAmozeshis.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> ModateDorehs = _serivecs.GetModateDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_ModateDoreh.ToString(), Text = x.Titles_ModateDoreh }).ToList();
            ModateDorehs.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> MokhatabanDorehs = _serivecs.GetMokhatabanDorehs().Result
              .Select(x => new SelectListItem { Value = x.ID_MokhatabanDoreh.ToString(), Text = x.Titles_MokhatabanDoreh }).ToList();
            MokhatabanDorehs.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> SatheKeyfi_Modares = _serivecs.GetSatheKeyfi_Modares().Result
              .Select(x => new SelectListItem { Value = x.ID_L_SatheKeyfi_Modares.ToString(), Text = x.Titles_SatheKeyfi_Modares }).ToList();
            SatheKeyfi_Modares.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
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
            , string MediaAmozeshis = "", string RaveshAmozeshis = "", string ModateDorehs = ""
            , string MokhatabanDorehs = "", string SatheKeyfi_Modares = "", string Phoneing = "")
        {
            if (ModelState.IsValid==false|| OnvanAsli == "0" || OnvanDoreh == "0" || MediaAmozeshis == "0" || RaveshAmozeshis == "0" || ModateDorehs == "0" || MokhatabanDorehs == "0" || SatheKeyfi_Modares == "0")
            {
                List<SelectListItem> OnvanAsli1 = _serivecs.GetOnvanAslis().Result
              .Select(x => new SelectListItem { Value = x.ID_L_OnvanAsli.ToString(), Text = x.Titles_OnvanAsli }).ToList();
                OnvanAsli1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> OnvanDoreh1 = _serivecs.GetOnvanDorehs().Result
                  .Select(x => new SelectListItem { Value = x.ID_OnvanDoreh.ToString(), Text = x.Titles_OnvanDoreh }).ToList();
                OnvanDoreh1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> MediaAmozeshis1 = _serivecs.GetMediaAmozeshis().Result
                  .Select(x => new SelectListItem { Value = x.ID_MediaAmozeshi.ToString(), Text = x.Titles_MediaAmozeshi }).ToList();
                MediaAmozeshis1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> RaveshAmozeshis1 = _serivecs.GetRaveshAmozeshis().Result
                  .Select(x => new SelectListItem { Value = x.ID_L_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
                RaveshAmozeshis1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> ModateDorehs1 = _serivecs.GetModateDorehs().Result
                  .Select(x => new SelectListItem { Value = x.ID_ModateDoreh.ToString(), Text = x.Titles_ModateDoreh }).ToList();
                ModateDorehs1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> MokhatabanDorehs1 = _serivecs.GetMokhatabanDorehs().Result
                  .Select(x => new SelectListItem { Value = x.ID_MokhatabanDoreh.ToString(), Text = x.Titles_MokhatabanDoreh }).ToList();
                MokhatabanDorehs1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> SatheKeyfi_Modares1 = _serivecs.GetSatheKeyfi_Modares().Result
                  .Select(x => new SelectListItem { Value = x.ID_L_SatheKeyfi_Modares.ToString(), Text = x.Titles_SatheKeyfi_Modares }).ToList();
                SatheKeyfi_Modares1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                ViewBag.OnvanAsli = OnvanAsli1;
                ViewBag.OnvanDoreh = OnvanDoreh1;
                ViewBag.MediaAmozeshis = MediaAmozeshis1;
                ViewBag.RaveshAmozeshis = RaveshAmozeshis1;
                ViewBag.ModateDorehs = ModateDorehs1;
                ViewBag.MokhatabanDorehs = MokhatabanDorehs1;
                ViewBag.SatheKeyfi_Modares = SatheKeyfi_Modares1;
                return View(model);
            }
           
            T_Doreh_Darkhasti t_Doreh_Darkhasti = new T_Doreh_Darkhasti()
            {
                Date_Az_Pishnahad = await _serivecs.ConvertDateToShamsi(model.DateStart),
                Date_Ta_Pishnahad = await _serivecs.ConvertDateToShamsi(model.DateEnd),
                Date_Create=await _serivecs.ConvertDateToShamsi(DateTime.Now), 
                T_L_OnvanAsli_ID = null,
                T_L_OnvanDoreh_ID = null,
                T_L_MediaAmozeshi_ID = null,
                T_L_RaveshAmozeshi_ID = null,
                T_L_ModateDoreh_ID = null,
                T_L_MokhatabanDoreh_ID = null,
                T_L_SatheKeyfi_Modares_ID = null,
                T_L_Vaziyat_Doreh_ID = 3
                
            };
            if (OnvanAsli != "0")
            {
                t_Doreh_Darkhasti.T_L_OnvanAsli_ID = Convert.ToInt16(OnvanAsli);
            }
            if (OnvanDoreh != "0")
            {
                t_Doreh_Darkhasti.T_L_OnvanDoreh_ID = Convert.ToInt16(OnvanDoreh);
            }
            if (MediaAmozeshis != "0")
            {
                t_Doreh_Darkhasti.T_L_MediaAmozeshi_ID = Convert.ToInt16(MediaAmozeshis);
            }
            if (RaveshAmozeshis != "0")
            {
                t_Doreh_Darkhasti.T_L_RaveshAmozeshi_ID = Convert.ToInt16(RaveshAmozeshis);
            }
            if (ModateDorehs != "0")
            {
                t_Doreh_Darkhasti.T_L_ModateDoreh_ID = Convert.ToInt16(ModateDorehs);
            }
            if (MokhatabanDorehs != "0")
            {
                t_Doreh_Darkhasti.T_L_MokhatabanDoreh_ID = Convert.ToInt16(MokhatabanDorehs);
            }
            if (SatheKeyfi_Modares != "0")
            {
                t_Doreh_Darkhasti.T_L_SatheKeyfi_Modares_ID = Convert.ToInt16(SatheKeyfi_Modares);
            }
            int Userid = _serivecs.GetMokhatebin(Phoneing).Result.ID_Mokhatebin;
            t_Doreh_Darkhasti.T_Mokhatebin_ID = Userid;
            await _serivecs.AddDorehJadid(t_Doreh_Darkhasti);
            return RedirectToAction("SarFaslDoreh", "Episod", new { onvanasli = Convert.ToInt16(OnvanAsli), onvandoreh = Convert.ToInt16(OnvanDoreh), DorehDarkhasti_ID = t_Doreh_Darkhasti.ID_Doreh_Darkhasti });
        }

        #endregion

        #region DarkhastDoreh jadid

        [HttpGet]
        public async Task<IActionResult> Request_New_DorehAmozeshi(string phone)
        {
            List<SelectListItem> OnvanAsli = _serivecs.GetOnvanAslis().Result
            .Select(x => new SelectListItem { Value = x.ID_L_OnvanAsli.ToString(), Text = x.Titles_OnvanAsli }).ToList();
            OnvanAsli.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> RaveshAmozeshis = _serivecs.GetRaveshAmozeshis().Result
            .Select(x => new SelectListItem { Value = x.ID_L_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            RaveshAmozeshis.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> MediaAmozeshis = _serivecs.GetMediaAmozeshis().Result
            .Select(x => new SelectListItem { Value = x.ID_MediaAmozeshi.ToString(), Text = x.Titles_MediaAmozeshi }).ToList();
            MediaAmozeshis.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> ModateDorehs = _serivecs.GetModateDorehs().Result
            .Select(x => new SelectListItem { Value = x.ID_ModateDoreh.ToString(), Text = x.Titles_ModateDoreh }).ToList();
            ModateDorehs.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
            List<SelectListItem> MokhatabanDorehs = _serivecs.GetMokhatabanDorehs().Result
            .Select(x => new SelectListItem { Value = x.ID_MokhatabanDoreh.ToString(), Text = x.Titles_MokhatabanDoreh }).ToList();
            MokhatabanDorehs.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
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
            if (!ModelState.IsValid || OnvanAsli == "0" || MediaAmozeshis == "0" || ModateDorehs == "0" || MokhatabanDorehs == "0" || RaveshAmozeshis == "0")
            {
                List<SelectListItem> OnvanAsli1 = _serivecs.GetOnvanAslis().Result
            .Select(x => new SelectListItem { Value = x.ID_L_OnvanAsli.ToString(), Text = x.Titles_OnvanAsli }).ToList();
                OnvanAsli1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> RaveshAmozeshis1 = _serivecs.GetRaveshAmozeshis().Result
                .Select(x => new SelectListItem { Value = x.ID_L_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
                RaveshAmozeshis1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> MediaAmozeshis1 = _serivecs.GetMediaAmozeshis().Result
                .Select(x => new SelectListItem { Value = x.ID_MediaAmozeshi.ToString(), Text = x.Titles_MediaAmozeshi }).ToList();
                MediaAmozeshis1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> ModateDorehs1 = _serivecs.GetModateDorehs().Result
                .Select(x => new SelectListItem { Value = x.ID_ModateDoreh.ToString(), Text = x.Titles_ModateDoreh }).ToList();
                ModateDorehs1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                List<SelectListItem> MokhatabanDorehs1 = _serivecs.GetMokhatabanDorehs().Result
                .Select(x => new SelectListItem { Value = x.ID_MokhatabanDoreh.ToString(), Text = x.Titles_MokhatabanDoreh }).ToList();
                MokhatabanDorehs1.Insert(0, new SelectListItem { Value = "0", Text = "انتخاب کنید" });
                ViewBag.OnvanAsli = OnvanAsli;
                ViewBag.MediaAmozeshis = MediaAmozeshis;
                ViewBag.RaveshAmozeshis = RaveshAmozeshis;
                ViewBag.ModateDorehs = ModateDorehs;
                ViewBag.MokhatabanDorehs = MokhatabanDorehs;
                return View(model);
            }
           
            T_Doreh_Darkhasti t_Doreh_Darkhasti = new T_Doreh_Darkhasti()
            {
                OnvanDoreh_Jadid = model.OnvanDoreh,
                Date_Az_Pishnahad = await _serivecs.ConvertDateToShamsi(model.DateStart),
                Date_Ta_Pishnahad = await _serivecs.ConvertDateToShamsi(model.DateEnd),
                Date_Create=await _serivecs.ConvertDateToShamsi(DateTime.Now),
                T_L_OnvanAsli_ID = null,
                T_L_MediaAmozeshi_ID = null,
                T_L_ModateDoreh_ID = null,
                T_L_MokhatabanDoreh_ID = null,
                T_L_RaveshAmozeshi_ID = null,
                T_L_Vaziyat_Doreh_ID = 3
            };
            if (OnvanAsli != "0")
            {
                t_Doreh_Darkhasti.T_L_OnvanAsli_ID = Convert.ToInt16(OnvanAsli);
            }
            if (MediaAmozeshis != "0")
            {
                t_Doreh_Darkhasti.T_L_MediaAmozeshi_ID = Convert.ToInt16(MediaAmozeshis);
            }
            if (ModateDorehs != "0")
            {
                t_Doreh_Darkhasti.T_L_ModateDoreh_ID = Convert.ToInt16(ModateDorehs);
            }
            if (MokhatabanDorehs != "0")
            {
                t_Doreh_Darkhasti.T_L_MokhatabanDoreh_ID = Convert.ToInt16(MokhatabanDorehs);
            }
            if (RaveshAmozeshis != "0")
            {
                t_Doreh_Darkhasti.T_L_RaveshAmozeshi_ID = Convert.ToInt16(RaveshAmozeshis);
            }
            int Userid = _serivecs.GetMokhatebin(model.Phone).Result.ID_Mokhatebin;
            t_Doreh_Darkhasti.T_Mokhatebin_ID = Userid;
            await _serivecs.AddDorehJadid(t_Doreh_Darkhasti);
            return RedirectToAction("SarFaslDoreh_NewDoreh_Pishnahadi", "Episod", new { onvanasli = Convert.ToInt16(OnvanAsli), DorehDarkhasti_ID = t_Doreh_Darkhasti.ID_Doreh_Darkhasti });

        }


        #endregion

        #region Modaresan doreh
        public async Task<IActionResult> TeacherOfDoreh(int onvanAsli, int OnvanDoreh, int DorehDarkhasti_ID = 0)
        {
            var Teachers = await _serivecs.GetModaresan(onvanAsli, OnvanDoreh);
            List<string> FamilyName = new List<string>();
            List<string> image = new List<string>();
            List<string> Stars = new List<string>();
            foreach (var item in Teachers)
            {
                image.Add(item.img);
                FamilyName.Add(_serivecs.GetActivation(item.Phone).Result.NameFamily);
                if (item.Sathe_Keyfi == null)
                {
                    Stars.Add("0");
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
                        Stars.Add("0");
                    }
                }
            }
            List<SelectListItem> Teacher = Teachers
               .Select(x => new SelectListItem { Value = x.ID_Modaresan.ToString(), Text = x.NameFamily }).ToList();
            Teacher.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "اتخاب کنید" });
            ViewBag.stars = Stars;
            ViewBag.Teacher = Teacher;
            ViewBag.image = image;
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
                T_Modaresan1 = null,
                T_Modaresan2 = null,
                T_Modaresan3 = null,
                T_Modaresan_ID1 = null,
                T_Modaresan_ID2 = null,
                T_Modaresan_ID3 = null,
                Pishnahad_Modares_Name1 = NewTeacher_Name,
                Pishnahad_Modares_Name2 = NewTeacher_Name2,
                Pishnahad_Modares_Name3 = NewTeacher_Name3,
                Pishnahad_Modares_phone1 = NewTeacher_Phone,
                Pishnahad_Modares_phone2 = NewTeacher_Phone2,
                Pishnahad_Modares_phone3 = NewTeacher_Phone3,
                T_Doreh_Darkhasti_ID = DorehDarkhasti_ID,
            };
            if (Convert.ToInt32(Teacher) != 0)
            {
                t_Pishnahad_Modares_Doreh.T_Modaresan_ID1 = Convert.ToInt32(Teacher);
            }
            if (Convert.ToInt32(Teacher2) != 0)
            {
                t_Pishnahad_Modares_Doreh.T_Modaresan_ID2 = Convert.ToInt32(Teacher2);
            }
            if (Convert.ToInt32(Teacher3) != 0)
            {
                t_Pishnahad_Modares_Doreh.T_Modaresan_ID3 = Convert.ToInt32(Teacher3);
            }
            await _serivecs.Add_Pishnahad_Modares_Doreh(t_Pishnahad_Modares_Doreh);
            return RedirectToAction("AllAboutDorehMethod", new { DorehId = DorehDarkhasti_ID });
        }

        public async Task<IActionResult> TeacherOfDoreh_NewDoreh(int onvanAsli, int DorehDarkhasti_ID = 0)
        {
            var Teachers = await _serivecs.GetModaresanByOnvanasli(onvanAsli);
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
            List<SelectListItem> Teacher = Teachers
               .Select(x => new SelectListItem { Value = x.ID_Modaresan.ToString(), Text = x.NameFamily }).ToList();
            Teacher.Insert(0, new SelectListItem { Value = 0.ToString(), Text = "اتخاب کنید" });
            ViewBag.stars = Stars;
            ViewBag.Teacher = Teacher;
            ViewBag.Family = FamilyName;
            ViewBag.onvanAsli = onvanAsli;
            ViewBag.DorehDarkhasti_ID = DorehDarkhasti_ID;
            return View(Teachers);
        }

       

        #endregion

        #region koldorehDarkhasti
        public async Task<IActionResult> AllAboutDorehMethod(int DorehId)
        {
            string Teacher1 = null;
            string Teacher2 = null;
            string Teacher3 = null;
            T_Doreh_Darkhasti Doreh = await _serivecs.GetDoreh_Darkhasti(DorehId);
            List<string> t_Fasl_Doreh_Pishnahadis = await _serivecs.GetT_Fasl_Dorehs_Pishnahadi(DorehId);
            var onvanasli = await _serivecs.GetOnvanAsli(Doreh.T_L_OnvanAsli_ID.Value);
            var RavasheAmozeshi = await _serivecs.GetRavasheAmozeshi(Doreh.T_L_RaveshAmozeshi_ID.Value);
            var MediaAmozeshi = await _serivecs.GetMediaAmozeshi(Doreh.T_L_MediaAmozeshi_ID.Value);
            var MokhatabinDoreh = await _serivecs.GetMokhatabinDoreh(Doreh.T_Mokhatebin_ID.Value);
            var pishnahad_MOdares = await _serivecs.GetPishnahad_Modares_Doreh(Doreh.ID_Doreh_Darkhasti);
            AllAboutDoreh model = new AllAboutDoreh()
            {
                EndDate = Doreh.Date_Ta_Pishnahad,
                StartDate = Doreh.Date_Az_Pishnahad,
                MediaAmozeshi = MediaAmozeshi,
                MokhatabinDoreh = MokhatabinDoreh,
                OnvanAsli = onvanasli,
                OnvanDoreh = Doreh.OnvanDoreh_Jadid,
                RavasheAmozeshi = RavasheAmozeshi,
                TeacherPshanmdiName1 = pishnahad_MOdares.Pishnahad_Modares_Name1,
                TeacherPshanmdiName2 = pishnahad_MOdares.Pishnahad_Modares_Name2,
                TeacherPshanmdiName3 = pishnahad_MOdares.Pishnahad_Modares_Name3,
            };
            T_Pishnahad_Modares_Doreh Teachers = await _serivecs.GetPishnahad_Modares_Doreh(DorehId);
            if (Teachers != null)
            {
                if (Teachers.T_Modaresan_ID1 != null)
                {
                    Teacher1 = await _serivecs.GetTeacherName(Teachers.T_Modaresan_ID1.Value);
                    model.Teahcername1 = Teacher1;
                }
                if (Teachers.T_Modaresan_ID2 != null)
                {
                    Teacher2 = await _serivecs.GetTeacherName(Teachers.T_Modaresan_ID2.Value);
                    model.Teahcername2 = Teacher2;
                }
                if (Teachers.T_Modaresan_ID3 != null)
                {
                    Teacher3 = await _serivecs.GetTeacherName(Teachers.T_Modaresan_ID3.Value);
                    model.Teahcername3 = Teacher3;
                }
            }
            if (Doreh.T_L_SatheKeyfi_Modares_ID != null)
            {
                var Satehkeyfi = await _serivecs.GetSatehkeyfi(Doreh.T_L_SatheKeyfi_Modares_ID.Value);
                model.Satehkeyfi = Satehkeyfi;
            }
            if (Doreh.T_L_OnvanDoreh_ID != null)
            {
                List<string> t_Fasl_Doreh = await _serivecs.GetT_Fasl_Dorehs(Doreh.T_L_OnvanAsli_ID.Value, Doreh.T_L_OnvanDoreh_ID.Value);
                ViewData["FasleDoreh"] = t_Fasl_Doreh;
                var onvanDoreh = await _serivecs.GetOnvanDoreh(Convert.ToInt16(Doreh.T_L_OnvanDoreh_ID));
                model.OnvanDoreh = onvanDoreh;
            }

            ViewBag.t_Fasl_Doreh_Pishnahadis = t_Fasl_Doreh_Pishnahadis;
            ViewBag.DorehDarkhasti_ID = DorehId;
            return View(model);
        }

        public async Task<IActionResult> ConfrimDoreh(int DorehId)
        {
            var user = User.Identity.Name;
            await _serivecs.ConfrimDoreh(DorehId);
            var doreh= await _serivecs.GetDoreh_Darkhasti(DorehId);
            var mokhatab = await _serivecs.GetMokhatebinById(doreh.T_Mokhatebin_ID.Value);
            return RedirectToAction("index", "Mokhatab", new { phone =mokhatab.Phone});
        }


        #endregion

        #region Confirm page
        public async Task<IActionResult> OK()
        {
            return View();
        }
        #endregion




    }
}
