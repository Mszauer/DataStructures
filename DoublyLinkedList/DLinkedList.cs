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
                    Node crawler = Head;
                    for (int i = 0; i < Size; i++) {
                        if (crawler.Next == null) {
                            tail = crawler;
                            return tail;
                        } 
                        crawler = crawler.Next;
                    }
                }
                else {
                    tail = Head;
                }
                return Head;
            }
        }
        public T this[int index] {
            get {
                if (index < Size -1 || index > Size-1) {
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
                Head.Next = Head.Next;
                head = newHead;
            }
            size++;
        }
        public void AddTail(T data) {
            if (Head == null) {
                AddHead(data);
                tail = Head;
            }
            else {
                Node newTail = new Node(data);
                newTail.Prev = Tail;
                Tail.Next = newTail;
                tail = newTail;
            }
            size++;
        }
        public void Clear() {
            head = null;
            size = 0;
        }
        public void InsertAt(T data, int index) {
            if (index == 0) {
                AddHead(data);
            }
            else if (index == size - 1) {
                AddTail(data);
            }
            else {
                Node crawler = head;
                for (int i = 1; i < index; i++) {
                    crawler = crawler.Next;
                }
                Node insert = crawler.Next;
                insert.Next = crawler.Next.Next;
                insert.Prev = crawler;
                crawler.Next.Prev = insert;
            }
            size++;
        }
        public void RemoveAt(int index) {
            if (index == 0) {
                head = head.Next;
            }
            else {
                Node crawler = head;
                for (int i = 1; i < index; i++) {
                    crawler = crawler.Next;
                }
                crawler.Next = crawler.Next.Next;
                crawler.Next.Next.Prev = crawler;
            }
            size--;
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
