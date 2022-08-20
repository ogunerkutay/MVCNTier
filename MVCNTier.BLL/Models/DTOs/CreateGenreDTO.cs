using MVCNTier.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.BLL.Models.DTOs
{
    public class CreateGenreDTO
    {

        //[RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage ="Only letters are allowed")] //Sadece alfabetik karakterler ve boşluk kabul etsin
        //[RegularExpression(@"^[\\p{L}\\s]+$", ErrorMessage = "Only letters are allowed")] //Unicode
        [Required(ErrorMessage ="Enter name")]
        [MinLength(3,ErrorMessage = "Name must have at least 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter description")]
        public string Description { get; set; }

        public DateTime CreationDate => DateTime.Now;

        public Status Status => Status.Active;
    }
}
