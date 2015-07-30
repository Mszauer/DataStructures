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
            return -1;
        }
    }
}
