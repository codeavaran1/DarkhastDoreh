namespace Request_Course.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class T_MarahelDoreh
    {
        [Key]
        public int ID_Marahel_Doreh { get; set; }

        public int? T_Doreh_Darkhasti_ID { get; set; }

        public int? T_L_Vaziyat_Doreh_ID { get; set; }

        public DateTime? DateCreate { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public virtual T_Doreh_Darkhasti T_Doreh_Darkhasti { get; set; }

        public virtual T_L_Vaziyat_Doreh T_L_Vaziyat_Doreh { get; set; }
    }
}
