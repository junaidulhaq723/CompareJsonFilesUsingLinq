using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CompareJsonFilesUsingLinq
{
    public static class GenerateTestData
    {
        public static void GeneratePersons(int count)
        {
            // Create a faker for the Person class
            var personFaker = new Faker<CompareJsonFilesUsingLinq.JsonFileComparison.Models.Person>()
                .RuleFor(p => p.EmailAddress, f => f.Internet.Email())
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)).ToString("yyyy-MM-dd"))
                .RuleFor(p => p.PersonId, f => f.IndexFaker + 1)
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName());

            // Generate a list of 10 persons
            List<CompareJsonFilesUsingLinq.JsonFileComparison.Models.Person> people = personFaker.Generate(count);

            File.WriteAllText("person_feed_"+DateTime.Now.ToString("HH_mm")+".json", JsonSerializer.Serialize(people));

            // Print the generated persons
            foreach (var person in people)
            {
                Console.WriteLine($"PersonId: {person.PersonId}");
                Console.WriteLine($"FirstName: {person.FirstName}");
                Console.WriteLine($"LastName: {person.LastName}");
                Console.WriteLine($"EmailAddress: {person.EmailAddress}");
                Console.WriteLine($"DateOfBirth: {person.DateOfBirth}");
                Console.WriteLine($"PhoneNumber: {person.PhoneNumber}");
                Console.WriteLine();
            }
        }
    }
}
