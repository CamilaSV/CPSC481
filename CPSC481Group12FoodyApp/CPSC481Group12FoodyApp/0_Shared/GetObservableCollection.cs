using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class GetObservableCollection
    {
        public static ObservableCollection<propertyChange_Friend> displayUsersFriendRequest()
        {
            ObservableCollection<propertyChange_Friend> collection = new ObservableCollection<propertyChange_Friend>();
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

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendList()
        {
            ObservableCollection<propertyChange_Friend> collection = new ObservableCollection<propertyChange_Friend>();
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

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendNoPendingInviteOnly()
        {
            ObservableCollection<propertyChange_Friend> collection = new ObservableCollection<propertyChange_Friend>();
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

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendPendingInviteOnly()
        {
            ObservableCollection<propertyChange_Friend> collection = new ObservableCollection<propertyChange_Friend>();
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

        public static ObservableCollection<propertyChange_FriendInvite> displayUsersFriendInviteList()
        {
            ObservableCollection<propertyChange_FriendInvite> collection = new ObservableCollection<propertyChange_FriendInvite>();
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

        public static ObservableCollection<propertyChange_FriendInvite> displayUsersFriendInviteMoreList()
        {
            ObservableCollection<propertyChange_FriendInvite> collection = new ObservableCollection<propertyChange_FriendInvite>();
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

        public static ObservableCollection<propertyChange_Chat> displayUsersChatList()
        {
            ObservableCollection<propertyChange_Chat> collection = new ObservableCollection<propertyChange_Chat>();

            MsgInfo msg;
            string name, abbreviation;
            List<int> sortedGroups = SessionData.getUserGroups(SessionData.getCurrentUser());
            sortedGroups.Sort((m1, m2) => SessionData.getGroupLastMsgInfo(m2).time.CompareTo(SessionData.getGroupLastMsgInfo(m1).time));

            foreach (var groupId in sortedGroups)
            {
                msg = SessionData.getGroupLastMsgInfo(groupId);
                if (string.IsNullOrEmpty(msg.senderEmail))
                {
                    name = "";
                    abbreviation = "";
                }
                else
                {
                    name = SessionData.getUserDisplayName(msg.senderEmail);
                    abbreviation = name.Substring(0, 1);
                }

                collection.Add(new propertyChange_Chat
                {
                    Abbreviation = abbreviation,
                    ChatId = groupId.ToString(),
                    ChatName = SessionData.getGroupName(groupId),
                    ChatLastSender = msg.senderEmail,
                    ChatLastMsg = msg.content,

                    ChatLastTime = SessionData.getDateTimeStringfromEpoch(msg.time),
                }
                );
            }

            return collection;
        }

        public static ObservableCollection<propertyChange_ChatInvite> displayUsersGroupInviteList()
        {
            ObservableCollection<propertyChange_ChatInvite> collection = new ObservableCollection<propertyChange_ChatInvite>();

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

        public static ObservableCollection<propertyChange_UserEvent> displayUserUpcomingEventDate(DateTime date)
        {

            List<propertyChange_UserEvent> list = new List<propertyChange_UserEvent>();

            foreach (var info in SessionData.getUserEvents(SessionData.getCurrentUser()))
            {
                var eventDate = SessionData.getDateOrTimefromEpoch(SessionData.getEventTime(info.groupId, info.eventId));

                if (eventDate.Date == date.Date)
                {
                    if (eventDate < date)
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

            return new ObservableCollection<propertyChange_UserEvent>(list);
        }

        public static ObservableCollection<propertyChange_UserEvent> displayUserCompletedEventDate(DateTime date)
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

            return new ObservableCollection<propertyChange_UserEvent>(list);
        }

        public static ObservableCollection<propertyChange_GroupMember> displayGroupMemberList()
        {
            ObservableCollection<propertyChange_GroupMember> collection = new ObservableCollection<propertyChange_GroupMember>();

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

        public static ObservableCollection<propertyChange_ChatScreen> displayChatModels()
        {
            ObservableCollection<propertyChange_ChatScreen> collection = new ObservableCollection<propertyChange_ChatScreen>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                string email;
                string abbreviation;
                string name;
                bool isSender;
                bool isUserJoined;
                foreach (var msgInfo in SessionData.getGroupMessages(SessionData.getCurrentGroupId()))
                {
                    email = msgInfo.senderEmail;
                    if (String.IsNullOrEmpty(email))
                    {
                        name = "";
                        abbreviation = "";
                        isUserJoined = true;
                        
                    }
                    else
                    {
                        name = SessionData.getUserDisplayName(email);
                        abbreviation = name.Substring(0, 1).ToUpper();
                        isUserJoined = false;
                    }

                    if (email.Equals(SessionData.getCurrentUser()))
                    {
                        collection.Add(new propertyChange_ChatScreen
                        {
                            IsUser_abbreviation = abbreviation,
                            IsUser_chatSenderEmail = email,
                            IsUser_chatSenderName = name,
                            IsUser_chatMsg = msgInfo.content,
                            IsUser_chatTime = msgInfo.time.ToString(),

                            IsSender = true,
                        });
                    }
                    else
                    {
                        collection.Add(new propertyChange_ChatScreen
                        {
                            IsUser_abbreviation = abbreviation,
                            IsUser_chatSenderEmail = email,
                            IsUser_chatSenderName = name,
                            IsUser_chatMsg = msgInfo.content,
                            IsUser_chatTime = msgInfo.time.ToString(),

                            IsSender = false,
                            IsUserJoined = isUserJoined,
                        });
                       
                        
                    }
                }
            }

            return collection;
        }

        public static ObservableCollection<propertyChange_GroupCriteria> displayGroupCriteriaList()
        {
            ObservableCollection<propertyChange_GroupCriteria> collection = new ObservableCollection<propertyChange_GroupCriteria>();

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

        // To do
        public static ObservableCollection<propertyChange_Restaurant> displayUserRestaurantList()
        {
            ObservableCollection<propertyChange_Restaurant> collection = new ObservableCollection<propertyChange_Restaurant>();

            return collection;
        }

        // To do
        public static ObservableCollection<propertyChange_Restaurant> displayGroupRestaurantList()
        {
            ObservableCollection<propertyChange_Restaurant> collection = new ObservableCollection<propertyChange_Restaurant>();

            return collection;
        }

        // To do
        public static ObservableCollection<propertyChange_GroupEvent> displayGroupEventList()
        {
            ObservableCollection<propertyChange_GroupEvent> collection = new ObservableCollection<propertyChange_GroupEvent>();

            return collection;
        }
    }
}
