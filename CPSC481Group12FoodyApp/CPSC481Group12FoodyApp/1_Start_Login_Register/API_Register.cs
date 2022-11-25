using System;
using System.IO;
using System.Net.Mail;

using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class API_Register
    {
        public static void register(UserControl_Register registerWindow)
        {
            string result = Logic_Register.register(registerWindow.Register_EmailTextBox.Text, registerWindow.Register_PasswordBox.Password);

            if (result.Equals("true"))
            {
                SessionData.initializeUser(registerWindow.Register_EmailTextBox.Text);
                PageNavigator.gotoChatList();
            }
            else
            {
                registerWindow.ErrorTextBlock.Text = result;
            }
        }
    }
}
