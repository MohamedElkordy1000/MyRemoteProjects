using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogging_system.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Blogging_system.Controllers.Hubs
{
    [HubName("chat")]
    public class ChatHub:Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void sendComment(string CommentOwnerID,string CommentText, DateTime PublishDate,int ArticleID)
        {
            Clients.All.newComment( CommentOwnerID,  CommentText,  PublishDate, ArticleID);
            Comment comment = new Comment() { ArticleId = ArticleID, MemberId = CommentOwnerID, CommentDate = PublishDate, CommentText = CommentText };
            db.Comments.Add(comment);
            db.SaveChanges();

        }
    }
}