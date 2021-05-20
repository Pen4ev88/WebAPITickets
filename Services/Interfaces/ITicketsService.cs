using Endava.Internship2020.WebApiExamples.Services.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endava.Internship2020.WebApiExamples.Services.Interfaces
{
    public interface ITicketsService
    {
        public bool Contains(int id);

        public IReadOnlyCollection<Ticket> GetAll();
        public Ticket Get(int id);
        public Ticket Create(Ticket ticket);

        public Ticket Update(Ticket ticket);

        public Ticket Update(int id, JsonPatchDocument<Ticket> patch);

        public void Delete(int id);
    }
}
