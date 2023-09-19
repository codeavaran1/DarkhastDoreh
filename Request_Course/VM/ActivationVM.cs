using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class ActivationVM
    {
        [MaxLength(12, ErrorMessage = "شماره تلفن12 رقم است")]
        [Required(ErrorMessage = "فیلد اجباری است")]
        public string Phone { get; set; } = string.Empty;

        public bool Teacher { get; set; }=false;

        public bool student { get; set; } = false;

        public string NameFamily { get; set; } = string.Empty;


    }
}
