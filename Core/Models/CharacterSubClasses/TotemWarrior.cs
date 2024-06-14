using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.CharacterSubClasses
{
    public class TotemWarrior : CharacterSubClass
    {
        public string TotemSpirit { get; set; } = "Bear";

        public string? AspectOfTheBeast { get; set; }

        public string? TotemicAttunement { get; set; }
    }
}
