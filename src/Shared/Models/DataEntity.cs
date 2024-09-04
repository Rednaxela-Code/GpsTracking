using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class DataEntity
    {
        [Key]
        public int Id { get; set; }
    }
}