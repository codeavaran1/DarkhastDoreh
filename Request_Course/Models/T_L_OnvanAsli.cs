namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_L_OnvanAsli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_OnvanAsli()
        {
            T_Fasl_Doreh = new HashSet<T_Fasl_Doreh>();
        }

        [Key]
        public int ID_L_OnvanAsli { get; set; }

        [StringLength(50)]
        public string Titles_OnvanAsli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Fasl_Doreh> T_Fasl_Doreh { get; set; }
    }
}
