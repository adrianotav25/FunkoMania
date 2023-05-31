using AutoMapper;
using FunkoMania.Application.Interfaces;
using FunkoMania.Application.ViewModel;
using FunkoMania.Core.Enums;
using FunkoMania.Domain.Entities;
using FunkoMania.Domain.Interfaces;
using FunkoMania.Domain.Shared.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Application.Services
{
    public class OrderAppService : BaseService, IOrderAppService
    {
        protected readonly IOrderRepository _orderRepository;
        protected readonly IOrderItemRepository _orderItemRepository;
        protected readonly IAddressRepository _addressRepository;
        protected readonly IClientRepository _clientRepository;
        protected readonly IProductRepository _productRepository;
        protected readonly IMapper _mapper;

        public OrderAppService(IMapper mapper,
            IUnitOfWork unitOfWork,
            IMediator bus,
            IOrderRepository repository,
            IOrderItemRepository orderItemRepository,
            IAddressRepository addressRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository) : base(unitOfWork, bus)


        {
            _mapper = mapper;
            _orderRepository = repository;
            _orderItemRepository = orderItemRepository;
            _addressRepository = addressRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;

        }

        public async Task<IEnumerable<OrderItemViewModel>> DeleteItemInOrder(Guid orderItemId, Guid orderId)
        {

            _orderItemRepository.Remove(orderItemId);
            Commit();

            IEnumerable<OrderItem> items = await _orderItemRepository.SearchAsync(oi => oi.OrderId == orderId);

            var viewModels = _mapper.Map<IEnumerable<OrderItemViewModel>>(items);

            return viewModels;
        }


        public Task<OrderSummaryViewModel> GetSummaryOrder(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderViewModel> SetAddressDelivery(Guid orderId, AddressViewModel addressModel)
        {

            var domain = _mapper.Map<Address>(addressModel);


            var address = await _addressRepository.AddAsync(entity: domain);
            Commit();


            var order = _orderRepository.GetById(orderId);
            order.SetAddress(address);

            _orderRepository.Update(order);
            Commit();

            return _mapper.Map<OrderViewModel>(order);
        }

        public Task<OrderViewModel> SetApplyVoucher(Guid orderId, string code)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderViewModel> SetCreateNewOrder(OrderViewModel model)
        {
            model.OrderStatus = OrderStatus.Criado;
            var domain = _mapper.Map<Order>(model);
            domain.CalculateOrderValue();
            domain.SetCode();


            var addressClientId = _clientRepository.GetById(domain.ClientId).AddressId;
            var addressClient = _addressRepository.GetbyId(addressClientId);
            domain.SetAddress(addressClient);

            var order = await _orderRepository.AddAsync(domain);
            Commit();

            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task<IEnumerable<OrderItemViewModel>> SetInsertNewItem(OrderItemViewModel model, Guid orderId)
        {
            var domain = _mapper.Map<OrderItem>(model);

            var product = _productRepository.GetById(model.ProductId);


            if (model.Amount > product.StockQuantity)
            {
                throw new Exception("Quantidade de compra maior que a quantidade disponível");
            }

            domain.SetProductName(product.Name);
            domain.SetProductImage(product.Image);



            _ = await _orderItemRepository.AddAsync(domain);
            Commit();


            var orderItems = await _orderItemRepository.SearchAsync(oi => oi.OrderId == orderId);


            return _mapper.Map<IEnumerable<OrderItemViewModel>>(orderItems);
        }

        public void UpdateQuantityItemInOrder(Guid orderItemId, int newQuantity)
        {

            var orderItem = _orderItemRepository.GetById(orderItemId);


            var product = _productRepository.GetById(orderItem.ProductId);
            if (newQuantity > product.StockQuantity)
            {
                throw new Exception("Quantidade de compra maior que a quantidade disponível");
            }


            orderItem.SetAmount(newQuantity);
            _orderItemRepository.Update(orderItem);
            Commit();
        }

        public async Task<OrderViewModel> UpdateStatusOrder(Guid orderId, OrderStatus newStatus)
        {

            var order = _orderRepository.GetById(orderId);


            if (order.OrderStatus == OrderStatus.Criado &&
                (newStatus == OrderStatus.Autorizado || newStatus == OrderStatus.EmProcessamento))
            {

                await SetStockOff(orderId);
            }



            if (order.OrderStatus == OrderStatus.EmProcessamento &&
                (newStatus == OrderStatus.Recusado || newStatus == OrderStatus.Cancelado))
            {
                await SetReturnedStock(orderId);
            }


            order.SetStatus(newStatus);
            _orderRepository.Update(order);
            Commit();

            return _mapper.Map<OrderViewModel>(order);
        }

        private async Task SetReturnedStock(Guid orderId)
        {
            IEnumerable<OrderItem> items = await _orderItemRepository.SearchAsync(oi => oi.OrderId == orderId);
            foreach (OrderItem item in items)
            {
                var product = _productRepository.GetById(item.ProductId);
                product.SetStockQuantity(product.StockQuantity + item.Amount);
                _productRepository.Update(product);
            }

            Commit();
        }

        private async Task SetStockOff(Guid orderId)
        {

            IEnumerable<OrderItem> items = await _orderItemRepository.SearchAsync(oi => oi.OrderId == orderId);

            foreach (OrderItem item in items)
            {
                var product = _productRepository.GetById(item.ProductId);


                if (item.Amount > product.StockQuantity)
                {

                    throw new Exception($"Quantidade de compra maior que a quantidade disponível. Produto: {product.Name}");
                }

                product.SetStockQuantity(product.StockQuantity - item.Amount);
                _productRepository.Update(product);
            }

            Commit();



        }
    }
}
