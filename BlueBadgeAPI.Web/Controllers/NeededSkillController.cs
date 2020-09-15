using BlueBadgeAPI.Models;
using BlueBadgeAPI.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace BlueBadgeAPI.Web.Controllers
{
    public class NeededSkillController : ApiController
    {
        private LogService CreateLogService()
        {
            var logService = new LogService();
            return logService;
        }

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

            string newLog = "Skill Created";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);

        }

        //Get
        [Route("api/NeededSkill")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkill();
            string newLog = "All Skills Recieved";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(neededSkills);
        }

        //Get
        [Route("api/NeededSkill/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkillById(id);

            string newLog = "Skill Recieved By Id";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(neededSkills);
        }

        //Put
        [Route("api/NeededSkill")]
        [HttpPut]
        public IHttpActionResult Put(NeededSkillEdit neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = Service();

            if (!service.UpdateNeededSkill(neededSkill))
                return InternalServerError();

            string newLog = "Skill Updated";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }

        //Delete
        [Route("api/NeededSkill/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = Service();

            if (!service.DeleteNeededSkill(id))
                return InternalServerError();

            string newLog = "Skill Deleted";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }

        public NeededSkillService Service()
        {
            var userId = User.Identity.GetUserId();
            var neededSkillService = new NeededSkillService();
            return neededSkillService;
        }

        public Log LogData()
        {
            var logOne = new Log();
            return logOne;
        }
    }
}