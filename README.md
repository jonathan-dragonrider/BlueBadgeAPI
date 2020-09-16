CONTENTS FOR THIS FILE
----------------------
INTRODUCTION\r
REQUIRMENTS
INSTALLATION
USE
MAINTAINERS
FUTURE ADDITIONS	

INTRODUCTION
-------------

Project: Together In Teams

Together In Teams is a community based, creator focused API. The goal of this application is to bring creative people together
and to facilitate collaboration on user created projects.

In this application users have the ability to create projects, set up teams, as well as search for open projects to join.


REQUIRMENTS
------------
This module requires you to have Microsoft Visual Studio. You can download this program here https://visualstudio.microsoft.com/downloads/. You must also have access to POSTMAN. 
If you do not have it you can dowlaod that here https://www.postman.com/downloads/. 
The following Nuget Pacackages should be already installed when you download to Visual Studio. However you may need to update some of the versions. 
Please verify the follwing NuGet packages are present before using the application:

Antlr v3.5.0.2
bootstrap v4.5.2
EntityFramework v6.4.4
jQuery v3.5.1
jQuery.Validation v1.19.2
Microsoft.aspNet.Identity.Core v2.2.3
Microsoft.AspNet.Identity.EntityFramework v2.2.3
Microft.AspNet.Identity.Orwin v2.2.3
Microsoft.AspNet.WebApi v5.2.7
Microsoft.AspNet.WebApi.Client v5.2.7
Microsoft.AspNet.WebApi.Core v5.2.7
Microsoft.AspNet.WebApi.HelpPage v5.2.7
Microsoft.AspNet.WebApi.Owin v4.1.1
Microsoft.AspNet.WebApi.WebHost v5.2.7
Microsoft.CodeDom.Providers.DotNetCompilerPlatform v3.6.0
Microsoft.jQuery.Unobtrusive.Validation v3.2.11
Microsoft.Owin v4.1.1
Microsoft.Owin.Host.SystemWeb v4.1.1
Microsoft.Owin.Security v4.1.1
Microsoft.Owin.Security.Cookies v4.1.1
Microsoft.Owin.Security.Facebook v4.1.1
Microsoft.Owin.Security.Google v4.1.1
Microsoft.Owin.Security.MicrosoftAccount v4.1.1
Microsoft.Owin.Security.OAuth v4.1.1
Microsoft.Owin.Security.Twitter v4.1.1
Microsoft.Web.Infrastructure v1.0.0
Modernizr v2.8.3
Newtonsoft.Json v12.0.3
Owin v1.0.0
popper.js v1.16.1
WebGrease v1.6.0


INSTALLATION
------------

If you have Visual Studio Code already then you will need to click the download code button in GitHub to complete the download and installation.



USE
----------

*Getting Started*

Once you have fully installed the application you will have to run the program to begin. Start by clicking the Play button at the top of the screen.



This should bring up the ASP.Net Homepage. From here please click on the API tab which will take you to the HELP page laying out all the possible things that can be done within POSTMAN.

At this point you will need to open POSTMAN. Before you can do anything with this application you must establish yourself as a User.

*Signing In As A User*

In order to sign up as a user you will need to copy the URL from the ASP.Net page and paste it in the POSTMAN url bar. Make sure that you switch from GET to POST.

Then, in the body fiels please create three Headings. Email, Password, and ConfirmPassword, About, FirstName, and LastName. Then on the right please enter the email you wish to use, as well as the password and Name you wish to use.
For the About Section you can enter anything you want other users to know about you or your skills/experiences.
The password must be 6 characters or more, and must have a symbol and a number included.

If your screen displays a 200 Ok status then you are good to move on. 

Next you will need to create a new request. In the body field change the headings to grant_type, username, and password. Then on the left hand side please add the word password accraoos for grant_type
and your email and created password accorss for username and password.

Once you do that you should be given a "bearer" token. 

For the last step you will need to go into the header section and creat a new section titled "Authorization". In this section type in the word bearer followed by the token you were given.

This token identifies you within the application and is the authorization you will need to make any changes, creations, or updates going forward.

Now that you are established as a user you are good to edit your profile, create projects/teams, and search for other creative individuals who have the skills you are looking for. 

We will start with editing your profile.

*Editing Your Profile*

To add Skills to your profile you must create a new request. In the POSTMAN url you will change it to Post and add /api/UserSkills
to the end of your localhost url.

The you will create two keys in the body Skill and UserId. The Skill is whatever you want to add, and the UserId is obtained from the Application user data table in Visual Studio.

After you add these two sections in and hit send you should get a 200 Ok message.

Feel free to add as many skills as you want. You can also update or delete skills by usung the Delete and Put functions in POSTMAN and their cooresponding APIs from ASP.NET.

We have only just scratched the surface of what we can do, however. Next we will look at creating a project and setting up the Skill you will need to fulfill your vision.


*Creating a Project*

To create a project please start by creating a new request in POSTMAN. Change the function to Post and add in api/Project.

In the body section please add the following keys UserID, Title, and Description.

The UserID will be your UserID from before and the Title and Description will be whatever you want to put in there.

After you complete these steps you will now have a Project tied to your Userid. You will henceforth be considered the Project Owner.

From here you can create more projects, update existing projects, or delete them. Like with user you just have to use the Put or Delete functions on POSTMAN along with the corresponding APIs in ASP.NET.
 
 Now we will focus on adding the skills you will need to complete your project.

 *Add Needed Skills*

 To add Needed Skills to you campaign you must first create a new request in POSTMAN. Make sure you have the function set to Post.

 From here you need to add the following keys ProjectId and Skill. Skill will obviously be the skill you require, and the ProjectId will be collected from the Project datatable in Visual Studio much like how we got UserId.

 Once you add all this in hit send and you should be presented with a 200 Ok message. 

 From here you can add more skills in, update exisiting ones or delete them.

 It should be noted that you are the only one able to preform these functions for Projects you create, and you cannot do this for projects created by others.

Now that we have our skills added to our project we will review who to create teams to house our future collaborators.


*Add Teams*

Add in a team is rather simple. As before you must create a new request in POSTMAN. After changing the function to Post add in the following keys ProjectId and Name. 

The name will be the name of your tema and the PojectId should coorespond to the project in which you wish to add the Team.

This should lead to a 200 Ok message when you hit enter.

Feel free to create more teams should you require them. You can also delete teams or update/edit them.

Next we will discuss adding other memebers to your team.

*Adding Team Assignments*

To add a team member to at team you will need to create a new request in POSTMAN. From here you will need to create a Post function and add /api/Assignment.

The keys you will need are as follows TeamId, ProjectId, and UserId. All of these Ids can be found within their cooresponding data tables in Visual Studio.

Once these are entered in correctly you should recieve a 200 Ok message. 

From here you can add more users to your already existing team, remove users, or create new teams and move users from one team to another.

Now that we have our teams set it is time to get to work! Congrats you have taken your first step toward realizing you vision.

To wrap things up the next section will just deal with some features that will help you find a project if you are looking for work that matches your skill set..

*Searching For Users By Skill*

Lets say you are a user, but you do have a project you are currently working on, but you want to see if there are any users who have similar skills that you want to connect

To do that you will have to search the user database based on the skill you are interested in.

After you create a new request in POSTMAN make sure the function is set to Get not Post. 

Next add in the following ADI from ASP.Net, api/Account/{skill}

In the skill portion you will add in the skill you are searching for and then hit send. A list of all users with that skill should then be presented to you.

*Searching for Projects by Skill*

So lets say you are looking to join a team and you want to know if their ar any projects out there that currently require your skill set. 

We give you the ability to search for projects based on skill.

To do this you need to first create a new request in POSTMAN. Next make sure your function is set to Get and you are using the API /api/Project.{Skill}.

As before the skill portion should be replaced with whatever skill you want to search for.

After pluggin everything in you should be presented with a list for the projects that require your skill.

*Activity Log*

The most recent edition to the application has been the creation of an activity log. Now whenever you preform any function within the application that will be logged and storred on a datatable for future reference. 

To pull this log simply go to POSTMAN open a new request and using the Get function add in the API api/Log and all activity ever preformed on the platform will be pulled for you to review.


MAINTAINERS
---------------------

Kyle Rambo (Kyle Rambo) krambo89@gmail.com
Alex Blansette (Alex Blansette) alexander.blansette@gmail.com
Jon Kline (Jon Kline) jonphilk@gmail.com

This project was entirely self funded, and was made possible thanks to the hard work and dedication of the contributor listed above.

Future Additions
-------------

We hope to add a "Save Team" feature so project leaders can more easily reachout to individuals they have worked with in the past regarding future projects.

We also hope to update the log functionality so that it can be filtered by User, Team, or Project.

Furthermore addition security/privacy features and updated front end functionality will follow in the next 6 months.



If there are any  bugs or issues with the program please forward questions on to krambo89@gmail.com, alexander.blansette@gmail.com, or jonphilk@gmail.com.
