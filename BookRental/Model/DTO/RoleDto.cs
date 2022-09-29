﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Model
{
    internal class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<ReaderDto> Readers { get; set; }
    }
}
