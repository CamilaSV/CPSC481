using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_EditProfile
    {
        public static void editUserDisplayName(string email, string newName)
        {
            SessionData.setUserDisplayName(email, newName);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void editUserBio(string email, string newBio)
        {
            SessionData.setUserBio(email, newBio);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void removeUserEvent(string email, int groupId, int eventId)
        {
            SessionData.removeUserEvent(email, groupId, eventId);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void saveUserRestaurant(string email, int restaurantId)
        {
            // To do: add catId selection to PersonalCalendar page
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addUserCategory(string catName)
        {
            int catId = SessionData.getFirstAvailableCategoryId(SessionData.getCurrentUser());
            SessionData.addUserCategory(SessionData.getCurrentUser(), catId, catName);
            SessionData.saveUserInfoToDB();
            PageNavigator.gotoHomePage();
        }

        public static void removeUserEvent(string email, string groupId, string eventId)
        {
            removeUserEvent(email, Int32.Parse(groupId), Int32.Parse(eventId));
        }
    }
}
