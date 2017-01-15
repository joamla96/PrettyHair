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
