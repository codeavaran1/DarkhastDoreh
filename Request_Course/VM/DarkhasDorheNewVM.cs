using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class DarkhasDorheNewVM
    {
        [Required(ErrorMessage = "فیلد اجباری است")]
        public string OnvanDoreh { get; set; }
        [Required(ErrorMessage = "فیلد اجباری است")]
        public DateTime DateStart { get; set; }
        [Required(ErrorMessage = "فیلد اجباری است")]
        public DateTime DateEnd { get; set; }

        public string Phone { get; set; }

    }
}
