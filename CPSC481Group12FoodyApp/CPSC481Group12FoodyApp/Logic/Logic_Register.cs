using System;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_Register
    {
        // check if the user-entered information validates register (No duplicate emails)
        public static string register(string email, string password)
        {
            string result;

            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(password))
                    {
                        result = "The password must not be empty.";
                    }
                    else
                    {
                        StreamReader userFile = File.OpenText(PathFinder.getAccEmail(email));
                        userFile.Close();

                        result = "The account already exists.";
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    result = createUser(email, password);
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    Directory.CreateDirectory(PathFinder.getAccDir(email));
                    result = createUser(email, password);
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

        private static string createUser(string email, string password)
        { 
            // the account does not exist, so register the account
            StreamWriter fileWriter = File.CreateText(PathFinder.getAccEmail(email));
            fileWriter.WriteLine(email);
            fileWriter.Close();

            fileWriter = File.CreateText(PathFinder.getAccPw(email));
            fileWriter.WriteLine(password);
            fileWriter.Close();

            File.Create(PathFinder.getAccName(email)).Close();
            File.Create(PathFinder.getAccBio(email)).Close();
            File.Create(PathFinder.getAccInv(email)).Close();
            File.Create(PathFinder.getAccFriends(email)).Close();
            File.Create(PathFinder.getAccChats(email)).Close();
            File.Create(PathFinder.getAccCategories(email)).Close();
            File.Create(PathFinder.getAccRestaurants(email)).Close();

            Directory.CreateDirectory(PathFinder.getAccFutSchDir(email));
            Directory.CreateDirectory(PathFinder.getAccCompSchDir(email));

            return "true";
        }
    }
}
