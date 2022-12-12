using CPSC481Group12FoodyApp.Logic;
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
    /// Interaction logic for PersonalCalendar.xaml
    /// </summary>
    public partial class PersonalCalendar : Page, Interface_Component
    {
        private DateTime selected_date;
        private int groupId_Remove;
        private int eventId_Remove;
        private int restaurantId_Save;

        public PersonalCalendar()
        {
            ComponentFunctions.addComponentToList(this);
            InitializeComponent();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            selected_date = EventCalendar.SelectedDate.Value;
            SessionData.stopTimer();
            refreshComponent();
            SessionData.startTimer();
        }

        private void changeConfirmVisibility()
        {
            TopBar.IsHitTestVisible = false;
            BottomBar.IsHitTestVisible = false;
            EventCalendar.IsHitTestVisible = false;
            UpcomingEventScroll.IsHitTestVisible = false;
            CompleteEventScroll.IsHitTestVisible = false;

            ConfirmRectangle.Visibility = Visibility.Visible;
            ConfirmGrid.Visibility = Visibility.Visible;
            ConfirmText.Visibility = Visibility.Visible;
        }

        private void exitConfirmVisibility()
        {
            ConfirmRectangle.Visibility = Visibility.Hidden;
            ConfirmGrid.Visibility = Visibility.Hidden;
            ConfirmText.Visibility = Visibility.Hidden;

            TopBar.IsHitTestVisible = true;
            BottomBar.IsHitTestVisible = true;
            EventCalendar.IsHitTestVisible = true;
            UpcomingEventScroll.IsHitTestVisible = true;
            CompleteEventScroll.IsHitTestVisible = true;
        }

        public void loadRemove(int groupId, int eventId)
        {
            ConfirmText.Text = "Delete the event?";
            groupId_Remove = groupId;
            eventId_Remove = eventId;

            changeConfirmVisibility();
            YesDelButton.Visibility = Visibility.Visible;
            NoDelButton.Visibility = Visibility.Visible;
        }

        private void exitRemove()
        {
            YesDelButton.Visibility = Visibility.Hidden;
            NoDelButton.Visibility = Visibility.Hidden;
            exitConfirmVisibility();
        }

        public void loadSave(int id)
        {
            ConfirmText.Text = "Save the restaurant?";
            restaurantId_Save = id;

            changeConfirmVisibility();
            YesSaveButton.Visibility = Visibility.Visible;
            NoSaveButton.Visibility = Visibility.Visible;
        }

        private void exitSave()
        {
            YesSaveButton.Visibility = Visibility.Hidden;
            NoSaveButton.Visibility = Visibility.Hidden;
            exitConfirmVisibility();
        }

        public void loadRemove(string groupId, string eventId)
        {
            loadRemove(Int32.Parse(groupId), Int32.Parse(eventId));
        }

        public void loadSave(string id)
        {
            loadSave(Int32.Parse(id));
        }

        public void refreshComponent()
        {
            UpcomingEventControl.ItemsSource = GetObservableCollection.displayUserUpcomingEventDate(selected_date);
            CompleteEventControl.ItemsSource = GetObservableCollection.displayUserCompletedEventDate(selected_date);
        }

        private void YesDelButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Home.removeUserEvent(SessionData.getCurrentUser(), groupId_Remove, eventId_Remove);
            exitRemove();
        }

        private void NoDelButton_Click(object sender, RoutedEventArgs e)
        {
            exitRemove();
        }

        private void YesSaveButton_Click(object sender, RoutedEventArgs e)
        {
            Logic_Home.saveUserRestaurant(SessionData.getCurrentUser(), 0, restaurantId_Save);
            exitSave();
        }

        private void NoSaveButton_Click(object sender, RoutedEventArgs e)
        {
            exitSave();
        }

        private void EventCalendar_Loaded(object sender, RoutedEventArgs e)
        {
            EventCalendar.SelectedDate = DateTime.Now;
        }
    }
}
