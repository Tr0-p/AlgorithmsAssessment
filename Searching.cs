using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAssessment
{
    public class Searching
    {
        // Binary Search

        public (bool, List<int>) BinarySearch(List<int> array, int numberToSearchFor)
        {
            int minimumNumber = 0;
            int maximumNumber = array.Count - 1;

            List<int> indexes = new List<int>();
            bool valueFound = false;

            int closestAbsolute = array.Max();
            int closestIndex = 0;
            
            while (minimumNumber <= maximumNumber)
            {
                int middle = (minimumNumber + maximumNumber) / 2;
                int absoluteValue = Math.Abs(numberToSearchFor - array[middle]);

                if (absoluteValue < closestAbsolute)
                {
                    closestAbsolute = absoluteValue;
                    closestIndex = middle;
                }
                
                if (numberToSearchFor == array[middle])
                {
                    indexes.Add(middle);
                    valueFound = true;
                    int tempMiddle = indexes[0] - 1;

                    while (numberToSearchFor == array[tempMiddle])
                    {
                        indexes.Add(tempMiddle);
                        tempMiddle -= 1;
                    }

                    tempMiddle = indexes[0] + 1;

                    while (numberToSearchFor == array[tempMiddle])
                    {
                        indexes.Add(tempMiddle);
                        tempMiddle += 1;
                    }

                    break;

                } else if (numberToSearchFor < array[middle])
                {
                    maximumNumber = middle - 1;
                }
                else
                {
                    minimumNumber = middle + 1;
                }
            }

            if (!valueFound)
            {
                indexes.Add(closestIndex);
            }
            
            return (valueFound, indexes);

        }
        
        // Linear Search
        public (bool, List<int>) LinearSearch(List<int> array, int numberToSearchFor, bool sorted)
        {
            int closestAbsolute = array.Max();
            int closestIndex = 0;
            List<int> indexes = new List<int>();
            bool found = false;
            
            for(int i = 0; i < array.Count - 1; i++)
            {
                int number = array[i];
                int absoluteValue = Math.Abs(numberToSearchFor - number);

                if (absoluteValue < closestAbsolute)
                {
                    closestAbsolute = absoluteValue;
                    closestIndex = i;
                }

                if (number == numberToSearchFor)
                {
                    indexes.Add(i);
                    found = true;
                }

                if (sorted && number > numberToSearchFor)
                {
                    break;
                }
            }

            if (!found)
            {
                indexes.Add(closestIndex);
            }

            return (found, indexes);
        }
    }
}