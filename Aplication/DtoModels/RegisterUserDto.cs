﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Aplication.DtoModels
{
    public class RegisterUserDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string Nationality { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; } = default!;
        public int RoleId { get; set; } = 1;
    }
}
