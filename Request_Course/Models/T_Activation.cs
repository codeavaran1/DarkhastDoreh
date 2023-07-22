using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Request_Course.Models
{
    public partial class T_Activation
    {
        [Key]
        public long ID_Activation { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(5)]
        public string code { get; set; }

        [MaxLength(50)]
        public string NameFamily { get; set; }

        public bool Teacher { get; set; } = false;

        public bool Student { get; set; } = false;

        public DateTime? DateGenerateCode { get; set; }

        public int? T_Modaresan_ID { get; set; }

        public int? T_Mokhatebin_ID { get; set; }

        public virtual T_Modaresan T_Modaresan { get; set; }

        public virtual T_Mokhatebin T_Mokhatebin { get; set; }
    }
}
