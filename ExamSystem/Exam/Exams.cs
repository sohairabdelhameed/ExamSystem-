using System;
using System.Collections.Generic;

namespace ExamSystem.Model
{
    public abstract class Exams
    {
        public int TimeOfExam { get; }
        public int NumberOfQuestions { get; }
        public List<Question> Questions { get; } = new List<Question>();

        protected Exams(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
        }

        public abstract void ShowExam();

        public void StartExam()
        {
            int score = 0;
            DateTime startTime = DateTime.Now;

            foreach (var question in Questions)
            {
                Console.WriteLine($"Question: {question.Header}\n{question.Body}");

                if (question is MCQQuestion mcq)
                {
                    foreach (var answer in mcq.AnswerList)
                    {
                        Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                    }
                }
                else if (question is TrueFalseQuestion trueFalse)
                {
                    foreach (var answer in trueFalse.AnswerList)
                    {
                        Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                    }
                }

                int userAnswerId;
                do
                {
                    Console.Write("Your answer: ");
                    string userAnswerInput = Console.ReadLine();

                    if (int.TryParse(userAnswerInput, out userAnswerId) && userAnswerId >= 1 && userAnswerId <= (question is MCQQuestion ? 4 : 2))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer ID. Please enter a valid number.");
                    }
                } while (true);

                if (userAnswerId == question.RightAnswer.AnswerId)
                {
                    score += question.Mark;
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }

                Console.WriteLine();
            }

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            Console.WriteLine($"Exam finished. Your score is: {score}/{Questions.Count}");
            Console.WriteLine($"Your Time is: {duration}");
        }
    }
}
