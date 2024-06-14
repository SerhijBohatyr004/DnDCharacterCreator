using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.UtilityModels
{
    public class Dice
    {
        public Dice(int diceQuantity, int edges) 
        {
            NumOfDice = diceQuantity;
            NumOfEdges = edges;
        }

        public int NumOfDice { get; set; }
        public int NumOfEdges { get; set; }

    }
}
