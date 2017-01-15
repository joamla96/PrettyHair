using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}


}
