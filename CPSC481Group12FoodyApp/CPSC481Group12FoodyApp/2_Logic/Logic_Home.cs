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
            SessionData.removeUserEvent(email, groupId, eventId);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void saveUserRestaurant(string email, int catId, int resId)
        {
            SessionData.addUserRestaurant(email, catId, resId);
            SessionData.saveUserInfoToDB();
            ComponentFunctions.refreshAll();
        }

        public static void addUserCategory(string catName)
        {
            int catId = SessionData.getFirstAvailableCategoryId(SessionData.getCurrentUser());
            SessionData.addUserCategory(SessionData.getCurrentUser(), catId, catName);
            SessionData.saveUserInfoToDB();
            PageNavigator.goBack();
        }

        public static void delUserRestaurant()
        {
            SessionData.removeUserRestaurant(SessionData.getCurrentUser(), SessionData.getCurrentCatId(), SessionData.getCurrentResId());
            SessionData.saveUserInfoToDB();
            PageNavigator.goBack();
        }

        public static void editUserRestaurantNotes(string content)
        {
            SessionData.editUserResNotes(SessionData.getCurrentUser(), SessionData.getCurrentCatId(), SessionData.getCurrentResId(), content);
            SessionData.saveUserInfoToDB();
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
