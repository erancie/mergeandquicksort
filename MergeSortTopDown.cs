using System;
using System.Collections;
using System.Collections.Generic;

namespace Vector
{
    public class MergeSortTopDown : ISorter
    {

      void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer){ //Interface Constructor
        // if (comparer == null) throw new ArgumentNullException("null comparer"); //PUT IN*

        //From DS&A in Java 6 p.555
          //Put these methods in our out of Sort??
          // TODO: CONVERT FROM JAVA TO C#
          // TODO: CHANGE REFERNCES TO TO TYPE K 
          // TODO: USE IComparer
          // *implement array based top down version of 12.1 & 12.2

          //  /∗∗ Merge contents of arrays S1 and S2 into properly sized array S. ∗/
          public static <K> void merge(K[ ] S1, K[ ] S2, K[ ] S, Comparator<K> comparer) {
           int i = 0, j = 0;
           while (i + j < S.length) {
           if (j == S2.length || (i < S1.length && comparer.Compare(S1[i], S2[j]) < 0))
            S[i+j] = S1[i++]; // copy ith element of S1 and increment i
           else
            S[i+j] = S2[j++]; // copy jth element of S2 and increment j
           }
          }

          // /∗∗ Merge-sort contents of array S. ∗/
          public static <K> void mergeSort(K[ ] S, Comparator<K> comp) {
            int n = S.length;
            if (n < 2) return; // array is trivially sorted
            // divide
            int mid = n/2;
            K[ ] S1 = Array.copyOfRange(S, 0, mid); // copy of first half
            K[ ] S2 = Arrays.copyOfRange(S, mid, n); // copy of second half
            // conquer (with recursion)
            mergeSort(S1, comp); // sort copy of first half
            mergeSort(S2, comp); // sort copy of second half
            // merge results
            merge(S1, S2, S, comp); // merge sorted halves back into original
           }




        // to cast K to int
        // int low = (int) Convert.ToInt32(sequence[0]); //cast K to int
        // int high = (int) Convert.ToInt32(sequence[sequence.Length -1]); 


          // ////////// Geeks for Geeks
        // Main function that sorts arr[l..r] using merge()
            // void MergeSort(K[] arr, int l, int r)
            // {
            //     if (l < r) {
            //         // Find the middle point
            //         int m = l+ (r-l)/2;
            //         // Sort first and
            //         // second halves
            //         MergeSort(arr, l, m);
            //         MergeSort(arr, m + 1, r);
        
            //         // Merge the last two sorted halves
            //         Merge(arr, l, m, r);
            //     }
            // }

            // void Merge(K[] arr, int l, int m, int r){
            //   // Find sizes of two subarrays to be merged
            //   int n1 = m - l + 1;
            //   int n2 = r - m;
      
            //   // Create temp arrays
            //   int[] L = new int[n1];
            //   int[] R = new int[n2];
            //   int i, j;
      
            //   // Copy data to temp arrays
            //   for (i = 0; i < n1; ++i)
            //       L[i] = arr[l + i];
            //   for (j = 0; j < n2; ++j)
            //       R[j] = arr[m + 1 + j];
      
            //   // Merge the temp arrays
      
            //   // Initial indexes of first and second subarrays
            //   i = 0;
            //   j = 0;
            //   // Initial index of merged subarry array
            //   int k = l;
            //   while (i < n1 && j < n2) {
            //       if (L[i] <= R[j]) {
            //           arr[k] = L[i];
            //           i++;
            //       }
            //       else {
            //           arr[k] = R[j];
            //           j++;
            //       }
            //       k++;
            //   }
            //   // Copy remaining elements of L[] if any
            //   while (i < n1) {
            //       arr[k] = L[i];
            //       i++;
            //       k++;
            //   }
            //   // Copy remaining elements // of R[] if any
            //   while (j < n2) {
            //       arr[k] = R[j];
            //       j++;
            //       k++;
            //   }
            // }
    



      }


    }
}