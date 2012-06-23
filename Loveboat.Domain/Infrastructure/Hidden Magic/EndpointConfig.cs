using NServiceBus;
using StructureMap;

namespace Loveboat.Domain.Infrastructure
{
    public class EndpointConfig :IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            });

            Configure.With()
                .StructureMapBuilder(ObjectFactory.Container);
        }
    }
}
