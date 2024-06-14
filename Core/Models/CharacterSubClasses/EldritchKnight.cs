using Core.Models.UtilityModels.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.CharacterSubClasses
{
    public class EldritchKnight : CharacterSubClass
    {
        public List<Spell> Spells { get; set; } = new List<Spell>();

        public List<SpellSlot> SpellSlots { get; set; } = new List<SpellSlot>();
    }
}
