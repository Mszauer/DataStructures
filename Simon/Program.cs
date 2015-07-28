using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace DataStructures {
    class Program {
        static void Main(string[] args) {
            Simon game = new Simon();
            game.Directions("Watch", System.Convert.ToString(3));
            game.Directions("Watch", System.Convert.ToString(2));
            game.Directions("Watch", System.Convert.ToString(1));
            game.Directions("Watch", "Go!");
            game.WriteKeys();
        }
        
    }
}
