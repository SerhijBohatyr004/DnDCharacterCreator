using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.CharacterSubClasses
{
    public class BattleMaster : CharacterSubClass
    {
        public Dictionary<string, string> Maneuvers { get; set; } = new Dictionary<string, string>();

        public Dice SuperiorityDice { get; set; } = new Dice(4, 8);
    }
}
