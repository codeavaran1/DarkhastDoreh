﻿using System.ComponentModel.DataAnnotations;

namespace Request_Course.VM
{
    public class RequesterVM
    {

        [StringLength(150)]
        public string Name_Sherkat { get; set; }
        
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Email { get; set; }
        public string Family { get; set; }




    }
}
