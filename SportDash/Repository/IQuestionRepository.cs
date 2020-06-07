using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IQuestionRepository
    {
        public List<Question> GetQuestionByUser(String id);
        public List<Question> GetQuestionByCategory(QuestionAbout category);
        public Question GetQuestion(int id);
        public bool Update(Question quest);
        public void Delete(int id);
        public Question Ask(Question question);
    }
}
