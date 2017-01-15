using Core;
using System;

namespace UserInterface_CLI {
	public class OrderManager {
		Program Program;
		CustomerManager CM;

		CustomerRepository RepoCus;
		OrderRepository RepoOdr;
		ProductTypeRepository RepoPT;
		public void OrderMenu(Program program) {
			this.Program = program;

			CM = Program.CM;
			RepoCus = Program.RepoCus;
			RepoOdr = Program.RepoOdr;
			RepoPT = Program.RepoPT;

			bool Running = true;

			while (Running) {
				Console.Clear();
				Console.WriteLine("Order Management System\n");

				Console.WriteLine("1. Create New Order");
				Console.WriteLine("x2. Delete Order");
				Console.WriteLine("x3. List Order");

				Console.WriteLine("\n0. Exit");

				switch(Program.GetInput("number")) {
					case "1":
						CreateNewOrder();
						break;

					case "2":
						DeleteOrder();
						break;

					case "3":
						ListOrders();
						break;

					case "0":
						Running = false;
						break;
				}
			}
		}

		private void ListOrders() {
			throw new NotImplementedException();
		}

		private void DeleteOrder() {
			throw new NotImplementedException();
		}

		private void CreateNewOrder() {
			Console.Clear();
			Console.Write("Type Customer ID: ");
			int CustomerID = int.Parse(Program.GetInput("number"));

			if(!RepoCus.Exists(CustomerID)) {
				CustomerID = CM.CreateNewCustomer();
			}

			Customer Customer = RepoCus.Get(CustomerID);

			Console.Write("Delivery Date: ");
			DateTime DeliveryDate = DateTime.Parse(Program.GetInput("date"));

			// Order date is right now, deal with it.
			DateTime OrderDate = DateTime.Now;

			Order Order = RepoOdr.Create(OrderDate, DeliveryDate, Customer);

			bool AddOrderLines = true;
			do { // TODO: List Products before asking for id?
				// TODO: Should maybe be a seperate method?
				Console.Clear();
				Console.WriteLine("Add Products to Order");

				Console.Write("Product ID: "); //TODO: Check if product actually exists
				int ProductTypeID = int.Parse(Program.GetInput("number"));

				Console.Write("\nQuantity: ");
				int Quantity = int.Parse(Program.GetInput("number"));

				ProductType PT = RepoPT.GetProduct(ProductTypeID);
				OrderLine OL = new OrderLine(PT, Quantity);

				Order.AddOrderLine(OL);

				Console.WriteLine("\nAdd more products to order? (Y/N)");
				string Continue = Program.GetInput("yn");

				switch(Continue) {
					case "N":
					case "n":
						AddOrderLines = false;
						break;
				}
			} while (AddOrderLines);

			// TODO: View full order (confirmation), before saving order
			RepoOdr.Add(Order);
		}
	}
}
