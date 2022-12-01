// helps the app navigate the page

using CPSC481Group12FoodyApp.Logic;
using System.Windows.Controls;

namespace CPSC481Group12FoodyApp
{
    public static class PageNavigator
    {
        private static Window_Single targetWindow;

        private static UserControl_Start startPage = new UserControl_Start();
        private static UserControl_Login loginPage = new UserControl_Login();
        private static UserControl_Register registerPage = new UserControl_Register();
        private static UserControl_ChatList chatListPage = new UserControl_ChatList();
        private static UserControl_CreateNewChat createChatPage = new UserControl_CreateNewChat();

        private static UserControl_Profile profilePage = new UserControl_Profile();
        private static UserControl_Invitations invitationsPage = new UserControl_Invitations();
        private static UserControl_AddFriends addFriendPage = new UserControl_AddFriends();

        private static ChatScreen chatScreenPage = new ChatScreen();
        private static ChatInfoScreen chatInfoPage = new ChatInfoScreen();
        private static ChatEditMembers groupMemberEditPage = new ChatEditMembers();
        private static ChatEditMembersRemoveNew removeConfirmPage = new ChatEditMembersRemoveNew();

        private static HomePage homePage = new HomePage();

        public static void initializeProgram(Window_Single target)
        {
            targetWindow = target;
            targetWindow.Content = startPage;
        }

        public static void gotoStart()
        {
            targetWindow.Content = startPage;
        }

        public static void gotoLogin()
        {
            targetWindow.Content = loginPage;
        }

        public static void gotoRegister()
        {
            targetWindow.Content = registerPage;
        }

        public static void gotoProfile()
        {
            targetWindow.Content = profilePage;
        }

        public static void gotoAddFriend()
        {
            targetWindow.Content = addFriendPage;
        }

        // below 3 are bottom navigator options
        public static void gotoCalendar()
        {

        }

        public static void gotoHomePage()
        {
            targetWindow.Content = homePage;
        }

        public static void gotoChatList()
        {
            targetWindow.Content = chatListPage;
        }

        public static void gotoCreateGroup()
        {
            targetWindow.Content = createChatPage;
        }

        public static void gotoOneChat()
        {            
            chatScreenPage.GroupNameBlock.Text = SessionData.getGroupName(SessionData.getCurrentGroupId());
            targetWindow.Content = chatScreenPage;
        }

        public static void gotoChatMember()
        {

        }

        public static void gotoChatInfo()
        {
            targetWindow.Content = chatInfoPage;
        }

        public static void gotoGroupCalendar()
        {

        }

        public static void gotoInvitation()
        {
            targetWindow.Content = invitationsPage;
        }

        public static void gotoGroupEditMembers()
        {
            targetWindow.Content = groupMemberEditPage;
        }

        public static void gotoMemberDeleteConfirm(string email)
        {
            removeConfirmPage.setRemoveEmail(email);
            targetWindow.Content = removeConfirmPage;
        }
    }
}
