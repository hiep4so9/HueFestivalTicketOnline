using HueFestivalTicketOnline.Model;
using HueFestivalTicketOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFestivalTicketOnline.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artists_Invited> Artists_Inviteds { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_Images> Event_Images { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<Events_Locations> Events_Locations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Role_Permission> Role_Permissions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCheckin> TicketCheckins { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artists_Invited>()
                .HasKey(a => new { a.artistID, a.eventID });

            modelBuilder.Entity<Event_Images>()
                .HasKey(a => new { a.eventID, a.eventImageID });

            modelBuilder.Entity<User_Role>()
               .HasKey(a => new { a.userID, a.roleID });

            modelBuilder.Entity<Role_Permission>()
                .HasKey(a => new { a.roleID, a.permissionID });

            modelBuilder.Entity<Events_Locations>()
                .HasKey(a => new { a.eventID, a.locationID });


            modelBuilder.Entity<Artists_Invited>()
                .HasOne(pc => pc.Artist)
                .WithMany(p => p.Artists_Inviteds)
                .HasForeignKey(pc => pc.artistID);

            modelBuilder.Entity<Artists_Invited>()
                .HasOne(pc => pc.Event)
                .WithMany(p => p.Artists_Inviteds)
                .HasForeignKey(pc => pc.eventID);

            modelBuilder.Entity<Event_Images>()
                .HasOne(pc => pc.EventImage)
                .WithMany(p => p.Event_Images)
                .HasForeignKey(pc => pc.eventImageID);

            modelBuilder.Entity<Event_Images>()
                .HasOne(pc => pc.Event)
                .WithMany(p => p.Event_Images)
                .HasForeignKey(pc => pc.eventID);

            modelBuilder.Entity<Events_Locations>()
                .HasOne(pc => pc.Location)
                .WithMany(p => p.Events_Locations)
                .HasForeignKey(pc => pc.locationID);

            modelBuilder.Entity<Events_Locations>()
                .HasOne(pc => pc.Event)
                .WithMany(p => p.Events_Locations)
                .HasForeignKey(pc => pc.eventID);

            modelBuilder.Entity<User_Role>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.User_Roles)
                .HasForeignKey(pc => pc.userID);

            modelBuilder.Entity<User_Role>()
                .HasOne(pc => pc.Role)
                .WithMany(p => p.User_Roles)
                .HasForeignKey(pc => pc.roleID);

            modelBuilder.Entity<Role_Permission>()
                .HasOne(pc => pc.Role)
                .WithMany(p => p.Role_Permissions)
                .HasForeignKey(pc => pc.roleID);

            modelBuilder.Entity<Role_Permission>()
                .HasOne(pc => pc.Permission)
                .WithMany(p => p.Role_Permissions)
                .HasForeignKey(pc => pc.permissionID);
        }
    }
}
