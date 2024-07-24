// See https://aka.ms/new-console-template for more information

using CompareJsonFilesUsingLinq;
using GettingStartedWithMongoDb.JsonFileComparison;

Console.WriteLine("Hello, World!");

//GenerateTestData.GeneratePersons(1000);
JsonFileComparisonManager.CompareJsonFiles("person_feed_15_38.json", "person_feed_15_37.json");

