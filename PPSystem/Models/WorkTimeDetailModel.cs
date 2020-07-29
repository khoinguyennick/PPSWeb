using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class WorkTimeDetailModel
    {

        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime WorkDate { get; set; }
        public double WorkTime { get; set; }
    }

    public class WorkTimeDetailStringModel
    {

        public string Id { get; set; }
        public string Description { get; set; }
        public string WorkDate { get; set; }
        public double WorkTime { get; set; }
    }

    public class WorkTimeAddModel
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public double WorkTime { get; set; }
    }
}
