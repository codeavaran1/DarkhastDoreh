namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_L_Sathe_Sherkat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_Sathe_Sherkat()
        {
            T_Mokhatebin = new HashSet<T_Mokhatebin>();
        }

        [Key]
        public int ID_Sathe_Sherkat { get; set; }

        [StringLength(50)]
        public string Titles_Sathe_Sherkat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Mokhatebin> T_Mokhatebin { get; set; }
    }
}
