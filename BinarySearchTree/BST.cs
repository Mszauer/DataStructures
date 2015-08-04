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
                height++;
            }
            else {
                Node crawler = root;
                Traverse(crawler, data);
            }
        }
        private void Traverse(Node crawler,T data) {
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
                    Traverse(crawler, data);
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
                    Traverse(crawler, data);
                }
            }
        }
    }
}
