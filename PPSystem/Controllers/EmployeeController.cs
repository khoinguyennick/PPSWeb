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
    public class EmployeeController : Controller
    {
        ResponseAPI _responseAPI = new ResponseAPI();
        private readonly string API_HOST = "https://projectporfoliosystem20200630144446.azurewebsites.net/";
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Employees");
            var isEmpty = await rs.Content.ReadAsStringAsync();
            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();
            if (rs.IsSuccessStatusCode)
            {
                if (isEmpty != "Empty!!!")
                {
                    var result = _responseAPI.ReadAsJsonAsync<List<EmployeeViewModel>>(rs.Content).Result;
                    ViewBag.Employees = result;
                }
                else
                {
                    ViewBag.Employees = employeeViewModels;
                }

            }
            #region Role
            rs = await client.GetAsync(API_HOST + "/api/Roles");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.Roles = result;
            }
            #endregion
            return View();
        }

        public async Task<IActionResult> Add(string message)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Employees");
            #region Role
            rs = await client.GetAsync(API_HOST + "/api/Roles");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.Roles = result;
            }
            #endregion
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            return View();
        }
        public async Task<IActionResult> Update(int empId)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Employees");
            #region Role
            rs = await client.GetAsync(API_HOST + "/api/Roles");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.Roles = result;
            }
            #endregion
            #region Employee
            HttpResponseMessage rsEmp = await client.GetAsync(API_HOST + "/api/Employees/" + empId);
            var resultEmp = _responseAPI.ReadAsJsonAsync<EmployeeEditModel>(rsEmp.Content).Result;
            ViewBag.EMP = resultEmp;
            #endregion
            //if (!string.IsNullOrEmpty(message))
            //{
            //    ViewBag.Message = message;
            //}
            return View();
        }

        public async Task<IActionResult> UpdateEmp(EmployeeEditModel model)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Employees");
            #region Role
            rs = await client.GetAsync(API_HOST + "/api/Roles");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.Roles = result;
            }
            #endregion
            var content = _responseAPI.GetContent<EmployeeEditModel>(model);

            HttpResponseMessage rsUpdate = await client.PutAsync(API_HOST + "/api/Employees", content);
            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> AddEmp(string empId, string empName, int role, int? manpower)
        {
            if (string.IsNullOrEmpty(empId))
            {
                return RedirectToAction("Add", "Employee", new { message = "Please input full information!!!" });
            }
            if (string.IsNullOrEmpty(empName))
            {
                return RedirectToAction("Add", "Employee", new { message = "Please input full information!!!" });
            }
            int manpw = 0;
            if (manpower == null)
            {
                return RedirectToAction("Add", "Employee", new { message = "Please input full information!!!" });
            }
            else
            {
                manpw = (int)manpower;
            }

            EmployeeCreateModel model = new EmployeeCreateModel()
            {
                EmployeeCompanyId = empId,
                FullName = empName,
                Manpower = manpw,
                RoleId = role
            };
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var content = _responseAPI.GetContent<EmployeeCreateModel>(model);

            HttpResponseMessage rs = await client.PostAsync(API_HOST + "/api/Employees", content);
            string message = "";
            if (rs.IsSuccessStatusCode)
            {
                message = "Successfully!!";
            }
            else if (rs.ReasonPhrase.Equals("Conflict"))
            {
                message = "Employee Code exist";
            }
            else
            {
                message = "Invalid Employee";
            }
            return RedirectToAction("Add", "Employee", new { message = message });
        }

        public async Task<IActionResult> AddWorkTime(int empId, int workTime, string emp)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            EmpWorkTimeAddModel model = new EmpWorkTimeAddModel()
            {
                EmployeeId = empId,
                WorkHour = workTime
            };
            var content = _responseAPI.GetContent<EmpWorkTimeAddModel>(model);
            HttpResponseMessage rs = await client.PostAsync(API_HOST + "/api/WorkTime", content);
            return RedirectToAction("EmployeeWork", "Employee", new { empId = empId, emp = emp });
        }

        public async Task<IActionResult> EmployeeWork(int empId, string emp)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/WorkTime/" + empId);
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<WorkTimeSearchModel>>(rs.Content).Result;
                ViewBag.EmpWork = result;
            }
            else if (rs.ReasonPhrase.Equals("Conflict"))
            {
                ViewBag.EmpWork = new List<WorkTimeSearchModel>();
            }
            ViewBag.Emp = emp;
            ViewBag.EmpId = empId;
            return View();
        }
    }
}