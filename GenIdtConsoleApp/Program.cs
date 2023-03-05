using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenIdtConsoleApp
{
    
    internal class Program
    {
        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }

        static int[] GetRightAnswer(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }

        static string GiveDiagnose(int countRightAnswers)
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            string yourDiagnose = $"ваш диагноз: {diagnoses[countRightAnswers]}";
            return yourDiagnose;
        }



        static void Main()
        {
            while (true)
            {

                int countQuestions = 5;
                string[] questions = GetQuestions(countQuestions);
                int[] answers = GetRightAnswer(countQuestions);




                int countRightAnswers = 0;

                Random random = new Random();

                Console.WriteLine("Приветствую! Введите пожалуйста свое имя: ");
                string userName = Console.ReadLine();

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    int randomQuestionIndex = random.Next(0, countQuestions);
                    Console.WriteLine(questions[randomQuestionIndex]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());

                    int rightAnswer = answers[randomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }


                }

                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                Console.WriteLine($"{userName}, " + GiveDiagnose(countRightAnswers));



                Console.WriteLine("Хотите пройти тест еще раз?");
                Console.WriteLine("y / n");

                if (Console.ReadKey(true).Key != ConsoleKey.Y)
                    break;
            }
        }
    }
}
