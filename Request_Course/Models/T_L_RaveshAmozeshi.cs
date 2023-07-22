namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_L_RaveshAmozeshi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_RaveshAmozeshi()
        {
            T_Doreh_Darkhasti = new HashSet<T_Doreh_Darkhasti>();
        }

        [Key]
        public int ID_L_RaveshAmozeshi { get; set; }

        [StringLength(50)]
        public string Titles_RaveshAmozeshi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Doreh_Darkhasti> T_Doreh_Darkhasti { get; set; }
    }
}
