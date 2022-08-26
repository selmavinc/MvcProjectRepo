﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCWebApplication.Data;
using MVCWebApplication.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVCWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVCWebApplicationContext") ?? throw new InvalidOperationException("Connection string 'MVCWebApplicationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.MapStudentEndpoints();

app.Run();
