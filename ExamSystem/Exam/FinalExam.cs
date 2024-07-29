using ExamSystem.Model;
using System;
using System.Collections.Generic;

namespace ExamSystem.Exam
{
    public class FinalExam : Exams
    {
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions) { }

        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam - Time: {TimeOfExam} minutes, Questions: {NumberOfQuestions}");

            StartExam();
        }
    }
}