﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Core {
	public class CustomerRepository {
		private Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();
		int IDcounter = 0;
		public int NextID() {
			return ++IDcounter;
		}

		public Customer Get(int id) {
			return Customers[id];
		}

		public List<Customer> GetAll() {
			return Customers.Values.ToList();
		}

		public int CreateNewCustomer(string name, string email, int houseno, string streetname, string city, int zipcode) {
			Address Addr = new Address(houseno, streetname, zipcode, city);
			Customer Customer = new Customer(this.NextID(), name, Addr, email);

			this.Add(Customer);

			return Customer.ID;
		}

		private void Add(Customer customer) {
			Customers.Add(customer.ID, customer);
		}

		public bool Exists(int id) {
			try {
				Customer A = Customers[id];
			} catch(KeyNotFoundException) {
				return false;
			}

			return true;
		}

	}
}