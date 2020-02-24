using GRM.Shared.Interfaces;
using GRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GRM.Shared.Classes
{
    public class FileManager : IManager
    {
        public IEnumerable<Contracts> ReadContractsFromFile(string filePath)
        {
            var path = HttpContext.Current.Server.MapPath(@"~/Files/" + filePath);

            using (var fs = new FileStream(path, FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    var content = sr.ReadToEnd();
                    var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    var contracts = new List<Contracts>();

                    foreach (var line in lines)
                    {
                        var column = line.Split('|');

                        if (column[2].Contains(','))
                        {
	                        var usageSplit = column[2].Split(',');
	                        var firstUsage = usageSplit[0];
	                        var secondUsage = usageSplit[1].Trim();

	                        contracts.AddRange(new List<Contracts>
	                        {
		                        new Contracts(column[0], column[1], firstUsage, column[3], column[4]),
		                        new Contracts(column[0], column[1], secondUsage, column[3], column[4])
	                        });
                        }
                        else
                        {
	                        contracts.Add(new Contracts(column[0], column[1], column[2], column[3], column[4]));
                        }
                    }

                    return contracts;
                }
            }

        }

        public IEnumerable<DistributionPartners> ReadPartnersFromFile(string filePath)
        {
            var path = HttpContext.Current.Server.MapPath(@"~/Files/" + filePath);

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var sr = new StreamReader(fs))
                {
                    var content = sr.ReadToEnd();
                    var lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    return lines.Select(line => line.Split('|')).Select(column => new DistributionPartners(column[0], column[1])).ToList();
                }
            }
        }
    }
}
