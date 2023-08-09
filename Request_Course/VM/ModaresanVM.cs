using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request_Course.VM
{
    public class ModaresanVM
    {
        [Required(ErrorMessage ="فیلد اجباری است")]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required(ErrorMessage = "فیلد اجباری است")]
        [MaxLength(150)]
        public string Daneshgah_Reshteh { get; set; }

        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "فیلد اجباری است")]
        public string Description { get; set; }
        [Required(ErrorMessage = "فیلد اجباری است")]
        public string OnvanShoghli { get; set; } 






    }
}
