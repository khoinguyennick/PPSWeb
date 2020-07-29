using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class WorkTimeViewModel : EmpWorkTimeAddModel
    {
        public int Id { get; set; }
    }
    public class EmpWorkTimeAddModel
    {
        public int EmployeeId { get; set; }
        public double WorkHour { get; set; }
    }
    public class WorkTimeUpdateModel
    {
        public int Id { get; set; }
        public double WorkHour { get; set; }
    }
    public class WorkTimeSearchModel : WorkTimeViewModel
    {
        public DateTime WorkDate { get; set; }
    }
}
