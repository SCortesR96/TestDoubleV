using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TestDoubleV.DV_EF.People
{
    public class PeopleEF
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
        [Required]
        public string DocumentType { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        public string? FullName { get; set; }
        public string? FullDocument { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
