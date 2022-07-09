using Braintree;

namespace CoinR.Services;

public interface IBraintreeService
{
    IBraintreeGateway CreateGateway();
    IBraintreeGateway GetGateway();
}