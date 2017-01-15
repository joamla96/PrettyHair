using System;
using System.Collections.Generic;
using System.Linq;

namespace Core {
	public class OrderRepository {
		private Dictionary<int, Order> Orders = new Dictionary<int, Order>();

		public int NextID() {
			int Latest = Orders.Keys.Last();
			return Latest + 1;
		}

		public void Add(Order order) {
			Orders.Add(order.ID, order);
		}

		public Order Get(int id) {
			return Orders[id];
		}

		public Order Create(DateTime orderDate, DateTime deliveryDate, Customer customer) {
			Order Order = new Order(this.NextID(), orderDate, deliveryDate, customer);
			return Order;
		}
	}
}
