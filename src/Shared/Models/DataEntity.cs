using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class DataEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}