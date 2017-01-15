using System;
using System.Collections.Generic;
using System.Linq;

namespace Core {
	public class OrderRepository {
		private Dictionary<int, Order> Orders = new Dictionary<int, Order>();
		int IDcounter = 0;
		public int NextID() {
			return ++IDcounter;
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

		public List<Order> GetAll() {
			return Orders.Values.ToList();
		} 
	}
}
