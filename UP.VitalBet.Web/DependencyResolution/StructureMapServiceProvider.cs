using StructureMap;
using System;

namespace UP.VitalBet.Web.DependencyResolution
{
    public class StructureMapServiceProvider : IServiceProvider
    {
        private readonly IContainer container;

        public StructureMapServiceProvider(IContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }
    }
}