using System.Numerics;
using Microsoft.Win32.SafeHandles;
using Z.Expressions;

namespace ConsoleCoreApp
{
    public static class MathSolution
    {
        public static string GetAns(string statement)
        {
            var complex = false;
            foreach (var symbol in statement)
            {
                if (symbol == 'i')
                {
                    complex = true;
                }
            }

            return !complex ? Eval.Execute<long>(statement).ToString() : MathSolver.GetAnswer(statement);
        }
    }
}
