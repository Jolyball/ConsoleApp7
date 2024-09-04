using System;
using System.Collections.Generic;
using System.IO;

public class FilesBehavior
{
    public static void StudentMain()
    {
        
        Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

        
        string[] phoneLines = File.ReadAllLines("phones.txt");
        foreach (string line in phoneLines)
        {
            
            string[] parts = line.Split(' ');
            string name = parts[0] + " " + parts[1];
            string phone = parts[2];

            PhoneBook[name] = phone;
        }

        using (StreamWriter writer = new StreamWriter("onlyPhones.txt"))
        {
            foreach (var entry in PhoneBook)
            {
                writer.WriteLine(entry.Value);
            }
        }
        string[] nameLines = File.ReadAllLines("names.txt");
        foreach (string name in nameLines)
        {
            if (PhoneBook.ContainsKey(name))
            {
                Console.WriteLine($"The phone number of {name} is: {PhoneBook[name]}");
            }
            else
            {
                Console.WriteLine($"Name {name} was not found in phone book.");
            }
        }

        using (StreamWriter newPhonesWriter = new StreamWriter("newPhones.txt"))
        {
            foreach (var entry in PhoneBook)
            {
                string updatedPhone = entry.Value;
                if (updatedPhone.StartsWith("80") && updatedPhone.Length == 11)
                {
                    updatedPhone = "+3" + updatedPhone;
                }

                newPhonesWriter.WriteLine($"{entry.Key} {updatedPhone}");
            }
        }
    }

    public static void Main()
    {
        StudentMain();
        Console.ReadKey();  
    }
}
