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
                    StreamReader userFile = File.OpenText(".\\DB\\Accounts\\" + email + "\\email.cfg");
                    userFile.Close();

                    result = "The account already exists.";
                }
                catch (FileNotFoundException fnfe)
                {
                    result = createUser(email, password);
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    Directory.CreateDirectory(".\\DB\\Accounts\\" + email);
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


            StreamWriter fileWriter = File.CreateText(".\\DB\\Accounts\\" + email + "\\email.cfg");
            fileWriter.WriteLine(email);
            fileWriter.Close();

            fileWriter = File.CreateText(".\\DB\\Accounts\\" + email + "\\password.cfg");
            fileWriter.WriteLine(password);
            fileWriter.Close();

            File.Create(".\\DB\\Accounts\\" + email + "\\display_name.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\bio.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\friends.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\chats.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\saved_cat.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\saved_res.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\future_sch.cfg").Close();
            File.Create(".\\DB\\Accounts\\" + email + "\\comp_sch.cfg").Close();

            return "true";
        }
    }
}
