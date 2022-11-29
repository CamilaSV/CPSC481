using System;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Login
    {
        // check if the user-entered information validates logging in (Matching email and password)
        public static void login(UserControl_Login loginWindow)
        {
            string email = loginWindow.Login_EmailTextBox.Text;
            string password = loginWindow.Login_PasswordBox.Password;

            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                try
                {
                    if (!SessionData.getUserPassword(email).Equals(password))
                    {
                        loginWindow.ErrorTextBlock.Text = "Username and password combination does not match.";
                    }
                    else
                    {
                        SessionData.loginUser(email);
                        PageNavigator.gotoChatList();
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    loginWindow.ErrorTextBlock.Text = "User does not exist.";
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    loginWindow.ErrorTextBlock.Text = "User does not exist.";
                }
                catch (Exception e)
                {
                    loginWindow.ErrorTextBlock.Text = "Something is wrong. Please contact support.";
                }
            }
            else
            {
                loginWindow.ErrorTextBlock.Text = "An invalid email address was given.";
            }
        }
    }
}
