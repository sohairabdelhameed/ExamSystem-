using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Model
{
    public abstract class Question
    {
        //Abstract classes allows us to define common properties and methods that can be shared among multiple derived classes.
        //This avoids code duplication and ensures that common functionality is implemented in one place.
        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer RightAnswer { get; set; }
        #endregion

        #region Constructor
        protected Question(string header, string body, int mark, List<Answer> answerList, int correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = answerList.Find(answer => answer.AnswerId == correctAnswerId);
        } 
        #endregion
    }
}
