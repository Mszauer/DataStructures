using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures {
    class BinaryHeap<T> {
        public delegate int CompareFunc(T left, T right);

        private Vector<T> data = null;
        CompareFunc cmp = null;

        public int Size {
            get {
                return data.Size;
            }
        }

        public T this[int index] {
            get {
                return data[index];
            }
        }

        public BinaryHeap(CompareFunc compare) {
            data = new Vector<T>();
            data.Append(default(T)); // Trash into the first element
            cmp = compare;
        }

        public void Enqueue(T newVal) {
            // TODO: IMPLEMENT
            data.Append(newVal);
            int index = Size - 1;
            for (int i = 0; i < Size; i++) {
                if (cmp(data[index], data[index / 2]) == -1) {
                    //swap
                    T temp = data[index / 2];
                    data[index / 2] = data[index];
                    data[index] = temp;
                }
                else if (cmp(data[index], data[index / 2]) == 1 || cmp(data[index], data[index / 2]) == 0) {
                    break;
                }
            }
        }

        public T Dequeue() {
            // TODO: Implement
            return default(T); // Will need to get rid of
        }

        public void Clear() {
            // TODO
        }

        public int IndexOf(T search) {
            // TODO
            int index = 1;
            //check versus first number
            if (cmp(data[index], search) == -1) {
                index *= 2;
                if (cmp(data[index], search) == -1) {
                    //go down branch
                    index = (index * 2) + 1;
                    //while index < search / cmp == -1
                }
            }
            return -1;
        }
    }
}
