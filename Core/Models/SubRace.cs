using Core.Models.UtilityModels.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class SubRace
    {
        public string SubRaceName { get; set; }

        public string SubRaceDescription { get; set; }

        public AbilityScore SubRaceAbilityScoreBonus { get; set; }

        public Dictionary<string, string> SubRaceFeatures { get; set; }
    }
}
