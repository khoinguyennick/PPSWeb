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
    public class ProjectController : Controller
    {
        ResponseAPI _responseAPI = new ResponseAPI();
        private readonly string API_HOST = "https://projectporfoliosystem20200630144446.azurewebsites.net/";
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "api/Project");
            var isEmpty = await rs.Content.ReadAsStringAsync();

            List<ProjectDetailViewModel> projectDetailViewModels = new List<ProjectDetailViewModel>();
            if (rs.IsSuccessStatusCode)
            {
                if (isEmpty != "Empty!!!")
                {
                    var result = _responseAPI.ReadAsJsonAsync<List<ProjectViewModel>>(rs.Content).Result;
                    foreach (var project in result)
                    {
                        rs = await client.GetAsync(API_HOST + "api/Project/" + project.Id);
                        if (rs.IsSuccessStatusCode)
                        {
                            projectDetailViewModels.Add(_responseAPI.ReadAsJsonAsync<ProjectDetailViewModel>(rs.Content).Result);
                        }
                    }
                }

            }
            ViewBag.Projects = projectDetailViewModels;
            #region Status
            rs = await client.GetAsync(API_HOST + "api/Project/Status");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.Status = result;
            }
            #endregion
            return View();
        }
        public IActionResult Add(string message)
        {
            ViewBag.message = message;
            return View();
        }
        public async Task<IActionResult> Manager(int projectId, string companyId)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/Project/" + projectId);
            ProjectDetailViewModel projectDetailViewModel = new ProjectDetailViewModel();
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<ProjectDetailViewModel>(rs.Content).Result;
                ViewBag.CurrentProject = result;
            }
            #region Status
            rs = await client.GetAsync(API_HOST + "api/Project/Status");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.Status = result;
            }
            #endregion
            #region Manpower In Project
            rs = await client.GetAsync(API_HOST + "api/Project/Manpower");
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<ManpowerInProjectModel>>(rs.Content).Result;
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].Id.Equals(companyId))
                    {
                        ViewBag.Manpower = result[i].Manpower;
                    }
                }
            }
            #endregion
            #region Add Employee
            rs = await client.GetAsync(API_HOST + "/api/Employees/NotInProject/" + projectId);
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<BaseModel>>(rs.Content).Result;
                ViewBag.EmpNotIn = result;
            }
            #endregion
            #region TotalWorkTime
            rs = await client.GetAsync(API_HOST + "/api/WorkTimeInProject/TotalWorkTime/" + projectId);
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<double>(rs.Content).Result;
                ViewBag.TotalWork = result;
            }
            #endregion
            #region WorkTimeEmInProjModel
            rs = await client.GetAsync(API_HOST + "/api/WorkTimeInProject/Employees/" + projectId);
            if (rs.IsSuccessStatusCode)
            {
                var result = _responseAPI.ReadAsJsonAsync<List<WorkTimeEmInProjModel>>(rs.Content).Result;
                ViewBag.WorkTimeEmInProj = result;
            }
            #endregion
            //#region Project
            //HttpResponseMessage rsProject = await client.GetAsync(API_HOST + "/api/Project/" + projectId);
            //var resultProject = _responseAPI.ReadAsJsonAsync<UpdateProjectModel>(rsProject.Content).Result;
            //ViewBag.ProjectUpdate = resultProject;
            //#endregion
            ViewBag.ProjectCompanyId = companyId;
            ViewBag.ProjectId = projectId;
            return View();
        }
        //public async Task<IActionResult> UpdateProject(UpdateProjectModel model)
        //{
        //    HttpClient client = new HttpClient();
        //    string token = HttpContext.Session.GetString("userToken");
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        //    var content = _responseAPI.GetContent<UpdateProjectModel>(model);
        //    HttpResponseMessage rsUpdate = await client.PutAsync(API_HOST + "/api/Project", content);
        //    return RedirectToAction("Manager", "Project");
        //}
        [HttpPost]
        public async Task<IActionResult> AddProject(string projectId, string description, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrEmpty(projectId))
            {
                return RedirectToAction("Add", "Project", new { message = "Please input full information!!!" });
            }
            if (string.IsNullOrEmpty(description))
            {
                return RedirectToAction("Add", "Project", new { message = "Please input full information!!!" });
            }
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            AddProjectModel model = new AddProjectModel()
            {
                Description = description,
                EndDate = endDate,
                ProjectCompanyId = projectId,
                StartDate = startDate
            };

            var content = _responseAPI.GetContent<AddProjectModel>(model);

            HttpResponseMessage rs = await client.PostAsync(API_HOST + "api/Project", content);
            string message = "";
            if (rs.IsSuccessStatusCode)
            {
                message = "Successfully!!";
            }
            else if (rs.ReasonPhrase.Equals("Conflict"))
            {
                message = "Project exist";
            }
            else
            {
                message = "Invalid Date";
            }
            return RedirectToAction("Add", "Project", new { message = message });
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int statusId, int projectId, string projectComanyId)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            ProjectStatusModel projectStatusModel = new ProjectStatusModel()
            {
                ProjectId = projectId,
                StatusId = statusId
            };
            var content = _responseAPI.GetContent<ProjectStatusModel>(projectStatusModel);
            HttpResponseMessage rs = await client.PutAsync(API_HOST + "/api/Project/Status", content);
            ProjectDetailViewModel projectDetailViewModel = new ProjectDetailViewModel();
            if (rs.IsSuccessStatusCode)
            {
                return RedirectToAction("Manager", "Project", new { projectId = projectId, companyId = projectComanyId });
            }
            return RedirectToAction("Manager", "Project", new { projectId = projectId, companyId = projectComanyId });
        }
        [HttpPost]
        public async Task<IActionResult> AddEmpToProj(int empId, int projectId, string projectComanyId)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            AddEmpToProjModel addEmpToProjModel = new AddEmpToProjModel()
            {
                ProjectId = projectId,
                EmlpoyeeId = empId
            };
            var content = _responseAPI.GetContent<AddEmpToProjModel>(addEmpToProjModel);
            HttpResponseMessage rs = await client.PostAsync(API_HOST + "/api/Project/Employee", content);
            ProjectDetailViewModel projectDetailViewModel = new ProjectDetailViewModel();
            if (rs.IsSuccessStatusCode)
            {
                return RedirectToAction("Manager", "Project", new { projectId = projectId, companyId = projectComanyId });
            }
            return RedirectToAction("Manager", "Project", new { projectId = projectId, companyId = projectComanyId });
        }
        public async Task<IActionResult> WorkTimeDetail(int empId, int projectId, string projectName)
        {
            ViewBag.EmpId = empId;
            ViewBag.ProjectId = projectId;
            ViewBag.ProjectName = projectName;
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage rs = await client.GetAsync(API_HOST + "/api/WorkTimeInProject/WorkTimeDetail/" + projectId + "/" + empId);
            if (rs.IsSuccessStatusCode)
            {
                List<WorkTimeDetailStringModel> workTimeDetail = new List<WorkTimeDetailStringModel>();
                var result = _responseAPI.ReadAsJsonAsync<List<WorkTimeDetailModel>>(rs.Content).Result;
                foreach (var item in result)
                {
                    workTimeDetail.Add(new WorkTimeDetailStringModel()
                    {
                        Id = item.Id,
                        WorkDate = item.WorkDate.Day + "/" + item.WorkDate.Month + "/" + item.WorkDate.Year,
                        Description = item.Description,
                        WorkTime = item.WorkTime
                    });
                }
                ViewBag.WorkTimeDetail = workTimeDetail;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkTime(int empId, int projectId, string projectName, double workHours)
        {
            HttpClient client = new HttpClient();
            string token = HttpContext.Session.GetString("userToken");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            WorkTimeAddModel model = new WorkTimeAddModel()
            {
                WorkTime = workHours,
                EmpId = empId,
                ProjectId = projectId
            };
            var content = _responseAPI.GetContent<WorkTimeAddModel>(model);
            HttpResponseMessage rs = await client.PostAsync(API_HOST + "/api/WorkTimeInProject/WorkTime", content);
            return RedirectToAction("WorkTimeDetail", "Project", new { empId = empId, projectId = projectId, projectName = projectName });
        }
    }
}