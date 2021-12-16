using Xunit;


namespace EventAttendeeTests
{
    public class AddAttendeeShould
    {

        [Fact]
        public void Add_Attendee_To_List()
        {

            //Prep
            

            //Act
            sut.Add();

            //Assert
            
            Assert.True(sut.ContainsAttendee(sut.Attendee));
        
        }
    }
}