using Braintree;

namespace CoinR.Services;

public class BraintreeService
{
    private readonly IConfiguration config;

    public BraintreeService(IConfiguration config)
    {
        this.config = config;
    }

    public IBraintreeGateway createGateway()
    {
        var braintreeGateway = new BraintreeGateway()
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = config.GetValue<string>("BraintreeGateway:MerchantId"),
            PublicKey = config.GetValue<string>("BraintreeGateway:PublicKey"),
            PrivateKey = config.GetValue<string>("BraintreeGateway:PrivateKey")
        };
        return braintreeGateway;
    }

    public IBraintreeGateway getGateway()
    {
        return createGateway();
    }
}