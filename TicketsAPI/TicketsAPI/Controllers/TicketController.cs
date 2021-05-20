using Endava.Internship2020.WebApiExamples.Services.Interfaces;
using Endava.Internship2020.WebApiExamples.Services.Models;
using Endava.Internship2020.WebApiExamples.Services.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketsService ticketsService;

        public TicketController(ITicketsService ticketsService)
        {
            this.ticketsService = ticketsService;
        }

        [HttpPost]
        public IActionResult Create(TicketRequest ticketRequest)
        {
            Ticket ticket =  ticketsService.Create(ticketRequest.ToTicket());

            return Ok(ticket);
        }

    }
}
