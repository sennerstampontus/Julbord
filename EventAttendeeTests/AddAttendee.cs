using System;

namespace EventAttendeeTests
{
    internal class AddAttendee
    {
       
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Allergies { get; set; }


        
       
    }
}