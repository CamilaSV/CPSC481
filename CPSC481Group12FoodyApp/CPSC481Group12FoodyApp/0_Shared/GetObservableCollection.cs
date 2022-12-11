using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class GetObservableCollection
    {
        public static List<propertyChange_Friend> displayUsersFriendRequest()
        {
            List<propertyChange_Friend> collection = new List<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriendRequests(SessionData.getCurrentUser()))
                {
                    name = SessionData.getUserDisplayName(email);
                    collection.Add(new propertyChange_Friend
                    {
                        TargetEmail = email,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                    }
                    );
                }
            }

            return collection;
        }

        public static List<propertyChange_Friend> displayUsersFriendList()
        {
            List<propertyChange_Friend> collection = new List<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    name = SessionData.getUserDisplayName(email);
                    collection.Add(new propertyChange_Friend
                    {
                        TargetEmail = email,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                    }
                    );
                }
            }

            return collection;
        }

        public static List<propertyChange_Friend> displayUsersFriendNoPendingInviteOnly()
        {
            List<propertyChange_Friend> collection = new List<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    if (!SessionData.getTargetIsPendingInvite(SessionData.getCurrentGroupId(), SessionData.getCurrentUser(), email))
                    {
                        name = SessionData.getUserDisplayName(email);
                        collection.Add(new propertyChange_Friend
                        {
                            TargetEmail = email,
                            TargetUserName = name,
                            Abbreviation = name.Substring(0, 1),
                        }
                        );
                    }
                }
            }

            return collection;
        }

        public static List<propertyChange_Friend> displayUsersFriendPendingInviteOnly()
        {
            List<propertyChange_Friend> collection = new List<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    if (SessionData.getTargetIsPendingInvite(SessionData.getCurrentGroupId(), SessionData.getCurrentUser(), email))
                    {
                        name = SessionData.getUserDisplayName(email);
                        collection.Add(new propertyChange_Friend
                        {
                            TargetEmail = email,
                            TargetUserName = name,
                            Abbreviation = name.Substring(0, 1),
                        }
                        );
                    }
                }
            }

            return collection;
        }

        public static List<propertyChange_FriendInvite> displayUsersFriendInviteList()
        {
            List<propertyChange_FriendInvite> collection = new List<propertyChange_FriendInvite>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    name = SessionData.getUserDisplayName(email);
                    collection.Add(new propertyChange_FriendInvite
                    {
                        TargetEmail = email,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                        IsInvited = SessionData.getTargetsToInviteToGroup().Contains(email),
                    }
                    );
                }
            }

            return collection;
        }

        public static List<propertyChange_FriendInvite> displayUsersFriendInviteMoreList()
        {
            List<propertyChange_FriendInvite> collection = new List<propertyChange_FriendInvite>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    if (!SessionData.getGroupMembers(SessionData.getCurrentGroupId()).Contains(email))
                    {
                        name = SessionData.getUserDisplayName(email);
                        collection.Add(new propertyChange_FriendInvite
                        {
                            TargetEmail = email,
                            TargetUserName = name,
                            Abbreviation = name.Substring(0, 1),
                            IsInvited = SessionData.getTargetsToInviteToGroup().Contains(email),
                        }
                        );
                    }
                }
            }

            return collection;
        }

        public static List<propertyChange_Chat> displayUsersChatList()
        {
            List<propertyChange_Chat> collection = new List<propertyChange_Chat>();

            MsgInfo msg;
            string name, abbreviation, content;
            List<int> sortedGroups = SessionData.getUserGroups(SessionData.getCurrentUser());
            sortedGroups.Sort((m1, m2) => SessionData.getGroupLastMsgInfo(m2).time.CompareTo(SessionData.getGroupLastMsgInfo(m1).time));

            foreach (var groupId in sortedGroups)
            {
                msg = SessionData.getGroupLastMsgInfo(groupId);
                if (string.IsNullOrEmpty(msg.senderEmail))
                {
                    name = "";
                    abbreviation = "";
                    content = msg.content;
                }
                else if (msg.senderEmail == "event")
                {
                    name = "";
                    abbreviation = "";
                    content = "A new event is created.";
                }
                else
                {
                    name = SessionData.getUserDisplayName(msg.senderEmail);
                    abbreviation = name.Substring(0, 1);
                    content = msg.content;
                }

                collection.Add(new propertyChange_Chat
                {
                    Abbreviation = abbreviation,
                    ChatId = groupId.ToString(),
                    ChatName = SessionData.getGroupName(groupId),
                    ChatLastSender = msg.senderEmail,
                    ChatLastMsg = content,

                    ChatLastTime = SessionData.getDateTimeStringfromEpoch(msg.time),
                }
                );
            }

            return collection;
        }

        public static List<propertyChange_ChatInvite> displayUsersGroupInviteList()
        {
            List<propertyChange_ChatInvite> collection = new List<propertyChange_ChatInvite>();

            foreach (var invite in SessionData.getUserGroupInvitations(SessionData.getCurrentUser()))
            {
                collection.Add(new propertyChange_ChatInvite
                {
                    GroupId = invite.inviteGroupId.ToString(),
                    GroupName = SessionData.getGroupName(invite.inviteGroupId),
                    SenderEmail = invite.inviteSenderEmail,
                    SenderName = SessionData.getUserDisplayName(invite.inviteSenderEmail),
                }
                );
            }

            return collection;
        }

        public static List<propertyChange_UserEvent> displayUserUpcomingEventDate(DateTime date)
        {

            List<propertyChange_UserEvent> list = new List<propertyChange_UserEvent>();

            foreach (var info in SessionData.getUserEvents(SessionData.getCurrentUser()))
            {
                var eventDate = SessionData.getDateOrTimefromEpoch(SessionData.getEventTime(info.groupId, info.eventId));

                if (eventDate < date)
                {
                    if (eventDate.Date == date.Date)
                    {
                        list.Add(new propertyChange_UserEvent
                        {
                            GroupId = info.groupId.ToString(),
                            EventId = info.eventId.ToString(),
                            EventTime = SessionData.convertDateTimeToString(eventDate),
                            RestaurantName = SessionData.getRestaurantName(SessionData.getEventRestaurant(info.groupId, info.eventId)),
                            TextToShow = "On " + eventDate.Date + "\n" + "with" + SessionData.getGroupName(info.groupId),
                        });
                    }
                }
            }

            if (list.Count > 1)
            {
                list.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
            }

            return list;
        }

        public static List<propertyChange_UserEvent> displayUserCompletedEventDate(DateTime date)
        {
            List<propertyChange_UserEvent> list = new List<propertyChange_UserEvent>();

            foreach (var info in SessionData.getUserEvents(SessionData.getCurrentUser()))
            {
                var eventDate = SessionData.getDateOrTimefromEpoch(SessionData.getEventTime(info.groupId, info.eventId));

                if (eventDate.Date == date.Date)
                {
                    if (eventDate >= date)
                    {
                        list.Add(new propertyChange_UserEvent
                        {
                            GroupId = info.groupId.ToString(),
                            EventId = info.eventId.ToString(),
                            EventTime = SessionData.convertDateTimeToString(eventDate),
                            RestaurantName = SessionData.getRestaurantName(SessionData.getEventRestaurant(info.groupId, info.eventId)),
                            TextToShow = "On " + eventDate.Date + "\n" + "with" + SessionData.getGroupName(info.groupId),
                        });
                    }
                }
            }

            if (list.Count > 1)
            {
                list.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
            }

            return list;
        }

        public static List<propertyChange_GroupMember> displayGroupMemberList()
        {
            List<propertyChange_GroupMember> collection = new List<propertyChange_GroupMember>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                string name;
                foreach (string email in SessionData.getGroupMembers(SessionData.getCurrentGroupId()))
                {
                    name = SessionData.getUserDisplayName(email);
                    collection.Add(new propertyChange_GroupMember
                    {
                        TargetEmail = email,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                        TargetIsAdmin = SessionData.getTargetIsGroupAdmin(SessionData.getCurrentGroupId(), email).ToString(),
                    }
                    );
                }
            }

            return collection;
        }

        public static List<propertyChange_ChatScreen> displayChatModels()
        {
            List<propertyChange_ChatScreen> collection = new List<propertyChange_ChatScreen>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                string email;
                string abbreviation;
                string name;
                bool isUserJoined;
                bool isEventNotification;
                bool isSender;
                int isConfirmedEvent;
                string resName;
                long evTime;
                int evId;
                int msgId;

                foreach (var msgInfo in SessionData.getGroupMessages(SessionData.getCurrentGroupId()))
                {
                    abbreviation = "";
                    name = "";
                    resName = "";
                    evTime = 0;
                    evId = -1;
                    isConfirmedEvent = -1;

                    email = msgInfo.senderEmail;
                    msgId = msgInfo.id;
                    if (email == string.Empty)
                    {
                        isSender = false;
                        isUserJoined = true;
                        isEventNotification = false;
                    }
                    else if (email == "event")
                    {
                        var eventIndex = SessionData.getGroupEventExist(SessionData.getCurrentGroupId(), msgInfo.evId);
                        if (SessionData.getGroupEvents(SessionData.getCurrentGroupId())[eventIndex].attendees.Contains(SessionData.getCurrentUser()))
                        {
                            isConfirmedEvent = 1;
                        }
                        else if (SessionData.getGroupEvents(SessionData.getCurrentGroupId())[eventIndex].denied.Contains(SessionData.getCurrentUser()))
                        {
                            isConfirmedEvent = 0;
                        }

                        evId = msgInfo.evId;
                        resName = msgInfo.resName;
                        evTime = msgInfo.evTime;
                        isSender = false;
                        isUserJoined = false;
                        isEventNotification = true;
                    }
                    else if (email.Equals(SessionData.getCurrentUser()))
                    {
                        name = SessionData.getUserDisplayName(email);
                        abbreviation = name.Substring(0, 1).ToUpper();
                        isSender = true;
                        isUserJoined = false;
                        isEventNotification = false;
                    }
                    else 
                    {
                        name = SessionData.getUserDisplayName(email);
                        abbreviation = name.Substring(0, 1).ToUpper();
                        isSender = false;
                        isUserJoined = false;
                        isEventNotification = false;
                    }

                    collection.Add(new propertyChange_ChatScreen
                    {
                        IsUser_chatId = msgId.ToString(),
                        IsUser_abbreviation = abbreviation,
                        IsUser_chatSenderEmail = email,
                        IsUser_chatSenderName = name,
                        IsUser_chatMsg = msgInfo.content,
                        IsUser_chatTime = msgInfo.time.ToString(),

                        EvId = evId.ToString(),
                        ResName = resName,
                        EvTime = SessionData.getDateOrTimefromEpoch(evTime).ToString("MMMM dd, yyyy @ hh:mm tt"),

                        IsSender = isSender,
                        IsUserJoined = isUserJoined,
                        IsEventNotification = isEventNotification,
                        IsConfirmedEvent = isConfirmedEvent,
                    });
                }
            }

            return collection;
        }

        public static List<propertyChange_GroupCriteria> displayGroupCriteriaList()
        {
            List<propertyChange_GroupCriteria> collection = new List<propertyChange_GroupCriteria>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                string criterionId;
                string targetEmail;

                var allInfo = SessionData.getGroupCustomCriteria(SessionData.getCurrentGroupId());

                if (allInfo.ContainsKey(SessionData.getCurrentUser()))
                {
                    criterionId = allInfo[SessionData.getCurrentUser()].ToString();
                    collection.Add(new propertyChange_GroupCriteria
                    {
                        CriterionId = criterionId,
                        CriterionContent = SessionData.getCriterionName(criterionId),
                        TargetUserName = "Me",
                        TargetEmail = SessionData.getCurrentUser(),
                    });
                }
                else
                {
                    collection.Add(new propertyChange_GroupCriteria
                    {
                        CriterionId = "none",
                        CriterionContent = "",
                        TargetUserName = "Me",
                        TargetEmail = SessionData.getCurrentUser(),
                    });
                }

                foreach (var info in allInfo)
                {
                    targetEmail = info.Key;
                    criterionId = info.Value.ToString();

                    if (!targetEmail.Equals(SessionData.getCurrentUser()))
                    {
                        collection.Add(new propertyChange_GroupCriteria
                        {
                            CriterionId = criterionId,
                            CriterionContent = SessionData.getCriterionName(criterionId),
                            TargetUserName = SessionData.getUserDisplayName(targetEmail),
                            TargetEmail = targetEmail,
                        });
                    }
                }
            }

            return collection;
        }

        public static Tuple<List<propertyChange_Category>, List<propertyChange_Category>> displayUserCategoryList()
        {
            List<propertyChange_Category> leftCollection = new List<propertyChange_Category>();
            List<propertyChange_Category> rightCollection = new List<propertyChange_Category>();
            Boolean isLeft = true;

            foreach (var info in SessionData.getUserSavedCategories(SessionData.getCurrentUser()))
            {
                if (isLeft)
                {
                    isLeft = false;

                    leftCollection.Add(new propertyChange_Category
                    {
                        CatId = info.id.ToString(),
                        CatName = info.name,
                    });
                }
                else
                {
                    isLeft = true;

                    rightCollection.Add(new propertyChange_Category
                    {
                        CatId = info.id.ToString(),
                        CatName = info.name,
                    });
                }
            }

            return new Tuple<List<propertyChange_Category>, List<propertyChange_Category>>(leftCollection, rightCollection);
        }

        public static List<propertyChange_RestaurantUser> displayUserCategoryRestaurantList(int catId)
        {
            List<propertyChange_RestaurantUser> collection = new List<propertyChange_RestaurantUser>();
            List<int> criteria = new List<int>();
            string criteria1, criteria2;
            int count;

            foreach (var info in SessionData.getUserCategoryRestaurants(SessionData.getCurrentUser(), catId))
            {
                criteria = SessionData.getRestaurantCriteria(info.Key);
                criteria1 = "";
                criteria2 = "";
                count = criteria.Count;

                if (count > 0)
                {
                    criteria1 = "• " + SessionData.getCriterionName(criteria[0]);

                    if (count > 1)
                    {
                        criteria2 = "• " + SessionData.getCriterionName(criteria[1]);

                        if (count > 2)
                        {
                            criteria2 += " ...";
                        }
                    }
                }

                collection.Add(new propertyChange_RestaurantUser
                {
                    RestaurantId = info.Key.ToString(),
                    RestaurantName = SessionData.getRestaurantName(info.Key),
                    Criteria1 = criteria1,
                    Criteria2 = criteria2,
                });
            }

            return collection;
        }

        public static List<propertyChange_GroupEvent> displayGroupSuggestTimeList(DateTime date)
        {
            List<propertyChange_GroupEvent> collection = new List<propertyChange_GroupEvent>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                var infos = SessionData.getEventCustomTimesOnGroupDate(SessionData.getCurrentGroupId());
                long chosenDate;
                foreach (var info in infos)
                {
                    chosenDate = SessionData.getEpochFromDateOrTime(date);
                    if (chosenDate <= info)
                    {
                        if (date.Date == SessionData.getDateOrTimefromEpoch(info).Date)
                        {
                            collection.Add(new propertyChange_GroupEvent
                            {
                                TimeText = SessionData.getDateOrTimefromEpoch(chosenDate).ToString("MMMM dd, yyyy @ hh:mm tt")
                            });
                        }
                    }
                }

                collection.Add(new propertyChange_GroupEvent
                {
                    TimeText = null,
                });
            }

            return collection;
        }

        public static List<propertyChange_UserDietary> displayUserDietaryList()
        {
            List<propertyChange_UserDietary> collection = new List<propertyChange_UserDietary>();
            var avail = SessionData.getUserDietaryChecked(SessionData.getCurrentUser());
            var all = SessionData.getAllPresetCriteria();

            for (int i = 0; i < all.Count; i++)
            {
                if (avail.Contains(i))
                {
                    collection.Add(new propertyChange_UserDietary
                    {
                        CriterionId = i.ToString(),
                        CriterionName = all[i].criteria,
                        CriterionChecked = true,
                    });
                }
                else
                {
                    collection.Add(new propertyChange_UserDietary
                    {
                        CriterionId = i.ToString(),
                        CriterionName = all[i].criteria,
                        CriterionChecked = false,
                    });
                }
            }

            return collection;
        }

        public static List<propertyChange_Restaurant> displayGroupRestaurantList()
        {
            List<propertyChange_Restaurant> collection = new List<propertyChange_Restaurant>();
            string criteriaListText;
            bool expandCard;
            string displayVotes;
            bool userVoted;

            foreach (var info in SessionData.getGroupSavedRestaurants(SessionData.getCurrentGroupId()))
            {
                criteriaListText = "";
                foreach (var critInfo in SessionData.getRestaurantCriteria(info))
                {
                    criteriaListText += " • " + SessionData.getCriterionName(critInfo) + "\n";
                }

                if (!criteriaListText.Equals(string.Empty))
                {
                    criteriaListText = criteriaListText.Substring(0, criteriaListText.Length - 1);
                }

                if (SessionData.getRestaurantCriteria(info).Count > 3) 
                    expandCard = true;
                else 
                    expandCard = false;

                if(SessionData.getHasUserVoted(SessionData.getCurrentGroupId(), info, SessionData.getCurrentUser()))
                {
                    //Logic_Group.addUserVote(info);
                    userVoted = true;
                }
                else
                {
                    //Logic_Group.removeUserVote(info);
                    userVoted = false;
                }

                displayVotes = "Votes: " + SessionData.getVoteCountRestaurant(SessionData.getCurrentGroupId(), info).ToString() +"/"+ SessionData.getNumberOfGroupMembers(SessionData.getCurrentGroupId(), info).ToString();

                collection.Add(new propertyChange_Restaurant
                {
                    RestaurantId = info.ToString(),
                    RestaurantName = SessionData.getRestaurantName(info),
                    CriteriaListText = criteriaListText,
                    ExpandCard = expandCard,

                    DisplayVote = displayVotes,
                    UserVoted = userVoted

                });
            }

            return collection;
        }

        public static List<propertyChange_GroupEvent> displayGroupEventList()
        {
            List<propertyChange_GroupEvent> collection = new List<propertyChange_GroupEvent>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                foreach (var info in SessionData.getGroupEvents(SessionData.getCurrentGroupId()))
                {
                    collection.Add(new propertyChange_GroupEvent
                    {
                        EventId = info.id.ToString(),
                        EventTime = SessionData.getDateTimeStringfromEpoch(info.time),
                        RestaurantName = SessionData.getRestaurantName(info.restaurantId),
                    }
                    );
                }
            }

            return collection;
        }

        public static List<propertyChange_Restaurant> displayGroupRestaurantCriteriaList(string resId)
        {
            return displayGroupRestaurantCriteriaList(resId);
        }

    }
}
