using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_Register
    {
        // check if the user-entered information validates register (No duplicate emails)
        public static string register(String email, String password)
        {
            string result;

            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                try
                {
                    StreamReader userFile = File.OpenText(".\\DB\\Accounts\\" + email + ".cfg");
                    userFile.Close();

                    result = "The account already exists.";
                }
                catch (FileNotFoundException fnfe)
                {
                    result = createUser(email, password);
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    Directory.CreateDirectory(".\\DB\\Accounts");
                    result = createUser(email, password);
                }
            }
            else
            {
                result = "An invalid email address was given.";
            }

            return result;
        }
        private static string createUser(string email, string password)
        { 
            // the account does not exist, so register the account

            // make sure the password is not empty and is not just whitespace
            if (String.IsNullOrWhiteSpace(password))
            {
                return "Password is empty.";
            }


            StreamWriter fileWriter = File.AppendText(".\\DB\\Accounts\\" + email + ".cfg");

            fileWriter.WriteLine("Email:");
            fileWriter.WriteLine(email);
            fileWriter.WriteLine("Password:");
            fileWriter.WriteLine(password);
            fileWriter.WriteLine("Display_Name:");
            fileWriter.WriteLine(email);
            fileWriter.WriteLine("Bio:");
            fileWriter.WriteLine("Friends:");
            fileWriter.WriteLine("Chats:");
            fileWriter.WriteLine("Saved_Categories:");
            fileWriter.WriteLine("Saved_Restaurants:");
            fileWriter.WriteLine("Future_Schedules:");
            fileWriter.WriteLine("Completed_Schedules:");

            fileWriter.Close();

            return "true";
        }
    }
}
