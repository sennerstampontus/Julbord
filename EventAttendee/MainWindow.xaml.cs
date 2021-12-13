using EventAttendee.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace EventAttendee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<CreateAttendee> attendee = new List<CreateAttendee>();

        //Ändras till önskad plats där filen ska sparas.
        public string path = @"C:\\Users\\Kappa\\Documents\\Programing\\C#\\Julbord\\Julbord\\Attendees.txt";




        public MainWindow()
        {
            InitializeComponent();
            if (attendee.Count > 0)
                lvAttendees.ItemsSource = attendee;
            //Task.Run(GetAttendeesAsync);
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                await AddAttendee();
                lvAttendees.ItemsSource = attendee;
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        public async Task AddAttendee()
        {
            CreateAttendee newAttendee = new CreateAttendee { FirstName = tbFirstName.Text, LastName = tbLastName.Text, Email = tbEmail.Text, Allergies = tbAllergies.Text ?? "Inga allergier angivna" };
            //var fileStream = new FileStream("C:\\Users\\Kappa\\Documents\\Programing\\C#\\Julbord\\Julbord\\Attendees.txt", FileMode.OpenOrCreate);

            string person = $"{newAttendee.Id},\n{newAttendee.FullName},\n{newAttendee.Email},\n{newAttendee.Allergies},\n";
            attendee.Add(newAttendee);
            lvAttendees.ItemsSource = attendee;

            if (!File.Exists(path))
            {
                await using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(person);
                }
            }
            else
            {
                await using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(person);
                }
            }

        }

        public async void GetAttendeesAsync()
        {
         
            
        }

        private void btnCupon_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

