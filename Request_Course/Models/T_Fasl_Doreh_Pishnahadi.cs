namespace Request_Course.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class T_Fasl_Doreh_Pishnahadi
    {
        [Key]
        public int ID_Fasl_Doreh_Pishnahadi { get; set; }

        [StringLength(550)]
        public string Mohtava { get; set; }

        [StringLength(50)]
        public string Modate_Ejra { get; set; }

        [StringLength(50)]
        public string Shekle_Ejra { get; set; }

        public int? T_Doreh_Darkhasti_ID { get; set; }

        public virtual T_Doreh_Darkhasti T_Doreh_Darkhasti { get; set; }
    }
}
