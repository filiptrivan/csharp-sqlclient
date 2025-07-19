using Spider.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Spider.Shared.Interfaces;
using SpiderCascadeVsClientCascadeBenchmark.Entities;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Diagnosers;

namespace SpiderCascadeVsClientCascadeBenchmark
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
        }
    }

    [AllStatisticsColumn]
    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        long ownerId;
        IApplicationDbContext _context = new SpiderApplicationDbContext();

        [GlobalSetup]
        public void GlobalSetup()
        {
            Task.Run(async () => await InitDatabase()).GetAwaiter().GetResult();
        }

        [IterationSetup]
        public void IterationSetup()
        {
            Task.Run(async () => await InitDatabase()).GetAwaiter().GetResult();
        }


        [Benchmark]
        public async Task SpiderCascadeDelete()
        {
            await _context.WithTransactionAsync(async () =>
            {
                // FT: Alway single element in the list here, but made this extension method for easier source generating whole method using recursion
                List<long> ownerIdsForDelete = ownerId.StructToList();

                // FT NOTE: As no tracking event if we are selecting only ids: https://learn.microsoft.com/en-us/ef/core/querying/tracking#tracking-and-custom-projections
                List<long> blogIdsForDeleteBecauseOwner = await _context.DbSet<Blog>()
                    .AsNoTracking()
                    .Where(x => ownerIdsForDelete.Contains(x.Owner.Id))
                    .Select(x => x.Id)
                    .ToListAsync();

                List<long> commentIdsForDeleteBecauseBlogs = await _context.DbSet<Comment>()
                    .AsNoTracking()
                    .Where(x => blogIdsForDeleteBecauseOwner.Contains(x.Blog.Id))
                    .Select(x => x.Id)
                    .ToListAsync();

                await _context.DbSet<Comment>()
                    .Where(x => commentIdsForDeleteBecauseBlogs.Contains(x.Id))
                    .ExecuteDeleteAsync();

                await _context.DbSet<Blog>()
                    .Where(x => blogIdsForDeleteBecauseOwner.Contains(x.Id))
                    .ExecuteDeleteAsync();

                // FT: Operates directly at the database level without loading entities into the context, so tracking isn’t relevant
                await _context.DbSet<People>()
                    .Where(x => x.Id == ownerId)
                    .ExecuteDeleteAsync();
            });
        }

        [Benchmark]
        public async Task ClientCascadeDelete()
        {
            await _context.WithTransactionAsync(async () =>
            {
                People owner = await _context.DbSet<People>()
                    .Where(x => x.Id == ownerId)
                    .SingleAsync();

                List<Blog> blogs = await _context.DbSet<Blog>()
                    .Where(e => e.Owner.Id == owner.Id)
                    .ToListAsync();

                List<long> blogIds = blogs
                    .Select(x => x.Id)
                    .ToList();

                List<Comment> comments = await _context.DbSet<Comment>()
                    .Where(e => blogIds.Contains(e.Blog.Id))
                    .ToListAsync();

                _context.DbSet<People>().Remove(owner);

                await _context.SaveChangesAsync();
            });
        }

        public async Task InitDatabase()
        {
            await _context.WithTransactionAsync(async () =>
            {
                await _context.DbSet<Comment>()
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _context.DbSet<Blog>()
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                await _context.DbSet<People>()
                    .AsNoTracking()
                    .ExecuteDeleteAsync();

                People owner = new People
                {
                    Name = "Test Name",
                    Description = "Test Description",
                    Address = "Test Address",
                    City = "Test City",
                    Region = "Test Region",
                    PostalCode = "Test PostalCode",
                    Country = "Test Country",
                    Phone = "Test Phone",
                    Fax = "Test Fax",
                    FaxNumber = "Test FaxNumber",
                    PhoneNumber = "Test PhoneNumber",
                    FaxName = "Test FaxName",
                    FaxPhone = "Test FaxPhone",
                    FaxPhoneNumber = "Test FaxPhoneNumber",
                    Email = "Test Email",
                    Index = "Test Index",
                };
                await _context.DbSet<People>().AddAsync(owner);

                for (int i = 0; i < 100; i++)
                {
                    Blog blog = new Blog
                    {
                        Name = "Test Name",
                        Description = "Test Description",
                        Title = "Test Title",
                        Author = "Test Author",
                        Number = "Test Number",
                        Code = "Test Code",
                        Html = "Test Html",
                        Slug = "Test Slug",
                        MetaDescription = "Test MetaDescription",
                        MetaTitle = "Test MetaTitle",
                        MetaAuthor = "Test MetaAuthor",
                        MetaCode = "Test MetaCode",
                        MetaHtml = "Test MetaHtml",
                        Owner = owner,
                    };
                    await _context.DbSet<Blog>().AddAsync(blog);

                    for (int j = 0; j < 10; j++)
                    {
                        Comment comment = new Comment
                        {
                            Name = "Test Name",
                            Description = "Test Description",
                            Created = DateTime.Now,
                            Updated = DateTime.Now,
                            Title = "Test Title",
                            Author = "Test Author",
                            Points = 10,
                            Owner = owner,
                            Blog = blog,
                        };
                        await _context.DbSet<Comment>().AddAsync(comment);
                    }
                }

                await _context.SaveChangesAsync();

                ownerId = owner.Id;
            });
        }

    }
}


