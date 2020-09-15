﻿using BlueBadgeAPI.Data;
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
    public class ProjectController : ApiController
    {

        private ProjectService CreateProjectService()
        {
            var projectService = new ProjectService();
            return projectService;
        }

        private LogService CreateLogService()
        {
            var logService = new LogService();
            return logService;
        }

        //Post
        [Route("api/Project")]
        [HttpPost]
        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.ProjectCreate(project))
                return InternalServerError();

            string newLog = "Project Created";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);

        }

        //Get 
        [Route("api/Project")]
        public IHttpActionResult Get()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();

            string newLog = "All Projects Recieved";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(projects);
        }
        //public IHttpActionResult GetAll()
        //{
        //    ProjectService projectService = CreateProjectService();
        //    var projects = projectService.GetAllProjects();
        //    return Ok(projects);
        //}

        [Route("api/Project/skill/{skill}")]
        public IHttpActionResult GetByNeededSkill(string skill)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectByNeededSkill(skill);

            string newLog = "Projects Recieved By Skill";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(projects);
        }

        //Get

        public IHttpActionResult Get(int id)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectById(id);

            string newLog = "Project Recieved By Id";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(projects);
        }

        //Put
        [Route("api/Project/Update")]
        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProject(project))
                return InternalServerError();

            string newLog = "Project Updated";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }

        
        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProjectService();

            if (!service.DeleteProject(id))
                return InternalServerError();

            string newLog = "Project Deleted";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }
    }
}
