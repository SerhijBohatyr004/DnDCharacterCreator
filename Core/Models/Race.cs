using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Models.UtilityModels.Stats;

namespace Core.Models
{
    public class Race
    {
        public string RaceName { get; set; }

        public string RaceDescription { get; set; }

        public CreatureSize RaceSize { get; set; }

        public int RaceSpeed { get; set; }

        public AbilityScore RaceAbilityScoreBonus { get; set; }

        public Dictionary<string, string> RaceFeatures { get; set; }

        public List<string> SubRaces { get; set; }
    }
}
