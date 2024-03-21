using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using AlgorithmsAssessment;

namespace AlgorithmsAssessment
{
    internal class Program
    {
        private static int MenuHandleAndVerify(string[] menu, IOHandler io, int excludedOption = -1)
        {
            (bool, int) choice = (false, 0);

            while (!choice.Item1)
            {
                choice = io.HandleMenu(menu);
                
                if (choice.Item2 == excludedOption)
                {
                    io.WriteColourTextLine("This option cannot be chosen at the moment.", ConsoleColor.DarkRed);
                    choice = (false, choice.Item2);
                }
            }

            return choice.Item2;
        }

        private static void AscendingAndDescendingOutput(List<int> array, IOHandler io)
        {
            int jump = 0;

            switch (array.Count)
            {
                case 2048:
                    jump = 50;
                    break;
                
                case 4096:
                    jump = 50;
                    break;
                
                default:
                    jump = 10;
                    break;
                
            } 
            
            io.WriteColourTextLine("\n\nAscending Order", ConsoleColor.DarkGreen);
            for (int i = 0; i < array.Count; i += jump)
            {
                io.WriteColourTextLine($"Value {i}: {array[i]}", ConsoleColor.Green);
            }
            
            Console.WriteLine();
            
            io.WriteColourTextLine("Descending Order", ConsoleColor.DarkRed);
            for (int i = array.Count - 1; i >= 0; i -= jump)
            {
                io.WriteColourTextLine($"Value {i}: {array[i]}", ConsoleColor.Red);
            }
        }

        private static List<int> MergeLists(List<List<int>> arrays)
        {
            List<int> mergeArray = new List<int>();

            foreach (List<int> list in arrays)
            {
                foreach (int number in list)
                {
                    mergeArray.Add(number);
                }
            }

            return mergeArray;
        }
        
        public static void Main(string[] args)
        {
            FileHandling fileHandler = new FileHandling();
            IOHandler io = new IOHandler();
            Sorting sort = new Sorting();
            Searching search = new Searching();
            
            string[] arrayOptions = {"Net_1_256.txt", "Net_2_256.txt", "Net_3_256.txt", "Net_1_2048.txt", "Net_2_2048.txt", "Net_3_2048.txt", "Merge Two Arrays"};
            String[] sortMenu = { "Bubble Sort", "Insertion Sort", "Merge Sort", "Quick Sort" };
            String[] searchMenu = { "Linear Search", "Binary Search" };
            List<List<int>> arrays = new List<List<int>>();

            foreach (string fileName in arrayOptions)
            {
                if (fileName.Substring(fileName.Length - 3) == "txt")
                {
                    arrays.Add(fileHandler.ReadFileIntoArray(fileName));
                }
            }
            
            while (true)
            {
                int arrayChosen = MenuHandleAndVerify(arrayOptions, io);
                List<int> arrayToHandle = new List<int>();
                
                if (arrayChosen == 6)
                {
                    io.WriteColourTextLine("\nChoose the first array to merge.", ConsoleColor.DarkCyan);
                    int arrayOptionOne = MenuHandleAndVerify(arrayOptions, io, 6);
                    
                    io.WriteColourTextLine("\nChoose the second array to merge.", ConsoleColor.DarkCyan);
                    int arrayOptionsTwo = MenuHandleAndVerify(arrayOptions, io, 6);

                    arrayToHandle = MergeLists(new List<List<int>> { arrays[arrayOptionOne], arrays[arrayOptionsTwo] });
                    io.WriteColourTextLine("Successfully merged the two arrays!", ConsoleColor.Green);
                }

                if (arrayToHandle.Count == 0)
                {
                    arrayToHandle = arrays[arrayChosen];
                }
                
                (List<int>, int) sortedList = (arrayToHandle, 0);
                
                int sortOption = MenuHandleAndVerify(sortMenu, io);
                
                switch (sortOption)
                {
                    case 0:
                        io.WriteColourTextLine("\nBubble Sort", ConsoleColor.Blue);
                        sortedList = sort.BubbleSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList.Item1, io);
                        io.WriteColourTextLine($"Steps: {sortedList.Item2}", ConsoleColor.Green);
                        break;
                    
                    case 1:
                        io.WriteColourTextLine("\nInsertion Sort", ConsoleColor.Blue);
                        sortedList = sort.InsertionSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList.Item1, io);
                        io.WriteColourTextLine($"Steps: {sortedList.Item2}", ConsoleColor.Green);
                        break;
                    
                    case 2:
                        io.WriteColourTextLine("\nMerge Sort", ConsoleColor.Blue);
                        sortedList = sort.MergeSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList.Item1, io);
                        io.WriteColourTextLine($"Steps: {sortedList.Item2}", ConsoleColor.Green);
                        break;
                    
                    case 3:
                        io.WriteColourTextLine("\nQuick Sort", ConsoleColor.Blue);
                        sortedList = sort.QuickSort(arrayToHandle, 0, arrayToHandle.Count - 1);
                        AscendingAndDescendingOutput(sortedList.Item1, io);
                        io.WriteColourTextLine($"Steps: {sortedList.Item2}", ConsoleColor.Green);
                        break;
                }
                
                io.WriteColourTextLine("Press any key to continue...", ConsoleColor.Cyan);
                Console.ReadKey();
                io.WriteColourTextLine("Search for a value...", ConsoleColor.DarkCyan);
                int searchOption = MenuHandleAndVerify(searchMenu, io);
                int searchValue = 0;
                
                while (true)
                {
                    try
                    {
                        io.WriteColourText("Value to search for: ", ConsoleColor.Green);
                        searchValue = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        io.WriteColourTextLine("\nError: Invalid input given.", ConsoleColor.Red);
                    }
                }
                
                switch (searchOption)
                {
                    case 0:
                        io.WriteColourTextLine("\nLinear Search Algorithm", ConsoleColor.DarkCyan);
                        (bool, List<int>, int) linearResults = search.LinearSearch(sortedList.Item1, searchValue, true);

                        if (linearResults.Item1)
                        {
                            io.WriteColourTextLine("Item Found!\nLocation(s): ", ConsoleColor.Green);

                            foreach (int index in linearResults.Item2)
                            {
                                io.WriteColourTextLine(index.ToString(), ConsoleColor.Green);
                                
                            }
                        }
                        else
                        {
                            io.WriteColourTextLine(
                                $"Item Not Found!\nNearest Index: {linearResults.Item2[0]}\nNearest Value: {sortedList.Item1[linearResults.Item2[0]]}",
                                ConsoleColor.Red);
                        }
                        
                        io.WriteColourTextLine($"Steps: {linearResults.Item3}", ConsoleColor.Green);

                        break;
                    
                    case 1:
                        io.WriteColourTextLine("\nBinary Search Algorithm", ConsoleColor.DarkCyan);
                        (bool, List<int>, int) binaryResults = search.BinarySearch(sortedList.Item1, searchValue);

                        if (binaryResults.Item1)
                        {
                            io.WriteColourTextLine("Item Found!\nLocation(s): ", ConsoleColor.Green);

                            foreach (int index in binaryResults.Item2)
                            {
                                io.WriteColourTextLine(index.ToString(), ConsoleColor.Green);
                                
                            }
                        }
                        else
                        {
                            io.WriteColourTextLine(
                                $"Item Not Found!\nNearest Index: {binaryResults.Item2[0]}\nNearest Value: {sortedList.Item1[binaryResults.Item2[0]]}",
                                ConsoleColor.Red);
                        }
                        
                        io.WriteColourTextLine($"Steps: {binaryResults.Item3}", ConsoleColor.Green);

                        break;
                }
            }
        }
    }
}