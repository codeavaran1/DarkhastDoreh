using Microsoft.AspNetCore.Mvc;
using Request_Course.Serivces.Interface;
using Request_Course.VM;
using System.Web.Mvc;

namespace Request_Course.Component
{
    public class CreateModaresViewComponent : ViewComponent
    {
        private IRepository _services;
        public CreateModaresViewComponent(IRepository repository)
        {
            _services = repository;
        }


//        /Views/Episod/Components/SarFasle/Default.cshtml
///Views/Shared/Components/SarFasle/Default.cshtml
///Pages/Shared/Components/SarFasle/Default.cshtml
        public async Task<IViewComponentResult> InvokeAsync(int DorehDarkhasti_ID = 0, int onvandoreh = 0, int onvanasli = 0)
        {
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
            return await Task.FromResult((IViewComponentResult)View("Default"));
        }
       
    }
}
