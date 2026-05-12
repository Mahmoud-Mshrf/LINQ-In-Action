using System.Linq.Expressions;

namespace IEnumerable_VS_IQueryable_DataSource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DelegateFromExpression();

        }
        
        private static void DelegateFromExpression()
        {
            Func<int, int, int> Multiply = (num1, num2) => num1 * num2;

            ParameterExpression num1Param = Expression.Parameter(typeof(int), "num1");
            ParameterExpression num2Param = Expression.Parameter(typeof(int), "num2");
            BinaryExpression expressionBody = Expression.Multiply(num1Param, num2Param);
            Expression<Func<int, int, int>> expression = Expression.Lambda<Func<int, int, int>>(expressionBody, [num1Param, num2Param]);

            var expressionToDelegate = expression.Compile();
            Console.WriteLine(expressionToDelegate(2, 5));
        }
    }

}
