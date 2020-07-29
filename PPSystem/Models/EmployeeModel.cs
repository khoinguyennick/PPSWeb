using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class EmployeeCreateModel
    {
        public string EmployeeCompanyId { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public int Manpower { get; set; }
    }
    public class EmployeeViewModel : EmployeeCreateModel
    {
        public int Id { get; set; }
    }
    public class EmployeeEditModel
    {
        public int Id { get; set; }
        public string EmployeeCompanyId { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
        public int Manpower { get; set; }
    }
}
