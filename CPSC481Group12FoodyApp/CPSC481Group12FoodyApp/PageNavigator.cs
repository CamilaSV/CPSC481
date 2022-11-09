// helps the app navigate the page

using System.Windows.Controls;

namespace CPSC481Group12FoodyApp
{
    public class PageNavigator
    {
        private Window_Single targetWindow;
        /*
        private UserControl_Start startPage;
        private UserControl_Login loginPage;
        private UserControl_Register registerPage;
        private UserControl_ChatList chatListPage;
        */

        public PageNavigator(Window_Single target)
        {
            targetWindow = target;
            /*
            startPage = new UserControl_Start(this);
            loginPage = new UserControl_Login(this);
            registerPage = new UserControl_Register(this);
            chatListPage = new UserControl_ChatList(this);
            targetWindow.Content = startPage;
            */
        }

        public void gotoStart()
        {
            //targetWindow.Content = startPage;
        }

        public void gotoLogin()
        {
            //targetWindow.Content = loginPage;
        }

        public void gotoRegister()
        {
            //targetWindow.Content = registerPage;
        }

        public void gotoProfile()
        {

        }

        // below 3 are bottom navigator options
        public void gotoCalendar()
        {

        }

        public void gotoHomePage()
        {

        }

        public void gotoChatList()
        {
            //targetWindow.Content = chatListPage;
        }

        public void gotoAddFriend()
        {

        }

        public void gotoCreateGroup()
        {

        }

        public void gotoOneChat()
        {

        }

        public void gotoChatMember()
        {

        }

        public void gotoChatInfo()
        {

        }

        public void gotoGroupCalendar()
        {

        }

        public void gotoInvitation()
        {

        }

        public void gotoOneChat(int version)
        {
            // temporary version that should be deleted
        }

        public void gotoChatInfo(int version)
        {
            // temporary version that should be deleted
        }

        public void gotoChatMember(int version)
        {
            // temporary version that should be deleted
        }
    }
}
