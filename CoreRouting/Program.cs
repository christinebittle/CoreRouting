var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// API help page on /Swagger/Index.html
// Tools > NuGet Package Manager > Manage NuGet Packages
// Install Swashbuckle.AspNetCore.SwaggerUI
// Install Swashbuckle.AspNetCore.SwaggerGen
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Include these lines to activate Swagger API page
app.UseSwagger();
//app.UseSwaggerUI();

app.UseSwaggerUI(c =>
{
    //Configuration option to use cURL (bash), cURL (PowerShell), cURL (CMD)
    c.ConfigObject.AdditionalItems.Add("requestSnippetsEnabled", true);
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
