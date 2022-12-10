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
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.setUserDisplayName(email, newName);
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }

        public static void editUserBio(string email, string newBio)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.setUserBio(email, newBio);
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }
        public static void addUserDietaryChecked(int criterionId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.addUserDietaryChecked(SessionData.getCurrentUser(), criterionId);
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }

        public static void addUserDietaryUnchecked(int criterionId)
        {
            SessionData.stopTimer();
            SessionData.updateUserInfoFromDB();
            SessionData.addUserDietaryUnchecked(SessionData.getCurrentUser(), criterionId);
            SessionData.saveUserInfoToDB();
            SessionData.startTimer();
        }

        public static List<int> getUserDietaryChecked()
        {
            return SessionData.getUserDietaryChecked(SessionData.getCurrentUser());
        }

        public static void addUserDietaryChecked(string criterionId)
        {
            addUserDietaryChecked(Int32.Parse(criterionId));
        }

        public static void addUserDietaryUnchecked(string criterionId)
        {
            addUserDietaryUnchecked(Int32.Parse(criterionId));
        }
    }
}
