using System;
using System.Collections.Generic;
using System.IO;

namespace EventAttendee.Test
{

    internal class AttendeeHandler
    {

        List<Attendee> AttendeeList = new List<Attendee>();

        /// <summary>
        /// AddToList ska helt enkelt lägga till "attendee" i listan.
        /// </summary>
        /// <param name="attendee"></param>
        /// <returns></returns>
        internal List<Attendee> AddToList(Attendee attendee)
        {
            AttendeeList.Add(attendee);
            return AttendeeList;
        }

        /// <summary>
        /// RemoveFromList har som uppgift att plocka bort en "attendee" från listan.
        /// </summary>
        /// <param name="attendee"></param>
        /// <returns></returns>
        internal List<Attendee> RemoveFromList(Attendee attendee)
        {
            AttendeeList.Remove(attendee);
            return AttendeeList;
        }

        /// <summary>
        /// SaveToFile testar om textfilen skapats.
        /// </summary>
        /// <returns></returns>
        internal bool SaveToFile(string filePath)
        {

            try
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine($"Test succeeded:{DateTime.Now}");
                }

                if (File.Exists(filePath))
                {
                    return true;
                }
            }
            catch { return false; }
            return false;
        }

        /// <summary>
        /// ReadFromFile testar om den kan läsa in vad som skrivits i textfilen.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal string ReadFromFile(string filePath)
        {
            string line;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    line = sr.ReadLine();
                }

                return line;
            }
            catch { return "Couldn't read file.."; }
        }
    }   
}