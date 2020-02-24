using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRM.Shared.Models
{
    public class Contracts
    {
        public Contracts()
        {

        }
        public Contracts(string artist, string title, string usage, string startDate, string endDate) =>
            (Artist, Title, Usage, StartDate, EndDate) = (artist, title, usage, startDate, endDate);

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Usage { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
