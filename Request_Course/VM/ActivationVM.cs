using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class ActivationVM
    {
        [StringLength(12)]
        [MinLength(9)]
        public string Phone { get; set; }

        public bool Teacher { get; set; }=false;

        public bool student { get; set; } = false;

        public string NameFamily { get; set; }


    }
}
