using NServiceBus;

namespace Loveboat.Domain
{
    public class EndpointConfig :IConfigureThisEndpoint, AsA_Publisher
    {
    }
}
