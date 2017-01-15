using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Core {
	[TestClass]
	class CustomerManager {
		CustomerRepository RepoCus;

		[TestInitialize]
		void InitCustomerTest() {
			RepoCus = new CustomerRepository();
		}

		[TestMethod]
		void CreateCustomer() {
			int ID = RepoCus.CreateNewCustomer("John Doe", "jdoe@example.com", 20, "Fakestreet", "Faketown", 5000);

			Customer Customer = RepoCus.Get(ID);

			Assert.AreEqual("John Doe", Customer.Name);
			Assert.AreEqual("jdoe@example.com", Customer.Email);
		}

		[TestMethod]
		void CheckNextID() {

		}

		[TestMethod]
		void AddCustomer() {

		}

		[TestMethod]
		void CustomerExists() {

		}

		[TestMethod]
		void GetCustomer() {

		}
	}
}
