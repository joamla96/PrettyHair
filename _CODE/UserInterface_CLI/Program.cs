using System;
using Core;

namespace UserInterface_CLI {
	public class Program {
		public CustomerRepository RepoCus = new CustomerRepository();
		public OrderRepository RepoOdr = new OrderRepository();
		public ProductTypeRepository RepoPT = new ProductTypeRepository();

		public CustomerManager CM;
		public OrderManager OM;
		static void Main(string[] args) {
			Program a = new Program();
			a.Init();
			a.Run();
		}

		private void Init() { // Initialize for debug
							 // NOTE: Remove before production
			ProductType A = new ProductType();
			A.ID = 1; A.Amount = 10; A.Description = "Apple"; A.Price = 5.99;

			ProductType B = new ProductType();
			B.ID = 2; B.Amount = 50; B.Description = "Pear"; B.Price = 4.99;

			ProductType C = new ProductType();
			C.ID = 3; C.Amount = 25; C.Description = "Shovel"; C.Price = 2;

			RepoPT.Add(A);
			RepoPT.Add(B);
			RepoPT.Add(C);

			RepoCus.CreateNewCustomer("John Doe", "jodoe@example.com", 28, "Fakestreet", "Papertown", 5880);
			RepoCus.CreateNewCustomer("Jane Doe", "jadoe@example.com", 30, "Fakestreet", "Papertown", 5881);
		}

		private void Run() {
			CM = new CustomerManager();
			OM = new OrderManager();

			bool running = true;
			while (running) {
				Console.Clear();
				Console.WriteLine("1. List all Product Types");
				Console.WriteLine("2. Update a Product");
				Console.WriteLine("3. Access Customer Manager");
				Console.WriteLine("4. Access Order Manager");

				Console.WriteLine("\n0. Exit");
				string Menu = GetInput("number");
				switch (Menu) {
					case "0":
						running = false;
						break;

					case "1":
						Console.Clear();
						ListAllPT();
						Console.ReadKey();
						break;

					case "2":
						Console.Clear();
						UpdateProduct();
						Console.ReadKey();
						break;

					case "3":
						CM.CustomerMenu(this);
						break;

					case "4":
						OM.OrderMenu(this);
						break;
				}
			}
		}

		private void ListAllPT() {
			foreach (ProductType PT in RepoPT.GetProductTypes()) {
				Console.WriteLine(PT.ToString());
			}

		}

		private void UpdateProduct() { //Refactor, too big, too much stuff
			bool running = true;
			ProductType PT;

			while (running) {
				Console.Clear();
				ListAllPT();

				Console.WriteLine("\nType Product ID:");
				int ProductID = int.Parse(GetInput("number"));
				PT = RepoPT.GetProduct(ProductID);

				Console.WriteLine("1. Update Description");
				Console.WriteLine("2. Update Price");
				Console.WriteLine("3. Update Amount");

				Console.WriteLine("\n0. Back to Main Menu");

				

				string Menu = GetInput("number");

				switch (Menu) {
					case "1":
						Console.WriteLine("New Description:");
						string newText = GetInput();
						RepoPT.AdjustDescription(PT, newText);
						Console.WriteLine("Done");
						Console.ReadKey();
						break;

					case "2":
						Console.WriteLine("New Price:");
						int newPrice = int.Parse(GetInput("number"));
						RepoPT.AdjustPrice(PT, newPrice);
						Console.WriteLine("Done");
						Console.ReadKey();
						break;

					case "3":
						Console.WriteLine("New Amount:");
						int newAmount = int.Parse(GetInput("number"));
						RepoPT.AdjustPrice(PT, newAmount);
						Console.WriteLine("Done");
						Console.ReadKey();
						break;

					case "0":
						running = false;
						break;
				}
			}
		}

		internal string GetInput(string rule = "", string err = "") {
			// Rewrite to be a loop instread of recursive function...
			// ... because Alan dislikes recursive functions
			if (err != "") {
				Console.WriteLine("\n" + err);
				Console.WriteLine("Try again!\n");
			}
			string Input = Console.ReadLine();
			Validator Valid = new Validator();
			switch (rule) {
				case "text":
					if (!Valid.text(Input)) return GetInput(rule, "Text Only!");
					break;

				case "number":
					if (!Valid.number(Input)) return GetInput(rule, "Numbers Only!");
					break;

				case "email":
					if (!Valid.email(Input)) return GetInput(rule, "Please type a valid email [text]@[doamin].[tld]");
					break;

				case "yn":
					if (!Valid.yesno(Input)) return GetInput(rule, "Please type either Yes (Y), or No (N).");
					break;

				case "date":
					if (!Valid.date(Input)) return GetInput(rule, "Please enter valid date (dd/mm/yyyy)");
				default:
					// If a rule is set, but doesent exists, expect the programmer wanted to validate
					// but forgot to make a rule set for it...
					if (rule != "") throw new Exception("Invalid Validation Parameter");
					break;
			}
			return Input;
		}
	}
}
