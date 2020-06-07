using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface ICommentRepository
    {
        public List<Comment> GetAllCommentsForQuestion(int qestID);
        public Comment GetComment(int id);
        public void Update(int id, Comment com);
        public void Delete(int id);
        public Comment AddComment(Comment comment);
    }
}