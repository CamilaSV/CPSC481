using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_Login
    {
        // check if the user-entered information validates logging in (Matching email and password)
        public static string login(String email, String password)
        {
            string result;

            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                try
                {
                    StreamReader userFile = File.OpenText(".\\DB\\" + email + ".cfg");

                    if (!userFile.ReadLine().Equals("Email:"))
                    {
                        result = "Please contact the customer support.";
                    }

                    if(!userFile.ReadLine().Equals(email))
                    {
                        result = "Please contact the customer support.";
                    }

                    if (!userFile.ReadLine().Equals("Password:"))
                    {
                        result = "Please contact the customer support.";
                    }

                    if (!userFile.ReadLine().Equals(password))
                    {
                        result = "Username and password combination does not match.";
                    }
                    else
                    {
                        result = "true";
                    }

                    userFile.Close();
                }
                catch (FileNotFoundException fnfe)
                {
                    result = "User does not exist.";
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    result = "User does not exist.";
                }
            }
            else
            {
                result = "An invalid email address was given.";
            }

            return result;
        }
    }
}
