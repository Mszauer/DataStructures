using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    class Program {
        static void Main(string[] args) {

            SLinkedList<int> test = new SLinkedList<int>();

            Log("Testing AddHead");
            Test(test);
            test.AddHead(3);
            Test(test, 3);
            test.AddHead(7);
            Test(test, 7, 3);
            test.AddHead(5);
            Test(test, 5, 7, 3);
            test.AddHead(2);
            Test(test, 2, 5, 7, 3);

            Log("\nTesting Clear");
            test.Clear();
            Test(test);

            Log("\nTesting AddTail");
            test.AddTail(3);
            Test(test, 3);
            test.AddTail(7);
            Test(test, 3, 7);
            test.AddTail(5);
            Test(test, 3, 7, 5);
            test.AddTail(2);
            Test(test, 3, 7, 5, 2);

            Log("\nMixing AddHead and AddTail");
            test.Clear();
            test.AddHead(3);
            Test(test, 3);
            test.AddTail(7);
            Test(test, 3, 7);
            test.AddHead(5);
            Test(test, 5, 3, 7);
            test.AddTail(2);
            Test(test, 5, 3, 7, 2);

            Log("\nTesting head and tail getters");
            if (test.Head.Data != 5) {
                LogError("Head expecting 5, got" + test.Head.Data);
            }
            else {
                Log("Head is: " + test.Head.Data);
            }

            if (test.Tail.Data != 2) {
                LogError("Tail expecting 2, got" + test.Tail.Data);
            }
            else {
                Log("Tail is: " + test.Tail.Data);
            }

            test.Clear();

            try {
                SLinkedList<int>.Node nn = test.Tail;
            }
            catch (System.Exception e) {
                LogError("Tail should be null, but threw an exception!");
                LogError("In the tail getter, check if head is null before you try to iterate it");
                Console.ReadLine();
                return;
            }

            if (test.Head != test.Tail && test.Head != null) {
                LogError("Error, expecting head and tail to be null");
            }
            else {
                Log("Head and tail are null as expected");
            }

            Log("\nTesting Size and [] getters");
            if (test.Size != 0) {
                LogError("Tail expecting 0, got" + test.Size);
            }
            else {
                Log("Size is 0 as expected");
            }
            for (int i = 0; i < 20; i += i + 1) {
                test.AddHead(i);
            }
            Test(test, 15, 7, 3, 1, 0);

            if (test[0] != 15) {
                LogError("test[0],  expecting 15, got" + test[0]);
            }
            else {
                Log("test[0] is 15");
            }

            if (test[2] != 3) {
                LogError("test[2],  expecting 3, got" + test[2]);
            }
            else {
                Log("test[2] is 3");
            }

            try {
                LogError("test[7],  did not throw exception, returned" + test[6]);
            }
            catch (System.Exception e) {
                Log("test[7] threw exception");
            }

            Log("\nTesting IndexOf");
            if (test.IndexOf(15) != 0) {
                LogError("index of 15, expected 0, got" + test.IndexOf(15));
            }
            else {
                Log("index of 15 is 0");
            }

            if (test.IndexOf(3) != 2) {
                LogError("index of 3, expected 2, got" + test.IndexOf(3));
            }
            else {
                Log("index of 3 is 2");
            }

            if (test.IndexOf(17) != -1) {
                LogError("index of 17, expected -1, got" + test.IndexOf(17));
            }
            else {
                Log("index of 17 is -1");
            }

            Log("\nTesting InsertAt, RemoveAt");
            test.InsertAt(10, 0);
            Test(test, 10, 15, 7, 3, 1, 0);
            test.InsertAt(5, 3);
            Test(test, 10, 15, 7, 5, 3, 1, 0);
            test.InsertAt(4, test.Size - 1);
            Test(test, 10, 15, 7, 5, 3, 1, 0, 4);

            test.RemoveAt(0);
            Test(test, 15, 7, 5, 3, 1, 0, 4);
            try {
                test.RemoveAt(test.Size - 1);
            }
            catch (System.Exception e) {
                LogError("When you do a removeAt 0, make sure to reset head to the next element");
            }
            Test(test, 15, 7, 5, 3, 1, 0);
            try {
                test.RemoveAt(2);
            }
            catch (System.Exception e) {
                LogError("When you do a removeAt 0, make sure to reset head to the next element");
            }
            Test(test, 15, 7, 3, 1, 0);

            Log("\nTesting iterator");
            int[] itest = new int[] { 15, 7, 3, 1, 0 };
            SLinkedList<int>.Iterator iter = test.Begin();
            int index = 0;
            do {
                if (iter != null && iter.Data != itest[index]) {
                    LogError("Iteration " + index + " expected at: " + itest[index] + ", got: " + iter.Data);
                }
                else {
                    if (iter != null) {
                        Log(iter.Data + " / " + itest[index]);
                    }
                    else {
                        LogError("Iter " + index + " was null");
                    }
                }
                if (iter != null) {
                    iter.Next();
                }
                index += 1;
            } while (iter != null && iter.Data != 0);

            if (!HadError) {
                LogSuccess("\nUnit tests finished");
            }
            else {
                LogError("\nUnit tests finished");
            }
            Console.ReadLine();
        }

        public static bool HadError = false;

        public static void Test(SLinkedList<int> list, params int[] test) {
            bool error = false;
            if (list.Size != test.Length) {
                PrintError(list, test);
                error = true;
            }
            else {
                int index = 0;
                SLinkedList<int>.Node node = list.Head;

                while (node != null) {
                    if (index >= test.Length) {
                        PrintError(list, test);
                        error = true;
                        break;
                    }

                    if (node.Data != test[index]) {
                        PrintError(list, test);
                        error = true;
                        break;
                    }

                    node = node.Next;
                    index += 1;
                }
            }

            if (!error) {
                PrintList(list);
            }
        }

        public static void PrintError(SLinkedList<int> list, params int[] test) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Size: ");
            sb.Append(test.Length);
            sb.Append(", { ");
            for (int i = 0; i < test.Length; ++i) {
                sb.Append(test[i]);
                sb.Append(" ");
            }
            sb.Append("}");
            LogError("\nExpected: " + sb.ToString());
            LogError("Result:   " + AsString<int>(list));
        }

        public static void PrintList(SLinkedList<int> list) {
            Log(AsString<int>(list));
        }

        public static string AsString<T>(SLinkedList<T> list) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Size: ");
            sb.Append(list.Size);
            sb.Append(", { ");
            SLinkedList<T>.Node node = list.Head;

            while (node != null) {
                sb.Append(node.Data.ToString());
                sb.Append(" ");
                node = node.Next;
            }

            sb.Append("}");
            return sb.ToString();
        }

        static void LogError(string message) {
            HadError = true;
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = foreground;
        }

        static void Log(string message) {
            Console.WriteLine(message);
        }

        static void LogSuccess(string message) {
            ConsoleColor foreground = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = foreground;
        }
    }
}