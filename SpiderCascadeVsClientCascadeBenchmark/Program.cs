using Spider.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Spider.Shared.Interfaces;
using SpiderCascadeVsClientCascadeBenchmark.Entities;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Diagnosers;
using System.Diagnostics;
using System.Security.Permissions;
using System.Xml;

namespace SpiderCascadeVsClientCascadeBenchmark
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //await InitDatabase();

            //ConsoleLogger logger = new();

            //var config = new ManualConfig()
            //    .AddLogger(logger)
            //    .AddDiagnoser(MemoryDiagnoser.Default)
            //    .AddColumnProvider(DefaultColumnProviders.Instance)
            //    .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            //Summary summary = BenchmarkRunner.Run<BenchmarkProgram>(config);
            //Console.WriteLine(summary);

            await new BenchmarkProgram().ClientCascadeDelete();
        }
    }

    [AllStatisticsColumn, MemoryDiagnoser]
    public class BenchmarkProgram
    {
        long ownerId;

        [GlobalSetup]
        public async void GlobalSetup()
        {
            IApplicationDbContext _context = new SpiderApplicationDbContext();

            await _context.WithTransactionAsync(async () =>
            {
                await InitDatabase();
            });
        }

        [IterationSetup]
        public async void IterationSetup()
        {
            IApplicationDbContext _context = new SpiderApplicationDbContext();

            await _context.WithTransactionAsync(async () =>
            {
                await InitDatabase();
            });
        }

        [Benchmark]
        public async Task FilipTrivanDelete()
        {
            IApplicationDbContext _context = new SpiderApplicationDbContext();

            await _context.WithTransactionAsync(async () =>
            {
                if (await _context.DbSet<People>().Where(e => e.Id == ownerId).AnyAsync() == false)
                    return;

                List<long> listForDelete_1 = ownerId.StructToList();

                var blogListForDeleteBecausePeople_2 = await _context.DbSet<Blog>()
                    .Where(x => listForDelete_1.Contains(x.Owner.Id))
                    .Select(x => x.Id)
                    .ToListAsync();

                var commentListForDeleteBecauseBlog_2 = await _context.DbSet<Comment>()
                    .Where(x => blogListForDeleteBecausePeople_2.Contains(x.Blog.Id))
                    .Select(x => x.Id)
                    .ToListAsync();

                await _context.DbSet<Comment>()
                    .Where(x => commentListForDeleteBecauseBlog_2.Contains(x.Id))
                    .ExecuteDeleteAsync();

                await _context.DbSet<Blog>()
                    .Where(x => blogListForDeleteBecausePeople_2.Contains(x.Id))
                    .ExecuteDeleteAsync();

                await _context.DbSet<People>().Where(x => x.Id == ownerId).ExecuteDeleteAsync();
            });
        }

        [Benchmark]
        public async Task ClientCascadeDelete()
        {
            IApplicationDbContext _context = new SpiderApplicationDbContext();

            await _context.WithTransactionAsync(async () =>
            {
                var owner = await _context.DbSet<People>()
                    .Where(x => x.Id == ownerId)
                    .SingleAsync();

                var blogs = await _context.DbSet<Blog>()
                    .Where(e => e.Owner.Id == owner.Id)
                    .ToListAsync();

                var blogIds = blogs
                    .Select(x => x.Id)
                    .ToList();

                var comments = await _context.DbSet<Comment>()
                    .Where(e => blogIds.Contains(e.Blog.Id))
                    .ToListAsync();

                _context.DbSet<People>().Remove(owner);

                await _context.SaveChangesAsync();
            });
        }

        public async Task InitDatabase()
        {
            IApplicationDbContext _context = new SpiderApplicationDbContext();

            await _context.WithTransactionAsync(async () =>
            {
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

                for (int i = 0; i < 1000; i++)
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


