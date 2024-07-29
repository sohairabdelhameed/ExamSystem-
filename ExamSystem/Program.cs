using ExamSystem.Exam;
using ExamSystem.Model;
using System;
using System.Collections.Generic;

namespace ExamSystem
{
    internal class Program
    {
        public static void Main()
        {
            #region Create The Subject
           
            Console.WriteLine("Enter the name of the Subject:");
            
            string subjectName = Console.ReadLine();

            Subject subject = new Subject
            {
                SubjectId = 1,
                SubjectName = subjectName
            };
            Console.Clear();
            #endregion

            #region Exam Type 
            int examType;
            do
            {
                Console.WriteLine("Please choose the type of the exam \n (1 for Final Exam || 2 for Practical Exam):");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out examType) && (examType == 1 || examType == 2))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid. Please enter '1' for Final Exam or '2' for Practical Exam.");
                }
            } while (true);
            #endregion

            #region Exam Time 
            int timer;
            do
            {
                Console.WriteLine("Enter the time of the exam you have time from 30mins to 120mins:");
                string time = Console.ReadLine();

                if (int.TryParse(time, out timer) && timer >= 30 && timer <= 120) //check if the time is in range
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The time must be between '30' and '120' minutes. Please try again.");
                }
            } while (true);
            #endregion

            #region Number of Questions 
            int questionNumber;
            do
            {
                Console.WriteLine("Enter the number of questions (between 1 and 10):");
                string qNum = Console.ReadLine();

                if (int.TryParse(qNum, out questionNumber) && questionNumber >= 1 && questionNumber <= 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("The number of questions must be between '1' and '10'. Please try again.");
                }
            } while (true);

            Console.Clear();
            #endregion

            #region Exam Initialization
            Exams exam;
            if (examType == 1)
            {
                exam = new FinalExam(timer, questionNumber); // time and number of questions 
            }
            else if (examType == 2)
            {
                exam = new PracticalExam(timer, questionNumber);
            }
            else
            {
                Console.WriteLine("Invalid Input.");
                return;
            }
            #endregion

            #region Question Type  and Details & Creating Exam
            for (int i = 0; i < questionNumber; i++)
            {
                if (examType == 2) // For Practical Exam, only MCQ questions are required
                {
                    Console.WriteLine("MCQ Question");

                    Console.Write("Enter the Question Header: ");
                    string qHeader = Console.ReadLine();

                    Console.Write("Enter the Question Body: ");
                    string qBody = Console.ReadLine();

                    List<Answer> answers = new List<Answer>();
                    for (int j = 1; j <= 4; j++)
                    {
                        Console.Write($"Enter answer option {j}: ");
                        string answerText = Console.ReadLine();
                        answers.Add(new Answer { AnswerId = j, AnswerText = answerText });
                    }

                    int correctAnswerId;
                    do
                    {
                        Console.Write("Enter the ID of the correct answer (1 to 4): ");
                        string correctAnswerInput = Console.ReadLine();

                        if (int.TryParse(correctAnswerInput, out correctAnswerId) && correctAnswerId >= 1 && correctAnswerId <= 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please enter a number between 1 and 4.");
                        }
                    } while (true);

                    exam.Questions.Add(new MCQQuestion(qHeader, qBody, 1, answers, correctAnswerId));
                    Console.Clear();
                }
                else if (examType == 1) // For Final Exam, allow both MCQ and True/False questions
                {
                    int questionType;
                    do
                    {
                        Console.WriteLine($"Please choose the type of question  \n (1 for MCQ || 2 for True or False):");
                        string qType = Console.ReadLine();

                        if (int.TryParse(qType, out questionType) && (questionType == 1 || questionType == 2))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid question type. Please enter 1 for MCQ or 2 for True or False.");
                        }
                    } while (true);
                    Console.Clear();

                    if (questionType == 1)
                    {
                        Console.WriteLine("MCQ Question");

                        Console.Write("Enter the Question Header: ");
                        string qHeader = Console.ReadLine();

                        Console.Write("Enter the Question Body: ");
                        string qBody = Console.ReadLine();

                        List<Answer> answers = new List<Answer>();
                        for (int j = 1; j <= 4; j++)
                        {
                            Console.Write($"Enter answer option {j}: ");
                            string answerText = Console.ReadLine();
                            answers.Add(new Answer { AnswerId = j, AnswerText = answerText });
                        }

                        int correctAnswerId;
                        do
                        {
                            Console.Write("Enter the ID of the correct answer (1 to 4): ");
                            string correctAnswerInput = Console.ReadLine();

                            if (int.TryParse(correctAnswerInput, out correctAnswerId) && correctAnswerId >= 1 && correctAnswerId <= 4)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a number between 1 and 4.");
                            }
                        } while (true);

                        exam.Questions.Add(new MCQQuestion(qHeader, qBody, 1, answers, correctAnswerId));
                    }
                    else if (questionType == 2)
                    {
                        Console.WriteLine("True/False Question");

                        Console.Write("Enter the Question Header: ");
                        string qHeader = Console.ReadLine();

                        Console.Write("Enter the Question Body: ");
                        string qBody = Console.ReadLine();

                        List<Answer> answers = new List<Answer>
                        {
                            new Answer { AnswerId = 1, AnswerText = "True" },
                            new Answer { AnswerId = 2, AnswerText = "False" }
                        };

                        int correctAnswerId;
                        do
                        {
                            Console.Write("Enter the ID of the correct answer (1 for True, 2 for False): ");
                            string correctAnswerInput = Console.ReadLine();

                            if (int.TryParse(correctAnswerInput, out correctAnswerId) && (correctAnswerId == 1 || correctAnswerId == 2))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter 1 for True or 2 for False.");
                            }
                        } while (true);

                        exam.Questions.Add(new TrueFalseQuestion(qHeader, qBody, 1, answers, correctAnswerId));
                    }
                }
            }
            subject.CreateExam(exam);

            Console.Clear();
            #endregion

            #region StartExam
            Console.WriteLine("Your Exam has been created.");
            Console.WriteLine("Do you want to start the exam? (y or n)");
            string startExam = Console.ReadLine();
            Console.Clear();
            if (startExam.ToLower() == "y")
            {
                exam.ShowExam();
            }
            else
            {
                Console.WriteLine("Thank You!.\n Exiting");
            }
            #endregion
        }
    }
}
