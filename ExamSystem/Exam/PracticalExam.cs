using ExamSystem.Model;

namespace ExamSystem.Exam
{
    public class PracticalExam : Exams
    {
        public PracticalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine($"Practical Exam - Time: {TimeOfExam} minutes, Questions: {NumberOfQuestions}");

            StartExam();
        }
    }
}