using MVCNTier.Core.Entities.Enums;
using MVCNTier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCNTier.BLL.Models.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="Enter full name")]
        [MinLength(3,ErrorMessage ="Full name must have at least 3 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter user name")]
        [MinLength(3, ErrorMessage = "Username must have at least 3 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [MinLength(3, ErrorMessage = "Password must have at least 3 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter confirm password")]
        [MinLength(3, ErrorMessage = "Confirm password must have at least 3 characters")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        

        public DateTime CreationTime => DateTime.Now;
                
        public Status Status { get; set; }


    }
}
