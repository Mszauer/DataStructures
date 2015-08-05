using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using System.IO;

namespace DataStructures{
    class Program {
        static void Main(string[] args) {
            HashTable<string, int> data = new HashTable<string, int>(100, CustomHash);
            Console.WriteLine("Enter a command, or help for help");
            string command = Console.ReadLine();
            string[] words = command.Split(' ');
            do {
                if (command == "help" || command == "Help") {
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("\t add < key> < value >");
                    Console.WriteLine("\t remove < key >");
                    Console.WriteLine("\t set < key > < value >");
                    Console.WriteLine("\t saveText < path >");
                    Console.WriteLine("\t loadText < path >");
                    Console.WriteLine("\t saveBin < path >");
                    Console.WriteLine("\t loadBin < path >");
                    Console.WriteLine("\t list");
                    Console.WriteLine("\t exit");
                }
                if (command == "List" || command == "list") {
                    Console.Clear();
                }
                else if (command == "exit" || command == "Exit") {
                    Environment.Exit(0);
                }
                else if (words[0] == "add") {
                    data.Add(words[1], System.Convert.ToInt32(words[2]));
                }
                else if (words[0] == "remove") {
                    data.Remove(words[1]);
                }
                else if (words[0] == "set") {
                    data[words[1]] = System.Convert.ToInt32(words[2]);
                }
                else if (words[0] == "saveText") {

                }
                else if (words[0] == "loadText") {

                }
                else if (words[0] == "saveBin") {
                    FileStream stream = new FileStream("C:/Users/User/Desktop/out.bin", FileMode.CreateNew);
                    BinaryWriter writer = new BinaryWriter(stream);

                    writer.Dispose();
                    stream.Dispose();
                }
                else if (words[0] == "loadBin") {

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
