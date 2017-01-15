using System;
using UserInterface_CLI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core {
	[TestClass]
	public class ValidatorTests {
		// TODO: Make some tests for the validator...
		Validator Valid;

		[TestInitialize]
		public void Init() {
			Valid = new Validator();
		}

		[TestMethod]
		public void ValidatorTextOnly() {
			Assert.IsTrue(Valid.text("this"));
			Assert.IsTrue(Valid.text("That"));
			Assert.IsTrue(Valid.text("ThoSE"));

			Assert.IsFalse(Valid.text("1234"));
			Assert.IsFalse(Valid.text("th1a3"));
			Assert.IsFalse(Valid.text("With Spaces"));
		}

		[TestMethod]
		public void ValidatorNumbersOnly() {
			Assert.IsTrue(Valid.number("4"));
			Assert.IsTrue(Valid.number("47"));
			Assert.IsTrue(Valid.number("85"));

			Assert.IsFalse(Valid.number("One"));
			Assert.IsFalse(Valid.number("Hello"));
			Assert.IsFalse(Valid.number("Testing"));
			Assert.IsFalse(Valid.number("Strigns with Spaces"));
		}

		[TestMethod]
		public void ValidatorAlphaNum() {
			Assert.IsTrue(Valid.alphanum("L3tters"));
			Assert.IsTrue(Valid.alphanum("L4zyN3ss"));
			Assert.IsTrue(Valid.alphanum("TextOnly"));
			Assert.IsTrue(Valid.alphanum("1234"));

			Assert.IsFalse(Valid.alphanum("Text With spaces"));
			Assert.IsTrue(Valid.alphanum("L@zyN3ss")); // Special Chars should be false...
		}
	}
}
