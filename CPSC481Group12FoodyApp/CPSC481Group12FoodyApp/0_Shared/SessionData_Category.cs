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

        // getters

        // setters

        // different types of arguments
    }
}
