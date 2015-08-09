using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    partial class Huffman {
        public static int HashChar(char c) {
            return (int)c;
        }
        public class Node {
            public char Data;
            public int Frequency;
            public Node Left;
            public Node Right;

            public bool IsLeaf {
                get {
                    return Left == null && Right == null;
                }
            }
        }

        public static Node MakeHuffmanTree(HashTable<char, int> frequencyTable) {
            //First, create a singly linked list of nodes to return
            SLinkedList<Node> looseNodes = new SLinkedList<Node>();
            //we need to loop through the given frequency table
            SLinkedList<char> keys = frequencyTable.Keys;
            for (int i = 0; i < keys.Size; i++) {
                //make new node for each element in hash table
                Node n = new Node();
                //node Data is current key (keys[i])
                n.Data = keys[i];
                //node frequency is going to be the value for the current key (table[key])
                n.Frequency = frequencyTable[keys[i]];
                //add this new node to the end(tail) of the loose nodes list
                looseNodes.AddTail(n);
            }//end loop

            /* Comments, no code */
            // Next we need to take this loose collection of nodes and build a tree out of it.
            // We do this by combining the smallest value nodes under a parent node. Each iteration
            // Of the below loop will reduce size by 1, because it removes two nodes and adds one.
            // We know we have a tree built, when the loose nodes list has a size of 1.
            /* End comments */

            //loop while the looseNodes list has more than one element in it
            while (looseNodes.Size > 1) {
                //Repeat above steps for a new local node called right
                Node right = looseNodes[0];
                for (int i = 0; i < looseNodes.Size; i++) {
                    if (right.Frequency > looseNodes[i].Frequency) {
                        right = looseNodes[i];
                    }
                }
                looseNodes.RemoveAt(looseNodes.IndexOf(right));

                //make local variable called left and set it to looseNodes[0]
                Node left = looseNodes[0];
                //we want to set left to the lowest frequency node, loop through nodes
                for (int i = 0; i < looseNodes.Size; i++) {
                    //if frequency of current node is less than left
                    if (left.Frequency > looseNodes[i].Frequency) {
                        //set left to current node
                        left = looseNodes[i];
                    }//end if
                }//end loop
                //now that we have a  reference to the smallest node, lets remove it from the list
                looseNodes.RemoveAt(looseNodes.IndexOf(left));
                
                //Make a new node
                Node n = new Node();
                //set its left to the local left node
                n.Left = left;
                //set its right to the local right node
                n.Right = right;
                //set its frequency to the sum of the left and right nodes frequencies
                n.Frequency = right.Frequency + left.Frequency;
                //set its data to '\0' (char equivalent of null)
                n.Data = '\0';
                //Add the new node to the end of the looseNodes list(AddTail)
                looseNodes.AddTail(n);
            }//end loop
            //at this point the loose node list has only one element, and it's the root node of our huffman table
            //return [0] of the loose list
            return looseNodes[0];
            //end loop ?? what loop
        
        }

        public static HashTable<char, int> MakeFrequencyTable(string input) {
            HashTable<char, int> result = new HashTable<char, int>(char.MaxValue, HashChar);
            //loop through the input string
            foreach (char c in input) {
                //check if key exists (get the keys of the result hash table)
                SLinkedList<char> chars = result.Keys;
                int index = chars.IndexOf(c);
                //check if key is in hashtable / SLL
                if (index < 0){ //checks if it contains the char
                    //add current char with count of 1
                    result.Add(c,1);
                }
                else{
                    //increment count of the character
                    result[c] += 1;
                }
            }
            return result;
        }
    }
}
