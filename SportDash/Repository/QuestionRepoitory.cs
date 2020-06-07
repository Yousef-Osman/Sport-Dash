using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class QuestionRepoitory : IQuestionRepository
    {
        ApplicationDbContext _context;
        public QuestionRepoitory(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Question> GetQuestionByUser(String userId)
        {
            List<Question> questions = _context.Questions.Where(question => question.UserId == userId).ToList();
            return questions;
        }

        public List<Question> GetQuestionByCategory(QuestionAbout category)
        {
            List<Question> questions = _context.Questions.Where(question => question.Category == category).ToList();
            return questions;
        }
        public Question GetQuestion(int id)
        {
            var question = _context.Questions.Find(id);
            return question;
        }
        public bool Update(Question Updatedquestion)
        {
            var question = _context.Questions.Find(Updatedquestion.Id);
            if (question != null)
            {
                question.Body = Updatedquestion.Body;
                question.LastUpdateTime = Updatedquestion.LastUpdateTime;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public void Delete(int id)
        {
            //var question = _context.Questions.Find(id).FirstOrDefault();
            //if (question != null)
            //{
            //    _context.Questions.Remove(question);
            //    _context.SaveChanges();
            //}
        }
        public Question Ask(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return question;
        }
    }
}
