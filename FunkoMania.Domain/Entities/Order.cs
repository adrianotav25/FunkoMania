using FunkoMania.Core.DomainObjects;
using FunkoMania.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Domain.Entities
{
    public class Order : Entity
    {
        public Guid ClientId { get; private set; }
        public decimal TotalValue { get; private set; }
        public string Code { get; private set; }
        public Guid AddressId { get; private set; }
        public Address Address { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;


        public Order(Guid clientId, decimal totalValue, string code, Guid addressId, List<OrderItem> orderItems)
        {
            ClientId = clientId;
            TotalValue = totalValue;
            Code = code;
            AddressId = addressId;
            _orderItems = orderItems;

        }

        public void AuthorizeOrder()
        {
            OrderStatus = OrderStatus.Autorizado;
        }
        public void CancelOrder()
        {
            OrderStatus = OrderStatus.Cancelado;
        }

        public void FinalizeOrder()
        {
            OrderStatus = OrderStatus.Pago;
        }

        public void SetAddress(Address address)
        {
            Address = address;
            AddressId = address.Id;
        }

        public void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(p => p.CalculeValue());
            
        }
        

        


    }
}
