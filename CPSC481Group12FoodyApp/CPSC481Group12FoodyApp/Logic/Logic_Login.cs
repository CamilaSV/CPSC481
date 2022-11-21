using System;
using System.IO;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_Login
    {
        /* TEMP */
        private static string currentUserEmail;
        public static string getCurrentUserEmail()
        {
            if (String.IsNullOrEmpty(currentUserEmail))
                return "is null or empty";
            else
                return currentUserEmail;
        }

        // check if the user-entered information validates logging in (Matching email and password)
        public static string login(string email, string password)
        {
            /* TEMP */
            currentUserEmail = email;

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

        public static string[] loadUserData(string email)
        {
            string[] wholeData;

            return null;
        }
    }
}
