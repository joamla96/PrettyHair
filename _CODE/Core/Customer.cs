using System;
using System.IO;

namespace Core {
	public class Customer {
		public int ID { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }
		public String Email { get; set; }

		public Customer(int id, string name, Address address, string email) {
			this.ID = id;
			this.Name = name;
			this.Address = address;
			this.Email = email;
		}

		public override string ToString() {
			Address Addr = this.Address;

			StringWriter Output = new StringWriter();

			Output.WriteLine("ID: " + this.ID);
			Output.WriteLine("Name: " + this.Name);
			Output.WriteLine("Email: "+ this.Email);
			Output.Write(Addr.ToString());

			return Output.ToString();
		}
	}


}
