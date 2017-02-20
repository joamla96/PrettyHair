using System;
using System.Collections.Generic;
using System.Linq;

namespace Core {
	public class OrderRepository {
		private ICollection<Order> Orders = new List<Order>();
		int IDcounter = 0;
		public int NextID() {
			return ++IDcounter;
		}

		public void Add(Order order) {
			Orders.Add(order);
		}

		public Order Create(DateTime orderDate, DateTime deliveryDate, Customer customer) {
			Order Order = new Order(this.NextID(), orderDate, deliveryDate, customer);
			return Order;
		}

		public List<Order> GetAll() {
			return (List<Order>)Orders;
		} 
	}
}
