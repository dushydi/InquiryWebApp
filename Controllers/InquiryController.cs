using InquiryWeb.Models;
using InquiryWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace InquiryWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InquiryController : ControllerBase
{
    private readonly InquiryService _inquiryService;

    public InquiryController(InquiryService inquiryService)
    {
        _inquiryService = inquiryService;
    }

    // Get all inquiries
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inquiry>>> GetAllInquiries()
    {
        var inquiries = await _inquiryService.GetAllInquiriesAsync();
        return Ok(inquiries);
    }

    // Get a specific inquiry by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Inquiry>> GetInquiry(int id)
    {
        var inquiry = await _inquiryService.GetInquiryByIdAsync(id);  // Corrected method name here
        if (inquiry == null)
        {
            return NotFound();
        }

        return Ok(inquiry);
    }

    // Add a new inquiry
    [HttpPost]
    public async Task<ActionResult<Inquiry>> AddInquiry(Inquiry inquiry)
    {
        await _inquiryService.AddInquiryAsync(inquiry);
        return CreatedAtAction(nameof(GetInquiry), new { id = inquiry.Id }, inquiry);  // Ensure it refers to 'GetInquiry'
    }

    // Update an existing inquiry
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInquiry(int id, Inquiry inquiry)
    {
        if (id != inquiry.Id)
        {
            return BadRequest();
        }
        await _inquiryService.UpdateInquiryAsync(inquiry);
        return NoContent();
    }

    // Delete an inquiry
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInquiry(int id)
    {
        await _inquiryService.DeleteInquiryAsync(id);
        return NoContent();
    }
}