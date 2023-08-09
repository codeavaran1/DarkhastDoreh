using System;
using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class DarkhastDorehAmozeshiVM
    {
        [Required(ErrorMessage = "فیلد اجباری است")]
        public DateTime DateStart{ get; set; }

        [Required(ErrorMessage = "فیلد اجباری است")]
        public DateTime DateEnd { get; set; }


    }
}
