using EventAttendee.Models;
using EventAttendee.Services;
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

        
        private AttendeeHandler _atts = new AttendeeHandler();
        
        //Ändras till önskad plats där filen ska sparas.
        public string path = @"C:\Users\Kappa\Documents\Programing\C#\Julbord\Julbord\Attendees.txt";

        

   
        public MainWindow()
        {
            InitializeComponent();

            // See info om GetAttendeesAsync i summary
            Task.FromResult(_atts.GetAttendeesAsync(path, lvAttendees)); 
        }
        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                // See info om AddAttendeeAsync i summary
                await _atts.AddAttendeeAsync(path, tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbAllergies.Text);
            }
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbAllergies.Text = "";
        }

        private void btnCupon_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (CreateAttendee)obj.DataContext;
            _atts.attendee.Remove(item);

            // See info om DeletAttendeeAsync i summary
            await _atts.DeleteAttendeeAsync(item, path);
        }
    }
}

