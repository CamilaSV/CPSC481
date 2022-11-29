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
            string email = registerWindow.Register_EmailTextBox.Text;
            string password = registerWindow.Register_PasswordBox.Password;
            string result = "true";

            // Source: https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress.trycreate
            if (MailAddress.TryCreate(email, out _))
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(password))
                    {
                        registerWindow.ErrorTextBlock.Text = "The password must not be empty.";
                    }
                    else if (SessionData.getUserExist(email))
                    {

                        registerWindow.ErrorTextBlock.Text = "The account already exists.";
                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    SessionData.createUser(email, password);
                    SessionData.loginUser(email);
                    PageNavigator.gotoChatList();
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    SessionData.createUser(email, password);
                    SessionData.loginUser(email);
                    PageNavigator.gotoChatList();
                }
                catch (Exception e)
                {
                    registerWindow.ErrorTextBlock.Text = "Something is wrong. Please contact support.";
                }
            }
            else
            {
                registerWindow.ErrorTextBlock.Text = "An invalid email address was given.";
            }
        }
    }
}
