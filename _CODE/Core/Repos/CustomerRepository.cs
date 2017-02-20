using System;
using System.Collections.Generic;
namespace Core {
	public class CustomerRepository {
		private ICollection<Customer> Customers = new List<Customer>();
		int IDcounter = 0;
		public int NextID() {
			return ++IDcounter;
		}

		public List<Customer> GetAll() {
			return (List<Customer>)Customers;
		}

		public Customer CreateNewCustomer(string name, string email, int houseno, string streetname, string city, int zipcode) {
			Address Addr = new Address(houseno, streetname, zipcode, city);
			Customer Customer = new Customer(name, Addr, email);

			this.Add(Customer);

			return Customer;
		}

		private void Add(Customer customer) {
			Customers.Add(customer);
		}

		public bool Exists(Customer Customer) {
			return Customers.Contains(Customer);
		}

	}
}
