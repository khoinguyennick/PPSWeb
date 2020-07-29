using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class AddProjectModel
    {
        public string ProjectCompanyId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class UpdateProjectModel
    {
        public int Id { get; set; }
        public string ProjectCompanyId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class ProjectStatusModel
    {
        public int ProjectId { get; set; }
        public int StatusId { get; set; }
    }

    public class AddEmpToProjModel
    {
        public int ProjectId { get; set; }
        public int EmlpoyeeId { get; set; }
    }

    public class WorkTimeEmInProjModel
    {
        public int EmpId { get; set; }
        public string EmpCompId { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; }
    }
}
