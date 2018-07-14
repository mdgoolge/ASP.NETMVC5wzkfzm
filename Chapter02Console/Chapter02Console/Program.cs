using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Northwind db = new Northwind();
            //IEnumerable<Customer> customers = db.Customers.Get();
            //IEnumerable<Order> orders = db.Orders.Get();

            //foreach (Customer  item in customers )
            //{
            //    Console.WriteLine("Customer:ID：{0},Name:{1}",item.CustomerID,item.ContactName );
            //}
            //foreach (Order item in orders)
            //{
            //    Console.WriteLine("Order:ID：{0},OrderDate:{1}", item.OrderID, item.OrderDate);
            //}


            //1
            System.Linq.Expressions.Expression<Func<int, bool>> lambda = num => num >= 5;

            //创建lambda表达式 num=>num>=5
            //第一步创建输入参数,参数名为num，类型为int类型
            ParameterExpression numParameter = Expression.Parameter(typeof(int), "num");
            //第二步创建常量表达式5，类型int
            ConstantExpression constant = Expression.Constant(5, typeof(int));
            //第三步创建比较运算符>=,大于等于,并将输入参数表达式和常量表达式输入
            //表示包含二元运算符的表达式。BinaryExpression继承自Expression
            BinaryExpression greaterThanOrEqual = Expression.GreaterThanOrEqual(numParameter, constant);
            //第四步构建lambda表达式树
            //Expression.Lambda<Func<int, bool>>:通过先构造一个委托类型来创建一个 LambdaExpression
            Expression<Func<int, bool>> lambda_ = Expression.Lambda<Func<int, bool>>(greaterThanOrEqual, numParameter);

            //2
            //Expression<Func<int, int>> lambda2 = n =>
            //{
            //    int result = 0;
            //    for (int j = n; j >= 0; j--)
            //    {
            //        result += j;
            //    }
            //    return result;
            //};

            ////变量表达式
            //ParameterExpression i = Expression.Variable(typeof(int), "i");
            ////变量表达式
            //ParameterExpression sum = Expression.Variable(typeof(int), "sum");
            ////跳出循环标志
            //LabelTarget label = Expression.Label(typeof(int));
            ////块表达式
            //BlockExpression block =
            //    Expression.Block(
            //    //添加局部变量
            //        new[] { sum },
            //    //为sum赋初值 sum=1
            //    //Assign表示赋值运算符
            //        Expression.Assign(sum, Expression.Constant(1, typeof(int))),
            //    //loop循环
            //        Expression.Loop(
            //    //如果为true 然后求和，否则跳出循环
            //            Expression.IfThenElse(
            //    //如果i>=0
            //            Expression.GreaterThanOrEqual(i, Expression.Constant(0, typeof(int))),
            //    //sum=sum+i;i++;
            //                      Expression.AddAssign(sum, Expression.PostDecrementAssign(i)),
            //    //跳出循环
            //                Expression.Break(label, sum)
            //            ), label
            //         )  // Loop ends
            //     );
            //int resutl = Expression.Lambda<Func<int, int>>(block, i).Compile()(100);


            //Expression<Func<int, int>> expr = x => x + 1;
            //Console.WriteLine(expr.ToString());  // x=> (x + 1)

            //// 下面的代码编译不通过
            ////Expression<Func<int, int, int>> expr2 = (x, y) => { return x + y; };
            ////Expression<Action<int>> expr3 = x => { };

            //var lambdaExpr = expr as LambdaExpression;
            //Console.WriteLine(lambdaExpr.Body);   // (x + 1)
            //Console.WriteLine(lambdaExpr.ReturnType.ToString());  // System.Int32

            //foreach (var parameter in lambdaExpr.Parameters)
            //{
            //    Console.WriteLine("Name:{0}, Type:{1}, ", parameter.Name, parameter.Type.ToString());
            //}

            // 下面的方法编译不能过
            /*
            Expression<Action> lambdaExpression2 = () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("Hello");
                }
            };
            */

            //// 创建 loop表达式体来包含我们想要执行的代码
            //LoopExpression loop = Expression.Loop(
            //    Expression.Call(
            //        null,
            //        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
            //        Expression.Constant("Hello"))
            //        );

            //// 创建一个代码块表达式包含我们上面创建的loop表达式
            //BlockExpression block = Expression.Block(loop);

            //// 将我们上面的代码块表达式
            //Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            //lambdaExpression.Compile().Invoke();

            //ParameterExpression number = Expression.Parameter(typeof(int), "number");

            //BlockExpression myBlock = Expression.Block(
            //    new[] { number },
            //    Expression.Assign(number, Expression.Constant(2)),
            //    Expression.AddAssign(number, Expression.Constant(6)),
            //    Expression.DivideAssign(number, Expression.Constant(2)));

            //Expression<Func<int>> myAction = Expression.Lambda<Func<int>>(myBlock);
            //Console.WriteLine(myAction.Compile()());
            //// 4

            //LabelTarget labelBreak = Expression.Label();
            //ParameterExpression loopIndex = Expression.Parameter(typeof(int), "index");

            //BlockExpression block = Expression.Block(
            //    new[] { loopIndex },
            //    // 初始化loopIndex =1
            //    Expression.Assign(loopIndex, Expression.Constant(1)),
            //    Expression.Loop(
            //    // if 的判断逻辑
            //        Expression.IfThenElse(
            //            Expression.LessThanOrEqual(loopIndex, Expression.Constant(10)),
            //    // 判断逻辑通过的代码
            //            Expression.Block(
            //                Expression.Call(
            //                    null,
            //                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
            //                    Expression.Constant("Hello")
            //                ),
            //                Expression.PostIncrementAssign(loopIndex)
            //            ),
            //    // 判断不通过的代码
            //            Expression.Break(labelBreak)
            //        ),
            //        labelBreak
            //    )
            //);

            //// 将我们上面的代码块表达式
            //Expression<Action> lambdaExpression = Expression.Lambda<Action>(block);
            //lambdaExpression.Compile().Invoke();

            ParameterExpression arrayExpr = Expression.Parameter(typeof(int[]), "Array");

            ParameterExpression indexExpr = Expression.Parameter(typeof(int), "Index");

            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "Value");

            Expression arrayAccessExpr = Expression.ArrayAccess(
                arrayExpr,
                indexExpr
            );

            Expression<Func<int[], int, int, int>> lambdaExpr = Expression.Lambda<Func<int[], int, int, int>>(
                    Expression.Assign(arrayAccessExpr, Expression.Add(arrayAccessExpr, valueExpr)),
                    arrayExpr,
                    indexExpr,
                    valueExpr
                );

            Console.WriteLine(arrayAccessExpr.ToString());
            // Array[Index]

            Console.WriteLine(lambdaExpr.ToString());
            // (Array, Index, Value) => (Array[Index] = (Array[Index] + Value))

            int[] array=new int[] { 10, 20, 30 };
            Console.WriteLine(lambdaExpr.Compile().Invoke(array, 0, 5));
            // 15

            Expression<Func<int[], int, int>> la = Expression.Lambda<Func<int[], int, int>>(
                     Expression.Assign(arrayAccessExpr, arrayAccessExpr),
                     arrayExpr,
                     indexExpr
                 );
            Console.WriteLine(la.Compile().Invoke(array, 1));
        }
    }
}
