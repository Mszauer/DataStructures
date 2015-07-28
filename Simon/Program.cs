using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastructures;

namespace Datastructures {
    class Program {
        static void Main(string[] args) {
            Simon game = new Simon();
            Random r = new Random();
            int nextColor = 0;
            do {
                8game.Directions("Watch", System.Convert.ToString(3));
                game.Directions("Watch", System.Convert.ToString(2));
                game.Directions("Watch", System.Convert.ToString(1));
                game.Directions("Watch", "Go!");
                 
                game.WriteKeys();
                int previousColor = nextColor;
                do { nextColor = r.Next(0, 4); } while (nextColor == previousColor);
                game.HighLightKeys(nextColor);
                
                game.Directions("Repeat", System.Convert.ToString(3));
                game.Directions("Repeat", System.Convert.ToString(2));
                game.Directions("Repeat", System.Convert.ToString(1));
                game.Directions("Repeat", "Go!");
                game.WriteKeys();
                

            } while (game.CorrectKeys());
        }
        
    }
}
