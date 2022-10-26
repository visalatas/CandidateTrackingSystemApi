using CandidateCore.Repository;
using CandidateCore.UnitOfWorks;
using CandidateRepository;
using CandidateRepository.Repositories;
using CandidateRepository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add db context

builder.Services.AddDbContext<CondidateDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConnection"], option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(CondidateDbContext)).GetName().Name);
    });
});

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));



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

app.Run();
