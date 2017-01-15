using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	public class OrderLine {
		public ProductType ProductType { get; set; }
		public int Quantity { get; set; }

		public OrderLine(ProductType pT, int quantity) {
			this.ProductType = pT;
			Quantity = quantity;
		}

	}
}
