namespace Request_Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class T_Modaresan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Modaresan()
        {
            T_Activation = new HashSet<T_Activation>();
            T_Doreh_Darkhasti = new HashSet<T_Doreh_Darkhasti>();
            T_Modaresan_Fild_Amozeshi = new HashSet<T_Modaresan_Fild_Amozeshi>();
            T_Pishnahad_Modares_Doreh3 = new HashSet<T_Pishnahad_Modares_Doreh>();
            T_Pishnahad_Modares_Doreh2 = new HashSet<T_Pishnahad_Modares_Doreh>();
            T_Pishnahad_Modares_Doreh1 = new HashSet<T_Pishnahad_Modares_Doreh>();
        }

        [Key]
        public int ID_Modaresan { get; set; }

        public int? T_L_ReshtehTahsili_ID { get; set; }

        public int? T_L_MaghtaeTahsili_ID { get; set; }

        public int? T_L_DaragehElmi_ID { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Daneshgah_Sherkat { get; set; }

        public decimal? Nomreh_Keyfi { get; set; }

        public float? Nomreh_Keyfi_float { get; set; }

        [StringLength(250)]
        public string Onvan_Shoghli { get; set; } = string.Empty;

        [StringLength(50)]
        public string MadrakTahsili { get; set; }

        [StringLength(100)]
        public string NameFamily { get; set; } = string.Empty;

        public int? Sathe_Keyfi { get; set; }

        public int? C_Doreh_Ejra { get; set; }

        public int? Rotbe_Modares { get; set; }

        public decimal? Avg_Nomreh_Tadris { get; set; }

        public float? Avg_Nomreh_Tadris_float { get; set; }

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        public string? img { get; set; }


        [StringLength(50)]
        public string ?Phone { get; set; }

        [StringLength(30)]
        public string? Mobile { get; set; }

        public DateTime? DateCreate { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Activation> T_Activation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Doreh_Darkhasti> T_Doreh_Darkhasti { get; set; }

        public virtual T_L_DaragehElmi T_L_DaragehElmi { get; set; }

        public virtual T_L_MaghtaeTahsili T_L_MaghtaeTahsili { get; set; }

        public virtual T_L_ReshtehTahsili T_L_ReshtehTahsili { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Modaresan_Fild_Amozeshi> T_Modaresan_Fild_Amozeshi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Pishnahad_Modares_Doreh> T_Pishnahad_Modares_Doreh3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Pishnahad_Modares_Doreh> T_Pishnahad_Modares_Doreh2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Pishnahad_Modares_Doreh> T_Pishnahad_Modares_Doreh1 { get; set; }

    }
}
