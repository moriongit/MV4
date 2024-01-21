﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.ViewModels.AuthVM
{
    public class LoginVM
    {
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
    }
}
