using BlueBadgeAPI.Models;
using DummyData.Models;
using DummyData.Models.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyData
{
    public class DummyData
    {
        // Users
        public static List<UserCreate> UserDummyData()
        {
            List<UserCreate> users = new List<UserCreate>();

            var email = new string[] {"Sailor@gmail.com", "Cia@gmail.com", "Guitar@gmail.com", "Stevenson@gmail.com", "RealStevenson@gmail.com", "Orange@gmail.com", "Secret@gmail.com", "Eighteen@gmail.com", "Laptop@gmail.com", "Lysol@gmail.com", "Favorite@gmail.com", "BassPlayer@gmail.com", "Joshua@gmail.com", "Micheal@gmail.com", "LoneWolf@gmail.com", "Afinch@gmail.com", "Pb@gmail.com", "Theinigo@gmail.com", "thegreatone@gmail.com", "rbutler@gmail.com", "flagpole@gmail.com", "salty@gmail.com", "crusoe11@gmail.com",  "DGrey@gmail.com", "Heath@gmail.com", "Ahab@gmail.com", "Pmarlowe@gmail.com", "Hanibal@gmail.com", "Bloom@gmail.com", "007@gmail.com", "Gump@gmail.com", "Ratchet@gmail.com", "Heep@gmail.com", "DoLittle@gmail.com", "Granger@gmail.com", "Baggins@gmail.com"};
            var firstName= new string[] {"Jon", "Kyle", "Guy", "Philip", "Steven", "Jimmy", "CIA", "Rachel", "Ukulele", "Anita", "Ben", "Casey", "Small", "Big", "Loner", "Atticus", "Patrick", "Inigo" ,"Jay", "Rhett",  "Randall", "Veruca", "Robinson" ,"Dorian", "HeathCliff", "Captain", "Philip", "Hannibal", "Leopold", "James", "Forrest", "Nurse", "Uriah", "John", "Herminoe", "Frodo"};
            var lastName = new string[] {"Rambo", "Kline", "Man",  "Steven", "Stevenson", "Kilio",  "Guy", "Blansette", "Lysol",  "Pea", "Glenn", "Wilson", "Guns", "Guns", "Stoner", "Finch", "Bateman", "Montoya", "Gatsby", "Butler", "Flagg", "Salt", "Crusoe", "Grey", "X", "Ahab", "Marlowe", "Lecter", "Bloom", "Bond", "Gump", "Ratchet","Heep", "Dolittle", "Granger", "Baggins"};
            var about = new string[] {"BOATS!", "Ill kill you", "Music n stuff", "Steven", "Other Stevenson",  "Jimbo is gross",  "I will kill you more", "Strong af", "I have a laptop", "Haha Funny!",  "Artist", "The best room", "Small Guns",  "Big guns", "Hates Groups",  "I Know the Law",  "Some Say I am Mad", "Looking For The Five Fingered Man", "I’m Rich and I Do Stuff", "I have and never will give a damn!", "Here comes the Man In Black", "I want it now!", "I’m a bit of a loner",  "Enjoy Gazing Deeply into My Own Eyes in the Mirror", "Shout my Name Over The Moors",  "Captain of the Pequod",  "The Original Gumshoe", "Always up for a nice glass of Chianti",  "Some call me an Every Man", "I have a Licence to Kill", "Champion Runner",  "Greatest Nurse Ever!", "World Class Yes-man",  "Specialize in Animal Linguistics", "Know-it-All",  "Jewelry Expert"};

            for (int i = 0; i < email.Length; i++)
            {
                var user = new UserCreate()
                {
                    Email = email[i],
                    Password = "1Tunapotato!",
                    ConfirmPassword = "1Tunapotato!",
                    FirstName = firstName[i],
                    LastName = lastName[i],
                    About = about[i]
                };

                users.Add(user);

            }

            return users;

        }

        // Projects
        public static List<ProjectCreate> ProjectDummyData()
        {
            List<ProjectCreate> projects = new List<ProjectCreate>();

            var creatorUserName = new string[] { "Sailor@gmail.com",  "Guitar@gmail.com",  "Secret@gmail.com",  "Joshua@gmail.com",  "LoneWolf@gmail.com",  "Theinigo@gmail.com" };
            var title = new string[] { "Sailors", "Music", "Secret", "Coders", "Tea", "FightClub" };
            var description = new string[] { "We Sail And Have Great SeaMenShip", "Musicians n stuff", "Classified", "We code n stuff", "Tea Making Society", "Virtual Fight Club" }
;

            for (int i = 0; i < creatorUserName.Length; i++)
            {
                var project = new ProjectCreate()
                {
                    CreatorUserName = creatorUserName[i],
                    Title = title[i],
                    Description = description[i]
                };

                projects.Add(project);

            }

            return projects;

        }

        // Teams
        public static List<TeamCreate> TeamDummyData()
        {
            List<TeamCreate> teams = new List<TeamCreate>();

            var name = new string[] {"Captain", "CrewMates", "A couple of Guitar Players", "A couple of pianists", "A drummer and singer", "FrontEnd", "BackEnd"};

            for (int i = 0; i < name.Length; i++)
            {
                var team = new TeamCreate()
                {
                    Name = name[i],
                };

                teams.Add(team);

            }

            return teams;
        }

        // Assignments
        public static List<AssignmentCreate> AssignmentDummyData()
        {
            List<AssignmentCreate> assignments = new List<AssignmentCreate>();

            var userName = new string[] {"Sailor@gmail.com", "Orange@gmail.com", "Ahab@gmail.com", "Stevenson@gmail.com", "Eighteen@gmail.com", "DoLittle@gmail.com", "Hanibal@gmail.com", "Guitar@gmail.com", "Ratchet@gmail.com", "Secret@gmail.com", "Cia@gmail.com", "007@gmail.com", "BassPlayer@gmail.com", "Joshua@gmail.com", "Micheal@gmail.com", "LoneWolf@gmail.com", "crusoe11@gmail.com", "Theinigo@gmail.com" };
            var teamId = new int[] { 1, 2, 2, 3, 3, 4, 4, 5, 5, 1, 1, 1, 6, 6, 7, 1, 1, 1};
            var projectId = new int[] {1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 6};

            for (int i = 0; i < userName.Length; i++)
            {
                var assignment = new AssignmentCreate()
                {
                    UserName = userName[i],
                    TeamId = teamId[i],
                    ProjectId = projectId[i]
                };

                assignments.Add(assignment);

            }

            return assignments;

        }

        // NeededSkills
        public static List<NeededSkillCreate> NeededSkillsDummyData()
        {
            List<NeededSkillCreate> neededSkills = new List<NeededSkillCreate>();

            var skill = new string[] { "Navigation skills", "Rowing skills", "Seamanship", "Singing", "Drumming", "Piano Skills", "Guitar skills",  "Espionage", "Spy skills", "Software development skills", "Web development skills", "Tea making", "Tea drinking" };
            var projectId = new int[] { 1, 1, 1, 2, 2, 2, 2, 3, 3, 4, 4, 5, 5 };

            for (int i = 0; i < skill.Length; i++)
            {
                var neededSkill = new NeededSkillCreate()
                {
                    Skill = skill[i],
                    ProjectId = projectId[i]
                };

                neededSkills.Add(neededSkill);

            }

            return neededSkills;
        }

        // UserSkills
        public static List<UserSkillCreate> UserSkillsDummyData()
        {
            List<UserSkillCreate> userSkills = new List<UserSkillCreate>();

            var skill = new string[] { "Seamanship", "Espionage", "Guitar skills", "Guitar skills", "Graphic designer", "Strength", "Espionage", "Strength", "Guitar skills", "Comedy Writer", "Artist", "Chef", "Coder", "Coder", "Coder", "Tea making", "Lawyer", "Fighter", "Fighter", "Financier", "Fighter", "Magician", "Model", "Tea drinking", "Model", "Financier", "Seamanship", "Navigation", "Researcher", "Pianist", "Chef", "Advertising", "Spy skills", "Athlete", "Drumming", "lawyer", "Piano skills", "Witch", "Adventurer" }
;
            var userName = new string[] {"Sailor@gmail.com", "Cia@gmail.com", "Guitar@gmail.com", "Stevenson@gmail.com", "RealStevenson@gmail.com", "Orange@gmail.com", "Secret@gmail.com", "Eighteen@gmail.com", "Laptop@gmail.com", "Lysol@gmail.com", "Favorite@gmail.com", "BassPlayer@gmail.com", "BassPlayer@gmail.com", "Joshua@gmail.com", "Micheal@gmail.com", "LoneWolf@gmail.com", "Afinch@gmail.com", "Pb@gmail.com", "Theinigo@gmail.com", "thegreatone@gmail.com", "rbutler@gmail.com", "flagpole@gmail.com", "salty@gmail.com", "crusoe11@gmail.com",  "DGrey@gmail.com", "Heath@gmail.com", "Ahab@gmail.com", "Ahab@gmail.com", "Pmarlowe@gmail.com", "Hanibal@gmail.com", "Hanibal@gmail.com", "Bloom@gmail.com", "007@gmail.com", "Gump@gmail.com", "Ratchet@gmail.com", "Heep@gmail.com", "DoLittle@gmail.com", "Granger@gmail.com", "Baggins@gmail.com"};

            for (int i = 0; i < skill.Length; i++)
            {
                var userSkill = new UserSkillCreate()
                {
                    Skill = skill[i],
                    UserName = userName[i]
                };

                userSkills.Add(userSkill);

            }

            return userSkills;
        }

    }
}
