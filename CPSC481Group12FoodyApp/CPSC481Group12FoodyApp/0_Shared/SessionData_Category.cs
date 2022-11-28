using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class SessionData_Category
    {
        private static Dictionary<CategoryId, CategoryInfo> allCategories;

        public static void initializeStartup()
        {
            allCategories = DBFunctions.getAllCategoryInfo();
        }

        public static void createCategory(string emailOwner, string categoryId, string name)
        {
            CategoryId catId = new CategoryId { emailOwner = emailOwner, id = categoryId };
            CategoryInfo info = new CategoryInfo
            {
                name = name,
                restaurantList = new List<string>(),
            };

            allCategories[catId] = info;
        }

        public static void deleteCategory(string emailOwner, string categoryId)
        {
            CategoryId catId = new CategoryId { emailOwner = emailOwner, id = categoryId };

            if (allCategories.ContainsKey(catId))
            {
                allCategories.Remove(catId);
            }
        }

        // getters
        public static string getCategoryName(CategoryId catId)
        {
            return allCategories[catId].name;
        }

        public static List<string> getCategoryRestaurants(CategoryId catId)
        {
            return allCategories[catId].restaurantList;
        }

        // setters
        public static void setCategoryName(CategoryId catId, string name)
        {
            allCategories[catId].name = name;
        }

        public static void addResToCategory(CategoryId catId, string restaurantId)
        {
            if (!allCategories[catId].restaurantList.Contains(restaurantId))
            {
                allCategories[catId].restaurantList.Add(restaurantId);
            }
        }

        public static void removeResFromCategory(CategoryId catId, string restaurantId)
        {
            if (allCategories[catId].restaurantList.Contains(restaurantId))
            {
                allCategories[catId].restaurantList.Remove(restaurantId);
            }
        }

        // different types of arguments
        public static void createCategory(string emailOwner, int categoryId, string name)
        {
            createCategory(emailOwner, categoryId.ToString(), name);
        }

        public static void deleteCategory(string emailOwner, int categoryId)
        {
            deleteCategory(emailOwner, categoryId.ToString());
        }

        public static void addResToCategory(CategoryId catId, int restaurantId)
        {
            addResToCategory(catId, restaurantId.ToString());
        }

        public static void removeResFromCategory(CategoryId catId, int restaurantId)
        {
            removeResFromCategory(catId, restaurantId.ToString());
        }
    }
}
