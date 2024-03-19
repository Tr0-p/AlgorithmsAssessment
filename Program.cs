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
            
            string[] arrayOptions = {"Net_1_256", "Net_2_256", "Net_3_256"};
            String[] sortMenu = { "Bubble Sort", "Insertion Sort", "Merge Sort", "Quick Sort" };
            List<int>[] arrays = { fileHandler.ReadFileIntoArray("Net_1_256.txt"), fileHandler.ReadFileIntoArray("Net_2_256.txt"), fileHandler.ReadFileIntoArray("Net_3_256.txt") };
            
            while (true)
            {
                int arrayChosen = MenuHandleAndVerify(arrayOptions, io);
                List<int> arrayToHandle = arrays[arrayChosen];
            
                int sortOption = MenuHandleAndVerify(sortMenu, io);

                switch (sortOption)
                {
                    case 0:
                        io.WriteColourTextLine("\nBubble Sort", ConsoleColor.Blue);
                        List<int> bubbleSortedList = sort.BubbleSort(arrayToHandle);
                        AscendingAndDescendingOutput(bubbleSortedList, io);
                        break;
                    
                    case 1:
                        io.WriteColourTextLine("\nInsertion Sort", ConsoleColor.Blue);
                        List<int> insertionSortedList = sort.InsertionSort(arrayToHandle);
                        AscendingAndDescendingOutput(insertionSortedList, io);
                        break;
                    
                    case 2:
                        io.WriteColourTextLine("\nMerge Sort", ConsoleColor.Blue);
                        List<int> mergeSortedList = sort.MergeSort(arrayToHandle);
                        AscendingAndDescendingOutput(mergeSortedList, io);
                        break;
                    
                    case 3:
                        io.WriteColourTextLine("\nQuick Sort", ConsoleColor.Blue);
                        List<int> quickSortedList = sort.QuickSort(arrayToHandle, 0, arrayToHandle.Count - 1);
                        AscendingAndDescendingOutput(quickSortedList, io);
                        break;
                }
            }
        }
    }
}