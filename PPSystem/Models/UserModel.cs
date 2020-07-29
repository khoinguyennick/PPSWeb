using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class EditUserProfileModel
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}
