using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Enter user name")]
        [MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(3, ErrorMessage = "Password must have at least 3 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
