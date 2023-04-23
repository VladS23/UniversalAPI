using UniversalAPI;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

var endPoints = new Endpoints(app);
endPoints.Run();

