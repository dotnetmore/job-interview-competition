using System;
using System.Collections.Generic;

namespace CalculatorApp.Infrastructure
{
	public class Calculator
	{
		/// <summary>
		/// Парсер
		/// </summary>
		private readonly Parser _parser;

		public Calculator()
		{
			_parser = Parser.DefaultParser();
		}

		public Calculator(Parser parser)
		{
			_parser = parser;
		}

		/// <summary>
		/// Коллекция операторов парсера
		/// </summary>
		public List<Operator> Operators => _parser.Operators;

		/// <summary>
		/// Вычисление строки
		/// </summary>
		public double Calculate(string expression)
		{
			if (string.IsNullOrWhiteSpace(expression))
				throw new ArgumentNullException(nameof(expression), "Строка выражения пустая");
			return _parser.Parse(expression);
		}
	}
}