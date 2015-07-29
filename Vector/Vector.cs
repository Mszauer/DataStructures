#define DEBUG

namespace Datastructures {
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
            int midIndex = size / 2;
            if (cmp(data[midIndex], value) == -1) {
                //remove left half of list
            }
            else if (cmp(data[midIndex], value) == 1) {
                //remove right half of list
            }
            // TODO: Implement Binary search, return item index
            return -1;
        }

        public void SelectionSort(CompareFunc cmp) {
            // TODO: Implement
        }

        public void InsertionSort(CompareFunc cmp) {
            // TODO: IMplement
        } // Insertion sort

    }
}
