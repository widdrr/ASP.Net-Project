using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Net_Backend.Models
{
    public class TestModel1
    {
        [Key]
        [Required]
        public Guid Id { get; set; };

    }
}
