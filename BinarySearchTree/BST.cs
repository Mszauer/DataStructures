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
            int h = 0;
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
                h++;
            } while (h < Height);
            //returns false if value has not been found and it reached a leaf node
            return false;
        }
        public bool Remove(T data) {
            //check if it contains node with our data
            if (Contains(data)) {
                Node crawler = root;
                //find the node with value we want
                do {
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
                        //find parent node

                        //equal remove node and assign it with next smallest value
                        //case 1
                        if (crawler.Left == null && crawler.Right == null) {
                            crawler = null;
                        }
                        //case 2
                        else if (crawler.Left != null) {
                            //set previous node's left to crawler.left
                            /*
                             * crawler.Data = crawler.Left.Data;
                            crawler.Left = null;
                             * deletes everything on the left tree
                             */
                        }
                        else if (crawler.Right != null) {
                            //set previous node's right to carawler.right
                        }
                        //case 3
                        //compare children, see which is smaller, then link accordingly
                    }
                } while (crawler != null);//fix this
            }
            //doesn't contain node, can't remove
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
        private Node FindParent(Node crawler, T data) {
            int cmp = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Data, data);
            if (cmp == -1) {
                //check if left subroot is empty / node is a leaf
                int _cmp = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Left.Data,data);
                if (_cmp == 0) {
                    return crawler;
                }
                else {
                    int _cmp2 = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Left.Data, data);
                    if (_cmp2 == -1) {
                        //move left
                        crawler = crawler.Left;
                        //recurse
                        FindParent(crawler, data);
                    }
                    else {
                        //move Right
                        crawler = crawler.Right;
                        //recurse
                        FindParent(crawler, data);
                    }
                }
                
            }
            //if larger go right
            else if (cmp == 1){
                int _cmp = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Right.Data, data);
                if (_cmp == 0) {
                    return crawler;
                }
                else {
                    int _cmp2 = System.Collections.Generic.Comparer<T>.Default.Compare(crawler.Right.Data, data);
                    if (_cmp2 == -1) {
                        //move left
                        crawler = crawler.Left;
                        //recurse
                        FindParent(crawler, data);
                    }
                    else {
                        //move Right
                        crawler = crawler.Right;
                        //recurse
                        FindParent(crawler, data);
                    }
                }
            }
            return crawler;
        }
    }
}
