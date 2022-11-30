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
            ObservableCollection<propertyChange_Friend> friendRequestCollection = new ObservableCollection<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                propertyChange_Friend requestItem;
                foreach (string email in SessionData.getUserFriendRequests(SessionData.getCurrentUser()))
                {
                    name = SessionData.getUserDisplayName(email);
                    requestItem = new propertyChange_Friend
                    {
                        TargetEmail = email,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                    };
                    friendRequestCollection.Add(requestItem);
                }
            }

            return friendRequestCollection;
        }

        public static ObservableCollection<propertyChange_Friend> displayUsersFriendList()
        {
            ObservableCollection<propertyChange_Friend> friendListCollection = new ObservableCollection<propertyChange_Friend>();
            if (!string.IsNullOrEmpty(SessionData.getCurrentUser()))
            {
                string name;
                propertyChange_Friend listItem;
                foreach (string email in SessionData.getUserFriends(SessionData.getCurrentUser()))
                {
                    name = SessionData.getUserDisplayName(email);
                    listItem = new propertyChange_Friend
                    {
                        TargetEmail = email,
                        TargetUserName = name,
                        Abbreviation = name.Substring(0, 1),
                    };
                    friendListCollection.Add(listItem);
                }
            }

            return friendListCollection;
        }

        public static ObservableCollection<propertyChange_ChatScreen> displayChatModels()
        {
            ObservableCollection<propertyChange_ChatScreen> chatMsgCollection = new ObservableCollection<propertyChange_ChatScreen>();

            if (SessionData.getCurrentGroupId() != -1)
            {
                string email;
                string abbreviation;
                string name;
                foreach (var msgInfo in SessionData.getGroupMessages(SessionData.getCurrentGroupId()))
                {
                    email = msgInfo.senderEmail;
                    if (String.IsNullOrEmpty(email))
                    {
                        name = "";
                        abbreviation = "";
                    }
                    else
                    {
                        name = SessionData.getUserDisplayName(email);
                        abbreviation = name.Substring(0, 1);
                    }

                    if (email.Equals(SessionData.getCurrentUser()))
                    {
                        chatMsgCollection.Add(new propertyChange_ChatScreen
                        {
                            IsUser_abbreviation = abbreviation,
                            IsUser_chatSenderEmail = email,
                            IsUser_chatSenderName = name,
                            IsUser_chatMsg = msgInfo.content,
                            IsUser_chatTime = msgInfo.time.ToString(),
                        });
                    }
                    else
                    {
                        chatMsgCollection.Add(new propertyChange_ChatScreen
                        {
                            IsUser_abbreviation = abbreviation,
                            IsUser_chatSenderEmail = email,
                            IsUser_chatSenderName = name,
                            IsUser_chatMsg = msgInfo.content,
                            IsUser_chatTime = msgInfo.time.ToString(),
                        });
                    }
                }
            }

            return chatMsgCollection;
        }

        public static ObservableCollection<propertyChange_Chat> displayUsersChatList()
        {
            ObservableCollection<propertyChange_Chat> chatListCollection = new ObservableCollection<propertyChange_Chat>();

            MsgInfo msg;
            string name, abbreviation;
            propertyChange_Chat chatItem;
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
                chatItem = new propertyChange_Chat
                {
                    Abbreviation = abbreviation,
                    ChatId = groupId.ToString(),
                    ChatName = SessionData.getGroupName(groupId),
                    ChatLastSender = msg.senderEmail,
                    ChatLastMsg = msg.content,

                    ChatLastTime = SessionData.getDateOrTimefromEpoch(msg.time),
                };
                chatListCollection.Add(chatItem);
            }

            return chatListCollection;
        }

        public static ObservableCollection<propertyChange_ChatInvite> displayUsersGroupInviteList()
        {
            ObservableCollection<propertyChange_ChatInvite> invListCollection = new ObservableCollection<propertyChange_ChatInvite>();

            propertyChange_ChatInvite invItem;
            foreach (var invite in SessionData.getUserGroupInvitations(SessionData.getCurrentUser()))
            {
                invItem = new propertyChange_ChatInvite
                {
                    GroupId = invite.inviteGroupId.ToString(),
                    GroupName = SessionData.getGroupName(invite.inviteGroupId),
                    SenderEmail = invite.inviteSenderEmail,
                    SenderName = SessionData.getUserDisplayName(invite.inviteSenderEmail),
                };
                invListCollection.Add(invItem);
            }

            return invListCollection;
        }
    }
}
