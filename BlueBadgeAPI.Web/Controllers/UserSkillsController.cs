using BlueBadgeAPI.Models;
using BlueBadgeAPI.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeAPI.Web.Controllers
{
    public class UserSkillsController : ApiController
    {
        private UserSkillService CreateUserSkillService()
        {
            var userSkillId = (User.Identity.GetUserId());
            var UserSkillService = new UserSkillService(userSkillId);
            return UserSkillService;
        }

        //Post
        public IHttpActionResult Post(UserSkillCreate userSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserSkillService();

            if (!service.UserSkillCreate(userSkill))
                return InternalServerError();

            return Ok();
        }

        //Get
        public IHttpActionResult Get()
        {
            UserSkillService UserSkillService = CreateUserSkillService();
            var userSkill = UserSkillService.GetUserSkills();
            return Ok(userSkill);
        }
        public IHttpActionResult GetAll()
        {
            UserSkillService UserSkillService = CreateUserSkillService();
            var userSkill = UserSkillService.GetUserSkills();
            return Ok(userSkill);
        }

        

        //Put
        public IHttpActionResult Put(UserSkillDetails userSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserSkillService();

            if (!service.UpdateUserSkill(userSkill))
                return InternalServerError();

            return Ok();
        }


        //Delete
        public IHttpActionResult Delete(int userSkillId)
        {
            var service = CreateUserSkillService();

            if (!service.DeleteUserSkill(userSkillId))
                return InternalServerError();

            return Ok();
        }
    }
}
