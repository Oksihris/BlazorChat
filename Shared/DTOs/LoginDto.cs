﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlazorChat.Shared.DTOs
{
    public class LoginDto
    {
        [Required, MaxLength(40)]
        public string UserName { get; set; }

        [Required, MaxLength(20), DataType(DataType.Password)]
        public string Password { get; set; }
    }

  
}
