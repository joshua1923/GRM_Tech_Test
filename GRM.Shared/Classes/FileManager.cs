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
        public List<Contracts> ReadContractsFromFile(string filePath)
        {
            var path = HttpContext.Current.Server.MapPath(@"~/Files/" + filePath);

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    int lineCount = 0;

                    var contracts = new List<Contracts>();

                    foreach (var line in lines)
                    {
                        var column = line.Split('|');
                        var firstUsage = string.Empty;
                        var secondUsage = string.Empty;
                        var startDate = string.Empty;
                        var endDate = string.Empty;

                        if (column != null)
                        {
                            if (column[2].Contains(','))
                            {
                                var usageSplit = column[2].Split(',');
                                firstUsage = usageSplit[0];
                                secondUsage = usageSplit[1].Trim();

                                //var startDateSplit = column[3].Split(' ');
                                //startDate = $"{startDateSplit[0]} {startDateSplit[1]} {startDateSplit[2]}";

                                //if (!string.IsNullOrEmpty(column[4]))
                                //{
                                //    var endDateSplit = column[4].Split(' ');
                                //    endDate = $"{endDateSplit[0]} {endDateSplit[1]} {endDateSplit[2]}";
                                //}

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

                        lineCount++;
                    }

                    return contracts;
                }
            }

        }

        public List<DistributionPartners> ReadPartnersFromFile(string filePath)
        {
            var path = HttpContext.Current.Server.MapPath(@"~/Files/" + filePath);

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    string[] lines = content.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    int lineCount = 0;

                    var partners = new List<DistributionPartners>();

                    foreach (var line in lines)
                    {
                        var column = line.Split('|');

                        if (column != null)
                        {
                            partners.Add(new DistributionPartners(column[0], column[1]));
                        }

                        lineCount++;
                    }

                    return partners;
                }
            }
        }
    }
}
