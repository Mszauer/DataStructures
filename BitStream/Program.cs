using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    class Program {
        public static void Error(string str) {
		    ConsoleColor old = Console.ForegroundColor;
		    Console.ForegroundColor = ConsoleColor.Red;
		    Console.WriteLine (str);
		    Console.ForegroundColor = old;
		}

		public static void Main (string[] args)
		{
			BitStream stream = new BitStream ();

			stream.Append (true);
			stream.Append (true);
			stream.Append (true);

			string debug = stream.ToString ();
			Console.WriteLine (debug);
			if (debug != "111") {
				Error ("Expecting 111, got " + debug);
                Console.ReadLine();
                return;
			}

			stream.Append (false);
			stream.Append (true);
			stream.Append (false);
			stream.Append (false);
			stream.Append (true);
			debug = stream.ToString ();
			Console.WriteLine (debug);
			if (debug != "11101001") {
				Error ("Expecting 11101001, got " + debug);
                Console.ReadLine();
                return;
			}

			Console.WriteLine ("0: " + stream.BitAt (0) + " / True");
			if (!stream.BitAt (0)) {
				Error ("Expecting bit 0 to be on, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("1: " + stream.BitAt (1) + " / True");
			if (!stream.BitAt (1)) {
				Error ("Expecting bit 1 to be on, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("2: " + stream.BitAt (2) + " / True");
			if (!stream.BitAt (2)) {
				Error ("Expecting bit 2 to be on, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("3: " + stream.BitAt (3) + " / False");
			if (stream.BitAt (3)) {
				Error ("Expecting bit 3 to be off, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("4: " + stream.BitAt (4) + " / True");
			if (!stream.BitAt (4)) {
				Error ("Expecting bit 4 to be on, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("5: " + stream.BitAt (5) + " / False");
			if (stream.BitAt (5)) {
				Error ("Expecting bit 5 to be off, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("6: " + stream.BitAt (6) + " / False");
			if (stream.BitAt (6)) {
				Error ("Expecting bit 6 to be off, it was not");
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("7: " + stream.BitAt (7) + " / True");
			if (!stream.BitAt (7)) {
				Error ("Expecting bit 7 to be on, it was not");
                Console.ReadLine();
                return;
			}

			stream.Append (stream);
			debug = stream.ToString ();
			Console.WriteLine (debug);
			if (debug != "1110100111101001") {
				Error ("Expecting 1110100111101001, got " + debug);
                Console.ReadLine();
                return;
			}

			stream.Append ("110011");
			debug = stream.ToString ();
			Console.WriteLine (debug);
			if (debug != "1110100111101001110011") {
				Error ("Expecting 1110100111101001110011, got " + debug);
                Console.ReadLine();
                return;
			}

			try {
				stream.Append("1A");
				Error("ERROR! Should not be able to insert A");
                Console.ReadLine();
                return;
			}
			catch (System.Exception e) {
				Console.WriteLine ("Was not able to insert A (As expected)");
			}
			debug = stream.ToString (); 
			Console.WriteLine (debug);
			if (debug != "11101001111010011100111") {
				Error ("Expecting 11101001111010011100111, got " + debug);
                Console.ReadLine();
                return;
			}

			Console.WriteLine(stream.ByteAt (0) + " / 233");
			if (stream.ByteAt (0) != 233) {
				Error ("Expected byte at 0 to be 233, not: " + stream.ByteAt (0));
                Console.ReadLine();
                return;
			}
			Console.WriteLine (stream.ByteAt (1) + " / 233");
			if (stream.ByteAt (1) != 233) {
				Error ("Expected byte at 1 to be 233, not: " + stream.ByteAt (1));
                Console.ReadLine();
                return;
			}
			Console.WriteLine (stream.ByteAt (2) + " / 206");
			if (stream.ByteAt (2) != 206) {
				Error ("Expected byte at 2 to be 206, not: " + stream.ByteAt (2));
                Console.ReadLine();
                return;
			}

			Console.WriteLine ("Num bytes: " + stream.ByteCount + " / 3");
			if (stream.ByteCount != 3) {
				Error ("Expecting ByteCount to be 3, not: " + stream.ByteCount);
                Console.ReadLine();
                return;
			}
			Console.WriteLine ("Num bits: " + stream.BitCount + " / 23");
			if (stream.BitCount != 23) {
				Error ("Expecting BitCount to be 23, not: " + stream.BitCount);
                Console.ReadLine();
                return;
			}

			Console.WriteLine (stream.ToString ());
			byte[] bits = stream.Bytes;
			for (int i = 0; i < bits.Length; ++i) {
				Console.Write(Convert.ToString(bits[i], 2).PadLeft(8, '0'));
			}
			Console.Write ("\n");
            Console.ReadLine();
        }
    }
}
