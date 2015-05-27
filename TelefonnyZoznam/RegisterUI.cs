using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TelefonnyZoznam
{
    class RegisterUI
    {        
        /// <summary>
        /// vytvaram register
        /// </summary>
        Register register = new Register();

        public void OpenRegister()
        {
            int volba = 0;
            while (volba != 7)
            {
                Console.Clear();
                Console.WriteLine("1 - Add contact");
                Console.WriteLine("2 - Get All contacts");
                Console.WriteLine("3 - Remove contact");
                Console.WriteLine("4 - Find By Name");
                Console.WriteLine("5 - Find By Email");
                Console.WriteLine("6 - Find By Phone Number");
                Console.WriteLine("7 - Close");
                Console.WriteLine("8 - Save contact list.");
                Console.WriteLine("9 - Load contact list.");
                char vyber = Console.ReadKey().KeyChar;

                switch (vyber)
                {
                    case '1':
                        PridajKontakt();
                        Console.WriteLine("Kontakt pridany!");
                        Console.ReadLine();
                        break;
                    case '2':
                        Console.WriteLine("Vypisujem zoznam:");
                        VypisZoznam();
                        Console.ReadLine();
                        break;
                    case '3':
                        OdstranKontakt();
                        Console.WriteLine("Kontakt bol uspesne odstraneny!");
                        Console.ReadLine();
                        break;
                    case '4':
                        NajdiKontaktPodlaMena();
                        Console.ReadLine();
                        break;
                    case '5':
                        NajdiKontaktPodlaEmailu();
                        Console.ReadLine();
                        break;
                    case '6':
                        NajdiKontaktPodlaCisla();
                        Console.ReadLine();
                        break;
                    case '7':
                        Environment.Exit(0);
                        break;
                    case '8':
                        Save();
                        Console.WriteLine("Ulozene");
                        Console.ReadLine();
                        break;
                    case '9':
                        Load();
                        Console.WriteLine("Nacitane");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Zle zadany vstup! Skus znova");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void Save()
        {
            using (Stream stream = new FileStream(@"C:\contact.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, register);
            }
        }

        private void Load()
        {
            using (Stream stream = new FileStream(@"C:\contact.dat", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                register = (Register)bf.Deserialize(stream);
            }
        }

        private void PridajKontakt()
        {
            Console.Write("Zadaj meno: ");
            string meno = Console.ReadLine();
            Console.Write("Zadaj cislo: ");
            int cislo = int.Parse(Console.ReadLine());
            Console.Write("Zadaj email: ");
            string email = Console.ReadLine();
            Contact kontakt = new Contact(meno, cislo, email);
            register.AddContact(kontakt);
        }

        private void VypisZoznam()
        {
            foreach (object osoba in register.GetContacts())
            {
                Console.WriteLine(osoba);
            }
        }

        private void OdstranKontakt()
        {
            Console.Write("Zadajte cislo kontaktu ktory chcete odstranit: ");
            int cislo = int.Parse(Console.ReadLine());
            register.RemoveContact(cislo);
        }

        private void NajdiKontaktPodlaMena()
        {
            Console.Write("Zadaj meno: ");
            string meno = Console.ReadLine();
            foreach (object osoba in register.FindByName(meno))
            {
                Console.WriteLine(osoba);                
            }
        }

        private void NajdiKontaktPodlaCisla()
        {
            Console.Write("Zadaj cislo: ");
            int cislo = int.Parse(Console.ReadLine());
            foreach (object osoba in register.FindByNumber(cislo))
            {
                Console.WriteLine(osoba);
            }
        }

        private void NajdiKontaktPodlaEmailu()
        {
            Console.Write("Zadaj email: ");
            string email = Console.ReadLine();
            foreach (object osoba in register.FindByEmail(email))
            {
                Console.WriteLine(osoba);
            }
        }
    }
}
