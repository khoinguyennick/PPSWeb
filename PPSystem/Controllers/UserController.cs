using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPSystem.Models;
using PPSystem.Utils;

namespace PPSystem.Controllers
{
    public class UserController : Controller
    {
        ResponseAPI _responseAPI = new ResponseAPI();
        private readonly string API_HOST = "https://projectporfoliosystem20200630144446.azurewebsites.net/";
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Account/Profile");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<UserModel>(rs.Content).Result;
                ViewBag.User = result;
                ViewBag.UserToken = token;
            }
            return View();
        }
        public async Task<IActionResult> EditProfile(string phone, string fullname, string address)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var model = new EditUserProfileModel()
            {
                FullName = fullname,
                PhoneNumber = phone,
                Address = address
            };
            var content = _responseAPI.GetContent<EditUserProfileModel>(model);
            HttpResponseMessage rs = await client.PutAsync(API_HOST + "api/Account/Information", content);
            if (rs.IsSuccessStatusCode)
            {
                TempData["Notify"] = "Edit Profile Successfully!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
    }

}
