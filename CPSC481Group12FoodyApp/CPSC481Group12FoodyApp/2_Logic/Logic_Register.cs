using System;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Register
    {
        // check if the user-entered information validates register (No duplicate emails)
        public static void register(UserControl_Register registerWindow)
        {
            string email = registerWindow.EmailTextBox.Text;
            string password = registerWindow.PasswordBox.Password;

            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                if (String.IsNullOrWhiteSpace(password))
                {
                    registerWindow.ErrorTextBlock.Text = "The password must not be empty.";
                }
                else if (SessionData.getUserExist(email))
                {

                    registerWindow.ErrorTextBlock.Text = "The account already exists.";
                }
                else
                {
                    SessionData.createUser(email, password);
                    SessionData.saveUserInfoToDB();
                    SessionData.loginUser(email);
                    PageNavigator.gotoChatList();
                }
            }
            else
            {
                registerWindow.ErrorTextBlock.Text = "An invalid email address was given.";
            }
            SessionData.startTimer();
        }
    }
}
