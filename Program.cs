using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using AlgorithmsAssessment;

namespace AlgorithmsAssessment
{
    internal class Program
    {
        /// <summary>
        /// Display the menu and verify the input is correct.
        /// </summary>
        /// <param name="menu">Array of strings containing the options.</param>
        /// <param name="io">Pre-Intialised IO Object.</param>
        /// <param name="excludedOption">Any option which cannot be chosen. Not essential.</param>
        /// <returns>The index of the list the user chose.</returns>
        private static int MenuHandleAndVerify(string[] menu, IOHandler io, int excludedOption = -1)
        {
            (bool, int) choice = (false, 0);  // Tuple containing whether it was a successful choice and the choice given.

            while (!choice.Item1)  // Keep running until an option is chosen.
            {
                choice = io.HandleMenu(menu);  // Display the menu and collect the option.
                
                if (choice.Item2 == excludedOption)  // Ensure they haven't chosen an excluded object.
                {
                    io.WriteColourTextLine("This option cannot be chosen at the moment.", ConsoleColor.DarkRed);
                    choice = (false, choice.Item2);
                }
            }

            return choice.Item2;  // Send the option back to the calling point.
        }

        /// <summary>
        /// Output the data in ascending and descending order.
        /// </summary>
        /// <param name="array">The array to display.</param>
        /// <param name="io">Pre-Initialised IO Object.</param>
        private static void AscendingAndDescendingOutput(List<int> array, IOHandler io)
        {
            int jump = 0;  // Every nth value to display.

            switch (array.Count)  // Choose which jump to use depending on array length.
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
            
            // Print out every nth value in Ascending order.
            io.WriteColourTextLine("\n\nAscending Order", ConsoleColor.DarkGreen);
            for (int i = 0; i < array.Count; i += jump)
            {
                io.WriteColourTextLine($"Value {i}: {array[i]}", ConsoleColor.Green);
            }
            
            Console.WriteLine();
            
            // Print out every nth value in Descending order.
            io.WriteColourTextLine("Descending Order", ConsoleColor.DarkRed);
            for (int i = array.Count - 1; i >= 0; i -= jump)
            {
                io.WriteColourTextLine($"Value {i}: {array[i]}", ConsoleColor.Red);
            }
        }
        
        /// <summary>
        /// Merge two seperate lists together.
        /// </summary>
        /// <param name="arrays">A list of lists to merge.</param>
        /// <returns></returns>
        private static List<int> MergeLists(List<List<int>> arrays)
        {
            List<int> mergeArray = new List<int>();  // Create an empty array to merge the values into.

            foreach (List<int> list in arrays)  // Use each list.
            {
                foreach (int number in list)  // Give the number in each list.
                {
                    mergeArray.Add(number);  // Add the number to the mergeArray.
                }
            }

            return mergeArray;
        }
        
        public static void Main(string[] args)
        {
            // Initialize the objects for each created class.
            FileHandling fileHandler = new FileHandling();
            IOHandler io = new IOHandler();
            Sorting sort = new Sorting();
            Searching search = new Searching();
            
            // Initialize each menu aray and an array to store the arrays.
            string[] arrayOptions = {"Net_1_256.txt", "Net_2_256.txt", "Net_3_256.txt", "Net_1_2048.txt", "Net_2_2048.txt", "Net_3_2048.txt", "Merge Two Arrays"};
            String[] sortMenu = { "Bubble Sort", "Insertion Sort", "Merge Sort", "Quick Sort" };
            String[] searchMenu = { "Linear Search", "Binary Search" };
            List<List<int>> arrays = new List<List<int>>();
            
            // Loop through each file name.
            foreach (string fileName in arrayOptions)
            {
                if (fileName.Substring(fileName.Length - 3) == "txt")  // Ensure the option is a txt file.
                {
                    arrays.Add(fileHandler.ReadFileIntoArray(fileName));  // Read each file and put it in the array.
                }
            }
            
            // Create an infinite loop so the program doesn't end.
            while (true)
            {
                // Choose an array to work with (or merge).
                int arrayChosen = MenuHandleAndVerify(arrayOptions, io);
                List<int> arrayToHandle = new List<int>();
                
                // Choose two arrays to merge and proceed with merging them.
                if (arrayChosen == 6)
                {
                    io.WriteColourTextLine("\nChoose the first array to merge.", ConsoleColor.DarkCyan);
                    int arrayOptionOne = MenuHandleAndVerify(arrayOptions, io, 6);
                    
                    io.WriteColourTextLine("\nChoose the second array to merge.", ConsoleColor.DarkCyan);
                    int arrayOptionsTwo = MenuHandleAndVerify(arrayOptions, io, 6);

                    arrayToHandle = MergeLists(new List<List<int>> { arrays[arrayOptionOne], arrays[arrayOptionsTwo] });
                    io.WriteColourTextLine("Successfully merged the two arrays!", ConsoleColor.Green);
                }
                
                // If the array is empty, load the chosen array into the variable.
                if (arrayToHandle.Count == 0)
                {
                    arrayToHandle = arrays[arrayChosen];
                }
                
                (List<int>, int) sortedList = (arrayToHandle, 0);  // Create a variable to store the sorted list.
                
                int sortOption = MenuHandleAndVerify(sortMenu, io);  // Choose a sort.
                
                // Switch between the sort options.
                // Comments for Case 0 apply to all other cases!
                switch (sortOption)
                {
                    case 0:
                        io.WriteColourTextLine("\nBubble Sort", ConsoleColor.Blue);
                        
                        // Sort the list and output it in ascending and descending order.
                        sortedList = sort.BubbleSort(arrayToHandle);
                        AscendingAndDescendingOutput(sortedList.Item1, io); 
                        
                        // Output the number of steps it was recorded to take.
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
                
                // Wait for the user to analyse the results.
                io.WriteColourTextLine("Press any key to continue...", ConsoleColor.Cyan);
                Console.ReadKey();
                
                // Get the user to choose a search algorithm.
                io.WriteColourTextLine("Search for a value...", ConsoleColor.DarkCyan);
                int searchOption = MenuHandleAndVerify(searchMenu, io);
                int searchValue = 0;
                
                // Keep looping until a valid choice is given.
                while (true)
                {
                    try
                    {
                        io.WriteColourText("Value to search for: ", ConsoleColor.Green);
                        searchValue = Int32.Parse(Console.ReadLine());  // Store the chosen value.
                        break;
                    }
                    catch (FormatException e)
                    {
                        // Give the user an error if there is no correct input.
                        io.WriteColourTextLine("\nError: Invalid input given.", ConsoleColor.Red);
                    }
                }
                
                // Switch through each search option.
                // Comments for case 0 apply to all cases.
                switch (searchOption)
                {
                    case 0:
                        // Call the search algorithm.
                        io.WriteColourTextLine("\nLinear Search Algorithm", ConsoleColor.DarkCyan);
                        (bool, List<int>, int) linearResults = search.LinearSearch(sortedList.Item1, searchValue, true);
                        
                        // If they found an item, output all available indexes.
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
                            // If no item was found, output the nearest value and index.
                            io.WriteColourTextLine(
                                $"Item Not Found!\nNearest Index: {linearResults.Item2[0]}\nNearest Value: {sortedList.Item1[linearResults.Item2[0]]}",
                                ConsoleColor.Red);
                        }
                        
                        // Output how many steps it took.
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