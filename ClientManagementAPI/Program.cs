using ClientManagementAPI.Entities;
using ClientManagementAPI.Repository;

string[] users = File.ReadAllLines("users.csv");
foreach (var user in users)
{
    var item = user.Split(";");
    var mockedData = new List<ClientEntity>();
    mockedData.Add(new ClientEntity
    {
        Id = Guid.NewGuid(),
        Comments = new List<CommentEntity>(),
        Email = "martin.novy@gmail.com",
        FirstName = "Martin",
        LastName = "Nový"
    });
    mockedData.Add(new ClientEntity
    {
        Id = Guid.NewGuid(),
        Comments = new List<CommentEntity>(),
        Email = "karel.stary@gmail.com",
        FirstName = "Karel",
        LastName = "Starý"
    });
    ClientsRepository.Clients.Add(item[1], mockedData);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("MyPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();