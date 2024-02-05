using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SqlServer;
using CamadaDeNegócios.Profiles;
using ApiExpIFoodTNF.Notifications;
using FluentValidation;
using FluentValidation.AspNetCore;
using CamadaDeNegócios.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddTnfAspNetCore(tnf => tnf.DefaultConnectionString(builder.Configuration.GetConnectionString("Sqlite")));

builder.Services.AddEFCoreMssqlServer();

builder.Services.AddTnfAutoMapper(config => 
{
    config.AddProfile<EmpresaProfile>();
    config.AddProfile<CategoriaProfile>();
    config.AddProfile<SegmentoProfile>();
    config.AddProfile<ExpProdIFoodProfile>();
    });
builder.Services.AddTransient<IValidator<EmpresaDto>, EmpresaValidation>();
builder.Services.AddTransient<IValidator<CategoriaDto>, CategoriaValidation>();
builder.Services.AddTransient<IValidator<SegmentoDto>, SegmentoValidation>();
builder.Services.AddTransient<IValidator<ExpProdIFoodDto>, ExpProdIFoodValidation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiExpIFood", Version = "v1" });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(op => op.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();

app.Run();