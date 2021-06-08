using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T> where T : IComparable<T>
    {
        // determines the default number of elements in a new vector.
        // Also extendeds capacity of the existing vector.
        private const int DEFAULT_CAPACITY = 10;

        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer  
        public T this[int index]
        {
            get {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

   
        public void Add(T element)
        {
            if (Count == Capacity) ExtendData(DEFAULT_CAPACITY);
            data[Count++] = element;
        }

        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (data[i].Equals(element)) return i;
            }
            return -1;
        }

        public void Insert(int index, T element) {
            if (index > Count || index < 0) throw new IndexOutOfRangeException(); //check for index inside the range
            if (Count == this.Capacity) ExtendData(DEFAULT_CAPACITY);
            if (index == Count) { this.Add(element); return; } 
            if (index < Count) { //check element is in the REST of the array
                for (int i = Count-1; i >= 0; i--) { 
                    data[i+1] = data[i]; 
                    if (i == index) { 
                        data[i] = element;
                        Count +=1; 
                        return; 
                    }
                }
            }
        }

        public void Clear() {
            for (int i = 0; i < this.Count; i++) {
                data[i] = default(T);
            }
            Count = 0;
        }

        public bool Contains(T element){
            if (this.IndexOf(element) >= 0) return true;
            return false;
        }

        public bool Remove(T element) {
            for (int i = 0; i < this.Count; i++) {
                if (i.Equals(this.IndexOf(element))) {
                    this.RemoveAt(i);
                    return true;
                }
            }
            return false;
            throw new IndexOutOfRangeException();
        }

        // TOFIX: RemoveAt has a mistake. 
        // Make the initial capacity Vector(1) in the test 
        // and make DEFAULT_CAPACITY=1 to test it.

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= Count) {throw new IndexOutOfRangeException();} 
            // T[] newData = new T[data.Length-1];
            for (int j = index; j < data.Length-1; j++) data[j] = data[j+1];
            // for (int i = 0; i < data.Length; i++) newData[i] = data[i];
            // data = newData;
            Count--;
        }

        public override string ToString()
        {
            string vectorString = "["; 
            for (int i = 0; i < Count; i++) { 
                vectorString += data[i]; 
                if (i < Count-1) { 
                    vectorString += ","; 
                }
            }
            vectorString += "]"; 
            return vectorString;
        }

        //------------------------------------
        public ISorter Sorter { set; get; } = new DefaultSorter();
        //change this sorter property in tester to select particular sort object

        internal class DefaultSorter : ISorter
        {
            public void Sort<K>(K[] sequence, IComparer<K> comparer) where K : IComparable<K>
            {
                if (comparer == null) comparer = Comparer<K>.Default;
                Array.Sort(sequence, comparer);
            }
        }

        //are these overloaded?
        public void Sort()
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            Sorter.Sort(data, null);
        }

        public void Sort(IComparer<T> comparer)
        {
            if (Sorter == null) Sorter = new DefaultSorter();
            Array.Resize(ref data, Count);
            if (comparer == null) Sorter.Sort(data, null);
            else Sorter.Sort(data, comparer);
        }
    }
}