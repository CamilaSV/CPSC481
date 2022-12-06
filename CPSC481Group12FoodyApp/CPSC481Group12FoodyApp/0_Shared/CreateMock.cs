using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text.Json;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class CreateMock
    {
        private const string dbDir = "DB\\";
        private const string restaurants = "Restaurants.json";
        private const string criteria = "Criteria.json";

        private static string getRestaurantsPath()
        {
            return dbDir + restaurants;
        }

        private static string getCriteriaPath()
        {
            return dbDir + criteria;
        }

        private static void createOneCriteria(Dictionary<int, PresetCriteriaInfo> dummyCriteria, ref int i, string criteria)
        {
            dummyCriteria.Add(i, new PresetCriteriaInfo { criteria = criteria });
            i++;
        }

        public static void createPresetCriteria()
        {
            Dictionary<int, PresetCriteriaInfo> dummyCriteria = new Dictionary<int, PresetCriteriaInfo>();
            PresetCriteriaInfo oneCriteria;
            int i = 0;
            createOneCriteria(dummyCriteria, ref i, "Meat"); // 0
            createOneCriteria(dummyCriteria, ref i, "Beef"); // 1
            createOneCriteria(dummyCriteria, ref i, "Pork"); // 2
            createOneCriteria(dummyCriteria, ref i, "Chicken"); // 3
            createOneCriteria(dummyCriteria, ref i, "Vegetarian"); // 4
            createOneCriteria(dummyCriteria, ref i, "Vegan"); // 5
            createOneCriteria(dummyCriteria, ref i, "Soup"); // 6
            createOneCriteria(dummyCriteria, ref i, "Mexican"); // 7
            createOneCriteria(dummyCriteria, ref i, "Chinese"); // 8
            createOneCriteria(dummyCriteria, ref i, "Korean"); // 9
            createOneCriteria(dummyCriteria, ref i, "Japanese"); // 10
            createOneCriteria(dummyCriteria, ref i, "Italian"); // 11
            createOneCriteria(dummyCriteria, ref i, "Fast Food"); // 12
            createOneCriteria(dummyCriteria, ref i, "$"); // 13
            createOneCriteria(dummyCriteria, ref i, "$$"); // 14
            createOneCriteria(dummyCriteria, ref i, "$$$"); // 15

            File.WriteAllText(getCriteriaPath(), JsonSerializer.Serialize(dummyCriteria, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static void createRestaurants()
        {
            Dictionary<int, RestaurantInfo> dummyRestaurants = new Dictionary<int, RestaurantInfo>();
            int i = 0;
            createOneRestaurant(dummyRestaurants, ref i, "Taiyo", "12424 Symons Valley Rd NW #23", "Calgary", "Alberta", "T3P 0A3", createCriteriaList(0, 10, 14)); // 0
            createOneRestaurant(dummyRestaurants, ref i, "Calgary Court Restaurant", "119 2 Ave SE", "Calgary", "Alberta", "T2G 0B2", createCriteriaList(0, 8, 14)); // 1
            createOneRestaurant(dummyRestaurants, ref i, "McDonald's", "63 Crowfoot Way NW", "Calgary", "Alberta", "T3G 2R2", createCriteriaList(0, 12, 13)); // 2
            createOneRestaurant(dummyRestaurants, ref i, "McDonald's", "12424 Symons Valley Rd NW #23", "Calgary", "Alberta", "T3P 0A3", createCriteriaList(0, 12, 13)); // 3
            createOneRestaurant(dummyRestaurants, ref i, "Chun Jang", "8650 112 Ave NW #7127", "Calgary", "Alberta", "T3R 0R5", createCriteriaList(2, 9, 14)); // 4
            createOneRestaurant(dummyRestaurants, ref i, "Minas Brazilian Steakhouse", "136 2 St SW", "Calgary", "Alberta", "T2P 0S7", createCriteriaList(0, 15)); // 5
            createOneRestaurant(dummyRestaurants, ref i, "Tokyo Street Market", "922 Centre St NE", "Calgary", "Alberta", "T2E 2P7", createCriteriaList(10, 14)); // 6
            createOneRestaurant(dummyRestaurants, ref i, "The Coup", "924 17 Ave SW", "Calgary", "Alberta", "T2T 0A2", createCriteriaList(4, 5, 14)); // 7
            createOneRestaurant(dummyRestaurants, ref i, "barBURRITO", "61 Crowfoot Terrace NW", "Calgary", "Alberta", "T3G 4J8", createCriteriaList(0, 7, 13)); // 8
            createOneRestaurant(dummyRestaurants, ref i, "Chicken On The Way", "1443 Kensington Rd NW", "Calgary", "Alberta", "T2N 3P9", createCriteriaList(3, 12, 13)); // 9
            createOneRestaurant(dummyRestaurants, ref i, "Mary Brown's Chicken", "163 Quarry Park Blvd SE #103", "Calgary", "Alberta", "T2C 5E1", createCriteriaList(3, 12, 13)); // 10

            do
            {
                createOneRestaurant(dummyRestaurants, ref i, "Restaurant" + i, "Address" + i, "Calgary", "Alberta", "PostalCode" + i, createCriteriaListRandom());
            } while (i < 100);

            File.WriteAllText(getRestaurantsPath(), JsonSerializer.Serialize(dummyRestaurants, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static void createEvents()
        {

        }

        public static void createGroups()
        {

        }

        public static void createUsers()
        {

        }

        private static List<int> createCriteriaListRandom()
        {
            List<int> result = new List<int>();
            Random random = new Random();
            int success;
            int criteria;
            List<int> alreadyChosenCriteria = new List<int>();

            for (int i = 0; i < 8; i++)
            {
                success = random.Next(0, 10);
                if (success < (8 - i))
                {
                    do
                    {
                        criteria = random.Next(0, 16);
                    } while (alreadyChosenCriteria.Contains(criteria));

                    if ((criteria >= 13) && (criteria <= 15))
                    {
                        alreadyChosenCriteria.Add(13);
                        alreadyChosenCriteria.Add(14);
                        alreadyChosenCriteria.Add(15);
                    }
                    else
                    {
                        alreadyChosenCriteria.Add(criteria);
                    }

                    result.Add(criteria);
                }
            }

            result.Sort();

            return result;
        }

        private static List<int> createCriteriaList(int one, int two, int three, int four, int five, int six)
        {
            return new List<int> { one, two, three, four, five, six };
        }

        private static List<int> createCriteriaList(int one, int two, int three, int four, int five)
        {
            return new List<int> { one, two, three, four, five };
        }

        private static List<int> createCriteriaList(int one, int two, int three, int four)
        {
            return new List<int> { one, two, three, four };
        }

        private static List<int> createCriteriaList(int one, int two, int three)
        {
            return new List<int> { one, two, three };
        }

        private static List<int> createCriteriaList(int one, int two)
        {
            return new List<int> { one, two };
        }

        private static List<int> createCriteriaList(int one)
        {
            return new List<int> { one };
        }

        private static List<int> createCriteriaList()
        {
            return new List<int>();
        }

        private static void createOneRestaurant(Dictionary<int, RestaurantInfo> dummyRestaurants, ref int i, string name, string address, string city, string province, string postal_code, List<int> criteriaList)
        {
            dummyRestaurants.Add(i, new RestaurantInfo { name = name, address = address, city = city, province = province, postal_code = postal_code, criteriaList = criteriaList });
            i++;
        }
    }
}
