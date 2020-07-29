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
    public class HomeController : Controller
    {
        ResponseAPI _responseAPI = new ResponseAPI();
        private readonly string API_HOST = "https://projectporfoliosystem20200630144446.azurewebsites.net/";
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("userToken") == null)
            {
                return RedirectToAction("Index", "Account", new { message = "" });
            }
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            #region Employees Statistics
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "api/Employees/Statistics");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<EmployeeStatisticsModel>(rs.Content).Result;
                ViewBag.TotalManpower = result.TotalManpower;
                ViewBag.ManpowerUsing = result.ManpowerUsing;
                ViewBag.EmName1 = "";
                ViewBag.EmName2 = "";
                ViewBag.EmName3 = "";
                ViewBag.EmName4 = "";
                ViewBag.EmName5 = "";
                for (int i = 0; i < result.EmployeeCountInProjects.Count; i++)
                {
                    if (i == 0)
                    {
                        ViewBag.EmName1 = result.EmployeeCountInProjects[i].EmpName;
                    }
                    if (i == 1)
                    {
                        ViewBag.EmName2 = result.EmployeeCountInProjects[i].EmpName;
                    }
                    if (i == 2)
                    {
                        ViewBag.EmName3 = result.EmployeeCountInProjects[i].EmpName;
                    }
                    if (i == 3)
                    {
                        ViewBag.EmName4 = result.EmployeeCountInProjects[i].EmpName;
                    }
                    if (i == 4)
                    {
                        ViewBag.EmName5 = result.EmployeeCountInProjects[i].EmpName;
                    }
                }
                ViewBag.EmpProject1 = 0;
                ViewBag.EmpProject2 = 0;
                ViewBag.EmpProject3 = 0;
                ViewBag.EmpProject4 = 0;
                ViewBag.EmpProject5 = 0;
                for (int i = 0; i < result.EmployeeCountInProjects.Count; i++)
                {
                    if (i == 0)
                    {
                        ViewBag.EmpProject1 = result.EmployeeCountInProjects[i].ProjectCount;
                    }
                    if (i == 1)
                    {
                        ViewBag.EmpProject2 = result.EmployeeCountInProjects[i].ProjectCount;
                    }
                    if (i == 2)
                    {
                        ViewBag.EmpProject3 = result.EmployeeCountInProjects[i].ProjectCount;
                    }
                    if (i == 3)
                    {
                        ViewBag.EmpProject4 = result.EmployeeCountInProjects[i].ProjectCount;
                    }
                    if (i == 4)
                    {
                        ViewBag.EmpProject5 = result.EmployeeCountInProjects[i].ProjectCount;
                    }
                }
            }
            #endregion
            #region Newest Employees
            rs = await client.GetAsync(API_HOST + "api/Employees/Newest");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<NewestEmp>>(rs.Content).Result;
                ViewBag.NewestEmp = result;
            }
            #endregion
            #region Newest Employees
            rs = await client.GetAsync(API_HOST + "api/Employees/InActive");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<InactiveModel>(rs.Content).Result;
                ViewBag.InActiveEmp = result;
            }
            #endregion
            #region Newest Project
            rs = await client.GetAsync(API_HOST + "api/Project/Newest");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<NewestProjectModel>>(rs.Content).Result;
                List<NewestProjectModel> models = new List<NewestProjectModel>();
                for (int i = 0; i < result.Count; i++)
                {
                    if (i < 5)
                    {
                        models.Add(result[i]);
                    }
                }
                ViewBag.NewestProject = models;
            }
            #endregion
            #region Manpower In Project
            rs = await client.GetAsync(API_HOST + "api/Project/Manpower");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<ManpowerInProjectModel>>(rs.Content).Result;
                List<ManpowerInProjectModel> models = new List<ManpowerInProjectModel>();
                for (int i = 0; i < result.Count; i++)
                {
                    if (i < 5)
                    {
                        models.Add(result[i]);
                    }
                }
                ViewBag.ManpowerInProject = models;
            }
            #endregion
            #region Project Statistics
            rs = await client.GetAsync(API_HOST + "api/Project/Statistics");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<ProjectStatisticsModel>(rs.Content).Result;
                double all = result.All;
                double inprogress = result.InProgress;
                double finish = result.Finished;
                ViewBag.ProgressPercent = (inprogress / all) * 100;
                ViewBag.FinishPercent = (finish / all) * 100;
                ViewBag.ProjectStatistics = result;
                if(finish == 0)
                {
                    ViewBag.ProjectFinished = 0;
                }
                else
                {
                    ViewBag.ProjectFinished = result.Finished;
                }
                ViewBag.AllProject = result.All;
                ViewBag.InProgress = result.InProgress;
            }
            #endregion
            return View();
        }

        public IActionResult Project()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
