using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ExpressionTreeDerivation
{
    public class Matan
    {
        private static readonly MethodInfo cosMethodInfo = typeof(Math).GetMethod(nameof(Math.Cos));
        private static readonly MethodInfo sinMethodInfo = typeof(Math).GetMethod(nameof(Math.Sin));

        public static Expression<Func<double, double>> Differentiate(Expression<Func<double, double>> f)
        {
            return Expression.Lambda<Func<double, double>>(
                Differentiate(f.Body),
                f.Parameters);
        }

        private static Expression Differentiate(Expression e)
        {
            switch (e.NodeType)
            {
                case ExpressionType.Constant:
                    return Expression.Constant(0.0);
                case ExpressionType.Parameter:
                    return Expression.Constant(1.0);
                case ExpressionType.Add:
                    return DifferentiateAddition((BinaryExpression)e);
                case ExpressionType.Multiply:
                    return DifferentiateMultiplication((BinaryExpression)e);
                case ExpressionType.Call:
                    return DifferentiateFunctionCall((MethodCallExpression)e);
                default:
                    throw new ArgumentException("Not supported expression " + e);
            }
        }

        private static Expression DifferentiateAddition(BinaryExpression b)
        {
            return Expression.Add(Differentiate(b.Left), Differentiate(b.Right));
        }

        private static Expression DifferentiateMultiplication(BinaryExpression b)
        {
            return Expression.Add(
                Expression.Multiply(
                    Differentiate(b.Left),
                    b.Right),
                Expression.Multiply(
                    Differentiate(b.Right),
                    b.Left));
        }

		private static Expression DifferentiateFunctionCall(MethodCallExpression call)
        {
            if (call.Method.DeclaringType == typeof(Math))
            {
                var x = call.Arguments[0];
                return call.Method switch
                {
                    { Name: "Sin" } when call.Method.DeclaringType == typeof(Math) => Expression.Multiply(
                                            Expression.Call(null, cosMethodInfo, x),
                                            Differentiate(call.Arguments[0])),
                    { Name: "Cos" } when call.Method.DeclaringType == typeof(Math) => Expression.Multiply(
                                            Expression.Call(null, sinMethodInfo, x),
                                            Differentiate(call.Arguments[0])),
                   _ => throw new ArgumentException($"Not supported method {call.Method.DeclaringType}.{call.Method.Name}")             
                };
            }

            throw new ArgumentException($"Not supported method {call.Method.DeclaringType}.{call.Method.Name}");
        }

        public static Expression<Func<double, double>> ParseDerivative(Expression<Func<double, double>> function)
        {
            return Expression.Lambda<Func<double, double>>(ParseDerivative(function.Body), function.Parameters);
        }

        private static Expression ParseDerivative(Expression function)
            => function switch
            {
                BinaryExpression binaryExpr => function.NodeType switch
				{
					ExpressionType.Add => Expression.Add(ParseDerivative(binaryExpr.Left), ParseDerivative(binaryExpr.Right)),
					ExpressionType.Subtract => Expression.Subtract(ParseDerivative(binaryExpr.Left), ParseDerivative(binaryExpr.Right)),

					ExpressionType.Multiply => (binaryExpr.Left, binaryExpr.Right) switch
					{
						(ConstantExpression _, ConstantExpression _) => Expression.Constant(0d, typeof(double)),
						(ConstantExpression constant, ParameterExpression _) => constant,
						(ParameterExpression _, ConstantExpression constant) => constant,
						_ => Expression.Add(Expression.Multiply(ParseDerivative(binaryExpr.Left), binaryExpr.Right), Expression.Multiply(binaryExpr.Left, ParseDerivative(binaryExpr.Right)))
					},

					ExpressionType.Divide => (binaryExpr.Left, binaryExpr.Right) switch
					{
						(ConstantExpression _, ConstantExpression _) => Expression.Constant(0d, typeof(double)),
						(ConstantExpression constant, ParameterExpression parameter) => Expression.Divide(constant, Expression.Multiply(parameter, parameter)),
						(ParameterExpression _, ConstantExpression constant) => Expression.Divide(Expression.Constant(1d, typeof(double)), constant),
						_ => Expression.Divide(Expression.Subtract(Expression.Multiply(ParseDerivative(binaryExpr.Left), binaryExpr.Right), Expression.Multiply(binaryExpr.Left, ParseDerivative(binaryExpr.Right))), Expression.Multiply(binaryExpr.Right, binaryExpr.Right))
					},
					_ => throw new NotImplementedException(),
				},
                MethodCallExpression methodCall => methodCall.Method switch
				{
					{ Name: "Sin" } when methodCall.Method.DeclaringType == typeof(Math) => Expression.Multiply(
											Expression.Call(null, cosMethodInfo, methodCall.Arguments[0]),
											Differentiate(methodCall.Arguments[0])),
					{ Name: "Cos" } when methodCall.Method.DeclaringType == typeof(Math)  => Expression.Multiply(
											Expression.Call(null, sinMethodInfo, methodCall.Arguments[0]),
											Differentiate(methodCall.Arguments[0])),
					_ => throw new NotImplementedException()
				},
                _ => function.NodeType switch
                {
                    ExpressionType.Constant => Expression.Constant(0d, typeof(double)),
                    ExpressionType.Parameter => Expression.Constant(1d, typeof(double)),
                    _ => throw new NotImplementedException()
                }
            };
    }
}
