// An ASP.NET Core Web API CRUD With Entity Framework 


using Building_A_Web_API.DATA;
using Microsoft.EntityFrameworkCore;

// for our createBuider many things come from it Our Logging, set up out Dependency Container, It Set Up Our configuration
// for talking to appsetting.Json
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
// service configuration is where we do our dependency Injection builder.Services here means dependency injection. The first method add Has lot of 
// services because they help run the program. so they are our 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<Contact_API_DB_Context>(options => options.UseInMemoryDatabase("ContactsDb"));
builder.Services.AddDbContext<Contact_API_DB_Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Building_A_Web_APIConnectionString")));

//This helps our program to build before running 
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); // This helps our application to run 



//this are the steps taken in building the project :  Install Entity framework core in memory database
                                                    //Create Domain Model
                                                    //create DbContext Class
                                                    //Inject Dbcontext to service in memory data base
                                                    //create controller
                                                    // create Get all contact Method 
                                                    // create Add Contact Method 
                                                    // create connection in your app settings .JSon
                                                    //create  update contact controller method 
                                                    // create et single contact method 
                                                    //create Data contact controller Method 
                                                    //run migration
                                                     //use EF Core SQL Server Dtabase
