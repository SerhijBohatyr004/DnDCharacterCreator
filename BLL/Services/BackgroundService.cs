using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Core.Models;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using DAL.Interfaces;

namespace BLL.Services
{
    public class BackgroundService : IBackgroundService
    {
        private readonly IGenericRepository<Background> _repository;

        public BackgroundService(IGenericRepository<Background> repository)
        {
            _repository = repository;
        }

        public Result<Background> GetBackground(string backName)
        {
            return _repository.GetSingleByCondition(back => back.BackName == backName);
        }

        public void CreateAllBackgrounds()
        {
            CreateAcolyte();
            CreateCharlatan();
            CreateCriminal();
            CreateEntertainer();
            CreateFolkHero();
            CreateGuildArtisan();
            CreateHermit();
            CreateNoble();
            CreateOutlander();
            CreateSage();
            CreateSailor();
            CreateSoldier();
            CreateUrchin();
        }

        private void CreateAcolyte()
        {
            string backName = "Acolyte";
            string backDesc = "You have spent your life in the service of a temple to a " +
                "specific god or pantheon of gods. You act as an intermediary between the " +
                "realm of the holy and the mortal world, performing sacred rites and offering " +
                "sacrifices in order to conduct worshipers into the presence of the divine. " +
                "You are not necessarily a cleric—performing sacred rites is not the same " +
                "thing as channeling divine power. Choose a god, a pantheon of gods, or some " +
                "other quasi-divine being from among those listed in Fantasy-Historical " +
                "Pantheons or those specified by your GM, and work with your GM to detail " +
                "the nature of your religious service. Were you a lesser functionary in a " +
                "temple, raised from childhood to assist the priests in the sacred rites? " +
                "Or were you a high priest who suddenly experienced a call to serve your " +
                "god in a different way? Perhaps you were the leader of a small cult outside " +
                "of any established temple structure, or even an occult group that served " +
                "a fiendish master that you now deny.";

            Skills skillProfs = new Skills();
            skillProfs.Insight.Profficiency = true;
            skillProfs.Religion.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Shelter of the Faithful", "As an acolyte, you command the respect " +
                "of those who share your faith, and you can perform the religious ceremonies of " +
                "your deity. You and your adventuring companions can expect to receive " +
                "free healing and care at a temple, shrine, or other established presence " +
                "of your faith, though you must provide any material components needed for " +
                "spells. Those who share your religion will support you (but only you) at a " +
                "modest lifestyle. You might also have ties to a specific temple dedicated " +
                "to your chosen deity or pantheon, and you have a residence there. This " +
                "could be the temple where you used to serve, if you remain on good terms " +
                "with it, or a temple where you have found a new home. While near your " +
                "temple, you can call upon the priests for assistance, provided the " +
                "assistance you ask for is not hazardous and you remain in good " +
                "standing with your temple.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Holy Symbol",
                    Description = "Holy Symbol of your church, a gift given to you when you entered priesthood.",
                    Price = 50,
                    Weight = 1,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Prayer Book",
                    Description = "A book filled with various prayers.",
                    Price = 250,
                    Weight = 5,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Incense Stick",
                    Description = "A stick of incense.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 5
                },

                new Item()
                {
                    Name = "Vestment",
                    Description = "Religious clothing.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Set of Common Clothes",
                    Description = "Common Clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 15
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateCharlatan()
        {
            string backName = "Charlatan";
            string backDesc = "You have always had a way with people. You know " +
                "what makes them tick, you can tease out their hearts' desires " +
                "after a few minutes of conversation, and with a few leading " +
                "questions you can read them like they were children's books. " +
                "It's a useful talent, and one that you're perfectly willing " +
                "to use for your advantage. You know what people want and you " +
                "deliver, or rather, you promise to deliver. Common sense " +
                "should steer people away from things that sound too good to " +
                "be true, but common sense seems to be in short supply when " +
                "you're around. The bottle of pink colored liquid will surely " +
                "cure that unseemly rash, this ointment – nothing more than a " +
                "bit of fat with a sprinkle of silver dust can restore youth " +
                "and vigor, and there's a bridge in the city that just happens " +
                "to be for sale. These marvels sound implausible, but " +
                "you make them sound like the real deal.";

            Skills skillProfs = new Skills();
            skillProfs.Deception.Profficiency = true;
            skillProfs.SleightOfHand.Profficiency = true;
            
            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You gain proficiency with Disguise kit and Forgery kit.");
            features.Add("False Identity", "You have created a second identity " +
                "that includes documentation, established acquaintances, and " +
                "disguises that allow you to assume that persona. Additionally, " +
                "you can forge documents including official papers and personal " +
                "letters, as long as you have seen an example of the kind of " +
                "document or the handwriting you are trying to copy.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Fine Clothes",
                    Description = "A set of fine clothes.",
                    Price = 150,
                    Weight = 6,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Disguise Kit",
                    Description = "A disguise kit used for faking your identity.",
                    Price = 250,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Charlatan Tools",
                    Description = "Some item you can use to fool people, could be anything like a set of weighted dice or a deck of marked cards.",
                    Price = 5,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 15
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateCriminal()
        {
            string backName = "Criminal";
            string backDesc = "You are an experienced criminal with a history " +
                "of breaking the law. You have spent a lot of time among other " +
                "criminals and still have contacts within the criminal underworld. " +
                "You're far closer than most people to the world of murder, theft, " +
                "and violence that pervades the underbelly of civilization, and you " +
                "have survived up to this point by flouting the rules and " +
                "regulations of society.";

            Skills skillProfs = new Skills();
            skillProfs.Deception.Profficiency = true;
            skillProfs.Stealth.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Criminal Contact", "You have a reliable and " +
                "trustworthy contact who acts as your liaison to a network " +
                "of other criminals. You know how to get messages to and " +
                "from your contact, even over great distances; specifically," +
                " you know the local messengers, corrupt caravan masters, and seedy" +
                " sailors who can deliver messages for you.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Crowbar",
                    Description = "It's a crowbar, you can use it to break something, may it be a lock or someone's face.",
                    Price = 20,
                    Weight = 5,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Dark Common Clothes Set",
                    Description = "It's a set of dark common clothes, hood included.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 15
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateEntertainer()
        {
            string backName = "Entertainer";
            string backDesc = "You thrive in front of an audience. You know " +
                "how to entrance them, entertain them, and even inspire them. " +
                "Your poetics can stir the hearts of those who hear you, " +
                "awakening grief or joy, laughter or anger. Your music " +
                "raises their spirits or captures their sorrow. Your " +
                "dance steps captivate, your humor cuts to the quick. " +
                "Whatever techniques you use, your art is your life.";

            Skills skillProfs = new Skills();
            skillProfs.Acrobatics.Profficiency = true;
            skillProfs.Performance.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You gain proficiency with disguise " +
                "kit and with one type of musical instrument.");
            features.Add("By Popular Demand", "You can always find a place to " +
                "perform, usually in an inn or tavern but possibly with a circus, " +
                "at a theater, or even in a noble's court. At such a place, " +
                "you receive free lodging and food of a modest or comfortable " +
                "standard (depending on the quality of the establishment), as " +
                "long as you perform each night. In addition, your performance " +
                "makes you something of a local figure. When strangers recognize " +
                "you in a town where you have performed, they typically take " +
                "a liking to you.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Musical Instrument",
                    Description = "A muscial instrument of your choice.",
                    Price = 100,
                    Weight = 1,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Favor of an Admirer",
                    Description = "A favor of one of your admirers, could be a love letter, lock of hari or a trinket.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Costume",
                    Description = "It's a costume.",
                    Price = 50,
                    Weight = 4,
                    Quantity = 15
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 15
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateFolkHero()
        {
            string backName = "Folk Hero";
            string backDesc = "You come from a humble social rank, but you are " +
                "destined for so much more. Already the people of your home " +
                "village regard you as their champion, and your destiny calls " +
                "you to stand against the tyrants and monsters that threaten " +
                "the common folk everywhere.";

            Skills skillProfs = new Skills();
            skillProfs.AnimalHandling.Profficiency = true;
            skillProfs.Survival.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You gain proficiency with one type " +
                "of artisan's tools and a land vehicle.");
            features.Add("Rustic Hospitality", "Since you come from the ranks of the " +
                "common folk, you fit in among them with ease. You can find a place " +
                "to hide, rest, or recuperate among other commoners, unless you have " +
                "shown yourself to be a danger to them. They will shield you from " +
                "the law or anyone else searching for you, though they will not " +
                "risk their lives for you.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "A set of Artisan's Tools",
                    Description = "You gain a set of artisan's tools of your choice.",
                    Price = 200,
                    Weight = 8,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Shovel",
                    Description = "It's a shovel, it digs stuff.",
                    Price = 20,
                    Weight = 5,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Iron Pot",
                    Description = "It's an iron pot.",
                    Price = 20,
                    Weight = 10,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Common Clothes",
                    Description = "It's a set of common clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 10
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateGuildArtisan()
        {
            string backName = "Guild Artisan";
            string backDesc = "You come from a humble social rank, but " +
                "you are destined for so much more. Already the people " +
                "of your home village regard you as their champion, and " +
                "your destiny calls you to stand against the tyrants and " +
                "monsters that threaten the common folk everywhere.";

            Skills skillProfs = new Skills();
            skillProfs.Insight.Profficiency = true;
            skillProfs.Persuation.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You can select a proficiency with one type of artisan's tools.");
            features.Add("Guild Membership", "As an established and respected member " +
                "of a guild, you can rely on certain benefits that membership " +
                "provides. Your fellow guild members will provide you with " +
                "lodging and food if necessary, and pay for your funeral if " +
                "needed. In some cities and towns, a guildhall offers a " +
                "central place to meet other members of your profession, " +
                "which can be a good place to meet potential patrons, allies, " +
                "or hirelings. Guilds often wield tremendous political " +
                "power. If you are accused of a crime, your guild will support " +
                "you if a good case can be made for your innocence or the crime " +
                "is justifiable. You can also gain access to powerful political " +
                "figures through the guild, if you are a member in good standing. " +
                "Such connections might require the donation of money or magic " +
                "items to the guild's coffers. You must pay dues of 5 gp per month " +
                "to the guild. If you miss payments, you must make up back dues " +
                "to remain in the guild's good graces.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "A set of Artisan's Tools",
                    Description = "You gain a set of artisan's tools of your choice.",
                    Price = 200,
                    Weight = 8,
                    Quantity = 1
                },

                new Item() 
                {
                    Name = "Letter",
                    Description = "A letter of introduction from your guild.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Traveler's Clothes",
                    Description = "It's a set of travelere's clothes.",
                    Price = 20,
                    Weight = 4,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 15
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateHermit()
        {
            string backName = "Hermit";
            string backDesc = "You lived in seclusion – either in a " +
                "sheltered community such as a monastery, or entirely " +
                "alone – for a formative part of your life. In your " +
                "time apart from the clamor of society, you found quiet, " +
                "solitude, and perhaps some of the answers you were looking for.";

            Skills skillProfs = new Skills();
            skillProfs.Medicine.Profficiency = true;
            skillProfs.Religion.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You have proficiency with a herbalism kit.");
            features.Add("Discovery", "The quiet seclusion of your extended hermitage gave " +
                "you access to a unique and powerful discovery. The exact nature of this " +
                "revelation depends on the nature of your seclusion. It might be a great " +
                "truth about the cosmos, the deities, the powerful beings of the outer " +
                "planes, or the forces of nature. It could be a site that no one else has " +
                "ever seen. You might have uncovered a fact that has long been forgotten, " +
                "or unearthed some relic of the past that could rewrite history. It might " +
                "be information that would be damaging to the people who or consigned you " +
                "to exile, and hence the reason for your return to society. Work " +
                "with your DM to determine the details of your discovery and its impact " +
                "on the campaign.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Scroll Case",
                    Description = "It's a scroll case stuffed with notes of your studies and prayers.",
                    Price = 10,
                    Weight = 1,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Winter Blanket",
                    Description = "Big and warm winter blanket.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Common Clothes",
                    Description = "It's a set of common clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Herbalism Kit",
                    Description = "This kit contains variety of instruments that you can use for brewing potions or identifyin and applying herbs.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 5
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateNoble()
        {
            string backName = "Noble";
            string backDesc = "You understand wealth, power, and privilege. " +
                "You carry a noble title, and your family owns land, collects " +
                "taxes, and wields significant political influence. You might " +
                "be a pampered aristocrat unfamiliar with work or discomfort, " +
                "a former merchant just elevated to the nobility, or a " +
                "disinherited scoundrel with a disproportionate sense of " +
                "entitlement. Or you could be an honest, hard-working landowner " +
                "who cares deeply about the people who live and work on your " +
                "land, keenly aware of your responsibility to them. Work with " +
                "your DM to come up with an appropriate title and determine how " +
                "much authority that title carries. A noble title doesn't stand " +
                "on its own-it's connected to an entire family, and whatever title " +
                "you hold, you will pass it down to your own children. Not only " +
                "do you need to determine your noble title, but you should also " +
                "work with the DM to describe your family and their influence on " +
                "you. Is your family old and established, or was your title only " +
                "recently bestowed? How much influence do they wield, and over " +
                "what area? What kind of reputation does your family have among " +
                "the other aristocrats of the region? How do the common people " +
                "regard them? What's your position in the family? Are you the " +
                "heir to the head of the family? Have you already inherited " +
                "the title? How do you feel about that responsibility? Or are " +
                "you so far down the line of inheritance that no one cares what " +
                "you do, as long as you don't embarrass the family? How does " +
                "the head of your family feel about your adventuring career? " +
                "Are you in your family's good graces, or shunned by the rest " +
                "of your family? Does your family have a coat of arms? An " +
                "insignia you might wear on a signet ring? Particular colors you " +
                "wear all the time? An animal you regard as a symbol of your line " +
                "or even a spiritual member of the family? These details help " +
                "establish your family and your title as features of the world " +
                "of the campaign.";

            Skills skillProfs = new Skills();
            skillProfs.History.Profficiency = true;
            skillProfs.Persuation.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You gain proficiency with one type of gaming set.");
            features.Add("Position of Privilege", "Thanks to your noble birth, " +
                "people are inclined to think the best of you. You are welcome " +
                "in high society, and people assume you have the right to be " +
                "wherever you are. The common folk make every effort to " +
                "accommodate you and avoid your displeasure, and other people " +
                "of high birth treat you as a member of the same social sphere. " +
                "You can secure an audience with a local noble if you need to.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Fine Clothes",
                    Description = "It's a set of fine clothes.",
                    Price = 150,
                    Weight = 6,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Signet Ring",
                    Description = "This ring is a symbol of your status, show of nobility.",
                    Price = 50,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Scroll of Pedigree",
                    Description = "Diagram of your family tree.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 25
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateOutlander()
        {
            string backName = "Outlander";
            string backDesc = "You grew up in the wilds, far from civilization " +
                "and the comforts of town and technology. You've witnessed the " +
                "migration of herds larger than forests, survived weather more " +
                "extreme than any city-dweller could comprehend, and enjoyed the " +
                "solitude of being the only thinking creature for miles in any " +
                "direction. The wilds are in your blood, whether you were a" +
                " nomad, an explorer, a recluse, a hunter-gatherer, or even a " +
                "marauder. Even in places where you don't know the specific " +
                "features of the terrain, you know the ways of the wild.";

            Skills skillProfs = new Skills();
            skillProfs.Athletics.Profficiency = true;
            skillProfs.Survival.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", "You gain proficiency with one type of musical instrument.");
            features.Add("Wanderer", "You have an excellent memory for maps and " +
                "geography, and you can always recall the general layout of " +
                "terrain, settlements, and other features around you. In addition, " +
                "you can find food and fresh water for yourself and up to five " +
                "other people each day, provided that the land offers berries, " +
                "small game, water, and so forth.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Staff",
                    Description = "It's a wooden staff.",
                    Price = 2,
                    Weight = 4,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Hunting Trap",
                    Description = "Trap used for hunting animals.",
                    Price = 50,
                    Weight = 25,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Trophy",
                    Description = "A trophy from an animal you have killed.",
                    Price = 20,
                    Weight = 4,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Traveler's Clothes",
                    Description = "It's a set of travelere's clothes.",
                    Price = 20,
                    Weight = 4,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 10
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateSage()
        {
            string backName = "Sage";
            string backDesc = "You spent years learning the lore of the " +
                "multiverse. You scoured manuscripts, studied scrolls, " +
                "and listened to the greatest experts on the subjects that " +
                "interest you. Your efforts have made you a master in your " +
                "fields of study.";

            Skills skillProfs = new Skills();
            skillProfs.Arcana.Profficiency = true;
            skillProfs.History.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Researcher", "When you attempt to learn or recall " +
                "a piece of lore, if you do not know that information, you " +
                "often know where and from whom you can obtain it. Usually, " +
                "this information comes from a library, scriptorium, " +
                "university, or a sage or other learned person or creature." +
                " Your DM might rule that the knowledge you seek is secreted " +
                "away in an almost inaccessible place, or that it simply " +
                "cannot be found. Unearthing the deepest secrets of the " +
                "multiverse can require an adventure or even a whole campaign.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Bottle of Ink",
                    Description = "It's a bottle full of ink.",
                    Price = 100,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Quill",
                    Description = "A quill used for writing on paper.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Small Knife",
                    Description = "It's a small knife, but it's still sharp.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Letter",
                    Description = "A letter from your dead colleague, it poses a " +
                    "question you have not been able to answer, work with your DM " +
                    "to determine what is inside of this letter.",

                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Common Clothes",
                    Description = "It's a set of common clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 10
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateSailor()
        {
            string backName = "Sailor";
            string backDesc = "You sailed on a seagoing vessel for years. " +
                "In that time, you faced down mighty storms, monsters of the " +
                "deep, and those who wanted to sink your craft to the bottomless " +
                "depths. Your first love is the distant line of the horizon, but " +
                "the time has come to try your hand at something new. Discuss the " +
                "nature of the ship you previously sailed with your DM. Was it a " +
                "merchant ship, a naval vessel, a ship of discovery, or a pirate " +
                "ship? How famous (or infamous) is it? Is it widely traveled? Is " +
                "it still sailing, or is it missing and presumed lost with all " +
                "hands? What were your duties on board – boatswain, captain, " +
                "navigator, cook, or some other position? Who were the captain " +
                "and first mate? Did you leave your ship on good terms with " +
                "your fellows, or on the run?";

            Skills skillProfs = new Skills();
            skillProfs.Athletics.Profficiency = true;
            skillProfs.Perception.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", 
                "You gain proficiency with Navigator's tools and water vehicles.");
            features.Add("Ship's Passage", "When you need to, you can secure free " +
                "passage on a sailing ship for yourself and your adventuring companions. " +
                "You might sail on the ship you served on, or another ship you have " +
                "good relations with (perhaps one captained by a former crewmate). " +
                "Because you're calling in a favor, you can't be certain of a " +
                "schedule or route that will meet your every need. Your DM will " +
                "determine how long it takes to get where you need to go. In return " +
                "for your free passage, you and your companions are expected to assist " +
                "the crew during the voyage.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Club",
                    Description = "Wooden club.",
                    Price = 1,
                    Weight = 2,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Silk Rope (50ft)",
                    Description = "50 feet of silk rope.",
                    Price = 100,
                    Weight = 5,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Lucky Charm",
                    Description = "A lucky charm such as a rabbit foot, small stone or a small trinket.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Common Clothes",
                    Description = "It's a set of common clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 10
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateSoldier()
        {
            string backName = "Soldier";
            string backDesc = "War has been your life for as long as you care to " +
                "remember. You trained as a youth, studied the use of weapons and " +
                "armor, learned basic survival techniques, including how to stay " +
                "alive on the battlefield. You might have been part of a standing" +
                " national army or a mercenary company, or perhaps a member of a " +
                "local militia who rose to prominence during a recent war. When " +
                "you choose this background, work with your DM to determine which " +
                "military organization you were a part of, how far through its " +
                "ranks you progressed, and what kind of experiences you had " +
                "during your military career. Was it a standing army, a town " +
                "guard, or a village militia? Or it might have been a noble's " +
                "or merchant's private army, or a mercenary company.";

            Skills skillProfs = new Skills();
            skillProfs.Athletics.Profficiency = true;
            skillProfs.Intimidation.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies", 
                "You gain proficiency with one type of gaming set and land vehicles.");
            features.Add("Military Rank", "You have a military rank from " +
                "your career as a soldier. Soldiers loyal to your former " +
                "military organization still recognize your authority and " +
                "influence, and they defer to you if they are of a lower rank. " +
                "You can invoke your rank to exert influence over other soldiers " +
                "and requisition simple equipment or horses for temporary use. " +
                "You can also usually gain access to friendly military encampments " +
                "and fortresses where your rank is recognized.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Rank Insignia",
                    Description = "Insignia of rank you had back in the army.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Trophy",
                    Description = "A trophy take from a fallen enemy, broken " +
                    "blade, piece of a banner or something else.",

                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Gaming set",
                    Description = "A set of bone dice or a deck of cards.",
                    Price = 5,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Common Clothes",
                    Description = "It's a set of common clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 10
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }

        private void CreateUrchin()
        {
            string backName = "Urchin";
            string backDesc = "You grew up on the streets alone, " +
                "orphaned, and poor, You had no one to watch over " +
                "you or to provide for you, so you learned to provide " +
                "for yourself. You fought fiercely over food and kept " +
                "a constant watch out for other desperate souls who might " +
                "steal from you. You slept on rooftops and in alleyways, " +
                "exposed to the elements, and endured sickness without " +
                "the advantage of medicine or a place to recuperate. " +
                "You've survived despite all odds, and did so through " +
                "cunning, strength, speed, or some combination of each. " +
                "You begin your adventuring career with enough money to " +
                "live modestly but securely for at least ten days. How " +
                "did you come by that money? What allowed you to break " +
                "free of your desperate circumstances and embark on a " +
                "better life?";

            Skills skillProfs = new Skills();
            skillProfs.SleightOfHand.Profficiency = true;
            skillProfs.Stealth.Profficiency = true;

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Tool Proficiencies",
                "You gain proficiency with diguise kit and thieves' tools.");
            features.Add("City Secrets", "You know the secret patterns and flow " +
                "to cities and can find passages through the urban sprawl that " +
                "others would miss. When you are not in combat, you " +
                "(and companions you lead) can travel between any two locations in " +
                "the city twice as fast as your speed would normally allow.");

            List<Item> equipment = new List<Item>()
            {
                new Item()
                {
                    Name = "Small Knife",
                    Description = "It's a small knife, but it's still sharp.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Map",
                    Description = "Map of the city you grew up in.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Pet Mouse",
                    Description = "Your little pet.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Token",
                    Description = "Small token to remember your parents by.",
                    Price = 0,
                    Weight = 0,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Common Clothes",
                    Description = "It's a set of common clothes.",
                    Price = 5,
                    Weight = 3,
                    Quantity = 1
                },

                new Item()
                {
                    Name = "Golden Coins",
                    Description = "Some golden coins in your pouch.",
                    Price = 10,
                    Weight = 0,
                    Quantity = 10
                }
            };

            CreateBackground(backName, backDesc, skillProfs, features, equipment);
        }


        private void CreateBackground(string backName, string backDesc, Skills skillProfs, Dictionary<string, string> features, List<Item> equipment) 
        {
            Background back = new Background();

            back.BackName = backName;
            back.BackDescription = backDesc;
            back.BackSkillProficiencies = skillProfs;
            back.BackFeatures = features;
            back.BackEquipment = equipment;

            _repository.Add(back);
        }
    }
}
