using XerifeTv.CMS;
using XerifeTv.CMS.MongoDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<DBSettings>(
  builder.Configuration.GetSection("MongoDBConfig"));

builder.Services.AddConfiguration(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment()) 
{
  app.Urls.Add("http://*:80");
  app.UseHsts();
} 

app.UseStatusCodePages(context =>
{
  var response = context.HttpContext.Response;

  if (response.StatusCode == 401)
    response.Redirect("/Users/SignIn");
  
  if (response.StatusCode == 403)
    response.Redirect("/Users/UserUnauthorized");

  if (response.StatusCode == 404)
    response.Redirect("/");

  return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Content API version 1");
  c.RoutePrefix = "Api";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
