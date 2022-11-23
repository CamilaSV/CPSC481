using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp
{
    public static class Logic_EditProfile
    {
        public static void editBio(string emailUser, string bio)
        {
            SharedFunctions.createFileWithText(PathFinder.getAccBio(emailUser), bio);
        }

        public static void createCategory(string emailUser, string category)
        {
        }

        public static void removeCategory(string emailUser, string category)
        {

        }

        public static void addRestaurantToCategory(string emailUser, string folderName, string restaurant)
        {
        }

        public static void remRestaurantFromCategory(string emailUser, string folderName, string restaurant)
        {
        }
    }
}
