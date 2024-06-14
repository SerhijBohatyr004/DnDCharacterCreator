using BLL.Interfaces;
using Core.Enums;
using Core.Models;
using Core.Models.CharacterClasses;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CharacterClassService : ICharacterClassService
    {
        public Fighter CreateFighter()
        {
            string name = "Fighter";
            string desc = "Fighters share an unparalleled mastery with " +
                "weapons and armor, and a thorough knowledge of the skills " +
                "of combat. They are well acquainted with death, both " +
                "meting it out and staring it defiantly in the face.";

            Dice hitDice = new Dice(1, 10);

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Hit Points", "Your hit dice are 1d10 per fighter " +
                "level, your hit points at level 1 are 10 + your " +
                "constitution modifier.");

            features.Add("Proficiencies", "You gain proficiency with all armor " +
                "and shields, simple and martial weapons and on Strength " +
                "and Constitution saving throws. For skills, you choose " +
                "two from Acrobatics, Animal Handling, Athletics, History, " +
                "Insight, Intimidation, Perception and Survival.");

            features.Add("Equipment", "You start with the following equipment in " +
                "addition to the equipment granted by your background: " +
                "(a) chain mail or (b) leather, longbow, and 20 arrows, " +
                "(a) a martial weapon and a shield or (b) two martial weapons, " +
                "(a) a light crossbow and 20 bolts or (b) two handaxes, " +
                "(a) a dungeoneer's pack or (b) an explorer's pack.");

            features.Add("Fighting Style", "You adopt a particular style of fighting " +
                "as your specialty. You can’t take a Fighting Style option more than " +
                "once, even if you later get to choose again.");

            features.Add("Second Wind", "You have a limited well of stamina that you " +
                "can draw on to protect yourself from harm. On your turn, you can use " +
                "a bonus action to regain hit points equal to 1d10 + your fighter " +
                "level. Once you use this feature, you must finish a short or long " +
                "rest before you can use it again.");

            features.Add("Action Surge", "Starting at 2nd level, you can push " +
                "yourself beyond your normal limits for a moment. On your turn, " +
                "you can take one additional action. Once you use this feature, " +
                "you must finish a short or long rest before you can use it again. " +
                "Starting at 17th level, you can use it twice before a rest, but " +
                "only once on the same turn.");

            features.Add("Martial Archetype", "At 3rd level, you choose an archetype " +
                "that you strive to emulate in your combat styles and techniques. " +
                "Choose Champion, Battle Master, or Eldritch Knight");

            features.Add("Class Ability Score Improvement", "When you reach 4th level, and " +
                "again at 6th, 8th, 12th, 14th, 16th, and 19th level, you can increase " +
                "one ability score of your choice by 2, or you can increase two ability " +
                "scores of your choice by 1. As normal, you can’t increase an ability " +
                "score above 20 using this feature. Using the optional feats " +
                "rule, you can forgo taking this feature to take a feat of your choice instead.");

            features.Add("Extra Attack", "Beginning at 5th level, you can attack " +
                "twice, instead of once, whenever you take the Attack action on your " +
                "turn. The number of attacks increases to three when you reach 11th " +
                "level in this class and to four when you reach 20th level in this class.");

            features.Add("Indomitable", "Beginning at 9th level, you can reroll a " +
                "saving throw that you fail. If you do so, you must use the new roll " +
                "no matter if its better or worse than the last one, and you can’t use " +
                "this feature again until you finish a long rest. You can use this feature " +
                "twice between long rests starting at 13th level and three times between " +
                "long rests starting at 17th level.");

            int skillProfs = 2;

            SavingThrows savingThrows = new SavingThrows();
            savingThrows.Strength.Profficiency = true;
            savingThrows.Constitution.Profficiency = true;

            Skills skills = new Skills();
            skills.Acrobatics.Profficiency = true;
            skills.AnimalHandling.Profficiency = true;
            skills.Athletics.Profficiency = true;
            skills.History.Profficiency = true;
            skills.Insight.Profficiency = true;
            skills.Intimidation.Profficiency = true;
            skills.Perception.Profficiency = true;
            skills.Survival.Profficiency = true;

            List<ItemPair> equipment = new List<ItemPair>()
            {
                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Chain Mail",
                            Description = "Made of interlocking metal rings, chain mail includes a layer of quilted fabric worn underneath the mail to prevent chafing and to cushion the impact of blows. The suit includes gauntlets.",
                            Price = 750,
                            Weight = 55,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Leather Armor",
                            Description = "The breastplate and shoulder protectors of this armor are made of leather that has been stiffened by being boiled in oil. The rest of the armor is made of softer and more flexible materials.",
                            Price = 100,
                            Weight = 10,
                            Quantity = 1
                        },
                        
                        new Item()
                        {
                            Name = "Longbow",
                            Description = "This is a Longbow, it's a long bow, shoots far but needs a lot of strength.",
                            Price = 500,
                            Weight = 2,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Arrows 10x",
                            Description = "Arrows that can be shot from a bow.",
                            Price = 10,
                            Weight = 1,
                            Quantity = 2
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Martial Weapon",
                            Description = "You get a martial weapon of your choice.",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Shield",
                            Description = "A shield is made from wood or metal and is carried in one hand. Wielding a shield increases your Armor Class by 2. You can benefit from only one shield at a time.",
                            Price = 100,
                            Weight = 6,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Martial Weapon",
                            Description = "You get a martial weapon of your choice.",
                            Price = 0,
                            Weight = 0,
                            Quantity = 2
                        },
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Light Crossbow",
                            Description = "It is a crossbow, but a light one, quite usefull as a side weapon.",
                            Price = 250,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Bolts 10x",
                            Description = "Bolts that can be shot from a crossbow.",
                            Price = 10,
                            Weight = 1,
                            Quantity = 2
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Handaxe",
                            Description = "This is a handaxe, a simple weapon, but can also serve as a usefull tool.",
                            Price = 50,
                            Weight = 2,
                            Quantity = 2
                        }
                    }
                },

                new ItemPair() 
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Backpack",
                            Description = "A backpack can hold one cubic foot or 30 pounds of gear. You can also strap items, such as a bedroll or a coil of rope, to the outside of a backpack.",
                            Price = 20,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Crowbar",
                            Description = "Using a crowbar grants advantage to Strength checks where the crowbar's leverage can be applied.",
                            Price = 20,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Hammer",
                            Description = "This one-handed hammer with an iron head is useful for pounding pitons into a wall.",
                            Price = 10,
                            Weight = 3,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Piton",
                            Description = "When a wall doesn’t offer handholds and footholds, you can make your own. A piton is a steel spike with an eye through which you can loop a rope.",
                            Price = 0.5,
                            Weight = 1,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Torch",
                            Description = "A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage.",
                            Price = 0.1,
                            Weight = 1,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Tinderbox",
                            Description = "This small container holds flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a torch -- or anything else with abundant, exposed fuel -- takes an action. Lighting any other fire takes 1 minute.",
                            Price = 5,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Ration (1 day)",
                            Description = "Rations consist of dry foods suitable for extended travel, including jerky, dried fruit, hardtack, and nuts.",
                            Price = 5,
                            Weight = 2,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Waterskin",
                            Description = "A waterskin can hold 4 pints of liquid.",
                            Price = 2,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Torch",
                            Description = "A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage.",
                            Price = 0.1,
                            Weight = 1,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Rope, Hempen (50 feet)",
                            Description = "Rope, has 2 hit points and can be burst with a DC 17 Strength check.",
                            Price = 10,
                            Weight = 10,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Backpack",
                            Description = "A backpack can hold one cubic foot or 30 pounds of gear. You can also strap items, such as a bedroll or a coil of rope, to the outside of a backpack.",
                            Price = 20,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Bedroll",
                            Description = "You never know where you’re going to sleep, and a bedroll helps you get better sleep in a hayloft or on the cold ground. A bedroll consists of bedding and a blanket thin enough to be rolled up and tied. In an emergency, it can double as a stretcher.",
                            Price = 10,
                            Weight = 7,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Mess kit",
                            Description = "This tin box contains a cup and simple cutlery. The box clamps together, and one side can be used as a cooking pan and the other as a plate or shallow bowl.",
                            Price = 2,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Tinderbox",
                            Description = "This small container holds flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a torch -- or anything else with abundant, exposed fuel -- takes an action. Lighting any other fire takes 1 minute.",
                            Price = 5,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Ration (1 day)",
                            Description = "Rations consist of dry foods suitable for extended travel, including jerky, dried fruit, hardtack, and nuts.",
                            Price = 5,
                            Weight = 2,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Waterskin",
                            Description = "A waterskin can hold 4 pints of liquid.",
                            Price = 2,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Torch",
                            Description = "A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage.",
                            Price = 0.1,
                            Weight = 1,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Rope, Hempen (50 feet)",
                            Description = "Rope, has 2 hit points and can be burst with a DC 17 Strength check.",
                            Price = 10,
                            Weight = 10,
                            Quantity = 1
                        }
                    }
                }
            };

            List<string> subClasses = new List<string>();
            subClasses.Add("Champion");
            subClasses.Add("Battle Master");
            subClasses.Add("Eldritch Knight");

            Fighter fighter = new Fighter();

            fighter.ClassName = name;
            fighter.ClassDescription = desc;
            fighter.HitDice = hitDice;
            fighter.ClassFeatures = features;
            fighter.AmountOfSkillProfs = skillProfs;
            fighter.ClassSavingThrows = savingThrows;
            fighter.ClassSkills = skills;
            fighter.ClassInventory = equipment;
            fighter.SubClasses = subClasses;

            return fighter;
        }

        public Barbarian CreateBarbarian()
        {
            string name = "Barbarian";
            string desc = "For some, their rage springs from a communion " +
                "with fierce animal spirits. Others draw from a roiling " +
                "reservoir of anger at a world full of pain. For every " +
                "barbarian, rage is a power that fuels not just a battle " +
                "frenzy but also uncanny reflexes, resilience, and feats " +
                "of strength.";

            Dice hitDice = new Dice(1, 12);

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Hit Points", "Your hit dice are 1d12 per barbarian " +
                "level, your hit points at level 1 are 12 + your " +
                "constitution modifier.");

            features.Add("Proficiencies", "You gain proficiency with: light " +
                "and medium armor, shields, simple and martial weapons, " +
                "strength and constitution saving throws. For skills you can " +
                "choose two from Animal Handling, Athletics, Intimidation, " +
                "Nature, Perception and Survival.");

            features.Add("Equipment", "You start with the following equipment in " +
                "addition to the equipment granted by your background: " +
                "(a) great axe or (b) any martial melee weapon, " +
                "(a) two handaxes (b) any simple weapon, " +
                "(a) a light crossbow and 20 bolts or (b) two handaxes, " +
                "an explorer's pack and four javelins.");

            features.Add("Rage", "In battle, you fight with primal ferocity. On " +
                "your turn, you can enter a rage as a bonus action. While raging, " +
                "you gain the following benefits if you aren't wearing heavy armor: " +
                "You have advantage on Strength checks and Strength saving throws. " +
                "When you make a melee weapon attack using Strength, you gain a " +
                "bonus to the damage roll that increases as you gain levels as " +
                "a barbarian, as shown in the Rage Damage column of the Barbarian " +
                "table. You have resistance to bludgeoning, piercing, and slashing " +
                "damage. If you are able to cast spells, you can't cast them or " +
                "concentrate on them while raging. Your rage lasts for 1 minute. " +
                "It ends early if you are knocked unconscious or if your turn " +
                "ends and you haven't attacked a hostile creature since your " +
                "last turn or taken damage since then. You can also end your " +
                "rage on your turn as a bonus action. To recharge rage you must " +
                "take a long rest before you can rage again.");

            features.Add("Unarmored Defence", "While you are not wearing any " +
                "armor, your armor class equals to 10 + your Dexterity modifier " +
                "+ your Constitution modifier. Your can use a shield and still " +
                "gain this benefit.");

            features.Add("Danger Sense", "At 2nd level, you gain an uncanny sense " +
                "of when things nearby aren't as they should be, giving you an edge " +
                "when you dodge away from danger. You have advantage on Dexterity " +
                "saving throws against effects that you can see, such as traps and " +
                "spells. To gain this benefit, you can't be blinded, deafened, or " +
                "incapacitated.");

            features.Add("Reckless Attack", "Starting at 2nd level, you can throw " +
                "aside all concern for defense to attack with fierce desperation. " +
                "When you make your first attack on your turn, you can decide to " +
                "attack recklessly. Doing so gives you advantage on melee weapon " +
                "attack rolls using Strength during this turn, but attack rolls " +
                "against you have advantage until your next turn.");

            features.Add("Primal Path", "At 3rd level, you choose a path that " +
                "shapes the nature of your rage. Your choice grants you features " +
                "at 3rd level and again at 6th, 10th, and 14th levels.");

            features.Add("Class Ability Score Improvement", "When you reach 4th " +
                "level, and again at 8th, 12th, 16th, and 19th level, you can " +
                "increase one ability score of your choice by 2, or you can " +
                "increase two ability scores of your choice by 1. As normal, " +
                "you can't increase an ability score above 20 using this feature.");

            features.Add("Extra Attack", "Beginning at 5-th level, you can attack " +
                "twice, instead of once, whenever you take the Attack action on " +
                "your turn.");

            features.Add("Fast Movement", "Starting at 5-th level, your speed " +
                "increases by 10 feet while you aren't wearing heavy armor.");

            features.Add("Feral Instinct", "By 7th level, your instincts are so " +
                "honed that you have advantage on initiative rolls. Additionally, " +
                "if you are surprised at the beginning of combat and aren't " +
                "incapacitated, you can act normally on your first turn, but " +
                "only if you enter your rage before doing anything else on that turn.");

            features.Add("Brutal Critical", "Beginning at 9th level, you can roll" +
                " one additional weapon damage die when determining the extra " +
                "damage for a critical hit with a melee attack. This increases " +
                "to two additional dice at 13th level and three additional dice " +
                "at 17th level.");

            features.Add("Relentless Rage", "Starting at 11th level, your rage " +
                "can keep you fighting despite grievous wounds. If you drop to " +
                "0 hit points while you're raging and don't die outright, you " +
                "can make a DC 10 Constitution saving throw. If you succeed, " +
                "you drop to 1 hit point instead. Each time you use this " +
                "feature after the first, the DC increases by 5. When you " +
                "finish a short or long rest, the DC resets to 10.");

            features.Add("Persistent Rage", "Beginning at 15th level, your " +
                "rage is so fierce that it ends early only if you fall " +
                "unconscious or if you choose to end it.");

            features.Add("Indomitable Might", "Beginning at 18th level, if " +
                "your total for a Strength check is less than your Strength " +
                "score, you can use that score in place of the total.");

            features.Add("Primal Champion", "At 20th level, you embody the " +
                "power of the wilds. Your Strength and Constitution scores " +
                "increase by 4. Your maximum for those scores is now 24.");

            int skillProfs = 2;
            int rageCharges = 2;
            int rageDamage = 2;

            SavingThrows savingThrows = new SavingThrows();
            savingThrows.Strength.Profficiency = true;
            savingThrows.Constitution.Profficiency = true;

            Skills skills = new Skills();
            skills.AnimalHandling.Profficiency = true;
            skills.Athletics.Profficiency = true;
            skills.Intimidation.Profficiency = true;
            skills.Nature.Profficiency = true;
            skills.Perception.Profficiency = true;
            skills.Survival.Profficiency = true;

            List<ItemPair> equipment = new List<ItemPair>()
            {
                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Greataxe",
                            Description = "A big axe, made specifically for combat.",
                            Price = 300,
                            Weight = 7,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Martial weapon",
                            Description = "Any martial weapon of your choice",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Handaxe",
                            Description = "This is a handaxe, a simple weapon, but can also serve as a usefull tool.",
                            Price = 50,
                            Weight = 2,
                            Quantity = 2
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Simple weapon",
                            Description = "You get a simple weapon of your choice.",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        },
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Backpack",
                            Description = "A backpack can hold one cubic foot or 30 pounds of gear. You can also strap items, such as a bedroll or a coil of rope, to the outside of a backpack.",
                            Price = 20,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Bedroll",
                            Description = "You never know where you’re going to sleep, and a bedroll helps you get better sleep in a hayloft or on the cold ground. A bedroll consists of bedding and a blanket thin enough to be rolled up and tied. In an emergency, it can double as a stretcher.",
                            Price = 10,
                            Weight = 7,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Mess kit",
                            Description = "This tin box contains a cup and simple cutlery. The box clamps together, and one side can be used as a cooking pan and the other as a plate or shallow bowl.",
                            Price = 2,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Tinderbox",
                            Description = "This small container holds flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a torch -- or anything else with abundant, exposed fuel -- takes an action. Lighting any other fire takes 1 minute.",
                            Price = 5,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Ration (1 day)",
                            Description = "Rations consist of dry foods suitable for extended travel, including jerky, dried fruit, hardtack, and nuts.",
                            Price = 5,
                            Weight = 2,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Waterskin",
                            Description = "A waterskin can hold 4 pints of liquid.",
                            Price = 2,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Torch",
                            Description = "A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage.",
                            Price = 0.1,
                            Weight = 1,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Rope, Hempen (50 feet)",
                            Description = "Rope, has 2 hit points and can be burst with a DC 17 Strength check.",
                            Price = 10,
                            Weight = 10,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Backpack",
                            Description = "A backpack can hold one cubic foot or 30 pounds of gear. You can also strap items, such as a bedroll or a coil of rope, to the outside of a backpack.",
                            Price = 20,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Bedroll",
                            Description = "You never know where you’re going to sleep, and a bedroll helps you get better sleep in a hayloft or on the cold ground. A bedroll consists of bedding and a blanket thin enough to be rolled up and tied. In an emergency, it can double as a stretcher.",
                            Price = 10,
                            Weight = 7,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Mess kit",
                            Description = "This tin box contains a cup and simple cutlery. The box clamps together, and one side can be used as a cooking pan and the other as a plate or shallow bowl.",
                            Price = 2,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Tinderbox",
                            Description = "This small container holds flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a torch -- or anything else with abundant, exposed fuel -- takes an action. Lighting any other fire takes 1 minute.",
                            Price = 5,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Ration (1 day)",
                            Description = "Rations consist of dry foods suitable for extended travel, including jerky, dried fruit, hardtack, and nuts.",
                            Price = 5,
                            Weight = 2,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Waterskin",
                            Description = "A waterskin can hold 4 pints of liquid.",
                            Price = 2,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Torch",
                            Description = "A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage.",
                            Price = 0.1,
                            Weight = 1,
                            Quantity = 10
                        },

                        new Item()
                        {
                            Name = "Rope, Hempen (50 feet)",
                            Description = "Rope, has 2 hit points and can be burst with a DC 17 Strength check.",
                            Price = 10,
                            Weight = 10,
                            Quantity = 1
                        }
                    }
                }
            };

            List<string> subClasses = new List<string>();
            subClasses.Add("Berserker");
            subClasses.Add("Totem Warrior");

            Barbarian barbarian = new Barbarian();

            barbarian.ClassName = name;
            barbarian.ClassDescription = desc;
            barbarian.HitDice = hitDice;
            barbarian.ClassFeatures = features;
            barbarian.AmountOfSkillProfs = skillProfs;
            barbarian.ClassSavingThrows = savingThrows;
            barbarian.ClassSkills = skills;
            barbarian.ClassInventory = equipment;
            barbarian.SubClasses = subClasses;

            return barbarian;
        }

        public Bard CreateBard()
        {
            string name = "Bard";
            string desc = "Whether scholar, skald, or scoundrel, a bard weaves " +
                "magic through words and music to inspire allies, demoralize " +
                "foes, manipulate minds, create illusions, and even heal " +
                "wounds. The bard is a master of song, speech, and the magic " +
                "they contain.";

            Dice hitDice = new Dice(1, 8);

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Hit Points", "Your hit dice are 1d8 per bard " +
                "level, your hit points at level 1 are 8 + your " +
                "constitution modifier.");

            features.Add("Proficiencies", "You gain a proficiency with light armor, " +
                "simple weapons, hand crossbows, longswords, rapiers, shortswords, " +
                "three musical instruments of your choice, dexterity and charisma " +
                "saving throws, any three skills.");

            features.Add("Equipment", "You start with the following equipment in " +
                "addition to the equipment granted by your background: " +
                "(a) a rapier (b) a longsword, " +
                "(a) a diplomat's pack (b) an entertainer's pack, " +
                "(a) a lute or (b) any other musical instrument, " +
                "Leather armor and a dagger");

            features.Add("Cantrips", "You know two cantrips of your choice from the " +
                "bard spell list. You learn additional bard cantrips of your choice " +
                "at higher levels, as shown in the Cantrips Known column of the Bard table.");
            
            features.Add("Spell Slots", "The Bard table shows how many spell slots " +
                "you have to cast your bard spells of 1st level and higher. To cast " +
                "one of these spells, you must expend a slot of the spell's level or " +
                "higher. You regain all expended spell slots when you finish a long " +
                "rest. For example, if you know the 1st-level spell Cure Wounds and " +
                "have a 1st-level and a 2nd-level spell slot available, you can cast " +
                "Cure Wounds using either slot.");
            
            features.Add("Spells Known of 1st Level and Higher", "You know four " +
                "1st-level spells of your choice from the bard spell list. Additionally, " +
                "when you gain a level in this class, you can choose one of the bard " +
                "spells you know and replace it with another spell from the bard spell " +
                "list, which also must be of a level for which you have spell slots.");
            
            features.Add("Spellcasting Ability", "Charisma is your spellcasting ability " +
                "for your bard spells. Your magic comes from the heart and soul you pour " +
                "into the performance of your music or oration. You use your Charisma " +
                "whenever a spell refers to your spellcasting ability. In addition, you " +
                "use your Charisma modifier when setting the saving throw DC for a bard " +
                "spell you cast and when making an attack roll with one. Spell save " +
                "DC = 8 + your proficiency bonus + your Charisma modifier. Spell attack " +
                "modifier = your proficiency bonus + your Charisma modifier.");
            
            features.Add("Ritual Casting", "You can cast any bard spell you know as a " +
                "ritual if that spell has the ritual tag.");
            
            features.Add("Spellcasting Focus", "ou can use a musical instrument (found " +
                "in chapter 5) as a spellcasting focus for your bard spells.");
            
            features.Add("Bardic Inspiration", "You can inspire others through stirring " +
                "words or music. To do so, you use a bonus action on your turn to choose " +
                "one creature other than yourself within 60 feet of you who can hear you. " +
                "That creature gains one Bardic Inspiration die, a d6. Once within the next " +
                "10 minutes, the creature can roll the die and add the number rolled to one " +
                "ability check, attack roll, or saving throw it makes. The creature can wait " +
                "until after it rolls the d20 before deciding to use the Bardic Inspiration " +
                "die, but must decide before the DM says whether the roll succeeds or fails. " +
                "Once the Bardic Inspiration die is rolled, it is lost. A creature can have " +
                "only one Bardic Inspiration die at a time. You can use this feature a " +
                "number of times equal to your Charisma modifier (a minimum of once). " +
                "You regain any expended uses when you finish a long rest. Your Bardic " +
                "Inspiration die changes when you reach certain levels in this class. " +
                "The die becomes a d8 at 5th level, a d10 at 10th level, and a d12 at " +
                "15th level.");
            
            features.Add("Jack of All Trades", "Starting at 2nd level, you can add half " +
                "your proficiency bonus, rounded down, to any ability check you make that " +
                "doesn't already include your proficiency bonus.");
            
            features.Add("Song of Rest", "Beginning at 2nd level, you can use soothing " +
                "music or oration to help revitalize your wounded allies during a short " +
                "rest. If you or any friendly creatures who can hear your performance " +
                "regain hit points at the end of the short rest by spending one or more " +
                "Hit Dice, each of those creatures regains an extra 1d6 hit points. " +
                "The extra Hit Points increase when you reach certain levels in this " +
                "class: to 1d8 at 9th level, to 1d10 at 13th level, and to 1d12 at 17th level.");
            
            features.Add("Bard College", "At 3rd level, you delve into the advanced " +
                "techniques of a bard college of your choice. Your choice grants you " +
                "features at 3rd level and again at 6th and 14th level.");
            
            features.Add("Expertise", "At 3rd level, choose two of your skill proficiencies. " +
                "Your proficiency bonus is doubled for any ability check you make that uses " +
                "either of the chosen proficiencies. At 10th level, you can choose another " +
                "two skill proficiencies to gain this benefit.");
            
            features.Add("Class Ability Score Improvement", "When you reach 4th level, " +
                "and again at 8th, 12th, 16th, and 19th level, you can increase one " +
                "ability score of your choice by 2, or you can increase two ability " +
                "scores of your choice by 1. As normal, you can't increase an ability " +
                "score above 20 using this feature.");
            
            features.Add("Font of Inspiration", "Beginning when you reach 5th level, " +
                "you regain all of your expended uses of Bardic Inspiration when you " +
                "finish a short or long rest.");
            
            features.Add("Countercharm", "At 6th level, you gain the ability to use " +
                "musical notes or words of power to disrupt mind-influencing effects. " +
                "As an action, you can start a performance that lasts until the end of " +
                "your next turn. During that time, you and any friendly creatures within " +
                "30 feet of you have advantage on saving throws against being frightened " +
                "or charmed. A creature must be able to hear you to gain this benefit. The " +
                "performance ends early if you are incapacitated or silenced or if you " +
                "voluntarily end it (no action required).");
            
            features.Add("Magical Secrets", "By 10th level, you have plundered magical " +
                "knowledge from a wide spectrum of disciplines. Choose two spells from any " +
                "classes, including this one. A spell you choose must be of a level you can " +
                "cast, as shown on the Bard table, or a cantrip. The chosen spells count as " +
                "bard spells for you and are included in the number in the Spells Known " +
                "column of the Bard table. You learn two additional spells from any classes " +
                "at 14th level and again at 18th level.");
            
            features.Add("Superior Inspiration", "At 20th level, when you roll initiative " +
                "and have no uses of Bardic Inspiration left, you regain one use.");

            int skillProfs = 3;

            SavingThrows savingThrows = new SavingThrows();
            savingThrows.Dexterity.Profficiency = true;
            savingThrows.Charisma.Profficiency = true;

            Skills skills = new Skills();
            skills.Athletics.Profficiency = true;
            skills.Acrobatics.Profficiency = true;
            skills.SleightOfHand.Profficiency = true;
            skills.Stealth.Profficiency = true;
            skills.Arcana.Profficiency = true;
            skills.History.Profficiency = true;
            skills.Investigation.Profficiency = true;
            skills.Nature.Profficiency = true;
            skills.Religion.Profficiency = true;
            skills.Insight.Profficiency = true;
            skills.AnimalHandling.Profficiency = true;
            skills.Medicine.Profficiency = true;
            skills.Intimidation.Profficiency = true;
            skills.Perception.Profficiency = true;
            skills.Deception.Profficiency = true;
            skills.Performance.Profficiency = true;
            skills.Persuation.Profficiency = true;

            List<ItemPair> equipment = new List<ItemPair>()
            {
                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Rapier",
                            Description = "Light, fast and deadly finesse weapon.",
                            Price = 250,
                            Weight = 2,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Longsword",
                            Description = "Long yet not heavy sword, quite fancy.",
                            Price = 150,
                            Weight = 3,
                            Quantity = 1
                        },
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Diplomat's Pack",
                            Description = "Includes a chest, 2 cases for maps and scrolls, a set of fine clothes, a bottle of ink, an ink pen, a lamp, 2 flasks of oil, 5 sheets of paper, a vial of perfume, sealing wax, and soap.",
                            Price = 390,
                            Weight = 36,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Entertainer's Pack",
                            Description = "Includes a backpack, a bedroll, 2 costumes, 5 candles, 5 days of rations, a waterskin, and a disguise kit.",
                            Price = 400,
                            Weight = 38,
                            Quantity = 1
                        },
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Lute",
                            Description = "A musical instrument that uses strings to make sounds. Favourite among bards.",
                            Price = 350,
                            Weight = 2,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Musical Instrument",
                            Description = "Any musical instrument of your imagination",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Leather Armor",
                            Description = "The breastplate and shoulder protectors of this armor are made of leather that has been stiffened by being boiled in oil. The rest of the armor is made of softer and more flexible materials.",
                            Price = 100,
                            Weight = 10,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Dagger",
                            Description = "A small dagger, easy to hide and deadly.",
                            Price = 20,
                            Weight = 1,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Leather Armor",
                            Description = "The breastplate and shoulder protectors of this armor are made of leather that has been stiffened by being boiled in oil. The rest of the armor is made of softer and more flexible materials.",
                            Price = 100,
                            Weight = 10,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Dagger",
                            Description = "A small dagger, easy to hide and deadly.",
                            Price = 20,
                            Weight = 1,
                            Quantity = 1
                        }
                    }
                }
            };

            List<string> subClasses = new List<string>();
            subClasses.Add("Lore Bard");
            subClasses.Add("Valor Bard");

            Bard bard = new Bard();

            bard.ClassName = name;
            bard.ClassDescription = desc;
            bard.HitDice = hitDice;
            bard.ClassFeatures = features;
            bard.AmountOfSkillProfs = skillProfs;
            bard.ClassSavingThrows = savingThrows;
            bard.ClassSkills = skills;
            bard.ClassInventory = equipment;
            bard.SubClasses = subClasses;

            return bard;
        }

        public Cleric CreateCleric()
        {
            string name = "Cleric";
            string desc = "Clerics are intermediaries between the mortal world " +
                "and the distant planes of the gods. As varied as the gods they " +
                "serve, clerics strive to embody the handiwork of their deities. " +
                "No ordinary priest, a cleric is imbued with divine magic.";

            Dice hitDice = new Dice(1, 8);

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Hit Points", "Your hit dice are 1d8 per cleric " +
                "level, your hit points at level 1 are 8 + your " +
                "constitution modifier.");

            features.Add("Proficiencies", "You gain a proficiency with light " +
                "armor, medium armor, shields, all simple weapons, wisdom and " +
                "charisma saving throws, two skills out of History, Insight, " +
                "Medicine, Persuasion and Religion.");

            features.Add("Equipment", "You start with the following equipment in " +
                "addition to the equipment granted by your background: " +
                "(a) a mace (b) a warhammer, " +
                "(a) scale mail (b) leather armor, " +
                "(a) a light crossbow and 20 bolts (b) any simple weapon, " +
                "(a) a priest's pack or (b) an explorer's pack" +
                "A shield and a holy symbol");

            features.Add("Spellcasting", "As a conduit for divine power, you can " +
                "cast cleric spells.");

            features.Add("Cantrips", "At 1st level, you know three cantrips of your " +
                "choice from the cleric spell list. You learn additional cleric " +
                "cantrips of your choice at higher levels, as shown in the Cantrips" +
                " Known column of the Cleric table.");

            features.Add("Spell Slots", "You prepare the list of cleric spells that " +
                "are available for you to cast, choosing from the cleric spell list. " +
                "When you do so, choose a number of cleric spells equal to your Wisdom " +
                "modifier + your cleric level (minimum of one spell). The spells must be " +
                "of a level for which you have spell slots. For example, if you are a " +
                "3rd-level cleric, you have four 1st-level and two 2nd-level spell slots." +
                " With a Wisdom of 16, your list of prepared spells can include six " +
                "spells of 1st or 2nd level, in any combination. If you prepare the " +
                "1st-level spell Cure Wounds, you can cast it using a 1st-level or " +
                "2nd-level slot. Casting the spell doesn't remove it from your list " +
                "of prepared spells. You can change your list of prepared spells when " +
                "you finish a long rest. Preparing a new list of cleric spells requires " +
                "time spent in prayer and meditation: at least 1 minute per spell " +
                "level for each spell on your list.");

            features.Add("Spellcasting Ability", "Wisdom is your spellcasting ability " +
                "for your cleric spells. The power of your spells comes from your devotion " +
                "to your deity. You use your Wisdom whenever a cleric spell refers to your " +
                "spellcasting ability. In addition, you use your Wisdom modifier when " +
                "setting the saving throw DC for a cleric spell you cast and when making " +
                "an attack roll with one. Spell save DC = 8 + your proficiency bonus + " +
                "your Wisdom modifier. Spell attack modifier = your proficiency bonus + " +
                "your Wisdom modifier.");

            features.Add("Ritual Casting", "You can cast a cleric spell as a ritual if " +
                "that spell has the ritual tag and you have the spell prepared.");

            features.Add("Spellcasting Focus", "You can use a holy symbol as a spellcasting " +
                "focus for your cleric spells.");

            features.Add("Divine Domain", "At 1st level, you choose a domain shaped by your" +
                " choice of Deity and the gifts they grant you. Your choice grants you domain" +
                " spells and other features when you choose it at 1st level. It also grants " +
                "you additional ways to use Channel Divinity when you gain that feature at " +
                "2nd level, and additional benefits at 6th, 8th, and 17th levels.");

            features.Add("Domain Spells", "Each domain has a list of spells-its domain spells " +
                "that you gain at the cleric levels noted in the domain description. Once you " +
                "gain a domain spell, you always have it prepared, and it doesn't count against " +
                "the number of spells you can prepare each day. If you have a domain spell that " +
                "doesn't appear on the cleric spell list, the spell is nonetheless a cleric" +
                " spell for you.");

            features.Add("Channel Divinity", "At 2nd level, you gain the ability to channel" +
                " divine energy directly from your deity, using that energy to fuel magical" +
                " effects. You start with two such effects: Turn Undead and an effect determined " +
                "by your domain. Some domains grant you additional effects as you advance in " +
                "levels, as noted in the domain description. When you use your Channel " +
                "Divinity, you choose which effect to create. You must then finish a short or " +
                "long rest to use your Channel Divinity again. Some Channel Divinity effects " +
                "require saving throws. When you use such an effect from this class, the DC " +
                "equals your cleric spell save DC. Beginning at 6th level, you can use your " +
                "Channel Divinity twice between rests, and beginning at 18th level, you can " +
                "use it three times between rests. When you finish a short or long rest, you " +
                "regain your expended uses.");

            features.Add("Channel Divinity: Turn Undead", "As an action, you present your holy" +
                " symbol and speak a prayer censuring the undead. Each undead that can see or" +
                " hear you within 30 feet of you must make a Wisdom saving throw. If the creature" +
                " fails its saving throw, it is turned for 1 minute or until it takes any damage." +
                " A turned creature must spend its turns trying to move as far away from you as " +
                "it can, and it can't willingly move to a space within 30 feet of you. It also " +
                "can't take reactions. For its action, it can use only the Dash action or try to " +
                "escape from an effect that prevents it from moving. If there's nowhere to move," +
                " the creature can use the Dodge action.");

            features.Add("Class Ability Score Improvement", "When you reach 4th level, and again" +
                " at 8th, 12th, 16th, and 19th level, you can increase one ability score of your" +
                " choice by 2, or you can increase two ability scores of your choice by 1. As " +
                "normal, you can't increase an ability score above 20 using this feature.");

            features.Add("Destroy Undead", "Starting at 5th level, when an undead fails its " +
                "saving throw against your Turn Undead feature, the creature is instantly" +
                " destroyed if its challenge rating is at or below a certain threshold, as shown" +
                " in the Cleric table above.");

            features.Add("Divine Intervention", "Beginning at 10th level, you can call on your " +
                "deity to intervene on your behalf when your need is great. Imploring your deity's" +
                " aid requires you to use your action. Describe the assistance you seek, and " +
                "roll percentile dice. If you roll a number equal to or lower than your cleric" +
                " level, your deity intervenes. The DM chooses the nature of the intervention;" +
                " the effect of any cleric spell or cleric domain spell would be appropriate." +
                " If your deity intervenes, you can't use this feature again for 7 days. Otherwise, " +
                "you can use it again after you finish a long rest. At 20th level, your call for" +
                " intervention succeeds automatically, no roll required.");

            int skillProfs = 2;

            SavingThrows savingThrows = new SavingThrows();
            savingThrows.Wisdom.Profficiency = true;
            savingThrows.Charisma.Profficiency = true;

            Skills skills = new Skills();
            skills.History.Profficiency = true;
            skills.Religion.Profficiency = true;
            skills.Insight.Profficiency = true;
            skills.Medicine.Profficiency = true;
            skills.Persuation.Profficiency = true;

            List<ItemPair> equipment = new List<ItemPair>()
            {
                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Mace",
                            Description = "Quite simple, but devastating blunt weapon.",
                            Price = 50,
                            Weight = 4,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Warhammer",
                            Description = "A hammer specifically designed for combat",
                            Price = 150,
                            Weight = 2,
                            Quantity = 1
                        },
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Scale mail",
                            Description = "This armor consists of a coat and leggings (and perhaps a separate skirt) of leather covered with overlapping pieces of metal, much like the scales of a fish. The suit includes gauntlets.",
                            Price = 500,
                            Weight = 45,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Leather Armor",
                            Description = "The breastplate and shoulder protectors of this armor are made of leather that has been stiffened by being boiled in oil. The rest of the armor is made of softer and more flexible materials.",
                            Price = 100,
                            Weight = 10,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Light Crossbow",
                            Description = "It is a crossbow, but a light one, quite usefull as a side weapon.",
                            Price = 250,
                            Weight = 5,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Bolts 10x",
                            Description = "Bolts that can be shot from a crossbow.",
                            Price = 10,
                            Weight = 1,
                            Quantity = 2
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Simple Weapon",
                            Description = "Any simple weapon of your choice.",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Priest's Pack",
                            Description = "Includes a backpack, a blanket, 10 candles, a tinderbox, an alms box, 2 blocks of incense, a censer, vestments, 2 days of rations, and a waterskin.",
                            Price = 190,
                            Weight = 24,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Explorer's Pack",
                            Description = "Includes a backpack, a bedroll, a mess kit, a tinderbox, 10 torches, 10 days of rations, and a waterskin. The pack also has 50 feet of hempen rope strapped to the side of it.",
                            Price = 100,
                            Weight = 59,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Holy Symbol",
                            Description = "A holy symbol is a representation of a god or pantheon. A cleric or paladin can use a holy symbol as a spellcasting focus, as described in the Spellcasting section. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield.",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Shield",
                            Description = "A shield is made from wood or metal and is carried in one hand. Wielding a shield increases your Armor Class by 2. You can benefit from only one shield at a time.",
                            Price = 100,
                            Weight = 6,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Holy Symbol",
                            Description = "A holy symbol is a representation of a god or pantheon. A cleric or paladin can use a holy symbol as a spellcasting focus, as described in the Spellcasting section. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield.",
                            Price = 0,
                            Weight = 0,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Shield",
                            Description = "A shield is made from wood or metal and is carried in one hand. Wielding a shield increases your Armor Class by 2. You can benefit from only one shield at a time.",
                            Price = 100,
                            Weight = 6,
                            Quantity = 1
                        }
                    }
                }
            };

            List<string> subClasses = new List<string>();
            subClasses.Add("Knowledge Cleric");
            subClasses.Add("War Cleric");

            Cleric cleric = new Cleric();

            cleric.ClassName = name;
            cleric.ClassDescription = desc;
            cleric.HitDice = hitDice;
            cleric.ClassFeatures = features;
            cleric.AmountOfSkillProfs = skillProfs;
            cleric.ClassSavingThrows = savingThrows;
            cleric.ClassSkills = skills;
            cleric.ClassInventory = equipment;
            cleric.SubClasses = subClasses;

            return cleric;
        }

        public Rogue CreateRogue()
        {
            string name = "Rogue";
            string desc = "Rogues rely on skill, stealth, and their foes' " +
                "vulnerabilities to get the upper hand in any situation. They" +
                " have a knack for finding the solution to just about any " +
                "problem, demonstrating a resourcefulness and versatility " +
                "that is the cornerstone of any successful adventuring party.";

            Dice hitDice = new Dice(1, 8);

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Hit Points", "Your hit dice are 1d8 per rogue " +
                "level, your hit points at level 1 are 8 + your " +
                "constitution modifier.");

            features.Add("Proficiencies", "You gain a proficiency with light " +
                "armor, simple weapons, hand crossbows, longswords, rapiers, " +
                "shortswords, thieve's tools, dexterity and intelligence saving " +
                "throws, and four skills out of Acrobatics, Deception, Insight, " +
                "Intimidation, Investigation, Perception, Performance, Persuasion, " +
                "Sleight of Hand, Stealth.");

            features.Add("Equipment", "You start with the following equipment in " +
                "addition to the equipment granted by your background: " +
                "(a) a rapier (b) a shortsword, " +
                "(a) a shortbow and 20 arrows (b) a shortsword, " +
                "(a) a burglar's pack (b) a dungeoneer's pack, " +
                "Leather armor, two daggers, and thieves' tools");

            features.Add("Expertise", "At 1st level, choose two of your skill" +
                " proficiencies, or one of your skill proficiencies and your" +
                " proficiency with thieves' tools. Your proficiency bonus is " +
                "doubled for any ability check you make that uses either of the" +
                " chosen proficiencies. At 6th level, you can choose two more of" +
                " your proficiencies (in skills or with thieves' tools) to gain" +
                " this benefit.");

            features.Add("Sneak Attack", "Beginning at 1st level, you know how " +
                "to strike subtly and exploit a foe's distraction. Once per turn," +
                " you can deal an extra 1d6 damage to one creature you hit with " +
                "an attack if you have advantage on the attack roll. The attack " +
                "must use a finesse or a ranged weapon. You don't need advantage" +
                " on the attack roll if another enemy of the target is within 5 " +
                "feet of it, that enemy isn't incapacitated, and you don't have" +
                " disadvantage on the attack roll. The amount of the extra " +
                "damage increases as you gain levels in this class, as shown" +
                " in the Sneak Attack column of the Rogue table.");

            features.Add("Thieves' Cant", "During your rogue training you learned" +
                " thieves' cant, a secret mix of dialect, jargon, and code that" +
                " allows you to hide messages in seemingly normal conversation. " +
                "Only another creature that knows thieves' cant understands such " +
                "messages. It takes four times longer to convey such a message than" +
                " it does to speak the same idea plainly. In addition, you " +
                "understand a set of secret signs and symbols used to convey short," +
                " simple messages, such as whether an area is dangerous or the " +
                "territory of a thieves' guild, whether loot is nearby, or whether" +
                " the people in an area are easy marks or will provide a safe house" +
                " for thieves on the run.");

            features.Add("Cunning Action", "Starting at 2nd level, your quick" +
                " thinking and agility allow you to move and act quickly. You can" +
                " take a bonus action on each of your turns in combat. This action " +
                "can be used only to take the Dash, Disengage, or Hide action.");

            features.Add("Roguish Archetype", "At 3rd level, you choose an archetype" +
                " that you emulate in the exercise of your rogue abilities. Your" +
                " archetype choice grants you features at 3rd level and then again " +
                "at 9th, 13th, and 17th level.");

            features.Add("Class Ability Score Improvement", "When you reach 4th " +
                "level, and again at 8th, 10th, 12th, 16th, and 19th level, you" +
                " can increase one ability score of your choice by 2, or you can " +
                "increase two ability scores of your choice by 1. As normal, you " +
                "can't increase an ability score above 20 using this feature.");

            features.Add("Uncanny Dodge", "Starting at 5th level, when an attacker" +
                " that you can see hits you with an attack, you can use your reaction" +
                " to halve the attack's damage against you.");

            features.Add("Evasion", "Beginning at 7th level, you can nimbly dodge" +
                " out of the way of certain area effects, such as a red dragon's " +
                "fiery breath or an Ice Storm spell. When you are subjected to an " +
                "effect that allows you to make a Dexterity saving throw to take" +
                " only half damage, you instead take no damage if you succeed on" +
                " the saving throw, and only half damage if you fail.");

            features.Add("Reliable Talent", "By 11th level, you have refined your " +
                "chosen skills until they approach perfection. Whenever you make an " +
                "ability check that lets you add your proficiency bonus, you can treat" +
                " a d20 roll of 9 or lower as a 10.");

            features.Add("Blindsense", "Starting at 14th level, if you are able to " +
                "hear, you are aware of the location of any hidden or invisible " +
                "creature within 10 feet of you.");

            features.Add("Slippery Mind", "By 15th level, you have acquired greater" +
                " mental strength. You gain proficiency in Wisdom saving throws.");

            features.Add("Elusive", "Beginning at 18th level, you are so evasive " +
                "that attackers rarely gain the upper hand against you. No attack" +
                " roll has advantage against you while you aren't incapacitated.");

            features.Add("Stroke of Luck", "At 20th level, you have an uncanny " +
                "knack for succeeding when you need to. If your attack misses a " +
                "target within range, you can turn the miss into a hit. Alternatively," +
                " if you fail an ability check, you can treat the d20 roll as a 20." +
                " Once you use this feature, you can't use it again until you finish " +
                "a short or long rest.");

            int skillProfs = 4;

            SavingThrows savingThrows = new SavingThrows();
            savingThrows.Dexterity.Profficiency = true;
            savingThrows.Intelligence.Profficiency = true;

            Skills skills = new Skills();
            skills.Acrobatics.Profficiency = true;
            skills.Athletics.Profficiency = true;
            skills.Deception.Profficiency = true;
            skills.Insight.Profficiency = true;
            skills.Intimidation.Profficiency = true;
            skills.Investigation.Profficiency = true;
            skills.Perception.Profficiency = true;
            skills.Performance.Profficiency = true;
            skills.Persuation.Profficiency = true;
            skills.SleightOfHand.Profficiency = true;
            skills.Stealth.Profficiency = true;

            List<ItemPair> equipment = new List<ItemPair>()
            {
                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Rapier",
                            Description = "Light, fast and deadly finesse weapon.",
                            Price = 250,
                            Weight = 2,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Shortsword",
                            Description = "A short sword.",
                            Price = 100,
                            Weight = 2,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Shortbow",
                            Description = "This is a shortbow, it's a short bow, quick to draw but lacks strength of a longbow.",
                            Price = 250,
                            Weight = 2,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Arrows 10x",
                            Description = "Arrows that can be shot from a bow.",
                            Price = 10,
                            Weight = 1,
                            Quantity = 2
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Shortsword",
                            Description = "A short sword.",
                            Price = 100,
                            Weight = 2,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Burglar's Pack",
                            Description = "Includes a backpack, a bag of 1,000 ball bearings, 10 feet of string, a bell, 5 candles, a crowbar, a hammer, 10 pitons, a hooded lantern, 2 flasks of oil, 5 days rations, a tinderbox, and a waterskin. The pack also has 50 feet of hempen rope strapped to the side of it.",
                            Price = 160,
                            Weight = 47,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Dungeoneer's Pack",
                            Description = "Includes a backpack, a crowbar, a hammer, 10 pitons, 10 torches, a tinderbox, 10 days of rations, and a waterskin. The pack also has 50 feet of hempen rope strapped to the side of it.",
                            Price = 120,
                            Weight = 61,
                            Quantity = 1
                        }
                    }
                },

                new ItemPair()
                {
                    A = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Leather Armor",
                            Description = "The breastplate and shoulder protectors of this armor are made of leather that has been stiffened by being boiled in oil. The rest of the armor is made of softer and more flexible materials.",
                            Price = 100,
                            Weight = 10,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Dagger",
                            Description = "A small dagger, easy to hide and deadly.",
                            Price = 20,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Thieves' Tools",
                            Description = "This set of tools includes a small file, a set of lock picks, a small mirror mounted on a metal handle, a set of narrow-bladed scissors, and a pair of pliers. Proficiency with these tools lets you add your proficiency bonus to any ability checks you make to disarm traps or open locks.",
                            Price = 250,
                            Weight = 1,
                            Quantity = 1
                        }
                    },

                    B = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Leather Armor",
                            Description = "The breastplate and shoulder protectors of this armor are made of leather that has been stiffened by being boiled in oil. The rest of the armor is made of softer and more flexible materials.",
                            Price = 100,
                            Weight = 10,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Dagger",
                            Description = "A small dagger, easy to hide and deadly.",
                            Price = 20,
                            Weight = 1,
                            Quantity = 1
                        },

                        new Item()
                        {
                            Name = "Thieves' Tools",
                            Description = "This set of tools includes a small file, a set of lock picks, a small mirror mounted on a metal handle, a set of narrow-bladed scissors, and a pair of pliers. Proficiency with these tools lets you add your proficiency bonus to any ability checks you make to disarm traps or open locks.",
                            Price = 250,
                            Weight = 1,
                            Quantity = 1
                        }
                    }
                }
            };

            List<string> subClasses = new List<string>();
            subClasses.Add("Assasin");
            subClasses.Add("Thief");

            Rogue rogue = new Rogue();

            rogue.ClassName = name;
            rogue.ClassDescription = desc;
            rogue.HitDice = hitDice;
            rogue.ClassFeatures = features;
            rogue.AmountOfSkillProfs = skillProfs;
            rogue.ClassSavingThrows = savingThrows;
            rogue.ClassSkills = skills;
            rogue.ClassInventory = equipment;
            rogue.SubClasses = subClasses;

            return rogue;
        }

        public Result<bool> FinishFighter(Fighter fighter, string fightingStyleInput)
        {
            Dictionary<FightingStyle, string> fightingStyleDescritpions = new Dictionary<FightingStyle, string>();
            fightingStyleDescritpions.Add(FightingStyle.Archery, "You gain a +2 bonus to attack rolls you make with ranged weapons.");
            fightingStyleDescritpions.Add(FightingStyle.Defence, "While you are wearing armor, you gain a +1 bonus to AC.");
            fightingStyleDescritpions.Add(FightingStyle.Dueling, "When you are wielding a melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon.");
            fightingStyleDescritpions.Add(FightingStyle.GreatWeaponFighting, "When you roll a 1 or 2 on a damage die for an attack you make with a melee weapon that you are wielding with two hands, you can reroll the die and must use the new roll, even if the new roll is a 1 or a 2. The weapon must have the two-handed or versatile property for you to gain this benefit.");
            fightingStyleDescritpions.Add(FightingStyle.Protection, "When a creature you can see attacks a target other than you that is within 5 feet of you, you can use your reaction to impose disadvantage on the attack roll. You must be wielding a shield.");
            fightingStyleDescritpions.Add(FightingStyle.TwoWeaponFighting, "When you engage in two-weapon fighting, you can add your ability modifier to the damage of the second attack.");


            if (int.TryParse(fightingStyleInput, out int fightingStyleNum))
            {
                if (fightingStyleNum > 0 && fightingStyleNum < 7)
                {
                    FightingStyle fightingStyle = (FightingStyle)fightingStyleNum;
                    fighter.FightingStyle = fightingStyle;
                    fighter.FightingStyleDesc = fightingStyleDescritpions[fightingStyle];
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("Invalid fighting style selection! Fighting style with number that you have selected does not exist.");
                }
            }
            else
            {
                return Result<bool>.Failure("Invalid fighting style selection! Please use only numbers.");
            }
        }
    }
}
