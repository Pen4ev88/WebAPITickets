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

        [HttpPost("ticket", Name = "Create")]
        public IActionResult Create(TicketRequest ticketRequest)
        {
            Ticket ticket = ticketsService.Create(ticketRequest.ToTicket());

            return Ok(ticket);
        }

        [HttpGet("ticketId", Name = "Get")]
        public IActionResult Get(int ticketId)
        {
            Ticket ticket = ticketsService.Get(ticketId);

            return Ok(ticket);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tickets = ticketsService.GetAll();

            return Ok(tickets);
        }

        [HttpPost("ticketId", Name = "Delete")]
        public IActionResult Delete(int ticketId)
        {
            ticketsService.Delete(ticketId);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Contains(int id)
        {
            if(!ticketsService.Contains(id))
            {
                return NotFound();
            }

            return Ok();
        }


    }
}
