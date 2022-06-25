using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VolunTEENProject.Models
{
    public class AppDBContext : IdentityDbContext<EndUser>
    {

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {

        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<EndUser> EndUsers { get; set; }
        public DbSet<EndUserTags> EndUserTags { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<OpportunityTags> OpportunityTags { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PartnerMember> PartnerMembers{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //EndUserTags
            modelBuilder.Entity<EndUserTags>()
                .HasKey(e => new { e.EndUserID, e.TagID });

            modelBuilder.Entity<EndUserTags>()
                .HasOne<EndUser>(e => e.EndUser)
                .WithMany()
                .HasForeignKey(e => e.EndUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EndUserTags>()
                .HasOne<Tag>(t => t.Tag)
                .WithMany()
                .HasForeignKey(t => t.TagID)
                .OnDelete(DeleteBehavior.Restrict);

            //Friend

            modelBuilder.Entity<Friend>()
                .HasKey(f => new { f.MainUserID, f.FriendUserID });

            modelBuilder.Entity<Friend>()
                .HasOne<EndUser>(f => f.MainUser)
                .WithMany()
                .HasForeignKey(f => f.MainUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>()
                .HasOne<EndUser>(f => f.FriendUser)
                .WithMany()
                .HasForeignKey(f => f.FriendUserID)
                .OnDelete(DeleteBehavior.Restrict);

            //OpportunityTag
            modelBuilder.Entity<OpportunityTags>()
                .HasKey(o => new { o.OpportunityID, o.TagID });

            modelBuilder.Entity<OpportunityTags>()
                .HasOne<Opportunity>(o => o.Opportunity)
                .WithMany()
                .HasForeignKey(o => o.OpportunityID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OpportunityTags>()
                .HasOne<Tag>(t => t.Tag)
                .WithMany()
                .HasForeignKey(t => t.TagID)
                .OnDelete(DeleteBehavior.Restrict);

            //PartnerMembers
            modelBuilder.Entity<PartnerMember>()
                .HasKey(p => new { p.UserId, p.PartnerId});

            modelBuilder.Entity<PartnerMember>()
                .HasOne<EndUser>( e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PartnerMember>()
                .HasOne<Partner>(p => p.Partner)
                .WithMany()
                .HasForeignKey(p => p.PartnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
