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
