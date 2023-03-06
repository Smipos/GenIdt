﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenIdtConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                int countQuestions = 5; // убрать необходимость прописывать в main количество вопросов
                int i = 0;  // неименнованная переменная
                int countRightAnswers = 0;
                var questions = GetQuestions(countQuestions);
                var answers = GetRightAnswer(countQuestions);
                var emptyMasQuestions = new string[countQuestions];
                var emptyMasAnswers = new int[countQuestions];  


                Random random = new Random();

                Console.WriteLine("Приветствую! Введите пожалуйста свое имя: ");
                string userName = Console.ReadLine();

                while (countQuestions > 0)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    int randomQuestionIndex = random.Next(0, countQuestions);
                    emptyMasQuestions[i] = questions[randomQuestionIndex];
                    emptyMasAnswers[i] = answers[randomQuestionIndex];

                    // подумай, как можно вынести перемешивание в отдельную функцию
                    var questionsList = questions.ToList();
                    questionsList.RemoveAt(randomQuestionIndex);
                    questions = questionsList.ToArray();

                    var answersList = answers.ToList();
                    answersList.RemoveAt(randomQuestionIndex);
                    answers = answersList.ToArray();

                    Console.WriteLine(emptyMasQuestions[i]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());
                    int rightAnswer = emptyMasAnswers[i];
                    if (userAnswer == rightAnswer)
                        countRightAnswers++;
                    // старайся не оставлять так много пустых строк между комаднами.
                    // 1 - между полями класса
                    // 1, 2 - по смыслу
                    // 4 - зачем?
                    i++;
                    countQuestions--;
                }

                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                Console.WriteLine($"{userName}, " + GetDiagnose(countRightAnswers));

                Console.WriteLine("Хотите пройти тест еще раз?");
                Console.WriteLine("y / n");
                if (Console.ReadKey(true).Key != ConsoleKey.Y)
                    break;
            }
        }

        static string[] GetQuestions(int countQuestions)
        {
            // Подумай и реализуй вариант, как сделать более удобной задачу добавления новых вопросов с ответами (чтобы количество правок было в минимальном количестве мест)
            // И вообще, продумай ситуацию, когда могут добавить ещё вопросы, возможно ли такое, что в этом случае код программы будет работать не адекватно? 
            // Может быть структуру приложения в этом случае лучше изменить? (Я не намекаю, может и не нужно менять, просто хочу чтобы ты задался этим вопросом)

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

        static string GetDiagnose(int countRightAnswers)  
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

    }
}
