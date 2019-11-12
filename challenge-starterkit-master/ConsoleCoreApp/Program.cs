using Challenge;
using System;

namespace ConsoleCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            const string teamSecret = "wHUYV6IVfJh7akUFzCmSqG9Fk/z/GwX"; // Вставь сюда ключ команды
            var challengeClient = new ChallengeClient(teamSecret);
            const string challengeId = "projects-course";
            var challenge = challengeClient.GetChallengeAsync(challengeId).Result;
            var sender = new Sender();
            sender.ShowResults(challengeClient);
            Console.WriteLine("Insert type of your task");
            string type = Console.ReadLine();
            Console.WriteLine("Insert number of tests");
            var count = int.Parse(Console.ReadLine());    
            sender.SendSomeAnswers(challengeClient, challenge, type, count);
            //*/
            Console.WriteLine(TheLargestMatch.GetAnswer("ANAlANAlANAlANAl they saw flat on the floor in front of them a troll even larger than the one they had tackled out cold ANAlANAlANAl",
                "h5ydxqkjxfrkhx26xh5yxfr22sx76xfs26hx2fxh5ymxkxhs2rrxy3y6xrkseysxh5k6xh5yx26yxh5ydx5kixhkcbryix2uhxc2ri", 
                "tackled"));
        }
    }
}
