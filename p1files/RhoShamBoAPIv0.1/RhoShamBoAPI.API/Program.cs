//we know that we need to read in a connection string from somewhere

using RhoShamBoAPI.Data;


//******************* MIGHT BE DIFFERENT PATH FOR EACH COMPUTER ***************************
string connectionString = await File.ReadAllTextAsync("C:/Users/Hau/source/repos/ConnectionStrings/FirstRevatureDB.txt");

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// this adds a singleton (single object) of InterfaceRepository called with a lambda function ( =>), argument to lambda function is sp.
// sp is very specific to dotnet, you can use any var instead of sp, but it would be anyvar.GetRequiredService
builder.Services.AddSingleton<InterfaceRepository>(sp => new SQLRepository(connectionString, sp.GetRequiredService<ILogger<SQLRepository>>()));


var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger Integration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
