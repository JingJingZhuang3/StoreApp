using System.ComponentModel.DataAnnotations;

namespace StoreApp.API.Dtos
{
    public class CustomerName
    {
        [Required]
        public string? firstName { get; set; }

        [Required]
        public string? lastName { get; set; }
    }
}
