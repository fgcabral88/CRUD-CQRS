using CRUD_CQRS.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CRUD_CQRS.Application.Handlers.Tax; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateTaxHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UpdateTaxHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DeleteTaxHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAllTaxesHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetTaxByIdHandler).Assembly);
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
