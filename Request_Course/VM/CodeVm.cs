using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class CodeVm
    {
        [MaxLength(5, ErrorMessage = "کد 5 رقمی را وارد نمایید")]
        [Required(ErrorMessage = "وارد کردن کد اجباری است")]
        public string Code { get; set; } = string.Empty;
        public string Phone { get; set; }= string.Empty;

    }
}
