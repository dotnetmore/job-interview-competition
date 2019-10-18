using System;
using CalculatorApp.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
	[TestClass]
	public class CalculatorTest
	{
		[TestMethod]
		public void CreateCalculatorTest()
		{
			var parser = Parser.DefaultParser();
			var calculator = new Calculator(parser);

			Assert.IsTrue(calculator.Operators.Count > 0);
		}

		[TestMethod]
		public void AddOperatorTest()
		{
			var parser = new Parser();
			parser.Operators.Add(new Operator("%", Priority.High, (x, y) => x % y));
			var calculator = new Calculator(parser);

			Assert.IsTrue(calculator.Operators.Count == 1);
			Assert.AreEqual(5 % 3, calculator.Calculate("5 % 3"));
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentNullException))]
		public void ExpressionIsNullTest() => new Calculator().Calculate(string.Empty);

		[TestMethod]
		[ExpectedException(typeof (ArgumentNullException))]
		public void ExpressionIsWhiteSpaceTest() => new Calculator().Calculate("  ");

		[TestMethod]
		public void SeporatorPointTest() => Assert.IsTrue(new Calculator().Calculate("0.1") > 0);

		[TestMethod]
		public void SeparatorCommaTest() => Assert.IsTrue(new Calculator().Calculate("0,1") > 0);

		[TestMethod]
		public void SumTest() => Assert.AreEqual(5 + 7, new Calculator().Calculate("5+7"));

		[TestMethod]
		public void DifferentPriorityTest() => Assert.AreEqual(5 + 3 * 3, new Calculator().Calculate("5+3*3"));

		[TestMethod]
		public void DivisionZeroTest() => Assert.AreEqual(double.PositiveInfinity, new Calculator().Calculate("5/0"));
	}
}