namespace Request_Course.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class T_Fasl_Doreh
    {
        [Key]
        public int ID_Fasl_Doreh { get; set; }

        [StringLength(550)]
        public string ?Mohtav { get; set; }

        [StringLength(50)]
        public string ?Modate_Ejra { get; set; }

        [StringLength(50)]
        public string ?Shekle_Ejra { get; set; }

        public int? T_L_OnvanAsli_ID { get; set; }

        public int? T_L_OnvanDoreh_ID { get; set; }

        public virtual T_L_OnvanAsli T_L_OnvanAsli { get; set; }

        public virtual T_L_OnvanDoreh T_L_OnvanDoreh { get; set; }
    }
}
