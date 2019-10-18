using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalculatorApp.Infrastructure
{
	public class Parser
	{
		public Parser()
		{
			Operators = new List<Operator>();
		}

		/// <summary>
		/// Коллекция операторов
		/// </summary>
		public List<Operator> Operators { get; set; }

		/// <summary>
		/// Парсер со стандартными операторами
		/// </summary>
		public static Parser DefaultParser()
		{
			var parser = new Parser();
			parser.Operators.Add(new Operator("+", Priority.Low, (x, y) => x + y));
			parser.Operators.Add(new Operator("-", Priority.Low, (x, y) => x - y));
			parser.Operators.Add(new Operator("*", Priority.Low, (x, y) => x * y));
			parser.Operators.Add(new Operator("/", Priority.Low, (x, y) => x / y));
			parser.Operators.Add(new Operator("^", Priority.Low, Math.Pow));

			return parser;
		}

		/// <summary>
		/// Приведение строки к нормальному виду
		/// </summary>
		private static string NormalizeExpression(string expression)
		{
			//удаление пробелов и табуляции
			expression = expression.Trim();
			expression = expression.Replace(" ", string.Empty);
			expression = expression.Replace("\t", string.Empty);

			//корректировка разделителя дробной части
			var numberSeparator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
			expression = expression.Replace(",", numberSeparator);
			expression = expression.Replace(".", numberSeparator);

			//проверка корректной расстановки скобок
			var count1 = expression.Split(new[] {"("}, StringSplitOptions.None).Length - 1;
			var count2 = expression.Split(new[] {")"}, StringSplitOptions.None).Length - 1;
			if (count1 != count2) throw new ArgumentException("Не хватает скобки.");

			return expression;
		}

		/// <summary>
		/// Парсинг строки с нормализацией
		/// </summary>
		public double Parse(string expression)
		{
			expression = NormalizeExpression(expression);
			if (string.IsNullOrWhiteSpace(expression))
				throw new ArgumentNullException(nameof(expression));

			//сортировка операторов по возврастанию приоритета
			Operators.Sort((x, y) => x.Priority.CompareTo(y.Priority));

			return ParseNormal(expression);
		}

		/// <summary>
		/// Парсинг нормированной строки
		/// </summary>
		private double ParseNormal(string expression)
		{
			//вычисление выражений в скобках
			while (expression.LastIndexOf("(", StringComparison.Ordinal) + 1 > 0)
			{
				var indexLeftBrace = expression.LastIndexOf("(", StringComparison.Ordinal) + 1;
				var indexRightBrace = expression.Substring(indexLeftBrace).IndexOf(")", StringComparison.Ordinal);

				var subExpression = expression.Substring(indexLeftBrace, indexRightBrace);
				var result = ParseNormal(subExpression);

				//замена выражения в скобках на полученный результат
				expression = expression.Replace($"({subExpression})", result.ToString(CultureInfo.InvariantCulture));
			}

			foreach (var _operator in Operators)
			{
				//поиск оператора в строке
				var index = expression.LastIndexOf(_operator.Symbol, StringComparison.Ordinal);
				if (index > 0)
				{
					//проверка того, что это операция вычитания, а не отрицательное число
					if (_operator.Symbol == "-" && !char.IsDigit(expression[index - 1])) continue;

					var leftArgStr = expression.Substring(0, index);
					var rightArgStr = expression.Substring(index + _operator.Symbol.Length);

					var leftArg = ParseNormal(leftArgStr);
					var rightArg = ParseNormal(rightArgStr);

					var result = _operator.Operation(leftArg, rightArg);
					return result;
				}
			}

			return double.Parse(expression);
		}
	}
}