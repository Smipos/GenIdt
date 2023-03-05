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
            string yourDiagnose = $"Ваш диагноз: {diagnoses[countRightAnswers]}";
            return yourDiagnose;
        }



        static void Main(string[] args)
        {
            int countQuestions = 5;
            string[] questions = GetQuestions(countQuestions); //Заполненный массив questions
            int[] answers = GetRightAnswer(countQuestions);
            string[] emptyMas = new string[countQuestions];
            //Цикл должен пройти по всем вопросам, присвоив пустому массиву emptyMas значение случайного элемента из questions
            //Затем удаляем элемент из questions, присвоенный массиву emptyMas
            int countRightAnswers = 0;

            Random random = new Random();

            Console.WriteLine("Приветствую! Введите пожалуйста свое имя: ");
            string userName = Console.ReadLine();

            int i = 0;

            while (countQuestions > 0)
            {
                Console.WriteLine("Вопрос №" + (i + 1));
                int randomQuestionIndex = random.Next(0, countQuestions);
                emptyMas[i] = questions[randomQuestionIndex]; //присвоение

                Console.WriteLine(randomQuestionIndex);
                //Удаление
                List<string> questionsList = questions.ToList();
                questionsList.RemoveAt(randomQuestionIndex);
                questions = questionsList.ToArray();


                countQuestions--;


                Console.WriteLine(emptyMas[i]);





                int userAnswer = Convert.ToInt32(Console.ReadLine());

                int rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
                i++;
            }
            //Здесь задаются вопросы
         /*  
            for (int i = 0; i <= countQuestions; i++)
            {
                Console.WriteLine("Вопрос №" + (i + 1));
                //---------------------------------------------------------
                //Переделаем, чтобы вопросы не повторялись


                int randomQuestionIndex = random.Next(0, countQuestions);
                emptyMas[i] = questions[randomQuestionIndex]; //присвоение

                Console.WriteLine(randomQuestionIndex);
                //Удаление
                List<string> questionsList = questions.ToList();
                questionsList.RemoveAt(randomQuestionIndex);
                questions = questionsList.ToArray();


                countQuestions--;

               
                Console.WriteLine(emptyMas[i]);

                



                int userAnswer = Convert.ToInt32(Console.ReadLine());

                int rightAnswer = answers[randomQuestionIndex];

                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
                
                
            }
          */  

            Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
            Console.WriteLine($"{userName}, ваш диагноз:" + GiveDiagnose(countRightAnswers));

        }
    }
}
