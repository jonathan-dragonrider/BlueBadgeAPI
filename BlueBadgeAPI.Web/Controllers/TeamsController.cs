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
    public class TeamsController : ApiController
    {
        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var TeamService = new TeamService(userId);
            return TeamService;
        }

        //Post
        public IHttpActionResult Post(TeamCreate Team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.TeamCreate(Team))
                return InternalServerError();

            return Ok();
        }

        //Get
        public IHttpActionResult Get()
        {
            TeamService TeamService = CreateTeamService();
            var Teams = TeamService.GetTeams();
            return Ok(Teams);
        }
        public IHttpActionResult GetAll()
        {
            TeamService TeamService = CreateTeamService();
            var Teams = TeamService.GetTeams();
            return Ok(Teams);
        }

        //Get
        public IHttpActionResult Get(int id)
        {
            TeamService TeamService = CreateTeamService();
            var Teams = TeamService.GetTeamById(id);
            return Ok(Teams);
        }

        //Put
        public IHttpActionResult Put(TeamDetails Team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.UpdateTeam(Team))
                return InternalServerError();

            return Ok();
        }


        //Delete
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();

            if (!service.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
    }
}
