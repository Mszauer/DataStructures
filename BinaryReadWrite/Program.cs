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
            
            do {
                string command = Console.ReadLine().ToLower();
                string[] words = command.Split(' ');
                if (command == "help" || command == "Help") {
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("\t add < key> < value >");
                    Console.WriteLine("\t remove < key >");
                    Console.WriteLine("\t set < key > < value >");
                    Console.WriteLine("\t saveText < path >");
                    Console.WriteLine("\t loadText < path >");
                    Console.WriteLine("\t saveBin < path >");
                    Console.WriteLine("\t loadBin < path >");
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
                    using (TextWriter writer = File.CreateText(words[1])) {
                        Console.WriteLine("Writing data now...");
                        SLinkedList<string> keys = data.Keys;
                        for (int i = 0 ; i < keys.Size; i++){
                            string key = keys[i];
                            int value = data[key];
                            writer.WriteLine(key + " " + value);
                        }
                        Console.WriteLine("File has been saved");
                    }
                }
                else if (words[0] == "loadText") {
                    if (File.Exists(words[1])) {
                        Console.WriteLine("Loading Data...");
                        using (TextReader reader = File.OpenText(words[1])) {
                            string content = reader.ReadLine();
                            while (content != null) {
                                string[] add = content.Split(' ');
                                data.Add(add[0], System.Convert.ToInt32(add[1]));
                                content = reader.ReadLine();
                            }
                        }
                        Console.WriteLine("Data has been loaded.");
                    }
                    else {
                        Console.WriteLine("File not found");
                    }
                }
                else if (words[0] == "saveBin") {
                    FileStream stream = new FileStream(words[1], FileMode.CreateNew);
                    BinaryWriter writer = new BinaryWriter(stream);
                    Console.WriteLine("Writing data now...");
                    SLinkedList<string> keys = data.Keys;
                    writer.Write((byte)data.Size);
                    for (int i = 0; i < keys.Size; i++) {
                        string key = keys[i];
                        int value = data[key];
                        writer.Write((byte)key.Length);
                        foreach (char c in key) {
                            writer.Write((byte)c);
                        }
                        //always 4bytes
                        writer.Write((int)value);
                    }
                    Console.WriteLine("Filed Saved");
                    writer.Dispose();
                    stream.Dispose();
                }
                else if (words[0] == "loadBin") {
                    if (File.Exists(words[1])) {
                        Console.WriteLine("Loading Data...");
                        using (BinaryReader reader = new BinaryReader(File.Open(words[1], FileMode.Open))) {
                            int size = reader.ReadByte();
                            for (int i = 0; i < size; i++) {
                                int length = (int)reader.ReadByte();
                                string key = "";
                                for (int j = 0; j < length; j++) {
                                    key += reader.ReadChar();
                                }
                                int value = reader.ReadInt32();
                                data.Add(key, value);
                            }
                        }
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
