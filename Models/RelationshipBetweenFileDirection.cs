using System.ComponentModel.DataAnnotations;

namespace HierarchicalStructureOfDirectories.Models
{
    public class RelationshipBetweenFileDirection
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int DirectoryParentId { get; set; }
        [Required]
        public int DirectoryChildId { get; set; }

    }
}
