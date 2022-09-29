using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Model.DTO
{
    internal class LoanDto
    {
        public int Id { get; set; }
        public DateTime DateOfLoan { get; set; }
        public DateTime? DateOfReturn { get; set; }

        public int ReaderId { get; set; }
        public ReaderDto Reader { get; set; }

        public int BookId { get; set; }
        public BookDTO Book { get; set; }
    }
}
