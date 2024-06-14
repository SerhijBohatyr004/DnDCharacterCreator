using Core.Models.UtilityModels.Stats;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAbilityScoreService
    {
        public Result<AbilityScore> AbilityScorePointBuy(Result<int> strScoreInput, Result<int> dexScoreInput, Result<int> conScoreInput, Result<int> intScoreInput, Result<int> wisScoreInput, Result<int> chaScoreInput);
    }
}
