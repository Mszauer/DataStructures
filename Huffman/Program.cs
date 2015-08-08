using System;
using DataStructures;

namespace DataStructures {
    class Program {
        static void Error(string error) {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = old;

            Console.WriteLine("Press return to continue");
            Console.ReadLine();
        }

        static void Main(string[] args) {
            Console.WriteLine("sizeof(int):  " + sizeof(int) + " bytes, " + (sizeof(int) * 8) + " bits");
            Console.WriteLine("sizeof(char): " + sizeof(char) + " bytes, " + (sizeof(char) * 8) + " bits");
            Console.WriteLine("sizeof(byte): " + sizeof(byte) + " bytes, " + (sizeof(byte) * 8) + " bits\n");

            string testString = "sailing down the mississippi river";

            HashTable<char, int> frequencyTable = Huffman.MakeFrequencyTable(testString);
            Console.WriteLine("Frequency Table: ");
            SLinkedList<char> frequencyKeys = frequencyTable.Keys;
            for (int i = 0; i < frequencyKeys.Size; ++i) {
                Console.Write(frequencyKeys[i] + ":" + frequencyTable[frequencyKeys[i]] + " ");
            }
            Console.Write("\n");

            HashTable<char, int> expectedFrequency = new HashTable<char, int>(char.MaxValue, (char c) => {
                return (int)c;
            });
            expectedFrequency.Add('w', 1);
            expectedFrequency.Add('v', 1);
            expectedFrequency.Add('t', 1);
            expectedFrequency.Add('s', 5);
            expectedFrequency.Add('r', 2);
            expectedFrequency.Add('p', 2);
            expectedFrequency.Add('o', 1);
            expectedFrequency.Add('n', 2);
            expectedFrequency.Add('m', 1);
            expectedFrequency.Add('l', 1);
            expectedFrequency.Add('i', 7);
            expectedFrequency.Add('h', 1);
            expectedFrequency.Add('g', 1);
            expectedFrequency.Add('e', 2);
            expectedFrequency.Add('d', 1);
            expectedFrequency.Add('a', 1);
            expectedFrequency.Add(' ', 4);

            SLinkedList<char> expectedKeys = expectedFrequency.Keys;
            for (int i = 0; i < expectedKeys.Size; ++i) {
                if (frequencyKeys.IndexOf(expectedKeys[i]) < 0) {
                    Error("Key " + expectedKeys[i] + " was not found in frequency table");
                    return;
                }
            }
            for (int i = 0; i < frequencyKeys.Size; ++i) {
                if (expectedKeys.IndexOf(frequencyKeys[i]) < 0) {
                    Error("Unexpected key " + frequencyKeys[i] + " in frequency table");
                    return;
                }
            }

            for (int i = 0; i < frequencyKeys.Size; ++i) {
                if (frequencyTable[frequencyKeys[i]] != expectedFrequency[expectedKeys[i]]) {
                    Error("Expecting \"" + frequencyKeys[i] + "\" to equal " + expectedFrequency[expectedKeys[i]] + ", not " + frequencyTable[frequencyKeys[i]]);
                }
            }


            Console.ReadLine();
        }
    }
}