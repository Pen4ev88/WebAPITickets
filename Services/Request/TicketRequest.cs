using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.Internship2020.WebApiExamples.Services.Request
{
    public class TicketRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="You should fill Event Name.")]
        [MaxLength(100, ErrorMessage ="The Event Name shouldn't have more than 100 characters.")]
        public string EventName { get; set; } = string.Empty;
        [MaxLength(120, ErrorMessage = "The Owner shouldn't have more than 120 characters.")]
        public string Owner { get; set; } = string.Empty;
    }
}
