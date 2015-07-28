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
            do {
                game.CreateColors();
                game.Directions("Watch", System.Convert.ToString(3));
                game.Directions("Watch", System.Convert.ToString(2));
                game.Directions("Watch", System.Convert.ToString(1));
                game.Directions("Watch", "Go!");
                game.WriteKeys();
                game.HighLightKeys();
                game.Directions("Repeat", System.Convert.ToString(3));
                game.Directions("Repeat", System.Convert.ToString(2));
                game.Directions("Repeat", System.Convert.ToString(1));
                game.Directions("Repeat", "Go!");
            } while (game.CorrectKeys());
        }
        
    }
}
