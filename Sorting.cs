using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Xsl;

namespace AlgorithmsAssessment
{
    public class Sorting
    {
        // List Cloning
        private List<int> CloneList(List<int> listToClone)
        {
            return listToClone.ConvertAll(num => num);
        }
        
        // Bubble Sort
        public (List<int>, int) BubbleSort(List<int> handedArray)
        {
            List<int> array = CloneList(handedArray);
            int arrayIndex = array.Count;
            int steps = 0;
            
            
            while (arrayIndex > 0)
            {
                int lastIndex = 0;

                for (int index = 1; index < arrayIndex; index++)
                {
                    if (array[index - 1] > array[index])
                    {
                        (array[index - 1], array[index]) = (array[index], array[index - 1]);
                        lastIndex = index;
                    }

                    steps += 1;
                }

                arrayIndex = lastIndex;
            }

            return (array, steps);
        }
        
        // Insertion Sort

        public (List<int>, int) InsertionSort(List<int> handedArray)
        {
            List<int> array = CloneList(handedArray);
            int steps = 0;

            for (int i = 1; i < array.Count; i++)
            {
                int currentIndex = i;

                while (currentIndex > 0 && array[currentIndex - 1] > array[currentIndex])
                {
                    (array[currentIndex - 1], array[currentIndex]) = (array[currentIndex], array[currentIndex - 1]);
                    currentIndex--;
                    steps += 1;
                }

                steps += 1;
            }

            return (array, steps);
        }
        
        // Merge Sort

        public (List<int>, int) MergeSort(List<int> handedArray)
        {
            List<int> array = CloneList(handedArray);

            return MergeSortMethod(array);
        }

        private (List<int>, int) MergeSortMethod(List<int> array)
        {
            int steps = 0;
            
            if (array.Count <= 1)
            {
                return (array, steps);
            }

            (List<int>, int) left = (new List<int>(), 0);
            (List<int>, int) right = (new List<int>(), 0);

            int middle = array.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Item1.Add(array[i]);
            }

            for (int i = middle; i < array.Count; i++)
            {
                right.Item1.Add(array[i]);
            }

            left = MergeSortMethod(left.Item1);
            right = MergeSortMethod(right.Item1);

            steps += (left.Item2 + right.Item2);

            (List<int>, int) returnValue = Merge(left.Item1, right.Item1);
            
            return (returnValue.Item1, steps + returnValue.Item2);
        }

        private (List<int>, int) Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int steps = 0;
            
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] <= right[0])
                    {
                        result.Add(left[0]);
                        left.Remove(left[0]);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.Remove(right[0]);
                    }
                } else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                } else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.Remove(right[0]);
                }

                steps += 1;
            }
            
            return (result, steps);
        }
        
        // Quick Sort
        public (List<int>, int) QuickSort(List<int> handedArray, int start, int end)
        {
            List<int> array = CloneList(handedArray);

            return QuickSortMethod(array, start, end);
        }

        private (List<int>, int) QuickSortMethod(List<int> array, int start, int end)
        {

            int steps = 0;
            
            if (start < end)
            {
                (int, int) returnValues = Partition(array, start, end);

                steps += returnValues.Item2;
                
                int pivot = returnValues.Item1;
                
                if (pivot > 1)
                {
                    steps += QuickSortMethod(array, start, pivot - 1).Item2;
                }

                if (pivot + 1 < end)
                {
                    steps += QuickSortMethod(array, pivot + 1, end).Item2;
                }
            }

            return (array, steps);
        }

        private (int, int) Partition(List<int> array, int start, int end)
        {
            int pivot = array[start];
            int steps = 0;
            
            while (true)
            {
                while (array[start] < pivot)
                {
                    start++;
                    steps += 1;
                }

                while (array[end] > pivot)
                {
                    end--;
                    steps += 1;
                }

                if (start < end)
                {
                    if (array[start] == array[end])
                    {
                        return (end, steps);
                    }

                    (array[start], array[end]) = (array[end], array[start]);

                }
                else
                {
                    return (end, steps);
                }
            }
        }
    }
}