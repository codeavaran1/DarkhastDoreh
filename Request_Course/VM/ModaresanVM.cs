using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request_Course.VM
{
    public class ModaresanVM
    {
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Daneshgah_Reshteh { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string OnvanShoghli { get; set; }=string.Empty;



    }
}
