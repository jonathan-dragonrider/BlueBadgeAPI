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

        /// <summary>
        /// Create an assignment.
        /// </summary>
        [Route("api/Assignment")]
        public IHttpActionResult Post(AssignmentCreate assignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAssignmentService();

            if (!service.AssignmentCreate(assignment))
                return InternalServerError();

            return Ok("Assignment Created");
        }

        /// <summary>
        /// Get all assignments.
        /// </summary>
        [Route("api/Assignment")]
        public IHttpActionResult Get()
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignments();
            return Ok("Assignments Recieved");
        }

        /// <summary>
        /// Get an assignment by Id.
        /// </summary>
        public IHttpActionResult Get(int id)
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignmentById(id);
            return Ok("Assignments Recieved");
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

            return Ok("Assignment Updated");
        }

        /// <summary>
        /// Delete existing assignment.
        /// </summary>
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAssignmentService();

            if (!service.DeleteAssignment(id))
                return InternalServerError();

            return Ok("Assignment Deleted");
        }
    }
}
