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
            Console.WriteLine("Insert number of tests");
            var count = int.Parse(Console.ReadLine());    
            sender.SendSomeAnswers(challengeClient, challenge, count);
            //*/
            //Console.WriteLine(InverseMatrix.GetAnswer(@"-25 & 16 & -20 \\ 19 & 24 & 5 \\ 7 & 8 & 0"));
        }
    }
}
