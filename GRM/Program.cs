using ConsoleTables;
using GRM.Shared.DataLayer;
using GRM.Shared.Models;
using System;
using System.Data.Entity;

namespace GRM
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePathContracts = @"contracts.txt";
            const string filePathPartners = @"partners.txt";

            var dataProvider = new DataProvider();

            Console.WriteLine("Please enter Partner name and date in the format of 'Itunes 1st feb 2012':");

            dataProvider.PostContractFiles(filePathContracts);
            dataProvider.PostPartnersFiles(filePathPartners);

            var input = Console.ReadLine();
            var inputSplit = input.Split(' ');
            var partner = inputSplit[0];
            var date = $"{inputSplit[1]} {inputSplit[2]} {inputSplit[3]}";

            var contracts = dataProvider.GetContractsByCriteria(new Criteria { Date = date, Partner = partner });

            Console.WriteLine();
            Console.WriteLine("Please find below the contracts that match your criteria:");
            Console.WriteLine();
            ConsoleTable.From(contracts).Write();
            Console.ReadKey();
        }
    }
}


