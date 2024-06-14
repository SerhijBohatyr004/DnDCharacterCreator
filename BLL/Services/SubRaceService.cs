using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Core.Models;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SubRaceService : ISubRaceService
    {
        private readonly IGenericRepository<SubRace> _repository;

        public SubRaceService(IGenericRepository<SubRace> repository)
        {
            _repository = repository;
        }

        public Result<SubRace> GetSubRace(string subRaceName)
        {
            return  _repository.GetSingleByCondition(subRace => subRace.SubRaceName == subRaceName);
        }

        public void CreateAllSubRaces()
        {
            CreateMountainDwarf();
            CreateHillDwarf();
            CreateHighElf();
            CreateWoodElf();
            CreateDarkElf();
            CreateLightfoot();
            CreateStout();
            CreateForestGnome();
            CreateRockGnome();
        }

        private void CreateMountainDwarf()
        {
            string name = "Mountain Dwarf";
            string description = "As a mountain dwarf, " +
                "you’re strong and hardy, accustomed to a difficult " +
                "life in rugged terrain. You’re probably on the tall " +
                "side (for a dwarf), and tend toward lighter coloration. " +
                "The shield dwarves of northern Faerûn, as well as the " +
                "ruling Hylar clan and the noble Daewar clan of " +
                "Dragonlance, are mountain dwarves.";

            AbilityScore score = new AbilityScore();
            score.Strength = 2;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability Score Increase", "Your Strength score increases by 2");

            features.Add("Dwarven Armor Training", "You have proficiency with light and medium armor");

            CreateSubRace(name, description, score, features);
        }

        private void CreateHillDwarf()
        {
            string name = "Hill Dwarf";
            string description = "As a hill dwarf, you " +
                "have keen senses, deep intuition, and " +
                "remarkable resilience. The gold dwarves " +
                "of Faerûn in their mighty southern kingdom " +
                "are hill dwarves, as are the exiled Neidar " +
                "and the debased Klar of Krynn in the Dragonlance setting.";

            AbilityScore score = new AbilityScore();
            score.Wisdom = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Ability Score Increase", "Your Wisdom score increases by 1.");

            features.Add("Dwarven Toughness", "Your hit point maximum increases by 1, " +
                "and it increases by 1 every time you gain a level");

            CreateSubRace(name, description, score, features);
        }

        private void CreateHighElf()
        {
            string name = "High Elf";
            string description = "As a high elf, you have a keen mind " +
                "and a mastery of at least the basics of magic. In " +
                "many of the worlds of D&D, there are two kinds of " +
                "high elves. One type (which includes the gray elves " +
                "and valley elves of Greyhawk, the Silvanesti of " +
                "Dragonlance, and the sun elves of the Forgotten Realms) " +
                "is haughty and reclusive, believing themselves to be " +
                "superior to non-elves and even other elves. The other " +
                "type (including the high elves of Greyhawk, the Qualinesti " +
                "of Dragonlance, and the moon elves of the Forgotten Realms) " +
                "are more common and more friendly, and often encountered " +
                "among humans and other races.";

            AbilityScore score = new AbilityScore();
            score.Intelligence = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability score increase", "Your Intelligence score increases by 1.");

            features.Add("Elf weapon training", "You have proficiency with " +
                "the longsword, shortsword, shortbow, and longbow");

            features.Add("Cantrip", "You know one cantrip of your " +
                "choice from the wizard spell list. Intelligence " +
                "is your spellcasting ability for it");

            features.Add("Extra Language", "You can speak, read, " +
                "and write one extra language of your choice.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateWoodElf()
        {
            string name = "Wood Elf";
            string description = "As a wood elf, you have keen senses " +
                "and intuition, and your fleet feet carry you quickly " +
                "and stealthily through your native forests. This " +
                "category includes the wild elves (grugach) of Greyhawk " +
                "and the Kagonesti of Dragonlance, as well as the races " +
                "called wood elves in Greyhawk and the Forgotten Realms. " +
                "In Faerûn, wood elves (also called wild elves, green " +
                "elves, or forest elves) are reclusive and distrusting " +
                "of non-elves.";

            AbilityScore score = new AbilityScore();
            score.Wisdom = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability score increase", "Yout Wisdom score increases by 1.");

            features.Add("Elf weapon training", "You have proficiency with " +
                "the longsword, shortsword, shortbow, and longbow.");

            features.Add("Fleet of foot", "Your walking speed increases to 35 feet");

            features.Add("Mask of the wild", "You can attempt to hide even " +
                "when you are only lightly obscure by foliage, heavy rain, " +
                "falling snow, mist, and other natural phenomena.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateDarkElf()
        {
            string name = "Dark Elf";
            string description = "Descended from an earlier subrace of " +
                "dark-skinned elves, the drow were banished from the " +
                "surface world for following the goddess Lolth down the " +
                "path to evil and corruption. Now they have built their " +
                "own civilization in the depths of the Underdark, patterned " +
                "after the Way of Lolth. Also called dark elves, the drow " +
                "have black skin that resembles polished obsidian and stark " +
                "white or pale yellow hair. They commonly have very pale " +
                "eyes (so pale as to be mistaken for white) in shades of " +
                "lilac, silver, pink, red, and blue. They tend to be " +
                "smaller and thinner than most elves.";

            AbilityScore score = new AbilityScore();
            score.Charisma = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability score increase", "Yout Charisma score increases by 1.");

            features.Add("Superior darkvision", "Your darkvision as a radius of 120 feet");

            features.Add("Sunlight sensitivity", "You have disadvantage " +
                "on attack rolls and on Wisdom(Perception) checks that " +
                "rely on sight when you, the target of your attack, or " +
                "whatever you are trying to perceive is in direct sunlight.");

            features.Add("Drow magic", "You know dancing lights cantrip, " +
                "When you reach 3rd level, you can cast faerie fire spell " +
                "once per day. When you reach 5th level, you can also cast " +
                "the darkness spell once per day. Charisma is your spellcasting " +
                "ability for these spells.");

            features.Add("Drow weapon training", "You have proficiency with " +
                "rapiers, shortswords, and hand crossbows.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateLightfoot()
        {
            string name = "Lightfoot";
            string description = "As a lightfoot halfling, you can easily hide " +
                "from notice, even using other people as cover. You’re inclined " +
                "to be affable and get along well with others. In the Forgotten " +
                "Realms, lightfoot halflings have spread the farthest and thus " +
                "are the most common variety.";

            AbilityScore score = new AbilityScore();
            score.Charisma = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability score increase", "Your Charisma score increases by 1.");

            features.Add("Naturally stealthy", "You can attempt to hide even when you " +
                "are obscured only by a creature that is at least one size larger than you.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateStout()
        {
            string name = "Stout";
            string description = "As a stout halfling, you’re hardier than " +
                "average and have some resistance to poison. Some say that " +
                "stouts have dwarven blood. In the Forgotten Realms, these " +
                "halflings are called stronghearts, and they’re most common " +
                "in the south.";

            AbilityScore score = new AbilityScore();
            score.Constitution = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability score increase", "Your Constitution score increases by 1.");

            features.Add("Stout Resilience", "You have advantage on saving " +
                "throws against poison and you have resistance against poison damage.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateForestGnome()
        {
            string name = "Forest Gnome";
            string description = "As a forest gnome, you have a natural knack " +
                "for illusion and inherent quickness and stealth. In the worlds " +
                "of D&D, forest gnomes are rare and secretive. They gather in " +
                "hidden communities in sylvan forests, using illusions and " +
                "trickery to conceal themselves from threats or to mask " +
                "their escape should they be detected. Forest gnomes tend " +
                "to be friendly with other good-spirited woodland folk, and " +
                "they regard elves and good fey as their most important allies. " +
                "These gnomes also befriend small forest animals and rely on " +
                "them for information about threats that might prowl their lands.";

            AbilityScore score = new AbilityScore();
            score.Dexterity = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability Score Increase", "Your Dexterity score increases by 1.");

            features.Add("Natural Illusionist", "You know the Minor Illusion cantrip. " +
                "Intelligence is your spellcasting modifier for it.");

            features.Add("Speak with Small Beasts", "Through sound and gestures, " +
                "you may communicate simple ideas with Small or smaller beasts.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateRockGnome()
        {
            string name = "Rock Gnome";
            string description = "As a rock gnome, you have a natural " +
                "inventiveness and hardiness beyond that of other gnomes. " +
                "Most gnomes in the worlds of D&D are rock gnomes, " +
                "including the tinker gnomes of the Dragonlance setting.";

            AbilityScore score = new AbilityScore();
            score.Constitution = 1;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Race Ability Score Increase", "Your Constitution score increases by 1.");

            features.Add("Artificer's Lore", "Whenever you make an Intelligence (History) " +
                "check related to magical, alchemical, or technological items, you can add " +
                "twice your proficiency bonus instead of any other proficiency bonus that " +
                "may apply.");

            features.Add("Tinker", "You have proficiency with artisan tools (tinker's tools). " +
                "Using those tools, you can spend 1 hour and 10 gp worth of materials to " +
                "construct a Tiny clockwork device (AC 5, 1 hp). The device ceases to " +
                "function after 24 hours (unless you spend 1 hour repairing it to keep " +
                "the device functioning), or when you use your action to dismantle it; at " +
                "that time, you can reclaim the materials used to create it. You can have " +
                "up to three such devices active at a time. When you create a device, " +
                "choose one of the following options: Clockwork Toy. This toy is a " +
                "clockwork animal, monster, or person, such as a frog, mouse, bird, dragon, " +
                "or soldier. When placed on the ground, the toy moves 5 feet across the " +
                "ground on each of your turns in a random direction. It makes noises as " +
                "appropriate to the creature it represents. Fire Starter. The device produces " +
                "a miniature flame, which you can use to light a candle, torch, or campfire. " +
                "Using the device requires your action. Music Box. When opened, this music box " +
                "plays a single song at a moderate volume. The box stops playing when it reaches " +
                "the song's end or when it is closed. At your DM's discretion, you may make other " +
                "objects with effects similar in power to these.");

            CreateSubRace(name, description, score, features);
        }

        private void CreateSubRace(string subRaceName, string subRaceDescription, AbilityScore SubRaceAbilityScoreBonus, Dictionary<string, string> subRaceFeatures)
        {
            SubRace subRace = new SubRace();

            subRace.SubRaceName = subRaceName;
            subRace.SubRaceDescription = subRaceDescription;
            subRace.SubRaceAbilityScoreBonus = SubRaceAbilityScoreBonus;
            subRace.SubRaceFeatures = subRaceFeatures;

            _repository.Add(subRace);
        }
    }
}
