using Core.Models;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRaceService
    {
        public void CreateAllRaces();
        public Result<Race> GetRace(string raceName);
    }
}
