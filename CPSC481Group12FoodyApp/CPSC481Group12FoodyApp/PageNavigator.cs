// helps the app navigate the page

using System.Windows.Controls;

namespace CPSC481Group12FoodyApp
{
    public class PageNavigator
    {
        private Window_Single targetWindow;
        private UserControl_Start startPage;
        private UserControl_Login loginPage;
        private UserControl_Register registerPage;


        public PageNavigator(Window_Single target)
        {
            targetWindow = target;

            startPage = new UserControl_Start(this);
            loginPage = new UserControl_Login(this);
            registerPage = new UserControl_Register(this);

            targetWindow.Content = startPage;
        }

        public void gotoLogin()
        {
            targetWindow.Content = loginPage;
        }

        public void gotoRegister()
        {
            targetWindow.Content = registerPage;
        }

        public void gotoStart()
        {
            targetWindow.Content = startPage;
        }
    }
}
