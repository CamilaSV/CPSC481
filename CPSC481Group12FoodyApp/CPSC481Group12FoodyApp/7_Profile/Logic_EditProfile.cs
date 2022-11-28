using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_EditProfile
    {
        public static void editBio(string emailUser, string bio)
        {
            DBSetter.createFileWithText(PathFinder.getAccBio(emailUser), bio);
        }

        public static void createCategory(string emailUser, string categoryId, string categoryName)
        {
            Directory.CreateDirectory(PathFinder.getAccOneCategoryDir(emailUser, categoryId));
            DBSetter.createFileWithText(PathFinder.getAccOneCategoryName(emailUser, categoryId), categoryName);
        }

        public static void removeCategory(string emailUser, string categoryId)
        {
            Directory.Delete(PathFinder.getAccOneCategoryDir(emailUser, categoryId), true);
        }

        public static void editCategoryName(string emailUser, string categoryId, string categoryName)
        {
            DBSetter.createFileWithText(PathFinder.getAccOneCategoryName(emailUser, categoryId), categoryName);
        }

        public static void addRestaurantToCategory(string emailUser, string categoryId, string restaurantId)
        {
            DBSetter.appendLineToFile(PathFinder.getAccOneCategoryRestaurants(emailUser, categoryId), restaurantId);
        }

        public static void remRestaurantFromCategory(string emailUser, string categoryId, string restaurantId)
        {
            DBSetter.removeLineFromFile(PathFinder.getAccOneCategoryRestaurants(emailUser, categoryId), restaurantId);
        }

        // polymorphism?
        public static void createCategory(string emailUser, int categoryId, string categoryName)
        {
            createCategory(emailUser, categoryId.ToString(), categoryName);
        }

        public static void removeCategory(string emailUser, int categoryId)
        {
            removeCategory(emailUser, categoryId.ToString());
        }

        public static void editCategoryName(string emailUser, int categoryId, string categoryName)
        {
            editCategoryName(emailUser, categoryId.ToString(), categoryName);
        }

        public static void addRestaurantToCategory(string emailUser, string categoryId, int restaurantId)
        {
            addRestaurantToCategory(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void addRestaurantToCategory(string emailUser, int categoryId, string restaurantId)
        {
            addRestaurantToCategory(emailUser, categoryId.ToString(), restaurantId.ToString());
        }

        public static void remRestaurantFromCategory(string emailUser, int categoryId, int restaurantId)
        {
            addRestaurantToCategory(emailUser, categoryId.ToString(), restaurantId.ToString());
        }
    }
}
