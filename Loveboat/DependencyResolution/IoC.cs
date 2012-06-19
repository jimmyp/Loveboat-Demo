using Loveboat.CommandHandlers;
using Loveboat.EventHandlers;
using StructureMap;

namespace Loveboat.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                        scan.AddAllTypesOf(typeof(ICommandHandler<>));
                                        scan.AddAllTypesOf(typeof(IEventHandler<>));
                                    });
                        });
            return ObjectFactory.Container;
        }
    }
}