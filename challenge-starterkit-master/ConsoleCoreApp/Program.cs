using Challenge;
using System;

namespace ConsoleCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //*
            const string teamSecret = "R/72jERH1xsugaFANPVcHmgIiRoMyT4O"; // Вставь сюда ключ команды
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
            //Console.WriteLine(Caesar.GetAns("first longest word=underground|marherxhyezmgvbh0ehihve0hhzhnezassuvbeavegv0hnbnogv0ema1he8xhnhexgbhesramacrurhseav0esramab7urhsebnh8"));
        }
    }
}
