using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DigitalWhiteboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Load the whiteboard
            Whiteboard.Instance.Initialize();
        }

        public void AgendaStackPanel_AgendaViewLoaded(object sender, RoutedEventArgs e)
        {
            // Convert to StackPanel
            StackPanel s = (StackPanel)sender;

            // Loop through the Agenda data structure and add TextBlocks
            foreach (var day in Whiteboard.Instance.agenda.days)
            {
                // For each day, add the date
                TextBlock dateTB = new TextBlock();
                dateTB.Text = "\n" + day.Key.Date.DayOfWeek.ToString() + ", " + day.Key.Date.Month.ToString() + "/" + day.Key.Date.Day.ToString();

                // Add to stack panel
                s.Children.Add(dateTB);

                // Loop through events on the day and add to the agenda view
                foreach (var cevent in day.Value.events)
                {
                    // For each event, add time and title
                    // For each day, add the date
                    Button timeTB = new Button();
                    timeTB.Content = cevent.startTime.TimeOfDay.ToString() + " - " + cevent.endTime.TimeOfDay.ToString() + "\n" + cevent.title;

                    // Add to stack panel
                    s.Children.Add(timeTB);
                }
            }
        }

        public void NotesStackPanel_NotesViewLoaded(object sender, RoutedEventArgs e)
        {
            // Convert to StackPanel
            StackPanel s = (StackPanel)sender;

            // Loop through the Agenda data structure and add TextBlocks
            foreach (var note in Whiteboard.Instance.notes)
            {
                // < Border BorderThickness = "2" BorderBrush = "#FFFFD700" Background = "#FFFFFFFF" >
                // Add textblock for each note and add a click callback
                Border b = new Border();
                b.BorderBrush = new SolidColorBrush(Colors.Black);
                Thickness bt = new Thickness(1.0);
                b.BorderThickness = bt;
                TextBlock tb = new TextBlock();
                tb.Text = note.text + "\n" + "Reminder: " + note.reminder.TimeOfDay.ToString() + " - " + note.reminder.TimeOfDay.ToString();
                b.Child = tb;
                s.Children.Add(b);
            }
        }

        // Connect to the account
        public void ConnectButton_ButtonClicked(object sender, RoutedEventArgs e)
        {
            Button ConnectButton = (Button)sender;
            if (await SignInCurrentUserAsync())
            {
                ConnectButton.Content = "Disconnect";
            }
        }

        /// <summary>
        /// Signs in the current user.
        /// </summary>
        /// <returns></returns>
        public async bool SignInCurrentUserAsync()
        {
            var token = await AuthenticationHelper.GetTokenForUserAsync();

            if (token == null)
            {
                //
                return false;
            }

            // Fetch the Notes list

            // Fetch all the notes from the notes list

            // 
        }
    }
}
