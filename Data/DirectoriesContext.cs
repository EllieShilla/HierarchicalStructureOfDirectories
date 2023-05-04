using HierarchicalStructureOfDirectories.Models;
using Microsoft.EntityFrameworkCore;

namespace HierarchicalStructureOfDirectories.Data
{
    public class DirectoriesContext : DbContext
    {
        public DirectoriesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FileDirectory> Directorys { get; set; }
        public DbSet<RelationshipBetweenFileDirection> RelationshipBetweenFiles { get; set; }
    }
}
