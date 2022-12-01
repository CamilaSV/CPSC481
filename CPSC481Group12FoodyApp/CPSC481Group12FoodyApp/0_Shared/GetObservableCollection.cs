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

        public static ObservableCollection<propertyChange_Chat> displayUsersChatList()
        {
            ObservableCollection<propertyChange_Chat> collection = new ObservableCollection<propertyChange_Chat>();

            MsgInfo msg;
            string name, abbreviation;
            List<int> sortedGroups = SessionData.getUserGroups(SessionData.getCurrentUser());
            sortedGroups.Sort((m1, m2) => SessionData.getGroupLastMsgInfo(m2).time.CompareTo(SessionData.getGroupLastMsgInfo(m1).time));

            foreach (var groupId in sortedGroups)
            {
                // testing
                System.Diagnostics.Debug.WriteLine(groupId);

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

                    ChatLastTime = SessionData.getDateOrTimefromEpoch(msg.time),
                }
                );
            }

            return collection;
        }

        public static ObservableCollection<propertyChange_Restaurant> displayUserRestaurantList()
        {
            ObservableCollection<propertyChange_Restaurant> collection = new ObservableCollection<propertyChange_Restaurant>();

            return collection;
        }

        public static ObservableCollection<propertyChange_UserEvent> displayUserEventList()
        {
            ObservableCollection<propertyChange_UserEvent> collection = new ObservableCollection<propertyChange_UserEvent>();

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

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendListWithoutInvite()
        {
            ObservableCollection<propertyChange_Friend> collection = new ObservableCollection<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    if (!SessionData.getTargetsToInviteToGroup().Contains(email))
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

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendListWithInvite()
        {
            ObservableCollection<propertyChange_Friend> collection = new ObservableCollection<propertyChange_Friend>();

            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    if (SessionData.getTargetsToInviteToGroup().Contains(email))
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
                        abbreviation = name.Substring(0, 1);
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

            return collection;
        }

        public static ObservableCollection<propertyChange_Restaurant> displayGroupRestaurantList()
        {
            ObservableCollection<propertyChange_Restaurant> collection = new ObservableCollection<propertyChange_Restaurant>();

            return collection;
        }

        public static ObservableCollection<propertyChange_GroupEvent> displayGroupEventList()
        {
            ObservableCollection<propertyChange_GroupEvent> collection = new ObservableCollection<propertyChange_GroupEvent>();

            return collection;
        }
    }
}
