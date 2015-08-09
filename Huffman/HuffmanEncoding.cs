using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    partial class Huffman {
        public static HashTable<char,BitStream> MakeEncodingTable(Node node, BitStream progress){
            HashTable<char,BitStream> result = new HashTable<char,BitStream>(char.MaxValue,HashChar);

            //if the current node is not null and it is a leaf, we want to add it to result
            if (node != null && node.Left == null && node.Right == null) {
                //we only store leaf nodes in the result array
                //make a new bit stream
                BitStream stream = new BitStream();
                //append progress to it
                stream.Append(progress);
                //add node.data and the new stream to result
                result.Add(node.Data, stream);
            }

            //else if the node is not null, we are going to want to process it's childern
            else {
                if (node != null && node.Left != null) {
                    //if left subtree is not null
                    //make new bit stream
                    BitStream stream = new BitStream();
                    //append progress
                    stream.Append(progress);
                    //append 0 (because we are going left)
                    stream.Append(false);
                    //recursivley call this function on node.Left with the new stream we just created
                    //store the result of the previous call in a local hashtable
                    HashTable<char, BitStream> local = MakeEncodingTable(node.Left, stream);
                    //loop through the just created hash table(the return of the recursive function)
                    SLinkedList<char> list = local.Keys;
                    for (int i = 0; i < list.Size; i++) {
                        //add each key value pair to this function's result hash table
                        result.Add(list[i], stream); //what bitstream?
                        Console.WriteLine("added: " + System.Convert.ToString(list[i]) + " " + stream);
                        //we do this because the results of each recursion bubble back up to the top.
                        //by the time the root returns, all of the leaf nodes will be in the final hash table
                    }//end loop
                }//end if
                if (node != null && node.Right != null) {
                    //repeat above for the right subtree
                    BitStream stream = new BitStream();
                    stream.Append(progress);
                    stream.Append(true);
                    HashTable<char, BitStream> local = MakeEncodingTable(node.Right, stream);
                    SLinkedList<char> list = local.Keys;
                    for (int i = 0; i < list.Size; i++) {
                        result.Add(list[i], stream);
                        Console.WriteLine("added: " + list[i] + " " + stream);
                    }
                }//end else
            }
            return result;
        }
    }
}
