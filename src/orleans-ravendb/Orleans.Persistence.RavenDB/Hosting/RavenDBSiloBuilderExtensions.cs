using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Storage;

namespace Orleans.Hosting
{
    /// <summary>
    /// Configure silo to use RavenDB storage as the default grain storage.
    /// Adapted from Azure blob reference implementation which can be found on: 
    /// https://github.com/sjefvanleeuwen/orleans/blob/master/src/Azure/Orleans.Persistence.AzureStorage/Hosting/AzureBlobSiloBuilderExtensions.cs
    /// </summary>
    public static class RavenDBSiloBuilderExtensions
    {
        /// <summary>
        /// Configure silo to use RavenDB as the default grain storage.
        /// </summary>
        public static ISiloHostBuilder AddRavenDBGrainStorageAsDefault(this ISiloHostBuilder builder, Action<RavenDBStorageOptions> configureOptions)
        {
            return builder.AddRavenDBGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use RavenDB for grain storage.
        /// </summary>
        public static ISiloHostBuilder AddRavenDBGrainStorage(this ISiloHostBuilder builder, string name, Action<RavenDBStorageOptions> configureOptions)
        {
            return builder.ConfigureServices(services => services.AddRavenDBGrainStorage(name, configureOptions));
        }

        /// <summary>
        /// Configure silo to use RavenDB as the default grain storage.
        /// </summary>
        public static ISiloHostBuilder AddRavenDBGrainStorageAsDefault(this ISiloHostBuilder builder, Action<OptionsBuilder<RavenDBStorageOptions>> configureOptions = null)
        {
            return builder.AddRavenDBGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use RavenDB for grain storage.
        /// </summary>
        public static ISiloHostBuilder AddRavenDBGrainStorage(this ISiloHostBuilder builder, string name, Action<OptionsBuilder<RavenDBStorageOptions>> configureOptions = null)
        {
            return builder.ConfigureServices(services => services.AddRavenDBGrainStorage(name, configureOptions));
        }

        /// <summary>
        /// Configure silo to use RavenDB as the default grain storage.
        /// </summary>
        public static ISiloBuilder AddRavenDBGrainStorageAsDefault(this ISiloBuilder builder, Action<RavenDBStorageOptions> configureOptions)
        {
            return builder.AddRavenDBGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use RavenDB for grain storage.
        /// </summary>
        public static ISiloBuilder AddRavenDBGrainStorage(this ISiloBuilder builder, string name, Action<RavenDBStorageOptions> configureOptions)
        {
            return builder.ConfigureServices(services => services.AddRavenDBGrainStorage(name, configureOptions));
        }

        /// <summary>
        /// Configure silo to use RavenDB as the default grain storage.
        /// </summary>
        public static ISiloBuilder AddRavenDBGrainStorageAsDefault(this ISiloBuilder builder, Action<OptionsBuilder<RavenDBStorageOptions>> configureOptions = null)
        {
            return builder.AddRavenDBGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use RavenDB for grain storage.
        /// </summary>
        public static ISiloBuilder AddRavenDBGrainStorage(this ISiloBuilder builder, string name, Action<OptionsBuilder<RavenDBStorageOptions>> configureOptions = null)
        {
            return builder.ConfigureServices(services => services.AddRavenDBGrainStorage(name, configureOptions));
        }

        /// <summary>
        /// Configure silo to use RavenDB as the default grain storage.
        /// </summary>
        public static IServiceCollection AddRavenDBGrainStorageAsDefault(this IServiceCollection services, Action<RavenDBStorageOptions> configureOptions)
        {
            return services.AddRavenDBGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, ob => ob.Configure(configureOptions));
        }

        /// <summary>
        /// Configure silo to use RavenDB for grain storage.
        /// </summary>
        public static IServiceCollection AddRavenDBGrainStorage(this IServiceCollection services, string name, Action<RavenDBStorageOptions> configureOptions)
        {
            return services.AddRavenDBGrainStorage(name, ob => ob.Configure(configureOptions));
        }

        /// <summary>
        /// Configure silo to use RavenDB as the default grain storage.
        /// </summary>
        public static IServiceCollection AddRavenDBGrainStorageAsDefault(this IServiceCollection services, Action<OptionsBuilder<RavenDBStorageOptions>> configureOptions = null)
        {
            return services.AddRavenDBGrainStorage(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME, configureOptions);
        }

        /// <summary>
        /// Configure silo to use RavenDB for grain storage.
        /// </summary>
        public static IServiceCollection AddRavenDBGrainStorage(this IServiceCollection services, string name,
            Action<OptionsBuilder<RavenDBStorageOptions>> configureOptions = null)
        {
            configureOptions?.Invoke(services.AddOptions<RavenDBStorageOptions>(name));
            services.AddTransient<IConfigurationValidator>(sp => new RavenDBStorageOptionsValidator(sp.GetRequiredService<IOptionsMonitor<RavenDBStorageOptions>>().Get(name), name));
            services.ConfigureNamedOptionForLogging<RavenDBStorageOptions>(name);
            services.TryAddSingleton<IGrainStorage>(sp => sp.GetServiceByName<IGrainStorage>(ProviderConstants.DEFAULT_STORAGE_PROVIDER_NAME));
            return services.AddSingletonNamedService<IGrainStorage>(name, RavenDBGrainStorageFactory.Create)
                           .AddSingletonNamedService<ILifecycleParticipant<ISiloLifecycle>>(name, (s, n) => (ILifecycleParticipant<ISiloLifecycle>)s.GetRequiredServiceByName<IGrainStorage>(n));
        }
    }
}
