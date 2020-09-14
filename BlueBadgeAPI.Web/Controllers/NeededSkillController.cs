using BlueBadgeAPI.Models;
using BlueBadgeAPI.Services;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace BlueBadgeAPI.Web.Controllers
{
    public class NeededSkillController : ApiController
    {

        //Post
        //[Route("api/NeededSkillController/Post")]
        [Route("api/NeededSkill")]
        [HttpPost]
        public IHttpActionResult Post(NeededSkillCreate neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = Service();

            if (!service.NeededSkillCreate(neededSkill))
                return InternalServerError();
            return Ok();

        }

        //Get
        [HttpGet]
        public IHttpActionResult Get()
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkill();
            return Ok(neededSkills);
        }

        //Get
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkillById(id);
            return Ok(neededSkills);
        }

        //Put
        [HttpPut]
        public IHttpActionResult Put(NeededSkillEdit neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = Service();

            if (!service.UpdateNeededSkill(neededSkill))
                return InternalServerError();

            return Ok();
        }

        //Delete
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = Service();

            if (!service.DeleteNeededSkill(id))
                return InternalServerError();

            return Ok();
        }

        public NeededSkillService Service()
        {
            var userId = User.Identity.GetUserId();
            var neededSkillService = new NeededSkillService();
            return neededSkillService;
        }
    }
}

