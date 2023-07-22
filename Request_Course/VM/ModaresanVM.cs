using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request_Course.VM
{
    public class ModaresanVM
    {
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Daneshgah_Reshteh { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public string OnvanShoghli { get; set; }=string.Empty;



    }
}
