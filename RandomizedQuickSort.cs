namespace Vector
{
    public class RandomizedQuickSort : ISorter
    {
        //**TOFIX**
        void ISorter.Sort<K>(K[] sequence, IComparer<K> comparer) {
            // int low = 0;
            // int high = sequence.Length -1;
            // QuickSort(sequence, low, high);
        }
        /* The main function that implements Quicksort()
            arr[] --> Array to be sorted,
            low --> Starting index,
            high --> Ending index */

        static void QuickSort(K[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);
                // Recursively sort elements before and after partition
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        
        static int partition(K[] arr, int low, int high)
        {
            random(arr, low, high);
            int pivot = arr[high];
        
            int i = (low-1); // index of smaller element
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int tempp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempp;
                }
            }
        
            int tempp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tempp2;
        
            return i + 1;
        }

        static int random(K[] arr, int low, int high)
        {
        
            Random rand = new Random();
            int pivot = rand.Next() % (high - low) + low;
        
            int tempp1 = arr[pivot]; 
            arr[pivot] = arr[high];
            arr[high] = tempp1;
        
            return partition(arr, low, high);
        }
    }
}