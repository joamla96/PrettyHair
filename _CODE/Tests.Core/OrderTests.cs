using System;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.Core {

	[TestClass]
	public class OrderTests {
		OrderRepository RepoOdr;
		ProductTypeRepository RepoPT;
		CustomerRepository RepoCus;

		ProductType HairSpray;
		ProductType Shampoo;
		ProductType Conditioner;

		Customer John;
		Customer Jane;

		[TestInitialize]
		public void Init() {
			RepoOdr = new OrderRepository();
			RepoPT = new ProductTypeRepository();
			RepoCus = new CustomerRepository();

			HairSpray = new ProductType(1, "Hair Spray", 29.99, 5);
			Shampoo = new ProductType(2, "Shampoo", 10.99, 7);
			Conditioner = new ProductType(3, "Conditioner", 59.99, 200);

			Address Addr1 = new Address(28, "Fakestreet", 6881, "Town");
			John = new Customer(1, "John Doe", Addr1, "jodoe@example.com");

			Address Addr2 = new Address(35, "Anotherstreet", 9741, "Papertown");
			Jane = new Customer(1, "Jane Doe", Addr2, "jadoe@example.com");
		}

		[TestMethod]
		public void OrderIDcounter() {
			Assert.AreEqual(1, RepoOdr.NextID());
			Assert.AreEqual(2, RepoOdr.NextID());
			Assert.AreEqual(3, RepoOdr.NextID());
		}

		[TestMethod]
		public void CreateOrder() {
			DateTime Now = DateTime.Now;
			DateTime NextWeek = Now.AddDays(7);
			Order one = RepoOdr.Create(Now, NextWeek, John);
			RepoOdr.Add(one);

			List<Order> InRepo = RepoOdr.GetAll();

			Assert.IsTrue(InRepo.Contains(one));
		}

	}
}
