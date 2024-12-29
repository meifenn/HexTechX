using Infra.Helpers.Paging;
using Infra.Models;
using Infra.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace SocialAPI.Services.Posts
{
    public class PostBase : IPost
    {
        private readonly AppDbContext _context;
        DateTime current;
        public PostBase(AppDbContext context)
        {
            _context = context;

            current = DateTime.Now;
        }
        public async Task<Post> GetByID(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post ?? new Post();
        }

        public async Task<string> Delete(int id)
        {
            var post = await GetByID(id);
            if(post.ID == 0)
            {
                return "empty post";
            }

            _context.Posts.Remove(post);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }

      
        public async Task<Paging<Post>> GetPaging(int page = 1, int pageSize = 10,string? searchString = null, int? userId = null, string? tag = null)
        {

            var query = _context.Posts.AsQueryable().AsNoTracking();

            if(query is null)
            {
                return new Paging<Post>();
            }

            if(!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(post => EF.Functions.Like(post.Title, $"%{searchString}%") ||
                                            EF.Functions.Like(post.Description, $"{searchString}") ||
                                            EF.Functions.Like(post.UploadedUserName, $"{searchString}"));
            }
            if(!string.IsNullOrEmpty(tag))
            {
                query = query.Where(post => post.Tags.Contains(tag));
            }
            query = query.OrderByDescending(a => a.CreatedTime);
            var pagedList = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            Paging<Post> data = new Paging<Post>();
            data.TotalEntities = query.Count();
            data.TotalPages = (int)Math.Ceiling((double)data.TotalEntities / pageSize);
            data.PageSize = pageSize;
            data.PageNumber = page;
            data.Results = pagedList;
            return data;
        }

        public async Task<string> Insert(Post post)
        {
            await ProcessTags(post.Tags);
            post.LikeCount = 0;
            post.CommentCount = 0;
            post.CreatedTime = current;
            await _context.Posts.AddAsync(post);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }

        public async Task<string> Update(Post post)
        {
            await ProcessTags(post.Tags);
            post.ModifiedTime = current;
            _context.Posts.Update(post);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }
       
        private async Task ProcessTags(string? tags)
        {
            if (string.IsNullOrEmpty(tags)) return;
            var tagList = tags.Split(",").Where(a => !string.IsNullOrEmpty(a));
            if (!tagList.Any()) return;

            foreach (var tag in tagList)
            {
                var existing = await _context.Tags.FirstOrDefaultAsync(a => a.Text.Equals(tag));
                if (existing is null)
                {
                    Tag newTag = new Tag
                    {
                        Text = tag,
                        CreatedAt = current,
                        PostCount = 1,
                    };
                    await _context.Tags.AddAsync(newTag);
                }
                else
                {
                    existing.PostCount += 1;
                    _context.Tags.Update(existing);
                }
            }
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<string> ProcessLikeCount(int postId = 0, bool isIncreasing = true)
        {
            var post = await GetByID(postId);
            if(post.ID == 0)
            {
                return "empty post";
            }

            post.LikeCount = isIncreasing ? post.LikeCount + 1 : post.LikeCount - 1;
            _context.Posts.Update(post);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }

        //private async Task<string?> ProcessPhotos(List<PhotoUpload>? photosList)
        //{
        //    if (photosList is null || !photosList.Any()) return null;

        //    List<string> fileNameList = new List<string>();
        //    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Photos");
        //    Directory.CreateDirectory(uploadPath);

        //    if (!Directory.Exists(uploadPath))
        //    {
        //        Directory.CreateDirectory(uploadPath);
        //    }
        //    foreach (var photo in photosList)
        //    {
        //        var photoString = photo.base64String?.Split(",")[1]; 
        //        if(string.IsNullOrEmpty(photoString))
        //        {
        //            continue;
        //        }
        //        byte[] fileBytes = Convert.FromBase64String(photoString);
        //        var fileName = Guid.NewGuid().ToString() + ".jpg";
        //        var filePath = Path.Combine(uploadPath, fileName);
        //        await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);
        //        fileNameList.Add(fileName);
        //    }
        //    var fileNameStrings = string.Join(",", fileNameList);
        //    return fileNameStrings;

        //}
    }
}
