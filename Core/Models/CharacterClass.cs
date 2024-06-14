using Core.Enums;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class CharacterClass
    {
        public string ClassName { get; set; }

        public string ClassDescription { get; set; }

        public Dice HitDice { get; set; }

        public Dictionary<string, string> ClassFeatures { get; set; }

        public int AmountOfSkillProfs { get; set; }

        public SavingThrows ClassSavingThrows { get; set; } = new SavingThrows();

        public Skills ClassSkills { get; set; } = new Skills();

        public List<ItemPair> ClassInventory { get; set; }

        public List<string> SubClasses { get; set; }
    }
}
