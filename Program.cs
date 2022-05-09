using System;


namespace Patika_C101_TelefonRehberi
{
    public class Program
    {
        static void Main(string[] args)
        {
            DefaultContacts();

            MenuOptions();
            Console.WriteLine();
        }
        public static void MainMenuSelection()
        {
            int selection = InputValidation();

            switch (selection)
            {
                case 1:
                    SaveContact();
                    break;
                case 2:
                    DeleteContact();
                    break;
                case 3:
                    UpdateContact();
                    break;
                case 4:
                    ListAllContacts();
                    break;
                case 5:
                    SearchForContact();
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }
        }

        public static void MenuOptions()
        {
            Console.WriteLine("*******Telefon Rehberi*******");
            Console.WriteLine();
            Console.WriteLine("1. Telefon numarası kaydet.");
            Console.WriteLine("2. Telefon numarası sil.");
            Console.WriteLine("3. Telefon numarası güncelle.");
            Console.WriteLine("4. Telefon rehberindeki numaraları listele.");
            Console.WriteLine("5. Rehberde ara.");
            MainMenuSelection();
        }

        public static void DefaultContacts()
        {
            ContactsList.contactsList.Add(new Contact("Aragorn", "Elessar", "111 11 11"));
            ContactsList.contactsList.Add(new Contact("Arwen", "Evenstar", "222 22 22"));
            ContactsList.contactsList.Add(new Contact("Frodo", "Baggins", "333 33 33"));
            ContactsList.contactsList.Add(new Contact("Boromir", "Rohannes", "444 44 44"));
            ContactsList.contactsList.Add(new Contact("Faramir", "Rohannes", "555 55 55"));
        }       

        static void SaveContact()
        {
            Console.WriteLine("Numara kaydet.");
            Contact contact = new Contact();
            ContactsList.contactsList.Add(contact);

            loadingMainMenu();
        }

        private static void DeleteContact()
        {
            string operationDef;
            Console.WriteLine("Lütfen rehberden silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string contacttoRemove = Contact.CaseCorrection(Console.ReadLine());

            if (ContactsList.contactsList.Exists(x => x.ContactName == contacttoRemove))
            {
                foreach (Contact contact in ContactsList.contactsList)
                {
                    if (contact.ContactName == contacttoRemove || contact.ContactSurname == contacttoRemove)
                    {
                        operationDef = contact.ContactName + " " + contact.ContactSurname + " adlı kişi rehberden silinecektir, onaylıyor musunuz?";

                        if (CancelOperation(operationDef) == 1)
                        {
                            ContactsList.contactsList.Remove(contact);
                            Console.WriteLine(contact.ContactName + " " + contact.ContactSurname + " adlı kişi rehberden silimiştir.");

                            loadingMainMenu();
                        }
                        else
                        {
                            loadingMainMenu();
                        }
                    }
                }
            }
            else
            {
                operationDef = "Rehberde bu isimde biri bulunamamıştır. Silme işlemine başka bir kişi ile devam etmek istiyor musunuz?";
                Console.WriteLine();
                if (CancelOperation(operationDef) == 1)
                {
                    DeleteContact();
                }
                else
                    MenuOptions();            
            }
        }

        private static void UpdateContact()
        {
            Console.WriteLine("Lütfen rehberde numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
            string operationDef;
            string contacttoUpdate = Contact.CaseCorrection(Console.ReadLine());

            if (ContactsList.contactsList.Exists(x => x.ContactName == contacttoUpdate))
            {
                foreach (Contact contact in ContactsList.contactsList)
                {
                    if (contact.ContactName == contacttoUpdate || contact.ContactSurname == contacttoUpdate)
                    {
                        Console.WriteLine(contact.ContactName + " " + contact.ContactSurname + "adlı kişinin yeni telefon numarasını giriniz: ");
                        string tempPhoneNumber = Console.ReadLine();


                        operationDef = contact.ContactName + " " + contact.ContactSurname + " adlı kişinin telefon numarası güncellenecektir, onaylıyor musunuz?";

                        if (CancelOperation(operationDef) == 1)
                        {
                            contact.PhoneNumber = tempPhoneNumber;
                            Console.WriteLine(contact.ContactName + " " + contact.ContactSurname + " adlı kişinin numarası {0} olarak güncellenmiştir.", contact.PhoneNumber);

                            loadingMainMenu();
                        }
                        else
                        {
                            loadingMainMenu();
                        }
                    }
                }
            }

            else
            {
                operationDef = "Rehberde bu isimde biri bulunamamıştır. Güncelleme işlemine başka bir kişi ile devam etmek istiyor musunuz?";
                Console.WriteLine();
                if (CancelOperation(operationDef) == 1)
                {
                    UpdateContact();
                }
                else
                    MenuOptions();
            }
        }

        private static void ListAllContacts()
        {
            Console.WriteLine("Telefon rehberi listeleniyor: ");
            foreach (Contact contact in ContactsList.contactsList)
            {
                PrintContacts(contact);
            }

            loadingMainMenu();
        }

        public static void SearchForContact()
        {
            Console.WriteLine("Arama yapmak istediğiniz kategoriyi seçiniz: ");
            Console.WriteLine("1. İsme veya soyisime göre arama yap.");
            Console.WriteLine("2. Telefon numarasına göre arama yap.");

            int selection = InputValidation();

            if (selection == 1)
            {
                Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin adını veya soyadını giriniz:");
                string contacttoSearch = Contact.CaseCorrection(Console.ReadLine());

                if (ContactsList.contactsList.Exists(x => x.ContactName == contacttoSearch))
                {
                    foreach (Contact contact in ContactsList.contactsList)
                    {
                        if (contact.ContactName == contacttoSearch || contact.ContactSurname == contacttoSearch)
                        {
                            PrintContacts(contact);
                            loadingMainMenu();
                            break;
                        }
                    }
                }

                else
                {
                    Console.WriteLine();
                    if (CancelOperation("Rehberde bu isimde biri bulunamamıştır. Güncelleme işlemine başka bir kişi ile devam etmek istiyor musunuz?") == 1)
                    {
                        SearchForContact();
                    }
                    else
                        MenuOptions();
                }
            }

            else if (selection == 2)
            {
                Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin telefon numarasını giriniz:");
                string contactNumToSearch = Console.ReadLine();

                foreach (Contact contact in ContactsList.contactsList)
                {
                    if (contact.PhoneNumber == contactNumToSearch)
                    {
                        PrintContacts(contact);
                        loadingMainMenu();
                    }
                }
            }
        }
              
        public static int CancelOperation(string operationName)
        {
            Console.WriteLine(operationName);
            Console.WriteLine("Evet için 1, Hayır için 2'yi tuşlayınız.");
            int selection = InputValidation();

            return selection;
        }

        public static void PrintContacts(Contact contact)
        {
            Console.WriteLine();
            Console.WriteLine("İsim: {0}", contact.ContactName);
            Console.WriteLine("Soyisim: {0}", contact.ContactSurname);
            Console.WriteLine("Telefon numarası: {0}", contact.PhoneNumber);
            Console.WriteLine("-");
        }

        public static void loadingMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("İşlem sonlanmıştır.");
            Console.WriteLine("Ana menuye aktarılıyorsunuz...");
            Console.WriteLine();
            MenuOptions();
        }

        public static int InputValidation()
        {
            string userInput = Console.ReadLine();
            try
            {
                int input = Convert.ToInt32(userInput);
                return input;
            }
            catch
            {
                Console.WriteLine("Lütfen geçerli bir giriş yapınız:");
                Console.WriteLine();
                return InputValidation();
            }
        }
        public static class ContactsList
        {
            public static List<Contact> contactsList = new List<Contact>();
        }
    }
}