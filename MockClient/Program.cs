using System;
using Autofac;
using Lutron.Common.Interfaces;
using Lutron.Connector;
using Lutron.Service;

namespace MockClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = GetDependencyContainer();

            using (var lifetimeScope = container.BeginLifetimeScope())
            {
                var outputService = lifetimeScope.Resolve<IOutputService>();
                var outputLevel = outputService.GetOutputLevel(2);
                Console.WriteLine(outputLevel);
                Console.ReadLine();
            }
        }

        private static IContainer GetDependencyContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OutputService>().As<IOutputService>();
            builder.RegisterType<MyRoomPlusConnector>().As<IMyRoomPlusConnector>();
            builder.RegisterType<MyRoomPlusClient>().As<IMyRoomPlusClient>();
            builder.RegisterType<MyRoomPlusClientConfiguration>().As<IMyRoomPlusClientConfiguration>();
            var container = builder.Build();
            return container;
        }
    }
}