using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    class SLinkedList<T> {
        public class Node {
            public T Data;
            public Node Next;
            public void Node (T data, Node next){
                Data = data;
                Next = next;
            }
            
        }
        public class Iterator {
            public Node current;
            public void Iterator(Node node) {
                
            }
            public void Next() {

            }
            public T Data {
                get {
                    return current.Data;
                }
            }
        }
        public Node head = null;
        public int Size {
            get {
                return 0;
            }
        }
        public Node Head{
            get{
                return head;
            }
        }
        public Node Tail {
            get {
                return head; // change to tail
            }
        }
        public T this[int index] {
            get {
                return default(T); //change
            }
        }
        public void MakeNewHead(T data) {
            head = new Node();
            head.Data = data;
        }

        public void AddHead(T data) {

        }
        public void AddTail(T data) {

        }
        public void Clear() {

        }
        public int IndexOf(T data) {
            return 0;
        }
        public void InsertAt(T data, int index) {

        }
        public void RemoveAt(int index) {

        }
        public Iterator Begin() {
            return default(Iterator);

        }
        public Iterator End() {
            return default(Iterator);
        }
    }
}
