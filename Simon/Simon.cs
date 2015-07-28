using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace Datastructures {
    class Simon {
        Vector<int> highlightedKeys = new Vector<int>();

        public void Directions(string dir, string num) {
            Console.WriteLine("{0} the pattern, {1}", dir, num);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public void WriteKeys() {
            Console.WriteLine(" ^");
            Console.Write("< ");
            Console.Write(">");
            Console.WriteLine("\n v");
            //Console.ReadLine();
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public void HighLightKeys(int nextColor) {
            highlightedKeys.Append(nextColor);
#if DEBUG
            Console.WriteLine("Size: " + highlightedKeys.Size + ", Capacity: " + highlightedKeys.Capacity);
#endif
            for (int i = 0; i < highlightedKeys.Size; i++) {
                switch (highlightedKeys[i]) {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Direction #" + (i + 1));
                        Console.WriteLine(" ^", Console.ForegroundColor = ConsoleColor.Red);
                        Console.Write("< ", Console.ForegroundColor = ConsoleColor.White);
                        Console.Write(">");
                        Console.WriteLine("\n v");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;

                    case 1:
                        Console.Clear();
                        Console.WriteLine("Direction #" + (i + 1));
                        Console.WriteLine(" ^");
                        Console.Write("< ", Console.ForegroundColor = ConsoleColor.Green);
                        Console.Write(">", Console.ForegroundColor = ConsoleColor.White);
                        Console.WriteLine("\n v");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Direction #" + (i + 1));
                        Console.WriteLine(" ^");
                        Console.Write("< ");
                        Console.Write(">", Console.ForegroundColor = ConsoleColor.Blue);
                        Console.WriteLine("\n v", Console.ForegroundColor = ConsoleColor.White);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Direction #" + (i + 1));
                        Console.WriteLine(" ^");
                        Console.Write("< ");
                        Console.Write(">");
                        Console.WriteLine("\n v", Console.ForegroundColor = ConsoleColor.Yellow);
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
                
        }
        //create vector, add random (0,4)
        //bools? true, false (correct key or not)
        //loop through vector and color the directions
        //next one is random

        public bool CorrectKeys() {
            //console highlight console.readkey with corresponding color
            //if correct go to next pattern
            return true ;
        }
    }
}
