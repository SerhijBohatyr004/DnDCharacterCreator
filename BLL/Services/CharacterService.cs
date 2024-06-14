using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using BLL.Interfaces;
using Core.Enums;
using Core.Models.UtilityModels.Stats;
using Core.Models.UtilityModels;
using System.Xml.XPath;

namespace BLL.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IGenericRepository<Character> _repository;

        public CharacterService(IGenericRepository<Character> repository)
        {
            _repository = repository;
        }

        public List<string> GetAllCharacterPreviews()
        {
            IEnumerable<Character> characters = GetAllCharacters();
            List<string> characterPreviews = new List<string>();

            foreach (var character in characters) 
            {
                string characterPreview = " " + character.CharName + " | " + "Race: " + character.Race.RaceName + " | " + "Class: " + character.CharacterClass.ClassName + " | " + "Background: " + character.CharacterBackground.BackName;
                characterPreviews.Add(characterPreview);
            }
            return characterPreviews;
        }

        public List<string> GetAllCharacterNames()
        {
            IEnumerable<Character> characters = GetAllCharacters();
            List<string> characterNames = new List<string>();

            foreach (var character in characters)
            {
                string characterName = character.CharName;
                characterNames.Add(characterName);
            }
            return characterNames;
        }

        

        public Character GetCharacterByName(string name)
        {
            var getCharacterResult = _repository.GetSingleByCondition(character => character.CharName == name);

            if (!getCharacterResult.IsSuccess)
            {
                return null;
            }

            else return getCharacterResult.Data;
        }

        public Result<bool> UpdateCharacterByName(Character character)
        {
            string name = character.CharName;

            return _repository.Update(character, ch => ch.CharName == name);
        }

        public void  RemoveCharacterByName(string name)
        {
            _repository.Delete(character => character.CharName == name);
        }

        public void CreateCharacter(string name, string gender, int age, int height, int weight, int level, Alignment alignment, Race race, SubRace subRace, CharacterClass characterClass, CharacterSubClass characterSubClass, Background background, AbilityScore abilityScore)
        {
            Character character = new Character();

            character.CharName = name;
            character.Gender = gender;
            character.Age = age;
            character.Height = height;
            character.Weight = weight;
            character.CharacterLevel = level;
            character.Alignment = alignment;
            character.Race = race;
            character.CharacterSubRace = subRace;
            character.CharacterClass = characterClass;
            character.CharacterSubClass = characterSubClass;
            character.CharacterBackground = background;
            character.CharacterAbilityScore = abilityScore;

            _repository.Add(character);
        }

        public List<Item> GetBackItems(Background background)
        {
            List<Item> items = new List<Item>();

            foreach (Item backItem in background.BackEquipment)
            {
                Item item = new Item();
                item.Name = backItem.Name;
                item.Description = backItem.Description;
                item.Price = backItem.Price;
                item.Weight = backItem.Weight;
                item.Quantity = backItem.Quantity;

                items.Add(item);
            }

            return items;
        }

        public Result<List<Item>> GetChosenClassItems(string answer, ItemPair itemPair)
        {
            List<Item> itemList = new List<Item>();

            if (answer != "A" && answer != "a" && answer != "B" && answer != "b")
            {
                return Result<List<Item>>.Failure("Invalid input.");
            }
            else
            {
                if (answer == "A" || answer == "a")
                {
                    foreach (Item classItem in itemPair.A)
                    {
                        Item item = new Item();
                        item.Name = classItem.Name;
                        item.Description = classItem.Description;
                        item.Price = classItem.Price;
                        item.Weight = classItem.Weight;
                        item.Quantity = classItem.Quantity;

                        itemList.Add(item);
                    }
                }
                else
                {
                    foreach (Item classItem in itemPair.B)
                    {
                        Item item = new Item();
                        item.Name = classItem.Name;
                        item.Description = classItem.Description;
                        item.Price = classItem.Price;
                        item.Weight = classItem.Weight;
                        item.Quantity = classItem.Quantity;

                        itemList.Add(item);
                    }
                }
            }
            return Result<List<Item>>.Success(itemList);
        }

        public void FinishAbilityScore(Character character)
        {
            AbilityScore abilityScore = character.CharacterAbilityScore;
            AbilityScore raceScore = character.Race.RaceAbilityScoreBonus;
            AbilityScore subRaceScore = new AbilityScore();
            if (character.CharacterSubRace != null)
            {
                subRaceScore = character.CharacterSubRace.SubRaceAbilityScoreBonus;
            }
            

            abilityScore.Strength += raceScore.Strength + subRaceScore.Strength;
            abilityScore.Dexterity += raceScore.Dexterity + subRaceScore.Dexterity;
            abilityScore.Constitution += raceScore.Constitution + subRaceScore.Constitution;
            abilityScore.Intelligence += raceScore.Intelligence + subRaceScore.Intelligence;
            abilityScore.Wisdom += raceScore.Wisdom + subRaceScore.Wisdom;
            abilityScore.Charisma += raceScore.Charisma + subRaceScore.Charisma;

            CountAbilityMods(character);
        }

        public void CountAbilityMods(Character character)
        {
            AbilityScore abilityScore = character.CharacterAbilityScore;
            AbilityScore abilityScoreMods = character.CharacterAbilityScoreMods;

            abilityScoreMods.Strength = (abilityScore.Strength - 10) / 2;
            abilityScoreMods.Dexterity = (abilityScore.Dexterity - 10) / 2;
            abilityScoreMods.Constitution = (abilityScore.Constitution - 10) / 2;
            abilityScoreMods.Intelligence = (abilityScore.Intelligence - 10) / 2;
            abilityScoreMods.Wisdom = (abilityScore.Wisdom - 10) / 2;
            abilityScoreMods.Charisma = (abilityScore.Charisma - 10) / 2;
        }

        public void AsignBackSkills(Character character)
        {
            Skills skills = character.CharacterSkills;
            Skills backSkills = character.CharacterBackground.BackSkillProficiencies;

            skills.Athletics.Profficiency = backSkills.Athletics.Profficiency;
            skills.Acrobatics.Profficiency = backSkills.Acrobatics.Profficiency;
            skills.SleightOfHand.Profficiency = backSkills.SleightOfHand.Profficiency;
            skills.Stealth.Profficiency = backSkills.Stealth.Profficiency;
            skills.Arcana.Profficiency = backSkills.Arcana.Profficiency;
            skills.History.Profficiency = backSkills.History.Profficiency;
            skills.Investigation.Profficiency = backSkills.Investigation.Profficiency;
            skills.Nature.Profficiency = backSkills.Nature.Profficiency;
            skills.Religion.Profficiency = backSkills.Religion.Profficiency;
            skills.AnimalHandling.Profficiency = backSkills.AnimalHandling.Profficiency;
            skills.Insight.Profficiency = backSkills.Insight.Profficiency;
            skills.Medicine.Profficiency = backSkills.Medicine.Profficiency;
            skills.Perception.Profficiency = backSkills.Perception.Profficiency;
            skills.Survival.Profficiency = backSkills.Survival.Profficiency;
            skills.Deception.Profficiency = backSkills.Deception.Profficiency;
            skills.Intimidation.Profficiency = backSkills.Intimidation.Profficiency;
            skills.Performance.Profficiency = backSkills.Performance.Profficiency;
            skills.Persuation.Profficiency = backSkills.Persuation.Profficiency;
        }

        public Result<bool> AsignSkillProf(string skillName, Character character)
        {
            Skills skills = character.CharacterSkills;

            switch (skillName)
            {
                case "Athletics":
                    if (skills.Athletics.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Athletics.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Acrobatics":
                    if (skills.Acrobatics.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Acrobatics.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Sleight of Hand":
                    if (skills.SleightOfHand.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.SleightOfHand.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Stealth":
                    if (skills.Stealth.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Stealth.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Arcana":
                    if (skills.Arcana.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Arcana.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "History":
                    if (skills.History.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.History.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Investigation":
                    if (skills.Investigation.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Investigation.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Nature":
                    if (skills.Nature.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Nature.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Religion":
                    if (skills.Religion.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Religion.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Animal Handling":
                    if (skills.AnimalHandling.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.AnimalHandling.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Insight":
                    if (skills.Insight.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Insight.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Medicine":
                    if (skills.Medicine.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Medicine.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Perception":
                    if (skills.Perception.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Perception.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Survival":
                    if (skills.Survival.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Survival.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Deception":
                    if (skills.Deception.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Deception.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Intimidation":
                    if (skills.Intimidation.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Intimidation.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Performance":
                    if (skills.Performance.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Performance.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                case "Persuation":
                    if (skills.Persuation.Profficiency == true)
                    {
                        return Result<bool>.Failure("This skill already has a proficiency, you have to pick another.");
                    }
                    else
                    {
                        skills.Persuation.Profficiency = true;
                        return Result<bool>.Success(true);
                    }

                default:
                    return Result<bool>.Failure("Skill with that name is not found.");
            }
        }

        public void CountSkillMods(Character character)
        {
            Skills skills = character.CharacterSkills;
            int str = character.CharacterAbilityScoreMods.Strength;
            int dex = character.CharacterAbilityScoreMods.Dexterity;
            int intt = character.CharacterAbilityScoreMods.Intelligence;
            int wis = character.CharacterAbilityScoreMods.Wisdom;
            int cha = character.CharacterAbilityScoreMods.Charisma;
            int profMod = character.ProficiencyBonus;

            skills.Acrobatics.StatValue = skills.Acrobatics.Profficiency ? dex + profMod : dex;
            skills.Athletics.StatValue = skills.Athletics.Profficiency ? str + profMod : str;
            skills.SleightOfHand.StatValue = skills.SleightOfHand.Profficiency ? dex + profMod : dex;
            skills.Stealth.StatValue = skills.Stealth.Profficiency ? dex + profMod : dex;
            skills.Arcana.StatValue = skills.Arcana.Profficiency ? intt + profMod : intt;
            skills.History.StatValue = skills.History.Profficiency ? intt + profMod : intt;
            skills.Investigation.StatValue = skills.Investigation.Profficiency ? intt + profMod : intt;
            skills.Nature.StatValue = skills.Nature.Profficiency ? intt + profMod : intt;
            skills.Religion.StatValue = skills.Religion.Profficiency ? intt + profMod : intt;
            skills.AnimalHandling.StatValue = skills.AnimalHandling.Profficiency ? wis + profMod : wis;
            skills.Insight.StatValue = skills.Insight.Profficiency ? wis + profMod : wis;
            skills.Medicine.StatValue = skills.Medicine.Profficiency ? wis + profMod : wis;
            skills.Perception.StatValue = skills.Perception.Profficiency ? wis + profMod : wis;
            skills.Survival.StatValue = skills.Survival.Profficiency ? wis + profMod : wis;
            skills.Deception.StatValue = skills.Deception.Profficiency ? cha + profMod : cha;
            skills.Intimidation.StatValue = skills.Intimidation.Profficiency ? cha + profMod : cha;
            skills.Performance.StatValue = skills.Performance.Profficiency ? cha + profMod : cha;
            skills.Persuation.StatValue = skills.Persuation.Profficiency ? cha + profMod : cha;
        }

        public void FinishSavingThrows(Character character)
        {
            SavingThrows savingThrows = character.CharacterSavingThrows;
            SavingThrows classSavingThrows = character.CharacterClass.ClassSavingThrows;
            AbilityScore scoreMods = character.CharacterAbilityScoreMods;
            int profMod = character.ProficiencyBonus;

            if (classSavingThrows.Strength.Profficiency == true)
            {
                savingThrows.Strength.Profficiency = true;
                savingThrows.Strength.StatValue = scoreMods.Strength + profMod;
            }
            else
            {
                savingThrows.Strength.StatValue = scoreMods.Strength;
            }

            if (classSavingThrows.Dexterity.Profficiency == true)
            {
                savingThrows.Dexterity.Profficiency = true;
                savingThrows.Dexterity.StatValue = scoreMods.Dexterity + profMod;
            }
            else
            {
                savingThrows.Dexterity.StatValue = scoreMods.Dexterity;
            }

            if (classSavingThrows.Constitution.Profficiency == true)
            {
                savingThrows.Constitution.Profficiency = true;
                savingThrows.Constitution.StatValue = scoreMods.Constitution + profMod;
            }
            else
            {
                savingThrows.Constitution.StatValue = scoreMods.Constitution;
            }

            if (classSavingThrows.Intelligence.Profficiency == true)
            {
                savingThrows.Intelligence.Profficiency = true;
                savingThrows.Intelligence.StatValue = scoreMods.Intelligence + profMod;
            }
            else
            {
                savingThrows.Intelligence.StatValue = scoreMods.Intelligence;
            }

            if (classSavingThrows.Wisdom.Profficiency == true)
            {
                savingThrows.Wisdom.Profficiency = true;
                savingThrows.Wisdom.StatValue = scoreMods.Wisdom + profMod;
            }
            else
            {
                savingThrows.Wisdom.StatValue = scoreMods.Wisdom;
            }

            if (classSavingThrows.Charisma.Profficiency == true)
            {
                savingThrows.Charisma.Profficiency = true;
                savingThrows.Charisma.StatValue = scoreMods.Charisma + profMod;
            }
            else
            {
                savingThrows.Charisma.StatValue = scoreMods.Charisma;
            }
        }

        public void CountProficiencyBonus(Character character)
        {
            int level = character.CharacterLevel;
            
            if (level > 0 && level < 5 ) 
            {
                character.ProficiencyBonus = 2;
            }
            if (level > 4 && level < 9)
            {
                character.ProficiencyBonus = 3;
            }
            if (level > 8 && level < 13)
            {
                character.ProficiencyBonus = 4;
            }
            if (level > 12 && level < 17)
            {
                character.ProficiencyBonus = 5;
            }
            if (level > 16)
            {
                character.ProficiencyBonus = 6;
            }
        }

        public void CountHP(Character character)
        {
            Dice hitDice = character.CharacterClass.HitDice;
            character.HitDice = hitDice;
            int conMod = character.CharacterAbilityScoreMods.Constitution;

            character.HitPoints = hitDice.NumOfEdges + conMod;
        }

        public void FinishCharacterFeatures(Character character)
        {
            character.CharacterFeatures.Clear();

            Dictionary<string, string> backgroundFeats = character.CharacterBackground.BackFeatures;
            Dictionary<string, string> characterClassFeats = character.CharacterClass.ClassFeatures;
            Dictionary<string, string> characterSubClassFeats = new Dictionary<string, string>();
            if (character.CharacterSubClass != null)
            {
                characterSubClassFeats = character.CharacterSubClass.SubClassFeatures;
            }
            Dictionary<string, string> raceFeats = character.Race.RaceFeatures;
            Dictionary<string, string> subRaceFeats = new Dictionary<string, string>();
            if (character.CharacterSubRace != null)
            {
                subRaceFeats = character.CharacterSubRace.SubRaceFeatures;
            }

            foreach (KeyValuePair<string, string> feat in backgroundFeats)
            {
                character.CharacterFeatures.Add(feat.Key, feat.Value);
            }

            foreach (KeyValuePair<string, string> feat in characterClassFeats)
            {
                character.CharacterFeatures.Add(feat.Key, feat.Value);
            }

            foreach (KeyValuePair<string, string> feat in characterSubClassFeats)
            {
                character.CharacterFeatures.Add(feat.Key, feat.Value);
            }

            foreach (KeyValuePair<string, string> feat in raceFeats)
            {
                character.CharacterFeatures.Add(feat.Key, feat.Value);
            }

            foreach (KeyValuePair<string, string> feat in subRaceFeats)
            {
                character.CharacterFeatures.Add(feat.Key, feat.Value);
            }
        }

        private IEnumerable<Character> GetAllCharacters()
        {
            try
            {
                var result = _repository.GetAll();

                if (!result.IsSuccess)
                {
                    throw new Exception("Failed to get all characters");
                }
                else
                {
                    IEnumerable<Character> characters = result.Data;
                    return characters;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get all characters. Exception: {ex.Message}");
            }
        }
    }
}
