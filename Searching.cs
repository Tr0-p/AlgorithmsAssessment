using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAssessment
{
    public class Searching
    {
        // Binary Search
        
        /// <summary>
        /// Perform a binary search on the array.
        /// </summary>
        /// <param name="array">The list to be searched.</param>
        /// <param name="numberToSearchFor">The value to be searched for</param>
        /// <returns></returns>
        public (bool, List<int>, int) BinarySearch(List<int> array, int numberToSearchFor)
        {
            int minimumNumber = 0;
            int maximumNumber = array.Count - 1;

            List<int> indexes = new List<int>();
            bool valueFound = false;

            int closestAbsolute = array.Max();
            int closestIndex = 0;

            int steps = 0;
            
            while (minimumNumber <= maximumNumber)  // Ensure the min is smaller than the max.
            {
                int middle = (minimumNumber + maximumNumber) / 2;  // Get the middle of the section.
                int absoluteValue = Math.Abs(numberToSearchFor - array[middle]);  // Get how close the number is to the item.

                if (absoluteValue < closestAbsolute)
                {
                    closestAbsolute = absoluteValue;
                    closestIndex = middle;
                }
                
                // Check if the number has been found.
                if (numberToSearchFor == array[middle])
                {
                    indexes.Add(middle);  // Add it to the index list.
                    valueFound = true;
                    int tempMiddle = indexes[0] - 1;
                    
                    // Check if there is any more numbers to the left of the found item.
                    while (numberToSearchFor == array[tempMiddle])
                    {
                        indexes.Add(tempMiddle);
                        tempMiddle -= 1;

                        steps += 1;
                    }

                    tempMiddle = indexes[0] + 1;
                    
                    // Check if there is any more items to the right of the found item.
                    while (numberToSearchFor == array[tempMiddle])
                    {
                        indexes.Add(tempMiddle);
                        tempMiddle += 1;

                        steps += 1;
                    }

                    break;
                    
                } else if (numberToSearchFor < array[middle])
                {
                    maximumNumber = middle - 1;  // Move the maximum number down.
                }
                else
                {
                    minimumNumber = middle + 1;  // Move the minimum number up.
                }

                steps += 1;
            }

            if (!valueFound)  // If the value isn't found, add the closest number to the list.
            {
                indexes.Add(closestIndex);
            }
            
            return (valueFound, indexes, steps);

        }
        
        // Linear Search
        /// <summary>
        /// Search through item by item.
        /// </summary>
        /// <param name="array">The array to search.</param>
        /// <param name="numberToSearchFor">The value we are searching for.</param>
        /// <param name="sorted">Whether the array is sorted or not.</param>
        /// <returns></returns>
        public (bool, List<int>, int) LinearSearch(List<int> array, int numberToSearchFor, bool sorted)
        {
            int closestAbsolute = array.Max();  // Stores how close the value is.
            int closestIndex = 0;  // Stores where the value is.
            List<int> indexes = new List<int>();
            bool found = false;

            int steps = 0;
            
            for(int i = 0; i < array.Count - 1; i++)  // Loop through each item.
            {
                int number = array[i];
                int absoluteValue = Math.Abs(numberToSearchFor - number);  // How close the item is to the search item.

                if (absoluteValue < closestAbsolute)
                {
                    // If the absolute is smaller, store the index.
                    closestAbsolute = absoluteValue;
                    closestIndex = i;
                }

                if (number == numberToSearchFor)
                {
                    // If the item has been found, add it to the list of indexes.
                    indexes.Add(i);
                    found = true;
                }

                steps += 1;
                
                // If the list is sorted and we are above the number to search for, break.
                if (sorted && number > numberToSearchFor)
                {
                    break;
                }
            }

            if (!found) // If the item has not been found, add the closest index to the list.
            {
                indexes.Add(closestIndex);
            }

            return (found, indexes, steps);
        }
    }
}