namespace Request_Course.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class T_Nazarsanji
    {
        [Key]
        public int ID_Nazarsanji { get; set; }

        public int? T_Doreh_Darkhasti_ID { get; set; }

        public int? Num_Tasalot { get; set; }

        public int? Num_Roayat_Sarfasl { get; set; }

        public int? Num_Roayat_Nazm { get; set; }

        public int? Num_TamoolBaFaragir { get; set; }

        public decimal? Avg_Num { get; set; }

        public DateTime? DateCreate { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public virtual T_Doreh_Darkhasti T_Doreh_Darkhasti { get; set; }
    }
}
