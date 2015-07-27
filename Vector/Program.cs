using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures {
    class Program {
        static void Main(string[] args) {
            ////////////////////////////////////////////////////////////////////////////////////////////
            // 1st Test, expand vector 1 int at a time
            ////////////////////////////////////////////////////////////////////////////////////////////
            Log("*** TEST 1 ***");
            Log("Attempting to create and expand to 7 items one by one:");
            Vector<int> test = new Vector<int>();
            for (int i = 0; i < 28; i += 4) {
                Log(VecToString<int>(test));
                test.Append(i);
            }
            if (!TestVector<int>(true, test, 7, 8, 0, 4, 8, 12, 16, 20, 24)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            // 2nd Test. Reserve function
            ////////////////////////////////////////////////////////////////////////////////////////////
            Log("*** TEST 2 ***");
            Log("Attempting to call reserve and clear in various edge cases:");
            test.Reserve(0);
            if (!TestVector<int>(false, test, 7, 8, 0, 4, 8, 12, 16, 20, 24)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Reserve(2);
            if (!TestVector<int>(false, test, 7, 8, 0, 4, 8, 12, 16, 20, 24)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Clear();
            if (!TestVector<int>(false, test, 0, 0)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Reserve(88);
            if (!TestVector<int>(false, test, 0, 88)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < 28; i += 4) {
                test.Append(i);
            }
            test[1] = 77;
            if (!TestVector<int>(true, test, 7, 88, 0, 77, 8, 12, 16, 20, 24)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            // TEST 3 Order of operations
            ////////////////////////////////////////////////////////////////////////////////////////////
            Log("*** TEST 3 ***");
            Log("Trying to break with order of operations:");
            test.Clear();
            if (!TestVector<int>(false, test, 0, 0)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Reserve(10);
            if (!TestVector<int>(false, test, 0, 10)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Clear();
            if (!TestVector<int>(true, test, 0, 0)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////
            // TEST 4 Direct Memory Access (DMA)
            ////////////////////////////////////////////////////////////////////////////////////////////
            Log("*** TEST 4 ***");
            Log("Trying to break using direct memory access (DMA):");
            test.Clear();
            if (!TestVector<int>(false, test, 0, 0)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Append(1);
            if (!TestVector<int>(false, test, 1, 1, 1)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Append(2);
            if (!TestVector<int>(false, test, 2, 2, 1, 2)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Append(3);
            if (!TestVector<int>(false, test, 3, 4, 1, 2, 3)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test[3] = 4; // Index 3, element 4 was not appended yet
            // we should be able to do DMA here, but it will be overwritten soon
            if (!TestVector<int>(false, test, 3, 4, 1, 2, 3, 4)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }
            test.Append(5);
            if (!TestVector<int>(true, test, 4, 4, 1, 2, 3, 5)) {
                System.Diagnostics.Debugger.Break();
                Console.ReadLine();
                return;
            }


            Console.ReadLine();
        }

        static bool Compare<T>(T x, T y) where T : class {
            return x == y;
        }

        static bool TestVector<T>(bool greenText, Vector<T> toTest, int expectedSize, int expectedCapacity, params T[] expectedValue) {
            bool error = false;

            if (toTest.Size != expectedSize || toTest.Capacity != expectedCapacity) {
                error = true;
            }

            for (int i = 0; i < toTest.Size; ++i) {
                if (!EqualityComparer<T>.Default.Equals(toTest[i], expectedValue[i])) {
                    error = true;
                    break;
                }
            }

            if (error) {
                LogError("Error:    " + VecToString<T>(toTest));
                StringBuilder output = new StringBuilder();
                output.Append("{");
                for (int i = 0; i < expectedValue.Length; ++i) {
                    output.Append(expectedValue[i].ToString());
                    if (i != expectedValue.Length - 1) {
                        output.Append(", ");
                    }
                }
                output.Append("}, Size: ");
                output.Append(expectedSize);
                output.Append(", Capacity: ");
                output.Append(expectedCapacity);
                LogError("Expected: " + output.ToString());

                
                return false;
            }

            if (greenText) {
                LogSuccess(VecToString<T>(toTest));
                Console.Write("\n");
            }
            else {
                Log(VecToString<T>(toTest));
            }
            return true;
        }

        static string VecToString<T>(Vector<T> vec) {
            StringBuilder output = new StringBuilder();
            output.Append("{");
            for (int i = 0; i < vec.Size; ++i) {
                output.Append(vec[i].ToString());
                if (i != vec.Size - 1) {
                    output.Append(", ");
                }
            }
            output.Append("}, Size: ");
            output.Append(vec.Size);
            output.Append(", Capacity: ");
            output.Append(vec.Capacity);

            return output.ToString();
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
    }
}
