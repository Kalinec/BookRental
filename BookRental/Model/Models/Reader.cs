using BookRental.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRental.Model.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public Role Role { get; set; }

        public Reader(int id, string name, string surname, string pesel, Role role)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel = pesel;
            Role = role;
        }

        public Reader(string name, string surname, string pesel, Role role)
        {
            Name = name;
            Surname = surname;
            Pesel = pesel;
            Role = role;
        }
    }
}
