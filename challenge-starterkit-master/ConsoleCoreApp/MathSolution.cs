using Z.Expressions;

namespace ConsoleCoreApp
{
    public static class MathSolution
    {
        public static string GetAns(string statement)
        {
            return (Eval.Execute<long>(statement)).ToString();
        }
    }
}
