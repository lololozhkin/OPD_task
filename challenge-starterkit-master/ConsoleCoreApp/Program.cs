using Challenge;
using System;

namespace ConsoleCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //*
            const string teamSecret = "wHUYV6IVfJh7akUFzCmSqG9Fk/z/GwX"; // Вставь сюда ключ команды
            var challengeClient = new ChallengeClient(teamSecret);
            const string challengeId = "projects-course";
            var challenge = challengeClient.GetChallengeAsync(challengeId).Result;
            var sender = new Sender();
            //sender.ShowResults(challengeClient);
            //Console.WriteLine("Insert type of your task");
            //string type = Console.ReadLine();
            Console.WriteLine("Insert number of tests");
            var count = int.Parse(Console.ReadLine());    
            sender.SendSomeAnswers(challengeClient, challenge, count);
            //*/
            //Console.WriteLine(InverseMatrix.GetAnswer(@"-10 & -5 & 2 \\ -5 & -7 & 9 \\ -8 & 8 & -4"));
        }
    }
}
