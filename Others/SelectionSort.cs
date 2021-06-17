using System;
using System.Collections;
using System.Collections.Generic;

namespace Vector
{
    internal class SelectionSort : ISorter 
    {
      void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer) {
        //selection sort
        for (int i = 0; i < sequence.Length - 1; i++) {// Loop over sequence to move min of unsorted right sub-array
            int min_idx = i; // Find the min index in unsorted array
            for (int j = i + 1; j < sequence.Length; j++) { //loop through sub-array from after i
                if (comparer.Compare(sequence[j], sequence[min_idx]) < 0) { //if j is less than min
                    min_idx = j; //make new min = to j
                }
            }
            // Swap min w/ first
            K temp = sequence[min_idx];
            sequence[min_idx] = sequence[i];
            sequence[i] = temp;
        }
      }//END SORT
    }
}