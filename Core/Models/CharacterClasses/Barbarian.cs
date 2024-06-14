using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.CharacterClasses
{
    public class Barbarian : CharacterClass
    {
        public int RageCharges { get; set; } = 2;

        public int RageDamage { get; set; } = 2;
    }
}
