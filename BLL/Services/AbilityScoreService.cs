using BLL.Interfaces;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AbilityScoreService : IAbilityScoreService
    {
        public Result<AbilityScore> AbilityScorePointBuy(Result<int> strScoreInput, Result<int> dexScoreInput, Result<int> conScoreInput, Result<int> intScoreInput, Result<int> wisScoreInput, Result<int> chaScoreInput)
        {
            AbilityScore abilityScore = new AbilityScore();
            int points = 27;

            if (strScoreInput.IsSuccess)
            {
                int strScore = strScoreInput.Data;

                Result<(int, int)> strPriceValidation = GetAbilityScorePointBuyPrice(points, strScore);
                if (strPriceValidation.IsSuccess)
                {
                    abilityScore.Strength = strPriceValidation.Data.Item2;
                    points = strPriceValidation.Data.Item1;
                }
                else
                {
                    return Result<AbilityScore>.Failure(strPriceValidation.ErrorMessage);
                }
            }
            else
            {
                return Result<AbilityScore>.Failure(strScoreInput.ErrorMessage);
            }

            if (dexScoreInput.IsSuccess)
            {
                int dexScore = dexScoreInput.Data;
                Result<(int, int)> dexPriceValidation = GetAbilityScorePointBuyPrice(points, dexScore);
                if (dexPriceValidation.IsSuccess)
                {
                    abilityScore.Dexterity = dexPriceValidation.Data.Item2;
                    points = dexPriceValidation.Data.Item1;
                }
                else
                {
                    return Result<AbilityScore>.Failure(dexPriceValidation.ErrorMessage);
                }
            }
            else
            {
                return Result<AbilityScore>.Failure(dexScoreInput.ErrorMessage);
            }

            if (conScoreInput.IsSuccess)
            {
                int conScore = conScoreInput.Data;
                Result<(int, int)> conPriceValidation = GetAbilityScorePointBuyPrice(points, conScore);
                if (conPriceValidation.IsSuccess)
                {
                    abilityScore.Constitution = conPriceValidation.Data.Item2;
                    points = conPriceValidation.Data.Item1;
                }
                else
                {
                    return Result<AbilityScore>.Failure(conPriceValidation.ErrorMessage);
                }
            }
            else
            {
                return Result<AbilityScore>.Failure(conScoreInput.ErrorMessage);
            }

            if (intScoreInput.IsSuccess)
            {
                int intScore = intScoreInput.Data;
                Result<(int, int)> intPriceValidation = GetAbilityScorePointBuyPrice(points, intScore);
                if (intPriceValidation.IsSuccess)
                {
                    abilityScore.Intelligence = intPriceValidation.Data.Item2;
                    points = intPriceValidation.Data.Item1;
                }
                else
                {
                    return Result<AbilityScore>.Failure(intPriceValidation.ErrorMessage);
                }
            }
            else
            {
                return Result<AbilityScore>.Failure(intScoreInput.ErrorMessage);
            }

            if (wisScoreInput.IsSuccess)
            {
                int wisScore = wisScoreInput.Data;
                Result<(int, int)> wisPriceValidation = GetAbilityScorePointBuyPrice(points, wisScore);
                if (wisPriceValidation.IsSuccess)
                {
                    abilityScore.Wisdom = wisPriceValidation.Data.Item2;
                    points = wisPriceValidation.Data.Item1;
                }
                else
                {
                    return Result<AbilityScore>.Failure(wisPriceValidation.ErrorMessage);
                }
            }
            else
            {
                return Result<AbilityScore>.Failure(wisScoreInput.ErrorMessage);
            }

            if (chaScoreInput.IsSuccess)
            {
                int chaScore = chaScoreInput.Data;
                Result<(int, int)> chaPriceValidation = GetAbilityScorePointBuyPrice(points, chaScore);
                if (chaPriceValidation.IsSuccess)
                {
                    abilityScore.Charisma = chaPriceValidation.Data.Item2;
                    points = chaPriceValidation.Data.Item1;
                }
                else
                {
                    return Result<AbilityScore>.Failure(chaPriceValidation.ErrorMessage);
                }
            }
            else
            {
                return Result<AbilityScore>.Failure(chaScoreInput.ErrorMessage);
            }

            return Result<AbilityScore>.Success(abilityScore);
        }

        private Result<(int, int)> GetAbilityScorePointBuyPrice(int points, int statScore)
        {
            if (statScore < 8)
            {
                statScore = 8;
            }

            if (statScore > 15)
            {
                statScore = 15;
            }

            int statScorePrice = 0;

            if (statScore > 8 && statScore < 14)
            {
                statScorePrice = statScore - 8;
            }

            if (statScore == 14)
            {
                statScorePrice = 7;
            }

            if (statScore == 15)
            {
                statScorePrice = 9;
            }

            if (statScorePrice <= points)
            {
                return Result<(int, int)>.Success((points - statScorePrice, statScore));
            }

            else
            {
                return Result<(int, int)>.Failure("Error, not enough points left to asign that value to your ability score.");
            }
        }
    }
}
