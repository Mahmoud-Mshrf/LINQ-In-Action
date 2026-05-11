using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace ExpressionTrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MethodOne();
            //MethodTwo();
            //MethodThree();
            MethodFour();
        }

        private static void MethodFour()
        {
            Func<int, bool> IsEven = num => num % 2 == 0;
            ParameterExpression numParameter = Expression.Parameter(typeof(int), "num");
            ConstantExpression two = Expression.Constant(2);
            ConstantExpression zero = Expression.Constant(0);
            BinaryExpression modulo = Expression.Modulo(numParameter, two);
            BinaryExpression equal = Expression.Equal(modulo, zero);
            Expression<Func<int, bool>> expression = Expression.Lambda<Func<int, bool>>(equal, numParameter);

            var expressionToDelegate = expression.Compile();
            Console.WriteLine(expressionToDelegate(100));

        }

        private static void MethodThree()
        {
            Func<int, bool> IsNegative = num => num < 0;
            ParameterExpression numParameter = Expression.Parameter(typeof(int), "num");
            ConstantExpression zero = Expression.Constant(0);
            BinaryExpression equal = Expression.Equal(numParameter, zero);
            Expression<Func<int, bool>> expression = Expression.Lambda<Func<int,bool>>(equal,numParameter);
            Func<int, bool> expressionToDelegat = expression.Compile();
            Console.WriteLine(expressionToDelegat(2));
        }

        private static void MethodTwo()
        {
            Expression<Func<int, bool>> isNegativeExpression = num => num < 0;
            ParameterExpression numParameter = isNegativeExpression.Parameters[0];
            BinaryExpression body = (BinaryExpression)isNegativeExpression.Body;
            ParameterExpression left = (ParameterExpression)body.Left;
            ConstantExpression right = (ConstantExpression)body.Right;
            // num => num < 0
            Console.WriteLine($"{numParameter.Name} => {left.Name} {body.NodeType} {right.Value}");
        }

        private static void MethodOne()
        {
            Func<int, bool> IsEven = num => num % 2 == 0;
            Expression<Func<int, bool>> IsEvenExpression = num => num % 2 == 0;
            Func<int, bool> ExpressionToDelegate = IsEvenExpression.Compile();
            Console.WriteLine(IsEven(2));
            Console.WriteLine(IsEvenExpression.Compile()(2));
        }
    }
}
