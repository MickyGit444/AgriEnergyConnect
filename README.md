AgriEnergyConnect Prototype Application

This is a prototype ASP.NET Core application that was created for data sharing for growers and employees 

The technologies that are used are:

-ASP.NET Core MVC
-Entity Framework Core
-razore views
-Bootstrap style CSS
-session-based authentication

The features are: 

LOGIN
-Log in using predefined users
-session-based authentication
-role-based navigation

GROWERS
-Add harvest items

EMPLOYEES
-Add a new grower
-View and filter harvest

How to run

1- Open the project in Visual Studio
2- in the program.cs make sure this is there 
    - In-memory DB is used:
      ```csharp
      builder.Services.AddDbContext<AgriConnectDbContext>(options =>
          options.UseInMemoryDatabase("AgriConnectMemoryDb"));
      builder.Services.AddSession();
      ```
3- Then click F5 or start debugging with this button ▶️
      

login credentials 

Username                 Password                   Role  
grower1                  grow123                    Grower   
employee1                emp123                     Employee 



