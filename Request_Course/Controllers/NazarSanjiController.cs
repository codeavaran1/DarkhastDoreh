﻿using Microsoft.AspNetCore.Mvc;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

namespace Request_Course.Controllers
{
    public class NazarSanjiController : Controller
    {
        private IRepository _services;
        public NazarSanjiController(IRepository repository)
        {
            _services = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Nazarsanj(string Username,int Doreh_Darkhasti_ID)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nazarsanj(NazarSanjiVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            T_Nazarsanji t_Nazarsanji = new T_Nazarsanji()
            {
                Num_Roayat_Nazm = model.Num_Roayat_Nazm,
                Num_Roayat_Sarfasl = model.Num_Roayat_Sarfasl,
                Num_TamoolBaFaragir = model.Num_TamoolBaFaragir,
                Num_Tasalot = model.Num_Tasalot,
                T_Doreh_Darkhasti_ID = model.T_Doreh_Darkhasti_ID,
                DateCreate =await _services.ConvertDateToShamsi(DateTime.Now),
                UserID = model.Username,
            };
            var Avrage =(model.Num_Roayat_Sarfasl + model.Num_Roayat_Nazm + model.Num_TamoolBaFaragir + model.Num_Tasalot)/4;
            t_Nazarsanji.Avg_Num = Avrage;
            await _services.AddNazasanji(t_Nazarsanji);
            return View();
        }

    }
}
