using CompareJsonFilesUsingLinq.JsonFileComparison.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GettingStartedWithMongoDb.JsonFileComparison
{
    public static class JsonFileComparisonManager
    {
        //Create a method to read the JSON file as Person objects and compare the data
        public static void CompareJsonFiles(string newFileName,string oldFileName)
        {
            //Read the JSON files and convert them to Person objects
            IEnumerable<Person> newFile = ReadJsonFile(newFileName);
            IEnumerable<Person> existingFile = ReadJsonFile(oldFileName);


            Console.WriteLine("Are both files same : {0}", newFile.Intersect(existingFile).Count() == existingFile.Count());
            //Compare the data in the two lists of Person objects
            IEnumerable<Person> newPersonsFound = GetNewPersons(newFile, existingFile);
            IEnumerable<Person> missingPersons = GetMissingPersons(newFile, existingFile);

            Console.WriteLine("New Persons : {0}", newPersonsFound.Count());
            Console.WriteLine("Missing Persons : {0}", missingPersons.Count());
        }
        //create implementation of ReadJsonFile method
        private static IEnumerable<Person> ReadJsonFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            //Read the JSON file and convert it to a list of Person objects
            IEnumerable<Person>? patientsFeed = JsonSerializer.Deserialize<IEnumerable<Person>>(jsonString);

            //Add code to read the JSON file and convert it to a list of Person objects
            return patientsFeed ?? [];
        }

               

        private static IEnumerable<Person> GetNewPersons(IEnumerable<Person> newPersons, IEnumerable<Person> existingPersons)
        {
            if (newPersons == null || !newPersons.Any()){
                return [];
            }
                //Compare the data in the two lists of Person objects
            if (existingPersons == null)
            {
                return newPersons;
            }

            return newPersons.Except(existingPersons);
        }

        private static IEnumerable<Person> GetMissingPersons(IEnumerable<Person> newPersons, IEnumerable<Person> existingPersons)
        {
            if (newPersons == null )
            {
                return existingPersons;
            }
            //Compare the data in the two lists of Person objects
            if (existingPersons == null || !existingPersons.Any())
            {
                return [];
            }

            return existingPersons.Except(newPersons);
        }



    }
}
