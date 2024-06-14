using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.UtilityModels.Magic
{
    public class SpellSlot
    {
        public int SlotLevel { get; set; }

        public Spell Spell { get; set; }
    }
}
