using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsAssessment
{
    public class FileHandling
    {
        private readonly string _basePath = @"../../NetworkFiles";  // Store the base pathway of the Net Files.

        private readonly IOHandler _io = new IOHandler();  // Initialize the IO Handler.

        /// <summary>
        /// Read the file into a List.
        /// </summary>
        /// <param name="fileName">The name of the file to read.</param>
        /// <returns>A list of all </returns>
        public List<int> ReadFileIntoArray(string fileName)
        {
            var path = Path.Combine(_basePath, fileName);  // Combine the base path with the fileName.

            if (File.Exists(path))  // Ensure the pathway exists.
            {
                var fileLines = File.ReadAllLines(path);
                var allNumbers = new List<int>();  // Create an array to store all the numbers.
                
                // Loop through each value and convert it to a number.
                foreach (var number in fileLines) allNumbers.Add(int.Parse(number));

                return allNumbers;
            }
            
            // If the pathway cannot be found, tell the user.
            _io.WriteColourTextLine($"File {path} cannot be found! Maybe check the directory?", ConsoleColor.Red);
            return new List<int>();
        }
    }
}