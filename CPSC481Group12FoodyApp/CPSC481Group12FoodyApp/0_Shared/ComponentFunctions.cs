﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class ComponentFunctions
    {
        private static Interface_Component component;

        public static void addComponentToList(Interface_Component newComponent)
        {
            component = newComponent;
        }

        public static void refreshAll()
        {
            if (component != null)
            {
                component.refreshComponent();
            }
        }

        // Source: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-find-datatemplate-generated-elements
        public static void setLabel(ContentPresenter thing)
        {
            Label lb = FindVisualChild<Label>(thing);
            lb.Content = SessionData.getGroupName(SessionData.getCurrentGroupId());
        }

        private static childItem FindVisualChild<childItem>(DependencyObject obj)
    where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
