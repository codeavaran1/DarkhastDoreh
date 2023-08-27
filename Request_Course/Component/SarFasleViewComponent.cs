using Microsoft.AspNetCore.Mvc;
using Request_Course.Serivces.Interface;
using System.Web.Mvc;

namespace Request_Course.Component
{
    public class SarFasleViewComponent : ViewComponent
    {
        private IRepository _services;
        public SarFasleViewComponent(IRepository repository)
        {
            _services = repository;
        }


//        /Views/Episod/Components/SarFasle/Default.cshtml
///Views/Shared/Components/SarFasle/Default.cshtml
///Pages/Shared/Components/SarFasle/Default.cshtml
        public async Task<IViewComponentResult> InvokeAsync(int DorehDarkhasti_ID = 0, int onvandoreh = 0, int onvanasli = 0)
        {
            List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
                .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            ViewBag.Sheklejra = Sheklejra;
            ViewBag.DarkhastDoreh = DorehDarkhasti_ID;
            ViewBag.onvanasli = onvanasli;
            ViewBag.onvandoreh = onvandoreh;
            return await Task.FromResult((IViewComponentResult)View("Default"));
        }
       
    }
}
