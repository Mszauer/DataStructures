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
            DLinkedList<byte> result = new DLinkedList<byte>();
            
            //make an encoding table out of the huffman tree, out of a frequency table
            HashTable<char, int> FreqTable = MakeFrequencyTable(toCompress); //copy to memory because we access it multiple times
            Node huffmanTree = MakeHuffmanTree(FreqTable);
            HashTable<char,BitStream> encodingTable = MakeEncodingTable(huffmanTree,new BitStream()); // add to memory because accessed twice
            //convert the size of the frequency table to bytes.
            byte[] freqToByte = IntToBytes(FreqTable.Size);
            //and all four bytes to the resuld linked list
            for (int i = 0; i < freqToByte.Length; i++) {
                result.AddTail(freqToByte[i]);
            }

            //next loop through the frequency table
            SLinkedList<char> list = FreqTable.Keys;
            for (int i = 0; i < list.Size; i++) {
                //convert current key to two bytes
                byte[] key = CharToBytes(list[i]);
                //add both bytes to the linked list
                result.AddTail(key[0]);
                result.AddTail(key[1]); // O(1) vs O(n) even though it is trivial enough to be small
                //convert the current value to foure bytes,
                byte[] value = IntToBytes(FreqTable[list[i]]);
                //add alll four bytes to the linked list
                for (int j = 0; j < value.Length; j++) {
                    result.AddTail(value[j]);
                }
            }//end loop
                
            //make new bitstream (datastream) to hold bits
            BitStream datastream = new BitStream();

            //loop through the string
            for (int i = 0; i < toCompress.Length; i++) {
                //append the bitstream of the encoding table to the newely created bitstream
                datastream.Append(encodingTable[toCompress[i]]);
            }//end loop

            //get the bit streams bit count as an integer
            int streamBitCount = datastream.BitCount;
            //convert this integer to bytes and add it to the result list
            byte[] streambitByte = IntToBytes(streamBitCount);
            for (int i = 0; i < streambitByte.Length; i++) {
                result.AddTail(streambitByte[i]);
            }
            byte[] dataStreamContents = datastream.Bytes;
            for (int i = 0; i < dataStreamContents.Length; i++) {
                result.AddTail(dataStreamContents[i]);
            }
            //finally convert the result list to a byte array.
            byte[] byteResult = new byte[result.Size];
            for (int i = 0; i < byteResult.Length; i++) {
                byteResult[i] = result[i];
            }
            //return the array
            return byteResult;
        }
    }
}
