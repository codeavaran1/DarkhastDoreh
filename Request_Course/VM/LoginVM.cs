using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class LoginVM
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
