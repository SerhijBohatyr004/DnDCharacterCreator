using Core.Models;
using Core.Models.CharacterSubClasses;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICharacterSubClassService
    {
        public Result<CharacterSubClass> GetSubClass(string subClassName);
    }
}
