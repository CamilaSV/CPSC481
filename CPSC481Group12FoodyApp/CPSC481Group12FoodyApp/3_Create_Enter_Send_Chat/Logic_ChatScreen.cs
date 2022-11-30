﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Printing;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class Logic_ChatScreen
    {
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

        public static void sendMsg(string emailSender, int groupId, string chatMsg)
        {
            SessionData.addGroupMsg(groupId, emailSender, chatMsg);
            SessionData.saveGroupInfoToDB();
            ComponentFunctions.refreshChatMsgs();
        }

        public static void sendMsg(string emailSender, string groupId, string chatMsg)
        {
            sendMsg(emailSender, Int32.Parse(groupId), chatMsg);
        }
    }
}
