using System;
using Xunit;

namespace EventAttendee.Test
{
    public class AddAttendeeShould
    {
        private AttendeeHandler _sut = new AttendeeHandler();
        //Byts till önskad målplats för testfilen
        
        string filePath = "C:\\Users\\Kappa\\Documents\\Programing\\C#\\Julbord\\Julbord\\test.txt";
        
        //

        [Fact]
        public void Add_New_Attendee()
        {
            //Prep
            var _attendee = new Attendee() { Id = System.Guid.NewGuid(), FirstName = "Pontus", LastName = "Sennerstam", Email = "pontus@domain.com", Allergies = "Inga angivna"};

            //Act
            var _addsAttendee = _sut.AddToList(_attendee);

            //Assert
            Assert.NotEmpty(_addsAttendee);
        }

        [Fact]
        public void Remove_New_Attendee()
        {
            //Prep
            var _attendee = new Attendee() { Id = System.Guid.NewGuid(), FirstName = "Pontus", LastName = "Sennerstam", Email = "pontus@domain.com", Allergies = "Inga angivna" };
            _sut.AddToList(_attendee);

            //Act
            var _removedAttendee = _sut.RemoveFromList(_attendee);

            //Assert
            Assert.Empty(_removedAttendee);
        }

        [Fact]
        public void Save_To_File()
        {
            //Act
            bool isSaved = _sut.SaveToFile(filePath);

            //Assert
            Assert.True(isSaved);
        }

        [Fact]
        public void Read_From_File()
        {
            //Prep
            _sut.SaveToFile(filePath);

            //Act
            string isRead= _sut.ReadFromFile(filePath);

            //Assert
            Assert.Equal($"Test succeeded:{DateTime.Now}", isRead);     
        }
    }
}