# Assignment

- Provide 2 http endpoints that accepts JSON base64 encoded binary data on both endpoints
  - <host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right 
- The provided data needs to be diff-ed and the results shall be available on a third end point 
  - <host>/v1/diff/<ID> 
- The results shall provide the following info in JSON format 
  - If equal return that 
  - If not of equal size just return that 
  - If of same size provide insight in where the diffs are, actual diffs are not needed. 
	- So mainly offsets + length in the data 
- Make assumptions in the implementation explicit, choices are good but need to be communicated 
 

# Requirements for running
- Windows / Linux / MacOs
- [Visual Studio Comunity](https://visualstudio.microsoft.com/vs/community/) (prefereable 2017/2019) or any other prefered code editor ([Vs Code :D](https://code.visualstudio.com/))
- [Sql Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express) or and SqlServer Db installed elsewhere
- [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)

# Running Application
1. If using a local SqlServer proceed to 2, otherwise remember to change the value from ConnectionStrings under the file `appsettings.json` pointing to your database.
2. Make Shure you have conected to your Sql Server Local DB (possibly ServerName: "(LocalDb)\MSSQLLocalDB")
and run the scripts that create the database and tables.

	Scripts at:

   `dbScripts/create_db.sql`

2. Open a console and run at the root of the project
   > dotnet run

	After that you would be presented with the Swagger Documentation

# Runing Tests
> dotnet test

# Running Tests With Coverage
> dotnet test /p:CollectCoverage=true /p:Exclude="[xunit*]*"

# Sugestion of improvement
- Implementation
	- Implement PUT for updating sides
	- Implement some kind of Authentication and Authorization either by implementing a token generation or by using an external API Manager and validating a JWT Token
- Technical Debt
	- Increase Test Coverage
	- Remove Both Left and Right Repository since they don't make sense anymore
	- Properly handle http responses
	- Create Models and separate the Controler and Repositories
	- Properly handle model validation
