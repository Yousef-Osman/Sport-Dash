using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class CommentRepository: ICommentRepository
    {
        ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Comment> GetAllCommentsForQuestion(int qestID)
        {
            var comments = _context.Comments.Where(c => c.QuestionId == qestID).ToList();
            if (comments != null)
            {
                return comments;
            }
            return new List<Comment>();
        }
        public Comment GetComment(int id)
        {
            return new Comment();
        }
        public void Update(int id,Comment com)
        {
            
        }
        public void Delete(int id)
        {
            
        }
        public Comment AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

    }
}
