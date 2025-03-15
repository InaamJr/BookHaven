using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface IOrderRepository
    {
        int CreateOrder(OrderModel order, List<OrderDetailsModel> orderDetails);
        List<OrderModel> GetAllOrders();
        List<OrderDetailsModel> GetOrderDetails(int orderID);
        void UpdateOrder(int orderId, OrderModel order, List<OrderDetailsModel> orderDetails);
        void DeleteOrder(int orderID);
        //public void UpdateOrderDetails(Guid orderId, OrderDetailsModel orderDetails);

    }
}
