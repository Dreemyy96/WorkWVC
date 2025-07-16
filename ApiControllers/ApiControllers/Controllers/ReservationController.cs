using ApiControllers.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
	[Route("api/[controller]")]
	public class ReservationController : Controller
	{
		private readonly IRepository _rep;
        public ReservationController(IRepository rep)
        {
            _rep = rep;
        }
        [HttpGet]
        public IEnumerable<Reservation> Get() =>_rep.Reservations;
        [HttpGet("{id}")]
        public Reservation Get(int id) => _rep[id];
        [HttpPost]
        public Reservation Post([FromBody]Reservation reservation) => _rep.AddReservation(new Reservation 
        { 
            ClientName = reservation.ClientName,
            Location = reservation.Location
        });
        [HttpPut]
        public Reservation Put([FromBody]Reservation res)=>_rep.UpdateReservation(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Path(int id, [FromBody]JsonPatchDocument<Reservation> patch)
        {
            Reservation res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => _rep.DeleteReservation(id);
    }
}
