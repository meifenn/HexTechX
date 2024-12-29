using Blazored.LocalStorage;
using Infra.Helpers.ApiRequestHelper;
using Infra.Helpers.ApiRequestHelper.CommentApiRequest;
using Infra.Helpers.ApiRequestHelper.FriendApiRequest;
using Infra.Helpers.ApiRequestHelper.FriendRequestApiRequest;
using Infra.Helpers.ApiRequestHelper.LikeApiRequest;
using Infra.Helpers.ApiRequestHelper.PostApiRequest;
using Infra.Helpers.ApiRequestHelper.TagApiRequest;
using Infra.Helpers.ApiRequestHelper.UserApiRequest;
using SocialWeb.Client.Pages;
using SocialWeb.Components;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("") });

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7175");
});

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddScoped<ApiRequest>();
builder.Services.AddScoped<IPostApiRequest, PostApiRequestBase>();
builder.Services.AddScoped<IUserApiRequest, UserApiRequestBase>();
builder.Services.AddScoped<ILikeApiRequest, LikeApiRequestBase>();
builder.Services.AddScoped<ICommentApiRequest, CommentApiRequestBase>();
builder.Services.AddScoped<IFriendApiRequest, FriendApiRequestBase>();
builder.Services.AddScoped<IFriendRequestApiRequest, FriendRequestApiRequestBase>();
builder.Services.AddScoped<ITagApiRequest, TagApiRequestBase>();

builder.Services.AddBlazoredLocalStorage();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
{
    options.DetailedErrors = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SocialWeb.Client._Imports).Assembly);

app.Run();
