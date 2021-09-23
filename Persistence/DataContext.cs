using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<DataType> DataTypes { get; set; }
        public DbSet<AttributeRule> AttributeRules { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<ControlType> ControlTypes { get; set; }
        public DbSet<AttributeValueOption> AttributeValueOptions { get; set; }
        public DbSet<AttributeLog> AttributeLogs { get; set; }
        public DbSet<Log> Logs { get; set; }


        ///Model builder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //App User
            builder.Entity<AppUser>()
                .HasMany(F => F.Forms)
                .WithOne(A => A.User)
                .OnDelete(DeleteBehavior.Cascade);

            //Form
            builder.Entity<Form>()
                .HasMany(A => A.Attributes)
                .WithOne(F => F.Form)
                .OnDelete(DeleteBehavior.Cascade);

            //DataType
            builder.Entity<DataType>()
                .HasMany(A => A.Attributes)
                .WithOne(D => D.DataType)
                .OnDelete(DeleteBehavior.Restrict);

            //ControlType

            builder.Entity<ControlType>()
                .HasMany(A => A.Attributes)
                .WithOne(C => C.ControlType)
                .OnDelete(DeleteBehavior.Restrict);

            //Attribute - Attribute Option Value

            builder.Entity<Attribute>()
                .HasMany(A => A.ValueOptions)
                .WithOne(A => A.Attribute)
                .OnDelete(DeleteBehavior.Cascade);


            //Attribute - AttributeRule - Rule
            builder.Entity<AttributeRule>()
                .HasKey(AR => new { AR.AttributeId, AR.RuleId });

            builder.Entity<AttributeRule>()
                    .HasOne(A => A.Attribute)
                    .WithMany(AR => AR.Rules)
                    .HasForeignKey(AR => AR.AttributeId);

            builder.Entity<AttributeRule>()
                    .HasOne(R => R.Rule)
                    .WithMany(AR => AR.Attributes)
                    .HasForeignKey(R => R.RuleId);

            //Attribute - AttributeLog - Log

            builder.Entity<AttributeLog>()
                    .HasKey(AL => new { AL.AttributeId, AL.LogId });

            builder.Entity<AttributeLog>()
                    .HasOne(A => A.Attribute)
                    .WithMany(AL => AL.Logs)
                    .HasForeignKey(A => A.AttributeId);

            builder.Entity<AttributeLog>()
                    .HasOne(L => L.Log)
                    .WithMany(A => A.AttributeLogs)
                    .HasForeignKey(L => L.LogId);

        }
    }
}