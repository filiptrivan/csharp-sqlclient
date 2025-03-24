using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Spider.Shared.Interfaces;
using System.Reflection;

namespace SpiderCascadeVsClientCascadeBenchmark
{
    public partial class SpiderApplicationDbContext : DbContext, IApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            List<string> alreadyEntityTypeNames = modelBuilder.Model.GetEntityTypes().Select(x => x.Name).ToList();

            List<Type> entityTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type != null && type.Namespace != null && type.Namespace.EndsWith(".Entities"))
                .ToList();

            foreach (Type entityType in entityTypes)
                modelBuilder.Entity(entityType);

            List<IMutableEntityType> mutableEntityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

    }
}
