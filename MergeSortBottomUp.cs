// namespace Vector
// {
//     public class MergeSortBottomUp : ISorter
//     {
        
//     }
// }


//A Bottom-Up (Nonrecursive) Merge-Sort
//12.1.5 Java 6 p.561
//  /∗∗ Merges in[start..start+inc−1] and in[start+inc..start+2∗inc−1] into out. ∗/
2 public static <K> void merge(K[ ] in, K[ ] out, Comparator<K> comp,
3 int start, int inc) {
4 int end1 = Math.min(start + inc, in.length); // boundary for run 1
5 int end2 = Math.min(start + 2 ∗ inc, in.length); // boundary for run 2
6 int x=start; // index into run 1
7 int y=start+inc; // index into run 2
8 int z=start; // index into output
9 while (x < end1 && y < end2)
10 if (comp.compare(in[x], in[y]) < 0)
11 out[z++] = in[x++]; // take next from run 1
12 else
13 out[z++] = in[y++]; // take next from run 2
14 if (x < end1) System.arraycopy(in, x, out, z, end1 − x); // copy rest of run 1
15 else if (y < end2) System.arraycopy(in, y, out, z, end2 − y); // copy rest of run 2
16 }

// 17 /∗∗ Merge-sort contents of data array. ∗/
18 public static <K> void mergeSortBottomUp(K[ ] orig, Comparator<K> comp) {
19 int n = orig.length;
20 K[ ] src = orig; // alias for the original
21 K[ ] dest = (K[ ]) new Object[n]; // make a new temporary array
22 K[ ] temp; // reference used only for swapping
23 for (int i=1; i < n; i ∗= 2) { // each iteration sorts all runs of length i
24 for (int j=0; j < n; j += 2∗i) // each pass merges two runs of length i
25 merge(src, dest, comp, j, i);
26 temp = src; src = dest; dest = temp; // reverse roles of the arrays
27 }
28 if (orig != src)
29 System.arraycopy(src, 0, orig, 0, n); // additional copy to get result to original
30 }




//p.559
//LINKED LIST IMPLEMENTATION
// 1 /∗∗ Merge contents of sorted queues S1 and S2 into empty queue S. ∗/
// 2 public static <K> void merge(Queue<K> S1, Queue<K> S2, Queue<K> S,
// 3 Comparator<K> comp) {
// 4 while (!S1.isEmpty( ) && !S2.isEmpty( )) {
// 5 if (comp.compare(S1.first( ), S2.first( )) < 0)
// 6 S.enqueue(S1.dequeue( )); // take next element from S1
// 7 else
// 8 S.enqueue(S2.dequeue( )); // take next element from S2
// 9 }
// 10 while (!S1.isEmpty( ))
// 11 S.enqueue(S1.dequeue( )); // move any elements that remain in S1
// 12 while (!S2.isEmpty( ))
// 13 S.enqueue(S2.dequeue( )); // move any elements that remain in S2
// 14 }
// 15
// 16 /∗∗ Merge-sort contents of queue. ∗/
// 17 public static <K> void mergeSort(Queue<K> S, Comparator<K> comp) {
// 18 int n = S.size( );
// 19 if (n < 2) return; // queue is trivially sorted
// 20 // divide
// 21 Queue<K> S1 = new LinkedQueue<>( ); // (or any queue implementation)
// 22 Queue<K> S2 = new LinkedQueue<>( );
// 23 while (S1.size( ) < n/2)
// 24 S1.enqueue(S.dequeue( )); // move the first n/2 elements to S1
// 25 while (!S.isEmpty( ))
// 26 S2.enqueue(S.dequeue( )); // move remaining elements to S2
// 27 // conquer (with recursion)
// 28 mergeSort(S1, comp); // sort first half
// 29 mergeSort(S2, comp); // sort second half
// 30 // merge results
// 31 merge(S1, S2, S, comp); // merge sorted halves back into original
// 32 }