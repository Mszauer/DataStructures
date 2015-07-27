#define DEBUG

namespace Datastructures {
    class Vector<T> {
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
                // TODO: return the size of the vector
                return size;
            }
        }

        public int Capacity {
            get {
                // TODO: return the capacity of the vector
                return capacity;
            }
        }

        // Overloading the [] operator to allow for access like an array
        public T this[int index] {
            get {
                // TODO: Return the element from data at index
                return data[index];
            }
            set {
                // TODO: set element at index to Value
                data[index] = value;
            }
        }

        public void Append(T newData) {
            // TODO
            // If the capacity of the data is 0, you are going to have to make a new array
            // if size == capacity, you are going to have to make a new array
            // whenever you make a new array, make it 2X the size. That way you will have
            // ample space. data = new T[size * 2]. Also, copy the data from the old one
            // Dont forget to update the size and capacity variables
            if (capacity == 0) {
                data = new T[capacity];
            }
            if (size == capacity) {
                T[] _data = new T[capacity * 2];
                for (int i = 0; i < capacity; i++) {
                    _data[i] = data[i];
                }
                data = new T[capacity * 2];
                for (int i = 0; i < _data.Length; i++) {
                    data[i] = _data[i];

                }
                size = data.Length;
                capacity = capacity * 2;
            }
        }

        public void Reserve(int requestedCapacity) {
            // If the requested capacity is greater than the current capacity, increase
            // the current capacity to the requested capacity by ceateing a new array
            // dont forget to copy the old data!
            /*
            T[] _data = new T[requestedCapacity];
            if (requestedCapacity > capacity) {
                for (int i = 0; i < data.Length; i++) {
                    _data[i] = data[i];
                }
            }
            capacity = requestedCapacity;
             */
        }

        public void Clear() {
            // Essentially a reset function, hold no data, with 0 size and capacity
            /*
            for (int i = 0; i < data.Length; i++) {
                data[i] = default(T);
            }
            size = 0;
            capacity = 0;
             */
        }
    }
}
