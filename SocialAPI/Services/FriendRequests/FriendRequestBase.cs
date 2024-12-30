using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialAPI.Services.FriendRequests
{
    public class FriendRequestBase : IFriendRequest
    {
        private readonly AppDbContext _context;
        DateTime now;
        public FriendRequestBase(AppDbContext ctx)
        {
            _context = ctx;
            now = DateTime.Now;
        }
        public async Task<string> SendFriendRequest(FriendRequest req)
        {
            var existing = _context.FriendRequests
                .FirstOrDefault(x => x.FromUserID == req.FromUserID && x.ToUserID == req.ToUserID);
            if (existing != null)
            {
                var deleteRes = await RemoveFriendRequest(existing);
                return deleteRes;
            }

            var reqUser = await _context.Users.FindAsync(req.FromUserID);
            if (reqUser != null)
            {
                req.FromUserName = reqUser.UserName;
            }
            var sentUser = await _context.Users.FindAsync(req.ToUserID);
            if (sentUser != null)
            {
                req.ToUserName = sentUser.UserName;
            }

            req.RequestedTime = now;
            req.IsAccepted = null;
            await _context.FriendRequests.AddAsync(req);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }
        public async Task<List<FriendRequest>> GetFriendRequest(int userId)
        {
            var query = _context.FriendRequests.Where(a => a.ToUserID == userId && a.IsAccepted == null).AsNoTracking();
            return await query.ToListAsync() ?? new List<FriendRequest>();
        }
        public async Task<string> RespondFriendRequest(int Id, bool? IsAccept = true)
        {
            var friReq = await _context.FriendRequests.FindAsync(Id);
            if(friReq is null)
            {
                return "friend request does not exist";
            }

            friReq.IsAccepted = IsAccept;
            string res = "";

            if(IsAccept == true)
            {
                Friend friend = new Friend
                {
                    UserID = friReq.FromUserID,
                    UserName = friReq.FromUserName,
                    FriendID = friReq.ToUserID,
                    FriendName = friReq.ToUserName,
                    RequestedTime = friReq.RequestedTime,
                    AcceptedTime = now,
                };
                await _context.Friends.AddAsync(friend);
                Friend reverseFriend = new Friend
                {
                    UserID = friReq.ToUserID,
                    UserName = friReq.ToUserName,
                    FriendID = friReq.FromUserID,
                    FriendName = friReq.FromUserName,
                    RequestedTime = friReq.RequestedTime,
                    AcceptedTime = now,
                };
                await _context.Friends.AddAsync(reverseFriend);
                var result = await _context.SaveChangesAsync();
                return "success";
            }
            else
            {
                res = await RemoveFriendRequest(friReq);
            }
            return res;
        }
        async Task<string> RemoveFriendRequest(FriendRequest req)
        {
            _context.FriendRequests.Remove(req);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "friend request removed" : "fail";
        }

    
    }
}
