﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

namespace Request_Course.Controllers
{
    public class EpisodController : Controller
    {
        private IRepository _services;
        public EpisodController(IRepository repository)
        {
            _services = repository;
        }

        public async Task<IActionResult> SarFaslDoreh(int onvanasli, int onvandoreh, int DorehDarkhasti_ID = 0)
        {
            List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
               .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            ViewBag.DorehDarkhasti_ID = DorehDarkhasti_ID;
            var SarFasleha = await _services.GetT_Fasl_Dore(onvanasli, onvandoreh);
            ViewBag.onvanasli = onvanasli;
            ViewBag.onvandoreh = onvandoreh;
            ViewBag.Sheklejra = Sheklejra;
            return View(SarFasleha);
        }

        public async Task<IActionResult> SarFaslDoreh_NewDoreh_Pishnahadi(int onvanasli, int DorehDarkhasti_ID = 0)
        {
            List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
               .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
            ViewBag.DorehDarkhasti_ID = DorehDarkhasti_ID;
            var SarFasleha = await _services.GetT_Fasl_Dorehs_PishnahadiByDoreh(DorehDarkhasti_ID);
            ViewBag.onvanasli = onvanasli;
            ViewBag.Sheklejra = Sheklejra;
            return View(SarFasleha);
        }



        //[HttpGet]
        //public async Task<IActionResult> SarFasliPishnahadi(int DorehDarkhasti_ID = 0, int onvandoreh = 0, int onvanasli = 0)
        //{
        //    List<SelectListItem> Sheklejra = _services.GetRaveshAmozeshis().Result
        //        .Select(x => new SelectListItem { Value = x.Titles_RaveshAmozeshi.ToString(), Text = x.Titles_RaveshAmozeshi }).ToList();
        //    ViewBag.Sheklejra = Sheklejra;
        //    ViewBag.DarkhastDoreh = DorehDarkhasti_ID;
        //    ViewBag.onvanasli = onvanasli;
        //    ViewBag.onvandoreh = onvandoreh;
        //    return PartialView();
        //}


        [HttpPost]
        public async Task<IActionResult> SarFasliPishnahadi(List<string> Mohtav, List<string> Modate_Ejra,
            List<string> shekldoreh, int DorehDarkhasti_ID = 0,int onvandoreh=1,int onvanasli=0)
        {
            List<T_Fasl_Doreh_Pishnahadi> List_Fasl = new List<T_Fasl_Doreh_Pishnahadi>();
            for (int i = 0; i < Mohtav.Count; i++)
            {
                T_Fasl_Doreh_Pishnahadi t_Fasl_Doreh_Pishnahadi = new T_Fasl_Doreh_Pishnahadi()
                {
                    Modate_Ejra = Modate_Ejra[i],
                    Mohtava = Mohtav[i],
                    Shekle_Ejra = shekldoreh[i],
                    T_Doreh_Darkhasti_ID = DorehDarkhasti_ID
                };
                List_Fasl.Add(t_Fasl_Doreh_Pishnahadi);
                
            }
            await _services.Add_sar_Fasle_Doreh_Pishnahadi(List_Fasl);
            return RedirectToAction("TeacherOfDoreh", "Request", new { onvanAsli= onvanasli, OnvanDoreh= onvandoreh, DorehDarkhasti_ID=DorehDarkhasti_ID });
        }


        [HttpPost]
        public async Task<IActionResult> SarFaslDoreh_NewDoreh_Pishnahadi(List<string> Mohtav, List<string> Modate_Ejra,
           List<string> shekldoreh, int DorehDarkhasti_ID = 0, int onvanasli = 0)
        {
            List<T_Fasl_Doreh_Pishnahadi> List_Fasl = new List<T_Fasl_Doreh_Pishnahadi>();
            for (int i = 0; i < Mohtav.Count; i++)
            {
                T_Fasl_Doreh_Pishnahadi t_Fasl_Doreh_Pishnahadi = new T_Fasl_Doreh_Pishnahadi()
                {
                    Modate_Ejra = Modate_Ejra[i],
                    Mohtava = Mohtav[i],
                    Shekle_Ejra = shekldoreh[i],
                    T_Doreh_Darkhasti_ID = DorehDarkhasti_ID
                };
                List_Fasl.Add(t_Fasl_Doreh_Pishnahadi);

            }
            await _services.Add_sar_Fasle_Doreh_Pishnahadi(List_Fasl);
            return RedirectToAction("TeacherOfDoreh_NewDoreh", "Request", new { onvanAsli = onvanasli, DorehDarkhasti_ID = DorehDarkhasti_ID });
        }

    }


}

