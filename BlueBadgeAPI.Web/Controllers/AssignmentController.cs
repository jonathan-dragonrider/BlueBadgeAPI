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
    public class AssignmentController : ApiController
    {
        public AssignmentService CreateAssignmentService()
        {
            var assignmentService = new AssignmentService();
            return assignmentService;
        }
        private LogService CreateLogService()
        {
            var logService = new LogService();
            return logService;
        }


        /// <summary>
        /// Create an assignment.
        /// </summary>
        [Route("api/Assignment")]
        [HttpPost]
        public IHttpActionResult Post(AssignmentCreate assignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAssignmentService();

            if (!service.AssignmentCreate(assignment))
                return InternalServerError();

            string newLog = "Assignment Created";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }

        /// <summary>
        /// Get all assignments.
        /// </summary>
        public IHttpActionResult Get()
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignments();

            string newLog = "All Assignments Recieved";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(assignments);
        }

        /// <summary>
        /// Get an assignment by Id.
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignmentById(id);

            string newLog = "Assignment Recieved By Id";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(assignments);
        }

        /// <summary>
        /// Update existing assignment.
        /// </summary>
        public IHttpActionResult Put(AssignmentEdit assignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAssignmentService();

            if (!service.UpdateAssignment(assignment))
                return InternalServerError();

            string newLog = "Assignment Updated";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }

        /// <summary>
        /// Delete existing assignment.
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAssignmentService();

            if (!service.DeleteAssignment(id))
                return InternalServerError();

            string newLog = "Assignment Deleted";
            var logService = CreateLogService();
            logService.LogCreate(newLog);

            return Ok(newLog);
        }
    }
}
