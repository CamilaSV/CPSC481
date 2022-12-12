using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class CreateMock
    {
        private const string dbDir = "DB\\";
        private const string accounts = "Accounts.json";
        private const string groups = "Groups.json";
        private const string restaurants = "Restaurants.json";
        private const string criteria = "Criteria.json";

        private static Dictionary<string, UserInfo> allUsers;
        private static Dictionary<int, GroupInfo> allGroups;
        private static Dictionary<int, RestaurantInfo> allRestaurants;
        private static Dictionary<int, PresetCriteriaInfo> allPresetCriteria;

        private const string ac1 = "account1@hotmail.com";
        private const string ac2 = "account2@hotmail.com";
        private const string ac3 = "account3@gmail.com";
        private const string ac4 = "account4@hotmail.com";
        private const string ac5 = "account5@gmail.com";

        private static string getAccountsPath()
        {
            return dbDir + accounts;
        }

        private static string getGroupsPath()
        {
            return dbDir + groups;
        }

        private static string getRestaurantsPath()
        {
            return dbDir + restaurants;
        }

        private static string getCriteriaPath()
        {
            return dbDir + criteria;
        }

        private static void createOneCriteria(ref int i, string criteria)
        {
            allPresetCriteria.Add(i, new PresetCriteriaInfo { criteria = criteria });
            i++;
        }

        public static void createPresetCriteria()
        {
            allPresetCriteria = new Dictionary<int, PresetCriteriaInfo>();
            int i = 0;
            createOneCriteria(ref i, "Meat"); // 0
            createOneCriteria(ref i, "Beef"); // 1
            createOneCriteria(ref i, "Pork"); // 2
            createOneCriteria(ref i, "Chicken"); // 3
            createOneCriteria(ref i, "Vegetarian"); // 4
            createOneCriteria(ref i, "Vegan"); // 5
            createOneCriteria(ref i, "Soup"); // 6
            createOneCriteria(ref i, "Mexican"); // 7
            createOneCriteria(ref i, "Chinese"); // 8
            createOneCriteria(ref i, "Korean"); // 9
            createOneCriteria(ref i, "Japanese"); // 10
            createOneCriteria(ref i, "Italian"); // 11
            createOneCriteria(ref i, "Fast Food"); // 12
            createOneCriteria(ref i, "$"); // 13
            createOneCriteria(ref i, "$$"); // 14
            createOneCriteria(ref i, "$$$"); // 15

            File.WriteAllText(getCriteriaPath(), JsonSerializer.Serialize(allPresetCriteria, new JsonSerializerOptions { WriteIndented = true }));
        }

        public static void createRestaurants()
        {
            allRestaurants = new Dictionary<int, RestaurantInfo>();
            int i = 0;
            createOneRestaurant(ref i, "Taiyo", "12424 Symons Valley Rd NW #23", "Calgary", "Alberta", "T3P 0A3", createCriteriaList(0, 10, 14)); // 0
            createOneRestaurant(ref i, "Calgary Court Restaurant", "119 2 Ave SE", "Calgary", "Alberta", "T2G 0B2", createCriteriaList(0, 8, 14)); // 1
            createOneRestaurant(ref i, "McDonald's", "63 Crowfoot Way NW", "Calgary", "Alberta", "T3G 2R2", createCriteriaList(0, 12, 13)); // 2
            createOneRestaurant(ref i, "McDonald's", "12424 Symons Valley Rd NW #23", "Calgary", "Alberta", "T3P 0A3", createCriteriaList(0, 12, 13)); // 3
            createOneRestaurant(ref i, "Chun Jang", "8650 112 Ave NW #7127", "Calgary", "Alberta", "T3R 0R5", createCriteriaList(2, 9, 14)); // 4
            createOneRestaurant(ref i, "Minas Brazilian Steakhouse", "136 2 St SW", "Calgary", "Alberta", "T2P 0S7", createCriteriaList(0, 15)); // 5
            createOneRestaurant(ref i, "Tokyo Street Market", "922 Centre St NE", "Calgary", "Alberta", "T2E 2P7", createCriteriaList(10, 14)); // 6
            createOneRestaurant(ref i, "The Coup", "924 17 Ave SW", "Calgary", "Alberta", "T2T 0A2", createCriteriaList(4, 5, 14)); // 7
            createOneRestaurant(ref i, "barBURRITO", "61 Crowfoot Terrace NW", "Calgary", "Alberta", "T3G 4J8", createCriteriaList(0, 7, 13)); // 8
            createOneRestaurant(ref i, "Chicken On The Way", "1443 Kensington Rd NW", "Calgary", "Alberta", "T2N 3P9", createCriteriaList(3, 12, 13)); // 9
            createOneRestaurant(ref i, "Mary Brown's Chicken", "163 Quarry Park Blvd SE #103", "Calgary", "Alberta", "T2C 5E1", createCriteriaList(3, 12, 13)); // 10

            do
            {
                createOneRestaurant(ref i, "Restaurant" + i, "Address" + i, "Calgary", "Alberta", "PostalCode" + i, createCriteriaListRandom());
            } while (i < 100);

            File.WriteAllText(getRestaurantsPath(), JsonSerializer.Serialize(allRestaurants, new JsonSerializerOptions { WriteIndented = true }));
        }

        private static void initializeGroups()
        {
            var time = getEpochFromDateOrTime(DateTime.Now);

            // add members, messages and invites
            addUserNewGroup(ac1, 0, "FOODIES", time - 26000000);
            addUserGroup(ac2, 0);
            addGroupMember(0, ac2, time - 15000000);
            addGroupMsg(0, ac2, "Heya", time - 10000000);
            addGroupMsg(0, ac2, "How are you", time - 9998000);
            addGroupMsg(0, ac1, "Pretty good", time - 9990000);

            addUserNewGroup(ac2, 1, "Friends", time - 15000000);
            addUserGroup(ac1, 1);
            addGroupMember(1, ac1, time - 13000000);
            addGroupMsg(1, ac2, "Welcome", time - 12990000);
            addUserGroup(ac3, 1);
            addGroupMember(1, ac3, time - 12980000);
            addGroupMsg(1, ac3, "Good Everyone is here already", time - 10000000);
            addGroupMsg(1, ac1, "Yea", time - 9970000);

            addUserNewGroup(ac3, 2, "Family", time - 300000000);
            addUserGroup(ac4, 2);
            addGroupMember(2, ac4, time - 130000000);
            addGroupMemberToAdmin(2, ac4);

            addUserNewGroup(ac5, 3, "Enjoy", time - 24050430);

            sendGroupInviteToTarget(ac5, 0, ac1);
            sendGroupInviteToTarget(ac1, 3, ac5);
            sendGroupInviteToTarget(ac2, 3, ac5);
            sendGroupInviteToTarget(ac3, 3, ac5);
            sendGroupInviteToTarget(ac4, 3, ac5);

            // add saved restaurants and times
            addGroupRestaurant(0, 0);
            addGroupRestaurant(0, 1);
            addGroupRestaurant(0, 2);
            addGroupRestaurant(0, 3);
            addGroupRestaurant(0, 4);
            addEventCustomTime(0, time + 7000000);
            addEventCustomTime(0, time + 6000000);
            addEventCustomTime(0, time + 5000000);
            addEventCustomTime(0, time + 4000000);
            addEventCustomTime(0, time + 3000000);

            addGroupRestaurant(3, 2);
            addGroupRestaurant(3, 3);
            addGroupRestaurant(3, 0);
            addGroupRestaurant(3, 5);
            addGroupRestaurant(3, 6);
            addGroupRestaurant(3, 7);
            addGroupRestaurant(3, 8);
            addGroupRestaurant(3, 9);
            addEventCustomTime(3, time + 23000000);
            addEventCustomTime(3, time + 15000000);
            addEventCustomTime(3, time + 7000000);
            addEventCustomTime(3, time + 6000000);
            addEventCustomTime(3, time + 5000000);
            addEventCustomTime(3, time + 4000000);
            addEventCustomTime(3, time + 3000000);

            // add event
            addGroupEvent(0, 0, time + 5000000, 3, "", time - 7000000);
            addUserEvent(ac1, 0, 0);
            addGroupEvent(3, 0, time + 5000000, 9, "", time - 9000000);
            addGroupEvent(3, 1, time + 15000000, 9, "", time - 4000000);
        }
        private static void createAllGroups()
        {
            initializeGroups();
        }

        private static void createAllCategories()
        {
            addUserCategory(ac1, 0, "Favourites");
            addUserRestaurant(ac1, 0, 0);
            addUserRestaurant(ac1, 0, 1);
            addUserRestaurant(ac1, 0, 2);
            addUserCategory(ac1, 1, "Friends");
            addUserRestaurant(ac1, 1, 10);
            addUserRestaurant(ac1, 1, 2);
            addUserRestaurant(ac1, 1, 5);
            addUserCategory(ac1, 2, "Later");
            addUserRestaurant(ac1, 2, 0);
            addUserRestaurant(ac1, 2, 4);
            addUserRestaurant(ac1, 2, 8);

            addUserCategory(ac3, 0, "Mine");
            addUserRestaurant(ac3, 0, 0);
            addUserRestaurant(ac3, 0, 1);
            addUserRestaurant(ac3, 0, 2);
            addUserRestaurant(ac3, 0, 3);
            addUserRestaurant(ac3, 0, 4);
            addUserRestaurant(ac3, 0, 5);
            addUserRestaurant(ac3, 0, 6);
            addUserRestaurant(ac3, 0, 7);

            addUserCategory(ac4, 0, "Cat1");
            addUserCategory(ac4, 1, "Cat2");
            addUserCategory(ac4, 2, "Cat3");
            addUserCategory(ac4, 3, "Cat4");
            addUserCategory(ac4, 4, "Cat5");
        }

        public static void createDummyData()
        {
            allUsers = initializeUserList(); // friend list, requests, dietary check added
            allGroups = new Dictionary<int, GroupInfo>();

            createAllCategories();
            createAllGroups();

            DBFunctions.saveInfo(allUsers);
            DBFunctions.saveInfo(allGroups);
        }

        private static Dictionary<string, UserInfo> initializeUserList()
        {
            return new Dictionary<string, UserInfo>
            {
                {
                    ac1,
                    createOneUser
                    (
                    "12341234",
                    ac1,
                    "hihi",
                    new List<string> { ac2, ac3 },
                    new List<string> { ac4, ac5 },
                    new List<int>(),
                    new List<int> { 0, 1, 3, 4 }
                    )
                },
                {
                    ac2,
                    createOneUser
                    (
                    "12341234",
                    ac2,
                    "I like beef",
                    new List<string> { ac1, ac4 },
                    new List<string> { ac3 },
                    new List<int>(),
                    new List<int> { 2 }
                    )
                },
                {
                    ac3,
                    createOneUser
                    (
                    "12341234",
                    ac3,
                    "",
                    new List<string> { ac1, ac4 },
                    new List<string> { ac5 },
                    new List<int>(),
                    new List<int> { 5, 7, 8 }
                    )
                },
                {
                    ac4,
                    createOneUser
                    (
                    "12341234",
                    ac4,
                    "",
                    new List<string> { ac2, ac3 },
                    new List<string> { ac5 },
                    new List<int>(),
                    new List<int>()
                    )
                },
                {
                    ac5,
                    createOneUser
                    (
                    "12341234",
                    ac5,
                    "",
                    new List<string>(),
                    new List<string> { ac4 },
                    new List<int>(),
                    new List<int> { 1, 3, 5 }
                    )
                }
            };
        }

        private static UserInfo createOneUser(string pw, string name, string bio, List<string> fl, List<string> frq, List<int> gl, List<int> cri)
        {
            return new UserInfo
            {
                password = pw,
                name = name,
                bio = bio,
                friendList = fl,
                friendReqList = frq,
                groupList = gl,
                categoryList = new List<CategoryInfo>(),
                eventList = new List<UserEventInfo>(),
                invitationList = new List<InvitationInfo>(),
                criteriaChecked = cri,
            };
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

        private static void createOneRestaurant(ref int i, string name, string address, string city, string province, string postal_code, List<int> criteriaList)
        {
            allRestaurants.Add(i, new RestaurantInfo { name = name, address = address, city = city, province = province, postal_code = postal_code, criteriaList = criteriaList });
            i++;
        }

        private static void addUserNewGroup(string emailCreator, int groupId, string name, long time)
        {
            createGroup(groupId, name, emailCreator);
            addGroupMemberToAdmin(groupId, emailCreator);
            addUserGroup(emailCreator, groupId);
            addGroupMember(groupId, emailCreator, time);
        }

        private static void addUserCategory(string emailUser, int categoryId, string name)
        {
            if (getCategoryExist(emailUser, categoryId) == -1)
            {
                CategoryInfo info = new CategoryInfo
                {
                    id = categoryId,
                    name = name,
                    restaurantList = new Dictionary<int, string>(),
                };

                allUsers[emailUser].categoryList.Add(info);
            }
        }

        private static void addUserGroup(string emailUser, int groupId)
        {
            if (!allUsers[emailUser].groupList.Contains(groupId))
            {
                allUsers[emailUser].groupList.Add(groupId);
                // delete all invitations that invites to the added groupId
                allUsers[emailUser].invitationList.RemoveAll(invite => invite.inviteGroupId.Equals(groupId));
            }
        }

        private static void addUserEvent(string emailUser, int groupId, int eventId)
        {
            UserEventInfo eventInfo = new UserEventInfo { groupId = groupId, eventId = eventId };

            if (!allUsers[emailUser].eventList.Contains(eventInfo))
            {
                allUsers[emailUser].eventList.Add(eventInfo);
                var eventIndex = getGroupEventExist(groupId, eventId);
                if (eventIndex != -1)
                {
                    allGroups[groupId].eventList[eventIndex].attendees.Add(emailUser);
                }
            }
        }

        private static void addUserRestaurant(string emailUser, int catId, int resId)
        {
            Tuple<int, Boolean> index = getUserCategoryHasRes(emailUser, catId, resId);
            if ((index.Item1 != -1) && (index.Item2 == false))
            {
                allUsers[emailUser].categoryList[index.Item1].restaurantList.Add(resId, "");
            }
        }

        private static void sendGroupInviteToTarget(string emailTarget, int groupId, string emailSender)
        {
            InvitationInfo info = new InvitationInfo { inviteGroupId = groupId, inviteSenderEmail = emailSender };
            if (!allUsers[emailTarget].invitationList.Contains(info))
            {
                allUsers[emailTarget].invitationList.Add(info);
            }
        }

        // setters for group/event
        private static void createGroup(int groupId, string groupName, string emailCreator)
        {
            GroupInfo info = new GroupInfo(groupName);

            allGroups[groupId] = info;
        }

        private static void addGroupMsg(int groupId, string msgSender, string msgContent, long time)
        {
            int msgId = getFirstAvailableMsgId(groupId);
            MsgInfo msg = new MsgInfo(msgId, msgSender, msgContent, time);

            allGroups[groupId].msgList.Add(msg); // always sort messages depending on time
        }

        private static void addGroupMsg(int groupId, int eventId, long time)
        {
            int msgId = getFirstAvailableMsgId(groupId);
            MsgInfo msg = new MsgInfo
            {
                id = msgId,
                senderEmail = "event",
                evId = eventId,
                evTime = getEventTime(groupId, eventId),
                resName = getRestaurantName(getEventRestaurant(groupId, eventId)),
                time = getEpochFromDateOrTime(DateTime.Now),
            };

            allGroups[groupId].msgList.Add(msg); // always sort messages depending on time
        }

        private static void addGroupMemberToAdmin(int groupId, string emailTarget)
        {
            if (!allGroups[groupId].adminList.Contains(emailTarget))
            {
                allGroups[groupId].adminList.Add(emailTarget);
            }
        }

        private static void addGroupMember(int groupId, string emailTarget, long time)
        {
            if (!allGroups[groupId].memberList.Contains(emailTarget))
            {
                allGroups[groupId].memberList.Add(emailTarget);
                addGroupMsg(groupId, "", emailTarget + " has joined the group.", time);
            }
        }

        private static void addGroupCriterion(int groupId, string email, int criterionId)
        {
            if (!allGroups[groupId].customCriteriaList.ContainsKey(email))
            {
                allGroups[groupId].customCriteriaList.Add(email, criterionId);
            }
        }

        private static void addGroupRestaurant(int groupId, int restaurantId)
        {
            if (!allGroups[groupId].restaurantList.Contains(restaurantId))
            {
                allGroups[groupId].restaurantList.Add(restaurantId);
            }
        }

        private static void addGroupEvent(int groupId, int eventId, long time, int resId, string comment, long msgtime)
        {
            if (getGroupEventExist(groupId, eventId) == -1)
            {
                EventInfo info = new EventInfo
                {
                    id = eventId,
                    time = time,
                    restaurantId = resId,
                    comment = comment,
                };

                if (!allGroups[groupId].eventList.Contains(info))
                {
                    allGroups[groupId].eventList.Add(info);
                    addGroupMsg(groupId, eventId, msgtime);
                }
            }
        }

        private static Tuple<int, Boolean> getUserCategoryHasRes(string email, int catId, int resId)
        {
            for (int i = 0; i < allUsers[email].categoryList.Count; i++)
            {
                if (allUsers[email].categoryList[i].id == catId)
                {
                    if (allUsers[email].categoryList[i].restaurantList.ContainsKey(resId))
                    {
                        return new Tuple<int, Boolean>(i, true);
                    }
                    else
                    {
                        return new Tuple<int, Boolean>(i, false);
                    }
                }
            }

            return new Tuple<int, Boolean>(-1, false);
        }

        private static int getCategoryExist(string email, int catId)
        {
            for (int i = 0; i < allUsers[email].categoryList.Count; i++)
            {
                if (allUsers[email].categoryList[i].id == catId)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int getGroupMsgExist(int groupId, int msgId)
        {
            for (int i = 0; i < allGroups[groupId].msgList.Count; i++)
            {
                if (allGroups[groupId].msgList[i].id == msgId)
                {
                    return i;
                }
            }

            return -1;
        }

        private static int getGroupEventExist(int groupId, int eventId)
        {
            for (int i = 0; i < allGroups[groupId].eventList.Count; i++)
            {
                if (allGroups[groupId].msgList[i].id == eventId)
                {
                    return i;
                }
            }

            return -1;
        }

        private static long getEpochFromDateOrTime(DateTime date)
        {
            DateTimeOffset offset = new DateTimeOffset(date);

            return offset.ToUnixTimeMilliseconds();
        }

        private static string convertDateTimeToString(DateTime epochDateTime)
        {
            string dateOrTime;

            if (epochDateTime.Date < DateTime.Now.Date)
            {
                // at least 1 day has passed; only show date
                dateOrTime = epochDateTime.ToString("MM-dd", new CultureInfo("en-US"));
            }
            else
            {
                dateOrTime = epochDateTime.ToString("hh:mm tt", new CultureInfo("en-US"));
            }

            return dateOrTime;
        }

        private static DateTime getDateOrTimefromEpoch(long epochTime)
        {
            DateTimeOffset timeoff = DateTimeOffset.FromUnixTimeMilliseconds(epochTime);

            return timeoff.DateTime.ToLocalTime();
        }

        private static string getDateTimeStringfromEpoch(long epochTime)
        {
            return convertDateTimeToString(getDateOrTimefromEpoch(epochTime));
        }

        private static int getFirstAvailableEventId(int groupId)
        {
            SortedSet<int> allIds = new SortedSet<int>();

            foreach (var id in allGroups[groupId].eventList)
            {
                allIds.Add(id.id);
            }

            return getFirstAvailableId(allIds);
        }

        private static int getFirstAvailableCategoryId(string email)
        {
            SortedSet<int> allIds = new SortedSet<int>();

            foreach (var id in allUsers[email].categoryList)
            {
                allIds.Add(id.id);
            }

            return getFirstAvailableId(allIds);
        }

        private static int getFirstAvailableMsgId(int groupId)
        {
            SortedSet<int> allIds = new SortedSet<int>();

            foreach (var id in allGroups[groupId].msgList)
            {
                allIds.Add(id.id);
            }

            return getFirstAvailableId(allIds);
        }

        private static int getFirstAvailableGroupId()
        {
            int index;
            for (index = 0; allGroups.ContainsKey(index); index++) ;

            return index;
        }

        private static int getFirstAvailableId(SortedSet<int> allIds)
        {
            int returnId = 0;
            foreach (var id in allIds)
            {
                if (id != returnId)
                {
                    break;
                }

                returnId++;
            }

            return returnId;
        }

        private static void addEventCustomTime(int groupId, long eventTime)
        {
            if (!allGroups[groupId].suggestedTimes.Contains(eventTime))
            {
                allGroups[groupId].suggestedTimes.Add(eventTime);
            }
        }

        private static long getEventTime(int groupId, int eventId)
        {
            return allGroups[groupId].eventList[getGroupEventExist(groupId, eventId)].time;
        }

        private static int getEventRestaurant(int groupId, int eventId)
        {
            return allGroups[groupId].eventList[getGroupEventExist(groupId, eventId)].restaurantId;
        }

        private static string getRestaurantName(int restaurantId)
        {
            return allRestaurants[restaurantId].name;
        }
    }
}
