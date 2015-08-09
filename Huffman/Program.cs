﻿using System;
using DataStructures;
using System.IO;

namespace DataStructures {
    class Program {

        static void Main(string[] args) {
            HashTable<string, int> data = new HashTable<string, int>(100, CustomHash);
            Console.WriteLine("Enter a command, or help for help");

            do {
                string command = Console.ReadLine().ToLower();
                string[] words = command.Split(' ');
                if (command == "help") {
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("\t compress to < path >");
                    Console.WriteLine("\t inflate from < path >");
                    Console.WriteLine("\t clear");
                    Console.WriteLine("\t list");
                    Console.WriteLine("\t exit");
                }
                if (command == "list") {
                    SLinkedList<string> keys = data.Keys;
                    for (int i = 0; i < keys.Size; i++) {
                        string key = keys[i];
                        int value = data[key];
                        Console.WriteLine(value + " " + key);
                    }
                }
                else if (command == "Exit") {
                    break;
                }
                else if (command == "clear") {
                    Console.Clear();
                    Console.WriteLine("Enter a command, or help for help");
                }
                else if (words[0] == "compress") {
                    Console.Write("Please enter the word(s) you want to compress: ");
                    string phrase = Console.ReadLine();
                    Console.WriteLine("Writing data now...");
                    try {
                        System.IO.File.WriteAllBytes(words[2], Huffman.Compress(phrase));
                    }
                    catch (SystemException e) {
                        Console.WriteLine("Error: " + e);
                    }
                    Console.WriteLine("Filed Saved");
                }
                else if (words[0] == "inflate") {
                    if (File.Exists(words[2])) {
                        Console.WriteLine("Loading Data...");
                        
                        Console.WriteLine("Data has been loaded.");
                    }
                    else {
                        Console.WriteLine("File not found");
                    }
                }
            } while (true);
        }

        public static int CustomHash(string arg) {
            int result = 1;
            foreach (char c in arg) {
                result += System.Convert.ToInt32(c);
            }
            return result % 100; // hash table is of size 100
        }
    }
}