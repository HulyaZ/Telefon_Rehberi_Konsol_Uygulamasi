using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patika_C101_TelefonRehberi
{
    public class Contact
    {
        private string contactName;
        private string contactSurname;
        private string phoneNumber;
        public string ContactName
        {
            get => contactName;       
            set
            {
                this.contactName = value;               
            }
        }

        public string ContactSurname
        {
            get => contactSurname;
            set
            {
                this.contactSurname = value;
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
            }
        }

        public Contact(string name, string surname, string number)
        {
            this.ContactName = name;
            this.ContactSurname = surname;  
            this.PhoneNumber = number;
        }

        public Contact()
        {
            Console.WriteLine("Lütfen kaydetmek istediğiniz kişinin bilgilerini giriniz.");
            Console.WriteLine("İsim: ");
            string name = CaseCorrection(Console.ReadLine());
            Console.WriteLine("Soyisim: ");
            string surname = CaseCorrection(Console.ReadLine());
            Console.WriteLine("Telefon numarası: ");
            string number = CaseCorrection(Console.ReadLine());

            Console.WriteLine(name + " " + surname + " adlı kişi rehbere kaydedilmiştir.");

            this.ContactName = name;
            this.ContactSurname = surname;
            this.PhoneNumber = number;
        }

        public static string CaseCorrection(string inputStr)
        {
            inputStr = inputStr[0].ToString().ToUpper() + inputStr.Substring(1).ToLower();
            return inputStr;
        }
    }
}
