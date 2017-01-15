using Core;
using System;
using System.Collections.Generic;

namespace UserInterface_CLI {
	public class CustomerManager {
		Program Program;
		CustomerRepository CustomerRepo;

		public void CustomerMenu(Program program) {
			this.Program = program;
			CustomerRepo = Program.RepoCus;

			bool Running = true;

			while (Running) {
				Console.Clear();
				Console.WriteLine("Customer Management\n");
				Console.WriteLine("1. Create New Customer");
				Console.WriteLine("2. Update Customer Information");
				Console.WriteLine("3. Delete Customer");
				Console.WriteLine("4. List All Customers");

				Console.WriteLine("\n0. Back to Main Menu");

				switch (Program.GetInput("number")) {
					case "0":
						Running = false;
						break;

					case "1":
						CreateNewCustomer();
						break;

					case "2":
						UpdateCustomerInformation();
						break;

					case "3":
						DeleteCustomer();
						break;

					case "4":
						ListCustomers();
						break;
				}
			}
		}

		private void ListCustomers() {
			Console.Clear();
			List<Customer> Customers = CustomerRepo.GetAll();

			if (Customers.Count == 0) {
				Console.WriteLine("No Customers Exists");
			} else {

				foreach (Customer C in Customers) {
					Console.WriteLine(C.ToString());
				}

			}

			Console.ReadKey();

		}

		private void DeleteCustomer() {
			throw new NotImplementedException();
		}

		private void UpdateCustomerInformation() {
			throw new NotImplementedException();
		}

		internal int CreateNewCustomer() { // Returns int, used in Order Manager.
			Console.Clear();

			Console.WriteLine("Create New Customer\n");

			Console.Write("First Name: ");
			string FirstName = Program.GetInput("text");

			Console.Write("\nLast Name: ");
			string LastName = Program.GetInput("text");

			Console.Write("\nHouse Number: ");
			int HouseNo = int.Parse(Program.GetInput("number")); // No need to tryparse, as validator checks if its a number

			Console.Write("\nStreet Name: ");
			string Streetname = Program.GetInput("text");

			Console.Write("\nCity: ");
			string City = Program.GetInput("text");

			Console.Write("\nZip Code: ");
			int ZipCode = int.Parse(Program.GetInput("number"));

			Console.Write("\nEmail: ");
			string Email = Program.GetInput("email");

			int CustomerID = CustomerRepo.CreateNewCustomer(FirstName + " " + LastName, Email, HouseNo, Streetname, City, ZipCode);

			Console.WriteLine("\nCustomer was created successfully...");
			Console.ReadKey();

			return CustomerID;
		}
	}
}
