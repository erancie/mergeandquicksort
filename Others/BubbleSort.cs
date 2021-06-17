using System;
using System.Collections;
using System.Collections.Generic;

namespace Vector
{
    internal class BubbleSort : ISorter 
    {
        private void Swap<K>(K[] seq, int idx){
            K temp = seq[idx];
            seq[idx] = seq[idx +1];
            seq[idx +1] = temp;
        }
        void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer) //where K : IComparable<K> 
        {
            if (comparer == null) throw new ArgumentNullException("null comparer");

            //bubble sort
            for (int i = 1; i < sequence.Length; i++) { //loop through array from [1]
                int swaps = 0;
                for (int j = 0; j < sequence.Length - i; j++) {
                    //IComparer.Compare method for type K  -> true if 'a' is greater than 'b' -> expressed by > 0
                    if (comparer.Compare(sequence[j],sequence[j+1]) > 0)
                    {   
                        Swap(sequence, j);
                        swaps += 1;
                    }
                }
                if(swaps == 0) break;
            }
        }
    }
}

            //bubble 2

            // for (int i = 0; i < sequence.Length - 1; i++) { 
            //     for (int j = 0; j < sequence.Length - i - 1; j++) {
            //         if (comparer.Compare(sequence[j],sequence[j+1]) > 0)
            //         {   
            //             Swap(sequence, j);
            //         }
            //     }
            // }

