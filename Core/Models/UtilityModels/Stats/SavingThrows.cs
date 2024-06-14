using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;

namespace Core.Models.UtilityModels.Stats
{
    public class SavingThrows
    {
        public StatProfPair Strength { get; set; } = new StatProfPair(Abilities.Strength);
        public StatProfPair Dexterity { get; set; } = new StatProfPair(Abilities.Dexterity);
        public StatProfPair Constitution { get; set; } = new StatProfPair(Abilities.Constitution);
        public StatProfPair Intelligence { get; set; } = new StatProfPair(Abilities.Intelligence);
        public StatProfPair Wisdom { get; set; } = new StatProfPair(Abilities.Wisdom);
        public StatProfPair Charisma { get; set; } = new StatProfPair(Abilities.Charisma);
    }
}
