using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace Datastructures {
    class Simon {
        Vector<int> computerInput = new Vector<int>();
        Vector<int> userInput = new Vector<int>();

        public void Directions(string dir, string num) {
            Console.WriteLine("{0} the pattern, {1}", dir, num);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public void WriteKeys() {
            int i = 0;
            do{
                Console.WriteLine(" ^");
                Console.Write("< ");
                Console.Write(">");
                Console.WriteLine("\n v");
                System.Threading.Thread.Sleep(1000);
                char key = Console.ReadKey(false).KeyChar;
                switch (key) {
                    case 'w': //fall through aka switch version of logical OR/AND
                    case 'W':
                        userInput.Append(0);
                        SwitchHelper(0);
                        break;
                    case 'a':
                    case 'A':
                        userInput.Append(1);
                        SwitchHelper(1);
                        break;
                
                    case 'd':
                    case 'D':
                        userInput.Append(2);
                        SwitchHelper(2);
                        break;
                    case 's':
                    case 'S':
                        userInput.Append(3);
                        SwitchHelper(3);
                        break;
                }

            
                Console.Clear();
                i++;
            } while(i < computerInput.Size);
        }

        public void HighLightKeys(int nextColor) {
            computerInput.Append(nextColor);
#if DEBUG
            Console.WriteLine("Size: " + computerInput.Size + ", Capacity: " + computerInput.Capacity);
#endif
            for (int i = 0; i < computerInput.Size; i++) {
                SwitchHelper(computerInput[i]);
            }
                
        }

        void SwitchHelper(int number) {

            switch (number) {
                case 0:
                    Console.Clear();
                    Console.WriteLine(" ^", Console.ForegroundColor = ConsoleColor.Red);
                    Console.Write("< ", Console.ForegroundColor = ConsoleColor.White);
                    Console.Write(">");
                    Console.WriteLine("\n v");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                case 1:
                    Console.Clear();
                    Console.WriteLine(" ^");
                    Console.Write("< ", Console.ForegroundColor = ConsoleColor.Green);
                    Console.Write(">", Console.ForegroundColor = ConsoleColor.White);
                    Console.WriteLine("\n v");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine(" ^");
                    Console.Write("< ");
                    Console.Write(">", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.WriteLine("\n v", Console.ForegroundColor = ConsoleColor.White);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    break;

                case 3:
                    Console.Clear();
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

        public bool CorrectKeys() {
            bool correctOrder = true;
            for (int i = 0; i < computerInput.Size; i++) {
                if (userInput[i] != computerInput[i]) {
                    correctOrder = false;
                }

            }
            if (correctOrder) {
                return true;
            }
            return false;
        }

    }
}
