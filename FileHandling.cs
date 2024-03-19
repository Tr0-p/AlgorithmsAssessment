using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmsAssessment
{
    public class FileHandling
    { 
        private string _basePath =
            @"../../NetworkFiles";

        private IOHandler _io = new IOHandler();
        
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

            _io.WriteColourTextLine($"File {path} cannot be found! Maybe check the directory?", ConsoleColor.Red); 
            return new List<int>();
        }
    }
}