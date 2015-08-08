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

            Huffman.Node huffmanTree = Huffman.MakeHuffmanTree(frequencyTable);
            PrintTree(huffmanTree);
            SLinkedList<Huffman.Node> allNodes = new SLinkedList<Huffman.Node>();
            SLinkedList<Huffman.Node> queue = new SLinkedList<Huffman.Node>();
            queue.AddTail(huffmanTree);
            while (queue.Size > 0) {
                allNodes.AddTail(queue[0]);

                if (queue[0].Left != null) {
                    queue.AddTail(queue[0].Left);
                }

                if (queue[0].Right != null) {
                    queue.AddTail(queue[0].Right);
                }

                queue.RemoveAt(0);
            }


            SLinkedList<char> expectedNodeData = new SLinkedList<char>();
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('i');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('s');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail(' ');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('\0');
            expectedNodeData.AddTail('e');
            expectedNodeData.AddTail('n');
            expectedNodeData.AddTail('p');
            expectedNodeData.AddTail('r');
            expectedNodeData.AddTail('a');
            expectedNodeData.AddTail('d');
            expectedNodeData.AddTail('g');
            expectedNodeData.AddTail('h');
            expectedNodeData.AddTail('l');
            expectedNodeData.AddTail('m');
            expectedNodeData.AddTail('o');
            expectedNodeData.AddTail('t');
            expectedNodeData.AddTail('v');
            expectedNodeData.AddTail('w');

            SLinkedList<int> expectedNodeFrequency = new SLinkedList<int>();
            expectedNodeFrequency.AddTail(34);
            expectedNodeFrequency.AddTail(19);
            expectedNodeFrequency.AddTail(15);
            expectedNodeFrequency.AddTail(11);
            expectedNodeFrequency.AddTail(8);
            expectedNodeFrequency.AddTail(8);
            expectedNodeFrequency.AddTail(7);
            expectedNodeFrequency.AddTail(6);
            expectedNodeFrequency.AddTail(5);
            expectedNodeFrequency.AddTail(4);
            expectedNodeFrequency.AddTail(4);
            expectedNodeFrequency.AddTail(4);
            expectedNodeFrequency.AddTail(4);
            expectedNodeFrequency.AddTail(4);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(2);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);
            expectedNodeFrequency.AddTail(1);

            for (int i = 0; i < allNodes.Size; ++i) {
                if (allNodes[i].Data != expectedNodeData[i]) {
                    Error("Error somewhere in huffman tree");
                }
                if (allNodes[i].Frequency != expectedNodeFrequency[i]) {
                    Error("Error somewhere in huffman tree");
                }
            }

            Console.ReadLine();
        }

        static void PrintTree(Huffman.Node node, int indent = 0) {
            if (node == null) {
                return;
            }
            for (int i = 0; i < indent; ++i) {
                Console.Write('\t');
            }

            if (!node.IsLeaf) {
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("*");
                Console.ForegroundColor = old;
            }
            else {
                Console.Write(node.Data);
            }

            Console.WriteLine(":" + node.Frequency);

            PrintTree(node.Left, indent + 1);
            PrintTree(node.Right, indent + 1);
        }
    }
}