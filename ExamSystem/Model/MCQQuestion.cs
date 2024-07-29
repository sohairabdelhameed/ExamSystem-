using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Model
{
    public class MCQQuestion : Question
    {
        // We will use Constructor chaining here in MCQQuestion constructor to call the base class constructor which
        //is Question Class to initialize common properties for a question, such as header, body, mark, answer list,
       // and the ID of the correct answer. This will ensure that the base class's initialization logic is
       // executed before any additional initialization specific to MCQQuestion.
        public MCQQuestion(string header, string body, int mark, List<Answer> answerList, int correctAnswerId)
            : base(header, body, mark, answerList, correctAnswerId) { }
    }
}
