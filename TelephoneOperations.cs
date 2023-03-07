using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phone_Book
{
    class TelephoneOperations
    {
        const string path = @"TelephoneBook.txt";
        public string Name { get; set; }
        public string Telephone { get; set; }
        public TelephoneOperations(string name, string phone)
        {
            Name = name;
            Telephone = phone;
        }
        public TelephoneOperations() { }
        /// <summary>
        /// Method 'Add new contact'
        /// </summary>
        public void AddNewContact()
        {
            /// <summary>
            /// Adding a new contact to a file
            /// </summary>
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine($"{Name}              --               +380{Telephone}");
            sw.Close();
            Console.WriteLine("The contact was successfully added");
        }
        /// <summary>
        /// Method 'Delete contacts'
        /// </summary>
        public void DeleteContact()
        {
            string phoneDel = Console.ReadLine();
            /// <summary>
            /// Selecting all lines from a file
            /// </summary>
            string[] readText = File.ReadAllLines(path);
            List<string> listFile = readText.ToList();
            StreamWriter sw = new StreamWriter(path);
            /// <summary>
            /// Checking for correct entry and deleting a number
            /// </summary>
            for (int i = 0; i < listFile.Count; i++)
            {
                if(phoneDel.Length == 9)
                {
                    if (listFile[i].Contains(phoneDel))
                    {
                        listFile.Remove(listFile[i]);
                        Console.WriteLine("The contact was successfully removed");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong number entered");
                    break;
                }
            }
            /// <summary>
            /// Write new data to file
            /// </summary>
            foreach (string line in listFile)
                sw.WriteLine(line);
            sw.Close();
            
        }
        /// <summary>
        /// Method 'Check all contacts'
        /// </summary>
        public void CheckAllContacts()
        {
            try
            {
                /// <summary>
                /// Output all contacts to the console
                /// </summary>
                StreamReader streamReader = new StreamReader(path);
                Console.WriteLine(streamReader.ReadToEnd());
                streamReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your telephone list is empty");
            }
        }
    }
}
