namespace Request_Course.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class T_Mokhatebin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Mokhatebin()
        {
            T_Activation = new HashSet<T_Activation>();
            T_Doreh_Darkhasti = new HashSet<T_Doreh_Darkhasti>();
            
        }

        [Key]
        public int ID_Mokhatebin { get; set; }

        [StringLength(150)]
        public string Name_Sherkat { get; set; }=string.Empty;

        [StringLength(150)]
        public string NamFamily_Rabet { get; set; }=string.Empty;

        [StringLength(12)]
        public string Mobile_Rabet { get; set; }=string.Empty;

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public int? T_L_Semat_ID { get; set; }

        public int? T_L_Ostan_ID { get; set; }

        public int? T_L_Sathe_Sherkat_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Activation> T_Activation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Doreh_Darkhasti> T_Doreh_Darkhasti { get; set; }

        public virtual T_L_Ostan T_L_Ostan { get; set; }

        public virtual T_L_Sathe_Sherkat T_L_Sathe_Sherkat { get; set; }

        public virtual T_L_Semat T_L_Semat { get; set; }

       
    }
}
