using Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialAPI.Services.Auth;
using SocialAPI.Services.Comments;
using SocialAPI.Services.FriendRequests;
using SocialAPI.Services.Friends;
using SocialAPI.Services.Likes;
using SocialAPI.Services.Posts;
using SocialAPI.Services.Tags;
using SocialAPI.Services.Users;

var allowedSpecificOrigin = "_allowedSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedSpecificOrigin,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7027")
                          .AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                      });
});

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
//sqlOptions =>
//{
//    sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
//});
);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPost>(s => new PostBase(
    s.GetService<AppDbContext>()
    ));

builder.Services.AddScoped<IUser>(s => new UserBase(
    s.GetService<AppDbContext>()
    ));
builder.Services.AddScoped<ILike>(s => new LikeBase(
    s.GetService<AppDbContext>(),
    s.GetService<IPost>()
    ));
builder.Services.AddScoped<IComment>(s => new CommentBase(
    s.GetService<AppDbContext>(),
    s.GetService<IPost>()
    ));
builder.Services.AddScoped<IFriend>(s => new FriendBase(
    s.GetService<AppDbContext>()
    ));
builder.Services.AddScoped<IFriendRequest>(s => new FriendRequestBase(
    s.GetService<AppDbContext>()
    ));
builder.Services.AddScoped<ITag>(s => new TagBase(
    s.GetService<AppDbContext>()
    ));
builder.Services.AddScoped<IAuthentication>(s => new Authentication(
    s.GetService<AppDbContext>()
    ));



var app = builder.Build();
app.UseCors(x => x
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true)
          .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
