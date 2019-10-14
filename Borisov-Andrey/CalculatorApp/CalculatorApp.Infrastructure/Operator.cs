using System;

namespace CalculatorApp.Infrastructure
{
	/// <summary>
	/// Список приоритетов
	/// </summary>
	public enum Priority
	{
		Low = 0,
		Middle,
		High
	}

	public class Operator
	{
		/// <summary>
		/// Функция
		/// </summary>
		public Func<double, double, double> Operation;

		public Operator(string symbol, Priority priority, Func<double, double, double> operation)
		{
			Symbol = symbol;
			Priority = priority;
			Operation = operation;
		}

		/// <summary>
		/// Обозначение оператора
		/// </summary>
		public string Symbol { get; set; }

		/// <summary>
		/// Приоритет оператора
		/// </summary>
		public Priority Priority { get; set; }
	}
}