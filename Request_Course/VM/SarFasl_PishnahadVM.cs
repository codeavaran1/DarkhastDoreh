using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class SarFasl_PishnahadVM
    {
        [StringLength(550)]
        public string Mohtav { get; set; }

        [StringLength(50)]
        public string Modate_Ejra { get; set; }



        
    }
}
