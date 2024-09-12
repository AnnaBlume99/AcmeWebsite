using Microsoft.EntityFrameworkCore;
using PrizeDrawLogic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeWebsite
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SerialNumber>().ToTable("SerialNumbers");
            modelBuilder.Entity<Submission>().ToTable("Submissions");
        }

    }

    public class SerialNumber
    {
        [Column("SerialNumber")]
        [Key]
        public string Number { get; set; }
    }

    public class Submission : ISubmission
    {
        [Key]
        public int SubmissionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SerialNumber { get; set; }
    }
}
