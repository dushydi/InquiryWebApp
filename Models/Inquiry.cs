using System.ComponentModel.DataAnnotations;

namespace InquiryWeb.Models
{
    public class Inquiry
    {
    
        public int Id { get; set; } 

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Telephone number must be a positive number.")]
        public int TelNo { get; set; }

        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        public int Age { get; set; }

        public DateTime Date { get; set; }
        
        [Required(ErrorMessage = "Inquiry message is required.")]
        [StringLength(200,ErrorMessage = "Inquiry description should be less than 200 characters.")]
        public string Message { get; set; }
        
    }
}