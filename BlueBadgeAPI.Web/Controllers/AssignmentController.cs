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
        private AssignmentService CreateAssignmentService()
        {
            var userId =User.Identity.GetUserId();
            var assignmentService = new AssignmentService(userId);
            return assignmentService;
        }

        //Post
        public IHttpActionResult Post(AssignmentCreate assignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAssignmentService();

            if (!service.AssignmentCreate(assignment))
                return InternalServerError();

            return Ok();
        }

        //Get
        public IHttpActionResult Get()
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignments();
            return Ok(assignments);
        }
        public IHttpActionResult GetAll()
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignments();
            return Ok(assignments);
        }

        //Get
        public IHttpActionResult Get(int id)
        {
            AssignmentService assignmentService = CreateAssignmentService();
            var assignments = assignmentService.GetAssignmentById(id);
            return Ok(assignments);
        }

        //Put
        public IHttpActionResult Put(AssignmentListItems Assignment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAssignmentService();

            if (!service.UpdateAssignment(Assignment))
                return InternalServerError();

            return Ok();
        }


        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAssignmentService();

            if (!service.DeleteAssignment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
