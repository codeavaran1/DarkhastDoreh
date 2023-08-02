namespace Request_Course.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class T_Modaresan_Fild_Amozeshi
    {
        [Key]
        public int ID_Modaresan_Fild_Amozeshi { get; set; }

        public int? T_L_FildAsli_ID { get; set; }

        public int? T_L_OnvanDoreh_ID { get; set; }

        public int? T_Modaresan_ID { get; set; }

        public DateTime? Date_Create { get; set; }

        public virtual T_L_FildAsli T_L_FildAsli { get; set; }

        public virtual T_L_OnvanDoreh T_L_OnvanDoreh { get; set; }

        public virtual T_Modaresan T_Modaresan { get; set; }
    }
}
