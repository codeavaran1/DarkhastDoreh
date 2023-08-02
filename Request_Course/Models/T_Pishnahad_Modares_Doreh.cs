namespace Request_Course.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class T_Pishnahad_Modares_Doreh
    {
        [Key]
        public int ID_Pishnahad_Modares_Doreh { get; set; }

        public int? T_Doreh_Darkhasti_ID { get; set; }

        public int? T_Modaresan_ID1 { get; set; }

        public int? T_Modaresan_ID2 { get; set; }

        public int? T_Modaresan_ID3 { get; set; }

        [StringLength(150)]
        public string? Pishnahad_Modares_Name1 { get; set; }

        [StringLength(50)]
        public string? Pishnahad_Modares_phone1 { get; set; }

        [StringLength(150)]
        public string? Pishnahad_Modares_Name2 { get; set; }

        [StringLength(50)]
        public string? Pishnahad_Modares_phone2 { get; set; }

        [StringLength(150)]
        public string ?Pishnahad_Modares_Name3 { get; set; }

        [StringLength(50)]
        public string ?Pishnahad_Modares_phone3 { get; set; }

        public virtual T_Doreh_Darkhasti T_Doreh_Darkhasti { get; set; }

        public virtual T_Modaresan T_Modaresan1 { get; set; }

        public virtual T_Modaresan T_Modaresan2 { get; set; }

        public virtual T_Modaresan T_Modaresan3 { get; set; }
    }
}
