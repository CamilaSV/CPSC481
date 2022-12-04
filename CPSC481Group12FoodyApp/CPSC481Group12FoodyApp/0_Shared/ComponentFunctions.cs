using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace CPSC481Group12FoodyApp.Logic
{
    public static class ComponentFunctions
    {
        private static Interface_Component component;

        public static void addComponentToList(Interface_Component newComponent)
        {
            component = newComponent;
            refreshAll();
        }

        public static void refreshAll()
        {
            if (component != null) 
            {
                component.refreshComponent();
            }
        }

        /*
        private static List<Interface_Component> components = new List<Interface_Component>();

        public static void addComponentToList(Interface_Component component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
        }
        public static void refreshAll()
        {
            foreach (var component in components)
            {
                component.refreshComponent();
            }
        }
        */
    }
}
