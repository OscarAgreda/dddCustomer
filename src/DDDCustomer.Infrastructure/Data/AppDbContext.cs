using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DDDCustomer.Domain.Entities;
using dDDCustomerLib.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// -c	The DbContext class to use. Class name only or fully qualified with namespaces. If this option is omitted, EF Core will find the context class. If there are multiple context classes, this option is required.
// -p	Relative path to the project folder of the target project. Default value is the current folder.
// -s	Relative path to the project folder of the startup project. Default value is the current folder.
// -o	The directory to put files in. Paths are relative to the project directory.


// to drop the database
// dotnet ef database drop -c appdbcontext -p ../DDDCustomer.Infrastructure/DDDCustomer.Infrastructure.csproj -f -v

// dotnet ef migrations add initialDDDCustomerAppMigration -c appdbcontext -p ../DDDCustomer.Infrastructure/DDDCustomer.Infrastructure.csproj -s DDDCustomer.Api.csproj -o Data/Migrations

// dotnet ef database update -c appdbcontext --project ../DDDCustomer.Infrastructure/DDDCustomer.Infrastructure.csproj -s DDDCustomer.Api.csproj

// then look at AppDbContextSeed


namespace DDDCustomer.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;


        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator)
            : base(options)
        {
            SavedChanges += PublishEvent;
            _mediator = mediator;
        }

        public DbSet<Customer> Customers { get; set; }

        private static void PublishEvent(object sender, SavedChangesEventArgs e)
        {
            var aa = e;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            if (_mediator == null)
            {
                return result;
            }

            var entitiesWithEventsTracked = ChangeTracker
                .Entries()
                .Select(e => e.Entity as BaseEntityEv<Guid>)
                .Where(e => e?.Events != null && e.Events.Any())
                .ToArray();
            var entitiesAll = ChangeTracker
                .Entries()
                .ToList();
            foreach (var entity in entitiesWithEventsTracked)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }


    }
}