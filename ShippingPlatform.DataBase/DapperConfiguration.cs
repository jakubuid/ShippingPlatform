using Dapper.FluentMap;
using ShippingPlatform.DataBase.Mappers;

namespace ShippingPlatform.DataBase
{
    public static class DapperConfiguration
    {
        private static bool isConfigured = false;

        public static void Configure()
        {
            if (isConfigured)
            {
                return;
            }
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ClientMapper());
                config.AddMap(new AddressMapper());
                config.AddMap(new RouteMapper());
                config.AddMap(new PackageMapper());
                config.AddMap(new OrderMapper());
                config.AddMap(new LogisticCenterMapper());
                config.AddMap(new NotificationMapper());
            });
        }
    }
}