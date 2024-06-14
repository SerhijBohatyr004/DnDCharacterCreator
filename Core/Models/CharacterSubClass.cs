using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class CharacterSubClass
    {
        public string SubClassName { get; set; }

        public string SubClassDescription { get; set; }

        public Dictionary<string, string> SubClassFeatures { get; set; }
    }
}
