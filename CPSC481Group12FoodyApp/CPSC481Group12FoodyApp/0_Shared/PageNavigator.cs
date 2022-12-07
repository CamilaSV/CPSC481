// helps the app navigate the page

using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Windows.Controls;

namespace CPSC481Group12FoodyApp
{
    public static class PageNavigator
    {
        private static Window_Single targetWindow;

        // start page & related navigation
        private static UserControl_Start startPage;

        private static UserControl_Login loginPage;
        private static UserControl_Register registerPage;

        // chat list & related navigation
        private static UserControl_ChatList chatListPage;

        private static UserControl_CreateNewChat createChatPage;
        private static UserControl_Invitations invitationsPage;

        private static ChatScreen chatScreenPage;

        private static ChatInfoScreen chatInfoPage;

        private static ChatEditMembers groupMemberEditPage;

        private static ChatScheduler groupSchedulerPage;

        private static ChatAddCustomTime groupCustomTimePage;

        private static CreateEventScreen groupEventCreatePage;

        private static ChatEditRestaurant groupRestaurantEditPage;

        private static ChatEditCriteria groupCriteriaEditPage;

        private static SuggestRestaurant groupResSuggestPage;

        // user home page & related navigation
        private static HomePage homePage;
        private static UserControl_AddCategory addCategoryPage;
        private static AddUserRestaurant addUserRestaurantPage;

        private static ExpandCategory expandCategoryPage;

        private static ExpandRestaurant expandRestaurantPage;

        // user schedule & related navigation
        private static PersonalCalendar personalCalendarPage;

        // user profile & related navigation
        private static UserControl_Profile profilePage;

        private static UserControl_AddFriends addFriendPage;

        public static void goBack()
        {
            if ((targetWindow.Content == loginPage) ||
                (targetWindow.Content == registerPage))
            {
                gotoStart();
            }
            else if ((targetWindow.Content == createChatPage) ||
                (targetWindow.Content == invitationsPage) ||
                (targetWindow.Content == chatScreenPage))
            {
                gotoChatList();
            }
            else if (targetWindow.Content == chatInfoPage)
            {
                gotoOneChat();
            }
            else if ((targetWindow.Content == groupMemberEditPage) ||
                (targetWindow.Content == groupSchedulerPage) ||
                (targetWindow.Content == groupEventCreatePage) ||
                (targetWindow.Content == groupCustomTimePage) ||
                (targetWindow.Content == groupRestaurantEditPage) ||
                (targetWindow.Content == groupCriteriaEditPage))
            {
                gotoChatInfo();
            }
            else if ((targetWindow.Content == expandCategoryPage) ||
                (targetWindow.Content == addCategoryPage))
            {
                gotoHomePage();
            }
            else if ((targetWindow.Content == addUserRestaurantPage) ||
                (targetWindow.Content == expandRestaurantPage))
            {
                gotoExpandCategory();
            }
            else if (targetWindow.Content == addFriendPage)
            {
                gotoProfile();
            }
            else if (targetWindow.Content == groupResSuggestPage)
            {
                gotoGroupEditRestaurants();
            }
        }

        public static void initializeProgram(Window_Single target)
        {
            targetWindow = target;
            startPage = new UserControl_Start();
            ComponentFunctions.refreshAll();
            targetWindow.Content = startPage;
        }

        public static void gotoStart()
        {
            startPage = new UserControl_Start();
            ComponentFunctions.refreshAll();
            targetWindow.Content = startPage;
        }

        public static void gotoLogin()
        {
            loginPage = new UserControl_Login();
            ComponentFunctions.refreshAll();
            targetWindow.Content = loginPage;
        }

        public static void gotoRegister()
        {
            registerPage = new UserControl_Register();
            ComponentFunctions.refreshAll();
            targetWindow.Content = registerPage;
        }

        public static void gotoChatList()
        {
            chatListPage = new UserControl_ChatList();
            ComponentFunctions.refreshAll();
            targetWindow.Content = chatListPage;
        }

        public static void gotoCreateGroup()
        {
            createChatPage = new UserControl_CreateNewChat();
            ComponentFunctions.refreshAll();
            targetWindow.Content = createChatPage;
        }

        public static void gotoInvitation()
        {
            invitationsPage = new UserControl_Invitations();
            ComponentFunctions.refreshAll();
            targetWindow.Content = invitationsPage;
        }

        public static void gotoOneChat()
        {
            chatScreenPage = new ChatScreen();
            ComponentFunctions.refreshAll();
            targetWindow.Content = chatScreenPage;
        }

        public static void gotoChatInfo()
        {
            chatInfoPage = new ChatInfoScreen();
            ComponentFunctions.refreshAll();
            targetWindow.Content = chatInfoPage;
        }

        public static void gotoGroupEditMembers()
        {
            groupMemberEditPage = new ChatEditMembers();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupMemberEditPage;
        }

        public static void gotoMemberDeleteConfirm(string email)
        {
            groupMemberEditPage.loadRemove(email);
        }

        public static void gotoGroupCalendar()
        {
            groupSchedulerPage = new ChatScheduler();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupSchedulerPage;
        }

        public static void gotoCustomEventTime()
        {
            groupCustomTimePage = new ChatAddCustomTime();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupCustomTimePage;
        }

        public static void gotoCreateGroupEvent()
        {
            groupEventCreatePage = new CreateEventScreen();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupEventCreatePage;
        }

        public static void gotoGroupEditRestaurants()
        {
            groupRestaurantEditPage = new ChatEditRestaurant();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupRestaurantEditPage;
        }

        public static void gotoGroupEditCriteria()
        {
            groupCriteriaEditPage = new ChatEditCriteria();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupCriteriaEditPage;
        }

        public static void gotoSuggestRestaurant()
        {
            groupResSuggestPage = new SuggestRestaurant();
            ComponentFunctions.refreshAll();
            targetWindow.Content = groupResSuggestPage;
        }

        public static void gotoHomePage()
        {
            homePage = new HomePage();
            ComponentFunctions.refreshAll();
            targetWindow.Content = homePage;
        }

        public static void gotoAddCategory()
        {
            addCategoryPage = new UserControl_AddCategory();
            ComponentFunctions.refreshAll();
            targetWindow.Content = addCategoryPage;
        }

        public static void gotoExpandCategory()
        {
            expandCategoryPage = new ExpandCategory();
            ComponentFunctions.refreshAll();
            targetWindow.Content = expandCategoryPage;
        }

        public static void gotoExpandRestaurant()
        {
            expandRestaurantPage = new ExpandRestaurant();
            ComponentFunctions.refreshAll();
            targetWindow.Content = expandRestaurantPage;
        }

        public static void gotoCalendar()
        {
            personalCalendarPage = new PersonalCalendar();
            ComponentFunctions.refreshAll();
            targetWindow.Content = personalCalendarPage;
        }

        public static void gotoGroupResturantDeleteConfirm(int restaurantId)
        {
            groupRestaurantEditPage.loadRemove(restaurantId);
        }

        public static void gotoPersonalEventDeleteConfirm(int groupId, int eventId)
        {
            personalCalendarPage.loadRemove(groupId, eventId);
        }

        public static void gotoPersonalEventSaveConfirm(int restaurantId)
        {
            personalCalendarPage.loadSave(restaurantId);
        }

        public static void gotoProfile()
        {
            profilePage = new UserControl_Profile();
            ComponentFunctions.refreshAll();
            targetWindow.Content = profilePage;
        }

        public static void gotoAddFriend()
        {
            addFriendPage = new UserControl_AddFriends();
            ComponentFunctions.refreshAll();
            targetWindow.Content = addFriendPage;
        }

        public static void gotoUserAddRestaurant()
        {
            addUserRestaurantPage = new AddUserRestaurant();
            ComponentFunctions.refreshAll();
            targetWindow.Content = addUserRestaurantPage;
        }

        public static void gotoPersonalEventDeleteConfirm(string groupId, string eventId)
        {
            gotoPersonalEventDeleteConfirm(Int32.Parse(groupId), Int32.Parse(eventId));
        }

        public static void gotoPersonalEventSaveConfirm(string id)
        {
            gotoPersonalEventSaveConfirm(Int32.Parse(id));
        }

        public static void gotoGroupResturantDeleteConfirm(string restaurantId)
        {
            gotoGroupResturantDeleteConfirm(Int32.Parse(restaurantId));
        }

    }
}
