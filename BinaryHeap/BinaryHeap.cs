﻿using System;
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
            data.Append(newVal);
            int index = Size - 1;
            while (index > 1) {
                if (cmp(data[index], data[index / 2]) == -1) {
                    T temp = data[index / 2];
                    data[index / 2] = data[index];
                    data[index] = temp;
                }
                else {
                    break;

                }
                index = index / 2;

            }
        }

        public T Dequeue() {
            T temp = data[1];
            data[1] = data[Size - 1];
            data.RemoveAt(Size - 1);
            int index = 1;
            while (index * 2 + 1 < Size && index * 2 < Size) {
                //check left branch
                if (cmp(data[index], data[index * 2]) == -1) {
                    if (cmp(data[index], data[index * 2]) == 0) {
                        return data[index];
                    }
                    index *= 2;
                }
                //check right branch
                else if (cmp(data[index], data[index * 2 + 1]) == -1) {
                    if (cmp(data[index], data[index * 2 + 1]) == 0) {
                        return data[index];
                    }
                    index = index * 2 + 1;
                }
                else {
                    break;
                }
            }
            return data[1]; // Will need to get rid of
        }

        public void Clear() {
            // TODO
            
        }

        public int IndexOf(T search) {
            // TODO
            int index = 1;
            //check versus first number
            if (cmp(data[index], search) == -1) {
                //Check left branch
                if (cmp(data[index], data[index * 2]) == -1) {
                    index *= 2;
                    if (cmp(data[index],search) == 0){
                        return index;
                    }
                }
                //check right branch
                else if (cmp(data[index], data[index * 2 + 1]) == -1) {
                    index = index * 2 + 1;
                    if (cmp(data[index],search) == 0){
                        return index;
                    }
                }
                else if(cmp(data[index],search) == 0){
                    return index;
                }
            }
            return -1;
        }
    }
}
