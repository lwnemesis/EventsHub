using EventsHubCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsHubCatalogAPI.Data
{
    public class EventContext: DbContext 
    {
        public EventContext(DbContextOptions options) : base(options)
        { }
        public DbSet <CategoryType> CategoryTypes { get; set; }
        public DbSet <OrganizerType> OrganizerTypes { get; set; }
        public DbSet<EventType> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryType>(e =>
            {
                e.Property(t => t.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<OrganizerType>(e =>
            {
                e.Property(b => b.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(b => b.Organizer)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(c => c.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                e.Property(c => c.Price)
                    .IsRequired();

                e.Property(c => c.DateTime);

                e.HasOne(t => t.CategoryType)
                    .WithMany()
                    .HasForeignKey(t => t.CategoryTypeId);

                e.HasOne(t => t.OrganizerType)
                    .WithMany()
                    .HasForeignKey(t => t.OrganizerTypeId);

            });
        }
    }
}
