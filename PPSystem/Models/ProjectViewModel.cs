using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectCompanyId { get; set; }
        public string Description { get; set; }
    }

    public class ProjectDetailViewModel
    {
        public int Id { get; set; }
        public string ProjectCompanyId { get; set; }
        public string Description { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
