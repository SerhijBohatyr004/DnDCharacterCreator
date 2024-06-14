using BLL.Interfaces;
using Core.Enums;
using Core.Models;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IGenericRepository<Race> _repository;

        public RaceService(IGenericRepository<Race> repository) 
        {
            _repository = repository;
        }

        public Result<Race> GetRace(string raceName)
        {
             return _repository.GetSingleByCondition(race => race.RaceName == raceName);
        }

        public void CreateAllRaces()
        {
            CreateDwarf();
            CreateElf();
            CreateHalfling();
            CreateHuman();
            CreateDragonborn();
            CreateGnome();
            CreateHalfElf();
            CreateHalfOrc();
            CreateTiefling();
        }

        private void CreateDwarf()
        {
            string raceName = "Dwarf";
            string descrtiption = "Bold and hardy, dwarves are known as skilled warriors," +
                " miners and workers of stone and metal.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 25;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Constitution = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", "Your constitution increases by 2");

            features.Add("Age", "Dwarves mature at the same rate as humans, " +
                "but they're considered young until they reach the age of 50. " +
                "On average, they live about 350 years.");

            features.Add("Size", "Dwarves stand between 4 and 5 feet tall " +
                "and average about 150 pounds. Your size is Medium.");

            features.Add("Speed", "Your base walking speed is 25 feet. " +
                "Your speed is not reduced by wearing heavy armor.");

            features.Add("Darkvision", "You have superior vision in the dark and dim conditions. " +
                "You can see in dim light within 60 feet of you as if it were bright light, " +
                "and in darkness as if it were dim light. " +
                "You can't discern colors in darkness, only shades of gray.");

            features.Add("Dwarven resilience",
                "You have advantage on saving throws against poison, " +
                "and you have resistance against poison damage.");

            features.Add("Dwarven combat training",
                "You have proficiency with the battleaxe, " +
                "handaxe, throwing hammer and warhammer.");

            features.Add("Tool proficiency",
                "You gain proficiency with the artisan's tools of your choice: " +
                "smith's tools, brewer's supplies, or mason's tools.");

            features.Add("Stonecunning",
                "Whenever you make an Intelligence (History) " +
                "check related to origin of stonework, you are considered proficient " +
                "in the History skill and add double your proficiency bonus to check, " +
                "instead of your normal proficiency bonus.");

            features.Add("Languages", "YOu can speak, read and write Common and Dwarvish.");

            List<string> subRaces = new List<string>();
            subRaces.Add("Mountain Dwarf");
            subRaces.Add("Hill Dwarf");

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateElf()
        {
            string raceName = "Elf";
            string descrtiption = "Elves are a magical people of otherworldly grace, " +
                "living in the world but not entirely part of it. " +
                "They live in places of ethereal beauty, " +
                "in the midst of ancient forests or in silvery spires glittering with faerie light, " +
                "where soft music drifts through the air and gentle fragrances waft on the breeze. " +
                "Elves love nature and magic, art and artistry, music and poetry, " +
                "and the good things of the world.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 30;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Dexterity = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability Score Increase", "Your dexterity score increases by 2");

            features.Add("Age", "Although elves reach physical maturity at about the same age as humans, " +
                "the elven understanding of adulthood goes beyond physical growth to encompass worldly experience. " +
                "An elf typically claims adulthood and an adult name around the age of 100 and can live to be 750 years old.");

            features.Add("Size", "Elves range from under 5 to over 6 feet tall and have slender builds, Your size is Medium.");

            features.Add("Speed", "Your base walking speed is 30 feet");

            features.Add("Darkvision", "Accustomed to twilit forests and the night sky, " +
                "you have superior vision in dark and dim conditions. " +
                "You can see in dim light within 60 feet of you as if it were bright light, " +
                "and in darkness as if it were dim light. " +
                "You can’t discern color in darkness, only shades of gray.");

            features.Add("Keen Senses", "You have proficiency in the Preception skill");

            features.Add("Fey Ancesty", "You have advantage on saving throws against being charmed, " +
                "and magic can't put you to sleep");

            features.Add("Trance", "Elves don’t need to sleep. Instead, they meditate deeply, " +
                "remaining semiconscious, for 4 hours a day. (The Common word for such meditation is “trance.”) " +
                "While meditating, you can dream after a fashion; such dreams are actually mental exercises " +
                "that have become reflexive through years of practice. After resting in this way, " +
                "you gain the same benefit that a human does from 8 hours of sleep.");

            features.Add("Languages", "You can speak, read and write Common and Elvish languages.");

            List<string> subRaces = new List<string>();
            subRaces.Add("High Elf");
            subRaces.Add("Wood Elf");
            subRaces.Add("Dark Elf");

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateHalfling()
        {
            string raceName = "Halfling";
            string descrtiption = "The comforts of home are the goals of most halflings’ lives: " +
                "a place to settle in peace and quiet, far from marauding monsters and clashing armies; " +
                "a blazing fire and a generous meal; fine drink and fine conversation. " +
                "Though some halflings live out their days in remote agricultural communities, " +
                "others form nomadic bands that travel constantly, lured by the open road and the wide horizon " +
                "to discover the wonders of new lands and peoples. " +
                "But even these wanderers love peace, food, hearth, and home, " +
                "though home might be a wagon jostling along a dirt road or a raft floating downriver.";

            CreatureSize size = CreatureSize.Small;
            int speed = 25;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Dexterity = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", "Your dexterity increases by 2");

            features.Add("Age", "A halfling reaches adultgood at the age of 20 " +
                "and generally lives into the middle of his or her second century");

            features.Add("Size", "Halflings average about 3 feet " +
                "tall and weigh about 40 pounds. Your size is small");

            features.Add("Speed", "Your base walking speed is 25 feet");

            features.Add("Lucky", "When you roll a 1 on the d20 for an attack roll, " +
                "ability check, or saving throw, " +
                "you can reroll the die and must use the new roll.");

            features.Add("Brave", "You have advantage on saving throws against being frightened");

            features.Add("Halfling Numbleness", "You can move through the space " +
                "of any creature that is of a size larger than yours");

            features.Add("Languages", "You can speak, read and write Common and Halfling languages.");

            List<string> subRaces = new List<string>();
            subRaces.Add("Lightfoot");
            subRaces.Add("Stout");

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateHuman()
        {
            string raceName = "Human";
            string descrtiption = "In the reckonings of most worlds, " +
                "humans are the youngest of the common races, " +
                "late to arrive on the world scene and short-lived in comparison " +
                "to dwarves, elves, and dragons. Perhaps it is because of their " +
                "shorter lives that they strive to achieve as much as they can " +
                "in the years they are given. Or maybe they feel they have " +
                "something to prove to the elder races, and that’s why they " +
                "build their mighty empires on the foundation of conquest " +
                "and trade. Whatever drives them, humans are the innovators, " +
                "the achievers, and the pioneers of the worlds.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 30;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Strength = 1;
            abilityScore.Constitution = 1;
            abilityScore.Dexterity = 1;
            abilityScore.Intelligence = 1;
            abilityScore.Wisdom = 1;
            abilityScore.Charisma = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", "Your ability scores each increase by 1");

            features.Add("Age", "Humans reach adulthood in their late teens and live less than a century");

            features.Add("Size", "Humans vary widely in height and build, " +
                "from barely 5 feet to well over 6 feet tall. " +
                "Regardless of your position in that range, your size is medium.");

            features.Add("Languages", "You can speak, read and write " +
                "Common and one extra language of your choice.");

            List<string> subRaces = new List<string>();

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateDragonborn()
        {
            string raceName = "Dragonborn";
            string descrtiption = "Born of dragons, as their name proclaims, " +
                "the dragonborn walk proudly through a world that greets them " +
                "with fearful incomprehension. Shaped by draconic gods or the " +
                "dragons themselves, dragonborn originally hatched from dragon " +
                "eggs as a unique race, combining the best attributes of dragons " +
                "and humanoids. Some dragonborn are faithful servants to true " +
                "dragons, others form the ranks of soldiers in great wars, " +
                "and still others find themselves adrift, with no clear calling in life.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 30;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Strength = 2;
            abilityScore.Charisma = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", "Your Strength score increases by 2, " +
                "and your Charisma score increases by 1");

            features.Add("Age", "Young Dragonborn grow quickly. " +
                "They walk hours after hatching, " +
                "attain the size and development of a 10 year-old" +
                " human child by the age of 3, and reach adulthood by 15. " +
                "They live to be around 80");

            features.Add("Size", "Dragonborn are taller and heavier than humans, " +
                "standing well over 6 feet tall and averaging almost 250 pounds. " +
                "Your size is Medium");

            features.Add("Speed", "Your walking speed is 30 feet");

            features.Add("Draconic Ancestry", "You have draconic ancestry. " +
                "Type of your draconic ancestry gives you a breath weapon " +
                "and gives you damage resistance.");

            features.Add("Breath Weapon", "You can use your action to use your breath " +
                "weapon, type of your ancestry detemines the size, shape and damage " +
                "type of exhalation. When you use this weapon, each creature in the " +
                "are of exhalation must make a saving throw, the type of which is " +
                "determined by your draconic ancestry. The DC for this saving throw " +
                "equals 8 + your Constitution modifier + your proficiency bonus. A " +
                "creature takes 2d6 damage on a failed save, and half as much damage " +
                "on a successful one. The damage increases to 3d6 at 6th level, 4d6 " +
                "at 11th level and 5d6 at 16th level. After you use your breath weapon, " +
                "you can't use it again until you complete a short or long rest.");

            features.Add("Damage Resistance", "You have a resistance to the damage " +
                "type associated with your ancestry type");

            features.Add("Languages", "You can speak, read and write Commong and Draconic.");

            List<string> subRaces = new List<string>();

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateGnome()
        {
            string raceName = "Gnome";
            string descrtiption = "A constant hum of busy activity " +
                "pervades the warrens and neighborhoods where gnomes " +
                "form their close-knit communities. Louder sounds " +
                "punctuate the hum: a crunch of grinding gears here, " +
                "a minor explosion there, a yelp of surprise or triumph, " +
                "and especially bursts of laughter. Gnomes take delight " +
                "in life, enjoying every moment of invention, exploration, " +
                "investigation, creation, and play.";

            CreatureSize size = CreatureSize.Small;
            int speed = 25;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Intelligence = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", "Your Intelligence score increases by 2");

            features.Add("Age", "Gnomes mature at the same rate as humans do, " +
                "and most are expected to settle down into adult life by " +
                "around age 40. They can live 350 to almost 500 years");

            features.Add("Size", "Gnomes are between 3 and 4 feet tall and " +
                "average about 40 pounds. Your size is Small");

            features.Add("Speed", "Your base walking speed is 25 feet");

            features.Add("Darkvision", "Accustomed to life underground, you " +
                "have superior vision in dark and dim conditions. You can see " +
                "in the dim light within 60 feet of you as if it were bright " +
                "light, and in darkness as if it were dim light. You can't " +
                "discern color in darkness, only shades of gray");

            features.Add("Gnome Cunning", "You have advantage on all Intelligence, " +
                "Wisdom and Charisma saving throws against magic.");

            features.Add("Languages", "You can speak, read and write Common and Gnomlish.");

            List<string> subRaces = new List<string>();
            subRaces.Add("Forest Gnome");
            subRaces.Add("Rock Gnome");

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateHalfElf()
        {
            string raceName = "Half-Elf";
            string descrtiption = "Walking in two worlds but truly belonging " +
                "to neither, half-elves combine what some say are the best " +
                "qualities of their elf and human parents: human curiosity, " +
                "inventiveness, and ambition tempered by the refined senses, " +
                "love of nature, and artistic tastes of the elves. Some " +
                "half-elves live among humans, set apart by their emotional " +
                "and physical differences, watching friends and loved ones " +
                "age while time barely touches them. Others live with the " +
                "elves, growing restless as they reach adulthood in the " +
                "timeless elven realms, while their peers continue to live " +
                "as children. Many half-elves, unable to fit into either " +
                "society, choose lives of solitary wandering or join with " +
                "other misfits and outcasts in the adventuring life.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 30;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Charisma = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase",
                "Your Charisma score increases by 2, and two " +
                "other ability scores of your choice increase by 1.");

            features.Add("Age", "Half-elves mature at the same rate " +
                "humans do and reach adulthood around the age of 20. " +
                "They live much longer than humans, however, " +
                "often exceeding 180 years.");

            features.Add("Size", "Half-elves are about the same size " +
                "as humans, ranging from 5 to 6 feet tall. Your size is Medium.");

            features.Add("Darkvision", "Thanks to your elf blood, you " +
                "have superior vision in dark and dim conditions. You " +
                "can see in dim light within 60 feet of you as if it " +
                "were bright light, and in darkness as if it were dim " +
                "light. You can’t discern color in darkness, only shades of gray.");

            features.Add("Fey Ancestry", "You have advantage on saving " +
                "throws against being charmed, and magic can’t put you to sleep.");

            features.Add("Skill Versatility", "You gain proficiency in " +
                "two skills of your choice");

            features.Add("Languages", "You can speak, read and write " +
                "Common, Elvish and one extra language of your choice.");

            List<string> subRaces = new List<string>();

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateHalfOrc()
        {
            string raceName = "Half-Orc";
            string descrtiption = "Whether united under the leadership " +
                "of a mighty warlock or having fought to a standstill " +
                "after years of conflict, orc and human communities, " +
                "sometimes form alliances. When these alliances are " +
                "sealed by marriages, half-orcs are born. Some " +
                "half-orcs rise to become proud leaders of orc " +
                "communities. Some venture into the world to prove " +
                "their worth. Many of these become adventurers, " +
                "achieving greatness for their mighty deeds.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 30;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Strength = 2;
            abilityScore.Constitution = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", 
                "Your Strength score increases by 2, and your " +
                "Constitution score increases by 1.");

            features.Add("Age", "Half-orcs mature a little faster " +
                "than humans, reaching adulthood around age 14. " +
                "They age noticeably faster and rarely " +
                "live longer than 75 years.");

            features.Add("Size", "Half-orcs are somewhat larger and " +
                "bulkier than humans, and they range from 5 to well " +
                "over 6 feet tall. Your size is Medium.");

            features.Add("Speed", "Your base walking speed is 30 feet");

            features.Add("Darkvision", "Thanks to your orc blood, you " +
                "have superior vision in dark and dim conditions. You " +
                "can see in dim light within 60 feet of you as if it " +
                "were bright light, and in darkness as if it were dim " +
                "light. You can’t discern color in darkness, only shades of gray.");

            features.Add("Menacing", "You gain proficiency in the Intimidation skill");

            features.Add("Relentless Endurance", "When you are reduced " +
                "to 0 hit points but not killed outright, you can drop " +
                "to 1 hit point instead. You can’t use this feature again " +
                "until you finish a long rest.");

            features.Add("Savage Attacks", "When you score a critical hit " +
                "with a melee weapon attack, you can roll one of the " +
                "weapon’s damage dice one additional time and add it to " +
                "the extra damage of the critical hit.");

            features.Add("Languages", "You can speak, read and write Common and Orc.");

            List<string> subRaces = new List<string>();

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateTiefling()
        {
            string raceName = "Tiefling";
            string descrtiption = "To be greeted with stares and whispers, " +
                "to suffer violence and insult on the street, to see mistrust " +
                "and fear in every eye: this is the lot of the tiefling. " +
                "And to twist the knife, tieflings know that this is because " +
                "a pact struck generations ago infused the essence of " +
                "Asmodeus—overlord of the Nine Hells—into their bloodline. " +
                "Their appearance and their nature are not their fault but " +
                "the result of an ancient sin, for which they and their " +
                "children and their children’s children will always be " +
                "held accountable.";

            CreatureSize size = CreatureSize.Medium;
            int speed = 30;

            AbilityScore abilityScore = new AbilityScore();
            abilityScore.Intelligence = 1;
            abilityScore.Charisma = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Race Ability score increase", 
                "Your Intelligence score increases by 1, " +
                "and your Charisma score increases by 2.");

            features.Add("Age", "Tieflings mature at the same rate as " +
                "humans but live a few years longer.");

            features.Add("Size", "Your base walking speed is 30 feet.");

            features.Add("Speed", "Your base walking speed is 25 feet. " +
                "Your speed is not reduced by wearing heavy armor.");

            features.Add("Darkvision", "Thanks to your infernal heritage, " +
                "you have superior vision in dark and dim conditions. You " +
                "can see in dim light within 60 feet of you as if it were " +
                "bright light, and in darkness as if it were dim light. You " +
                "can’t discern color in darkness, only shades of gray.");

            features.Add("Hellish Resistance", "You have resistance to fire damage");

            features.Add("Infernal Legacy", "You know the thaumaturgy cantrip. " +
                "When you reach 3rd level, you can cast the hellish rebuke " +
                "spell as a 2nd-level spell once with this trait and regain " +
                "the ability to do so when you finish a long rest. When you " +
                "reach 5th level, you can cast the darkness spell once with " +
                "this trait and regain the ability to do so when you finish " +
                "a long rest. Charisma is your spellcasting ability for these spells.");

            features.Add("Languages", "You can speak, read, and write Common and Infernal.");

            List<string> subRaces = new List<string>();

            CreateRace(raceName, descrtiption, size, speed, abilityScore, features, subRaces);
        }

        private void CreateRace(string name, string description, CreatureSize size, int speed, AbilityScore abilityScoreBonus, Dictionary<string, string> features, List<string> subRaces)
        {
            Race race = new Race();

            race.RaceName = name;
            race.RaceDescription = description;
            race.RaceSize = size;
            race.RaceSpeed = speed;
            race.RaceAbilityScoreBonus = abilityScoreBonus;
            race.RaceFeatures = features;
            race.SubRaces = subRaces;

            _repository.Add(race);
        }
    }
}
