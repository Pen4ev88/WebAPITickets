using Endava.Internship2020.WebApiExamples.DataAccess.Entities;
using Endava.Internship2020.WebApiExamples.Services.Models;
using Endava.Internship2020.WebApiExamples.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAPI
{
    public static class Mapper
    {
        public static Ticket ToTicket(this TicketRequest ticket)
        {
            return new Ticket
            {
                //Id = ticket.Id,
                EventName = ticket.EventName,
                Owner = ticket.Owner
            };
        }
    }
}
