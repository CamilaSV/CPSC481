using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_Home
    {
        public static void removeUserEvent(string email, int groupId, int eventId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.removeUserEvent(email, groupId, eventId);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void saveUserRestaurant(string email, int catId, int resId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.addUserRestaurant(email, catId, resId);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
            SessionData.startTimer();
        }

        public static void addUserCategory(string catName)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            int catId = SessionData.getFirstAvailableCategoryId(SessionData.getCurrentUser());
            SessionData.addUserCategory(SessionData.getCurrentUser(), catId, catName);
            SessionData.saveUserInfoToDB();
            PageNavigator.goBack();
            SessionData.startTimer();
        }

        public static void delUserRestaurant()
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.removeUserRestaurant(SessionData.getCurrentUser(), SessionData.getCurrentCatId(), SessionData.getCurrentResId());
            SessionData.saveUserInfoToDB();
            PageNavigator.goBack();
            SessionData.startTimer();
        }

        public static void editUserRestaurantNotes(string content)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.editUserResNotes(SessionData.getCurrentUser(), SessionData.getCurrentCatId(), SessionData.getCurrentResId(), content);
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }

        public static List<int> getUserAllRestaurantsNotSaved()
        {
            return SessionData.getUserAllRestaurantsNotSaved(SessionData.getCurrentUser());
        }

        public static string getUserRestaurantNotes()
        {
            return SessionData.getUserResNotes(SessionData.getCurrentUser(), SessionData.getCurrentCatId(), SessionData.getCurrentResId());
        }

        public static void removeUserEvent(string email, string groupId, string eventId)
        {
            removeUserEvent(email, Int32.Parse(groupId), Int32.Parse(eventId));
        }
    }
}
