#define DEBUG
using System;

namespace DataStructures {
    class Vector<T> {
        // if (left > right) return 1;
        // if (left < right) return -1
        // if (left == right) return 0;
        public delegate int CompareFunc(T left, T right);


        T[] data;
        int size;
        int capacity;

        public Vector() {
            data = null;
            size = 0;
            capacity = 0;
        }

        public int Size {
            get {
                return size;
            }
        }

        public int Capacity {
            get {
                return capacity;
            }
        }

        // Overloading the [] operator to allow for access like an array
        public T this[int index] {
            get {

                return data[index];
            }
            set {
                data[index] = value;
            }
        }
        public void AddRange(T[] input) {
            Reserve(size + input.Length);
            Array.Copy(input, 0, data, Size,input.Length);
            size += input.Length;
        }

        public void Append(T newData) {

            if (capacity == 0) {
                capacity = 1;
                data = new T[capacity];
            }
            if (size == capacity) {
                T[] _data = new T[capacity * 2];
                for (int i = 0; i < capacity; i++) {
                    _data[i] = data[i];

                }
                data = new T[capacity * 2];
                for (int i = 0; i < size; i++) {
                    data[i] = _data[i];

                }
                capacity = capacity * 2;
            }
            data[size] = newData;
            size++;
        }

        public void Reserve(int requestedCapacity) {
            if (requestedCapacity > capacity) {
                T[] _data = new T[requestedCapacity];

                for (int i = 0; i < size; i++) {
                    _data[i] = data[i];
                }
                capacity = requestedCapacity;
                data = _data;
            }
        }

        public void Clear() {
            data = null;
            size = 0;
            capacity = 0;
             
        }

        public void RemoveAt(int requestedIndex) {
            for (int i = 0; i < size;i++ ) {
                if (i >= requestedIndex) {
                    if (i < size - 1) {
                        data[i] = data[i + 1];
                    }
                    else {
                        data[i] = default(T);
                    }
                }
            }
            size--;
        }

        public void BubbleSort(CompareFunc cmp) {
            int n = size;
            for (int j = 0; j < n; j++) {
                for (int i = 0; i < n; i++) {
                    if (i + 1 != n) {
                        if (cmp(data[i], data[i + 1]) == 1) {
                            T _temp = data[i + 1];
                            data[i + 1] = data[i];
                            data[i] = _temp;
                        }
                    }
                }
                n--;
            }
        }

        // Searches for value in the data array. if value is contained in the array
        // the index of value is returned. If it is not, -1 is returned.
        // The Vector MUST be sorted for this to work
        public int BinarySearch(T value, CompareFunc cmp) {
            int min = 0;
            int max = size;
            int midIndex = (max-min) / 2;
                if (cmp(data[midIndex], value) == -1) {
                    //look only at > midIndex
                    min = midIndex + 1;
                    midIndex = min + ((max - min) / 2);
                }
                else if (cmp(data[midIndex], value) == 1) {
                    //look only at <midIndex
                    max = midIndex - 1;
                    midIndex = (max - min) / 2;
                }
                else if (cmp(data[midIndex], value) == 0) {
                    return midIndex;
                }
            if (cmp(data[midIndex], value) == 0) {
                return midIndex;
            }
            return -1;
        }

        public void SelectionSort(CompareFunc cmp) {
            //iterations of loop through array (as many times as there are elements)
            for (int i = 0; i < size; i++) {
                //sorted is the amount of things we have sorted (should be same as the amount of times we looped)
                int sorted = i;
                //the place we start at, same as i because we start after sorted elements
                int indexOfMin = i;
                //loop through each element
                for (int j = i; j < size; j++) {
                    //if  min is greater than next element, set min to next element
                    if (cmp(data[indexOfMin], data[j]) == 1) {
                        indexOfMin = j;
                    }
                }
                //swap
                T temp = data[sorted];
                data[sorted] = data[indexOfMin];
                data[indexOfMin] = temp;
            }
        }

        public void InsertionSort(CompareFunc cmp) {
            //create unsorted list
            T[] unsorted = new T[size];
            //copy unsorted values to unsorted list
            for (int q = 0; q < size; q++) {
                unsorted[q] = data[q];
            }
            //create size of sorted list
            int sortedSize = 0;
            //loop through unsorted list
            for (int i = 0; i < size; i++) {
                //if not first index, copy then sort
                if (i != 0) {
                    unsorted[i] = data[i];
                    //loop thorough sorted list
                    for (int j = 0 ; j < sortedSize ; j++){
                        //if value to the left is greater than input value, move value left
                        if (cmp(data[j],data[i]) == 1) {
                            T temp = data[i];
                            data[i] = data[j];
                            data[j] = temp;
                        }
                    }
                }
                else {
                    //add first element
                    unsorted[i] = data[i];
                }
                sortedSize++;
            }
        } // Insertion sort

    }
}
