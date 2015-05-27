using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonnyZoznam
{
    [Serializable]
    class Contact
    {
        public string Meno { get; set; }
        public int TelefonneCislo { get; set; }
        public string Email { get; set; }


        public Contact(string meno, int telefonneCislo, string email)
        {
            Meno = meno;
            TelefonneCislo = telefonneCislo;
            Email = email;
        }

        public override string ToString()
        {
            return Meno + " " + TelefonneCislo + " " + Email;
        }

    }
}
