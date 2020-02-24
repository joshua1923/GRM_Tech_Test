using GRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRM.Shared.Interfaces
{
    public interface IManager
    {
        IEnumerable<Contracts> ReadContractsFromFile(string filePath);
        IEnumerable<DistributionPartners> ReadPartnersFromFile(string filePath);
    }
}
