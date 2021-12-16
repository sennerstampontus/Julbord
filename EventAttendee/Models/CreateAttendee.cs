using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAttendee.Models
{


       public class CreateAttendee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Allergies { get; set; }
        public Guid CreateCupon { get; set; } = Guid.NewGuid();

        public string Cupon => $"Rabattkod:{Id.ToString("N").Substring(0,4)}";

        public string FullName => $"{FirstName} {LastName}";

        public string CuponStatus => "Rabattkupong skickad";
    }
}
