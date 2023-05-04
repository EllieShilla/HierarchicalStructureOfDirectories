namespace HierarchicalStructureOfDirectories.Models
{
    public class ParentDirectoryData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FileDirectory> ChildsDirecories { get; set; }
    }
}
