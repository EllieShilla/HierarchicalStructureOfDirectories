using HierarchicalStructureOfDirectories.Models;

namespace HierarchicalStructureOfDirectories.Data
{
    public class DirectoriesContextSeed
    {
        public static async Task SeedAsync(DirectoriesContext context)
        {
            List<FileDirectory> directoriesData = null;

            if (!context.Directorys.Any())
            {
                directoriesData = new List<FileDirectory>()
                {
                    new FileDirectory()
                    {
                        DirectoryName="Creating Digital Images",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Resources",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Evidence",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Graphic Products",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Primary Sources",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Secondary Sources",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Process",
                    },
                    new FileDirectory()
                    {
                        DirectoryName="Final Product",
                    }
                };

                context.Directorys.AddRange(directoriesData);

                if (context.ChangeTracker.HasChanges())
                    await context.SaveChangesAsync();
            }


            if (!context.RelationshipBetweenFiles.Any())
            {
                List<RelationshipBetweenFileDirection> relationshipBetweenFiles = new List<RelationshipBetweenFileDirection>()
                {
                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Resources").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Creating Digital Images").Id,
                    },
                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Evidence").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Creating Digital Images").Id,
                    },
                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Graphic Products").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Creating Digital Images").Id,
                    },
                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Primary Sources").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Resources").Id,
                    },
                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Secondary Sources").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Resources").Id,
                    },                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Process").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Graphic Products").Id,
                    },                    new RelationshipBetweenFileDirection()
                    {
                        DirectoryChildId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Final Product").Id,
                        DirectoryParentId=directoriesData.FirstOrDefault(i=>i.DirectoryName=="Graphic Products").Id,
                    },

                };

                context.RelationshipBetweenFiles.AddRange(relationshipBetweenFiles);

                if (context.ChangeTracker.HasChanges())
                    await context.SaveChangesAsync();
            }
        }
    }
}
