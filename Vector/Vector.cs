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
                return 0;
            }
        }

        public int Capacity {
            get {
                // TODO: return the capacity of the vector
                return 0;
            }
        }

        // Overloading the [] operator to allow for access like an array
        public T this[int index] {
            get {
                // TODO: Return the element deom data at index
                return default(T);
            }
            set {
                // TODO: set element at index to Value
            }
        }

        public void Append(T newData) {
            // TODO
            // If the capacity of the data is 0, you are going to have to make a new array
            // if size == capacity, you are going to have to make a new array
            // whenever you make a new array, make it 2X the size. That way you will have
            // ample space. data = new T[size * 2]. Also, copy the data from the old one
            // Dont forget to update the size and capacity variables
        }

        public void Reserve(int requestedCapacity) {
            // If the requested capacity is greater than the current capacity, increase
            // the current capacity to the requested capacity by ceateing a new array
            // dont forget to copy the old data!
        }

        public void Clear() {
            // Essentially a reset function, hold no data, with 0 size and capacity
        }
    }
}
