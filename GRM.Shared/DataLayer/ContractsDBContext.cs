using GRM.Shared.Interfaces;
using GRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRM.Shared.DataLayer
{
    public class ContractsDBContext : DbContext
    {
        public ContractsDBContext()
        {
        }

        public ContractsDBContext(string ConnectionString) :
            base("DbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ContractsDBContext>());
        }
        
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<DistributionPartners> DistributionPartners { get; set; }
    }
}
