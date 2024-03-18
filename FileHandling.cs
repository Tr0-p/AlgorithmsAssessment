using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsAssessment
{
    public class FileHandling
    {
        private string _basePath =
            @"C:\Users\tommi\RiderProjects\AlgorithmsAssessment\AlgorithmsAssessment\NetworkFiles";
        
        public List<int> ReadFileIntoArray(string fileName)
        {
            string path = Path.Combine(_basePath, fileName);
            
            if (File.Exists(path))
            {
                string[] fileLines = File.ReadAllLines(path);
                List<int> allNumbers = new List<int>();
                
                foreach (string number in fileLines)
                {
                    allNumbers.Add(int.Parse(number));
                }

                return allNumbers;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"File {path} cannot be found! Maybe check the directory?");
                Console.ResetColor();

                return new List<int>();
            }
        }
    }
}