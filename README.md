# ConsoleToAsp
Send data from a console application to an ASP.NET website and save the data in a database

Technologies used:
  Client - Windows Console Application, using HttpClient lib. to send a POST request to the server.
  Web - ASP.NET 5 with MVC 6
  DB - Code first Entity Framework

I learned alot along the way but did not find the time to implement it.
This is a test version of my project, not the final release I intended.
Thus it includes unnecessary code (like asp.net identity and other autogenerated code, which is never used).

Further I'd like to note that this project would benefit from using a repository pattern and units of work,
to decouple the database logic and to allow smoother further development.

The console client ia not very testable, although for the porpouses of this project using the POSTMAN software was enough to verify its use. 
It also does not give the user any feedback in it self, doesn't handle exceptions or has any logic implemented to receive any response from the server.
[EDIT]
The console client is now handling exceptions and now also gives user feedback on POST request with response status.
