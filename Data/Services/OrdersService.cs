﻿namespace ComputerStoreWebApi.Data.Services
{
    public class OrdersService
    {
        private AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public void CreateOrder(OrderVM order,string userEmail)
        {
            var _product = _context.Product.FirstOrDefault(x => x.Id == order.ProductId);
            var _user = _context.User.FirstOrDefault(x => x.Email == userEmail);
            var _order = new Orders()
            {
                Paid = order.Paid,
            };
            _context.Orders.Add(_order);
            _order.ProductId = _product?.Id;
            _order.CreatorId = _user?.Id;
            // LINE TO ADD ADDRESS LATER //
            _order.Status = "pending";
            _order.CreatedAt = DateTime.Now;
            _context.SaveChanges();
            var _userOrder = new UserOrder()
            {
                OrderId = _order.Id,
                UserId = _user.Id,
            };
            _context.UserOrder.Add(_userOrder);
            _context.SaveChanges();
        }
        public bool ChangeOrderStatus(OrderStatus order,int orderId,string email)
        {
            var _user = _context.User.FirstOrDefault(x => x.Email == email);
            var _order = _context.Orders.FirstOrDefault(n => n.Id == orderId);
            if (_order == null || _order.Status != "pending"|| _order.Status != "completed"|| _order.Status != "return")
            {
                return false;
            }
            else
            {
                _order.Status = order.Status;
                _order.ModifiedId = _user?.Id;
                _order.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
                return true;
            }

        }
    }
}
