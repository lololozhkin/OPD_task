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
            Console.WriteLine(TheLargestMatch.GetAnswer(InputText.GetText(),
                "7c5zmcp24z7yz7qvyz yywzecze9phd4z7yo4zeyywzspd''y22z97y'yz97q9zvy'3z4q3ze7qkywz7qw4ez5d97z7dlzdwz97y",
                "quirrell"));
        }
    }
}
