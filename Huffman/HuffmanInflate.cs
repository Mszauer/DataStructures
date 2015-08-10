using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    partial class Huffman {
        //Returns an integer out of the bytes array
        static int BytesToInt(byte[] bytes, int offset) {
            return BitConverter.ToInt32(bytes, offset);
        }
        //Same as integer just with a char
        static char BytesToChar(byte[] bytes, int offset) {
            return BitConverter.ToChar(bytes, offset);
        }
        //retrieve bit from byte array
        static bool GetBit(byte[] data, int pos) {
            int byteIndex = pos / 8;
            int bitIndex = pos - byteIndex * 8;

            byte bitmask = (byte)(1 << (7 - bitIndex));
            return (data[byteIndex] & bitmask) != 0;
        }
        public static string Inflate(byte[] toInflate) {
            // This is going to be the frequency table, but we have to read it out of our byte array.
            HashTable<char, int> frequencyTable = new HashTable<char, int>(char.MaxValue, HashChar);

            // The first thing in our byte array is the frequency table, let's read it back in

            // Lets make a new string, call it result
            string result = "";
            // Lets make a new int, call it byte offset and set it to 0
            int byteOffset = 0;
            // Make a new int, call it frequencyTableSize, set it equat to the next 
            // int in the byte array passed in as argument (code included)
            int frequencyTableSize = BytesToInt(toInflate, byteOffset);
            // Don't forget, an int is 4 btyes, add 4 to the byteOffset int (Code included)
            byteOffset += 4;

            // Loop 0 to frequencyTableSize
            Console.WriteLine("copying chars from bytes");
            for (int i = 0; i < frequencyTableSize; i++) {
                // Read in a character for the table key (add 2 to offset after)
                char c = BytesToChar(toInflate, byteOffset);
                byteOffset += 2;
                // Read in an integer for the value (add 4 to offset after)
                int n = BytesToInt(toInflate, byteOffset);
                byteOffset += 4;
                // Add the key and vaue to the frequencyTable
                frequencyTable.Add(c, n);
            }// end loop

                // After the frequency table, is the number of bits that our compressed data consists of
                // Read an integer from the byte array, lets call it numBits (how many to be read)
            int numBits = BytesToInt(toInflate, byteOffset);
            byteOffset += 4;
            // Make a new integer call it bitsRead and set it to 0. We keep track of how many bits need
            // to be red, and how many HAVE been read
            int bitsRead = 0;

                // Make a huffman tree out of the frequency table
            Console.WriteLine("Making Huffman tree");
            Node huffmanTree = MakeHuffmanTree(frequencyTable);
                // While the bits read is less than the number of bits
            while (bitsRead < numBits) {
                // Make a local node reference (I called mine root) and set it
                // equal to the root of the tree
                Node root = huffmanTree;
                // While the node is not a leaf
                while (!root.IsLeaf) {
                    // Read one bit from the input stream and see if its set
                    // we need to multiply readerOffset by 8, because reader
                    // offset is in bytes, but GetBit needs a bit offset (code included)
                    if (GetBit(toInflate, byteOffset * 8 + bitsRead)) {
                        // If the bit was on, go down the right branch
                        root = root.Right;
                    }
                    else {
                        // If the bit was off, go down the left branch
                        root = root.Left;
                    }
                    // Add one to bits read
                    bitsRead++;
                }// End loop
                // Add root.Data to the result string
                result += root.Data;
            } // End loop
            // return the result string
            return result;
        }
    }
}
