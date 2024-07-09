using Microsoft.EntityFrameworkCore;
using SMSApi.Entity;
namespace SMSApi
{
    public class StudentCollectionContext:DbContext
    {
       public DbSet<Student> student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost; port=3306; database=studentnet;" +
                "user=root; password=root; ";
            optionsBuilder.UseMySQL(connectionString);
            Console.WriteLine("Connection done with DB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Phone).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.AddmissionDate).IsRequired();
                entity.Property(e => e.Fees).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                });
            Console.WriteLine("Mapin of POCO wiht table done");
        }
    }
}
