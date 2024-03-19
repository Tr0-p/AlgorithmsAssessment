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
        public List<int> BubbleSort(List<int> handedArray)
        {
            List<int> array = CloneList(handedArray);
            int arrayIndex = array.Count;

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
                }

                arrayIndex = lastIndex;
            }

            return array;
        }
        
        // Insertion Sort

        public List<int> InsertionSort(List<int> handedArray)
        {
            List<int> array = CloneList(handedArray);

            for (int i = 1; i < array.Count; i++)
            {
                int currentIndex = i;

                while (currentIndex > 0 && array[currentIndex - 1] > array[currentIndex])
                {
                    (array[currentIndex - 1], array[currentIndex]) = (array[currentIndex], array[currentIndex - 1]);
                    currentIndex--;
                }
            }

            return array;
        }
        
        // Merge Sort

        public List<int> MergeSort(List<int> handedArray)
        {
            List<int> array = CloneList(handedArray);

            return MergeSortMethod(array);
        }

        private List<int> MergeSortMethod(List<int> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = array.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                left.Add(array[i]);
            }

            for (int i = middle; i < array.Count; i++)
            {
                right.Add(array[i]);
            }

            left = MergeSortMethod(left);
            right = MergeSortMethod(right);

            return Merge(left, right);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

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
            }
            
            return result;
        }
        
        // Quick Sort
        public List<int> QuickSort(List<int> handedArray, int start, int end)
        {
            List<int> array = CloneList(handedArray);

            return QuickSortMethod(array, start, end);
        }

        private List<int> QuickSortMethod(List<int> array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);

                if (pivot > 1)
                {
                    QuickSortMethod(array, start, pivot - 1);
                }

                if (pivot + 1 < end)
                {
                    QuickSortMethod(array, pivot + 1, end);
                }
            }

            return array;
        }

        private int Partition(List<int> array, int start, int end)
        {
            int pivot = array[start];

            while (true)
            {
                while (array[start] < pivot)
                {
                    start++;
                }

                while (array[end] > pivot)
                {
                    end--;
                }

                if (start < end)
                {
                    if (array[start] == array[end])
                    {
                        return end;
                    }

                    (array[start], array[end]) = (array[end], array[start]);

                }
                else
                {
                    return end;
                }
            }
        }
    }
}