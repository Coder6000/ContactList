namespace ContactList
{
    public class ContactApp
    {
        string input;
        public void Run()
        {
            
            string ContactDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Contacts\";
            Directory.CreateDirectory(ContactDir);

            while(input != "exit")
            {

                Console.WriteLine("(add) add a contact");
                Console.WriteLine("(show) show contact list");
                Console.WriteLine("(exit) exit app");
                Console.WriteLine("(remove) removes a contact");
                Console.WriteLine("(removeall) clears the list");
                input = Console.ReadLine();

                switch (input)
                {
                    case "add":
                        Console.Clear();
                        AddContact();
                        break;

                    case "show":
                        Console.Clear();
                        ShowAllContacts();
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "removeall":
                        RemoveAllContacts();
                        break;
                }

                void AddContact()
                {
                    Console.Write("Name: \n");
                    string name = Console.ReadLine();

                    Console.Write("Address: \n");
                    string address = Console.ReadLine();

                    Console.Write("Phone Number: \n");
                    string phoneNumber = Console.ReadLine();

                    List<string> contactInformation = new List<string>();

                    contactInformation.Add($"Name: {name}");
                    contactInformation.Add($"Nummer: {phoneNumber}");
                    contactInformation.Add($"Adresse: {address} \n---------------------------------");

                    try
                    {
                        using (var streamWriter = File.AppendText(ContactDir + "contacts.txt"))
                        {
                            streamWriter.WriteLine(contactInformation[0]);
                            streamWriter.WriteLine(contactInformation[1]);
                            streamWriter.WriteLine(contactInformation[2]);
                            streamWriter.Dispose();
                            streamWriter.Close();
                        }
                        Console.WriteLine($"{name} has been added to your list!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                void ShowAllContacts()
                {
                    try
                    {
                        List<string> contactInformation = File.ReadAllLines(ContactDir + "contacts.txt").ToList();

                        foreach (var contact in contactInformation)
                        {
                            Console.WriteLine(contact);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            void RemoveContact()
            {
                
            }

            void RemoveAllContacts()
            {
                using (var streamWriter = File.CreateText(ContactDir + "contacts.txt"))
                {
                    streamWriter.WriteLine("");
                }
            }
        }
    }
}