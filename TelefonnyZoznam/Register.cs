using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonnyZoznam
{
    [Serializable]
    class Register
    {
        public List<Contact> contacts;

        public Register()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {

            contacts.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            contacts.OrderBy(c => c.Meno);
            return contacts;
        }

        public List<Contact> FindByNumber(int cislo)
        {
            return contacts.FindAll(c => c.TelefonneCislo == cislo).ToList();
        }

        public List<Contact> FindByName(string name)
        {
            return contacts.FindAll(c => c.Meno == name).ToList();
        }

        public List<Contact> FindByEmail(string email)
        {
            return contacts.FindAll(c => c.Email == email).ToList();
        }

        public void RemoveContact(int cislo)
        {
            contacts.RemoveAll(c => c.TelefonneCislo == cislo);
        }
    }
}
