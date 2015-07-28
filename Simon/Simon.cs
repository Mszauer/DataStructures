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
        Vector<ConsoleColor> colors = new Vector<ConsoleColor>();
        

        public void CreateColors() {
            colors.Append(ConsoleColor.Red);
            colors.Append(ConsoleColor.Green);
            colors.Append(ConsoleColor.Blue);
            colors.Append(ConsoleColor.Yellow);
        }

        public void Directions(string dir, string num) {
            //console write watch the pattern, 3/2/1/Go!
            //thread.sleep (1sec)
            //console.clear
            //switch to next console write
            Console.WriteLine("{0} the pattern, {1}", dir, num);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public void WriteKeys() {
            Console.WriteLine(" ^");
            Console.Write("< ");
            Console.Write(">");
            Console.WriteLine("\n v");
            Console.ReadLine();
        }

        public void HighLightKeys() {
            nextColor = r.Next(0, 5);
            Console.WriteLine(">", ConsoleColor.Blue);
        }
        //console write arrow keys
        //left = green , right = blue
        //up =  red , down = yellow
        //Random start
        //create vector, add random (0,4)
        //bools? true, false (correct key or not)
        //loop through vector and color the directions
        //next one is random

        //console write repeat the pattern, 3/2/1/Go!
        //thread sleep 1sec
        //Console.Write arrows keys
        //console highlight console.readkey with corresponding color
        //if correct go to next pattern
    }
}
