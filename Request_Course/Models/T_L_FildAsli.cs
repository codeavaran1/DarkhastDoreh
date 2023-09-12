namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_L_FildAsli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_FildAsli()
        {
            T_Modaresan_Fild_Amozeshi = new HashSet<T_Modaresan_Fild_Amozeshi>();
        }

        [Key]
        public int ID_FildAsli { get; set; }

        [StringLength(150)]
        public string? Titles_FildAsli { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Modaresan_Fild_Amozeshi> T_Modaresan_Fild_Amozeshi { get; set; }
    }
}
