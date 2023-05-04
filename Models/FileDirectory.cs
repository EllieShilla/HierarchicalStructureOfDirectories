using System.ComponentModel.DataAnnotations;

namespace HierarchicalStructureOfDirectories.Models
{
    public class FileDirectory
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? DirectoryName { get; set; }
    }
}
