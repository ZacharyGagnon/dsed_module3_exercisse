using DSED_Module03_QuickStart_web.Services;
using M01_Srv_Municipalite;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DSED_Module03_QuickStart_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalitesController : ControllerBase
    {
        private ManipulationMunicipalite m_manipulationMunicipalite;

        public MunicipalitesController(ManipulationMunicipalite p_manipulationMunicipalite)
        {
            m_manipulationMunicipalite = p_manipulationMunicipalite;
        }

        // GET: api/municipalites
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<MunicipaliteModel>> Get()
        {
            return Ok(m_manipulationMunicipalite.ListerMuniciapliter());
        }

        // GET api/municipalites/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<MunicipaliteModel> Get(int id)
        {
            MunicipaliteModel municipalite = new MunicipaliteModel(m_manipulationMunicipalite.ObtenirMunicipalite(id));

            if (municipalite != null)
            {
                return Ok(municipalite);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/municipalites
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] MunicipaliteModel p_municipalite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int dernierId = m_manipulationMunicipalite.ListerMuniciapliter().OrderByDescending(x => x.CodeGeographique).FirstOrDefault()?.CodeGeographique ?? 0;
            p_municipalite.MunicipaliteId = dernierId + 1;
            m_manipulationMunicipalite.AjouterMunicipalite(p_municipalite.VersEntite());
            return CreatedAtAction(nameof(Get), new { id = p_municipalite.MunicipaliteId }, p_municipalite);
        }

        // PUT api/municipalites/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int p_municipaliteId, [FromBody] MunicipaliteModel p_municipalite)
        {
            if (p_municipaliteId != p_municipalite.MunicipaliteId || !ModelState.IsValid)
            {
                return BadRequest();
            }
            int nbMunicipaliteMAJ = m_manipulationMunicipalite.ListerMuniciapliter().Where(x => x.CodeGeographique == p_municipaliteId).Count();

            if (nbMunicipaliteMAJ < 0)
            {
                return NotFound();
            }
            m_manipulationMunicipalite.MAJMunicipalite(p_municipalite.VersEntite());

            return NoContent();
        }

        // DELETE api/municipalites/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int p_municipaliteId)
        {
            MunicipaliteModel municipalite = new MunicipaliteModel(m_manipulationMunicipalite.ObtenirMunicipalite(p_municipaliteId));

            if (municipalite == null)
            {
                return NotFound();
            }

            m_manipulationMunicipalite.SupprimerMunicipalite(p_municipaliteId);

            return NoContent();
        }
    }
}
