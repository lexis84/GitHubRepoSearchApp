using GitHubSearchApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.DictionaryKeyPolicy = null;
        });
builder.Services.AddSession(options =>
{
});
builder.Services.AddScoped<IRepoSearchService, RepoSearchService>();
//builder.Services.AddTransient<ISessionManagerService, SessionManagerService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.UseEndpoints(endpoints =>
{
});

app.MapRazorPages();
app.Run();