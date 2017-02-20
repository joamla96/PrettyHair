using System;
using System.IO;

namespace Core {
	public class Customer {
		public string Name { get; set; }
		public Address Address { get; set; }
		public string Email { get; set; }

		public Customer(string name, Address address, string email) {
			this.Name = name;
			this.Address = address;
			this.Email = email;
		}

		public override string ToString() {
			Address Addr = this.Address;

			StringWriter Output = new StringWriter();

			Output.WriteLine("Name: " + this.Name);
			Output.WriteLine("Email: "+ this.Email);
			Output.Write(Addr.ToString());

			return Output.ToString();
		}
	}


}
