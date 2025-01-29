using Blog.Shared.Data;
using Blog.Shared.Services;
using Blog.WebUI.Components;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// idk 要不要加
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<ArticleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();