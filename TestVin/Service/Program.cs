using PostgreDAL.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>((sp, options) =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));


var app = builder.Build();

app.Run();
