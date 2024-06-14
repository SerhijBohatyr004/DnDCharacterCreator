using Core.Models;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISubRaceService
    {
        public Result<SubRace> GetSubRace(string subRaceName);
        public void CreateAllSubRaces();

    }
}
