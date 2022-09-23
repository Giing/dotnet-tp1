using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// Controller responsible for devises
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        private List<Devise> devises;

        /// <summary>
        /// List of devices
        /// </summary>
        public List<Devise> Devises
        {
            get { return devises; }
            set { devises = value; }
        }

        // GET: api/<DevisesController>
        /// <summary>
        /// Get all devises
        /// </summary>
        /// <returns>Http Response</returns>
        /// <response code="200">All the time</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        public IActionResult GetAll()
        {
            return Ok(this.Devises);
        }

        // GET api/<DevisesController>/5
        /// <summary>
        /// Get a devise by id
        /// </summary>
        /// <param name="id">The id of the devise</param>
        /// <returns>Http response</returns>
        /// <response code="200">When the devise id is found</response>
        /// <response code="404">When the devise id is not found</response>
        [HttpGet("{id}", Name="GetDevise")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            Devise? devise = Devises.FirstOrDefault(x => x.Id == id);
            if (devise == null) return NotFound();
            return Ok(devise);
        }

        // POST api/<DevisesController>
        /// <summary>
        /// Add a devise
        /// </summary>
        /// <param name="devise">The devise</param>
        /// <returns>Http response</returns>
        /// <response code="201">When the devise has been added</response>
        /// <response code="400">When the devise has not a valid state</response>
        [HttpPost]
        [ProducesResponseType(typeof(Devise), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        // PUT api/<DevisesController>/5
        /// <summary>
        /// Update a devise
        /// </summary>
        /// <param name="id">Id of the devise</param>
        /// <param name="devise">The devise</param>
        /// <returns>Http response</returns>
        /// <response code="204">When the devise has been updated</response>
        /// <response code="400">When the devise has not a valid state</response>
        /// <response code="404">When the devise does not exist</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Devise devise)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(id != devise.Id) return BadRequest(ModelState);

            int index = Devises.FindIndex(d => id == d.Id);
            
            if(index < 0) return NotFound();

            Devises[index] = devise;
            return NoContent();
        }

        // DELETE api/<DevisesController>/5
        /// <summary>
        /// Delete a devise
        /// </summary>
        /// <param name="id">Id of the devise</param>
        /// <returns>Http response</returns>
        /// <response code="200">When the devise has been deleted</response>
        /// <response code="404">When the devise does not exist</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            Devise? devise = Devises.FirstOrDefault(devise => id == devise.Id);
            if(devise == null) return NotFound();
            Devises.Remove(devise);
            return Ok(devise);
        }

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        public DevisesController()
        {
            this.Devises = new List<Devise>()
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc suisse", 1.07),
                new Devise(3, "Yen", 120),
            };
        }
    }
}
