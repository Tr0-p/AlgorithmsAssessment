using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace AlgorithmsAssessment
{
    public class Sorting
    {
        // Bubble Sort

        public List<int> BubbleSort(List<int> handedArray)
        {
            List<int> array = handedArray.ConvertAll(num => num);
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
        
        // Merge Sort
        
        // Quick Sort
    }
}