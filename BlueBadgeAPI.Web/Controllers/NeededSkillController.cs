using BlueBadgeAPI.Models;
using BlueBadgeAPI.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace BlueBadgeAPI.Web.Controllers
{
    public class NeededSkillController : ApiController
    {

        /// <summary>
        /// Add a needed skill for a project.
        /// </summary>
        [Route("api/NeededSkill")]
        [HttpPost]
        public IHttpActionResult Post(NeededSkillCreate neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = Service();

            if (!service.NeededSkillCreate(neededSkill))
                return InternalServerError();
            return Ok("Skill Created");

        }

        /// <summary>
        /// Get all needed skills.
        /// </summary>
        [Route("api/NeededSkill")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkill();
            return Ok("Skills Recived");
        }

        /// <summary>
        /// Get a needed skill by Id.
        /// </summary>
        [Route("api/NeededSkill/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkillById(id);
            return Ok("Skills Recived");
        }

        /// <summary>
        /// Update existing needed skill.
        /// </summary>
        [Route("api/NeededSkill")]
        [HttpPut]
        public IHttpActionResult Put(NeededSkillEdit neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = Service();

            if (!service.UpdateNeededSkill(neededSkill))
                return InternalServerError();

            return Ok("Skill Updated");
        }

        /// <summary>
        /// Delete needed skill by Id.
        /// </summary>
        [Route("api/NeededSkill/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = Service();

            if (!service.DeleteNeededSkill(id))
                return InternalServerError();

            return Ok("Skill Deleted");
        }

        public NeededSkillService Service()
        {
            var userId = User.Identity.GetUserId();
            var neededSkillService = new NeededSkillService();
            return neededSkillService;
        }
    }
}