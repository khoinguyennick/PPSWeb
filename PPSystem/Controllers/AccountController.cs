using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPSystem.Models;
using PPSystem.Utils;

namespace PPSystem.Controllers
{
    public class AccountController : Controller
    {
        ResponseAPI _responseAPI = new ResponseAPI();
        public IActionResult Index(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = "";
            }
            if (HttpContext.Session.GetString("userToken") == null)
            {
                ViewBag.message = message;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var loginModel = new Models.LoginModel()
            {
                Email = email,
                Password = password
            };
            var content = _responseAPI.GetContent<Models.LoginModel>(loginModel);

            HttpClient client = new HttpClient();
            using (client = _responseAPI.Initial())
            {
                HttpResponseMessage rs = await client.PostAsync("api/Account/Auth", content);
                if (rs.IsSuccessStatusCode)
                {
                    var result = _responseAPI.ReadAsJsonAsync<TokenModel>(rs.Content).Result;
                    HttpContext.Session.SetString("userToken", result.Token);

                    HttpContext.Session.SetString("email", email);
                    HttpContext.Session.SetString("address", result.Address);
                    HttpContext.Session.SetString("fullName", result.FullName);
                    HttpContext.Session.SetString("imagePath", result.ImagePath);
                    HttpContext.Session.SetString("phoneNumber", result.PhoneNumber);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Account", new { message = "Username and password doesn't match!!!" });
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userToken");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public IActionResult ForgotPassword(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public async Task<IActionResult> SignUp(string email, string password, string fullname, string address, string phoneNumber)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Register", "Account", new { message = "Please input email!" });
            }

            if (string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Register", "Account", new { message = "Please input password!" });
            }

            if (string.IsNullOrEmpty(fullname))
            {
                return RedirectToAction("Register", "Account", new { message = "Please input fullname!" });
            }

            if (string.IsNullOrEmpty(address))
            {
                return RedirectToAction("Register", "Account", new { message = "Please input address!" });
            }

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return RedirectToAction("Register", "Account", new { message = "Please input phoneNumber!" });
            }

            var signUpModel = new RegisterModel()
            {
                Email = email,
                Password = password,
                FullName = fullname,
                Address = address,
                PhoneNumber = phoneNumber
            };
            var content = _responseAPI.GetContent<RegisterModel>(signUpModel);

            HttpClient client = new HttpClient();
            using (client = _responseAPI.Initial())
            {
                HttpResponseMessage rs = await client.PostAsync("api/Account", content);
                if (rs.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Account", new { message = "Register successfully!"});
                }
                if(rs.ReasonPhrase.Equals("Conflict"))
                {
                    var result = _responseAPI.ReadAsJsonAsync<List<RegisterError>>(rs.Content).Result;
                    return RedirectToAction("Register", "Account", new { message = result[0].Description });
                }
                return RedirectToAction("Register", "Account", new { message = "Your password doesn't strong enough!!!" });
            }
        }
        public async Task<IActionResult> SendEmailAsync(string email)
        {
            var content = _responseAPI.GetContent<string>(email);

            HttpClient client = new HttpClient();
            using (client = _responseAPI.Initial())
            {
                HttpResponseMessage rs = await client.PostAsync("api/Account/Code", content);
                if (rs.IsSuccessStatusCode)
                {
                    return RedirectToAction("ChangePasswordByCode", "Account", new { message = "An email have been sent to " + email + " !!!" , email = email});
                }
                else
                {
                    return RedirectToAction("ForgotPassword", "Account", new { message = "This email doesn't belong to this system!!!" });
                }
            }
        }
        public IActionResult ChangePasswordByCode(string message, string email)
        {
            ViewBag.message = message;
            ViewBag.email = email;
            return View();
        }
        public async Task<IActionResult> PasswordByCodeAsync(string email, string code, string newpassword)
        {
            var model = new PasswordByCodeModel()
            {
                Code = code,
                Email = email,
                Password = newpassword
            };
            var content = _responseAPI.GetContent<PasswordByCodeModel>(model);

            HttpClient client = new HttpClient();
            using (client = _responseAPI.Initial())
            {
                HttpResponseMessage rs = await client.PutAsync("api/Account/PasswordByCode", content);
                if (rs.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Account", new { message = "Successfully!" });
                }
                else
                {
                    return RedirectToAction("ChangePasswordByCode", "Account", new { message = "This code is Expires or Invalid!!!", email = email });
                }
            }
        }
    }
}