using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRental.Model.DTO;

namespace BookRental.Model
{
    internal class ReaderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }

        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
        ICollection<LoanDto> Loans { get; set; }
    }
}
