using ExamSystem.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Model
{
    public class Subject
    {
        #region Properties
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exams Exam { get; set; }
        #endregion

        #region Constructors
        public Subject() { }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        } 
        #endregion

        public void CreateExam(Exams exam)
        {
            Exam = exam;
        }
    }
}
