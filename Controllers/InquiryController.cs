using InquiryWeb.Models;
using InquiryWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace InquiryWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Automatically validates the model
    public class InquiryController : ControllerBase
    {
        private readonly InquiryService _inquiryService;

        public InquiryController(InquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetAllInquiries()
        {
            var inquiries = await _inquiryService.GetAllInquiriesAsync();
            return Ok(inquiries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiry>> GetInquiry(int id)
        {
            var inquiry = await _inquiryService.GetInquiryByIdAsync(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            return Ok(inquiry);
        }

        [HttpPost]
        public async Task<ActionResult<Inquiry>> AddInquiry(Inquiry inquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Don't set the Id manually; let EF handle it automatically
            await _inquiryService.AddInquiryAsync(inquiry);
            return CreatedAtAction(nameof(GetInquiry), new { id = inquiry.Id }, inquiry);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInquiry(int id, Inquiry inquiry)
        {
            if (id != inquiry.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) // Ensures validation is respected
            {
                return BadRequest(ModelState);
            }

            await _inquiryService.UpdateInquiryAsync(inquiry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInquiry(int id)
        {
            await _inquiryService.DeleteInquiryAsync(id);
            return NoContent();
        }
    }
}
