using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PPSystem.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ChangeEmailModel
    {
        [Required]
        public string CurrentEmail { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }

        public string Token { get; set; }
    }
}
