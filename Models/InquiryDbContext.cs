using Microsoft.EntityFrameworkCore;

namespace InquiryWeb.Models
{
    public class InquiryDbContext : DbContext
    {
        public InquiryDbContext(DbContextOptions<InquiryDbContext> options) : base(options) {}

        public DbSet<Inquiry> Inquiries { get; set; } // Define a DbSet for your entity
    }
}