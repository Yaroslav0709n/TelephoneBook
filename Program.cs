using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Phone_Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Application start
            /// </summary>
            Console.WriteLine("Telephone Book");
            while (true)
            {
                Options();
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the name");
                    /// <summary>
                    /// Entering a name and checking for correct input
                    /// </summary>
                    string name = Console.ReadLine();
                    while (true)
                    {
                        if (name.Length >= 20)
                        {
                            Console.WriteLine("Enter the name again. Not more 10 letters");
                            name = Console.ReadLine();
                        }
                        else
                            break;
                    }
                    if (name.Length <= 20)
                    {
                        int count = 20 - name.Length;
                        name += new string(' ', count);
                    }
                    else if (name.Length >= 16)
                    {
                        int count = name.Length - 16;
                        name += new string(' ', 16 - count);
                    }
                    /// <summary>
                    /// Entering the phone number and checking for correct input
                    /// </summary>
                    Console.WriteLine("Enter your phone number");
                    Console.Write("+380");
                    string phone = Console.ReadLine();
                    while (true)
                    {
                        if (phone.Any(c => char.IsLetter(c)))
                        {
                            Console.WriteLine("The phone number can't  contain a letters");
                            Console.Write("+380");
                            phone = Console.ReadLine();
                        }
                        else if (phone.Length != 9)
                        {
                            Console.WriteLine("Enter the phone number again (only 10 digits)");
                            Console.Write("+380");
                            phone = Console.ReadLine();
                        }
                        else
                            break;
                    }
                    /// <summary>
                    /// Calling the 'Add new contact' method
                    /// </summary>
                    new TelephoneOperations(name, phone).AddNewContact();
                }
                else if (choice == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the phone number, which you want to delete");
                    Console.Write("+380");
                    /// <summary>
                    /// Calling the 'Delete contact' method
                    /// </summary>
                    new TelephoneOperations().DeleteContact();
                }
                else if (choice == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("This is your list of contacts");
                    /// <summary>
                    /// Calling the 'Check all contacts' method
                    /// </summary>
                    new TelephoneOperations().CheckAllContacts();
                }
                else if (choice == 4)
                    break;
            }
        }
        static void Options()
        {
            Console.WriteLine(@"
1. Add new Telephone Number
2. Delete a Telephone Number
3. Check the lists of numbers
4. Close the Telephone Book");
        }
    }
}
