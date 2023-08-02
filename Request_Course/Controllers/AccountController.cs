using Microsoft.AspNetCore.Mvc;
using Request_Course.Models;
using Request_Course.Serivces.Interface;
using Request_Course.VM;

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
                            return RedirectToAction("FollowUpTeacher", "Teacher");
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
                            return RedirectToAction("FollowUpRequest", "Request");
                        }

                    }
                }
                else
                {
                    Activtion.code = "";
                    await _servises.UpdateActivation(Activtion);
                    //Expired Time of Code
                    return RedirectToAction("ReCode");
                }
            }
            //wrong Code
            return RedirectToAction("ReCode");

        }

        public async Task<IActionResult> ReCode()
        {
            //For undertanding user for Re Generate Code 
            return View();
        }

        #endregion




    }
}
