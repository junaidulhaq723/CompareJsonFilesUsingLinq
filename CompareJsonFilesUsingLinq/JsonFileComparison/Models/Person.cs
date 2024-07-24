using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompareJsonFilesUsingLinq.JsonFileComparison.Models
{
    public class Person
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Person other = (Person)obj;

            return PersonId == other.PersonId &&
                   EmailAddress == other.EmailAddress &&
                   DateOfBirth == other.DateOfBirth &&
                   LastName == other.LastName &&
                   PhoneNumber == other.PhoneNumber &&
                   FirstName == other.FirstName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PersonId, EmailAddress, DateOfBirth, LastName, PhoneNumber, FirstName);
          
          
        }
    }
}
