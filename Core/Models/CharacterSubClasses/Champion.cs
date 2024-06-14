using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.CharacterSubClasses
{
    public class Champion : CharacterSubClass
    {
        public FightingStyle FightingStyle { get; set; } = Enums.FightingStyle.None;

        public string FightingStyleDesc { get; set; } = "No fighting style.";
    }
}
