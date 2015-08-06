using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures {
    class Program {
        static void Main(string[] args) {
            BST<int> bst = new BST<int>();
            //Testing add
            Console.WriteLine("Testing Add function");
            int[] add = new int[] { 35, 50, 10, 15, 55, 1, 37 };
            foreach (int i in add) {
                bst.Insert(i);
                Console.WriteLine("\t" + i + "added ");
            }
            Console.WriteLine("\n Add function finished");
            bst.PreTraversal(BSTPrint);
            if (bst.Contains(55)) {
                Console.WriteLine("\n BST Contains 55");
            }
            if (bst.Contains(10)) {
                Console.WriteLine("\n BST contains 10");
            }
            bst.Remove(10);
            if (!bst.Contains(10)) {
                Console.WriteLine("\n Remove Successfull");
            }
            else {
                Console.WriteLine("\n Could not remove 10");
            }
            bst.PreTraversal(BSTPrint);
            Console.ReadLine();
        }

        public static void BSTPrint(int data) {
            Console.Write(" " + data + " ");
        }
    }
}
