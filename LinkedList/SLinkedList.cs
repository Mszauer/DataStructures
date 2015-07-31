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
        int size = 0;
        public int Size {
            get {
                return size;
            }
        }
        public Node Head{
            get{
                return head;
            }
        }
        public Node Tail {
            get {
                if (head != null) {
                    Node crawler = head;
                    for (int i = 0; i < size; i++) {
                        if (crawler.Next == null) {
                            return crawler;
                        }
                    }
                }
                return Head;
            }
        }
        public T this[int index] {
            get {
                if (index < 0 || index > Size){
                    throw new System.Exception();
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
            size++;
        }

        public void AddTail(T data) {
            Node newTail = new Node(data, null);
            Tail.Next = newTail;
            size++;
        }

        public void Clear() {
            head = null;
            size = 0;
        }

        public int IndexOf(T data) {
            int index = 0;
            Node crawler = head;
            while (index < size) {
                bool equals = System.Collections.Generic.EqualityComparer<T>.Default.Equals(crawler.Data, data);
                if (equals) {
                    return index;
                }
                index++;
                crawler = crawler.Next;
            }
            return 0;
        }

        public void InsertAt(T data, int index) {
            Node crawler = head;
            for (int i = 0; i < index; i++) {
                crawler = crawler.Next;
            }
            Node insert = new Node(data, crawler.Next);
            crawler.Next = insert;
        }

        public void RemoveAt(int index) {
            Node crawler = head;
            for (int i = 0; i < index; i++) {
                crawler = crawler.Next;
            }
            crawler.Next = crawler.Next.Next;
            size--;
        }

        public Iterator Begin() {
            return new Iterator(Head);
        }
        public Iterator End() {
            return new Iterator(Tail);
        }

    }
}
