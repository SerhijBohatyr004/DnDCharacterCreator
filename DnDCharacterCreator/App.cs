using BLL.Interfaces;
using Core.Enums;
using Core.Models;
using Core.Models.CharacterClasses;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UI
{
    public class App
    {
        private readonly ICharacterService _characterService;
        private readonly IRaceService _raceService;
        private readonly ISubRaceService _subRaceService;
        private readonly IBackgroundService _backgroundService;
        private readonly ICharacterClassService _characterClassService;
        private readonly ICharacterSubClassService _characterSubClassService;
        private readonly IAbilityScoreService _abilityScoreService;

        private readonly string _fatBorder = "======================================================================================================================";
        private readonly string _smallBorder = "_____________________________________________________________________________________________________________________";

        public App(ICharacterService characterService, IRaceService raceService, ISubRaceService subRaceService, IBackgroundService backgroundService, ICharacterClassService characterClassService, ICharacterSubClassService characterSubClassService, IAbilityScoreService abilityScoreService)
        {
            _characterService = characterService;
            _raceService = raceService;
            _subRaceService = subRaceService;
            _backgroundService = backgroundService;
            _characterClassService = characterClassService;
            _characterSubClassService = characterSubClassService;
            _abilityScoreService = abilityScoreService;
        }

        public void Run()
        {
            Console.WriteLine(_fatBorder);
            Console.WriteLine();

            Console.WriteLine("Welcome to DnD Character Creator!");
            Console.WriteLine();

            Console.WriteLine("Here are your characters:");
            Console.WriteLine(_smallBorder);


            List<string> characterPreviews = _characterService.GetAllCharacterPreviews();
            
            foreach (string characterPreview in characterPreviews) 
            {
                Console.WriteLine();
                Console.WriteLine(characterPreview);
                Console.WriteLine(_smallBorder);
            }
            Console.WriteLine();

            Console.WriteLine("This is what you can do with them:");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Check");
            Console.WriteLine("5. Create all default entities (do only when you open program for the first time)");
            Console.WriteLine();

            var commandSelect = BaseCommandSelect();

            while (!commandSelect.IsSuccess)
            {
                Console.WriteLine(commandSelect.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                commandSelect = BaseCommandSelect();
            }
        }

        private Result<bool> BaseCommandSelect()
        {
            string answer = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (answer)
            {
                case "1":
                    Console.WriteLine("Character creation started.");
                    Console.WriteLine(_fatBorder);
                    Console.WriteLine();

                    CreateCharacter();
                    break;

                case "2":
                    Console.WriteLine("Character editing started.");
                    Console.WriteLine(_fatBorder);
                    Console.WriteLine();

                    EditCharacter();
                    break;

                case "3":
                    Console.WriteLine("Character removal started.");
                    Console.WriteLine(_fatBorder);
                    Console.WriteLine();

                    DeleteCharacter();
                    break;

                case "4":
                    Console.WriteLine("Character check selected.");
                    Console.WriteLine(_fatBorder);
                    Console.WriteLine();

                    CheckCharacter();
                    break;

                case "5":
                    CreateAllDefaultEnitities();

                    Console.WriteLine("Default entities created.");
                    Console.WriteLine(_fatBorder);
                    Console.WriteLine();
                    break;

                default:
                    return Result<bool>.Failure("Invalid command number");
            }

            return Result<bool>.Success(true);
        }

        private void EditCharacter()
        {
            Console.WriteLine("Please, type in a name of the character you wish to check.");
            Console.WriteLine();

            string charName = Console.ReadLine()?.Trim();
            Console.WriteLine();

            Character character = _characterService.GetCharacterByName(charName);

            if (character != null)
            {
                Console.WriteLine($"Selected character: {character.CharName}");
                Console.WriteLine();

                Console.WriteLine("Select what do you want to change:");
                Console.WriteLine("1. Race");
                Console.WriteLine("2. Sub-Race");
                Console.WriteLine("3. Class");
                Console.WriteLine("4. Sub-Class");
                Console.WriteLine("5. Background");
                Console.WriteLine("6. Backstory");
                Console.WriteLine("7. Re-start score point buy");
                Console.WriteLine("8. Re-asign proficiencies for skills or re-choose starting items");
                Console.WriteLine("9. Height and Weight");
                Console.WriteLine("10. Age");
                Console.WriteLine("11. Gender");
                Console.WriteLine();

                string answer = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (answer)
                {
                    case "1":
                        var raceEdit = EditRace(character);

                        while (!raceEdit.IsSuccess)
                        {
                            Console.WriteLine(raceEdit.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            raceEdit = EditRace(character);
                        }
                        break;

                    case "2":
                        var subRaceEdit = EditSubRace(character);

                        while (!subRaceEdit.IsSuccess)
                        {
                            Console.WriteLine(subRaceEdit.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            raceEdit = EditSubRace(character);
                        }
                        break;

                    case "3":
                        var classEdit = EditClass(character);

                        while (!classEdit.IsSuccess)
                        {
                            Console.WriteLine(classEdit.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            classEdit = EditClass(character);
                        }
                        break;

                    case "4":
                        var subClassEdit = EditSubClass(character);

                        while (!subClassEdit.IsSuccess)
                        {
                            Console.WriteLine(subClassEdit.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            subClassEdit = EditSubClass(character);
                        }
                        break;

                    case "5":
                        var backgroundEdit = EditBackground(character);

                        while (!backgroundEdit.IsSuccess)
                        {
                            Console.WriteLine(backgroundEdit.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            backgroundEdit = EditBackground(character);
                        }
                        break;

                    case "6":
                        var backstoryEdit = EditBackstory(character);

                        while (!backstoryEdit.IsSuccess)
                        {
                            Console.WriteLine(backstoryEdit.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            backstoryEdit = EditBackstory(character);
                        }
                        break;

                    case "7":
                        var poinBuy = RestartPointBuy(character);

                        while (!poinBuy.IsSuccess)
                        {
                            Console.WriteLine(poinBuy.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            poinBuy = RestartPointBuy(character);
                        }
                        break;

                    case "8":
                        var characterFinish = RestartCharacterFinish(character);

                        while (!characterFinish.IsSuccess)
                        {
                            Console.WriteLine(characterFinish.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            backstoryEdit = RestartCharacterFinish(character);
                        }
                        break;

                    case "9":
                        var weightHeightResult = AskHeightAndWeight();

                        while (!weightHeightResult.IsSuccess)
                        {
                            Console.WriteLine(weightHeightResult.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            weightHeightResult = AskHeightAndWeight();
                        }

                        Console.WriteLine($"Height is set to: {weightHeightResult.Data.Item1} | Weight is set to:{weightHeightResult.Data.Item2}");
                        Console.WriteLine(_smallBorder);
                        Console.WriteLine();

                        character.Height = weightHeightResult.Data.Item1;
                        character.Weight = weightHeightResult.Data.Item2;
                        _characterService.UpdateCharacterByName(character);
                        break;


                    case "10":
                        var ageResult = AskAge();

                        while (!ageResult.IsSuccess)
                        {
                            Console.WriteLine(ageResult.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            ageResult = AskAge();
                        }
                        Console.WriteLine($"Age is set to: {ageResult.Data}");
                        Console.WriteLine(_smallBorder);
                        Console.WriteLine();

                        character.Age = ageResult.Data;
                        _characterService.UpdateCharacterByName(character);
                        break;

                    case "11":
                        var genderResult = AskGender();

                        while (!genderResult.IsSuccess)
                        {
                            Console.WriteLine(genderResult.ErrorMessage);
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();

                            genderResult = AskGender();
                        }
                        Console.WriteLine($"Gender is set to: {genderResult.Data}");
                        Console.WriteLine(_smallBorder);
                        Console.WriteLine();

                        character.Gender = genderResult.Data;
                        _characterService.UpdateCharacterByName(character);
                        break;

                    default:
                        Console.WriteLine("Error. Invalid command select.");
                        Console.WriteLine(_smallBorder);
                        Console.WriteLine();

                        EditCharacter();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error. Character with specified name was not found.");
                Console.WriteLine(_fatBorder);
                Console.WriteLine();

                EditCharacter();
            }
        }

        private void CheckCharacter()
        {
            Console.WriteLine("Please, type in a name of the character you wish to check.");
            Console.WriteLine();

            string charName = Console.ReadLine()?.Trim();
            Console.WriteLine();

            Character character = _characterService.GetCharacterByName(charName);

            if (character != null) 
            {
                Console.WriteLine($"Selected character: {character.CharName}");
                Console.WriteLine();

                Console.WriteLine("Select what do you want to have a look at:");
                Console.WriteLine("1. Features");
                Console.WriteLine("2. Ability score and its modifiers");
                Console.WriteLine("3. Skills");
                Console.WriteLine("4. Saving Throws");
                Console.WriteLine("5. Class specific feature");
                Console.WriteLine("6. Inventory");
                Console.WriteLine("7. Backstory");
                Console.WriteLine("8. Basic Info");
                Console.WriteLine();

                string answer = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (answer) 
                {
                    case "1":
                        Console.WriteLine("Here are features of your character:");
                        foreach (var feature in character.CharacterFeatures)
                        {
                            Console.WriteLine($"{feature.Key}: {feature.Value}");
                            Console.WriteLine(_smallBorder);
                            Console.WriteLine();
                        }
                        break;

                    case "2":
                        CheckAbilityScore(character);
                        break;

                    case "3":
                        CheckSkills(character);
                        break;

                    case "4":
                        CheckSavingThrows(character);
                        break;

                    case "5":
                        CheckClassSpecial(character);
                        break;

                    case "6":
                        CheckInventory(character);
                        break;

                    case "7":
                        Console.WriteLine(character.Backstory);
                        Console.WriteLine(_smallBorder);
                        Console.WriteLine();
                        break;

                    case "8":
                        CheckBasicInfo(character);
                        break;

                    default:
                        Console.WriteLine("Error. Invalid command select.");
                        Console.WriteLine(_smallBorder);
                        Console.WriteLine();

                        CheckCharacter();
                        break;

                }
            }
            else
            {
                Console.WriteLine("Error. Character with specified name was not found.");
                Console.WriteLine(_fatBorder);
                Console.WriteLine();

                CheckCharacter();
            }
        }

        private void DeleteCharacter()
        {
            Console.WriteLine("This aсtion will delete all characters with a certain name.");
            Console.WriteLine("Type in a name of the character you wish to delete.");
            Console.WriteLine("If you wish to cancel this action just don't type anything in and press 'Enter'.");
            Console.WriteLine();

            string charName = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (String.IsNullOrEmpty(charName))
            {
                return;
            }
            else
            {
                _characterService.RemoveCharacterByName(charName);
                Console.WriteLine(_fatBorder);
                Console.WriteLine();
            }
        }

        private void CreateAllDefaultEnitities()
        {
            _raceService.CreateAllRaces();
            _subRaceService.CreateAllSubRaces();
            _backgroundService.CreateAllBackgrounds();
        }

        private void CreateCharacter()
        {
            var nameInput = AskName();

            while (!nameInput.IsSuccess)
            {
                Console.WriteLine(nameInput.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                nameInput = AskName();
            }

            string name = nameInput.Data!;

            Console.WriteLine($"Name is set to {name}.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();


            var genderInput = AskGender();

            while (!genderInput.IsSuccess)
            {
                Console.WriteLine(genderInput.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                genderInput = AskGender();
            }

            string gender = genderInput.Data!;

            Console.WriteLine($"Gender is set to {gender}.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();


            var ageInput = AskAge();

            while (!ageInput.IsSuccess)
            {
                Console.WriteLine(ageInput.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                ageInput = AskAge();
            }

            int age = ageInput.Data!;

            Console.WriteLine($"Age is set to {age}.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();


            var heightWeightInput = AskHeightAndWeight();

            while (!heightWeightInput.IsSuccess) 
            {
                Console.WriteLine(heightWeightInput.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                heightWeightInput = AskHeightAndWeight();
            }

            (int, int) heightWeight = heightWeightInput.Data!;

            Console.WriteLine($"Height is set to {heightWeight.Item1}, weight is set to {heightWeight.Item2}");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();


            var selectedAlignment = SelectAlignment();

            while (!selectedAlignment.IsSuccess)
            {
                Console.WriteLine(selectedAlignment.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                selectedAlignment = SelectAlignment();
            }

            Alignment alignment = selectedAlignment.Data!;

            Console.WriteLine($"Alignment is set to {alignment}.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();


            var selectedRace = SelectRace();

            while (!selectedRace.IsSuccess)
            {
                Console.WriteLine(selectedRace.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                selectedRace = SelectRace();
            }

            Race race = selectedRace.Data!;

            Console.WriteLine($"Race is set to {race.RaceName}.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();


            var selectedSubRace = SelectSubRace(race);

            while (!selectedSubRace.IsSuccess)
            {
                Console.WriteLine(selectedSubRace.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                 selectedSubRace =  SelectSubRace(race);
            }

            SubRace subRace = selectedSubRace.Data!;

            if (subRace != null) 
            {
                Console.WriteLine($"Race is set to {subRace.SubRaceName}.");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }


            var selectedClass = SelectClass();

            while (!selectedClass.IsSuccess) 
            {
                Console.WriteLine(selectedClass.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                selectedClass = SelectClass();
            }

            CharacterClass characterClass = selectedClass.Data!;

            if (characterClass != null) 
            {
                Console.WriteLine($"Class is set to {characterClass.ClassName}.");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }


            var finishingClassResult = FinishClass(characterClass);

            while (!finishingClassResult.IsSuccess)
            {
                Console.WriteLine(finishingClassResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingClassResult = FinishClass(characterClass);
            }


            var selectedSubClass = SelectSubClass(characterClass);

            while (!selectedSubClass.IsSuccess) 
            {
                Console.WriteLine(selectedSubClass.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                selectedSubClass = SelectSubClass(characterClass);
            }

            CharacterSubClass characterSubClass = selectedSubClass.Data!;

            if (characterSubClass != null)
            {
                Console.WriteLine($"Sub class is set to {characterSubClass.SubClassName}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }


            var selectedBackground = SelectBackground();

            while (!selectedBackground.IsSuccess)
            {
                Console.WriteLine(selectedBackground.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                selectedBackground = SelectBackground();
            }

            Background background = selectedBackground.Data!;

            if (background != null) 
            {
                Console.WriteLine($"Character Background is set to {background.BackName}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var pointBuyResult = AbilityScorePointBuyStart();

            while (!pointBuyResult.IsSuccess)
            {
                Console.WriteLine(pointBuyResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                pointBuyResult = AbilityScorePointBuyStart();
            }

            AbilityScore abilityScore = pointBuyResult.Data!;

            if (abilityScore != null)
            {
                Console.WriteLine("These are ability scores of your character:");
                Console.WriteLine($"Strength: {abilityScore.Strength}");
                Console.WriteLine($"Dexterity: {abilityScore.Dexterity}");
                Console.WriteLine($"Constitution: {abilityScore.Constitution}");
                Console.WriteLine($"Intelligence: {abilityScore.Intelligence}");
                Console.WriteLine($"Wisdom: {abilityScore.Wisdom}");
                Console.WriteLine($"Charisma: {abilityScore.Charisma}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            _characterService.CreateCharacter(name, gender, age, heightWeight.Item1, heightWeight.Item2, 1, alignment, race, subRace, characterClass, characterSubClass, background, abilityScore);

            Character character = _characterService.GetCharacterByName(name);
            FinishCharacter(character);

            Console.WriteLine(_fatBorder);
            Console.WriteLine();
        }

        private Result<string> AskName()
        {
            Console.WriteLine("Type in name for your new character.");
            Console.WriteLine("Please, be aware, all characters must have unic names.");
            Console.WriteLine();

            string charName = Console.ReadLine()?.Trim();
            Console.WriteLine();

            List<string> charNames = _characterService.GetAllCharacterNames();

            if (String.IsNullOrEmpty(charName))
            {
                return Result<string>.Failure("Error, name cannot be empty.");
            }
            if (charNames.Contains(charName))
            {
                return Result<string>.Failure("Error, character with that name already exists.");
            }
            else
            {
                return Result<string>.Success(charName);
            }
        }

        private Result<string> AskGender()
        {
            Console.WriteLine("Type in gender of your new character:");
            Console.WriteLine();

            string charGender = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (String.IsNullOrEmpty(charGender))
            {
                return Result<string>.Failure("Error, gender cannot be empty.");
            }

            else
            {
                return Result<string>.Success(charGender);
            }
        }

        private Result<int> AskAge()
        {
            Console.WriteLine("Type in age of your new character, use only numbers.");
            Console.WriteLine("Before you do, you should be aware that different races in Dungeons and Dragons mature and age at different rates.");
            Console.WriteLine("For example human of age 50 is already quite old, but dwarf of the same age is still considered young.");
            Console.WriteLine();

            string charAge = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (String.IsNullOrEmpty(charAge))
            {
                return Result<int>.Failure("Error, age cannot be empty.");
            }

            else
            {
                if (int.TryParse(charAge, out int age))
                {
                    return Result<int>.Success(age);
                }

                else
                {
                    return Result<int>.Failure("Error, you have to use only numbers to set age of your character.");
                }
            }
        }

        private Result<(int, int)> AskHeightAndWeight()
        {
            int height;
            int weight;

            Console.WriteLine("Type in height of your new character, use only numbers. ");
            Console.WriteLine("As this value is stored purely for roleplay you can use both metric and imperial measuring systems.");
            Console.WriteLine("However, considering that you should use integers only, I would suggest that you type in your height value either in centimeters or inches.");
            Console.WriteLine();

            string charHeight = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (String.IsNullOrEmpty(charHeight)) 
            {
                return Result<(int, int)>.Failure("Error, you have to type in any number.");
            }

            else
            {
                if (int.TryParse(charHeight, out int heightInput))
                {
                    height = heightInput;
                }

                else
                {
                    return Result<(int, int)>.Failure("Error, you have to use only numbers to set height of your character.");
                }
            }

            Console.WriteLine("Type in weight of your new character, use only numbers. ");
            Console.WriteLine("This value is also purely for roleplay, for metric system use kilograms, for imperial use pounds.");
            Console.WriteLine();

            string charWeight = Console.ReadLine()?.Trim();

            if (String.IsNullOrEmpty(charWeight))
            {
                return Result<(int, int)>.Failure("Error, you have to type in any number.");
            }

            else
            {
                if (int.TryParse(charWeight, out int weightInput))
                {
                    weight = weightInput;
                }

                else
                {
                    return Result<(int, int)>.Failure("Error, you have to use only numbers to set weight of your character.");
                }
            }

            return Result<(int, int)>.Success((height, weight));
        }

        private Result<Alignment> SelectAlignment()
        {
            Console.WriteLine("Select alignment of your character from the following list:");
            Console.WriteLine("(Alignment is categorization of ethical and moral perspective of your character)");
            Console.WriteLine("1. Lawful Good");
            Console.WriteLine("2. Neutral Good");
            Console.WriteLine("3. Chaotic Good");
            Console.WriteLine("4. Lawful Neutral");
            Console.WriteLine("5. True Neutral");
            Console.WriteLine("6. Chaotic Neutral");
            Console.WriteLine("7. Lawful Evil");
            Console.WriteLine("8. Neutral Evil");
            Console.WriteLine("9. Chaotic Evil");
            Console.WriteLine();

            string answer = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (int.TryParse(answer, out int alignmentCode) && alignmentCode > 0 && alignmentCode < 10)
            {
                return Result<Alignment>.Success((Alignment)alignmentCode);
            }

            else
            {
                return Result<Alignment>.Failure("Error, invalid alignment selection input.");
            }
        }

        private Result<bool> FinishClass(CharacterClass characterClass)
        {
            switch (characterClass.ClassName) 
            {
                case "Fighter":
                    return FinishFighter(characterClass as Fighter);

                case "Barbarian":
                    return Result<bool>.Success(true);

                case "Bard":
                    return Result<bool>.Success(true);

                case "Cleric":
                    return Result<bool>.Success(true);

                case "Rogue":
                    return Result<bool>.Success(true);

                default:
                    return Result<bool>.Failure("Error! Invalid name of character class, try re-making a character or manualy changing ClassName property of your character class.");
            }
        }

        private Result<bool> FinishFighter(Fighter characterClass) 
        {
            Console.WriteLine($"Your character is now a fighter, to proceed, please select one of the following fighting styles:");
            Console.WriteLine("1. Archery");
            Console.WriteLine("You gain a +2 bonus to attack rolls you make with ranged weapons.");
            Console.WriteLine();

            Console.WriteLine("2. Defense");
            Console.WriteLine("While you are wearing armor, you gain a +1 bonus to AC.");
            Console.WriteLine();

            Console.WriteLine("3. Dueling");
            Console.WriteLine("When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon.");
            Console.WriteLine();

            Console.WriteLine("4. Great Weapon Fighting");
            Console.WriteLine("When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the two-handed or versatile property for you to gain this benefit.");
            Console.WriteLine();

            Console.WriteLine("5. Protection");
            Console.WriteLine("When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.");
            Console.WriteLine();

            Console.WriteLine("6. Two-Weapon Fighting");
            Console.WriteLine("When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.");
            Console.WriteLine();

            string selectedFightingStyle = Console.ReadLine()?.Trim();
            Console.WriteLine();

            Result<bool> result = _characterClassService.FinishFighter(characterClass, selectedFightingStyle);

            if (result.IsSuccess)
            {
                Console.WriteLine($"Selected fighting style: {characterClass.FightingStyle}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            return result;
        }

        private Result<Race> SelectRace()
        {
            Console.WriteLine("Select Race for your character by typing in its number from this list:");
            Console.WriteLine("1. Dwarf");
            Console.WriteLine("2. Elf");
            Console.WriteLine("3. Halfling");
            Console.WriteLine("4. Human");
            Console.WriteLine("5. Dragonborn");
            Console.WriteLine("6. Gnome");
            Console.WriteLine("7. Half-Elf");
            Console.WriteLine("8. Half-Orc");
            Console.WriteLine("9. Tiefling");
            Console.WriteLine();

            Result<Race> raceSearchResult;

            string answer = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (answer)
            {
                case "1":
                    raceSearchResult = _raceService.GetRace("Dwarf");
                    break;

                case "2":
                    raceSearchResult = _raceService.GetRace("Elf");
                    break;

                case "3":
                    raceSearchResult = _raceService.GetRace("Halfling");
                    break;

                case "4":
                    raceSearchResult = _raceService.GetRace("Human");
                    break;

                case "5":
                    raceSearchResult = _raceService.GetRace("Dragonborn");
                    break;

                case "6":
                    raceSearchResult = _raceService.GetRace("Gnome");
                    break;

                case "7":
                    raceSearchResult = _raceService.GetRace("Half-Elf");
                    break;

                case "8":
                    raceSearchResult = _raceService.GetRace("Half-Orc");
                    break;

                case "9":
                    raceSearchResult = _raceService.GetRace("Tiefling");
                    break;

                default:
                    return Result<Race>.Failure("Invalid input for race select.");
            }

            return raceSearchResult;
        }

        private Result<SubRace> SelectSubRace(Race selectedRace)
        {
            if (selectedRace.SubRaces[0] == "none")
            {
                return Result<SubRace>.Success(null);
            }

            else
            {
                Console.WriteLine("Select subrace for your character by typing in its number from this list:");

                for (int i = 0; i < selectedRace.SubRaces.Count; i++) 
                {
                    Console.WriteLine($"{i + 1}. {selectedRace.SubRaces[i]}");
                }
                Console.WriteLine();

                string answer = Console.ReadLine()?.Trim();
                Console.WriteLine();

                if (int.TryParse(answer, out int result) && (result - 1) < selectedRace.SubRaces.Count && (result - 1) >= 0) 
                {
                    string selectedSubRace = selectedRace.SubRaces[result - 1];
                    return _subRaceService.GetSubRace(selectedSubRace);
                }

                else
                {
                    return Result<SubRace>.Failure("Invalid subrace select");
                }
            }
        }

        private Result<CharacterClass> SelectClass()
        {
            Console.WriteLine("Select Class for your character by typing in its number from this list:");
            Console.WriteLine("1. Fighter");
            Console.WriteLine("2. Barbarian");
            Console.WriteLine("3. Bard");
            Console.WriteLine("4. Cleric");
            Console.WriteLine("5. Rogue");

            string answer = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (answer)
            {
                case "1":
                    return Result<CharacterClass>.Success(_characterClassService.CreateFighter());

                case "2":
                    return Result<CharacterClass>.Success(_characterClassService.CreateBarbarian());

                case "3":
                    return Result<CharacterClass>.Success(_characterClassService.CreateBard());

                case "4":
                    return Result<CharacterClass>.Success(_characterClassService.CreateCleric());

                case "5":
                    return Result<CharacterClass>.Success(_characterClassService.CreateRogue());

                default:
                    return Result<CharacterClass>.Failure("Invalid input for class select.");
            }
        }

        private Result<CharacterSubClass> SelectSubClass(CharacterClass selectedClass)
        {
            if (selectedClass.SubClasses[0] == "none")
            {
                return Result<CharacterSubClass>.Success(null);
            }
            else
            {
                Console.WriteLine("Select a Sub Class for your character by typing in its number from this list:");

                for (int i = 0; i < selectedClass.SubClasses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedClass.SubClasses[i]}");
                }
                Console.WriteLine();

                string answer = Console.ReadLine()?.Trim();
                Console.WriteLine();

                if (int.TryParse(answer, out int result) && (result - 1) < selectedClass.SubClasses.Count && (result - 1) >= 0)
                {
                    string selectedSubClass = selectedClass.SubClasses[result - 1];
                    return _characterSubClassService.GetSubClass(selectedSubClass);
                }

                else
                {
                    return Result<CharacterSubClass>.Failure("Invalid sub class select.");
                }
            }
        }

        private Result<Background> SelectBackground()
        {
            Console.WriteLine("Select Background for your character by typing in its number from this list:");
            Console.WriteLine("1. Acolyte");
            Console.WriteLine("2. Charlatan");
            Console.WriteLine("3. Criminal");
            Console.WriteLine("4. Entertainer");
            Console.WriteLine("5. Folk Hero");
            Console.WriteLine("6. Guild Artisan");
            Console.WriteLine("7. Hermit");
            Console.WriteLine("8. Noble");
            Console.WriteLine("9. Outlander");
            Console.WriteLine("10. Sage");
            Console.WriteLine("11. Sailor");
            Console.WriteLine("12. Soldier");
            Console.WriteLine("13. Urchin");
            Console.WriteLine();

            string answer = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (answer)
            {
                case "1":
                    return _backgroundService.GetBackground("Acolyte");

                case "2":
                    return _backgroundService.GetBackground("Charlatan");

                case "3":
                    return _backgroundService.GetBackground("Criminal");

                case "4":
                    return _backgroundService.GetBackground("Entertainer");

                case "5":
                    return _backgroundService.GetBackground("Folk Hero");

                case "6":
                    return _backgroundService.GetBackground("Guild Artisan");

                case "7":
                    return _backgroundService.GetBackground("Hermit");

                case "8":
                    return _backgroundService.GetBackground("Noble");

                case "9":
                    return _backgroundService.GetBackground("Outlander");

                case "10":
                    return _backgroundService.GetBackground("Sage");

                case "11":
                    return _backgroundService.GetBackground("Sailor");

                case "12":
                    return _backgroundService.GetBackground("Soldier");

                case "13":
                    return _backgroundService.GetBackground("Urchin");

                default:
                    return Result<Background>.Failure("Invalid input for Background select.");
            }
        }

        private Result<AbilityScore> AbilityScorePointBuyStart()
        {
            Console.WriteLine($"Starting point buy for ability scores of your character.");
            Console.WriteLine("Before entering any values, be aware that you must use only numbers.");
            Console.WriteLine("Minimum score for ability is 8, if you enter less ability will be set to minimum, so to 8.");
            Console.WriteLine("Maximum score that you can set is 15, if you enter more ability will be set to maximum, so to 15. (if you have enough points left)");
            Console.WriteLine("You get 27 point to spend, score and points don't have an equal value here is a price list:");
            Console.WriteLine();
            Console.WriteLine("8 score = 0 points");
            Console.WriteLine("9 score = 1 point");
            Console.WriteLine("10 score = 2 points");
            Console.WriteLine("11 score = 3 points");
            Console.WriteLine("12 score = 4 points");
            Console.WriteLine("13 score = 5 points");
            Console.WriteLine("14 score = 7 points");
            Console.WriteLine("15 score = 9 points");
            Console.WriteLine();

            var strScoreinput = GetAbilityScorePointBuyInput("Strength");
            var dexScoreinput = GetAbilityScorePointBuyInput("Dexterity");
            var conScoreinput = GetAbilityScorePointBuyInput("Constitution");
            var intScoreinput = GetAbilityScorePointBuyInput("Intelligence");
            var wisScoreinput = GetAbilityScorePointBuyInput("Wisdom");
            var chaScoreinput = GetAbilityScorePointBuyInput("Charisma");

            return _abilityScoreService.AbilityScorePointBuy(strScoreinput, dexScoreinput, conScoreinput, intScoreinput, wisScoreinput, chaScoreinput);
        }

        private Result<int> GetAbilityScorePointBuyInput(string ability)
        {
            Console.WriteLine($"Type in a value you for your {ability}.");
            Console.WriteLine();

            string answer = Console.ReadLine()?.Trim();
            Console.WriteLine();

            if (String.IsNullOrEmpty(answer))
            {
                return Result<int>.Failure("Error, ability score cannot be empty.");
            }

            else
            {
                if (int.TryParse(answer, out int score))
                {
                    return Result<int>.Success(score);
                }

                else
                {
                    return Result<int>.Failure($"Error, you have to use only numbers to set score of your {ability}.");
                }
            }
        }

        private Result<bool> FinishCharacter(Character character)
        {
            var inventoryFinishResult = FinishInventory(character);
            while (!inventoryFinishResult.IsSuccess)
            {
                inventoryFinishResult = FinishInventory(character);
            }

            _characterService.CountProficiencyBonus(character);

            _characterService.FinishAbilityScore(character);

            FinishSkillProfs(character);

            _characterService.FinishSavingThrows(character);

            _characterService.CountHP(character);

            _characterService.FinishCharacterFeatures(character);

            var updateResult =  _characterService.UpdateCharacterByName(character);
            {
                updateResult = _characterService.UpdateCharacterByName(character);
            }
            return updateResult;
        }

        private Result<bool> FinishInventory(Character character)
        {
            List<Item> backItems = _characterService.GetBackItems(character.CharacterBackground);

            Result<List<Item>> classItemsResult = GetClassItems(character.CharacterClass);

            if (classItemsResult.IsSuccess)
            {
                foreach (Item item in classItemsResult.Data)
                {
                    backItems.Add(item);
                }

                character.CharacterInventory = backItems;
                return Result<bool>.Success(true);
            }
            else
            {
                return Result<bool>.Failure(classItemsResult.ErrorMessage);
            }
        }

        private Result<List<Item>> GetClassItems(CharacterClass characterClass )
        {
            List<Item> itemList = new List<Item>();

            foreach (ItemPair itemPair in characterClass.ClassInventory)
            {
                Console.WriteLine("Choose one option (type in 'A' or 'B' to choose):");
                Console.WriteLine("Option A:");
                foreach (Item item in itemPair.A)
                {
                    Console.WriteLine($"{item.Name} | Price: {item.Price} | Weight {item.Weight} | Quantity {item.Quantity}");
                }
                Console.WriteLine();

                Console.WriteLine("Option: B");
                foreach (Item item in itemPair.B)
                {
                    Console.WriteLine($"{item.Name} | Price: {item.Price} | Weight {item.Weight} | Quantity {item.Quantity}");
                }
                Console.WriteLine();

                string answer = Console.ReadLine()?.Trim();
                Console.WriteLine();

                var chosenItemsResult = _characterService.GetChosenClassItems(answer, itemPair);
                if (chosenItemsResult.IsSuccess)
                {
                    foreach (Item item in chosenItemsResult.Data)
                    {
                        itemList.Add(item);
                    }
                }
                else
                {
                    return Result<List<Item>>.Failure(chosenItemsResult.ErrorMessage);
                }
            }

            return Result<List<Item>>.Success(itemList);
        }

        private void FinishSkillProfs(Character character)
        {
            _characterService.AsignBackSkills(character);
            AsignClassSkills(character);
            _characterService.CountSkillMods(character);
        }

        private void AsignClassSkills(Character character)
        {
            Skills charClassSkill = character.CharacterClass.ClassSkills;
            int profs = character.CharacterClass.AmountOfSkillProfs;
            PropertyInfo[] props = charClassSkill.GetType().GetProperties();

            while (profs > 0) 
            {
                Console.WriteLine($"You can pick {profs} proficiencies, choose one of the skills to gain proficiency in (type in name of skill):");

                foreach (var prop in props)
                {
                    StatProfPair statProfPair = (StatProfPair)prop.GetValue(charClassSkill);
                    PropertyInfo profProp = statProfPair.GetType().GetProperty("Profficiency");
                    bool profficiency = (bool)profProp.GetValue(statProfPair);

                    if (profficiency == true)
                    {
                        if (prop.Name == "SleightOfHand")
                        {
                            Console.WriteLine("Sleight of Hand");
                        }
                        if (prop.Name == "AnimalHandling")
                        {
                            Console.WriteLine("Animal Handling");
                        }
                        if (prop.Name != "SleightOfHand" && prop.Name != "AnimalHandling")
                        {
                            Console.WriteLine($"{prop.Name}");
                        }
                    }
                }
                Console.WriteLine();

                string pickedSkill = Console.ReadLine()?.Trim();
                Console.WriteLine();

                var asigningProfResult = _characterService.AsignSkillProf(pickedSkill, character);
                if (asigningProfResult.IsSuccess)
                {
                    Console.WriteLine("Proficiency asigned.");
                    Console.WriteLine();
                    profs--;
                }
                else
                {
                    Console.WriteLine(asigningProfResult.ErrorMessage);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Proficiencies asigned.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();
        }

        private void CheckAbilityScore(Character character)
        {
            AbilityScore abilityScore = character.CharacterAbilityScore;
            AbilityScore abilityScoreMods = character.CharacterAbilityScoreMods;

            Console.WriteLine("These are your ability scores:");
            Console.WriteLine($"Strength:     {abilityScore.Strength}  {abilityScoreMods.Strength}");
            Console.WriteLine($"Dexterity:    {abilityScore.Dexterity}  {abilityScoreMods.Dexterity}");
            Console.WriteLine($"Constitution: {abilityScore.Constitution}  {abilityScoreMods.Constitution}");
            Console.WriteLine($"Intelligence: {abilityScore.Intelligence}  {abilityScoreMods.Intelligence}");
            Console.WriteLine($"Wisdom:       {abilityScore.Wisdom}  {abilityScoreMods.Wisdom}");
            Console.WriteLine($"Charisma:     {abilityScore.Charisma}  {abilityScoreMods.Charisma}");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();
        }

        private void CheckSkills(Character character)
        {
            Skills skills = character.CharacterSkills;
            PropertyInfo[] props = skills.GetType().GetProperties();

            Console.WriteLine("These are your skills:");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();

            foreach ( PropertyInfo prop in props ) 
            {
                StatProfPair statProfPair = (StatProfPair)prop.GetValue(skills);
                if (prop.Name == "SleightOfHand")
                {
                    Console.WriteLine("     Sleight of Hand");
                }
                if (prop.Name == "AnimalHandling")
                {
                    Console.WriteLine("     Animal Handling");
                }
                if (prop.Name != "SleightOfHand" && prop.Name != "AnimalHandling")
                {
                    Console.WriteLine($"     {prop.Name}");
                }
                Console.WriteLine($"Skill modifier: {statProfPair.StatValue}");
                Console.WriteLine($"Skill root ability: {statProfPair.RootAbility}");
                Console.WriteLine($"Skill proficiency: {statProfPair.Profficiency}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }
        }

        private void CheckSavingThrows(Character character)
        {
            SavingThrows savingThrows = character.CharacterSavingThrows;
            PropertyInfo[] props = savingThrows.GetType().GetProperties();

            Console.WriteLine("These are your saving throws:");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();

            foreach (PropertyInfo prop in props)
            {
                StatProfPair statProfPair = (StatProfPair)prop.GetValue(savingThrows);

                Console.WriteLine($"     {prop.Name}");
                Console.WriteLine($"Skill modifier: {statProfPair.StatValue}");
                Console.WriteLine($"Skill root ability: {statProfPair.RootAbility}");
                Console.WriteLine($"Skill proficiency: {statProfPair.Profficiency}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }
        }

        private void CheckInventory(Character character)
        {
            List<Item> items = character.CharacterInventory;

            Console.WriteLine("These are your items:");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();

            foreach (Item item in items) 
            {
                Console.WriteLine($"     {item.Name}");
                Console.WriteLine($"Item description: {item.Description}");
                Console.WriteLine($"Item price: {item.Price}");
                Console.WriteLine($"Item weight: {item.Weight}");
                Console.WriteLine($"Item quantity: {item.Quantity}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }
        }

        private void CheckBasicInfo(Character character)
        {
            string subRaceName = "None";
            string subClassName = "None";
            string subRaceDesc = "None";
            string subClassDesc = "None";

            if (character.CharacterSubRace != null)
            {
                subRaceName = character.CharacterSubRace.SubRaceName;
                subRaceDesc = character.CharacterSubRace.SubRaceDescription;
            }

            if (character.CharacterSubClass != null)
            {
                subClassName = character.CharacterSubClass.SubClassName;
                subClassDesc = character.CharacterSubClass.SubClassDescription;
            }


            Console.WriteLine($"Basic information about {character.CharName}:");
            Console.WriteLine();

            Console.WriteLine($"Name: {character.CharName}");
            Console.WriteLine($"Age: {character.Age}");
            Console.WriteLine($"Gender: {character.Gender}");
            Console.WriteLine($"Height: {character.Height}");
            Console.WriteLine($"Weight: {character.Weight}");
            Console.WriteLine($"Size: {character.Race.RaceSize}");
            Console.WriteLine($"Background: {character.CharacterBackground.BackName}");
            Console.WriteLine($"Background description: {character.CharacterBackground.BackDescription}");
            Console.WriteLine();

            Console.WriteLine($"Race: {character.Race.RaceName}");
            Console.WriteLine($"Race description: {character.Race.RaceDescription}");
            Console.WriteLine();

            Console.WriteLine($"Sub-Race: {subRaceName}");
            Console.WriteLine($"Sub-Race description: {subRaceDesc}");
            Console.WriteLine();

            Console.WriteLine($"Class: {character.CharacterClass.ClassName}");
            Console.WriteLine($"Class description: {character.CharacterClass.ClassDescription}");
            Console.WriteLine();

            Console.WriteLine($"Sub-Class: {subClassName}");
            Console.WriteLine($"Sub-Class description: {subClassDesc}");
            Console.WriteLine();

            Console.WriteLine($"Max HP: {character.HitPoints}");
            Console.WriteLine($"Movement Speed: {character.Race.RaceSpeed}");
            Console.WriteLine($"Alignemnt: {character.Alignment}");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();
        }

        private void CheckClassSpecial(Character character)
        {
            CharacterClass characterClass = character.CharacterClass;

            switch (characterClass.ClassName)
            {
                case "Fighter":
                    CheckFighter(characterClass as Fighter);
                    break;

                default:
                    break;
            }
        }

        private void CheckFighter(Fighter fighter) 
        {
            Console.WriteLine("Your character is a fighter, his special feature is fighting style.");
            Console.WriteLine("This is their fighting style:");
            Console.WriteLine($"{fighter.FightingStyle}: {fighter.FightingStyleDesc}");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();
        }

        private Result<bool> EditRace(Character character)
        {
            var raceSelection = SelectRace();
            while (!raceSelection.IsSuccess)
            {
                Console.WriteLine(raceSelection.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                raceSelection = SelectRace();
            }

            character.Race = raceSelection.Data;
            Console.WriteLine($"Race is set to {character.Race.RaceName}.");
            Console.WriteLine(_smallBorder);
            Console.WriteLine();

            if (character.Race.SubRaces.Count > 0)
            {
                var subRaceSelection = SelectSubRace(character.Race);
                while (!subRaceSelection.IsSuccess)
                {
                    Console.WriteLine(subRaceSelection.ErrorMessage);
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();

                    subRaceSelection = SelectSubRace(character.Race);
                }

                character.CharacterSubRace = subRaceSelection.Data;
                if (character.CharacterSubRace != null)
                {
                    Console.WriteLine($"Sub-Race is set to {character.CharacterSubRace.SubRaceName}.");
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();
                }
            }

            var pointBuyResult = AbilityScorePointBuyStart();
            while (!pointBuyResult.IsSuccess)
            {
                Console.WriteLine(pointBuyResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                pointBuyResult = AbilityScorePointBuyStart();
            }

            AbilityScore abilityScore = pointBuyResult.Data!;
            character.CharacterAbilityScore = abilityScore;
            if (abilityScore != null)
            {
                Console.WriteLine("These are ability scores of your character:");
                Console.WriteLine($"Strength: {abilityScore.Strength}");
                Console.WriteLine($"Dexterity: {abilityScore.Dexterity}");
                Console.WriteLine($"Constitution: {abilityScore.Constitution}");
                Console.WriteLine($"Intelligence: {abilityScore.Intelligence}");
                Console.WriteLine($"Wisdom: {abilityScore.Wisdom}");
                Console.WriteLine($"Charisma: {abilityScore.Charisma}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var finishingResult = FinishCharacter(character);
            while (!finishingResult.IsSuccess)
            {
                Console.WriteLine(finishingResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingResult = FinishCharacter(character);
            }

            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }

        private Result<bool> EditSubRace(Character character)
        {
            if (character.Race.SubRaces.Count < 1)
            {
                Console.WriteLine("Race of this character doesn't have any sub races to choose from!");
                Console.WriteLine(_fatBorder);
                Console.WriteLine();

                return Result<bool>.Success(true);
            }
            else
            {
                var subRaceSelection = SelectSubRace(character.Race);
                while (!subRaceSelection.IsSuccess)
                {
                    Console.WriteLine(subRaceSelection.ErrorMessage);
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();

                    subRaceSelection = SelectSubRace(character.Race);
                }

                character.CharacterSubRace = subRaceSelection.Data;
                if (character.CharacterSubRace != null)
                {
                    Console.WriteLine($"Sub-Race is set to {character.CharacterSubRace.SubRaceName}.");
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();
                }

                var pointBuyResult = AbilityScorePointBuyStart();
                while (!pointBuyResult.IsSuccess)
                {
                    Console.WriteLine(pointBuyResult.ErrorMessage);
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();

                    pointBuyResult = AbilityScorePointBuyStart();
                }

                AbilityScore abilityScore = pointBuyResult.Data!;
                character.CharacterAbilityScore = abilityScore;
                if (abilityScore != null)
                {
                    Console.WriteLine("These are ability scores of your character:");
                    Console.WriteLine($"Strength: {abilityScore.Strength}");
                    Console.WriteLine($"Dexterity: {abilityScore.Dexterity}");
                    Console.WriteLine($"Constitution: {abilityScore.Constitution}");
                    Console.WriteLine($"Intelligence: {abilityScore.Intelligence}");
                    Console.WriteLine($"Wisdom: {abilityScore.Wisdom}");
                    Console.WriteLine($"Charisma: {abilityScore.Charisma}");
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();
                }

                var finishingResult = FinishCharacter(character);
                while (!finishingResult.IsSuccess)
                {
                    Console.WriteLine(finishingResult.ErrorMessage);
                    Console.WriteLine(_smallBorder);
                    Console.WriteLine();

                    finishingResult = FinishCharacter(character);
                }

                Console.WriteLine("Character editing finished successfully");
                Console.WriteLine(_fatBorder);
                Console.WriteLine();
                return Result<bool>.Success(true);
            }
            
        }

        private Result<bool> EditClass(Character character)
        {
            var clasSelect = SelectClass();
            while (!clasSelect.IsSuccess)
            {
                Console.WriteLine(clasSelect.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                clasSelect = SelectClass();
            }

            character.CharacterClass = clasSelect.Data;
            if (character.CharacterSubRace != null)
            {
                Console.WriteLine($"Class is set to {character.CharacterClass.ClassName}.");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var classFinishResult = FinishClass(character.CharacterClass);
            while (!classFinishResult.IsSuccess)
            {
                Console.WriteLine(classFinishResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var subClassSelect = SelectSubClass(character.CharacterClass);
            while (!subClassSelect.IsSuccess)
            {
                Console.WriteLine(subClassSelect.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                subClassSelect = SelectSubClass(character.CharacterClass);
            }

            character.CharacterSubClass = subClassSelect.Data;
            if (character.CharacterSubClass != null)
            {
                Console.WriteLine($"Sub-Class is set to {character.CharacterSubClass.SubClassName}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var finishingResult = FinishCharacter(character);
            while (!finishingResult.IsSuccess)
            {
                Console.WriteLine(finishingResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingResult = FinishCharacter(character);
            }

            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }

        private Result<bool> EditSubClass(Character character)
        {
            var subClassSelect = SelectSubClass(character.CharacterClass);
            while (!subClassSelect.IsSuccess)
            {
                Console.WriteLine(subClassSelect.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                subClassSelect = SelectSubClass(character.CharacterClass);
            }

            character.CharacterSubClass = subClassSelect.Data;
            if (character.CharacterSubClass != null)
            {
                Console.WriteLine($"Sub-Class is set to {character.CharacterSubClass.SubClassName}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var finishingResult = FinishCharacter(character);
            while (!finishingResult.IsSuccess)
            {
                Console.WriteLine(finishingResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingResult = FinishCharacter(character);
            }

            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }

        private Result<bool> EditBackground(Character character)
        {
            var backgroundSelect = SelectBackground();
            while (!backgroundSelect.IsSuccess)
            {
                Console.WriteLine(backgroundSelect.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                backgroundSelect = SelectBackground();
            }

            character.CharacterBackground = backgroundSelect.Data;
            if (character.CharacterBackground != null)
            {
                Console.WriteLine($"Background is set to {character.CharacterBackground.BackName}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var finishingResult = FinishCharacter(character);
            while (!finishingResult.IsSuccess)
            {
                Console.WriteLine(finishingResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingResult = FinishCharacter(character);
            }

            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }

        private Result<bool> EditBackstory(Character character)
        {
            Console.WriteLine("Backstory is a story of your character, you can write whatever you want, can be a biography or just random facts of this character's life.");
            Console.WriteLine();

            string input = Console.ReadLine()?.Trim();
            Console.WriteLine();

            character.Backstory = input;

            _characterService.UpdateCharacterByName(character);
            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }

        private Result<bool> RestartPointBuy(Character character)
        {
            var pointBuyResult = AbilityScorePointBuyStart();
            while (!pointBuyResult.IsSuccess)
            {
                Console.WriteLine(pointBuyResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                pointBuyResult = AbilityScorePointBuyStart();
            }

            AbilityScore abilityScore = pointBuyResult.Data!;
            character.CharacterAbilityScore = abilityScore;
            if (abilityScore != null)
            {
                Console.WriteLine("These are ability scores of your character:");
                Console.WriteLine($"Strength: {abilityScore.Strength}");
                Console.WriteLine($"Dexterity: {abilityScore.Dexterity}");
                Console.WriteLine($"Constitution: {abilityScore.Constitution}");
                Console.WriteLine($"Intelligence: {abilityScore.Intelligence}");
                Console.WriteLine($"Wisdom: {abilityScore.Wisdom}");
                Console.WriteLine($"Charisma: {abilityScore.Charisma}");
                Console.WriteLine(_smallBorder);
                Console.WriteLine();
            }

            var finishingResult = FinishCharacter(character);
            while (!finishingResult.IsSuccess)
            {
                Console.WriteLine(finishingResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingResult = FinishCharacter(character);
            }

            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }

        private Result<bool> RestartCharacterFinish(Character character)
        {
            var finishingResult = FinishCharacter(character);
            while (!finishingResult.IsSuccess)
            {
                Console.WriteLine(finishingResult.ErrorMessage);
                Console.WriteLine(_smallBorder);
                Console.WriteLine();

                finishingResult = FinishCharacter(character);
            }

            Console.WriteLine("Character editing finished successfully");
            Console.WriteLine(_fatBorder);
            Console.WriteLine();
            return Result<bool>.Success(true);
        }
    }
}
