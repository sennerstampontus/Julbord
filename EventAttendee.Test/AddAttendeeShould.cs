using Xunit;

namespace EventAttendee.Test
{
    public class AddAttendeeShould
    {
        private AttendeeHandler _sut = new AttendeeHandler();

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
            //Prep
            var _attendee = new Attendee() { Id = System.Guid.NewGuid(), FirstName = "Pontus", LastName = "Sennerstam", Email = "pontus@domain.com", Allergies = "Inga angivna" };
            _sut.AddToList(_attendee);

            //Act
            bool isSaved = _sut.SaveToFile();

            //Assert
            Assert.True(isSaved);     
        }
    }
}