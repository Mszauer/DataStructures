using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace Datastructures {
    class Simon {
        Vector<int> highlightedKeys = new Vector<int>();
        int nextColor = 0;
        Random r = new Random();
        /*Vector<ConsoleColor> colors = new Vector<ConsoleColor>();
        

        public void CreateColors() {
            colors.Append(ConsoleColor.Red);
            colors.Append(ConsoleColor.Green);
            colors.Append(ConsoleColor.Blue);
            colors.Append(ConsoleColor.Yellow);
        }*/

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
            switch (nextColor) {
                case 0:
                    Console.WriteLine(" ^", ConsoleColor.Red);
                    Console.Write("< ");
                    Console.Write(">");
                    Console.WriteLine("\n v");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                case 1:
                    Console.WriteLine(" ^");
                    Console.Write("< ", ConsoleColor.Green);
                    Console.Write(">");
                    Console.WriteLine("\n v");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                case 2:
                    Console.WriteLine(" ^");
                    Console.Write("< ");
                    Console.Write(">", ConsoleColor.Blue);
                    Console.WriteLine("\n v");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                case 3:
                    Console.WriteLine(" ^");
                    Console.Write("< ");
                    Console.Write(">");
                    Console.WriteLine("\n v", ConsoleColor.Yellow);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                default:
                    break;
            }
        }
        //console write arrow keys
        //left = green , right = blue
        //up =  red , down = yellow
        //Random start
        //create vector, add random (0,4)
        //bools? true, false (correct key or not)
        //loop through vector and color the directions
        //next one is random

        public bool CorrectKeys() {
            //console highlight console.readkey with corresponding color
            //if correct go to next pattern
            return false;
        }
    }
}
