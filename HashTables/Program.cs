using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataStructures {
    class Program {
        public static bool HadError = false;
        public static StreamWriter outStream = null;
        public static string outFile = "C:\\Users\\Martin\\Downloads\\test_output.txt";

        public static int CustomHash(string arg) {
            int result = 1;
            foreach (char c in arg) {
                result += System.Convert.ToInt32(c);
            }

            return result % 100; // hash table is of size 100
        }

        static void Main(string[] args) {
            if (System.IO.File.Exists(outFile)) {
                System.IO.File.Delete(outFile);
            }
            //outStream = File.CreateText(outFile);

            HashTable<string, int> test = new HashTable<string, int>(100, CustomHash);
            Log("Testing Add and [] getter");
            if (test.Size != 0) {
                LogError("Expecting size 0, got: " + test.Size);
            }
            TestSi(test, new string[0], new int[0]);
            test.Add("Apples", 2);
            if (test.Size != 1) {
                LogError("Expecting size 1, got: " + test.Size);
            }
            try {
                if (test["Apples"] != 2) {
                    LogError("Expecting \"Apples\" to be 2, not: " + test["Apples"]);
                }
            }
            catch (System.Exception e) {
                LogError("Exception trying to acces recently added \"Apples\"");
                LogError(e.ToString());
            }
            SLinkedList<string> ke = test.Keys;
            if (ke.Size != 1) {
                LogError("Keys accessor is busted, wrong size");
            }
            if (ke[0] != "Apples") {
                LogError("Keys accessor is busted, Apples not found");
            }
            TestSi(test, new string[] { "Apples" }, new int[] { 2 });
            test.Add("Oranges", 3);
            TestSi(test, new string[] { "Apples", "Oranges" }, new int[] { 2, 3 });
            test.Add("Bannanas", 7);
            TestSi(test, new string[] { "Apples", "Oranges", "Bannanas" }, new int[] { 2, 3, 7 });

            try {
                test.Add("Bannanas", 19);
                LogError("Tried to add \"Bannanas\" twice and program did not throw exception");
            }
            catch (System.Exception e) {
                Log("Could add insert duplicate keys");
            }

            try {
                int potatoe = test["Potatoes"];
                LogError("Accessing key \"Potatoes\" did not throw exception");
                LogError("\tInstead returned: " + potatoe.ToString());
            }
            catch (System.Exception e) {
                Log("Could not access non-existant key");
            }


            Log("\nTesting [] setter");
            try {
                test["Potatoes"] = 7;
                LogError("Setting \"Potatoes\" did not throw exception");
            }
            catch (System.Exception e) {
                Log("Could not set non-existant key");
            }
            if (test["Bannanas"] != 7) {
                LogError("Expecting \"Bannanas\" to equal 7, not: " + test["Bannanas"].ToString());
            }
            else {
                Log("equality correct");
            }
            test["Bannanas"] = 20;
            if (test["Bannanas"] != 20) {
                LogError("Expecting \"Bannanas\" to equal 20, not: " + test["Bannanas"].ToString());
            }
            else {
                Log("assignment correct");
            }

            test.Remove("Bannanas");
            TestSi(test, new string[] { "Apples", "Oranges" }, new int[] { 2, 3 });

            try {
                test.Remove("Olives");
                LogError("Trying to remove non existing key did not throw exception!");
            }
            catch (System.Exception e) {
                Log("Could not remove non existent key");
            }

            test.Remove("Oranges");
            TestSi(test, new string[] { "Apples" }, new int[] { 2 });

            test.Remove("Apples");
            TestSi(test, new string[] { }, new int[] { });

            Log("\nTesting hash");
            SLinkedList<string> keys = test.Keys;
            keys.AddHead("filler1");
            keys.AddHead("filler2");
            keys.AddHead("filler3");
            bool hasNon1 = false;
            for (int k = 0; k < keys.Size; ++k) {
                if (test.Hash(keys[k]) != 1) {
                    hasNon1 = true;
                    break;
                }
            }

            if (!hasNon1) {
                LogError("All hashes evaluated to 1. Implement CustomHash in Program.cs");
            }
            else {
                Log("No issues found");
            }

            if (!HadError) {
                LogSuccess("\nUnit tests finished");
            }
            else {
                LogError("\nUnit tests finished");
            }
            Log("Press enter to terminate");

            if (outStream != null) {
                outStream.Flush();
                outStream.Close();
            }
            Console.ReadLine();
        }

        public static void TestSi(HashTable<string, int> hash, string[] keys, int[] values) {
            Test<string, int>(hash, keys, values);
        }

        public static void Test<K, V>(HashTable<K, V> hash, K[] keys, V[] values) {
            bool error = false;
            if (hash.Size != keys.Length) {
                error = true;
            }

            SLinkedList<K> k = hash.Keys;


            if (!error) {
                for (int i = 0; i < k.Size; ++i) {
                    bool found = false;
                    for (int j = 0; j < keys.Length; ++j) {
                        if (eq<K>(k[i], keys[j])) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        LogError("Unexpected key: " + k[i].ToString() + " found\n");
                        error = true;
                    }
                    if (error) {
                        break;
                    }
                }
            }

            if (!error) {
                for (int i = 0; i < keys.Length; ++i) {
                    bool found = false;
                    for (int j = 0; j < k.Size; ++j) {
                        if (eq<K>(k[j], keys[i])) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        LogError("Expected key: " + k[i].ToString() + " not found\n");
                        error = true;
                    }
                    if (error) {
                        break;
                    }
                }
            }

            if (!error) {
                for (int i = 0; i < keys.Length; ++i) {
                    if (!eq<V>(hash[keys[i]], values[i])) {
                        LogError("Value for " + keys[i].ToString() + " does not match\n");
                        LogError("\tResult " + values[i].ToString() + " does not match\n");
                        LogError("\tExpected " + hash[keys[i]].ToString() + " does not match\n");
                        error = true;
                        break;
                    }
                }
            }

            if (error) {
                LogError(Verbose<K, V>(hash));
            }
            else {
                Log(Short<K, V>(hash));
            }
        }

        static bool eq<K>(K l, K r) {
            return System.Collections.Generic.EqualityComparer<K>.Default.Equals(l, r);
        }

        static string Short<K, V>(HashTable<K, V> table) {
            StringBuilder b = new StringBuilder();
            b.Append("Table(" + table.Size + ")");
            return b.ToString();
        }

        static string Verbose<K, V>(HashTable<K, V> table) {
            StringBuilder b = new StringBuilder();

            b.Append("Table(" + table.Size + ")\n");
            SLinkedList<K> keys = table.Keys;
            for (int i = 0; i < keys.Size; ++i) {
                b.Append("\t" + keys[i] + ": " + table[keys[i]] + "\n");
            }

            return b.ToString();
        }

        static void LogError(string message) {
            HadError = true;
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            if (outStream != null) {
                outStream.WriteLine(message);
            }
            Console.ForegroundColor = foreground;
        }

        static void Log(string message) {
            Console.WriteLine(message);
            if (outStream != null) {
                outStream.WriteLine(message);
            }
        }

        static void LogSuccess(string message) {
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            if (outStream != null) {
                outStream.WriteLine(message);
            }
            Console.ForegroundColor = foreground;
        }
    }
}