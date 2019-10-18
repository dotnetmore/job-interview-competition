using System;
using CalculatorApp.Infrastructure;

namespace CalculatorApp.ConsoleApp
{
	public static class Program
	{
		private static void Main()
		{
			var parser = Parser.DefaultParser();
			//добавление оператора для примера
			parser.Operators.Add(new Operator("%", Priority.High, (x, y) => x % y));

			var calculator = new Calculator(parser);

			Console.WriteLine("Enter 'q' to exit");
			while (true)
			{
				var expression = Console.ReadLine();
				if ("q" == expression) break;

				try
				{
					var result = calculator.Calculate(expression);
					Console.WriteLine($"= {result}");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
}