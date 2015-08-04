using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree {
    class BST <T>{
        public delegate void TraverseNode(T data);
        class Node {
            public T Data;
            public Node Left;
            public Node Right;
            public Node(T data) {
                Data = data;
            }
        }
        int height = 0;
        public int Height {
            get {
                return height;
            }
        }
        Node root = null;
        public void Insert(T data) {
            if (root == null) {
                root = new Node(data);
            }
            else {
                Node crawler = root;
                AddChild(crawler, data);
            }
            height++;
        }

        public bool Contains(T data) {
            Node crawler = root;
            do {
                //if it reached the end, break
                if (crawler == null) {
                    break;
                }
                //compare value given vs node value
                int cmp = System.Collections.Generic.Comparer<T>.Default.Compare(data, crawler.Data);
                if (cmp == -1) {
                    //if smaller, move left
                    crawler = crawler.Left;
                }
                else if (cmp == 1) {
                    //if larger, move right
                    crawler = crawler.Right;
                }
                else {
                    //equal, return true
                    return true;
                }
            } while (true);
            //returns false if value has not been found and it reached a leaf node
            return false;
        }
        public bool Remove(T data) {
            
            return false;
        }
        private void AddChild(Node crawler,T data) { //goes down BST and assigns New Node
            //compare values
            int cmp = System.Collections.Generic.Comparer<T>.Default.Compare(data, crawler.Data);
            //if smaller go left
            if (cmp == -1) {
                //check if left subroot is empty / node is a leaf
                if (crawler.Left == null) {
                    //if it is, assign new leaf node
                    crawler.Left = new Node(data);
                    return;
                }
                else {
                    //move left
                    crawler = crawler.Left;
                    //recurse
                    AddChild(crawler, data);
                }
            }
            //if larger go right
            else {
                //check if right subroot is empty
                if (crawler.Right == null) {
                    //assign new node
                    crawler.Right = new Node(data);
                    return;
                }
                else {
                    //move right, recurse
                    crawler = crawler.Right;
                    AddChild(crawler, data);
                }
            }
        }
        private Node GetParent(Node crawler, T data) {
            Node parent = null;
            while (crawler != null) {
                int dir = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Data, data);
                int left = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Left.Data, data);
                int right = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Right.Data, data);
                //if left child exists, and data is smaller than parent data, and left data is not the data we look for
                if (crawler.Left != null && dir == -1 && left != 0) {
                    crawler = crawler.Left;
                }
                //if right child exists, and data is larger than parent data, and right data is not data we are looking for
                else if (crawler.Right != null && dir == 1 && right != 0) {
                    crawler = crawler.Right;
                }
                else if (left == 0 || right == 0) {
                    parent = crawler;
                }
            }
            return parent;   
        }
        private Node GetMin(Node crawler) {
            Node min = null;
            min = crawler;
            while (crawler != null) {
                int cmp = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Data, min.Data);
                if (cmp == -1) {
                    min = crawler;
                }
                crawler = crawler.Left;
            }
            return min;
        }
    }
}
