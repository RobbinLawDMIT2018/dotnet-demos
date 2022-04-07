# Deliverable 2 - **Project Setup and Security**

There are three stages to accomplishing the setup of your solution.

1. **Project Setup**
1. **Subsystem Setup**
1. **Security Setup**

Your instructor has provided a `start-kit` that may include some of the infrastructure needed for this deliverable. All team members are expected to complete items not provided in the `start-kit`.

The first stage is to be completed by all team members. **Use GitHub issues** to delegate specific tasks among your team members; divide up the tasks as equitably as possible.

For the second stage, each team member must set up a class library for their selected scenario. This will reduce the possibility of merge conflicts as each scenario will be in a separate class library.

**Each** member **must** demonstrate their participation in the project setup by making small, meaningful commits. When performing commits of your code, be sure to reference the issue number in your commit so that your work can be easily distinguished by your instructor.

## Stage 1 - Project Setup

Using the techniques and practices demonstrated in class, set up the repository Web App Project files by generating the following items.


- [ ] **Web Application Project**
  - *This should be the first project in the solution, so that it opens as the default startup project.*
  - Use **individual accounts** for the authentication when setting up the Web App Project.
  - Use Bootsrap or custom CSS to style the Web App Razor Pages.
  - Create subfolders in the `Pages` folder of the Web App Project for each subsystem, to organize the pages related to each subsystem. This will also help reduce the possibility of merge conflicts. Ensure there is a *default page* for each subfolder as well as a *manage* page.
    - In the *default page* include the name of the team member implementing that particular subsystem.
    - Security information will also be included in the *default page* later.
    - In the *manage page* include all of the code to implement the subsystem. 
  - Site layout must include working navigation to pages for each subsystem.
  - Use [**user secrets**](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows) (e.g.: *connection string* values).

<!-- RESTORE NEXT SEMESTER

- [ ] [**Application User customization**](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-5.0#customize-the-model)
  - Add a nullable reference to the Employee's ID
- [ ] **Seed the database**
  - Add all the employees as users in the database
  - Use a default password generated from a *user secret*
  - Generate usernames in the form of `firstName.lastName`
  - Generate emails in the form of `firstName.lastName@eBikes.edu.ca`
- [ ] **Customize the User Experience**
  - Remove the ability for users to register on the site
- [ ] **Set an Authorization Policy**
  - Authorize the logged-in user (*Employee*) based on the values in the `Positions` table of the database
-->

## Stage 2 - Subsystem Setup

- [ ] **Class Library Projects for each Subsystem**
  - Each team member must create a **class library project** for their subsystem. 
  - In that library, reverse engineer the database including only the tables relevant to your subsystem.
  - The DLL context will also contain the necessary code to access only the tables relevant to your subsystem.


## Stage 3 - Security Setup

Only do this step ***after*** your instructor has demonstrated how to implement security. 

Using the techniques discussed in class, customize the default authentication that was generated when the project was first set up.

> ***NOTE:** Follow the [step-by-step instructions](./Addendum-Security/ReadMe.md) for this semester's handling of security.

----

*Back to the [General Instructions](../specs-general.md)*
