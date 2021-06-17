using System;
using System.Collections;
using System.Collections.Generic;

namespace Vector
{
    internal class InsertionSort : ISorter 
    {
        void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer) {
            //Insertion Sort
            int j;
            K temp;
            for (int i = 1; i <= sequence.Length - 1; i++) {
                temp = sequence[i];
                j = i - 1;
                while (j >= 0 && comparer.Compare(sequence[j], temp) > 0) {
                    sequence[j + 1] = sequence[j];
                    j--;
                }
                sequence[j + 1] = temp;
            }
        }
    }
}