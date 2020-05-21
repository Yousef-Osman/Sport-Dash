using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class QuestionRepoitory:IQuestionRepository
    {
        ApplicationDbContext _context;
        public QuestionRepoitory(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Question> GetAllQuestion()
        {
            //var questions = _context.Questions.ToList();
            //if (questions != null)
            //{
            //      return questions;
            //}

            return new List<Question>();
        }
        public Question GetQuestion(int id)
        {
            //var question = _context.Questions.Find(id).FirstOrDefault();
            //if (question != null)
            //{
            //      return question;
            //}
            return new Question();
        }
        public void Update(int id , Question quest)
        {
            //var question = _context.Questions.Find(id).FirstOrDefault();
            //if (question != null)
            //{
            //    question.Body = quest.Body;
            //    question.DateTime = DateTime.Now;
            //    _context.SaveChanges();
            //}
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
        public void Ask(Question question)
        {
            //_context.Questions.Add(question);
            //_context.SaveChanges();
        }
    }
}
