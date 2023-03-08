using System;
using System.Collections;
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
                var questionAndAnswerDict = GetQuestionAndAnswerDict();
                int countQuestions = questionAndAnswerDict.Count;
                int questionNumber = 0;  
                int countRightAnswers = 0;
                var questions = GetQuestions(questionAndAnswerDict);
                var answers = GetRightAnswer(questionAndAnswerDict);
                var mixedQuestions = new string[countQuestions];
                var mixedAnswers = new int[countQuestions];

                Random random = new Random();

                Console.WriteLine("Приветствую! Введите пожалуйста свое имя: ");
                string userName = Console.ReadLine();

                while (countQuestions > 0)
                {
                    Console.WriteLine("Вопрос №" + (questionNumber + 1));
                    int randomQuestionIndex = random.Next(0, countQuestions);

                    mixedQuestions[questionNumber] = questions[randomQuestionIndex];
                    mixedAnswers[questionNumber] = answers[randomQuestionIndex];

                    
                    var tupleQuestionsAnswers = MixQuestionsAndAnswers(questions, answers, randomQuestionIndex);
                    questions = tupleQuestionsAnswers.Item1;
                    answers = tupleQuestionsAnswers.Item2;
                    
                    Console.WriteLine(mixedQuestions[questionNumber]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());
                    int rightAnswer = mixedAnswers[questionNumber];
                    if (userAnswer == rightAnswer)
                        countRightAnswers++;

                    questionNumber++;
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
        static Dictionary<int, string> GetQuestionAndAnswerDict()
        {
            var questionAndAnswerDict = new Dictionary<int, string>()
            {
                [6] = "Сколько будет два плюс два умноженное на два?",
                [9] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
                [25] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
                [60] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
                [2] = "Пять свечей горело, две потухли. Сколько свечей осталось?"
            };
            return questionAndAnswerDict;
        }
        static List<string> GetQuestions(Dictionary<int, string> questionAndAnswerDict)
        {
            var questions = new List<string>();
            questions = questionAndAnswerDict.Values.ToList();
            return questions;
        }
        static List<int> GetRightAnswer(Dictionary<int, string> questionAndAnswerDict)
        {
            var answers = new List<int>();
            answers = questionAndAnswerDict.Keys.ToList();
            return answers;
        }
        static string GetDiagnose(int countRightAnswers)  
        {
            var diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            string yourDiagnose = $"ваш диагноз: {diagnoses[countRightAnswers]}";
            return yourDiagnose;
        }
        public static Tuple<List<string>, List<int>> MixQuestionsAndAnswers(List<string> questions, List<int> answers, int randomQuestionIndex)
        {
            var mixedQuestions = MixQuestions(questions, randomQuestionIndex);
            var mixedAnswers = MixAnswers(answers, randomQuestionIndex);
            return new Tuple<List<string>, List<int>>(mixedQuestions, mixedAnswers);
        }
        public static List<string> MixQuestions(List<string> questions, int randomQuestionIndex)
        {
            var mixedQuestions = questions.ToList();
            mixedQuestions.RemoveAt(randomQuestionIndex);
            return mixedQuestions;
        }
        public static List<int> MixAnswers(List<int> answers, int randomQuestionIndex)
        {
            var mixedAnswers = answers.ToList();
            mixedAnswers.RemoveAt(randomQuestionIndex);
            return mixedAnswers;
        }
    }
}
