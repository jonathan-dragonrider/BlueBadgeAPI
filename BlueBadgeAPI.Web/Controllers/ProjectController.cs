using BlueBadgeAPI.Data;
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

        /// <summary>
        /// Create a project.
        /// </summary>
        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.ProjectCreate(project))
                return InternalServerError();
            return Ok("Project Created");

        }

        /// <summary>
        /// Get all projects.
        /// </summary>
        public IHttpActionResult Get()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();
            return Ok("Projects Recieved");
        }

        /// <summary>
        /// Find projects by desired skills.
        /// </summary>
        [Route("api/Project/{skill}")]
        public IHttpActionResult GetByNeededSkill(string skill)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectByNeededSkill(skill);
            return Ok("Projects Recieved");
        }

        /// <summary>
        /// Get project by Id.
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectById(id);
            return Ok("Projects Recieved");
        }

        /// <summary>
        /// Update existing project.
        /// </summary>
        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProject(project))
                return InternalServerError();

            return Ok("Project updated");
        }

        /// <summary>
        /// Delete existing project.
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProjectService();

            if (!service.DeleteProject(id))
                return InternalServerError();

            return Ok("Project deleted");
        }
    }
}
