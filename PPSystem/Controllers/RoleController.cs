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
    public class RoleController : Controller
    {
        ResponseAPI _responseAPI = new ResponseAPI();
        private readonly string API_HOST = "https://projectporfoliosystem20200630144446.azurewebsites.net/";

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            #region Role
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Roles");
            var isEmpty = await rs.Content.ReadAsStringAsync();
            List<BaseModel> roleViewModels = new List<BaseModel>();
            if (rs.IsSuccessStatusCode)
            {
                if (isEmpty != "Empty!!!")
                {
                    var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                    ViewBag.Roles = result;
                }
                else
                {
                    ViewBag.Roles = roleViewModels;
                }
            }
            #endregion
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public async Task<IActionResult> Remove(int roleId)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.DeleteAsync(API_HOST + "/api/Roles/" + roleId);
            return RedirectToAction("Index", "Role");
        }

        public async Task<IActionResult> AddRole(string roleName)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            RoleModel model = new RoleModel()
            {
                RoleName = roleName
            };
            var content = _responseAPI.GetContent<string>(roleName);

            HttpResponseMessage rs = await client.PostAsync(API_HOST + "/api/Roles", content);
            return RedirectToAction("Add", "Role");
        }
        public async Task<IActionResult> Update(int roleId)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Roles/" + roleId);
            var result = _responseAPI.ReadAsJsonAsync<BaseModel>(rs.Content).Result;
            ViewBag.Roles = result;
            return View();
        }
        public async Task<IActionResult> UpdateRole(BaseModel model)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var content = _responseAPI.GetContent<BaseModel>(model);

            HttpResponseMessage rs = await client.PutAsync(API_HOST + "/api/Roles", content);
            return RedirectToAction("Index", "Role");
        }
    }
}