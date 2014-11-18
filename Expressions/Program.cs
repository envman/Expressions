using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressions = new ExpressionTest();
            expressions.Run();

            var memberInfo = new MemberInfoTest();
            memberInfo.Run();
        }
    }

    public class MemberInfoTest
    {
        public string TestProperty { get; set; }

        public void Run()
        {
            var name = GetMemberName(() => TestProperty);
            Console.WriteLine("PropertyName:{0}", name);

            var propertyInfo = GetType().GetProperty(name);
            propertyInfo.SetValue(this, "Test Data");

            Console.WriteLine(TestProperty);

            Console.ReadKey();
        }

        private string GetMemberName<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }

            return "Error";
        }
    }
}
