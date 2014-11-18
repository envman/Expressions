using System;
using System.Linq.Expressions;

namespace Expressions
{
    public class ExpressionTest
    {
        public void Run()
        {
            var test = new Func<string>(() => "test");
            Console.WriteLine("Test:{0}", test());

            var funcData = Func(() => "Func<string> data!");
            Console.WriteLine("Func:{0}",funcData);

            var expressionData = Expression(() => "Expression<Func<string>> data!");
            Console.WriteLine("Expression:{0}", expressionData);

            Console.ReadKey();
        }

        private string Expression(Expression<Func<string>> expression)
        {
            var func = expression.Compile();
            return func();
        }

        private string Func(Func<string> test)
        {
            return test();
        }
    }
}