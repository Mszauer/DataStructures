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
        }
        public bool BitAt(int index) {
            //return specific bit
            //find the byte the bit will be in
            //mask it out
            //return value
            //can be on or off aka true or false
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
        }
    }
}
