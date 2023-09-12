namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_L_OnvanDoreh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_L_OnvanDoreh()
        {
            T_Doreh_Darkhasti = new HashSet<T_Doreh_Darkhasti>();
            T_Fasl_Doreh = new HashSet<T_Fasl_Doreh>();
            T_Modaresan_Fild_Amozeshi = new HashSet<T_Modaresan_Fild_Amozeshi>();
        }

        [Key]
        public int ID_OnvanDoreh { get; set; }

        [StringLength(50)]
        public string? Titles_OnvanDoreh { get; set; }


        public int? ID_FildAsli { get; set; }

        [ForeignKey("ID_FildAsli")]
        public T_L_FildAsli? fildAsli { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Doreh_Darkhasti> T_Doreh_Darkhasti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Fasl_Doreh> T_Fasl_Doreh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Modaresan_Fild_Amozeshi> T_Modaresan_Fild_Amozeshi { get; set; }
    }
}
