using BookRental.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental
{
    public class PenaltyCalculator
    {
        public decimal ExceedingTheReturnDate(int daysExceeded, Role readerRole)
        {
            decimal penalty = 0;

            if (readerRole.Equals(Role.lecturer))
            {
                for (int i = 1; i <= daysExceeded; i++)
                {
                    if (i > 3 && i <= 14) penalty += 2;
                    else if (i > 14 && i <= 28) penalty += 5;
                    else if (i > 28) penalty += 10;
                }
            }
            else if (readerRole.Equals(Role.employee))
            {
                for (int i = 1; i <= daysExceeded; i++)
                {
                    if (i > 28) penalty += 5;
                }
            }
            else if (readerRole.Equals(Role.student))
            {
                for (int i = 1; i <= daysExceeded; i++)
                {
                    if (i >= 1 && i <= 7) penalty += 1;
                    else if (i > 7 && i <= 14) penalty += 2;
                    else if (i > 14 && i <= 28) penalty += 5;
                    else if (i > 28) penalty += 10;
                }
            }
            else penalty = -1;

            return penalty;
        }
    }
}
