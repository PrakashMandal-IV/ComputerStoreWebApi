namespace ComputerStoreWebApi.Data.Services
{
    public class OrdersService
    {
        private AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public void CreateOrder(OrderVM order, string userEmail)
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
        public bool ChangeOrderStatus(OrderStatus order, int orderId, string email)
        {
            var _user = _context.User.FirstOrDefault(x => x.Email == email);
            var _order = _context.Orders.FirstOrDefault(n => n.Id == orderId);
            if (_order == null || _order.Status != "pending" || _order.Status != "completed" || _order.Status != "return" || _order.Status != "approval" || _order.Status != "ready" || _order.Status != "shipped" || _order.Status != "Canceled")
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
        public bool ChangeOrderSubStatus(OrderSubStatus order, int orderId, string email)
        {
            var _user = _context.User.FirstOrDefault(x => x.Email == email);
            var _order = _context.Orders.FirstOrDefault(n => n.Id == orderId);
            if (_order == null || _order.Substatus!= "pending" || _order.Substatus != "received"|| _order.Substatus != "completed" || _order.Substatus != "return" || _order.Substatus != "approval" || _order.Substatus != "ready" || _order.Substatus != "shipped" || _order.Substatus != "Canceled")
            {
                return false;
            }
            else if(_order.Status == "pending" && (_order.Substatus != "approval" || _order.Substatus != "ready" || _order.Substatus != "shipped" || _order.Substatus != "completed"))
            {
                _order.Substatus = order.Substatus;
                _order.ModifiedId = _user?.Id;
                _order.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            else if (_order.Status == "completed" && (_order.Substatus != "received" || _order.Substatus != "return"))
            {
                _order.Substatus = order.Substatus;
                _order.ModifiedId = _user?.Id;
                _order.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            else if (_order.Status == "return" && (_order.Substatus != "picked up" || _order.Substatus != "refunded"))
            {
                _order.Substatus = order.Substatus;
                _order.ModifiedId = _user?.Id;
                _order.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            else return false;
        }
        public bool AddShipmentNumber(ShipmentNumber order, int orderId, string email)
        {
            var _user = _context.User.FirstOrDefault(x => x.Email == email);
            var _order = _context.Orders.FirstOrDefault(n => n.Id == orderId);
            if (_order?.Substatus == "shipped")
            {
                _order.ShipmentTrackingNumber = order.ShipmentTrackingNumber;
                _order.ModifiedId = _user?.Id;
                _order.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
                return true;        
            }
            else return false;
            

        }
        public List<Orders> GetAllOrders(string sort)
        {
            var _order = _context.Orders.OrderBy(n => n.CreatedAt).ToList();
            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "oldest")
                {
                    _order = _order.OrderByDescending(n => n.CreatedAt).ToList();
                }
            }

            return _order;
        }
        public List<Orders> GetPendingOrders()
        {
            var _orders = _context.Orders.Where(n => n.Status != "return").Where(x => x.Status != "completed").ToList();
            return _orders;
        }
        public List<Orders> GetCompletedOrders()
        {
            var _orders = _context.Orders.Where(n => n.Status == "completed").ToList();
            return _orders;
        }
        public List<Orders> GetReturnOrders()
        {
            var _orders = _context.Orders.Where(n => n.Status == "return").ToList();
            return _orders;
        }
        public List<Orders> GetOrderByProductId(int id)
        {
            var _order = _context.Orders.Where(n => n.ProductId == id).ToList();
            return _order;
        }
    }
}