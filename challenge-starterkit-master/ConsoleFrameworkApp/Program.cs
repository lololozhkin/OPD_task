using Challenge;
using Challenge.DataContracts;
using System;

namespace ConsoleFrameworkApp
{
    // Если не получилось разобраться с запуском ConsoleCoreApp, можно использовать это приложение.
    // Данное приложение можно запускать под Windows с установленной .NET Framework 4.6.1.
    // .NET Framework скорее всего установлен в Windows по умолчанию.
    // Также может быть установлен при установке Visual Studio или отдельно.
    // Также приложение можно запускать на Linux под Mono, но рекомендуется использовать ConsoleCoreApp для .NET Core.
    class Program
    {
        static void Main(string[] args)
        {
            const string teamSecret = ""; // Вставь сюда ключ команды
            if (string.IsNullOrEmpty(teamSecret))
            {
                Console.WriteLine("Задай секрет своей команды, чтобы можно было делать запросы от ее имени");
                return;
            }
            var challengeClient = new ChallengeClient(teamSecret);

            const string challengeId = "projects-course";
            Console.WriteLine($"Нажми ВВОД, чтобы получить информацию о челлендже {challengeId}");
            Console.ReadLine();
            var challenge = challengeClient.GetChallengeAsync(challengeId).Result;
            Console.WriteLine(challenge.Description);
            Console.WriteLine();
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.WriteLine($"Нажми ВВОД, чтобы получить список взятых командой задач");
            Console.ReadLine();
            var allTasks = challengeClient.GetAllTasksAsync().Result;
            for (int i = 0; i < allTasks.Count; i++)
            {
                var task = allTasks[i];
                Console.WriteLine($"  Задание {i + 1}, статус {task.Status}");
                Console.WriteLine($"  Формулировка: {task.UserHint}");
                Console.WriteLine($"                {task.Question}");
                Console.WriteLine();
            }
            Console.WriteLine("----------------");
            Console.WriteLine();

            const string type = "starter";
            string round = challenge.Rounds[challenge.Rounds.Count - 1].Id;
            Console.WriteLine($"Нажми ВВОД, чтобы получить задачу типа {type}");
            Console.ReadLine();
            var newTask = challengeClient.AskNewTaskAsync(round, type).Result;
            Console.WriteLine($"  Новое задание, статус {newTask.Status}");
            Console.WriteLine($"  Формулировка: {newTask.UserHint}");
            Console.WriteLine($"                {newTask.Question}");
            Console.WriteLine();
            Console.WriteLine("----------------");
            Console.WriteLine();

            const string answer = "42";
            Console.WriteLine($"Нажми ВВОД, чтобы ответить на полученную задачу самым правильным ответом: {answer}");
            Console.ReadLine();
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
            Console.WriteLine();
            Console.WriteLine("----------------");
            Console.WriteLine();

            Console.WriteLine($"Нажми ВВОД, чтобы завершить работу программы");
            Console.ReadLine();
        }
    }
}
