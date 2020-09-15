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
        
        //Post
        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.ProjectCreate(project))
                return InternalServerError();
            
            string newLog = "Project Created \n";
            return Ok(LogData().GetLogData(newLog));

        }

        //Get
        public IHttpActionResult Get()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();

            string newLog = "Projects Recieved \n";
            return Ok(LogData().GetLogData(newLog));
        }
        //public IHttpActionResult GetAll()
        //{
        //    ProjectService projectService = CreateProjectService();
        //    var projects = projectService.GetAllProjects();
        //    return Ok(projects);
        //}

        [Route("api/Project/{skill}")]
        public IHttpActionResult GetByNeededSkill(string skill)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectByNeededSkill(skill);

            string newLog = "Projects Recieved \n";
            return Ok(LogData().GetLogData(newLog));
        }

        //Get
        public IHttpActionResult Get(int id)
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjectById(id);

            string newLog = "Project Recieved \n";
            return Ok(LogData().GetLogData(newLog));
        }

        //Put
        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProject(project))
                return InternalServerError();

            string newLog = "Project Updated \n";
            return Ok(LogData().GetLogData(newLog));
        }

        
        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateProjectService();

            if (!service.DeleteProject(id))
                return InternalServerError();

            string newLog = "Project Deleted \n";
            return Ok(LogData().GetLogData(newLog));
        }

        public Log LogData()
        {
            var logOne = new Log();
            return logOne;
        }
    }
}
