using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace BinaryHeap {
    class Program {
        static void Main(string[] args) {
            ////////////////////////////////////////////////////////////////////////////////////////////
            // TEST 1 - test enqueue
            ////////////////////////////////////////////////////////////////////////////////////////////
            BinaryHeap<int> heap = new BinaryHeap<int>(cmp);
            int[] Vals1 = new int[] { 7, 2, 3, 5, 8 };
            Log("Testing enqueue");
            Log(HeapToString<int>(heap));

            for (int i = 0; i < 5; ++i) {
                heap.Enqueue(Vals1[i]);
                Log(HeapToString<int>(heap));
            }

            Log("\nIndex of 2: " + heap.IndexOf(2));
            Log("Index of 3: " + heap.IndexOf(3));
            Log("Index of 8: " + heap.IndexOf(8));
            Log("Index of 4: " + heap.IndexOf(4));


            ////////////////////////////////////////////////////////////////////////////////////////////
            // TEST 2 - test dequeue / re-queue
            ////////////////////////////////////////////////////////////////////////////////////////////
            Log("\nTesting requeue");

            for (int i = 0; i < 5; i++) {
                StringBuilder sb = new StringBuilder();
                sb.Append("Dequeue : ");
                sb.Append(heap.Dequeue());
                sb.Append(" : ");
                heap.Enqueue(10);
                Log(sb.ToString() + HeapToString<int>(heap));
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            // TEST 3 - clear and do one last enqueue and dequeue cycle 
            ////////////////////////////////////////////////////////////////////////////////////////////
            Log("\nClear");
            heap.Clear();

            int[] vals2 = new int[]{ 9, 0, 1, 6, 4, 7, 2, 3, 5, 8 };

            for (int i = 0; i < 10; ++i) {
                heap.Enqueue(vals2[i]);
                Log(HeapToString<int>(heap));
            }

            while (heap.Size > 1) { //always 21
                StringBuilder sb = new StringBuilder();
                sb.Append("Dequeue : ");
                sb.Append(heap.Dequeue());
                sb.Append(" : ");
                Log(sb.ToString() + HeapToString<int>(heap));
            }

            Console.ReadLine();
        }

        public static string HeapToString<T>(BinaryHeap<T> heap) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Heap Contents : ");
            for (int i = 1; i < heap.Size; ++i) {
                sb.Append(heap[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        static void LogError(string message) {
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

        static int cmp(int l, int r) {
            if (l < r) {
                return -1;
            }
            else if (l > r) {
                return 1;
            }
            return 0;
        }
    }

}
