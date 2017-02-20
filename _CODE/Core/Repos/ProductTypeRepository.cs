using System.Collections.Generic;
using System.Linq;

namespace Core {
	public class ProductTypeRepository {
		private Dictionary<int, ProductType> Repository = new Dictionary<int, ProductType>();
		// TODO: Update Diagram ^^
		public bool AdjustPrice(ProductType productType, double price) {	
			productType.SetPrice(price);
			return true;
		}

		public bool AdjustDescription(ProductType productType, string desc) {
			productType.SetDescription(desc);
			return true;
		}

		public bool AdjustAmount(ProductType productType, int amount) {
			productType.SetAmount(amount);
			return true;
		}

		public List<ProductType> GetProductTypes() {
			return Repository.Values.ToList();
		}

		public ProductType GetProduct(int ID) {
			return Repository[ID];
		}

		public void Add(ProductType P) {
			Repository.Add(P.ID, P);
		}


	}
}
