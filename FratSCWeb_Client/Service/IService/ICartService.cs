using FratSCWeb_Client.ViewModels;

namespace FratSCWeb_Client.Service.IService
{
    public interface ICartService
    {
        public event Action OnChange;
        Task DecrementCart(ShoppingCart shoppingCart);
        Task IncrementCart(ShoppingCart shoppingCart);
    }
}
