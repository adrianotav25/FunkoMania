using FunkoMania.Application.ViewModel;
using FunkoMania.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkoMania.Application.Interfaces
{
    public interface IOrderAppService
    {
        
        Task<OrderViewModel> SetCreateNewOrder(OrderViewModel model);
        
        Task<IEnumerable<OrderItemViewModel>> SetInsertNewItem(OrderItemViewModel model, Guid orderId);
        
        Task<IEnumerable<OrderItemViewModel>> DeleteItemInOrder(Guid orderItemId, Guid orderId);
        
        void UpdateQuantityItemInOrder(Guid orderItemId, int newQuantity);
       
        Task<OrderViewModel> UpdateStatusOrder(Guid orderId, OrderStatus newStatus);
       
        Task<OrderViewModel> SetAddressDelivery(Guid orderId, AddressViewModel addressModel);
       
        Task<OrderViewModel> SetApplyVoucher(Guid orderId, string code);
        
        Task<OrderSummaryViewModel> GetSummaryOrder(Guid orderId);

    }
}
