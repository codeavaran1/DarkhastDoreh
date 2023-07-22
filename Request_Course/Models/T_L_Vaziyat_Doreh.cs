namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_L_Vaziyat_Doreh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_Vaziyat_Doreh()
        {
            T_Doreh_Darkhasti = new HashSet<T_Doreh_Darkhasti>();
            T_MarahelDoreh = new HashSet<T_MarahelDoreh>();
        }

        [Key]
        public int ID_L_Vaziyat_Doreh { get; set; }

        [StringLength(150)]
        public string Titles_Vaziyat_Doreh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Doreh_Darkhasti> T_Doreh_Darkhasti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_MarahelDoreh> T_MarahelDoreh { get; set; }
    }
}
