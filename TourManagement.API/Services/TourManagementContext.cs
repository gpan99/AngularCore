using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TourManagement.API.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace TourManagement.API.Services
{
    public class TourManagementContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<State> States { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        private readonly IUserInfoService _userInfoService;

        public TourManagementContext(DbContextOptions<TourManagementContext> options,
            IUserInfoService userInfoService)
           : base(options)
        {
            // userInfoService is a required argument
            _userInfoService = userInfoService ?? throw new ArgumentNullException(nameof(userInfoService));
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // get added or updated entries
            var addedOrUpdatedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));

            // fill out the audit fields
            foreach (var entry in addedOrUpdatedEntries)
            {
                var entity = entry.Entity as AuditableEntity;
                if (entity == null)  // GP added
                    break;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = _userInfoService.UserId;
                    entity.CreatedOn = DateTime.UtcNow;
                }

                entity.UpdatedBy = _userInfoService.UserId;
                entity.UpdatedOn = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }        
    }
}
