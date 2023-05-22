using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialJuanPabloGomezRamirez.DAL;
using ParcialJuanPabloGomezRamirez.DAL.Entities;
using System.Diagnostics.Metrics;

namespace ParcialJuanPabloGomezRamirez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets() 
        {

            var tickets = await _context.Tickets.ToListAsync(); // Select * From Countries

            if (tickets == null) return NotFound();

            return tickets;

        }
        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(Guid? id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(c => c.id  == id); //Select * From Countries Where Id = "..."

            if (ticket == null) return NotFound();

            return Ok(ticket);
        }
        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountry(Ticket ticket)
        {
            try
            {
                ticket.id = Guid.NewGuid();
                //ticket.CreatedDate = DateTime.Now;
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Insert Into...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("  ya existe"));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }
        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditTicket(Guid? id, Ticket ticket)
        {
            try
            {
                if (id != ticket.id) return NotFound("ticket not found");

                

                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format(" ya existe"));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }
        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteTicket(Guid? id)
        {
            if (_context.Tickets == null) return Problem("Entity set 'DataBaseContext.Tickets' is null.");
            var ticket = await _context.Tickets.FirstOrDefaultAsync(c => c.id == id);

            if (ticket == null) return NotFound("Ticket not found");

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync(); //Hace las veces del Delete en SQL

            return Ok(String.Format("El ticket fue eliminado!"));
        }
    }
}
