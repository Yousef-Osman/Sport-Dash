using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    interface IQuestionRepository
    {
        public List<Question> GetAllQuestion();
        public Question GetQuestion(int id);
        public void Update(int id, Question quest);
        public void Delete(int id);
        public void Ask(Question question);
    }
}
