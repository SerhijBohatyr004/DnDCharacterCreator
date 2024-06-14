using Core.Models;
using Core.Models.CharacterClasses;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICharacterClassService
    {
        public Fighter CreateFighter();

        public Barbarian CreateBarbarian();

        public Bard CreateBard();

        public Cleric CreateCleric();

        public Rogue CreateRogue();

        public Result<bool> FinishFighter(Fighter fighter, string fightingStyle);
    }
}
