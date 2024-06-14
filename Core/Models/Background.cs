using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.UtilityModels;
using Core.Models.UtilityModels.Stats;

namespace Core.Models
{
    public class Background
    {
        public string BackName { get; set; }

        public string BackDescription { get; set; }

        public Skills BackSkillProficiencies { get; set; }

        public Dictionary<string, string> BackFeatures { get; set; }

        public List<Item> BackEquipment { get; set; }
    }
}
