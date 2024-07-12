using FratSCWeb_Models;

namespace FratSCWeb_Client.Service.IService
{
    public interface IPaymentService
    {
        public Task<SuccessModelDTO> Checkout(StripePaymentDTO model);
    }
}
