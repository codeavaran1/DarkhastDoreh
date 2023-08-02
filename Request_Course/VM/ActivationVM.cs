using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class ActivationVM
    {
        [MaxLength(13)]
        [MinLength(9)]
        public string Phone { get; set; } = string.Empty;

        public bool Teacher { get; set; }=false;

        public bool student { get; set; } = false;

        public string NameFamily { get; set; } = string.Empty;


    }
}
