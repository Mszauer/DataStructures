using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList {
    class DLinkedList<T> {
        public class Node {
            public T Data;
            public Node Prev;
            public Node Next;
            public Node(T data) {
                Data = data;
            }
        }

        public class Iterator {
            private Node current;
            public T Data {
                get {
                    return current.Data;
                }
            }
            public Iterator(Node node) {
                current = node;
            }
            public void Next(){
                current = current.Next;
            }
            public void Prev() {
                current = current.Prev;
            }
        }
        private Node head;
        private Node tail;
        private int size;
        public int Size {
            get {
                return size;
            }
        }
        public Node Head {
            get{
                return head;
            }
        }
        public Node Tail {
            get {
                if (Head != null) {
                    Node crawler = head;
                    for (int i = 0; i < Size; i++) {
                        if (crawler.Next != null) {
                            return crawler;
                        } 
                        crawler = crawler.Next;
                    }
                }
                return Head;
            }
        }
        public T this[int index] {
            get {
                if (index < Size || index > Size) {
                    throw new System.Exception();
                }
                Node crawler = head;
                for (int i = 0; i < Size; i++) {
                    crawler = crawler.Next;
                }
                return crawler.Data;
            }
        }
        public void AddHead(T data) {
            if (Head == null) {
                head = new Node(data);
            }
            else {
                Node newHead = new Node(data);
                newHead.Next = Head;
                Head.Prev = newHead;
            }
        }
        public void AddTail(T data) {
            if (Head == null) {
                AddHead(data);
            }
            else {
                Node newTail = new Node(data);
                newTail.Prev = Tail;
                Tail.Next = newTail;
            }
        }
        public void Clear() {
            head = null;
            size = 0;
        }
        public int InsertAt(T data, int index) {
            return 0;
        }
        public void RemoveAt(int index) {

        }
        public void Sort() {

        }
        public Iterator Begin() {
            return new Iterator(Head);
        }
        public Iterator End() {
            return new Iterator(Tail);
        }
    }
}
