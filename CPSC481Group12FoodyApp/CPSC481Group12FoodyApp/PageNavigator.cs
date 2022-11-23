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
        private UserControl_ChatList chatListPage;
        private UserControl_Profile profilePage;
        private UserControl_Invitations invitationsPage;
        private UserControl_AddFriends addFriendPage;

        public PageNavigator(Window_Single target)
        {
            targetWindow = target;
            
            startPage = new UserControl_Start(this);
            loginPage = new UserControl_Login(this);
            registerPage = new UserControl_Register(this);
            chatListPage = new UserControl_ChatList(this);
            profilePage = new UserControl_Profile(this);    
            invitationsPage = new UserControl_Invitations(this);
            addFriendPage = new UserControl_AddFriends(this, profilePage);
            targetWindow.Content = startPage;
            
        }

        public void gotoStart()
        {
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

        public void gotoProfile()
        {
            targetWindow.Content = profilePage;
        }

        public void gotoAddFriend()
        {
            targetWindow.Content = addFriendPage;
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
            targetWindow.Content = chatListPage;
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
            targetWindow.Content = invitationsPage;
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

        // temp
        public void acceptInvitation()
        {

        }
        // temp
        public void declineInvitation()
        {

        }

        //temp 

        public void editProfile()
        {

        }


    }
}
