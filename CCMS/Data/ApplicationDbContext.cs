using CCMS.Models;
using CCMS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
              
        }

        public DbSet <Student> Students { get; set; }
        public DbSet <Teacher> Teachers { get; set; }
        public DbSet <StudentClass> StudentClasses { get; set; }
        public DbSet <StudentSection> StudentSections { get; set; }
        public DbSet<CCMS.Models.StudentSubject> StudentSubject { get; set; } = default!;
        public DbSet <HeadCategory> HeadCategories { get; set; }
        public DbSet <AccountingHead> AccountingHeads { get; set; }
        public DbSet <Transaction> Transactions { get; set; }

    }
}
