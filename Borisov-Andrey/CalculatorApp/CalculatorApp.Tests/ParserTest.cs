using System;
using CalculatorApp.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
	[TestClass]
	public class ParserTest
	{
		[TestMethod]
		public void ParseNumber() => Assert.AreEqual(13, Parser.DefaultParser().Parse("13"));

		[TestMethod]
		public void ParseSumTest() => Assert.AreEqual(6 + 3 + 2, Parser.DefaultParser().Parse("6+3+2"));

		[TestMethod]
		public void ParseSubtractTest() => Assert.AreEqual(6 - 3 - 2, Parser.DefaultParser().Parse("6-3-2"));

		[TestMethod]
		public void SumAndSubtructTest()
		{
			Assert.AreEqual(6 - 3 - 5, Parser.DefaultParser().Parse("(6-3-5)"));
			Assert.AreEqual(6 - (3 - 2) + 5, Parser.DefaultParser().Parse("6-(3-2)+5"));
			Assert.AreEqual(6 + 5 - (3 - 2), Parser.DefaultParser().Parse("(6+5)-(3-2)"));
			Assert.AreEqual(6 - 2 * (3 - 2), Parser.DefaultParser().Parse("6-(2*(3-2))"));
		}

		[TestMethod]
		public void ParseMultipleTest() => Assert.AreEqual(6 * 3, Parser.DefaultParser().Parse("6*3"));

		[TestMethod]
		public void SumAndMultipleTest()
		{
			Assert.AreEqual(2 + 6 * 3, Parser.DefaultParser().Parse("2+6*3"));
			Assert.AreEqual(6 * 3 + 2, Parser.DefaultParser().Parse("6*3+2"));
		}

		[TestMethod]
		public void NegativeNumberTest()
		{
			Assert.AreEqual(6 + 6, Parser.DefaultParser().Parse("6+6"));
			Assert.AreEqual(6 + -6, Parser.DefaultParser().Parse("6+-6"));
			Assert.AreEqual(6 * -6, Parser.DefaultParser().Parse("6*-6"));
			Assert.AreEqual(-1, Parser.DefaultParser().Parse("6/-6"));
		}

		[TestMethod]
		public void BracesTest()
		{
			Assert.AreEqual((2 + 6) * 3, Parser.DefaultParser().Parse("(2+6)*3"));
			Assert.AreEqual(6 * (3 + 2), Parser.DefaultParser().Parse("6*(3+2)"));
		}

		[TestMethod]
		public void MultipleAndDivideTest()
		{
			Assert.AreEqual(10, Parser.DefaultParser().Parse("6*5/3"));
			Assert.AreEqual(2, Parser.DefaultParser().Parse("50/5/5"));
			Assert.AreEqual(4 * 4 - 3 * 3, Parser.DefaultParser().Parse("(4*4)-(3*3)"));
			Assert.AreEqual(50, Parser.DefaultParser().Parse("50/(5/5)"));
		}

		[TestMethod]
		public void ParsePowerTest() => Assert.AreEqual(Math.Pow(6, 2), Parser.DefaultParser().Parse("6^2"));

		[TestMethod]
		public void PowerAndMultipleTest()
		{
			Assert.AreEqual(72, Parser.DefaultParser().Parse("6^2*2"));
			Assert.AreEqual(75, Parser.DefaultParser().Parse("3*5^2"));
			Assert.AreEqual(96, Parser.DefaultParser().Parse("3*2^5"));
			Assert.AreEqual(625, Parser.DefaultParser().Parse("5^(1+3)"));
		}

		[TestMethod]
		[ExpectedException(typeof (ArgumentException))]
		public void ExpressionLeftBraceTest() => Parser.DefaultParser().Parse("6+1)");

		[TestMethod]
		[ExpectedException(typeof (ArgumentException))]
		public void ExpressionRightBraceTest() => Parser.DefaultParser().Parse("(6+1");
	}
}