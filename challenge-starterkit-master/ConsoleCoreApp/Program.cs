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
            Console.WriteLine(Json.GetAnswer(@"{""unequivalved"":-9,""ilian"" 1,""nutter"":-2,""naphthalenic"":-9,""libertas"":-11,""nugator"" 2,""inturns"":{""patronless"":-11,""bystander"" 8,""rebase"":-3,""underscribe"":-1,""arenose"":10},""beguines"":{""nannette"":1,""canaanitess"":-1,""laguncularia"":1,""volatilizing"" 10,""arterially"":-4,""yakutat"":-9}}"));
        }
    }
}
