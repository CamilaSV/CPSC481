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
    }
}
