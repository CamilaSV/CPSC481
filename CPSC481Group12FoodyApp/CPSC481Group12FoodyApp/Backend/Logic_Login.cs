using System;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Login_Login
    {
        // check if the user-entered information validates logging in (Matching email and password)
        public static string login(string email, string password)
        {
            string result;

            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                try
                {
                    SharedFunctions.getFirstLineFromFile(PathFinder.getAccEmail(email)); // try reading email to see if it raises an exception
                    if (!SharedFunctions.getFirstLineFromFile(PathFinder.getAccPw(email)).Equals(password))
                    {
                        result = "Username and password combination does not match.";
                    }
                    else
                    {
                        result = "true";
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    result = "User does not exist.";
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    result = "User does not exist.";
                }
                catch (Exception e)
                {
                    result = "Something is wrong. Please contact support.";
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
