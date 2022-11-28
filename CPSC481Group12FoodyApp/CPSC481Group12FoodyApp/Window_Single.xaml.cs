using CPSC481Group12FoodyApp.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for Window_Single.xaml
    /// </summary>
    public partial class Window_Single : Window
    {
        public Window_Single()
        {
            InitializeComponent();
            SessionData_User.initializeStartup();
            SessionData_Group.initializeStartup();
            SessionData_Msg.initializeStartup();
            SessionData_Event.initializeStartup();
            SessionData_Category.initializeStartup();
            SessionData_Restaurant.initializeStartup();
            PageNavigator.initializeProgram(this);
        }
    }
}
