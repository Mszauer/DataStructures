using System;
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
             //if no more room, create more
            if (size % 8 == 0) {
                bytes.Append(0);
            }
            // TODO: Find byte index
            int byteIndex = size / 8;
            // TODO: Find bit index
            int bitIndex = size - byteIndex * 8;
            // TODO: If the bit is on (the argument is true
            if (state) {
                // TODO: Create a byte mask out of bit index
                byte bitMask = (byte)(1 << 7 - bitIndex);
                // TODO: Or the value of bytes at byteIndex with the new mask. 
                //   Make sure the result is re-assigned back into bytes
                bytes[byteIndex] = (byte)(bitMask | bytes[byteIndex]);
            }
            //incease size
            size++;
        }
        public void Append(BitStream stream) {
            // TODO: Cache stream size as a member variable. We do this because
            int streamSize = stream.BitCount;
            //   it's valid to add elements mid loop. If we do this however, 
            //   we will face an infinite loop if the stream passed in is the
            //   same stream we are writing to. To avoid this scenario, we need
            //   a 'Stream Size' to be recorded in a variable local to this function
            //   we loop on this integer, not stream.Size.
            // TODO: (Inside the loop) Get every bit, and call the existing Append function
            for (int i = 0; i < streamSize; i++) {
                if (stream.BitAt(i)) {
                    Append(true);
                }
                else{
                    Append(false);
                }
            }
        }
        public void Append(string complicated) {
            //takes in string of 0's and 1's
            //if anything is not 0 or 1, throw exception
            //loop through string
            //if char is 0 call Append(false)
            //if char is 1 call append(true)
        }
        public string ToString() {
            //return large string with 0's or 1's for every bit
            string results = "";
            //loop until size
            for (int i = 0; i < size; i++) {
                //foreach index call BitAt
                if (BitAt(i) == true) {
                    //on, add 1 to string
                    results += "1";
                }
                else {
                    //off, add 0 to string
                    results += "0";
                }
            }
            return results;
        }
    }
}
