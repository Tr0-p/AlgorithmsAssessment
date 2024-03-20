using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using AlgorithmsAssessment;

namespace AlgorithmsAssessment
{
    internal class Program
    {
        private static int MenuHandleAndVerify(string[] menu, IOHandler io)
        {
            (bool, int) choice = (false, 0);

            while (!choice.Item1)
            {
                choice = io.HandleMenu(menu);
            }

            return choice.Item2;
        }

        private static void AscendingAndDescendingOutput(List<int> array, IOHandler io)
        {
            io.WriteColourTextLine("\n\nAscending Order", ConsoleColor.DarkGreen);
            for (int i = 0; i < array.Count; i += 10)
            {
                io.WriteColourTextLine($"Value {i}: {array[i]}", ConsoleColor.Green);
            }
            
            Console.WriteLine();
            
            io.WriteColourTextLine("Ascending Order", ConsoleColor.DarkRed);
            for (int i = array.Count - 1; i >= 0; i -= 10)
            {
                io.WriteColourTextLine($"Value {i}: {array[i]}", ConsoleColor.Red);
            }
        }
        
        public static void Main(string[] args)
        {
            FileHandling fileHandler = new FileHandling();
            IOHandler io = new IOHandler();
            Sorting sort = new Sorting();
            Searching search = new Searching();
            
            string[] arrayOptions = {"Net_1_256", "Net_2_256", "Net_3_256"};
            String[] sortMenu = { "Bubble Sort", "Insertion Sort", "Merge Sort", "Quick Sort" };
            String[] searchMenu = { "Linear Search", "Binary Search" };
            List<int>[] arrays = { fileHandler.ReadFileIntoArray("Net_1_256.txt"), fileHandler.ReadFileIntoArray("Net_2_256.txt"), fileHandler.ReadFileIntoArray("Net_3_256.txt") };
            
            while (true)
            {
                int arrayChosen = MenuHandleAndVerify(arrayOptions, io);
                List<int> arrayToHandle = arrays[arrayChosen];
                List<int> sortedList = arrayToHandle;
                
                int sortOption = MenuHandleAndVerify(sortMenu, io);
                
                switch (sortOption)
                {
                    case 0:
                        io.WriteColourTextLine("\nBubble Sort", ConsoleColor.Blue);
                        sortedList = sort.BubbleSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList, io);
                        break;
                    
                    case 1:
                        io.WriteColourTextLine("\nInsertion Sort", ConsoleColor.Blue);
                        sortedList = sort.InsertionSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList, io);
                        break;
                    
                    case 2:
                        io.WriteColourTextLine("\nMerge Sort", ConsoleColor.Blue);
                        sortedList = sort.MergeSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList, io);
                        break;
                    
                    case 3:
                        io.WriteColourTextLine("\nQuick Sort", ConsoleColor.Blue);
                        sortedList = sort.QuickSort(arrayToHandle, 0, arrayToHandle.Count - 1);
                        AscendingAndDescendingOutput(sortedList, io);
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
                        (bool, List<int>) linearResults = search.LinearSearch(sortedList, searchValue, true);

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
                                $"Item Not Found!\nNearest Index: {linearResults.Item2[0]}\nNearest Value: {sortedList[linearResults.Item2[0]]}",
                                ConsoleColor.Red);
                        }

                        break;
                    
                    case 1:
                        io.WriteColourTextLine("\nBinary Search Algorithm", ConsoleColor.DarkCyan);
                        (bool, List<int>) binaryResults = search.BinarySearch(sortedList, searchValue);

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
                                $"Item Not Found!\nNearest Index: {binaryResults.Item2[0]}\nNearest Value: {sortedList[binaryResults.Item2[0]]}",
                                ConsoleColor.Red);
                        }

                        break;
                }
            }
        }
    }
}