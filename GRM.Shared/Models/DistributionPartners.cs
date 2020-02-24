using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRM.Shared.Models
{
    public class DistributionPartners
    {
        public DistributionPartners()
        {

        }

        public DistributionPartners(string partner, string usage) =>
            (Partner, Usage) = (partner, usage);

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Partner { get; set; }
        public string Usage { get; set; }

    }
}
