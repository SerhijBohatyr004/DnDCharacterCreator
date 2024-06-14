using Core.Enums;
using Core.Models.CharacterClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using Core.Models.UtilityModels.Magic;

namespace Core.Models
{
    public class Character
    {
        public string CharName { get; set; }

        public string Gender { get; set; }

        public string? Backstory { get; set; }

        public Abilities? SpellCastintAbility { get; set; }

        public int? SpellDifficultyCheck { get; set; }

        public int Age { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int CharacterSpeed { get; set; }

        public int CharacterLevel { get; set; }

        public int ProficiencyBonus { get; set; }

        public int HitPoints { get; set; }

        public int ArmorClass { get; set; }

        public int TempHitPoints { get; set; }

        public int InitiativeBonus { get; set; }

        public int PassiveWisdom { get; set; }

        public Alignment Alignment { get; set; }

        public CreatureSize CharacterSize { get; set; }

        public Race Race { get; set; }

        public SubRace? CharacterSubRace { get; set; }

        public CharacterSubClass? CharacterSubClass { get; set; }

        public CharacterClass CharacterClass { get; set; }

        public Background CharacterBackground { get; set; }

        public AbilityScore CharacterAbilityScore { get; set; } = new AbilityScore();

        public AbilityScore CharacterAbilityScoreMods { get; set; } = new AbilityScore();

        public Skills CharacterSkills { get; set; } = new Skills();

        public SavingThrows CharacterSavingThrows { get; set; } = new SavingThrows();

        public Dictionary<string, string> CharacterFeatures { get; set; } = new Dictionary<string, string>();

        public List<Item> CharacterInventory { get; set; }

        public Dice HitDice { get; set; }

        public List<Spell> CharacterSpells { get; set; }

        public List<SpellSlot> CharacterSpellSlots { get; set; }
    }
}
