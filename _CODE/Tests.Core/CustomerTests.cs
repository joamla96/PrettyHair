using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core {
	[TestClass]
	public class CustomerTests {
		CustomerRepository RepoCus;

		[TestInitialize]
		public void InitCustomerTest() {
			RepoCus = new CustomerRepository();
		}

		[TestMethod]
		public void CreateCustomer() {
			int ID = RepoCus.CreateNewCustomer("John Doe", "jdoe@example.com", 20, "Fakestreet", "Faketown", 5000);

			Customer Customer = RepoCus.Get(ID);

			Assert.AreEqual("John Doe", Customer.Name);
			Assert.AreEqual("jdoe@example.com", Customer.Email);
		}

		[TestMethod]
		public void CheckNextID() {
			Assert.AreEqual(1, RepoCus.NextID());
			Assert.AreEqual(2, RepoCus.NextID());
		}

		[TestMethod]
		public void CustomerExists() {
			int ID = RepoCus.CreateNewCustomer("John Doe", "jdoe@example.com", 20, "Fakestreet", "Faketown", 5000);

			Assert.IsTrue(RepoCus.Exists(ID));
			Assert.IsFalse(RepoCus.Exists(555));
		}
	}
}
