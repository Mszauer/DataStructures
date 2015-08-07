﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    class BitStream {
        Vector<byte> bytes = new Vector<byte>();
        int size = 0;
        public int BitCount {
            get {
                return size;
            }
        }
        public int ByteCount {
            get {
                return bytes.Size;
            }
        }
        public byte[] Bytes {
            get {
                byte[] current = new byte[bytes.Size];
                for (int i = 0; i < ByteCount; i++) {
                    current[i] = bytes[i];
                }
                return current;
            }
        }
        public byte ByteAt(int index) {
            //return the byte from byte vector at given index
            return bytes[index];
        }
        public bool BitAt(int index) {
            //returns specific bit
            //find the byte the bit will be in and bit index 
            int byteIndex = index / 8;
            int bitIndex = index - byteIndex * 8;// what this will always give 0, it negates byteIndex?
            //mask it out
            byte bitMask = (byte)(1 << 7 - bitIndex);
            //can be on or off aka true or false
            bool set = (ByteAt(byteIndex) & bitMask) != 0;
            //return value
            return set;
        }
        public void Append(bool state) {
            //finds current byte
            //then sets next available bit to state
            //if no more bytes a new one is appended
        }
        public void Append(BitStream stream) {
            //loop through all of the bits in bitstream
            //append them to this one
            //just call Append(bool)
        }
        public void Append(string complicated) {
            //takes in string of 0's and 1's
            //if anything is not 0 or 1, throw exception
            //loop through string
            //if char is 0 call Append(false)
            //if char is 1 call append(true)
        }
        public string ToString() {
            //convert each bit to a string
            //return large string with 0's or 1's for every bit
            //loop until size
            //foreach index call BitAt
            //returns false add 0, true return 1 to bitat
            return " ";
        }
    }
}
