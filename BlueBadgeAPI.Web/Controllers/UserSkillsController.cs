﻿using BlueBadgeAPI.Models;
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

        /// <summary>
        /// Add skill to a user account.
        /// </summary>
        public IHttpActionResult Post(UserSkillCreate userSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserSkillService();

            if (!service.UserSkillCreate(userSkill))
                return InternalServerError();

            return Ok("Skill Created");
        }

        /// <summary>
        /// Get all user skills.
        /// </summary>
        public IHttpActionResult Get()
        {
            UserSkillService UserSkillService = CreateUserSkillService();
            var userSkill = UserSkillService.GetUserSkills();
            return Ok("Skills Reiceved");
        }

        /// <summary>
        /// Update existing user skill.
        /// </summary>
        public IHttpActionResult Put(UserSkillDetails userSkill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserSkillService();

            if (!service.UpdateUserSkill(userSkill))
                return InternalServerError();

            return Ok("Skill Updated");
        }

        /// <summary>
        /// Delete existing user skill.
        /// </summary>
        public IHttpActionResult Delete(int userSkillId)
        {
            var service = CreateUserSkillService();

            if (!service.DeleteUserSkill(userSkillId))
                return InternalServerError();

            return Ok("Skill Delete");
        }
    }
}
