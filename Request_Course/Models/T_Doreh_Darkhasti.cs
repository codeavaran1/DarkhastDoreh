namespace Request_Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class T_Doreh_Darkhasti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Doreh_Darkhasti()
        {
            T_Fasl_Doreh_Pishnahadi = new HashSet<T_Fasl_Doreh_Pishnahadi>();
            T_MarahelDoreh = new HashSet<T_MarahelDoreh>();
            T_Nazarsanji = new HashSet<T_Nazarsanji>();
            T_Pishnahad_Modares_Doreh = new HashSet<T_Pishnahad_Modares_Doreh>();
        }

        [Key]
        public int ID_Doreh_Darkhasti { get; set; }

        public int? T_Mokhatebin_ID { get; set; }

        public int? T_L_OnvanAsli_ID { get; set; }

        public int? T_L_OnvanDoreh_ID { get; set; }

        [StringLength(250)]
        public string OnvanDoreh_Jadid { get; set; } = string.Empty;

        public int? T_L_MediaAmozeshi_ID { get; set; }

        public int? T_L_RaveshAmozeshi_ID { get; set; }

        public int? T_L_ModateDoreh_ID { get; set; }

        public int? T_L_MokhatabanDoreh_ID { get; set; }

        public DateTime? Date_Az_Pishnahad { get; set; }

        public DateTime? Date_Ta_Pishnahad { get; set; }

        public int? T_L_SatheKeyfi_Modares_ID { get; set; }

        public int? T_Modaresan_ID { get; set; }

        public DateTime? Date_Az_Ejra { get; set; }

        public DateTime? Date_Ta_Ejra { get; set; }

        public decimal? Nomreh_Modares { get; set; }

        public DateTime? Date_Create { get; set; }

        public int? T_L_Vaziyat_Doreh_ID { get; set; }

        public virtual T_L_MediaAmozeshi T_L_MediaAmozeshi { get; set; }

        public virtual T_L_ModateDoreh T_L_ModateDoreh { get; set; }

        public virtual T_L_MokhatabanDoreh T_L_MokhatabanDoreh { get; set; }

        public virtual T_L_OnvanDoreh T_L_OnvanDoreh { get; set; }

        public virtual T_L_RaveshAmozeshi T_L_RaveshAmozeshi { get; set; }

        public virtual T_L_SatheKeyfi_Modares T_L_SatheKeyfi_Modares { get; set; }

        public virtual T_L_Vaziyat_Doreh T_L_Vaziyat_Doreh { get; set; }

        public virtual T_Modaresan T_Modaresan { get; set; }

        public virtual T_Mokhatebin T_Mokhatebin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Fasl_Doreh_Pishnahadi> T_Fasl_Doreh_Pishnahadi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_MarahelDoreh> T_MarahelDoreh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Nazarsanji> T_Nazarsanji { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Pishnahad_Modares_Doreh> T_Pishnahad_Modares_Doreh { get; set; }
    }
}
