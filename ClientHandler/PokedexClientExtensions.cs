using ClientHandler.ClientHandlers;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;

namespace ClientHandler
{
    public static class PokedexClientExtensions
    {
        public static IServiceCollection RegisterGlobalHandlers(this IServiceCollection services)
        {
            services.AddSingleton<OutgoingRequestHandlerFactory>();

            services.ConfigureAll<HttpClientFactoryOptions>(options =>
            {
                options.HttpMessageHandlerBuilderActions.Add(builder =>
                {
                    var handlerFactory = builder.Services.GetRequiredService<OutgoingRequestHandlerFactory>();
                    builder.AdditionalHandlers.Add(handlerFactory.CreateHandler(builder.Name));
                });

            });

            return services;
        }

        public static IServiceCollection AddPokedexClient(this IServiceCollection services)
        {
            services.RegisterGlobalHandlers();

            var outgoingRequestHandlerSettings = new OutgoingRequestHandlerSettings
            {
                ResponseHeader = "pokemon-header"
            };

            services.AddHttpClient<IPokedexClient, PokedexClient>(client =>
                {
                    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
                })
                    .AddClientHandlerSettings(outgoingRequestHandlerSettings);

            return services;
        }
    }

    public static class HttpClientHandlerSettingsExtensions
    {
        public static IHttpClientBuilder AddClientHandlerSettings<T>(this IHttpClientBuilder clientBuilder, T settings)
            where T : class, new()
        {
            clientBuilder.Services.TryAddSingleton<SettingsFactory<T>>();

            clientBuilder.Services.AddSingleton(new SettingsFactoryOptions<T>(clientBuilder.Name, settings));

            return clientBuilder;
        }
    }
}
