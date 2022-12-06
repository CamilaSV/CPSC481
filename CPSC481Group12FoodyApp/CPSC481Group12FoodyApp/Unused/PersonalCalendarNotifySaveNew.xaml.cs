using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481Group12FoodyApp
{
    /// <summary>
    /// Interaction logic for PersonalCalendarNotifySaveNew.xaml
    /// </summary>
    public partial class PersonalCalendarNotifySaveNew : Page
    {
        private int idSave;

        public PersonalCalendarNotifySaveNew(int idSave)
        {
            InitializeComponent();
            this.idSave = idSave;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
