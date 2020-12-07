# GymSite

GymSite is your tool to find the right gym for you!  Whether you are a first time gym goer or a seasoned veteran looking for new equipment to try out, GymSite will help you save time in your search so you can get going on your goals.  No more uninformative websites, no more driving to gyms to just be disappointed in your options, just a quick search and you'll know exactly what a gym has to offer.

GymSite's primary market is younger men and women, but is not necessarily limited to any age bracket.  We want to take in user input about gyms that they've gone to in order to fill our database.  The geographic region will be starting in Indianapolis and expanding outward with time to the entire USA.

To Run Locally:

1) Clone GymSite and build the solution in Visual Studio
1a) If you receive a roslyn error, try the ‘show all files’ fix in the solution explorer where you show all files a few times then reopen Visual Studio.  Otherwise, go to your package manager console and enter the following line: Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
2) Go to Package Manager Console and type Enable-Migrations, then Add-Migration Initial
3) Run the application and create an account!  Create an account to experience what a regular user would.  Login with Danny and adminpass to experience what the admin can do.

I encourage that you login as the admin and seed data to experience how the app is meant to be.  You will need to create a state, a city tied to a state, then create gyms tied to a city.


Resources:

https://stackoverflow.com/ (so many questions answered)

https://www.c-sharpcorner.com/UploadFile/asmabegam/Asp-Net-mvc-5-security-and-creating-user-role/ (didn't follow 100%, used to implement admin and regular user roles)

https://getbootstrap.com/docs/4.0/getting-started/introduction/ (for all design within the .cshtml files)

mdbootstrap.com (more on bootstrap)

www.w3schools.com (more on html/css/bootstrap)

https://www.youtube.com/watch?v=uSIlEY0gX9A&list=FLo47TMLaD1RDkvHZ-impI6A&index=1&t=1158s (didn't follow 100%, helped with incorporating a better rating system)

Thank you to the Eleven Fifty Academy for the great program and guidance as I begin my journey as a software developer!
