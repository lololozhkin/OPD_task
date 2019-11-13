using System;
using Challenge;
using Challenge.DataContracts;

namespace ConsoleCoreApp
{
    public class Sender
    {
        private string GetNonRelisedMathSolution(string task)
        {
            Console.WriteLine(task);
            Console.WriteLine("Я хуй занет как это решать, пиздец просто, помоги");
            var ans = Console.ReadLine();
            Console.WriteLine("Ну хуле, если ты такой уверенны блять");
            return ans;
        }

        private string GetAns(string type, string task)
        {
            type = GetTypeOfTheTask(type);
            return type switch
            {
                //"math" => MathSolution.GetAns(task),
                "math" => GetNonRelisedMathSolution(task),
                "polynomial-root" => PolynomsSolver.GetRoot(task),
                "shape" => ShapeSolver.GetAnswer(task),
                "determinant" => MatrixDetSolver.GetAns(task),
                "cypher" => Caesar.GetAns(task),
                "string-number" => StringNumber.GetNumber(task),
                "starter" => "42",
                "json" => Json.GetAnswer(task),
                "inverse-matrix" => InverseMatrix.GetAnswer(task),
                _ => string.Empty
            };
        }
        
        public string GetTypeOfTheTask(string hint)
        {
            return hint switch
            {
                @"Вычисли значение выражения в целых числах или комплексных числах с целыми действительной и мнимой частями. Примеры ответов через запятую: 4, i, 2i, 4+3i, 4-i"
                => "math",
                @"Посчитай определитель матрицы. Во входных данных строки матрицы разделяются двойным обратным слэшем \\, а столбцы - амперсандом &."
                => "determinant",
                @"Найди любой корень полинома, либо передай в качестве ответа ""no roots"", если корней нет." =>
                "polynomial-root",
                @"Расшифруй сообщение, используя подсказки. Все сообщения взяты из Ты-Знаешь-Какого-Текста. Но текст был предварительно подготовлен, поэтому сообщения содержат только латинские буквы в нижнем регистре, цифры, апостроф (') и пробелы. Остальные символы заменены на пробелы, а повторы пробелов заменены на одиночные пробелы."
                => "cypher",
                @"Определи, что за фигура задана точками, а затем выбери соответствующий ответ из предложенных." =>
                "shape",
                @"Найди обратную матрицу. Во входных данных и в ответе строки матрицы разделяются двойным обратным слэшем \\, а столбцы - амперсандом &. Если матрица необратима, то передай ""unsolvable"" в качестве ответа."
                => "inverse-matrix",
                @"Верни описанное число в цифровом представлении." => "string-number",
                @"Посчитай сумму значений JSON-объекта." => "json",
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

        public void SendSomeAnswers(ChallengeClient challengeClient, ChallengeResponse challenge,
            int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (!SendAnswer(challengeClient, challenge))
                {
                    Console.WriteLine("Wrong answer!1!");
                    break;
                }
                //Thread.Sleep(3000);
            }
        }

        public bool SendAnswer(ChallengeClient challengeClient, ChallengeResponse challenge)
        {
            string round = challenge.Rounds[challenge.Rounds.Count - 1].Id;
            //Console.WriteLine($"Нажми ВВОД, чтобы получить задачу типа {type}");
            //Console.ReadLine();
            var newTask = challengeClient.AskNewTaskAsync(round).Result;
            Console.WriteLine($"  Новое задание, статус {newTask.Status}");
            Console.WriteLine($"  Формулировка: {newTask.UserHint}");
            Console.WriteLine($"                {newTask.Question}");

            string answer = GetAns(newTask.UserHint, newTask.Question);
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
