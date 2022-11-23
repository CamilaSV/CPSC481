using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class ComponentFunctions
    {
        // realted to user
        private static List<Interface_ChatListComponent> chatListComponents = new List<Interface_ChatListComponent>();
        private static List<Interface_ChatInvComponent> chatInvComponents = new List<Interface_ChatInvComponent>();
        private static List<Interface_FriendListComponent> friendListComponents = new List<Interface_FriendListComponent>();
        private static List<Interface_FriendReqComponent> friendReqComponents = new List<Interface_FriendReqComponent>();
        
        // related to creating chat
        private static List<Interface_ChatCreateComponent> chatCreateComponents = new List<Interface_ChatCreateComponent>();

        // related to the selected chat? Such as events etc.


        public static void addComponentToList(Interface_ChatListComponent component)
        {
            if (!chatListComponents.Contains(component))
            {
                chatListComponents.Add(component);
            }
        }

        public static void addComponentToList(Interface_ChatInvComponent component)
        {
            if (!chatInvComponents.Contains(component))
            {
                chatInvComponents.Add(component);
            }
        }

        public static void addComponentToList(Interface_FriendListComponent component)
        {
            if (!friendListComponents.Contains(component))
            {
                friendListComponents.Add(component);
            }
        }

        public static void addComponentToList(Interface_FriendReqComponent component)
        {
            if (!friendReqComponents.Contains(component))
            {
                friendReqComponents.Add(component);
            }
        }

        public static void refreshAll()
        {
            refreshChats();
            refreshChatsInv();
            refreshFriends();
            refreshFriendsReq();
        }

        public static void refreshChats()
        {
            foreach (var component in chatListComponents)
            {
                component.refreshComponent();
            }
        }

        public static void refreshChatsInv()
        {
            foreach (var component in chatInvComponents)
            {
                component.refreshComponent();
            }
        }

        public static void refreshFriends()
        {
            foreach (var component in friendListComponents)
            {
                component.refreshComponent();
            }
        }

        public static void refreshFriendsReq()
        {
            foreach (var component in friendReqComponents)
            {
                component.refreshComponent();
            }
        }

        public static void refreshChatCreate()
        {
            foreach (var component in chatCreateComponents)
            {
                component.refreshComponent();
            }
        }
    }
}
