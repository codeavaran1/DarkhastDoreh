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
                if (user.Activation == true)
                {
                    // privent Arrive two times
                    if (user.DateGenerateCode >= DateTime.Now.AddMinutes(-5))
                    {
                        return RedirectToAction("GetPhone");
                    }
                }

                //Re generate Code
                //send SMS Code
                user.DateGenerateCode = DateTime.Now;
                user.code = "98751";
                user.Activation = true;
                await _servises.UpdateActivation(user);

            }
            else
            {
                //Cerate Avtivation
                //Send SMS Code
                #region Gneret Code
                var chars = "123456789";
                var stringChars = new char[5];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                #endregion

                T_Activation t_Activation = new T_Activation()
                {
                    Phone = activation.Phone,
                    //code = finalString,
                    code = "12345",
                    Activation = true,
                    DateGenerateCode = DateTime.Now,
                    NameFamily = "User",
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
        public async Task<IActionResult> GetCode(string phone = "", bool Error = false)
        {
            ViewBag.Error = "";
            ViewBag.Phone = phone;
            if (Error == true)
            {
                ViewBag.Error = "کد اشتیاه است";
            }
            var Activtion = await _servises.GetActivation(phone);

            var time = Activtion.DateGenerateCode - DateTime.Now.AddMinutes(-5);

            //Timer 
            ViewBag.sec = time.Value.Seconds;
            ViewBag.min = time.Value.Minutes;
            ViewBag.during = (((ViewBag.min-1)*100)+ ViewBag.sec)-60;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetCode(CodeVm codeVm)
        {
            ViewBag.Error = "";
            if (!ModelState.IsValid)
            {
                return View(codeVm);
            }
            string Code = await _servises.GetUserCode(codeVm.Phone);
            if (Code.ToString() == codeVm.Code && Code.ToString() != "" && codeVm.Code != null)
            {
                var Activtion = await _servises.GetActivation(codeVm.Phone);
                if (Activtion.DateGenerateCode >= DateTime.Now.AddMinutes(-5))
                {
                    var clm = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,Activtion.Phone),
                        new Claim(ClaimTypes.Name,Activtion.Phone)
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
                    Activtion.Activation = false;
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
                            teacher.LastTimeArrive = await _servises.ConvertDateToShamsi(DateTime.Now);
                            await _servises.UpdateModaresan(teacher);
                            if (string.IsNullOrEmpty(teacher.Email))
                            {
                                return RedirectToAction("TeacherForm", "Teacher", new { phone = codeVm.Phone });
                            }
                            return RedirectToAction("Index", "Teacher", new { teacherId = teacher.ID_Modaresan });
                        }
                    }
                    else
                    {
                        var Mokhatab = await _servises.GetMokhatebin(codeVm.Phone);
                        if (Mokhatab == null)
                        {
                            return RedirectToAction("RequestForm", "Request", new { phone = codeVm.Phone });
                        }
                        else
                        {
                            Mokhatab.LastTimeArrive = await _servises.ConvertDateToShamsi(DateTime.Now);
                            await _servises.UpdateMokhatab(Mokhatab);
                            if (string.IsNullOrEmpty(Mokhatab.Email))
                            {
                                return RedirectToAction("RequestForm", "Request", new { phone = codeVm.Phone });
                            }
                            return RedirectToAction("Index", "Mokhatab", new { phone = Mokhatab.Phone });
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
            ViewBag.Error = "کد اشتتباه است";
            return RedirectToAction("GetCode", new { phone = codeVm.Phone, Error = true });


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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GetPhone", "Account");
        }

        #endregion




    }
}
