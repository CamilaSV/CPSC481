using System;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_Login
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
                    StreamReader userFile = File.OpenText(PathFinder.getAccEmail(email));
                    userFile.Close();

                    userFile = File.OpenText(PathFinder.getAccPw(email));

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
