using System;
using System.Collections.Generic;
using System.IO;

namespace IDovhyiHomework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   In Main() method declare Dictionary PhoneBook for keeping pairs PersonName - PhoneNumber.
            Dictionary<string, string> phoneBook = new Dictionary<string, string>(); // key - PhoneNumber, value PersonName
            // 1) From file "phones.txt" read 9 pairs into PhoneBook.Write only PhoneNumbers into file "Phones.txt".
            string readPath = @"C:\Ihor\Study\SoftServe\Homework\IDovhyiHomework7\Phones.txt";
            using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
            {
                string line;
                string linePhoneNumber = "";
                bool saveNumer = false;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!saveNumer)
                    {
                        saveNumer = true;
                        linePhoneNumber = line;
                    }
                    else
                    {
                        phoneBook.Add(linePhoneNumber, line);
                        saveNumer = false;
                    }
                }
            }
            // 2) Find and print phone number by the given name(name input from console)
            Console.Write("Input name: ");
            string name = Console.ReadLine();
            foreach (string phone in phoneBook.Keys)
            {
                if (phoneBook[phone] == name) Console.WriteLine("Name: " + name + " Phone: " + phone);
            }
            // 3) Change all phone numbers, which are in format 80######### into new format +380#########. The result write into file "New.txt«
            var newPhoneBook = new Dictionary<string, string>(); // key - PhoneNumber, value PersonName
            foreach (string phone in phoneBook.Keys)
            {
                if (phone.IndexOf("80") == 0)
                {
                   string newPhone = "+380" + phone.Remove(0, 2);
                   newPhoneBook.Add(newPhone, phoneBook[phone]);
                } else newPhoneBook.Add(phone, phoneBook[phone]);
            }
            string writePath = @"C:\Ihor\Study\SoftServe\Homework\IDovhyiHomework7\New.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (string phone in newPhoneBook.Keys)
                {
                    sw.WriteLine(phone);
                    sw.WriteLine(newPhoneBook[phone]);
                }
            }
        }
    }
}
