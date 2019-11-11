using System;
using Challenge;
using Challenge.DataContracts;

namespace ConsoleCoreApp
{
    public class Sender
    {
        private string GetAns(string type, string task)
        {
            task = GetTypeOfTheTask(type);
            switch (type)
            {
                case "math": return MathSolution.GetAns(task);
                case "polynomial-root": return PolynomsSolver.GetRoot(task);
                case "shape": return ShapeSolver.GetAns(task);
                case "determinant": return MatrixDetSolver.GetAns(task);
                case "cypher": return Caesar.GetAns(task);
                case "string-number": return StringNumber.GetNumber(task);
                case "starter": return "42";
                default: return string.Empty;
            }
        }
        
        public string GetTypeOfTheTask(string hint)
        {
            return hint switch
            {
                @"Вычисли значение выражения в целых числах или комплексных числах с целыми действительной и мнимой частями. Примеры ответов через запятую: 4, i, 2i, 4+3i, 4-i" => "math",
                @"Посчитай определитель матрицы. Во входных данных строки разделяются двойным обратным слэшем \\, а столбцы амперсандом &." => "determinant",
                @"Найди любой корень полинома, либо передай в качестве ответа ""no roots"", если корней нет." => "polynomial-root",
                @"Расшифруй сообщение, используя подсказки. Все сообщения взяты из Ты-Знаешь-Какого-Текста. Но текст был предварительно подготовлен, поэтому сообщения содержат только латинские буквы в нижнем регистре, цифры, апостроф (') и пробелы. Пробелы не повторяются." => "cypher",
                @"Определи, что за фигура задана точками, а затем выбери соответствующий ответ из предложенных" => "shape",
                @"Найди обратную матрицу. Во входыных данных и в ответе строки матрицы разделяются двойным обратынм слэшем \\, а столбцы - амперсандом &. Если матрица необратима, то передай ""unsolvable"" в качестве ответа." => "inverse-matrix",
                @"Верни описанное число в цифровом представлении." => "string-number",
                _ => String.Empty,
            };
        }

        //*
        public void ShowResults(ChallengeClient challengeClient)
        {
            var allTasks = challengeClient.GetAllTasksAsync().Result;
            for (int i = 0; i < allTasks.Count; i++)
            {
                var task = allTasks[i];
                Console.WriteLine($"  Задание {i + 1}, статус {task.Status}");
                Console.WriteLine($"  Формулировка: {task.UserHint}");
                Console.WriteLine($"                {task.Question}");
                Console.WriteLine();
            }
        }
        //*/

        public void SendSomeAnswers(ChallengeClient challengeClient, ChallengeResponse challenge, string type,
            int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (!SendAnswer(challengeClient, challenge, type))
                {
                    Console.WriteLine("Wrong answer!1!");
                    break;
                }
                //Thread.Sleep(3000);
            }
        }

        public bool SendAnswer(ChallengeClient challengeClient, ChallengeResponse challenge, string type)
        {
            string round = challenge.Rounds[challenge.Rounds.Count - 1].Id;
            //Console.WriteLine($"Нажми ВВОД, чтобы получить задачу типа {type}");
            //Console.ReadLine();
            var newTask = challengeClient.AskNewTaskAsync(round, type).Result;
            Console.WriteLine($"  Новое задание, статус {newTask.Status}");
            Console.WriteLine($"  Формулировка: {newTask.UserHint}");
            Console.WriteLine($"                {newTask.Question}");

            string answer = GetAns(type, newTask.Question);
            //Console.WriteLine($"Нажми ВВОД, чтобы ответить на полученную задачу самым правильным ответом: {answer}");
            //Console.ReadLine();
            var updatedTask = challengeClient.CheckTaskAnswerAsync(newTask.Id, answer).Result;
            Console.WriteLine($"  Новое задание, статус {updatedTask.Status}");
            Console.WriteLine($"  Формулировка:  {updatedTask.UserHint}");
            Console.WriteLine($"                 {updatedTask.Question}");
            Console.WriteLine($"  Ответ команды: {updatedTask.TeamAnswer}");
            Console.WriteLine();
            if (updatedTask.Status == TaskStatus.Success)
                Console.WriteLine($"Ура! Ответ угадан!");
            else if (updatedTask.Status == TaskStatus.Failed)
                Console.WriteLine($"Похоже ответ не подошел и задачу больше сдать нельзя...");
            return updatedTask.Status == TaskStatus.Success;
        }
    }
}
