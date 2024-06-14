using Core.Enums;
using Core.Models;
using Core.Models.UtilityModels.Stats;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICharacterService
    {
        public List<string> GetAllCharacterPreviews();

        public List<string> GetAllCharacterNames();

        public Result<List<Item>> GetChosenClassItems(string answer, ItemPair itemPair);

        public List<Item> GetBackItems(Background background);

        public Character GetCharacterByName(string name);

        public Result<bool> UpdateCharacterByName(Character character);

        public void FinishAbilityScore(Character character);

        public void AsignBackSkills(Character character);

        public Result<bool> AsignSkillProf(string skillName, Character character);

        public void CountSkillMods(Character character);

        public void FinishSavingThrows(Character character);

        public void CountProficiencyBonus(Character character);

        public void CountHP(Character character);

        public void FinishCharacterFeatures(Character character);

        public void RemoveCharacterByName(string name);

        public void CreateCharacter(string name, string gender, int age, int height, int weight, int level, Alignment alignment, Race race, SubRace subRace, CharacterClass characterClass, CharacterSubClass characterSubClass, Background background, AbilityScore abilityScore);
    }
}
