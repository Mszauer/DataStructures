using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    partial class Huffman {
        private static byte[] IntToBytes(int num) {
            return BitConverter.GetBytes(num);
        }
        private static byte[] CharToBytes(char c) {
            return BitConverter.GetBytes(c);
        }
        public static byte[] Compress(string toCompress) {
            //then at the end of the function we're going to convert it to an array, and return it.
            Vector<byte> result = new Vector<byte>();
            
            //make an encoding table out of the huffman tree, out of a frequency table
            Console.WriteLine("Making Huffman frequency table");
            HashTable<char, int> FreqTable = MakeFrequencyTable(toCompress); //copy to memory because we access it multiple times
            Console.WriteLine("Making Huffman tree");
            Node huffmanTree = MakeHuffmanTree(FreqTable);
            Console.WriteLine("Making Huffman encoding table");
            HashTable<char, BitStream> encodingTable = MakeEncodingTable(huffmanTree, new BitStream()); // add to memory because accessed twice
            //convert the size of the frequency table to bytes.
            Console.WriteLine("Converting to bytes");
            byte[] freqToByte = IntToBytes(FreqTable.Size);
            //and all four bytes to the resuld linked list
            Console.WriteLine("Adding bytes bytes");
            result.AddRange(freqToByte);

            //next loop through the frequency table
            SLinkedList<char> list = FreqTable.Keys;
            Console.WriteLine("looping through frequency table");
            for (int i = 0; i < list.Size; i++) {
                //convert current key to two bytes
                byte[] key = CharToBytes(list[i]);
                //add both bytes to the linked list
                result.AddRange(key);

                //convert the current value to foure bytes,
                byte[] value = IntToBytes(FreqTable[list[i]]);
                //add alll four bytes to the linked list
                result.AddRange(value);

            }//end loop
                
            //make new bitstream (datastream) to hold bits
            BitStream datastream = new BitStream();

            //loop through the string
            Console.WriteLine("Looping through input and adding to datastream");
            for (int i = 0; i < toCompress.Length; i++) {
                //append the bitstream of the encoding table to the newely created bitstream
                datastream.Append(encodingTable[toCompress[i]]);
            }//end loop

            //get the bit streams bit count as an integer
            int streamBitCount = datastream.BitCount;
            //convert this integer to bytes and add it to the result list
            Console.WriteLine("Converting bytes");
            byte[] streambitByte = IntToBytes(streamBitCount);
            result.AddRange(streambitByte);

            Console.WriteLine("Copying Bytes");
            result.AddRange(datastream.Bytes);

            //finally convert the result list to a byte array.
            Console.WriteLine("Convert results list to byte array");
            byte[] byteResult = result.ToArray();

            //return the array
            return byteResult;
        }
    }
}
