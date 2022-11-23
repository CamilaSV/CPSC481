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
                        SharedFunctions.getFirstLineFromFile(PathFinder.getAccEmail(email)); // try reading email to see if it raises an exception
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
            SharedFunctions.appendLineToFile(PathFinder.getAccEmail(email), email);
            SharedFunctions.appendLineToFile(PathFinder.getAccPw(email), password);

            File.Create(PathFinder.getAccName(email)).Close();
            File.Create(PathFinder.getAccBio(email)).Close();
            File.Create(PathFinder.getAccChatInv(email)).Close();
            File.Create(PathFinder.getAccFriendReq(email)).Close();
            File.Create(PathFinder.getAccFriends(email)).Close();
            File.Create(PathFinder.getAccChats(email)).Close();

            Directory.CreateDirectory(PathFinder.getAccCatDir(email));
            Directory.CreateDirectory(PathFinder.getAccFutSchDir(email));
            Directory.CreateDirectory(PathFinder.getAccCompSchDir(email));

            return "true";
        }
    }
}
