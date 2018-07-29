using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWhiteboard
{
    // signed-in user data for Outlook, WunderList and Cortana
    public class User
    {
        public User()
        {
            // Outlook Calendar Data

            // Login to outlook if not already done

            // Pull calendar data from outlook
     
            // Login to wunderlist if not already done
        }
    }

    // Calendar event class containing calendar meetings and events
    public class CalendarEvent
    {
        // Title of the event
        public String title;

        // Start Time of the event
        public DateTime startTime;

        // End Time of the event  
        public DateTime endTime;

        public CalendarEvent(String titleArg, DateTime startTimeArg, DateTime endTimeArg)
        {
            title = titleArg;
            startTime = startTimeArg;
            endTime = endTimeArg;
        }
    }

    // AgendaDay class for showing events for a particular day
    public class AgendaDay
    {
        // Contains an array of calendar events
        public List<CalendarEvent> events;

        // Contains the date represented by the AgendaDay
        public DateTime day;

        public AgendaDay()
        {
            events = new List<CalendarEvent>();
        }
    }

    // Agenda class that contains a chronological view of calendar events
    public class Agenda
    {
        // Create an array of Agenda Days sorted by day
        public SortedList<DateTime, AgendaDay> days;

        // When agenda view initializes, it loads the calendar events from all the calendars associated with the logged-in user
        public Agenda()
        {
            // Initialize days list
            days = new SortedList<DateTime, AgendaDay>();

            // Fetch all calendar events from all calendars of the signed-in user
            FetchAllCalendarEvents();
            
            // 
        }

        // Fetches the calendar events using Outlook REST API and populates the 'days' variable
        public void FetchAllCalendarEvents()
        {
            // Login to Outlook

            // Fetch the calendar events and add to the sorted list
            // Add one for 1 Sep 2018, 1 PM - 2 PM
            CalendarEvent ce = new CalendarEvent("test event 1", new DateTime(2018, 9, 1, 13, 0, 0), new DateTime(2018, 9, 1, 14, 0, 0));
            AgendaDay ad = new AgendaDay();
            ad.events.Add(ce);
            days.Add(new DateTime(2018, 9, 1), ad);

            // Add one for 3 Sep 2018, 5 PM - 7 PM
            ce = new CalendarEvent("test event 2", new DateTime(2018, 9, 3, 17, 0, 0), new DateTime(2018, 9, 3, 18, 0, 0));
            ad = new AgendaDay();
            ad.events.Add(ce);
            days.Add(new DateTime(2018, 9, 3), ad);

        }
    }

    // Note
    public class Note
    {
        // text portion of the note
        public String text;

        // reminder on the note
        public DateTime reminder;
    }

    // Bad code! Do not use!
    public sealed class Whiteboard
    {
        private static Whiteboard instance = null;

        public Agenda agenda;
        public User user;
        public List<Note> notes;
        public Boolean firstFetch;

        private Whiteboard()
        {
            
        }

        public void Initialize()
        {
            // Create the registered user and login to WunderList, Outlook and Cortana
            user = new User();

            // Create the agenda class            
            agenda = new Agenda();

            // Create the notes class
            notes = new List<Note>();

            // Fetches all notes
            firstFetch = false;
            FetchNotes();
        }

        public void FetchNotes()
        {
            // Connect to WunderList

            // Fetch the Notes list

            // Add all notes from the list into notes

            // Note 1: text - test, reminder - 1st Sep, 2018 | 3 pm
            Note n = new Note();
            n.text = "test"; n.reminder = new DateTime(2018, 9, 1, 15, 0, 0);
            notes.Add(n);

            // Note 2: text - test2, reminder - 10th Sep, 2018 | 5 pm
            n = new Note();
            n.text = "test2"; n.reminder = new DateTime(2018, 9, 10, 17, 0, 0);
            notes.Add(n);

            firstFetch = true;
        }

        public static Whiteboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Whiteboard();
                }
                return instance;
            }
        }
    }
}
