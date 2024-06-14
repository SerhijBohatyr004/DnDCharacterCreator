using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Core.Models;
using Core.Models.CharacterSubClasses;
using Core.Models.UtilityModels;

namespace BLL.Services
{
    public class CharacterSubClassService : ICharacterSubClassService
    {
        public Result<CharacterSubClass> GetSubClass(string subClassName)
        {
            switch (subClassName)
            {
                case "Champion":
                    return Result<CharacterSubClass>.Success(CreateChampion());

                case "Battle Master":
                    return Result<CharacterSubClass>.Success(CreateBattleMaster());

                case "Eldritch Knight":
                    return Result<CharacterSubClass>.Success(CreateEldritchKnight());

                case "Berserker":
                    return Result<CharacterSubClass>.Success(CreateBerserker());

                case "Totem Warrior":
                    return Result<CharacterSubClass>.Success(CreateTotemWarrior());

                case "Lore Bard":
                    return Result<CharacterSubClass>.Success(CreateLoreBard());

                case "Valor Bard":
                    return Result<CharacterSubClass>.Success(CreateValorBard());

                case "Knowledge Cleric":
                    return Result<CharacterSubClass>.Success(CreateKnowledgeCleric());

                case "War Cleric":
                    return Result<CharacterSubClass>.Success(CreateWarCleric());

                case "Assasin":
                    return Result<CharacterSubClass>.Success(CreateAssasin());

                case "Thief":
                    return Result<CharacterSubClass>.Success(CreateThief());

                default:
                    return Result<CharacterSubClass>.Failure("Sub class was not found.");
            }
        }

        private Champion CreateChampion()
        {
            string name = "Champion";
            string description = "The archetypal Champion focuses on the development of raw physical " +
                "power honed to deadly perfection. Those who model themselves on this archetype " +
                "combine rigorous training with physical excellence to deal devastating blows.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Improved Critical", "Beginning when you choose this archetype at 3rd level, " +
                "your weapon attacks score a critical hit on a roll of 19 or 20.");

            features.Add("Remarkable Athlete", "Starting at 7th level, you can add half your proficiency" +
                " bonus (rounded up) to any Strength, Dexterity, or Constitution check you make that " +
                "doesn't already use your proficiency bonus. In addition, when you make a running " +
                "long jump, the distance you can cover increases by a number of feet equal to your Strength modifier.");

            features.Add("Additional Fighting Style", "At 10th level, you can choose a second " +
                "option from the Fighting Style class feature.");

            features.Add("Superior Critical", "Starting at 15th level, your weapon attacks score a " +
                "critical hit on a roll of 18-20.");

            features.Add("Survivor", "At 18th level, you attain the pinnacle of resilience in battle. " +
                "At the start of each of your turns, you regain hit points equal to 5 + your Constitution " +
                "modifier if you have no more than half of your hit points left. You don't gain this " +
                "benefit if you have 0 hit points.");

            Champion champion = new Champion();
            champion.SubClassName = name;
            champion.SubClassDescription = description;
            champion.SubClassFeatures = features;

            return champion;
        }

        private BattleMaster CreateBattleMaster()
        {
            string name = "Battle Master";
            string description = "Those who emulate the archetypal Battle Master employ martial " +
                "techniques passed down through generations. To a Battle Master, combat is an " +
                "academic field, sometimes including subjects beyond battle such as weaponsmithing " +
                "and calligraphy. Not every fighter absorbs the lessons of history, theory, and " +
                "artistry that are reflected in the Battle Master archetype, but those who do are " +
                "well-rounded fighters of great skill and knowledge.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Maneuvers", "You learn three maneuvers of your choice. Many maneuvers " +
                "enhance an attack in some way. You can use only one maneuver per attack. You " +
                "learn two additional maneuvers of your choice at 7th, 10th, and 15th level. " +
                "Each time you learn new maneuvers, you can also replace one maneuver you know " +
                "with a different one.");

            features.Add("Superiority Dice", "You have four superiority dice, which are d8s. " +
                "A superiority die is expended when you use it. You regain all of your expended " +
                "superiority dice when you finish a short or long rest. You gain another " +
                "superiority die at 7th level and one more at 15th level.");

            features.Add("Saving Throws", "Some of your maneuvers require your target to make " +
                "a saving throw to resist the maneuver's effects. The saving throw DC is " +
                "calculated as follows: Maneuver save DC = 8 + your proficiency bonus + your " +
                "Strength or Dexterity modifier (your choice)");

            features.Add("Student of War", "At 3rd level, you gain proficiency with one " +
                "type of artisan's tools of your choice.");

            features.Add("Know Your Enemy", "Starting at 7th level, if you spend at least 1 " +
                "minute observing or interacting with another creature outside combat, you can " +
                "learn certain information about its capabilities compared to your own. The DM " +
                "tells you if the creature is your equal, superior, or inferior in regard to " +
                "two of the following characteristics of your choice: Strength score, " +
                "Dexterity score, Constitution score, Armor Class, Current hit points, " +
                "Total class levels, if any, Fighter class levels, if any.");

            features.Add("Improved Combat Superiority", "At 10th level, your superiority " +
                "dice turn into d10s. At 18th level, they turn into d12s.");

            features.Add("Relentless", "Starting at 15th level, when you roll initiative " +
                "and have no superiority dice remaining, you regain 1 superiority die.");

            BattleMaster battleMaster = new BattleMaster();
            battleMaster.SubClassName = name;
            battleMaster.SubClassDescription = description;
            battleMaster.SubClassFeatures = features;
            return battleMaster;
        }

        private EldritchKnight CreateEldritchKnight()
        {
            string name = "Eldritch Knight";
            string description = "The archetypal Eldritch Knight combines the martial mastery " +
                "common to all fighters with a careful study of magic. Eldritch Knights use " +
                "magical techniques similar to those practiced by wizards. They focus their " +
                "study on two of the eight schools of magic: abjuration and evocation. " +
                "Abjuration spells grant an Eldritch Knight additional protection in battle, " +
                "and evocation spells deal damage to many foes at once, extending the " +
                "fighter's reach in combat. These knights learn a comparatively small " +
                "number of spells, committing them to memory instead of keeping them " +
                "in a spellbook.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Spellcasting", "When you reach 3rd level, you augment your " +
                "martial prowess with the ability to cast spells.");

            features.Add("Cantrips", "You learn two cantrips of your choice from the " +
                "wizard spell list. You learn an additional wizard cantrip of your " +
                "choice at 10th level.");

            features.Add("Spells Known of 1st Level and Higher", "You know three " +
                "1st-level wizard spells of your choice, two of which you must choose " +
                "from the abjuration and evocation spells on the wizard spell list. " +
                "The spells you learn at 8th, 14th, and 20th level can come from any " +
                "school of magic. Whenever you gain a level in this class, you can " +
                "replace one of the wizard spells you know with another spell of your " +
                "choice from the wizard spell list. The new spell must be of a level " +
                "for which you have spell slots, and it must be an abjuration or " +
                "evocation spell, unless you're replacing the spell you gained at " +
                "3rd, 8th, 14th, or 20th level from any school of magic.");

            features.Add("Spellcasting Ability", "Intelligence is your spellcasting " +
                "ability for your wizard spells, since you learn your spells through " +
                "study and memorization. You use your Intelligence whenever a spell " +
                "refers to your spellcasting ability. In addition, you use your " +
                "Intelligence modifier when setting the saving throw DC for a wizard " +
                "spell you cast and when making an attack roll with one. " +
                "Spell save DC = 8 + your proficiency bonus + your Intelligence modifier. " +
                "Spell attack modifier = your proficiency bonus + your Intelligence modifier.");

            features.Add("Weapon Bond", "At 3rd level, you learn a ritual that creates" +
                " a magical bond between yourself and one weapon. You perform the ritual " +
                "over the course of 1 hour, which can be done during a short rest. " +
                "The weapon must be within your reach throughout the ritual, at the " +
                "conclusion of which you touch the weapon and forge the bond. Once you " +
                "have bonded a weapon to yourself, you can't be disarmed of that weapon " +
                "unless you are incapacitated. If it is on the same plane of existence, " +
                "you can summon that weapon as a bonus action on your turn, causing it " +
                "to teleport instantly to your hand. You can have up to two bonded " +
                "weapons, but can summon only one at a time with your bonus action. " +
                "If you attempt to bond with a third weapon, you must break the bond " +
                "with one of the other two.");

            features.Add("War Magic", "Beginning at 7th level, when you use your action " +
                "to cast a cantrip, you can make one weapon attack as a bonus action.");

            features.Add("Eldritch Strike", "At 10th level, you learn how to make your " +
                "weapon strikes undercut a creature's resistance to your spells. When you " +
                "hit a creature with a weapon attack, that creature has disadvantage on the " +
                "next saving throw it makes against a spell you cast before the end of " +
                "your next turn.");

            features.Add("Arcane Charge", "At 15th level, you gain the ability to teleport " +
                "up to 30 feet to an unoccupied space you can see when you use your Action " +
                "Surge. You can teleport before or after the additional action.");

            features.Add("Improved War Magic", "Starting at 18th level, when you use your " +
                "action to cast a spell, you can make one weapon attack as a bonus action.");

            EldritchKnight eldritchKnight = new EldritchKnight();
            eldritchKnight.SubClassName = name;
            eldritchKnight.SubClassDescription = description;
            eldritchKnight.SubClassFeatures = features;
            return eldritchKnight;
        }

        private Berserker CreateBerserker()
        {
            string name = "Berserker";
            string description = "For some barbarians, rage is a means to an end – that " +
                "end being violence. The Path of the Berserker is a path of untrammeled " +
                "fury, slick with blood. As you enter the berserker's rage, you thrill " +
                "in the chaos of battle, heedless of your own health or well-being.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Frenzy", "Starting when you choose this path at 3rd level, you " +
                "can go into a frenzy when you rage. If you do so, for the duration of " +
                "your rage you can make a single melee weapon attack as a bonus action " +
                "on each of your turns after this one. When your rage ends, you suffer " +
                "one level of exhaustion.");

            features.Add("Mindless Rage", "Beginning at 6th level, you can't be charmed " +
                "or frightened while raging. If you are charmed or frightened when you " +
                "enter your rage, the effect is suspended for the duration of the rage.");

            features.Add("Intimidating Presence", "Beginning at 10th level, you can use " +
                "your action to frighten someone with your menacing presence. When you do " +
                "so, choose one creature that you can see within 30 feet of you. If the " +
                "creature can see or hear you, it must succeed on a Wisdom saving throw " +
                "(DC equal to 8 + your proficiency bonus + your Charisma modifier) or " +
                "be frightened of you until the end of your next turn. On subsequent " +
                "turns, you can use your action to extend the duration of this effect " +
                "on the frightened creature until the end of your next turn. This effect " +
                "ends if the creature ends its turn out of line of sight or more than " +
                "60 feet away from you. If the creature succeeds on its saving throw, " +
                "you can't use this feature on that creature again for 24 hours.");

            features.Add("Retaliation", "Starting at 14th level, when you take damage " +
                "from a creature that is within 5 feet of you, you can use your " +
                "reaction to make a melee weapon attack against that creature.");

            Berserker berserker = new Berserker();
            berserker.SubClassName = name;
            berserker.SubClassDescription = description;
            berserker.SubClassFeatures = features;
            return berserker;
        }

        private TotemWarrior CreateTotemWarrior()
        {
            string name = "Totem Warrior";
            string description = "The Path of the Totem Warrior is a spiritual journey, as " +
                "the barbarian accepts a spirit animal as guide, protector, and inspiration. " +
                "In battle, your totem spirit fills you with supernatural might, adding " +
                "magical fuel to your barbarian rage. Most barbarian tribes consider a " +
                "totem animal to be kin to a particular clan. In such cases, it is " +
                "unusual for an individual to have more than one totem animal spirit, " +
                "though exceptions exist.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Spirit Seeker", "Yours is a path that seeks attunement with the " +
                "natural world, giving you a kinship with beasts. At 3rd level when you " +
                "adopt this path, you gain the ability to cast the Beast Sense and Speak " +
                "with Animals spells, but only as rituals.");

            features.Add("Totem Spirit", "At 3rd level, when you adopt this path, you " +
                "choose a totem spirit and gain its feature. You must make or acquire " +
                "a physical totem object – an amulet or similar adornment – that " +
                "incorporates fur or feathers, claws, teeth, or bones of the totem " +
                "animal. At your option, you also gain minor physical attributes that " +
                "are reminiscent of your totem spirit. For example, if you have a bear " +
                "totem spirit, you might be unusually hairy and thick-skinned, or if " +
                "your totem is the eagle, your eyes turn bright yellow. Bear, while " +
                "raging, you have resistance to all damage except psychic damage. " +
                "The spirit of the bear makes you tough enough to stand up to any " +
                "punishment. Eagle, while you're raging and aren't wearing heavy " +
                "armor, other creatures have disadvantage on opportunity attack " +
                "rolls against you, and you can use the Dash action as a bonus " +
                "action on your turn. The spirit of the eagle makes you into a " +
                "predator who can weave through the fray with ease. Elk, while " +
                "you're raging and aren't wearing heavy armor, your walking speed " +
                "increases by 15 feet. The spirit of the elk makes you " +
                "extraordinarily swift. Tiger, while raging, you can add 10 feet " +
                "to your long jump distance and 3 feet to your high jump distance. " +
                "The spirit of the tiger empowers your leaps. Wolf, while you're " +
                "raging, your friends have advantage on melee attack rolls " +
                "against any creature within 5 feet of you that is hostile to " +
                "you. The spirit of the wolf makes you a leader of hunters.");

            features.Add("Aspect of the Beast", "At 6th level, you gain a magical " +
                "benefit based on the totem animal of your choice. You can choose " +
                "the same animal you selected at 3rd level or a different one. Bear, " +
                "you gain the might of a bear. Your carrying capacity (including " +
                "maximum load and maximum lift) is doubled, and you have advantage " +
                "on Strength checks made to push, pull, lift, or break objects. " +
                "Eagle, you gain the eyesight of an eagle. You can see up to 1 " +
                "mile away with no difficulty, able to discern even fine details " +
                "as though looking at something no more than 100 feet away " +
                "from you. Additionally, dim light doesn't impose disadvantage " +
                "on your Wisdom (Perception) checks. Elk, whether mounted or on " +
                "foot, your travel pace is doubled, as is the travel pace of up " +
                "to ten companions while they're within 60 feet of you and you're " +
                "not incapacitated. The elk spirit helps you roam far and fast. " +
                "Tiger, you gain proficiency in two skills from the following " +
                "list: Athletics, Acrobatics, Stealth, and Survival. The cat " +
                "spirit hones your survival instincts. Wolf, you gain the " +
                "hunting sensibilities of a wolf. You can track other creatures " +
                "while traveling at a fast pace, and you can move stealthily " +
                "while traveling at a normal pace.");

            features.Add("Spirit Walker", "At 10th level, you can cast the Commune " +
                "with Nature spell, but only as a ritual. When you do so, a " +
                "spiritual version of one of the animals you chose for Totem " +
                "Spirit or Aspect of the Beast appears to you to convey the " +
                "information you seek.");

            features.Add("Totemic Attunement", "At 14th level, you gain a magical " +
                "benefit based on a totem animal of your choice. You can choose " +
                "the same animal you selected previously or a different one. Bear, " +
                "while you're raging, any creature within 5 feet of you that's " +
                "hostile to you has disadvantage on attack rolls against targets " +
                "other than you or another character with this feature. An enemy " +
                "is immune to this effect if it can't see or hear you or if it " +
                "can't be frightened. Eagle, while raging, you have a flying " +
                "speed equal to your current walking speed. This benefit works " +
                "only in short bursts; you fall if you end your turn in the air " +
                "and nothing else is holding you aloft. Elk, while raging, you " +
                "can use a bonus action during your move to pass through the " +
                "space of a Large or smaller creature. That creature must " +
                "succeed on a Strength saving throw (DC 8 + your Strength " +
                "bonus + your proficiency bonus) or be knocked prone and " +
                "take bludgeoning damage equal to 1d12 + your Strength " +
                "modifier. Tiger, while you're raging, if you move at " +
                "least 20 feet in a straight line toward a Large or smaller " +
                "target right before making a melee weapon attack against " +
                "it, you can use a bonus action to make an additional melee " +
                "weapon attack against it. Wolf, while you're raging, you " +
                "can use a bonus action on your turn to knock a Large or " +
                "smaller creature prone when you hit it with melee weapon attack.");

            TotemWarrior totemWarrior = new TotemWarrior();
            totemWarrior.SubClassName = name;
            totemWarrior.SubClassDescription = description;
            totemWarrior.SubClassFeatures = features;
            return totemWarrior;
        }

        private LoreBard CreateLoreBard()
        {
            string name = "Lore Bard";
            string description = "Bards of the College of Lore know something about " +
                "most things, collecting bits of knowledge from sources as diverse " +
                "as scholarly tomes and peasant tales. Whether singing folk ballads " +
                "in taverns or elaborate compositions in royal courts, these bards " +
                "use their gifts to hold audiences spellbound. When the applause dies " +
                "down, the audience members might find themselves questioning " +
                "everything they held to be true, from their faith in the priesthood " +
                "of the local temple to their loyalty to the king. The loyalty of " +
                "these bards lies in the pursuit of beauty and truth, not in fealty " +
                "to a monarch or following the tenets of a deity. A noble who keeps " +
                "such a bard as a herald or advisor knows that the bard would rather " +
                "be honest than politic. The college's members gather in libraries " +
                "and sometimes in actual colleges, complete with classrooms and " +
                "dormitories, to share their lore with one another. They also meet " +
                "at festivals or affairs of state, where they can expose corruption, " +
                "unravel lies, and poke fun at self-important figures of authority.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Bonus Proficiencies", "When you join the College of " +
                "Lore at 3rd level, you gain proficiency with three skills of " +
                "your choice.");

            features.Add("Cutting Words", "Also at 3rd level, you learn how " +
                "to use your wit to distract, confuse, and otherwise sap the " +
                "confidence and competence of others. When a creature that you " +
                "can see within 60 feet of you makes an attack roll, an ability " +
                "check, or a damage roll, you can use your reaction to expend one " +
                "of your uses of Bardic Inspiration, rolling a Bardic Inspiration " +
                "die and subtracting the number rolled from the creature's roll. " +
                "You can choose to use this feature after the creature makes its " +
                "roll, but before the DM determines whether the attack roll or " +
                "ability check succeeds or fails, or before the creature deals " +
                "its damage. The creature is immune if it can't hear you or if " +
                "it's immune to being charmed.");

            features.Add("Additional Magical Secrets", "At 6th level, you learn " +
                "two spells of your choice from any class. A spell you choose must " +
                "be of a level you can cast, as shown on the Bard table, or a " +
                "cantrip. The chosen spells count as bard spells for you but don't " +
                "count against the number of bard spells you know.");

            features.Add("Peerless Skill", "Starting at 14th level, when you make " +
                "an ability check, you can expend one use of Bardic Inspiration. " +
                "Roll a Bardic Inspiration die and add the number rolled to your " +
                "ability check. You can choose to do so after you roll the die for " +
                "the ability check, but before the DM tells you whether you succeed " +
                "or fail.");

            LoreBard loreBard = new LoreBard();
            loreBard.SubClassName = name;
            loreBard.SubClassDescription = description;
            loreBard.SubClassFeatures = features;
            return loreBard;
        }

        private ValorBard CreateValorBard()
        {
            string name = "Valor Bard";
            string description = "Bards of the College of Valor are daring skalds whose " +
                "tales keep alive the memory of the great heroes of the past, and thereby " +
                "inspire a new generation of heroes. These bards gather in mead halls or " +
                "around great bonfires to sing the deeds of the mighty, both past and " +
                "present. They travel the land to witness great events firsthand and to " +
                "ensure that the memory of those events doesn't pass from the world. With " +
                "their songs, they inspire others to reach the same heights of " +
                "accomplishment as the heroes of old.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Bonus Proficiencies", "When you join the College of Valor at " +
                "3rd level, you gain proficiency with medium armor, shields, and martial " +
                "weapons.");
            
            features.Add("Combat Inspiration", "Also at 3rd level, you learn to inspire " +
                "others in battle. A creature that has a Bardic Inspiration die from you " +
                "can roll that die and add the number rolled to a weapon damage roll it " +
                "just made. Alternatively, when an attack roll is made against the " +
                "creature, it can use its reaction to roll the Bardic Inspiration die " +
                "and add the number rolled to its AC against that attack, after seeing " +
                "the roll but before knowing whether it hits or misses.");
            
            features.Add("Valor Extra Attack", "Starting at 6th level, you can attack " +
                "twice, instead of once, whenever you take the Attack action on your turn.");
           
            features.Add("Battle Magic", "At 14th level, you have mastered the art " +
                "of weaving spellcasting and weapon use into a single harmonious " +
                "act. When you use your action to cast a bard spell, you can make " +
                "one weapon attack as a bonus action.");

            ValorBard valorBard = new ValorBard();
            valorBard.SubClassName = name;
            valorBard.SubClassDescription = description;
            valorBard.SubClassFeatures = features;
            return valorBard;
        }

        private KnowledgeCleric CreateKnowledgeCleric()
        {
            string name = "Knowledge Cleric";
            string description = "The gods of knowledge – including Oghma, Boccob, Gilean, " +
                "Aureon, and Thoth – value learning and understanding above all. Some teach" +
                " that knowledge is to be gathered and shared in libraries and universities," +
                " or promote the practical knowledge of craft and invention. Some deities " +
                "hoard knowledge and keep its secrets to themselves. And some promise their " +
                "followers that they will gain tremendous power if they unlock the secrets" +
                " of the multiverse. Followers of these gods study esoteric lore, collect" +
                " old tomes, delve into the secret places of the earth, and learn all they " +
                "can. Some gods of knowledge promote the practical knowledge of craft and" +
                " invention, including smith deities like Gond, Reorx, Onatar, Moradin," +
                " Hephaestus, and Goibhniu. In Amonkhet, knowledge is the second virtue of " +
                "society. Kefnet’s task is to pass on this teaching of the God-Pharaoh and" +
                " elucidate its meaning. He teaches that the afterlife will be inhabited " +
                "only by those who have proved by their wits that they are worthy of dwelling " +
                "in the glorious presence of the God-Pharaoh. He trains acolytes and initiates" +
                " to push their limits and challenge their mental capacity with spells of" +
                " ever-greater power.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Blessings of Knowledge", "At 1st level, you learn two languages" +
                " of your choice. You also become proficient in your choice of two of the" +
                " following skills: Arcana, History, Nature, or Religion. Your proficiency" +
                " bonus is doubled for any ability check you make that uses either of those" +
                " skills.");

            features.Add("Channel Divinity: Knowledge of the Ages", "Starting at 2nd level, " +
                "you can use your Channel Divinity to tap into a divine well of knowledge." +
                " As an action, you choose one skill or tool. For 10 minutes, you have " +
                "proficiency with the chosen skill or tool.");

            features.Add("Channel Divinity: Read Thoughts", "At 6th level, you can use " +
                "your Channel Divinity to read a creature's thoughts. You can then use " +
                "your access to the creature's mind to command it. As an action, choose " +
                "one creature that you can see within 60 feet of you. That creature must " +
                "make a Wisdom saving throw. If the creature succeeds on the saving throw," +
                " you can't use this feature on it again until you finish a long rest. " +
                "If the creature fails its save, you can read its surface thoughts (those " +
                "foremost in its mind, reflecting its current emotions and what it is" +
                " actively thinking about) when it is within 60 feet of you. This " +
                "effect lasts for 1 minute. During that time, you can use your action" +
                " to end this effect and cast the Suggestion spell on the creature " +
                "without expending a spell slot. The target automatically fails its" +
                " saving throw against the spell.");

            features.Add("Potent Spellcasting", "Starting at 8th level, you add your " +
                "Wisdom modifier to the damage you deal with any cleric cantrip.");

            features.Add("Visions of the Past", "Starting at 17th level, you can call" +
                " up visions of the past that relate to an object you hold or your " +
                "immediate surroundings. You spend at least 1 minute in meditation and " +
                "prayer, then receive dreamlike, shadowy glimpses of recent events. You" +
                " can meditate in this way for a number of minutes equal to your Wisdom" +
                " score and must maintain concentration during that time, as if you were " +
                "casting a spell. Once you use this feature, you can't use it again until" +
                " you finish a short or long rest.");

            features.Add("Object Reading", "Holding an object as you meditate, you can see " +
                "visions of the object's previous owner. After meditating for 1 minute, you " +
                "learn how the owner acquired and lost the object, as well as the most recent" +
                " significant event involving the object and that owner. If the object was " +
                "owned by another creature in the recent past (within a number of days equal " +
                "to your Wisdom score), you can spend 1 additional minute for each owner to " +
                "learn the same information about that creature.");

            features.Add("Area Reading", "As you meditate, you see visions of recent events " +
                "in your immediate vicinity (a room, street, tunnel, clearing, or the like, " +
                "up to a 50-foot cube), going back a number of days equal to your Wisdom " +
                "score. For each minute you meditate, you learn about one significant event," +
                " beginning with the most recent. Significant events typically involve " +
                "powerful emotions, such as battles and betrayals, marriages and murders, " +
                "births and funerals. However, they might also include more mundane events " +
                "that are nevertheless important in your current situation.");

            KnowledgeCleric knowledgeCleric = new KnowledgeCleric();
            knowledgeCleric.SubClassName = name;
            knowledgeCleric.SubClassDescription = description;
            knowledgeCleric.SubClassFeatures = features;
            return knowledgeCleric;
        }

        private WarCleric CreateWarCleric()
        {
            string name = "War Cleric";
            string description = "War has many manifestations. It can make heroes of ordinary" +
                " people. It can be desperate and horrific, with acts of cruelty and cowardice " +
                "eclipsing instances of excellence and courage. In either case, the gods of" +
                " war watch over warriors and reward them for their great deeds. The clerics" +
                " of such gods excel in battle, inspiring others to fight the good fight " +
                "or offering acts of violence as prayers. Gods of war include champions of" +
                " honor and chivalry (such as Torm, Heironeous, and Kiri-Jolith) as well" +
                " as gods of destruction and pillage (such as Erythnul, the Fury, Gruumsh," +
                " and Ares) and gods of conquest and domination (such as Bane, Hextor, and " +
                "Maglubiyet). Other war gods (such as Tempus, Nike, and Nuada) take a more" +
                " neutral stance, promoting war in all its manifestations and supporting " +
                "warriors in any circumstance.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Class Bonus Proficiency", "At 1st level, you gain " +
                "proficiency with martial weapons and heavy armor");

            features.Add("War Priest", "From 1st level, your god delivers bolts" +
                " of inspiration to you while you are engaged in battle. When you " +
                "use the Attack action, you can make one weapon attack as a bonus" +
                " action. You can use this feature a number of times equal to your" +
                " Wisdom modifier (a minimum of once). You regain all expended " +
                "uses when you finish a long rest.");

            features.Add("Channel Divinity: Guided Strike", "Starting at 2nd level," +
                " you can use your Channel Divinity to strike with supernatural" +
                " accuracy. When you make an attack roll, you can use your Channel " +
                "Divinity to gain a +10 bonus to the roll. You make this choice " +
                "after you see the roll, but before the DM says whether the attack" +
                " hits or misses.");

            features.Add("Channel Divinity: War God's Blessing", "At 6th level," +
                " when a creature within 30 feet of you makes an attack roll, you " +
                "can use your reaction to grant that creature a +10 bonus to the roll," +
                " using your Channel Divinity. You make this choice after you see the " +
                "roll, but before the DM says whether the attack hits or misses.");

            features.Add("Divine Strike", "At 8th level, you gain the ability to" +
                " infuse your weapon strikes with divine energy. Once on each of" +
                " your turns when you hit a creature with a weapon attack, you can" +
                " cause the attack to deal an extra 1d8 damage of the same type" +
                " dealt by the weapon to the target. When you reach 14th level, " +
                "the extra damage increases to 2d8.");

            features.Add("Avatar of Battle", "At 17th level, you gain resistance " +
                "to bludgeoning, piercing, and slashing damage from nonmagical" +
                " attacks.");

            WarCleric warCleric = new WarCleric();
            warCleric.SubClassName = name;
            warCleric.SubClassDescription = description;
            warCleric.SubClassFeatures = features;
            return warCleric;
        }

        private Assasin CreateAssasin()
        {
            string name = "Assasin";
            string description = "You focus your training on the grim art of death." +
                " Those who adhere to this archetype are diverse: hired killers, spies, " +
                "bounty hunters, and even specially anointed priests trained to exterminate" +
                " the enemies of their deity. Stealth, poison, and disguise help you " +
                "eliminate your foes with deadly efficiency.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Sub-Class Bonus Proficiency", "When you choose this archetype " +
                "at 3rd level, you gain proficiency with the disguise kit and the poisoner's kit.");

            features.Add("Assassinate", "Starting at 3rd level, you are at your deadliest" +
                " when you get the drop on your enemies. You have advantage on attack " +
                "rolls against any creature that hasn't taken a turn in the combat yet." +
                " In addition, any hit you score against a creature that is surprised is " +
                "a critical hit.");

            features.Add("Infiltration Expertise", "Starting at 9th level, you can " +
                "unfailingly create false identities for yourself. You must spend seven" +
                " days and 25 gp to establish the history, profession, and affiliations " +
                "for an identity. You can't establish an identity that belongs to someone" +
                " else. For example, you might acquire appropriate clothing, letters of" +
                " introduction, and official- looking certification to establish yourself" +
                " as a member of a trading house from a remote city so you can insinuate " +
                "yourself into the company of other wealthy merchants. Thereafter, if you " +
                "adopt the new identity as a disguise, other creatures believe you to be " +
                "that person until given an obvious reason not to.");

            features.Add("Impostor", "At 13th level, you gain the ability to unerringly " +
                "mimic another person's speech, writing, and behavior. You must spend at" +
                " least three hours studying these three components of the person's " +
                "behavior, listening to speech, examining handwriting, and observing " +
                "mannerisms. Your ruse is indiscernible to the casual observer. If a wary " +
                "creature suspects something is amiss, you have advantage on any Charisma" +
                " (Deception) check you make to avoid detection.");

            features.Add("Death Strike", "Starting at 17th level, you become a master of" +
                " instant death. When you attack and hit a creature that is surprised, it" +
                " must make a Constitution saving throw (DC 8 + your Dexterity modifier +" +
                " your proficiency bonus). On a failed save, double the damage of your" +
                " attack against the creature.");
            
            Assasin assasin = new Assasin();
            assasin.SubClassName = name;
            assasin.SubClassDescription = description;
            assasin.SubClassFeatures = features;
            return assasin;
        }

        private Thief CreateThief()
        {
            string name = "Thief";
            string description = "You hone your skills in the larcenous arts. Burglars," +
                " bandits, cutpurses, and other criminals typically follow this archetype," +
                " but so do rogues who prefer to think of themselves as professional " +
                "treasure seekers, explorers, delvers, and investigators. In addition to " +
                "improving your agility and stealth, you learn skills useful for delving" +
                " into ancient ruins, reading unfamiliar languages, and using magic items" +
                " you normally couldn't employ.";

            Dictionary<string, string> features = new Dictionary<string, string>();
            features.Add("Fast Hands", "Starting at 3rd level, you can use the bonus action " +
                "granted by your Cunning Action to make a Dexterity (Sleight of Hand) check," +
                " use your thieves' tools to disarm a trap or open a lock, or take the Use an" +
                " Object action.");

            features.Add("Second-Story Work", "When you choose this archetype at 3rd level," +
                " you gain the ability to climb faster than normal; climbing no longer costs" +
                " you extra movement. In addition, when you make a running jump, the distance" +
                " you cover increases by a number of feet equal to your Dexterity modifier.");

            features.Add("Supreme Sneak", "Starting at 9th level, you have advantage on a " +
                "Dexterity (Stealth) check if you move no more than half your speed on the" +
                " same turn.");

            features.Add("Use Magic Device", "By 13th level, you have learned enough about" +
                " the workings of magic that you can improvise the use of items even when" +
                " they are not intended for you. You ignore all class, race, and level " +
                "requirements on the use of magic items.");

            features.Add("Thief's Reflexes", "When you reach 17th level, you have become " +
                "adept at laying ambushes and quickly escaping danger. You can take two " +
                "turns during the first round of any combat. You take your first turn at " +
                "your normal initiative and your second turn at your initiative minus 10. " +
                "You can't use this feature when you are surprised.");

            Thief thief = new Thief();
            thief.SubClassName = name;
            thief.SubClassDescription = description;
            thief.SubClassFeatures = features;
            return thief;
        }
    }
}
