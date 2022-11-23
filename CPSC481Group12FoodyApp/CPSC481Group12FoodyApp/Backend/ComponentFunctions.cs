using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class ComponentFunctions
    {
        private static List<Interface_ChatListComponent> chatListComponents;
        private static List<Interface_FriendListComponent> friendListComponents;
        private static List<Interface_FriendReqComponent> friendReqComponents;

        public static void addComponentToList(Interface_ChatListComponent component)
        {
            chatListComponents.Add(component);
        }

        public static void addComponentToList(Interface_FriendListComponent component)
        {
            friendListComponents.Add(component);
        }

        public static void addComponentToList(Interface_FriendReqComponent component)
        {
            friendReqComponents.Add(component);
        }

        public static void refreshChats()
        {
            foreach (var component in chatListComponents)
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
    }
}
