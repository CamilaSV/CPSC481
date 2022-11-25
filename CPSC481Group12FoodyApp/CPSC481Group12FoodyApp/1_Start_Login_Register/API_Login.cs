using System;
using System.IO;
using System.Net.Mail;

using CPSC481Group12FoodyApp.Logic;

namespace CPSC481Group12FoodyApp
{
    public static class API_Login
    {
        public static void login(UserControl_Login loginWindow)
        {
            string result = Login_Login.login(loginWindow.Login_EmailTextBox.Text, loginWindow.Login_PasswordBox.Password);

            if (result.Equals("true"))
            {
                SessionData.initializeUser(loginWindow.Login_EmailTextBox.Text);
                loginWindow.navigate_helper.gotoChatList();
            }
            else
            {
                loginWindow.ErrorTextBlock.Text = result;
            }
        }
    }
}
