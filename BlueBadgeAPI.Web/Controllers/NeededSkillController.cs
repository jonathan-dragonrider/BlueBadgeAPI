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
    public class NeededSkillController : ApiController
    {
        private NeededSkillService CreateProjectService()
        {
            var userId = User.Identity.GetUserId();
            var neededSkillService = new NeededSkillService();
            return neededSkillService;
        }

        //Post
        public IHttpActionResult Post(NeededSkillCreate neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.NeededSkillCreate(neededSkill))
                return InternalServerError();
            return Ok();

        }

        //Get
        public IHttpActionResult Get()
        {
            NeededSkillService projectService = CreateProjectService();
            var projects = projectService.GetNeededSkill();
            return Ok();
        }

        //Get
        public IHttpActionResult Get(int id)
        {
            NeededSkillService projectService = CreateProjectService();
            var projects = projectService.GetNeededSkillById(id);
            return Ok(projects);
        }

        //Put
        public IHttpActionResult Put(NeededSkillDetails neededSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateNeededSkill(neededSkill))
                return InternalServerError();

            return Ok();
        }


        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProjectService();

            if (!service.DeleteNeededSkill(id))
                return InternalServerError();

            return Ok();
        }
    }
}

