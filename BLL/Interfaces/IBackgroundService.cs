using Core.Models;
using Core.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBackgroundService
    {
        public Result<Background> GetBackground(string backname);

        public void CreateAllBackgrounds();

    }
}
