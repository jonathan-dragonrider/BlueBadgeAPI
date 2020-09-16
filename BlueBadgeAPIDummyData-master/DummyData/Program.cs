
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DummyData
{   
    class Program
    {
        static async Task Main(string[] args)
        {

            // Post Dummy Users

            var users = DummyData.UserDummyData();

            foreach (var user in users)
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44355/api/Account/Register";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            // Post Dummy Projects

            var projects = DummyData.ProjectDummyData();

            foreach (var project in projects)
            {
                var json = JsonConvert.SerializeObject(project);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44355/api/Project";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            // Post Dummy Teams

            var teams = DummyData.TeamDummyData();

            foreach (var team in teams)
            {
                var json = JsonConvert.SerializeObject(team);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44355/api/Teams";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            // Post Dummy Assignments

            var assignments = DummyData.AssignmentDummyData();

            foreach (var assignment in assignments)
            {
                var json = JsonConvert.SerializeObject(assignment);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44355/api/Assignment";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            // Post Dummy NeededSkills

            var neededSkills = DummyData.NeededSkillsDummyData();

            foreach (var neededSkill in neededSkills)
            {
                var json = JsonConvert.SerializeObject(neededSkill);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44355/api/NeededSkill";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            // Post Dummy UserSkills

            var userSkills = DummyData.UserSkillsDummyData();

            foreach (var userSkill in userSkills)
            {
                var json = JsonConvert.SerializeObject(userSkill);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44355/api/UserSkills";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            Console.ReadLine();

        }


    }


}

