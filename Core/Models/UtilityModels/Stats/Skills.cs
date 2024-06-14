using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.UtilityModels.Stats
{
    public class Skills
    {
        public StatProfPair Athletics { get; set; } = new StatProfPair(Abilities.Strength);

        public StatProfPair Acrobatics { get; set; } = new StatProfPair(Abilities.Dexterity);

        public StatProfPair SleightOfHand { get; set; } = new StatProfPair(Abilities.Dexterity);

        public StatProfPair Stealth { get; set; } = new StatProfPair(Abilities.Dexterity);

        public StatProfPair Arcana { get; set; } = new StatProfPair(Abilities.Intelligence);

        public StatProfPair History { get; set; } = new StatProfPair(Abilities.Intelligence);

        public StatProfPair Investigation { get; set; } = new StatProfPair(Abilities.Intelligence);

        public StatProfPair Nature { get; set; } = new StatProfPair(Abilities.Intelligence);

        public StatProfPair Religion { get; set; } = new StatProfPair(Abilities.Intelligence);

        public StatProfPair AnimalHandling { get; set; } = new StatProfPair(Abilities.Wisdom);

        public StatProfPair Insight { get; set; } = new StatProfPair(Abilities.Wisdom);

        public StatProfPair Medicine { get; set; } = new StatProfPair(Abilities.Wisdom);

        public StatProfPair Perception { get; set; } = new StatProfPair(Abilities.Wisdom);

        public StatProfPair Survival { get; set; } = new StatProfPair(Abilities.Wisdom);

        public StatProfPair Deception { get; set; } = new StatProfPair(Abilities.Charisma);

        public StatProfPair Intimidation { get; set; } = new StatProfPair(Abilities.Charisma);

        public StatProfPair Performance { get; set; } = new StatProfPair(Abilities.Charisma);

        public StatProfPair Persuation { get; set; } = new StatProfPair(Abilities.Charisma);
    }
}
