using Endava.Internship2020.WebApiExamples.Services.Models;
using Endava.Internship2020.WebApiExamples.Services.Request;

namespace TicketsAPI
{
    public static class Mapper
    {
        public static Ticket ToTicket(this TicketRequest ticket)
        {
            return new Ticket
            {
                EventName = ticket.EventName,
                Owner = ticket.Owner
            };
        }
    }
}
