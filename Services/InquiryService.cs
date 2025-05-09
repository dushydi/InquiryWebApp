using InquiryWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace InquiryWeb.Services
{
    public class InquiryService
    {
        private readonly InquiryDbContext _context;

        // Constructor to inject the DbContext
        public InquiryService(InquiryDbContext context)
        {
            _context = context;
        }

        // Get all inquiries
        public async Task<IEnumerable<Inquiry>> GetAllInquiriesAsync()
        {
            return await _context.Inquiries.ToListAsync();
        }

        // Get a single inquiry by ID
        public async Task<Inquiry> GetInquiryByIdAsync(int id)
        {
            return await _context.Inquiries.FindAsync(id);
        }

        // Add a new inquiry
        public async Task AddInquiryAsync(Inquiry inquiry)
        {
            await _context.Inquiries.AddAsync(inquiry);
            await _context.SaveChangesAsync();
        }

        // Update an existing inquiry
        public async Task UpdateInquiryAsync(Inquiry inquiry)
        {
            _context.Inquiries.Update(inquiry);
            await _context.SaveChangesAsync();
        }

        // Delete an inquiry
        public async Task DeleteInquiryAsync(int id)
        {
            var inquiry = await _context.Inquiries.FindAsync(id);
            if (inquiry != null)
            {
                _context.Inquiries.Remove(inquiry);
                await _context.SaveChangesAsync();
            }
        }
    }
}