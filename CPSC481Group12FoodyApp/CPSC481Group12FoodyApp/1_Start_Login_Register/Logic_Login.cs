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
                if (!SessionData.getUserExist(email)) 
                {
                    loginWindow.ErrorTextBlock.Text = "User does not exist.";
                }
                else if (!SessionData.getUserPassword(email).Equals(password))
                {
                    loginWindow.ErrorTextBlock.Text = "Username and password combination does not match.";
                }
                else 
                {
                    SessionData.loginUser(email);
                    ComponentFunctions.refreshAll();
                    PageNavigator.gotoChatList();
                }
            }
            else
            {
                loginWindow.ErrorTextBlock.Text = "An invalid email address was given.";
            }
        }
    }
}
