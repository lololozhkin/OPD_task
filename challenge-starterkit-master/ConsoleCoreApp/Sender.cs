using System;
using Challenge;
using Challenge.DataContracts;

namespace ConsoleCoreApp
{
    public class Sender
    {
        private string GetAns(string type, string task)
        {
            type = GetTypeOfTheTask(type);
            return type switch
            {
                "math" => MathSolution.GetAns(task),
                "polynomial-root" => PolynomsSolver.GetRoot(task),
                "shape" => ShapeSolver.GetAnswer(task),
                "determinant" => MatrixDetSolver.GetAns(task),
                "cypher" => Caesar.GetAns(task),
                "string-number" => StringNumber.StringToNumber(task),
                "starter" => "42",
                "json" => Json.GetAnswer(task),
                "inverse-matrix" => InverseMatrix.GetAnswer(task),
                _ => "Я не знаю тип задания, помогите"
            };
        }
        
        public string GetTypeOfTheTask(string hint)
        {
            if (hint.StartsWith("Посчитай определитель матрицы."))
            {
                return "determinant";
            }

            if (hint.StartsWith("Найди обратную матрицу."))
            {
                return "inverse-matrix";
            }

            if (hint.StartsWith(
                "Вычисли значение выражения в целых числах или комплексных числах с целыми действительной и мнимой частями.")
            )
            {
                return "math";
            }

            if (hint.StartsWith("Найди любой действительный корень полинома"))
            {
                return "polynomial-root";
            }

            if (hint.StartsWith("Расшифруй сообщение, используя подсказки."))
            {
                return "cypher";
            }

            if (hint.StartsWith("Определи, что за фигура задана точками"))
            {
                return "shape";
            }

            if (hint.StartsWith("Посчитай сумму значений"))
            {
                return "json";
            }
            return hint switch
            {
                @"Верни описанное число в цифровом представлении." => "string-number",
                _ => String.Empty,
            };
        }

        //*
        public void ShowResults(ChallengeClient challengeClient, ChallengeResponse challenge)
        {
            const string type = "starter";
            string round = challenge.Rounds[challenge.Rounds.Count - 1].Id;

            var allTasks = challengeClient.GetTasksAsync(round, type, TaskStatus.Pending).Result;
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

        public void SendSomeAnswers(ChallengeClient challengeClient,
            ChallengeResponse challenge,
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
            var newTask = challengeClient.AskNewTaskAsync(round).Result;
            Console.WriteLine($"  Новое задание, статус {newTask.Status}");
            Console.WriteLine($"  Формулировка: {newTask.UserHint}");
            Console.WriteLine($"                {newTask.Question}");
            string answer = GetAns(newTask.UserHint, newTask.Question);
            var updatedTask = challengeClient.CheckTaskAnswerAsync(newTask.Id, answer).Result;

            Console.WriteLine($"  Ответ команды: {updatedTask.TeamAnswer}");
            Console.WriteLine();
            if (updatedTask.Status == TaskStatus.Success)
                Console.WriteLine($"Ура! Ответ угадан!");
            else if (updatedTask.Status == TaskStatus.Failed)
                Console.WriteLine($"Похоже ответ не подошел и задачу больше сдать нельзя...");
            //return updatedTask.Status == TaskStatus.Success;
            return true;
        }
    }
}
