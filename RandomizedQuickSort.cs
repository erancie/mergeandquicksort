using System;
using System.Collections;
using System.Collections.Generic;

namespace Vector
{
    internal class RandomizedQuickSort : ISorter {
      void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer) {
        //**FIX THIS ENTRY POINT
        Console.WriteLine("QuickSort Run"); 
        int low = (int) Convert.ToInt32(sequence[0]); //cast K to int
        int high = (int) Convert.ToInt32(sequence[sequence.Length -1]); 
        QuickSort(sequence, low, high); 

        static void swapNum(K i, K j) {
                K temp = i;
                i = j;
                j = temp;
        }
        void QuickSort(K[] sequence, int low, int high) {
            if (low < high) {
                int pi = partition(sequence, low, high);
                Console.WriteLine("QUCICKSORT");
                // Recursively sort elements before and after partition
                QuickSort(sequence, low, pi - 1);
                QuickSort(sequence, pi + 1, high);            }
        }
        int partition(K[] sequence, int low, int high) {
            int rand = random(sequence, low, high);//CHECK**
            K pivot = sequence[high]; //pivot
            int i = (low-1); // index of smaller element
            for (int j = low; j < high; j++) {
                if (comparer.Compare(pivot, sequence[j]) < 0) {
                    i++;
                    swapNum(sequence[i], sequence[j]);
                }
            }
            K idx = (K) Convert.ChangeType(i + 1, typeof(K));
            swapNum(idx, sequence[high]);
            return i + 1;
        }
        int random(K[] sequence, int low, int high) {
            Random rand = new Random();
            int pivot = rand.Next() % (high - low) + low;
            K tempp1 = sequence[pivot]; 
            sequence[pivot] = sequence[high];
            sequence[high] = tempp1;
            return partition(sequence, low, high);
        }

      }//end ISorter.Sort<K>

    }//end RQS.IS
}


                //  IComparer.Compare(obj x, obj y) method 
                // - A signed integer that indicates the relative values of x and y:
                // - If less than 0, x is less than y.
                // - If 0, x equals y.
                // - If greater than 0, x is greater than y.



        /* The main function that implements Quicksort()
            arr[] --> Array to be sorted,
            low --> Starting index,
            high --> Ending index */
            
        //COMPARER TESTS
        // Console.WriteLine("Sequence 1: " + sequence[1] + "Sequence 2: " + sequence[2] );
        // int greater = comparer.Compare(sequence[1], sequence[2]);
        // Console.WriteLine("Sequence 1: " + sequence[1] + "Sequence 2: " + sequence[2] );
        // Console.WriteLine("Greater : " + greater );

        //SWAPS

            // int tempp = arr[i];
            // arr[i] = arr[j];
            // arr[j] = tempp;

        // int tempp2 = arr[i + 1];
        // arr[i + 1] = arr[high];
        // arr[high] = tempp2;

        //from ISorter.Sort
        //PUT QUICKSORT CODE HERE???

        //**How to convert K to int for quicksort method?
        // K number = sequence[0] as IComparer<K>;
        // int num = sequence[0].ConvertTo(Int32);  
        // int num = (K)sequence[0];