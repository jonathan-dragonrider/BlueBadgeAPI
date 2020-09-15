using BlueBadgeAPI.Models;
using BlueBadgeAPI.Services;
using Microsoft.Ajax.Utilities;
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

            string newLog = "Skill Created \n";
            return Ok(LogData().GetLogData(newLog));

        }

        //Get
        [Route("api/NeededSkill")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkill();
            string newLog = "Skill Created \n";
            return Ok(LogData().GetLogData(newLog));
        }

        //Get
        [Route("api/NeededSkill/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            NeededSkillService neededSkillService = Service();
            var neededSkills = neededSkillService.GetNeededSkillById(id);
            string newLog = "Skill Recieved \n";
            return Ok(LogData().GetLogData(newLog));
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

            string newLog = "Skill Updated \n";
            return Ok(LogData().GetLogData(newLog));
        }

        //Delete
        [Route("api/NeededSkill/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = Service();

            if (!service.DeleteNeededSkill(id))
                return InternalServerError();
            
            string newLog = "Skill Dleted \n";
            return Ok(LogData().GetLogData(newLog));
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