using EventAttendee.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EventAttendee.Services
{
    internal class AttendeeHandler
    {

        public ObservableCollection<CreateAttendee> attendee = new ObservableCollection<CreateAttendee>();
        
        /// <summary>
        /// AddAttendee metoden tar in filens sökväg tillsammans med inputs från fälten
        /// och lägger till i filen.
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_firstName"></param>
        /// <param name="_lastName"></param>
        /// <param name="_email"></param>
        /// <param name="_allergies"></param>
        /// <returns></returns>
        public async Task AddAttendeeAsync(ItemsControl quickLv, string _path, string _firstName, string _lastName, string _email, string _allergies)
        {
            CreateAttendee newAttendee = new CreateAttendee { FirstName = _firstName.Trim(), LastName = _lastName.Trim(), Email = _email.Trim(), Allergies = _allergies.Trim() };
            if(_allergies == null || _allergies == "")
            {
                newAttendee.Allergies = "Inga allergier angivna";
            }

            string person = $"{newAttendee.Id}, {newAttendee.FirstName}, {newAttendee.LastName}, {newAttendee.Email}, {newAttendee.Allergies}";
            attendee.Add(newAttendee);

            if (!File.Exists(_path))
            {
                await using (StreamWriter sw = File.CreateText(_path))
                {
                    sw.WriteLine(person);
                }
                quickLv.ItemsSource = attendee;
            }
            else
            {
                await using (StreamWriter sw = File.AppendText(_path))
                {
                    sw.WriteLine(person);
                }
            }           
        }

        /// <summary>
        /// <para>GetAttendeesAsync läser in listan från textfilen och lägger till i {<see cref="attendee"/>.}</para>
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patchLV"></param>
        /// <returns></returns>
        public async Task GetAttendeesAsync(string path, ItemsControl patchLV)
        {
            string line;
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(',');
                    attendee.Add(new CreateAttendee { Id = new Guid(parts[0]), FirstName = parts[1], LastName = parts[2], Email = parts[3], Allergies = parts[4] });
                }
            }

             FetchData(patchLV);
        }

        /// <summary>
        /// <para>FetchData metoden används för att gå runt "buggen" att listan inte läses in från start<br></br>
        /// Uppdaterar {<see cref="attendee"/>} med den inlästa listan från textfilen.<br></br>
        /// Och initieras från {<seealso cref="GetAttendeesAsync(string, ItemsControl)"/>} <br></br>
        /// För att helt eliminera försök att skriva ut listan innan hämtning.</para>
        /// <example>
        /// <code>
        ///     if(attendee.Count > 0)
        ///         lvAttendee.ItemsSource = attendee;
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="_patchLv"></param>
        /// <returns></returns>
        private object FetchData(ItemsControl _patchLv)
        {
            _patchLv.ItemsSource = attendee;

            return _patchLv.ItemsSource;
        }

        /// <summary>
        /// <para>DeleteAttendeeAsync<br></br>
        /// Sparar de registreringar som ska vara kvar i en tempList<br></br>
        /// tar bort den gamla filen och ersätter med en ny och korrekt fil.</para>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task DeleteAttendeeAsync(CreateAttendee item, string path)
        {
            string line;

            ObservableCollection<CreateAttendee> tempList = new();

            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(',');
                    if (!item.Id.ToString().Equals(parts[0]))
                    {
                        tempList.Add(new CreateAttendee { Id = new Guid(parts[0]), FirstName = parts[1], LastName = parts[2], Email = parts[3], Allergies = parts[4] });
                    }
                }
            }

            File.Delete(path);

            await using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var atts in tempList)
                {
                    sw.WriteLine($"{atts.Id}, {atts.FirstName}, {atts.LastName}, {atts.Email}, {atts.Allergies}");
                }
            }
        }
    }

}
