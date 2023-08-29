using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request_Course.VM
{
    public class ModaresanUpdateVM
    {
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Daneshgah_Sherkat { get; set; }

        [StringLength(250)]
        public string Onvan_Shoghli { get; set; } = string.Empty;

        
        [StringLength(100)]
        public string NameFamily { get; set; } = string.Empty;       

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Phone { get; set; }

    }
}
