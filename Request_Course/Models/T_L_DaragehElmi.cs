namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_L_DaragehElmi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_DaragehElmi()
        {
            T_Modaresan = new HashSet<T_Modaresan>();
        }

        [Key]
        public int ID_DaragehElmi { get; set; }

        [StringLength(50)]
        public string Titles_DaragehElmi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Modaresan> T_Modaresan { get; set; }
    }
}
