using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMR.Tracking.Platforms.Container
{
    public class AppContainerBuilder
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            // Register services


            return builder.Build();
        }
    }
}
