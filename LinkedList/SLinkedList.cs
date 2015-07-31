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
            public Node (T data, Node next){
                Data = data;
                Next = next;
            }
            
        }
        public class Iterator {
            public Node current;
            public Iterator(Node node) {
                current = node;
            }
            public void Next() {
                current = current.Next;
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
                return /*return size*/;
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
                if (index < 0 || index > Size){
                    //throw exception?
                }
                Node current = head;
                for (int i = 0; i < index; i++) {
                    current = current.Next;
                }
                return current.Data;
            }
        }

        public void AddHead(T data) {
            if (head == null) {
                head = new Node(data, null);
            }
            else {
                Node _head = new Node(data,head.Next);
                head = _head;
            }
        }

        public void AddTail(T data) {

        }

        public void Clear() {
            head = null;
        }

        public int IndexOf(T data) {
            int index = 0;
                bool equals = System.Collections.Generic.EqualityComparer<T>.Default.Equals(data[i], data);
            return 0;
        }

        public void InsertAt(T data, int index) {

        }

        public void RemoveAt(int index) {
            Node crawler = head;
            for (int i = 0; i < index; i++) {
                crawler = crawler.Next;
            }
            crawler.Next = crawler.Next.Next;
        }

        public Iterator Begin() {
            return default(Iterator);

        }
        public Iterator End() {
            return default(Iterator);
        }

    }
}
