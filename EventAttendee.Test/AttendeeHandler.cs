using System;
using System.Collections.Generic;
using System.IO;

namespace EventAttendee.Test
{

    

    internal class AttendeeHandler
    {
        //Byts till önskad målplats
        string filePath = "C:\\Users\\Kappa\\Documents\\Programing\\C#\\Julbord\\Julbord\\test.txt";


        List<Attendee> AttendeeList = new List<Attendee>();
 
        internal List<Attendee> AddToList(Attendee attendee)
        {
            AttendeeList.Add(attendee);
            return AttendeeList;
        }

        internal List<Attendee> RemoveFromList(Attendee attendee)
        {
            AttendeeList.Remove(attendee);
            return AttendeeList;
        }

        internal bool SaveToFile()
        {
            try 
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine($"Test succeeded:{DateTime.Now}");
                }

                return true;
            }
            catch { return false; }
        }
    }
}
