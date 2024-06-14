using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.UtilityModels.Stats
{
    public class StatProfPair
    {
        public StatProfPair(Abilities rootAbility)
        {
            RootAbility = rootAbility;
        }

        public Abilities RootAbility { get; set; }

        public int StatValue { get; set; } = 0;

        public bool Profficiency { get; set; } = false;
    }
}
