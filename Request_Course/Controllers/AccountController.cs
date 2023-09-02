using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;
using System.Security.Claims;

namespace Request_Course.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository _servises;
        public AccountController(IRepository servises)
        {
            _servises = servises;
        }


        #region Arrvie Users

        [HttpGet]
        public async Task<IActionResult> GetPhone()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetPhone(ActivationVM activation, string Persontype = "")
        {
            if (!ModelState.IsValid)
            {
                return View(activation);
            }
            var user = await _servises.GetActivation(activation.Phone);
            if (user != null)
            {
                //Re generate Code
                //send SMS Code
                user.DateGenerateCode = DateTime.Now;
                user.code = "98751";
                await _servises.UpdateActivation(user);

            }
            else
            {
                //Cerate Avtivation
                //Send SMS Code
                T_Activation t_Activation = new T_Activation()
                {
                    Phone = activation.Phone,
                    code = "12345",
                    DateGenerateCode = DateTime.Now,
                    NameFamily = activation.NameFamily,
                };
                if (Persontype == "Teacher")
                {
                    t_Activation.Teacher = true;
                }
                else
                {
                    t_Activation.Student = true;
                }
                await _servises.AddActivation(t_Activation);
            }

            return RedirectToAction("GetCode", new { phone = activation.Phone });
        }

        #endregion

        #region Create and send Code


        [HttpGet]
        public async Task<IActionResult> GetCode(string phone = "")
        {
            ViewBag.Phone = phone;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCode(CodeVm codeVm)
        {
            if (!ModelState.IsValid)
            {
                return View(codeVm);
            }
            string Code = await _servises.GetUserCode(codeVm.Phone);
            if (Code.ToString() == codeVm.Code && Code.ToString() != "")
            {
                var Activtion = await _servises.GetActivation(codeVm.Phone);
                if (Activtion.DateGenerateCode >= DateTime.Now.AddMinutes(-5))
                {
                    var clm = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,Activtion.Phone),
                        new Claim(ClaimTypes.Name,Activtion.NameFamily),
                    };
                    var identity = new ClaimsIdentity(clm, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = false
                    };
                    await HttpContext.SignInAsync(principle, properties);
                    Activtion.code = "";
                    await _servises.UpdateActivation(Activtion);
                    //Execept Code
                    if (Activtion.Teacher == true)
                    {
                        var teacher = await _servises.GetModaresan(codeVm.Phone);
                        if (teacher == null)
                        {
                            return RedirectToAction("TeacherForm", "Teacher", new { phone = codeVm.Phone });
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(teacher.Email))
                            {
                                return RedirectToAction("TeacherForm", "Teacher", new { phone = codeVm.Phone });
                            }
                            return RedirectToAction("Index", "Teacher", new {teacher.ID_Modaresan});
                        }
                    }
                    else
                    {
                        var Mokhatab = await _servises.GetMokhatebin(codeVm.Phone);
                        if (Mokhatab == null)
                        {
                            return RedirectToAction("RequestForm", "Request", new { phone = codeVm.Phone, Family = Activtion.NameFamily });
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(Mokhatab.Email))
                            {
                                return RedirectToAction("RequestForm", "Request", new { phone = codeVm.Phone, Family = Activtion.NameFamily });
                            }
                            return RedirectToAction("Index", "Mokhatab", new { phone =Mokhatab.Phone});
                        }

                    }
                }
                else
                {
                    Activtion.code = "";
                    await _servises.UpdateActivation(Activtion);
                    //Expired Time of Code
                    return RedirectToAction("ReCode", new { phone = codeVm.Phone });
                }
            }
            //wrong Code
            return RedirectToAction("ReCode", new { phone = codeVm.Phone });

        }

        public async Task<IActionResult> ReCode(string phone)
        {
            ViewBag.Phone = phone;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ReCodeConfrim(string phone)
        {
            var user = await _servises.GetActivation(phone);
            if (user != null)
            {
                //Re generate Code
                //send SMS Code
                user.DateGenerateCode = DateTime.Now;
                user.code = "21212";
                await _servises.UpdateActivation(user);

            }
            return RedirectToAction("GetCode", new { phone = phone });
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("GetPhone");
        }

        #endregion




    }
}
