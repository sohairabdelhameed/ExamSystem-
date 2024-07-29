using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Model
{
    public class TrueFalseQuestion : Question
    {
        // We will use Constructor chaining here in TrueFalseQuestion constructor to call the base class constructor 
        //same like MCQQuestion Class.
        public TrueFalseQuestion(string header, string body, int mark, List<Answer> answerList, int correctAnswerId)
            : base(header, body, mark, answerList, correctAnswerId) { }
    }
}
